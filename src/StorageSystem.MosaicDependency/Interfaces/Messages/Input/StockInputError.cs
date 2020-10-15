
namespace CareFusion.Mosaic.Interfaces.Messages.Input
{
    /// <summary>
    /// Class which defines the complete input error for a pack.
    /// </summary>
    public class StockInputError
    {
        #region Properties

        /// <summary>
        /// Gets or sets the type of the input error.
        /// </summary>
        public StockInputErrorType Type { get; set; }

        /// <summary>
        /// Gets or sets the optional additional error description (e.g. reason for reject).
        /// </summary>
        public string Description { get; set; }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="StockInputError"/> class.
        /// </summary>
        public StockInputError()
        {
            this.Description = string.Empty;
        }
    }
}
