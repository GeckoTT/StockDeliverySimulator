using System;
using CareFusion.Mosaic.Converters;
using CareFusion.Mosaic.Interfaces.Connectors;
using CareFusion.Mosaic.Interfaces.Messages;

namespace CareFusion.Mosaic.Interfaces.Converters
{
    /// <summary>
    /// Interface of a converter stream which is able to translate/generate Mosaic messages into/from a specific format. 
    /// </summary>
    public interface IConverterStream : IDisposable
    {
        #region Properties

        /// <summary>
        /// Gets the indentifier of the converter that created the converter stream. 
        /// </summary>
        int ConverterID { get; }

        /// <summary>
        /// Gets an arbitary destination descriptor which depends on the specific converter implementation. 
        /// </summary>
        string Destination { get; }

        /// <summary>
        /// Gets the tenant identifier which is assigned to this converter stream.
        /// </summary>
        string TenantID { get; }

        /// <summary>
        /// Gets the instance of the underlying connection used by the converter stream.
        /// </summary>
        IConnection Connection { get; }

        #endregion

        #region Methods

        /// <summary>
        /// Reads the next Mosaic message from the underlying connection and returns it. This method will block until a new Mosaic message  
        /// has been read, the converter stream has been cancelled or an error occurred.
        /// </summary>
        /// <returns>Read Mosaic message if successful; <c>null</c> otherwise.</returns>
        MosaicMessage Read();

        /// <summary>
        /// Writes the specified Mosaic message to the underlying connection. This method will block until the Mosaic message  
        /// has been written, the converter has been cancelled or an error occurred.
        /// </summary>
        /// <param name="message">The Mosaic message to write.</param>
        /// <returns><c>true</c>if successful; <c>false</c> otherwise.</returns>
        bool Write(MosaicMessage message);

        /// <summary>
        /// Cancels any pending operations like reading or writing messages.
        /// This method will block and not return until all outstanding operations have finished.
        /// </summary>
        void Cancel();

        /// <summary>
        /// Writes to the base stream the the message which is supposing to contain an XML.
        /// </summary>
        /// <param name="message">The message as array of bytes.</param>
        void WriteRaw(byte[] message);

        #endregion
    }
}
