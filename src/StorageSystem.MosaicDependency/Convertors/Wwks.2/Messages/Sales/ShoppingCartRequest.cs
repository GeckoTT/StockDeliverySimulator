using System.Xml.Serialization;
using System;
using CareFusion.Mosaic.Converters.Wwks2.Types;
using CareFusion.Mosaic.Interfaces.Converters;
using CareFusion.Mosaic.Interfaces.Messages;

namespace CareFusion.Mosaic.Converters.Wwks2.Messages.Sales
{
    /// <summary>
    /// Class which represents the WWKS 2.0 ShoppingCartRequest message envelope.
    /// </summary>
    [XmlType(TypeName = "WWKS")]
    public class ShoppingCartRequestEnvelope : EnvelopeBase, IMessageConversion
    {
        [XmlElement]
        public ShoppingCartRequest ShoppingCartRequest { get; set; }

        /// <summary>
        /// Translates this object instance into a Mosaic message.
        /// </summary>
        /// <param name="converterStream">The converter stream instance which request the message conversion.</param>
        /// <returns>
        /// The Mosaic message representation of this object.
        /// </returns>
        public MosaicMessage ToMosaicMessage(IConverterStream converterStream)
        {
            return this.ShoppingCartRequest.ToMosaicMessage(converterStream);
        }
    }

    /// <summary>
    /// Class which represents the WWKS 2.0 ShoppingCartRequest message.
    /// </summary>
    public class ShoppingCartRequest : MessageBase, IMessageConversion
    {
        #region Properties

        [XmlElement]
        public Criteria Criteria { get; set; }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="ShoppingCartRequest"/> class.
        /// </summary>
        public ShoppingCartRequest()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ShoppingCartRequest"/> class.
        /// </summary>
        public ShoppingCartRequest(MosaicMessage message)
        {
            Interfaces.Messages.Sales.ShoppingCartRequest request = (Interfaces.Messages.Sales.ShoppingCartRequest)message;

            this.Id = request.ID;
            this.Source = request.Source;
            this.Destination = request.Destination;

            this.Criteria = request.Criteria;
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
            var request = new Interfaces.Messages.Sales.ShoppingCartRequest(converterStream);

            request.ID = this.Id;
            request.Source = this.Source;
            request.Destination = this.Destination;

            request.Criteria = this.Criteria;

            return request;
        }
    }
}
