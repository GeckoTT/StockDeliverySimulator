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
    /// Class which represents the WWKS 2.0 OutputRequest small set message envelope.
    /// </summary>
    [XmlType(TypeName = "WWKS")]
    public class OutputRequestSmallSetEnvelope : EnvelopeBase, IMessageConversion
    {
        [XmlElement]
        public OutputRequestSmallSet OutputRequest { get; set; }

        /// <summary>
        /// Translates this object instance into a Mosaic message.
        /// </summary>
        /// <param name="converterStream">The converter stream instance which request the message conversion.</param>
        /// <returns>
        /// The Mosaic message representation of this object.
        /// </returns>
        public MosaicMessage ToMosaicMessage(IConverterStream converterStream)
        {
            return this.OutputRequest.ToMosaicMessage(converterStream);
        }
    }

    /// <summary>
    /// Class which represents the WWKS 2.0 OutputRequest full set message envelope.
    /// </summary>
    [XmlType(TypeName = "WWKS")]
    public class OutputRequestEnvelope : EnvelopeBase, IMessageConversion
    {
        [XmlElement]
        public OutputRequest OutputRequest { get; set; }

        /// <summary>
        /// Translates this object instance into a Mosaic message.
        /// </summary>
        /// <param name="converterStream">The converter stream instance which request the message conversion.</param>
        /// <returns>
        /// The Mosaic message representation of this object.
        /// </returns>
        public MosaicMessage ToMosaicMessage(IConverterStream converterStream)
        {
            return this.OutputRequest.ToMosaicMessage(converterStream);
        }
    }

    /// <summary>
    /// Class which represents the WWKS 2.0 OutputRequest message in it's small set version.
    /// <see cref="Documentation\WWKS 2.0\Rowa Interface WWKS v2.0 - Singapur Project.docx" />
    /// </summary>
    public class OutputRequestSmallSet : MessageBase, IMessageConversion
    {
        #region Properties

        [XmlElement]
        public Details Details { get; set; }

        [XmlElement]
        public Criteria[] Criteria { get; set; }
        
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="OutputRequestSmallSet"/> class.
        /// </summary>
        public OutputRequestSmallSet()
        {             
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OutputRequestSmallSet"/> class.
        /// </summary>
        /// <param name="message">The message to use for initialization.</param>
        public OutputRequestSmallSet(MosaicMessage message)
        {
            StockOutputRequest request = (StockOutputRequest)message;

            this.Id = request.ID;
            this.Source = request.Source;
            this.Destination = request.Destination;

            this.Details = new Details();
            this.Details.Priority = TypeConverter.ConvertOutputPriority(request.Order.Priority);
            this.Details.OutputDestination = request.Order.OutputNumber.ToString();

            if (request.Order.Items.Count > 0)
            {
                this.Criteria = new Criteria[request.Order.Items.Count];

                for (int i = 0; i < this.Criteria.Length; ++i)
                {
                    var item = request.Order.Items[i];
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
            StockOutputRequest request = new StockOutputRequest(converterStream);

            request.ID = this.Id;
            request.Source = this.Source;
            request.Destination = this.Destination;
            request.Order = new StockOutputOrder();

            if (this.Details == null)
            {
                return null;
            }
            
            request.Order.SourceID = request.Source;
            request.Order.Priority = TypeConverter.ConvertOutputPriority(this.Details.Priority);
            request.Order.OutputNumber = TypeConverter.ConvertInt(this.Details.OutputDestination);
            request.Order.OrderNumber = request.ID.ToString();

            if (this.Criteria != null)
            {
                for (int i = 0; i < this.Criteria.Length; ++i)
                {
                    var criteria = this.Criteria[i];
                    request.Order.Items.Add(new StockOutputOrderItem()
                    {
                        PISArticleCode = (criteria.ArticleId == null) ? string.Empty : TextConverter.UnescapeInvalidXmlChars(criteria.ArticleId),
                        RequestedQuantity = criteria.Quantity,
                        BatchNumber = (criteria.BatchNumber == null) ? string.Empty : TextConverter.UnescapeInvalidXmlChars(criteria.BatchNumber),
                        ExternalID = (criteria.ExternalId == null) ? string.Empty : TextConverter.UnescapeInvalidXmlChars(criteria.ExternalId),
                        PackID = (long)TypeConverter.ConvertULong(criteria.PackId),
                        ExpiryDate = TypeConverter.ConvertDate(criteria.MinimumExpiryDate)
                    });
                }
            }

            return request;
        }
    }

    /// <summary>
    /// Class which represents the WWKS 2.0 OutputRequest message.
    /// <see cref="https://portalrowa.carefusion.com/Unternehmen/Entwicklung/TechCom/Writing/P-010-044-B-I-388-DEU.docx" />
    /// </summary>
    public class OutputRequest : OutputRequestSmallSet
    {
        #region Properties

        [XmlAttribute]
        public string BoxNumber { get; set; }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="OutputRequest"/> class.
        /// </summary>
        public OutputRequest()
        {             
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OutputRequest"/> class.
        /// </summary>
        /// <param name="message">The message to use for initialization.</param>
        public OutputRequest(MosaicMessage message)
            : base(message)
        {
            StockOutputRequest request = (StockOutputRequest)message;

            this.BoxNumber = request.Order.BoxNumber;
            this.Details.OutputPoint = request.Order.OutputPoint != 0 ? request.Order.OutputPoint.ToString() : null;

            if (request.Order.Items.Count > 0)
            {
                for (int i = 0; i < this.Criteria.Length; ++i)
                {
                    if (request.Order.Items[i].PackID != 0)
                    {
                        this.Criteria[i].PackId = ((ulong)request.Order.Items[i].PackID).ToString();
                    }

                    if (request.Order.Items[i].RequestedSubItemQuantity > 0)
                    {
                        this.Criteria[i].Quantity = 0;
                        this.Criteria[i].SubItemQuantity = request.Order.Items[i].RequestedSubItemQuantity.ToString();
                    }

                    foreach (var label in request.Order.Items[i].Labels)
                    {
                        if (this.Criteria[i].Label == null)
                        {
                            this.Criteria[i].Label = new List<Label>();
                        }

                        this.Criteria[i].Label.Add(new Label() { TemplateId = label.TemplateID, RawContent = label.Content });
                    }

                    this.Criteria[i].SingleBatchNumber = request.Order.Items[i].SingleBatchNumber.ToString();
                    this.Criteria[i].StockLocationId = string.IsNullOrEmpty(request.Order.Items[i].StockLocationID) ? null : TextConverter.EscapeInvalidXmlChars(request.Order.Items[i].StockLocationID);
                    this.Criteria[i].MachineLocation = string.IsNullOrEmpty(request.Order.Items[i].MachineLocation) ? null : TextConverter.EscapeInvalidXmlChars(request.Order.Items[i].MachineLocation);
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
            StockOutputRequest request = (StockOutputRequest)base.ToMosaicMessage(converterStream);

            if (request == null)
            {
                return null;
            }

            request.Order.BoxNumber = this.BoxNumber != null ? this.BoxNumber : string.Empty;
            request.Order.OutputPoint = TypeConverter.ConvertInt(this.Details.OutputPoint);
    
            if (this.Criteria != null)
            {
                for (int i = 0; i < this.Criteria.Length; ++i)
                {
                    request.Order.Items[i].PackID = (long)TypeConverter.ConvertULong(this.Criteria[i].PackId);
                    request.Order.Items[i].RequestedSubItemQuantity = TypeConverter.ConvertInt(this.Criteria[i].SubItemQuantity);
                    request.Order.Items[i].SingleBatchNumber = TypeConverter.ConvertBool(this.Criteria[i].SingleBatchNumber);
                    request.Order.Items[i].StockLocationID = string.IsNullOrEmpty(this.Criteria[i].StockLocationId) ? string.Empty : TextConverter.UnescapeInvalidXmlChars(this.Criteria[i].StockLocationId);
                    request.Order.Items[i].MachineLocation = string.IsNullOrEmpty(this.Criteria[i].MachineLocation) ? string.Empty : TextConverter.UnescapeInvalidXmlChars(this.Criteria[i].MachineLocation);

                    if (request.Order.Items[i].RequestedSubItemQuantity > 0)
                    {
                        request.Order.Items[i].RequestedQuantity = 0;
                    }

                    if (this.Criteria[i].Label != null)
                    {
                        foreach (var label in this.Criteria[i].Label)
                        {
                            request.Order.Items[i].Labels.Add(new StockOutputOrderItemLabel() 
                            {
                                TemplateID = label.TemplateId,
                                Content = label.RawContent
                            });
                        }
                    }
                }
            }

            return request;
        }
    }
}

