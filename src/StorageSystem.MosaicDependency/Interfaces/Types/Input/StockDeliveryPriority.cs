
namespace CareFusion.Mosaic.Interfaces.Types.Input
{
    /// <summary>
    /// Defines different priority values for a stock delivery.
    /// </summary>
    public enum StockDeliveryPriority
    {
        /// <summary>
        /// The input is processed with the lowest priority.
        /// </summary>
        Low,

        /// <summary>
        /// The input is processed with the default priority.
        /// </summary>
        Normal,

        /// <summary>
        /// The input is processed with the highest possible priority.
        /// </summary>
        High
    }
}
