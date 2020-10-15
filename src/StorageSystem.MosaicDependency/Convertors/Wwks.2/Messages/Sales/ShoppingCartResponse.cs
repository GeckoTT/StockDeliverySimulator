using System.Xml.Serialization;
using CareFusion.Mosaic.Interfaces.Converters;
using CareFusion.Mosaic.Interfaces.Messages;
using System;
using CareFusion.Mosaic.Converters.Wwks2.Types;

namespace CareFusion.Mosaic.Converters.Wwks2.Messages.Sales
{
    /// <summary>
    /// Class which represents the WWKS 2.0 ShoppingCartResponse message envelope.
    /// </summary>
    [XmlType(TypeName = "WWKS")]
    public class ShoppingCartResponseEnvelope : EnvelopeBase, IMessageConversion
    {
        [XmlElement]
        public ShoppingCartResponse ShoppingCartResponse { get; set; }

        /// <summary>
        /// Translates this object instance into a Mosaic message.
        /// </summary>
        /// <param name="converterStream">The converter stream instance which request the message conversion.</param>
        /// <returns>
        /// The Mosaic message representation of this object.
        /// </returns>
        public MosaicMessage ToMosaicMessage(IConverterStream converterStream)
        {
            return this.ShoppingCartResponse.ToMosaicMessage(converterStream);
        }
    }

    /// <summary>
    /// Class which represents the WWKS 2.0 ShoppingCartResponse message.
    /// </summary>
    public class ShoppingCartResponse : MessageBase, IMessageConversion
    {
        [XmlElement]
        public ShoppingCart ShoppingCart { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ShoppingCartResponse"/> class.
        /// </summary>
        public ShoppingCartResponse()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ShoppingCartResponse"/> class.
        /// </summary>
        public ShoppingCartResponse(MosaicMessage message)
        {
            Interfaces.Messages.Sales.ShoppingCartResponse response = (Interfaces.Messages.Sales.ShoppingCartResponse)message;

            this.Id = response.ID;
            this.Source = response.Source;
            this.Destination = response.Destination;

            this.ShoppingCart = response.ShoppingCart;
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
            var response = new Interfaces.Messages.Sales.ShoppingCartResponse(converterStream);

            response.ID = this.Id;
            response.Source = this.Source;
            response.Destination = this.Destination;

            response.ShoppingCart = this.ShoppingCart;

            return response;
        }
    }
}
