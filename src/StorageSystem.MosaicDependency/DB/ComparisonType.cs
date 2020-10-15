
namespace CareFusion.Mosaic.DB
{
    /// <summary>
    /// Defines the different comparison types supported by command filter implementations.
    /// </summary>
    public enum ComparisonType
    {
        /// <summary>
        /// Compares for equality
        /// </summary>
        EqualTo,

        /// <summary>
        /// Compares for inequality
        /// </summary>
        NotEqualTo,

        /// <summary>
        /// Processes a "smaller than" comparison.
        /// </summary>
        SmallerThan,

        /// <summary>
        /// Processes a "equal or smaller than" comparison.
        /// </summary>
        EqualOrSmallerThan,

        /// <summary>
        /// Processes a "larger than" comparison.
        /// </summary>
        LargerThan,

         /// <summary>
        /// Processes a "equal or larger than" comparison.
        /// </summary>
        EqualOrLargerThan,

        /// <summary>
        /// Processes a "like" comparison.
        /// </summary>
        Like
    }
}
