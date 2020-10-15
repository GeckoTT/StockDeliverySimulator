using CareFusion.Mosaic.Converters.Wwks2.Types;
using CareFusion.Mosaic.Interfaces.Converters;

namespace CareFusion.Mosaic.Interfaces.Messages.Sales
{
    public class ShoppingCartResponse : MosaicMessage
    {
        #region Properties
        public ShoppingCart ShoppingCart { get; set; }
        #endregion

        /// <summary>
        /// Initializes a new <see cref="ShoppingCartResponse"/> instance.
        /// </summary>
        public ShoppingCartResponse() : base(MessageType.ShoppingCartResponse)
        {
        }

        /// <summary>
        /// Initializes a new <see cref="ShoppingCartResponse"/> instance.
        /// </summary>
        /// <param name="converterStream">The converter stream which created the response.</param>
        public ShoppingCartResponse(IConverterStream converterStream) : base(MessageType.ShoppingCartResponse, converterStream)
        {
        }
    }
}