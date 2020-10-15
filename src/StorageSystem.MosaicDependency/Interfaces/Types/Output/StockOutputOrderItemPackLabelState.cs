
namespace CareFusion.Mosaic.Interfaces.Types.Output
{
    /// <summary>
    /// Defines the different labelling states of a StockOutputOrderItemPack.
    /// </summary>
    public enum StockOutputOrderItemPackLabelState
    {
        /// <summary>
        /// The pack was not labelled (e.g. no label printer is involved).
        /// </summary>
        NotLabelled,

        /// <summary>
        /// The pack was successfully labelled.
        /// </summary>
        Labelled,

        /// <summary>
        /// An error occurred during the labelling of the pack.
        /// </summary>
        LabelError,

        /// <summary>
        /// The pack is to be labelled, but no final information from label printer has been received yet.
        /// </summary>
        WaitForLabel,

        /// <summary>
        /// It is not known if this pack is to be labelled. This indicates an error.
        /// </summary>
        Unknown
    }
}
