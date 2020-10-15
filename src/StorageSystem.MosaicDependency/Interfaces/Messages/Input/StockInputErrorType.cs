
namespace CareFusion.Mosaic.Interfaces.Messages.Input
{
    /// <summary>
    /// Defines the different error that may occur during pack input.
    /// </summary>
    public enum StockInputErrorType
    {
        /// <summary>
        /// The IT system rejected the pack input.
        /// </summary>
        Rejected,

        /// <summary>
        /// The IT system rejected the pack input because the expiry date was missing.
        /// </summary>
        RejectedNoExpiryDate,

        /// <summary>
        /// The machine rejected the pack input because the expiry date of the pack is invalid.
        /// </summary>
        RejectedInvalidExpiryDate,

        /// <summary>
        /// The IT system rejected the pack input because no picking indicator was set.
        /// </summary>
        RejectedNoPickingIndicator,

        /// <summary>
        /// The IT system rejected the pack input because the batch number was missing.
        /// </summary>
        RejectedNoBatchNumber,

        /// <summary>
        /// Pack input is rejected because no stock location has been set.
        /// </summary>
        RejectedNoStockLocation,

        /// <summary>
        /// Pack input is rejected because an invalid stock location has been set.
        /// </summary>
        RejectedInvalidStockLocation,

        /// <summary>
        /// The storage system rejected the input because it is busy.
        /// </summary>
        QueueFull,

        /// <summary>
        /// The storage system rejected the input because it has no fridge for the pack.
        /// </summary>
        FridgeMissing,

        /// <summary>
        /// The storage system rejected the input because the pack dimensions could not be determined.
        /// </summary>
        UnknownPackDimensions,

        /// <summary>
        /// The storage system rejected the input because an error occurred while checking the pack dimensions.
        /// </summary>
        MeasurementError,

        /// <summary>
        /// The storage system rejected the input because a critical error occurred and the pack was acknowledged.
        /// </summary>
        PackAcknowledged,

        /// <summary>
        /// The storage system rejected the input because the input source is broken.
        /// </summary>
        InputBroken,

        /// <summary>
        /// There is not enough space left in the machine to input the pack.
        /// </summary>
        NoSpaceInMachine,

        /// <summary>
        /// No pack has been placed at the medport by the user.
        /// </summary>
        NoPackDetected,
    }
}
