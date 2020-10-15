using System.Xml.Serialization;
using CareFusion.Mosaic.Interfaces.Converters;
using CareFusion.Mosaic.Interfaces.Messages;
using System;
using CareFusion.Mosaic.Converters.Wwks2.Types;

namespace CareFusion.Mosaic.Converters.Wwks2.Messages.Sales
{
    /// <summary>
    /// Class which represents the WWKS 2.0 ShoppingCartUpdateResponse message envelope.
    /// </summary>
    [XmlType(TypeName = "WWKS")]
    public class ShoppingCartUpdateResponseEnvelope : EnvelopeBase, IMessageConversion
    {
        [XmlElement]
        public ShoppingCartUpdateResponse ShoppingCartUpdateResponse { get; set; }

        /// <summary>
        /// Translates this object instance into a Mosaic message.
        /// </summary>
        /// <param name="converterStream">The converter stream instance which request the message conversion.</param>
        /// <returns>
        /// The Mosaic message representation of this object.
        /// </returns>
        public MosaicMessage ToMosaicMessage(IConverterStream converterStream)
        {
            return this.ShoppingCartUpdateResponse.ToMosaicMessage(converterStream);
        }
    }

    /// <summary>
    /// Class which represents the WWKS 2.0 ShoppingCartUpdateResponse message.
    /// </summary>
    public class ShoppingCartUpdateResponse : MessageBase, IMessageConversion
    {
        [XmlElement]
        public ShoppingCart ShoppingCart { get; set; }

        [XmlElement]
        public UpdateResult UpdateResult { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="ShoppingCartUpdateResponse"/> class.
        /// </summary>
        public ShoppingCartUpdateResponse()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ShoppingCartUpdateResponse"/> class.
        /// </summary>
        public ShoppingCartUpdateResponse(MosaicMessage message)
        {
            Interfaces.Messages.Sales.ShoppingCartUpdateResponse request = (Interfaces.Messages.Sales.ShoppingCartUpdateResponse)message;

            this.Id = request.ID;
            this.Source = request.Source;
            this.Destination = request.Destination;

            this.ShoppingCart = request.ShoppingCart;
            this.UpdateResult = request.UpdateResult;
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
            var request = new Interfaces.Messages.Sales.ShoppingCartUpdateResponse(converterStream);

            request.ID = this.Id;
            request.Source = this.Source;
            request.Destination = this.Destination;

            request.ShoppingCart = this.ShoppingCart;
            request.UpdateResult = this.UpdateResult;

            return request;
        }
    }
}
