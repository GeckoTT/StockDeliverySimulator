using System.Xml.Serialization;
using CareFusion.Mosaic.Interfaces.Converters;
using CareFusion.Mosaic.Interfaces.Messages;
using System;
using CareFusion.Mosaic.Converters.Wwks2.Types;

namespace CareFusion.Mosaic.Converters.Wwks2.Messages.Sales
{
    /// <summary>
    /// Class which represents the WWKS 2.0 ShoppingCartUpdateRequest message envelope.
    /// </summary>
    [XmlType(TypeName = "WWKS")]
    public class ShoppingCartUpdateRequestEnvelope : EnvelopeBase, IMessageConversion
    {
        [XmlElement]
        public ShoppingCartUpdateRequest ShoppingCartUpdateRequest { get; set; }

        /// <summary>
        /// Translates this object instance into a Mosaic message.
        /// </summary>
        /// <param name="converterStream">The converter stream instance which request the message conversion.</param>
        /// <returns>
        /// The Mosaic message representation of this object.
        /// </returns>
        public MosaicMessage ToMosaicMessage(IConverterStream converterStream)
        {
            return this.ShoppingCartUpdateRequest.ToMosaicMessage(converterStream);
        }
    }

    /// <summary>
    /// Class which represents the WWKS 2.0 ShoppingCartUpdateRequest message.
    /// </summary>
    public class ShoppingCartUpdateRequest : MessageBase, IMessageConversion
    {
        #region Properties

        [XmlElement]
        public ShoppingCart ShoppingCart { get; set; }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="ShoppingCartUpdateRequest"/> class.
        /// </summary>
        public ShoppingCartUpdateRequest()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ShoppingCartUpdateRequest"/> class.
        /// </summary>
        public ShoppingCartUpdateRequest(MosaicMessage message)
        {
            Interfaces.Messages.Sales.ShoppingCartUpdateRequest request = (Interfaces.Messages.Sales.ShoppingCartUpdateRequest)message;

            this.Id = request.ID;
            this.Source = request.Source;
            this.Destination = request.Destination;

            this.ShoppingCart = request.ShoppingCart;
        }

        /// <summary>
        /// Translates this object instance into a Mosaic message.
        /// </summary>
        /// <param name="converterStream">The converter stream instance which request the message conversion.</param>
        /// <returns>
        /// The Mosaic message representation of this object.
        /// </returns>
        public MosaicMessage ToMosaicMessage(IConverterStream converterStream)
        {
            var request = new Interfaces.Messages.Sales.ShoppingCartUpdateRequest(converterStream);

            request.ID = this.Id;
            request.Source = this.Source;
            request.Destination = this.Destination;

            request.ShoppingCart = this.ShoppingCart;

            return request;
        }
    }
}
