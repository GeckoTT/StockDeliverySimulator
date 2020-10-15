using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using CareFusion.Mosaic.Converters.Wwks2.Types;
using CareFusion.Mosaic.Interfaces.Converters;
using CareFusion.Mosaic.Interfaces.Messages;

namespace CareFusion.Mosaic.Converters.Wwks2.Messages.Stock
{
    /// <summary>
    /// Class which represents the WWKS 2.0 StockDeliverySetRequest  small set message envelope.
    /// </summary>
    [XmlType(TypeName = "WWKS")]
    public class StockDeliverySetRequestSmallSetEnvelope : EnvelopeBase, IMessageConversion
    {
        [XmlElement]
        public StockDeliverySetRequestSmallSet StockDeliverySetRequest { get; set; }

        /// <summary>
        /// Translates this object instance into a Mosaic message.
        /// </summary>
        /// <param name="converterStream">The converter stream instance which request the message conversion.</param>
        /// <returns>
        /// The Mosaic message representation of this object.
        /// </returns>
        public MosaicMessage ToMosaicMessage(IConverterStream converterStream)
        {
            return this.StockDeliverySetRequest.ToMosaicMessage(converterStream);
        }
    }

    /// <summary>
    /// Class which represents the WWKS 2.0 StockDeliverySetRequest message envelope.
    /// </summary>
    [XmlType(TypeName = "WWKS")]
    public class StockDeliverySetRequestEnvelope : EnvelopeBase, IMessageConversion
    {
        [XmlElement]
        public StockDeliverySetRequest StockDeliverySetRequest { get; set; }

        /// <summary>
        /// Translates this object instance into a Mosaic message.
        /// </summary>
        /// <param name="converterStream">The converter stream instance which request the message conversion.</param>
        /// <returns>
        /// The Mosaic message representation of this object.
        /// </returns>
        public MosaicMessage ToMosaicMessage(IConverterStream converterStream)
        {
            return this.StockDeliverySetRequest.ToMosaicMessage(converterStream);
        }
    }

    /// <summary>
    /// Class which represents the WWKS 2.0 StockDeliverySetRequest small set message.
    /// <see cref="https://portalrowa.carefusion.com/Unternehmen/Entwicklung/TechCom/Writing/P-010-044-B-I-388-DEU.docx" />
    /// </summary>
    public class StockDeliverySetRequestSmallSet : MessageBase, IMessageConversion
    {
        #region Properties

        [XmlElement]
        public StockDelivery[] StockDelivery { get; set; }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="StockDeliverySetRequestSmallSet"/> class.
        /// </summary>
        public StockDeliverySetRequestSmallSet()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StockDeliverySetRequestSmallSet"/> class.
        /// </summary>
        /// <param name="message">The message to use for initialization.</param>
        public StockDeliverySetRequestSmallSet(MosaicMessage message)
        {
            var request = (Interfaces.Messages.Stock.StockDeliverySetRequest)message;

            this.Id = request.ID;
            this.Source = request.Source;
            this.Destination = request.Destination;

            if (request.StockDeliveries.Count == 0)
            {
                return;
            }

            this.StockDelivery = new StockDelivery[request.StockDeliveries.Count];

            for (int i = 0; i < this.StockDelivery.Length; ++i)
            {
                var stockDelivery = request.StockDeliveries[i];

                this.StockDelivery[i] = new StockDelivery()
                {
                    DeliveryNumber = stockDelivery.DeliveryNumber,
                    Article = new List<Article>()
                };

                foreach (var article in stockDelivery.Items)
                {
                    this.StockDelivery[i].Article.Add(new Article() 
                    { 
                        Id = TextConverter.EscapeInvalidXmlChars(article.ArticleCode),
                        Name = TextConverter.EscapeInvalidXmlChars(article.Name),
                        DosageForm = TextConverter.EscapeInvalidXmlChars(article.DosageForm),
                        PackagingUnit = TextConverter.EscapeInvalidXmlChars(article.PackagingUnit),
                        BatchNumber = string.IsNullOrEmpty(article.BatchNumber) ? null : TextConverter.EscapeInvalidXmlChars(article.BatchNumber),
                        ExternalId = string.IsNullOrEmpty(article.ExternalID) ? null : TextConverter.EscapeInvalidXmlChars(article.ExternalID),
                        ExpiryDate = TypeConverter.ConvertDateNull(article.ExpiryDate),
                        Quantity = (article.RequestedQuantity != 0) ? null : article.RequestedQuantity.ToString()
                    });
                }
            }
        }

        /// <summary>
        /// Translates this object instance into a Mosaic message.
        /// </summary>
        /// <param name="converterStream">The converter stream instance which request the message conversion.</param>
        /// <returns>
        /// The Mosaic message representation of this object.
        /// </returns>
        public virtual MosaicMessage ToMosaicMessage(IConverterStream converterStream)
        {
            var request = new Interfaces.Messages.Stock.StockDeliverySetRequest(converterStream);

            request.ID = this.Id;
            request.Source = this.Source;
            request.Destination = this.Destination;

            if (this.StockDelivery == null)
            {
                return request;
            }

            for (int i = 0; i < this.StockDelivery.Length; ++i)
            {
                var stockDelivery = this.StockDelivery[i];

                request.StockDeliveries.Add(new Interfaces.Types.Input.StockDelivery()
                {
                    DeliveryNumber = stockDelivery.DeliveryNumber
                });

                if (stockDelivery.Article == null)
                {
                    continue;
                }

                foreach (var article in stockDelivery.Article)
                {
                    request.StockDeliveries[i].Items.Add(new Interfaces.Types.Input.StockDeliveryItem()
                    {
                        ArticleCode = TextConverter.UnescapeInvalidXmlChars(article.Id),
                        Name = TextConverter.UnescapeInvalidXmlChars(article.Name),
                        DosageForm = TextConverter.UnescapeInvalidXmlChars(article.DosageForm),
                        PackagingUnit = TextConverter.UnescapeInvalidXmlChars(article.PackagingUnit),
                        BatchNumber = string.IsNullOrEmpty(article.BatchNumber) ? string.Empty : TextConverter.UnescapeInvalidXmlChars(article.BatchNumber),
                        ExternalID = string.IsNullOrEmpty(article.ExternalId) ? string.Empty : TextConverter.UnescapeInvalidXmlChars(article.ExternalId),
                        ExpiryDate = TypeConverter.ConvertDate(article.ExpiryDate),
                        RequestedQuantity = TypeConverter.ConvertInt(article.Quantity)
                    });
                }
            }

            return request;
        }
    }

    /// <summary>
    /// Class which represents the WWKS 2.0 StockDeliverySetRequest message.
    /// <see cref="https://portalrowa.carefusion.com/Unternehmen/Entwicklung/TechCom/Writing/P-010-044-B-I-388-DEU.docx" />
    /// </summary>
    public class StockDeliverySetRequest : StockDeliverySetRequestSmallSet
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StockDeliverySetRequest"/> class.
        /// </summary>
        public StockDeliverySetRequest()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StockDeliverySetRequest"/> class.
        /// </summary>
        /// <param name="message">The message to use for initialization.</param>
        public StockDeliverySetRequest(MosaicMessage message)
            : base(message)
        {
            var request = (Interfaces.Messages.Stock.StockDeliverySetRequest)message;

            if (this.StockDelivery == null)
            {
                return;
            }

            for (int i = 0; i < this.StockDelivery.Length; ++i)
            {
                for (int k = 0, max = this.StockDelivery[i].Article.Count; k < max; ++k)
                {
                    this.StockDelivery[i].Article[k].RequiresFridge = request.StockDeliveries[i].Items[k].RequiresFridge.ToString();
                    this.StockDelivery[i].Article[k].MaxSubItemQuantity = request.StockDeliveries[i].Items[k].MaxSubItemQuantity.ToString();
                    this.StockDelivery[i].Article[k].StockLocationId = TextConverter.EscapeInvalidXmlChars(request.StockDeliveries[i].Items[k].StockLocationID);
                    this.StockDelivery[i].Article[k].MachineLocation = TextConverter.EscapeInvalidXmlChars(request.StockDeliveries[i].Items[k].MachineLocation);
                }
            }
        }

        /// <summary>
        /// Translates this object instance into a Mosaic message.
        /// </summary>
        /// <param name="converterStream">The converter stream instance which request the message conversion.</param>
        /// <returns>
        /// The Mosaic message representation of this object.
        /// </returns>
        public override MosaicMessage ToMosaicMessage(IConverterStream converterStream)
        {
            var request = (Interfaces.Messages.Stock.StockDeliverySetRequest)base.ToMosaicMessage(converterStream);

            if (this.StockDelivery == null)
            {
                return request;
            }

            for (int i = 0; i < this.StockDelivery.Length; ++i)
            {
                for (int k = 0, max = this.StockDelivery[i].Article.Count; k < max; ++k)
                {
                    request.StockDeliveries[i].Items[k].RequiresFridge = TypeConverter.ConvertBool(this.StockDelivery[i].Article[k].RequiresFridge);
                    request.StockDeliveries[i].Items[k].MaxSubItemQuantity = TypeConverter.ConvertInt(this.StockDelivery[i].Article[k].MaxSubItemQuantity);
                    request.StockDeliveries[i].Items[k].StockLocationID = string.IsNullOrEmpty(this.StockDelivery[i].Article[k].StockLocationId) ? string.Empty : TextConverter.UnescapeInvalidXmlChars(this.StockDelivery[i].Article[k].StockLocationId);
                    request.StockDeliveries[i].Items[k].MachineLocation = string.IsNullOrEmpty(this.StockDelivery[i].Article[k].MachineLocation) ? string.Empty : TextConverter.UnescapeInvalidXmlChars(this.StockDelivery[i].Article[k].MachineLocation);
                }
            }

            return request;
        }
    }
}
