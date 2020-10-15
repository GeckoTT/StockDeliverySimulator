
namespace CareFusion.Mosaic.Interfaces.Messages.Input
{
    /// <summary>
    /// Defines different types of pack input handlings.
    /// </summary>
    public enum StockInputHandlingType
    {
        /// <summary>
        /// Pack input is allowed.
        /// </summary>
        Allowed,

        /// <summary>
        /// Pack input is allowed when the pack is stored in a fridge.
        /// </summary>
        AllowedForFridge,

        /// <summary>
        /// Pack input is rejected.
        /// </summary>
        Rejected,

        /// <summary>
        /// Pack input is rejected bacause no expiry date has been set.
        /// </summary>
        RejectedNoExpiryDate,

        /// <summary>
        /// Pack input is rejected bacause no picking indicator has been set.
        /// </summary>
        RejectedNoPickingIndicator,

        /// <summary>
        /// Pack input is rejected bacause no batch number has been set.
        /// </summary>
        RejectedNoBatchNumber,

        /// <summary>
        /// Pack input is rejected because no stock location has been set.
        /// </summary>
        RejectedNoStockLocation,

        /// <summary>
        /// Pack input is rejected bacause no serial number has been set.
        /// </summary>
        RejectedNoSerialNumber,

        /// <summary>
        /// Pack input is rejected because an invalid stock location has been set.
        /// </summary>
        RejectedInvalidStockLocation,

        /// <summary>
        /// Pack input completed successfully.
        /// </summary>
        Completed,

        /// <summary>
        /// Pack input has been aborted.
        /// </summary>
        Aborted
    }
}

