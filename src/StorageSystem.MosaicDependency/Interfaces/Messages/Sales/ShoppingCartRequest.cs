using CareFusion.Mosaic.Converters.Wwks2.Types;
using CareFusion.Mosaic.Interfaces.Converters;

namespace CareFusion.Mosaic.Interfaces.Messages.Sales
{
    public class ShoppingCartRequest : MosaicMessage
    {
        #region Properties
        public Criteria Criteria { get; set; }
        #endregion

        /// <summary>
        /// Initializes a new <see cref="ShoppingCartRequest"/> instance.
        /// </summary>
        public ShoppingCartRequest() : base(MessageType.ShoppingCartRequest)
        {
        }

        /// <summary>
        /// Initializes a new <see cref="ShoppingCartRequest"/> instance.
        /// </summary>
        /// <param name="converterStream">The converter stream which created the request.</param>
        public ShoppingCartRequest(IConverterStream converterStream) : base(MessageType.ShoppingCartRequest, converterStream)
        {
        }
    }
}