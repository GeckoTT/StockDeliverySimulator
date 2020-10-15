using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using CareFusion.Mosaic.Converters.Wwks2.Types;
using CareFusion.Mosaic.Interfaces.Converters;
using CareFusion.Mosaic.Interfaces.Messages;
using CareFusion.Mosaic.Interfaces.Messages.Output;
using CareFusion.Mosaic.Interfaces.Types.Output;

namespace CareFusion.Mosaic.Converters.Wwks2.Messages.Output
{
    /// <summary>
    /// Class which represents the WWKS 2.0 OutputResponse small set message envelope.
    /// </summary>
    [XmlType(TypeName = "WWKS")]
    public class OutputResponseSmallSetEnvelope : EnvelopeBase, IMessageConversion
    {
        [XmlElement]
        public OutputResponseSmallSet OutputResponse { get; set; }

        /// <summary>
        /// Translates this object instance into a Mosaic message.
        /// </summary>
        /// <param name="converterStream">The converter stream instance which request the message conversion.</param>
        /// <returns>
        /// The Mosaic message representation of this object.
        /// </returns>
        public MosaicMessage ToMosaicMessage(IConverterStream converterStream)
        {
            return this.OutputResponse.ToMosaicMessage(converterStream);
        }
    }

    /// <summary>
    /// Class which represents the WWKS 2.0 OutputResponse full set message envelope.
    /// </summary>
    [XmlType(TypeName = "WWKS")]
    public class OutputResponseEnvelope : EnvelopeBase, IMessageConversion
    {
        [XmlElement]
        public OutputResponse OutputResponse { get; set; }

        /// <summary>
        /// Translates this object instance into a Mosaic message.
        /// </summary>
        /// <param name="converterStream">The converter stream instance which request the message conversion.</param>
        /// <returns>
        /// The Mosaic message representation of this object.
        /// </returns>
        public MosaicMessage ToMosaicMessage(IConverterStream converterStream)
        {
            return this.OutputResponse.ToMosaicMessage(converterStream);
        }
    }

    /// <summary>
    /// Class which represents the WWKS 2.0 OutputResponse message.
    /// <see cref="Documentation\WWKS 2.0\Rowa Interface WWKS v2.0 - Singapur Project.docx" />
    /// </summary>
    public class OutputResponseSmallSet : MessageBase, IMessageConversion
    {
        #region Properties

        [XmlElement]
        public Details Details { get; set; }

        [XmlElement]
        public Criteria[] Criteria { get; set; }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="OutputResponseSmallSet"/> class.
        /// </summary>
        public OutputResponseSmallSet()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OutputResponseSmallSet"/> class.
        /// </summary>
        /// <param name="message">The message to use for initialization.</param>
        public OutputResponseSmallSet(MosaicMessage message)
        {
            StockOutputResponse response = (StockOutputResponse)message;

            this.Id = response.ID;
            this.Source = response.Source;
            this.Destination = response.Destination;

            this.Details = new Details();
            this.Details.Priority = TypeConverter.ConvertOutputPriority(response.Order.Priority);
            this.Details.OutputDestination = response.Order.OutputNumber.ToString();
            this.Details.Status = response.Order.State.ToString();

            if (response.Order.Items.Count > 0)
            {
                this.Criteria = new Criteria[response.Order.Items.Count];

                for (int i = 0; i < this.Criteria.Length; ++i)
                {
                    var item = response.Order.Items[i];
                    this.Criteria[i] = new Criteria()
                    {
                        ArticleId = string.IsNullOrEmpty(item.RobotArticleCode) ? null : TextConverter.EscapeInvalidXmlChars(item.RobotArticleCode),
                        Quantity = item.RequestedQuantity,
                        BatchNumber = string.IsNullOrEmpty(item.BatchNumber) ? null : TextConverter.EscapeInvalidXmlChars(item.BatchNumber),
                        ExternalId = string.IsNullOrEmpty(item.ExternalID) ? null : TextConverter.EscapeInvalidXmlChars(item.ExternalID),
                        PackId = (item.PackID == 0) ? null : ((ulong)item.PackID).ToString(),
                        MinimumExpiryDate = TypeConverter.ConvertDateNull(item.ExpiryDate)
                    };
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
            StockOutputResponse response = new StockOutputResponse(converterStream);

            response.ID = this.Id;
            response.Source = this.Source;
            response.Destination = this.Destination;
            response.Order = new StockOutputOrder();

            if (this.Details == null)
            {
                return null;
            }

            response.Order.Priority = TypeConverter.ConvertOutputPriority(this.Details.Priority);
            response.Order.OutputNumber = TypeConverter.ConvertInt(this.Details.OutputDestination);
            response.Order.State = TypeConverter.ConvertOrderState(this.Details.Status);

            if (this.Criteria != null)
            {
                for (int i = 0; i < this.Criteria.Length; ++i)
                {
                    var criteria = this.Criteria[i];
                    response.Order.Items.Add(new StockOutputOrderItem()
                    {
                        RobotArticleCode = TextConverter.UnescapeInvalidXmlChars(criteria.ArticleId),
                        RequestedQuantity = criteria.Quantity,
                        BatchNumber = TextConverter.UnescapeInvalidXmlChars(criteria.BatchNumber),
                        ExternalID = TextConverter.UnescapeInvalidXmlChars(criteria.ExternalId),
                        PackID = (long)TypeConverter.ConvertULong(criteria.PackId),
                        ExpiryDate = TypeConverter.ConvertDate(criteria.MinimumExpiryDate)
                    });
                }
            }

            return response;
        }
    }

    /// <summary>
    /// Class which represents the WWKS 2.0 OutputResponse message.
    /// <see cref="https://portalrowa.carefusion.com/Unternehmen/Entwicklung/TechCom/Writing/P-010-044-B-I-388-DEU.docx" />
    /// </summary>
    public class OutputResponse : OutputResponseSmallSet
    {
        #region Properties

        [XmlAttribute]
        public string BoxNumber { get; set; }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="OutputResponse"/> class.
        /// </summary>
        public OutputResponse()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OutputResponse"/> class.
        /// </summary>
        /// <param name="message">The message to use for initialization.</param>
        public OutputResponse(MosaicMessage message)
            : base(message)
        {
            StockOutputResponse response = (StockOutputResponse)message;

            this.BoxNumber = response.Order.BoxNumber;
            this.Details.OutputPoint = response.Order.OutputPoint != 0 ? response.Order.OutputPoint.ToString() : null;

            if (response.Order.Items.Count > 0)
            {
                for (int i = 0; i < this.Criteria.Length; ++i)
                {
                    if (response.Order.Items[i].PackID != 0)
                    {
                        this.Criteria[i].PackId = ((ulong)response.Order.Items[i].PackID).ToString();
                    }

                    if (response.Order.Items[i].RequestedSubItemQuantity > 0)
                    {
                        this.Criteria[i].Quantity = 0;
                        this.Criteria[i].SubItemQuantity = response.Order.Items[i].RequestedSubItemQuantity.ToString();
                    }

                    foreach (var label in response.Order.Items[i].Labels)
                    {
                        if (this.Criteria[i].Label == null)
                        {
                            this.Criteria[i].Label = new List<Label>();
                        }

                        this.Criteria[i].Label.Add(new Label() { TemplateId = label.TemplateID, RawContent = label.Content });
                    }

                    this.Criteria[i].ArticleId = string.IsNullOrEmpty(response.Order.Items[i].PISArticleCode) ? null : TextConverter.EscapeInvalidXmlChars(response.Order.Items[i].PISArticleCode);
                    this.Criteria[i].SingleBatchNumber = response.Order.Items[i].SingleBatchNumber.ToString();
                    this.Criteria[i].StockLocationId = string.IsNullOrEmpty(response.Order.Items[i].StockLocationID) ? null : TextConverter.EscapeInvalidXmlChars(response.Order.Items[i].StockLocationID);
                    this.Criteria[i].MachineLocation = string.IsNullOrEmpty(response.Order.Items[i].MachineLocation) ? null : TextConverter.EscapeInvalidXmlChars(response.Order.Items[i].MachineLocation);
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
            StockOutputResponse response = (StockOutputResponse)base.ToMosaicMessage(converterStream);

            if (response == null)
            {
                return null;
            }

            response.Order.BoxNumber = this.BoxNumber != null ? this.BoxNumber : string.Empty;
            response.Order.OutputPoint = TypeConverter.ConvertInt(this.Details.OutputPoint);

            if (this.Criteria != null)
            {
                for (int i = 0; i < this.Criteria.Length; ++i)
                {
                    response.Order.Items[i].PackID = (long)TypeConverter.ConvertULong(this.Criteria[i].PackId);
                    response.Order.Items[i].RequestedSubItemQuantity = TypeConverter.ConvertInt(this.Criteria[i].SubItemQuantity);
                    response.Order.Items[i].SingleBatchNumber = TypeConverter.ConvertBool(this.Criteria[i].SingleBatchNumber);
                    response.Order.Items[i].StockLocationID = string.IsNullOrEmpty(this.Criteria[i].StockLocationId) ? string.Empty : TextConverter.UnescapeInvalidXmlChars(this.Criteria[i].StockLocationId);
                    response.Order.Items[i].MachineLocation = string.IsNullOrEmpty(this.Criteria[i].MachineLocation) ? string.Empty : TextConverter.UnescapeInvalidXmlChars(this.Criteria[i].MachineLocation);
                    response.Order.Items[i].PISArticleCode = string.IsNullOrEmpty(this.Criteria[i].ArticleId) ? null : TextConverter.EscapeInvalidXmlChars(this.Criteria[i].ArticleId);

                    if (response.Order.Items[i].RequestedSubItemQuantity > 0)
                    {
                        response.Order.Items[i].RequestedQuantity = 0;
                    }

                    if (this.Criteria[i].Label != null)
                    {
                        foreach (var label in this.Criteria[i].Label)
                        {
                            response.Order.Items[i].Labels.Add(new StockOutputOrderItemLabel()
                            {
                                TemplateID = label.TemplateId,
                                Content = label.RawContent
                            });
                        }
                    }
                }
            }

            return response;
        }
    }
}
