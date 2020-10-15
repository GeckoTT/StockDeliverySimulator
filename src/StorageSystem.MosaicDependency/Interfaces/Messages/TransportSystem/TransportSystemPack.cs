using CareFusion.Mosaic.Interfaces.Types.Packs;

namespace CareFusion.Mosaic.Interfaces.Messages.TransportSystem
{
    /// <summary>
    /// Represents a pack which is dispensed to a transport system hand over point.
    /// </summary>
    public class TransportSystemPack
    {
        #region Properties

        /// <summary>
        /// The local identifier of the pack.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// The height of the pack in millimeter.
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// The width of the pack in millimeter.
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// The depth of the pack in millimeter.
        /// </summary>
        public int Depth { get; set; }

        /// <summary>
        /// The shape of the pack.
        /// </summary>
        public PackShape Shape { get; set; }

        /// <summary>
        /// The IT system related output number to use for dispensing the pack.
        /// </summary>
        public int OutputNumber { get; set; }
		
		/// <summary>
        /// The number of the output order that initiated the pack output.
        /// </summary>
		public string OrderNumber { get; set; }

        /// <summary>
        /// The number of the IT system related output order that initiated the pack output.
        /// </summary>
        public string ItSystemOrderNumber { get; set; }

        #endregion
    }
}
