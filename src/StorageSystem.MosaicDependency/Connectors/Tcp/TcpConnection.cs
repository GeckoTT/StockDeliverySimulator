using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using CareFusion.Mosaic.Core.Logging;
using CareFusion.Mosaic.Interfaces.Connectors;

namespace CareFusion.Mosaic.Connectors.Tcp
{
    /// <summary>
    /// Class which implements a TCP/IP connection.
    /// </summary>
    public class TcpConnection : IConnection
    {
        #region Constants

        /// <summary>
        /// Size of the read buffer to use when reading messages.
        /// </summary>
        private const int ReadBufferSize = 4194304;

        #endregion

        #region Members

        /// <summary>
        /// TcpClient that represents the TCP connection itself.
        /// </summary>
        private TcpClient _tcpClient = null;

        /// <summary>
        /// Round robin connection id generator.
        /// </summary>
        private static int _idCounter = 0;

        #endregion

        #region Properties

        /// <summary>
        /// Gets the unique identifier of this connection instance.
        /// </summary>
        public int ID { get; private set; }

        /// <summary>
        /// Gets the identifier of the connector that created this connection instance.
        /// </summary>
        public int ConnectorID { get; private set; }

        /// <summary>
        /// Gets a description of the connected endpoint (e.g. IP address or COM port).
        /// </summary>
        public string EndPoint 
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the category this connection belongs to.
        /// </summary>
        public ConnectionCategory Category { get; private set; }

        /// <summary>
        /// Returns <c>true</c> if the connection is still active; <c>false</c> otherwise. 
        /// </summary>
        public bool IsConnected
        {
            get
            {
                if (_tcpClient == null)
                {
                    return false;
                }

                return _tcpClient.Connected;
            }
        }

        /// <summary>
        /// Gets a stream instance which can be used to read or write data from or to this connection.
        /// </summary>
        public Stream ConnectionStream
        {
            get { return (_tcpClient != null) ? _tcpClient.GetStream() : null; }
        }

        /// <summary>
        /// Provides an optional name of the element that was involved in the last read operation of the connection stream.
        /// The support for element names is connector specific (e.g. file names, table names ...) and may be unavailable at some connectors.
        /// </summary>
        public string LastReadElementName { get { return string.Empty; } }

        #endregion

        #region Events

        /// <summary>
        /// Occurs when the connection has been closed.
        /// </summary>
        public event EventHandler Closed;

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="TcpConnection" /> class.
        /// </summary>
        /// <param name="connectorID">The connector identifier.</param>
        /// <param name="category">The category.</param>
        /// <param name="tcpClient">The TCP client that represents the TCP connection.</param>
        /// <param name="endPoint">The end point description to use for this connection.</param>
        /// <exception cref="System.ArgumentException">Invalid tcpClient specified.</exception>
        public TcpConnection(int connectorID, ConnectionCategory category, TcpClient tcpClient, string endPoint)
        {
            if (tcpClient == null)
            {
                throw new ArgumentException("Invalid tcpClient specified.");
            }

            Interlocked.CompareExchange(ref _idCounter, 0, int.MaxValue);
            this.ID = Interlocked.Increment(ref _idCounter);
            this.ConnectorID = connectorID;
            this.Category = category;
            this.EndPoint = endPoint;

            _tcpClient = tcpClient;
            _tcpClient.ReceiveBufferSize = ReadBufferSize;
            EnableSocketKeepAlive();
        }

        /// <summary>
        /// Defines a name for the element that is used for the next write operations on the connection stream.
        /// The interpretation of the element name is connector specific (e.g. file names, table names ...) and may be ignored.
        /// </summary>
        /// <param name="elementName">Name of the element.</param>
        public void SetNextWriteElementName(string elementName)
        {
        }

        /// <summary>
        /// Cancels any pending blocking or asynchronous operations of the connection stream.
        /// This method will block and not return until all outstanding operations have finished.
        /// </summary>
        public void Cancel()
        {
            // nothing to do here
        }

        /// <summary>
        /// Gracefully shuts down the connection.
        /// </summary>
        public void Shutdown()
        {
            if (_tcpClient == null)
            {
                return;
            }

            try
            {
                _tcpClient.Client.Shutdown(SocketShutdown.Both);
            }
            catch (Exception ex)
            {
                this.Error("Shutdown of the connected TCP client failed!", ex);
            }            
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            if (_tcpClient == null)
                return;
            
            if ((_tcpClient.Client != null) && (_tcpClient.Client.Connected))
            {
                try
                {
                    _tcpClient.Client.Shutdown(SocketShutdown.Both);
                }
                catch (Exception ex)
                {
                    this.Error("Closing TCP connection gracefully failed.", ex);
                }
            }

            _tcpClient.Close();
            _tcpClient = null;

            if (this.Closed != null)
                this.Closed(this, null);
        }

        /// <summary>
        /// Enables the socket keep alive feature at the current TcpClient connection.
        /// <see cref="http://social.msdn.microsoft.com/Forums/en-US/netfxnetcom/thread/d5b6ae25-eac8-4e3d-9782-53059de04628"/>
        /// </summary>
        private void EnableSocketKeepAlive()
        {
            this.Trace("Enabling socket keep alive configuration...");

            const int bytesperlong = 4;
            const int bitsperbyte = 8;
            const ulong time = 2000;        // keep alive time in milliseconds
            const ulong interval = 500;     // keep alive interval in milliseconds

            try
            {
                // resulting structure
                byte[] SIO_KEEPALIVE_VALS = new byte[3 * bytesperlong];

                // array to hold input values
                ulong[] input = new ulong[3];
                input[0] = (1UL);    // on
                input[1] = time;     // time millis
                input[2] = interval; // interval millis

                // pack input into byte struct
                for (int i = 0; i < input.Length; i++)
                {
                    SIO_KEEPALIVE_VALS[i * bytesperlong + 3] = (byte)(input[i] >> ((bytesperlong - 1) * bitsperbyte) & 0xff);
                    SIO_KEEPALIVE_VALS[i * bytesperlong + 2] = (byte)(input[i] >> ((bytesperlong - 2) * bitsperbyte) & 0xff);
                    SIO_KEEPALIVE_VALS[i * bytesperlong + 1] = (byte)(input[i] >> ((bytesperlong - 3) * bitsperbyte) & 0xff);
                    SIO_KEEPALIVE_VALS[i * bytesperlong + 0] = (byte)(input[i] >> ((bytesperlong - 4) * bitsperbyte) & 0xff);
                }

                // create bytestruct for result (bytes pending on server socket)
                byte[] result = BitConverter.GetBytes(0);

                // write SIO_VALS to Socket IOControl
                _tcpClient.Client.IOControl(IOControlCode.KeepAliveValues, SIO_KEEPALIVE_VALS, result);
            }
            catch (Exception ex)
            {
                this.Error("Enable socket keep alive failed!", ex);
            }
        }
    }
}
