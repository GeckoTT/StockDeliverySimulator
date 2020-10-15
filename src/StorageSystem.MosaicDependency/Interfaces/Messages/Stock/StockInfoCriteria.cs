
namespace CareFusion.Mosaic.Interfaces.Messages.Stock
{
    /// <summary>
    /// Class which implements a criteria for a stock info request.
    /// </summary>
    public class StockInfoCriteria
    {
        #region Properties

        /// <summary>
        /// Defines the robot article code criteria for the stock information request.
        /// </summary>
        public string RobotArticleCode { get; set; }

        /// <summary>
        /// Defines the PIS article code criteria for the stock information request.
        /// </summary>
        public string PISArticleCode { get; set; }

        /// <summary>
        /// Defines the batch number criteria for the stock information request.
        /// </summary>
        public string BatchNumber { get; set; }

        /// <summary>
        /// Defines the external identifier criteria for the stock information request.
        /// </summary>
        public string ExternalID { get; set; }

        /// <summary>
        /// Defines the stock location identifier for the stock information request.
        /// </summary>
        public string StockLocationID { get; set; }

        /// <summary>
        /// Defines the stock machine identifier for the stock information request.
        /// </summary>
        public string MachineLocation { get; set; }

        /// <summary>
        /// Defines the maximum count of records to return.
        /// </summary>
        public int MaxCount { get; set; }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="StockInfoCriteria"/> class.
        /// </summary>
        public StockInfoCriteria()
        {
            this.RobotArticleCode = string.Empty;
            this.PISArticleCode = string.Empty;
            this.BatchNumber = string.Empty;
            this.ExternalID = string.Empty;
            this.StockLocationID = string.Empty;
            this.MachineLocation = string.Empty;
        }
    }
}
