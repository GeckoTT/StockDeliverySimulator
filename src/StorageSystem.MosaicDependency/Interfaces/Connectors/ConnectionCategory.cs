
namespace CareFusion.Mosaic.Interfaces.Connectors
{
    /// <summary>
    /// Enumeration which defines the different categories a connection can belong to. 
    /// </summary>
    public enum ConnectionCategory
    {
        /// <summary>
        /// The connection represents an IT system.
        /// This kind of connection always represents a master IT system connection.
        /// </summary>
        ItSystem,

        /// <summary>
        /// The connection represents a slave IT system.
        /// </summary>
        ItSystemSlave,

        /// <summary>
        /// The connection represents a digital shelf system.
        /// </summary>
        DigitalShelf,

        /// <summary>
        /// The connection represents a storage system (e.g. Vmax).
        /// </summary>
        StorageSystem,

        /// <summary>
        /// The connection 
        /// </summary>
        TransportSystem,

        /// <summary>
        /// The connection represents another third party component.
        /// </summary>
        Other
    }
}
