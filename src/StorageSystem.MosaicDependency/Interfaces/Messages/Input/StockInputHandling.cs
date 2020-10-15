
namespace CareFusion.Mosaic.Interfaces.Messages.Input
{
    /// <summary>
    /// Class which defines the complete input handling for a pack.
    /// </summary>
    public class StockInputHandling
    {
        #region Properties

        /// <summary>
        /// Gets or sets the handling of the pack.
        /// </summary>
        public StockInputHandlingType Handling { get; set; }

        /// <summary>
        /// Gets or sets the optional additional handling description (e.g. reason for reject).
        /// </summary>
        public string Description { get; set; }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="StockInputHandling"/> class.
        /// </summary>
        public StockInputHandling()
        {
            this.Description = string.Empty;
        }
    }
}
