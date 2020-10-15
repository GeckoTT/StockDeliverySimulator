using System;
using System.IO;
using System.Text;
using System.Threading;
using CareFusion.Mosaic.Core.Logging;
using Rowa.Lib.Log;

namespace CareFusion.Mosaic.Converters
{
    /// <summary>
    /// Class which implements the logic to read and write UTF-8 encoded XML messages.
    /// </summary>
    public class XmlMessageStream : IDisposable
    {
        #region Constants

        /// <summary>
        /// Maximum supported length of a XML message in bytes.
        /// </summary>
        private const int MaxMessageLength = 100000000;

        /// <summary>
        /// Size of the read buffer to use when reading messages.
        /// </summary>
        private const int ReadBufferSize = 4194304;

        /// <summary>
        /// Template for the Start indicator of a XML object message.
        /// </summary>
        private const string MessageStartTemplate = "<{0}";

        /// <summary>
        /// Template for the end indicator of a XML object message.
        /// </summary>
        private const string MessageEndTemplate = "</{0}>";

        /// <summary>
        /// The start of a CDATA section.
        /// </summary>
        private const string StartCData = "![CDATA[";

        /// <summary>
        /// The end of a CDATA section.
        /// </summary>
        private const string EndCData = "]]";

        #endregion

        #region Members

        /// <summary>
        /// The binary stream to use for reading and writing serialized objects.
        /// </summary>
        private Stream _stream = null;

        /// <summary>
        /// Reference to the message trace log file.
        /// </summary>
        private IWwi _messageTrace = null;

        /// <summary>
        /// Holds the XML message start tag as UTF-8 encoded byte array. 
        /// </summary>
        protected byte[] _xmlStartTag = null;

        /// <summary>
        /// Holds the XML message end tag as UTF-8 encoded byte array. 
        /// </summary>
        private byte[] _xmlEndTag = null;

        /// <summary>
        /// Read buffer to use when reading bytes from the underlying stream.
        /// </summary>
        private byte[] _readBuffer = new byte[ReadBufferSize];

        /// <summary>
        /// Overlapped buffer for unprocessed data of the last read call.
        /// </summary>
        private byte[] _overlappedBuffer = null;

        /// <summary>
        /// Event to cancel any blocking read and write operations.
        /// </summary>
        private ManualResetEvent _cancelEvent = new ManualResetEvent(false);

        /// <summary>
        /// Holds the XML message for the beginning of a CDATA section.
        /// </summary>
        private readonly byte[] _startCData = null;

        /// <summary>
        /// Holds the XML message for the ending of a CDATA section.
        /// </summary>
        private readonly byte[] _endCData = null;

        private int _msgStartIndex = -1;
        private int _startCDataIndex = -1;
        private int _endCDataIndex = -1;

        #endregion

        #region Methods

        /// <summary>
        /// Initializes a new instance of the <see cref="XmlMessageStream" /> class.
        /// </summary>
        /// <param name="stream">The base stream to use for reading and writing XML messages.</param>
        /// <param name="xmlRootTag">The XML root tag of the XML messages.</param>
        /// <param name="traceDescription">The WWI trace description.</param>
        /// <param name="traceEndPoint">The WWI trace endpoint.</param>
        public XmlMessageStream(Stream stream, 
                                string xmlRootTag, 
                                string traceDescription = null,
                                string traceEndPoint = null)
        {
            if (stream == null)
            {
                throw new ArgumentException("Invalid stream specified.");
            }

            if (string.IsNullOrEmpty(xmlRootTag))
            {
                throw new ArgumentException("Invalid xmlRootTag specified.");
            }

            _stream = stream;
            _xmlStartTag = Encoding.UTF8.GetBytes(string.Format(MessageStartTemplate, xmlRootTag));
            _xmlEndTag = Encoding.UTF8.GetBytes(string.Format(MessageEndTemplate, xmlRootTag));
            _startCData = Encoding.UTF8.GetBytes(StartCData);
            _endCData = Encoding.UTF8.GetBytes(EndCData);

            if ((string.IsNullOrEmpty(traceDescription) == false) &&
                (string.IsNullOrEmpty(traceEndPoint) == false))
            {
                ushort tracePort = 0;
                int index = traceEndPoint.IndexOf(':');

                if ((index > 0) && (index < traceEndPoint.Length - 1))
                {
                    ushort.TryParse(traceEndPoint.Substring(index + 1), out tracePort);
                    traceEndPoint = traceEndPoint.Substring(0, index);
                }

                WwiLogIntercept.CreateBaseWwiLogger(traceDescription, traceEndPoint, tracePort);
                _messageTrace = WwiLogIntercept.GetSingleton();
            }
        }

        /// <summary>
        /// Writes the specified XML message to the underlying stream.
        /// </summary>
        /// <param name="xmlMessage">The XML message to write.</param>
        /// <param name="length">The length of the XML message to write.</param>
        /// <returns>
        ///   <c>true</c> if successful, <c>false</c> otherwise.
        /// </returns>
        public bool Write(byte[] xmlMessage, int length)
        {
            if (_cancelEvent.WaitOne(0))
            {
                return false;
            }

            if ((xmlMessage == null) || (length == 0))
            {
                return false;
            }

            IAsyncResult writeResult = _stream.BeginWrite(xmlMessage, 0, length, null, null);

			using( WaitHandle writeHandle = writeResult.AsyncWaitHandle )
			{
				WaitHandle[] writeHandles = new WaitHandle[] { _cancelEvent, writeHandle };

				int waitResult = (_stream.WriteTimeout > 0) ? WaitHandle.WaitAny(writeHandles, _stream.WriteTimeout) : WaitHandle.WaitAny(writeHandles);

				if (waitResult == WaitHandle.WaitTimeout)
				{
					return false;
				}

				if (writeHandles[waitResult] == _cancelEvent)
				{
					this.Info("Writing of XML message was cancelled.");
					return false;
				}

				_stream.EndWrite(writeResult);
				_stream.Flush();

				if (_messageTrace != null)
				{
					_messageTrace.LogMessage(xmlMessage, 0, length, false);
				}
			}

            return true;
        }

        /// <summary>
        /// Reads the next XML message from the underlying stream.
        /// </summary>
        /// <param name="readTimeOutSeconds">The optional read time out seconds in seconds (0 means no timeout).</param>
        /// <returns>
        /// Read XML message if successful;<c>null</c> otherwise.
        /// </returns>
        public byte[] Read(int readTimeOutSeconds)
        {
            bool messageComplete = false;
            
            byte[] extractedMessage = null;

            int numBytesRead = 0;
            byte[] collectBuffer = null;

            if (_overlappedBuffer != null)
            {
                extractedMessage = null;
                
                this.ExtractMessage(_overlappedBuffer, ref extractedMessage, ref messageComplete);
                
                if( messageComplete == true )
                {
                    return extractedMessage;
                }
                collectBuffer = new byte[_overlappedBuffer.Length];
                Array.Copy(_overlappedBuffer, collectBuffer, _overlappedBuffer.Length);
                _overlappedBuffer = null;
            }

            while ((numBytesRead = ReadChunk(readTimeOutSeconds)) > 0)
            {
                if (collectBuffer == null)
                {
                    collectBuffer = new byte[numBytesRead];
                }
                else
                {
                    Array.Resize(ref collectBuffer, collectBuffer.Length + numBytesRead);
                }

                if (collectBuffer.Length >= MaxMessageLength)
                {
                    this.Fatal("The received buffer exceeded the maximum of {0} bytes.", MaxMessageLength);
                    return null;
                }

                Array.Copy(_readBuffer, 0, collectBuffer, collectBuffer.Length - numBytesRead, numBytesRead);
                extractedMessage = null;
                this.ExtractMessage(collectBuffer, ref extractedMessage, ref messageComplete);
                
                if( messageComplete == true )
                {
                    collectBuffer = null;

                    if (_messageTrace != null)
                    {
                        _messageTrace.LogMessage(extractedMessage, 0, extractedMessage.Length, true);
                    }

                    return extractedMessage;
                }
            }

            this.Info( "No more bytes to read from stream." );

            if( collectBuffer != null )
            {
                String collectedString = Encoding.UTF8.GetString( collectBuffer ).Trim();

                if( String.IsNullOrEmpty( collectedString ) == false )
                {
                    this.Error( $"Invalid message received: { Environment.NewLine }'{ Encoding.UTF8.GetString( collectBuffer ) }'" );
                    throw new Exception( Encoding.UTF8.GetString( collectBuffer ) );
                }else
                {
                    this.Info( $"Removed whitespaces from message: { Environment.NewLine }'{ Encoding.UTF8.GetString( collectBuffer ) }'" );
                }
            }

            return null;
        }

        /// <summary>
        /// Extract from the buffer to the extractedMessage, extra data will be pushed to the overlapped buffer.
        /// </summary>
        /// <param name="buffer">The buffer to extract message from</param>
        /// <param name="extractedMessage">The extracted message, null if nothing to extract.</param>
        /// <returns>
        /// True if the Buffer contained a message to process. <c>False</c> otherwise.
        /// </returns>
        private void ExtractMessage(byte[] buffer, ref byte[] extractedMessage, ref bool messageComplete )
        {
            int msgStartIndex = buffer.GetIndexOf(_xmlStartTag);
            int msgEndIndex = buffer.GetIndexOf(_xmlEndTag);

            int startCDataIndex = buffer.GetIndexOf(_startCData);

            if( msgStartIndex >= 0 )
            {
                if( startCDataIndex >= 0 )
                {
                    if( this._endCDataIndex >= 0 )
                    {
                        msgEndIndex = buffer.GetIndexOf(_xmlEndTag);
                    }else
                    {
                        this._endCDataIndex = buffer.GetIndexOf(_endCData);
                    }
                }else
                {
                    msgEndIndex = buffer.GetIndexOf(_xmlEndTag);
                }

                if( msgEndIndex >= 0 )
                {
                    if( msgEndIndex < this._endCDataIndex )
                    {
                        msgEndIndex = buffer.GetIndexOf(_xmlEndTag, msgEndIndex + 1);
                    }

                    msgEndIndex += _xmlEndTag.Length;

                    if (buffer.Length > msgEndIndex)
                    {
                        String contentBetweenMessages = Encoding.UTF8.GetString( buffer, msgEndIndex, buffer.Length - msgEndIndex );

                        if( String.IsNullOrEmpty( contentBetweenMessages ) == false )
                        {
                            int startIndex = contentBetweenMessages.IndexOf( Encoding.UTF8.GetString( _xmlStartTag ) );

                            if( startIndex > 0 )
                            {
                                try
                                {
                                    byte[] removedContent = new byte[ startIndex ];

                                    Array.Copy( buffer, msgEndIndex, removedContent, 0, startIndex );

                                    this.Info( $"Removed content between messages: '{ Encoding.UTF8.GetString( removedContent ) }'" );
                                }catch
                                {
                                }

                                _overlappedBuffer = new byte[buffer.Length - ( msgEndIndex + startIndex)];
                                Array.Copy(buffer, msgEndIndex + startIndex, _overlappedBuffer, 0, _overlappedBuffer.Length);
                                Array.Resize(ref buffer, msgEndIndex);
                            }else
                            {
                                _overlappedBuffer = new byte[buffer.Length - msgEndIndex];
                                Array.Copy(buffer, msgEndIndex, _overlappedBuffer, 0, _overlappedBuffer.Length);
                                Array.Resize(ref buffer, msgEndIndex);
                            }
                        }else
                        {
                            _overlappedBuffer = null;    
                        }
                    }else
                    {
                        _overlappedBuffer = null;
                    }
                
                    if( msgStartIndex < 0 )
                    {
                        msgStartIndex = 0;
                    }

                    extractedMessage = new byte[buffer.Length - msgStartIndex];

                    try
                    {
                        Array.Copy(buffer, msgStartIndex, extractedMessage, 0, extractedMessage.Length);
                    }
                    catch(Exception)
                    {
                        throw new Exception(Encoding.UTF8.GetString(buffer));
                    }

                    messageComplete = true;

                    this._endCDataIndex = -1;
                }
            }
        }

        /// <summary>
        /// Cancels any currently running and blocking read or write operation.
        /// </summary>
        public void Cancel()
        {
            _cancelEvent.Set();
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            if (_messageTrace != null)
            {
                _messageTrace.Dispose();
            }

            _cancelEvent.Dispose();
        }

        /// <summary>
        /// Reads a chunk of bytes from the base stream into the read buffer.
        /// </summary>
        /// <param name="readTimeOutSeconds">Optional read timeout in seconds  (0 means no timeout).</param>
        /// <returns>
        /// Number of bytes read if successful; <c>0</c> otherwise.
        /// </returns>
        private int ReadChunk(int readTimeOutSeconds)
        {
            if (_cancelEvent.WaitOne(0))
            {
                this.Info("Reading of content was cancelled.");
                return 0;
            }

            if( _stream.CanTimeout == true )
            {
                if (readTimeOutSeconds * 1000 < _stream.ReadTimeout)
                {
                    readTimeOutSeconds = _stream.ReadTimeout / 1000;
                }
            }

            int result = 0;
            int waitResult = WaitHandle.WaitTimeout;
            IAsyncResult readResult = _stream.BeginRead(_readBuffer, 0, _readBuffer.Length, null, null);

            using (WaitHandle readHandle = readResult.AsyncWaitHandle)
            {
                WaitHandle[] readHandles = new WaitHandle[] {_cancelEvent, readHandle};

                if (readTimeOutSeconds == 0)
                {
                    waitResult = WaitHandle.WaitAny(readHandles);
                }
                else
                {
                    waitResult = WaitHandle.WaitAny(readHandles, readTimeOutSeconds * 1000);
                }

                if (waitResult == WaitHandle.WaitTimeout)
                {
                    this.Error("Reading of content timed out after '{0}' seconds.", readTimeOutSeconds);
                    return 0;
                }

                if (readHandles[waitResult] == _cancelEvent)
                {
                    this.Info("Reading of content was cancelled.");
                    return 0;
                }

                result = _stream.EndRead(readResult);
            }

            return result;
        }

        #endregion

    }
}
