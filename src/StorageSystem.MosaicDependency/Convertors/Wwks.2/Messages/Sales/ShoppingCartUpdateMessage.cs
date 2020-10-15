using System.Xml.Serialization;
using CareFusion.Mosaic.Interfaces.Converters;
using CareFusion.Mosaic.Interfaces.Messages;
using System;
using CareFusion.Mosaic.Converters.Wwks2.Types;

namespace CareFusion.Mosaic.Converters.Wwks2.Messages.Sales
{
    /// <summary>
    /// Class which represents the WWKS 2.0 ShoppingCartUpdateMessage message envelope.
    /// </summary>
    [XmlType(TypeName = "WWKS")]
    public class ShoppingCartUpdateMessageEnvelope : EnvelopeBase, IMessageConversion
    {
        [XmlElement]
        public ShoppingCartUpdateMessage ShoppingCartUpdateMessage { get; set; }

        /// <summary>
        /// Translates this object instance into a Mosaic message.
        /// </summary>
        /// <param name="converterStream">The converter stream instance which request the message conversion.</param>
        /// <returns>
        /// The Mosaic message representation of this object.
        /// </returns>
        public MosaicMessage ToMosaicMessage(IConverterStream converterStream)
        {
            return this.ShoppingCartUpdateMessage.ToMosaicMessage(converterStream);
        }
    }

    /// <summary>
    /// Class which represents the WWKS 2.0 ShoppingCartUpdateMessage message.
    /// </summary>
    public class ShoppingCartUpdateMessage : MessageBase, IMessageConversion
    {
        [XmlElement]
        public ShoppingCart ShoppingCart { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ShoppingCartUpdateMessage"/> class.
        /// </summary>
        public ShoppingCartUpdateMessage()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ShoppingCartUpdateMessage"/> class.
        /// </summary>
        public ShoppingCartUpdateMessage(MosaicMessage message)
        {
            Interfaces.Messages.Sales.ShoppingCartUpdateMessage msg = (Interfaces.Messages.Sales.ShoppingCartUpdateMessage)message;

            this.Id = msg.ID;
            this.Source = msg.Source;
            this.Destination = msg.Destination;

            this.ShoppingCart = msg.ShoppingCart;
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
            var msg = new Interfaces.Messages.Sales.ShoppingCartUpdateMessage(converterStream);

            msg.ID = this.Id;
            msg.Source = this.Source;
            msg.Destination = this.Destination;

            msg.ShoppingCart = this.ShoppingCart;

            return msg;
        }
    }
}
