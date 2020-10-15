using CareFusion.Mosaic.Converters.Wwks2.Types;
using CareFusion.Mosaic.Interfaces.Converters;

namespace CareFusion.Mosaic.Interfaces.Messages.Sales
{
    public class ShoppingCartUpdateRequest : MosaicMessage
    {
        #region Properties
        public ShoppingCart ShoppingCart { get; set; }
        #endregion

        /// <summary>
        /// Initializes a new <see cref="ShoppingCartUpdateRequest"/> instance.
        /// </summary>
        public ShoppingCartUpdateRequest() : base(MessageType.ShoppingCartUpdateRequest)
        {
        }

        /// <summary>
        /// Initializes a new <see cref="ShoppingCartUpdateRequest"/> instance.
        /// </summary>
        /// <param name="converterStream">The converter stream which created the response.</param>
        public ShoppingCartUpdateRequest(IConverterStream converterStream) : base(MessageType.ShoppingCartUpdateRequest, converterStream)
        {
        }
    }
}
