
namespace CareFusion.Mosaic.Interfaces.Types.Input
{
    /// <summary>
    /// Defines different state values for a stock delivery.
    /// </summary>
    public enum StockDeliveryState
    {
        /// <summary>
        /// The order is queued and will be processed as soon as possible.
        /// </summary>
        Queued,

        /// <summary>
        /// The order is currently running.
        /// </summary>
        InProcess,

        /// <summary>
        /// An error occurred while sending or processing the order.
        /// </summary>
        HasError,

        /// <summary>
        /// The order has been finished successfully.
        /// </summary>
        Completed,

        /// <summary>
        /// The order has been finished, but not all requested packs were processed.
        /// </summary>
        Incomplete,

        /// <summary>
        /// The order has been aborted.
        /// </summary>
        Aborted
    }
}
