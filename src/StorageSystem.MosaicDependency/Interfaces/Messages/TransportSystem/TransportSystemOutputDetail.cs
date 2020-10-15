
namespace CareFusion.Mosaic.Interfaces.Messages.TransportSystem
{
    /// <summary>
    /// Represents an output detail element of a transport system hand over point.
    /// </summary>
    public class TransportSystemOutputDetail
    {
        #region Properties

        /// <summary>
        /// The identifier of the output.
        /// </summary>
        public string Output { get; set; }

        /// <summary>
        /// Flag whether the output is operational.
        /// </summary>
        public bool IsOperational { get; set; }

        #endregion
    }

}
