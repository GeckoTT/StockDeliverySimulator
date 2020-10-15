using CareFusion.Mosaic.Converters.Wwks2.Types;
using CareFusion.Mosaic.Interfaces.Converters;

namespace CareFusion.Mosaic.Interfaces.Messages.Sales
{
    public class ShoppingCartUpdateResponse : MosaicMessage
    {
        #region Properties
        public ShoppingCart ShoppingCart { get; set; }

        public UpdateResult UpdateResult { get; set; }
        #endregion

        /// <summary>
        /// Initializes a new <see cref="ShoppingCartUpdateResponse"/> instance.
        /// </summary>
        public ShoppingCartUpdateResponse() : base(MessageType.ShoppingCartUpdateResponse)
        {
        }

        /// <summary>
        /// Initializes a new <see cref="ShoppingCartUpdateResponse"/> instance.
        /// </summary>
        /// <param name="converterStream">The converter stream which created the response.</param>
        public ShoppingCartUpdateResponse(IConverterStream converterStream) : base(MessageType.ShoppingCartUpdateResponse, converterStream)
        {
        }
    }
}