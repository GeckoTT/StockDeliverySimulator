
namespace CareFusion.Mosaic.Interfaces.Messages.Input
{
    /// <summary>
    /// Defines the different supported states of an initiated stock input.
    /// </summary>
    public enum InitiateStockInputState
    {
        /// <summary>
        /// The initiated input has been accepted.
        /// </summary>
        Accepted,

        /// <summary>
        /// The initiated input is currently in running.
        /// </summary>
        InProgress,

        /// <summary>
        /// The initiated input was rejected.
        /// </summary>
        Rejected,

        /// <summary>
        /// The initiated input successfully finished.
        /// </summary>
        Completed,

        /// <summary>
        /// The initiated input finished with errors.
        /// </summary>
        Incomplete
    }
}
