using CareFusion.Mosaic.Converters.Wwks2.Types;
using CareFusion.Mosaic.Interfaces.Converters;

namespace CareFusion.Mosaic.Interfaces.Messages.Sales
{
    public class ShoppingCartUpdateMessage : MosaicMessage
    {
        #region Properties
        public ShoppingCart ShoppingCart { get; set; }
        #endregion

        /// <summary>
        /// Initializes a new <see cref="ShoppingCartUpdateMessage"/> instance.
        /// </summary>
        public ShoppingCartUpdateMessage() : base(MessageType.ShoppingCartUpdateMessage)
        {
        }

        /// <summary>
        /// Initializes a new <see cref="ShoppingCartUpdateMessage"/> instance.
        /// </summary>
        /// <param name="converterStream">The converter stream which created the response.</param>
        public ShoppingCartUpdateMessage(IConverterStream converterStream) : base(MessageType.ShoppingCartUpdateMessage, converterStream)
        {
        }
    }
}
