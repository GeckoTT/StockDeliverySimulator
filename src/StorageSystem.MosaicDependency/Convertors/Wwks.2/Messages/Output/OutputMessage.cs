using System.Collections.Generic;
using System.Xml.Serialization;
using CareFusion.Mosaic.Converters.Wwks2.Types;
using CareFusion.Mosaic.Interfaces.Converters;
using CareFusion.Mosaic.Interfaces.Messages;
using CareFusion.Mosaic.Interfaces.Messages.Output;
using CareFusion.Mosaic.Interfaces.Types.Output;
using CareFusion.Mosaic.Interfaces.Types.Packs;

namespace CareFusion.Mosaic.Converters.Wwks2.Messages.Output
{
    /// <summary>
    /// Class which represents the WWKS 2.0 OutputMessage message envelope.
    /// </summary>
    [XmlType(TypeName = "WWKS")]
    public class OutputMessageSmallSetEnvelope : EnvelopeBase, IMessageConversion
    {
        [XmlElement]
        public OutputMessageSmallSet OutputMessage { get; set; }

        /// <summary>
        /// Translates this object instance into a Mosaic message.
        /// </summary>
        /// <param name="converterStream">The converter stream instance which request the message conversion.</param>
        /// <returns>
        /// The Mosaic message representation of this object.
        /// </returns>
        public MosaicMessage ToMosaicMessage(IConverterStream converterStream)
        {
            return this.OutputMessage.ToMosaicMessage(converterStream);
        }
    }

    /// <summary>
    /// Class which represents the WWKS 2.0 OutputMessage message envelope.
    /// </summary>
    [XmlType(TypeName = "WWKS")]
    public class OutputMessageEnvelope : EnvelopeBase, IMessageConversion
    {
        [XmlElement]
        public OutputMessage OutputMessage { get; set; }

        /// <summary>
        /// Translates this object instance into a Mosaic message.
        /// </summary>
        /// <param name="converterStream">The converter stream instance which request the message conversion.</param>
        /// <returns>
        /// The Mosaic message representation of this object.
        /// </returns>
        public MosaicMessage ToMosaicMessage(IConverterStream converterStream)
        {
            return this.OutputMessage.ToMosaicMessage(converterStream);
        }
    }

    /// <summary>
    /// Class which represents the WWKS 2.0 OutputMessage message.
    /// <see cref="Documentation\WWKS 2.0\Rowa Interface WWKS v2.0 - Singapur Project.docx" />
    /// </summary>
    public class OutputMessageSmallSet : MessageBase, IMessageConversion
    {
        #region Properties

        [XmlElement]
        public Details Details { get; set; }

        [XmlElement]
        public Article[] Article { get; set; }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="OutputMessageSmallSet"/> class.
        /// </summary>
        public OutputMessageSmallSet()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OutputMessageSmallSet"/> class.
        /// </summary>
        /// <param name="message">The message to use for initialization.</param>
        public OutputMessageSmallSet(MosaicMessage message)
        {
            StockOutputMessage msg = (StockOutputMessage)message;

            this.Id = msg.ID;
            this.Source = msg.Source;
            this.Destination = msg.Destination;

            this.Details = new Details();
            this.Details.Priority = TypeConverter.ConvertOutputPriority(msg.Order.Priority);
            this.Details.OutputDestination = msg.Order.OutputNumber.ToString();

            switch (msg.Order.State)
            {
                case StockOutputOrderState.Completed: 
                case StockOutputOrderState.Incomplete:
                case StockOutputOrderState.Aborted:
                    this.Details.Status = msg.Order.State.ToString();
                    break;

                default:
                    this.Details.Status = StockOutputOrderState.Incomplete.ToString();
                    break;
            }

            if (msg.Order.Items.Count > 0)
            {
                Dictionary<string, Article> _articleMap = new Dictionary<string, Article>();

                foreach (var orderItem in msg.Order.Items)
                {
                    foreach (var pack in orderItem.Packs)
                    {
                        if (_articleMap.ContainsKey(pack.RobotArticleCode) == false)
                        {
                            _articleMap.Add(pack.RobotArticleCode, 
                                            new Article() { Id = TextConverter.EscapeInvalidXmlChars(pack.RobotArticleCode), 
                                                            Pack = new List<Types.Pack>() });
                        }

                        _articleMap[pack.RobotArticleCode].Pack.Add(new Types.Pack()
                                                               {
                                                                    Id = ((ulong)pack.ID).ToString(),
                                                                    BatchNumber = TextConverter.EscapeInvalidXmlChars(pack.BatchNumber),
                                                                    ExternalId = TextConverter.EscapeInvalidXmlChars(pack.ExternalID),
                                                                    ExpiryDate = TypeConverter.ConvertDateNull(pack.ExpiryDate)
                                                               });
                     }
                }

                if (_articleMap.Count > 0)
                {
                    int counter = 0;
                    this.Article = new Article[_articleMap.Count];

                    foreach (var articleKey in _articleMap.Keys)
                    {
                        this.Article[counter++] = _articleMap[articleKey];
                    }
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
            StockOutputMessage msg = new StockOutputMessage(converterStream);

            msg.ID = this.Id;
            msg.Source = this.Source;
            msg.Destination = this.Destination;
            msg.Order = new StockOutputOrder();

            if (this.Details == null)
            {
                return null;
            }

            msg.Order.Priority = TypeConverter.ConvertOutputPriority(this.Details.Priority);
            msg.Order.OutputNumber = TypeConverter.ConvertInt(this.Details.OutputDestination);
            msg.Order.State = TypeConverter.ConvertOrderState(this.Details.Status);

            if (this.Article != null)
            {
                foreach (var article in this.Article)
                {
                    var item = new StockOutputOrderItem() { RobotArticleCode = TextConverter.UnescapeInvalidXmlChars(article.Id) };

                    if (article.Pack != null)
                    {
                        foreach (var pack in article.Pack)
                        {
                            item.Packs.Add(new StockOutputOrderItemPack() 
                            {
                                ID = (long)TypeConverter.ConvertULong(pack.Id),
                                BatchNumber = TextConverter.UnescapeInvalidXmlChars(pack.BatchNumber),
                                ExternalID = TextConverter.UnescapeInvalidXmlChars(pack.ExternalId),
                                ExpiryDate = TypeConverter.ConvertDate(pack.ExpiryDate)
                            });
                        }
                    }

                    msg.Order.Items.Add(item);
                }
            }

            return msg;
        }
    }

    /// <summary>
    /// Class which represents the WWKS 2.0 OutputMessage message.
    /// <see cref="https://portalrowa.carefusion.com/Unternehmen/Entwicklung/TechCom/Writing/P-010-044-B-I-388-DEU.docx" />
    /// </summary>
    public class OutputMessage : OutputMessageSmallSet
    {
        #region Properties

        [XmlElement]
        public Box[] Box { get; set; }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="OutputMessage"/> class.
        /// </summary>
        public OutputMessage()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OutputMessage"/> class.
        /// </summary>
        /// <param name="message">The message to use for initialization.</param>
        public OutputMessage(MosaicMessage message)
            : base(message)
        {
            StockOutputMessage msg = (StockOutputMessage)message;
            this.Details.OutputPoint = msg.Order.OutputPoint != 0 ? msg.Order.OutputPoint.ToString() : null;

            var boxNumberList = new List<string>();

            if (this.Article != null)
            {
                Dictionary<string, Types.Pack> _packMap = new Dictionary<string, Types.Pack>();

                foreach (var article in this.Article)
                {
                    if (article.Pack == null)
                    {
                        continue;
                    }

                    foreach (var pack in article.Pack)
                    {
                        _packMap.Add(pack.Id, pack);
                    }
                }

                foreach (var orderItem in msg.Order.Items)
                {
                    foreach (var pack in orderItem.Packs)
                    {
                        if (_packMap.ContainsKey(((ulong)pack.ID).ToString()) == false)
                        {
                            continue;
                        }

                        var msgPack = _packMap[((ulong)pack.ID).ToString()];

                        msgPack.StockInDate = TypeConverter.ConvertDateNull(pack.StockInDate);
                        msgPack.ScanCode = TextConverter.EscapeInvalidXmlChars(pack.ScanCode);
                        msgPack.DeliveryNumber = TextConverter.EscapeInvalidXmlChars(pack.DeliveryNumber);
                        msgPack.Depth = pack.Depth.ToString();
                        msgPack.Width = pack.Width.ToString();
                        msgPack.Height = pack.Height.ToString();
                        msgPack.Shape = pack.Shape.ToString();
                        msgPack.IsInFridge = pack.IsInFridge.ToString();
                        msgPack.BoxNumber = pack.BoxNumber;
                        msgPack.SubItemQuantity = pack.SubItemQuantity.ToString();
                        msgPack.LabelStatus = pack.LabelState.ToString();
                        msgPack.OutputDestination = pack.OutputNumber.ToString();
                        msgPack.OutputPoint = pack.OutputPoint.ToString();
                        msgPack.StockLocationId = TextConverter.EscapeInvalidXmlChars(pack.StockLocationID);
                        msgPack.MachineLocation = TextConverter.EscapeInvalidXmlChars(pack.MachineLocation);

                        if ((string.IsNullOrEmpty(pack.BoxNumber) == false) &&
                            (boxNumberList.Contains(pack.BoxNumber) == false))
                        {
                            boxNumberList.Add(pack.BoxNumber);
                        }
                    }
                }
            }
            else if (string.IsNullOrEmpty(msg.Order.BoxNumber) == false)
            {
                if (msg.Order.BoxNumber.EndsWith(".."))
                {
                    boxNumberList.Add(msg.Order.BoxNumber.Substring(0, msg.Order.BoxNumber.Length - 2));
                }
                else
                {
                    boxNumberList.Add(msg.Order.BoxNumber);
                }
            }

            if (boxNumberList.Count > 0)
            {
                this.Box = new Box[boxNumberList.Count];

                for (int i = 0; i < this.Box.Length; ++i)
                {
                    this.Box[i] = new Box() { Number = boxNumberList[i] };
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
            StockOutputMessage msg = (StockOutputMessage)base.ToMosaicMessage(converterStream);
            msg.Order.OutputPoint = TypeConverter.ConvertInt(this.Details.OutputPoint);

            if (msg == null)
            {
                return null;
            }

            if (msg.Order.Items.Count > 0)
            {
                for (int i = 0; i < msg.Order.Items.Count; ++i)
                {
                    var item = msg.Order.Items[i];

                    if (item.Packs.Count > 0)
                    {
                        for (int k = 0; k < item.Packs.Count; ++k)
                        {
                            item.Packs[k].StockInDate = TypeConverter.ConvertDate(this.Article[i].Pack[k].StockInDate);
                            item.Packs[k].ScanCode = TextConverter.UnescapeInvalidXmlChars(this.Article[i].Pack[k].ScanCode);
                            item.Packs[k].DeliveryNumber = TextConverter.UnescapeInvalidXmlChars(this.Article[i].Pack[k].DeliveryNumber);
                            item.Packs[k].Depth = TypeConverter.ConvertInt(this.Article[i].Pack[k].Depth);
                            item.Packs[k].Width = TypeConverter.ConvertInt(this.Article[i].Pack[k].Depth);
                            item.Packs[k].Height = TypeConverter.ConvertInt(this.Article[i].Pack[k].Depth);
                            item.Packs[k].Shape = TypeConverter.ConvertEnum<PackShape>(this.Article[i].Pack[k].Shape, PackShape.Cuboid);
                            item.Packs[k].IsInFridge = TypeConverter.ConvertBool(this.Article[i].Pack[k].IsInFridge);
                            item.Packs[k].BoxNumber = this.Article[i].Pack[k].BoxNumber;
                            item.Packs[k].SubItemQuantity = TypeConverter.ConvertInt(this.Article[i].Pack[k].SubItemQuantity);
                            item.Packs[k].OutputNumber = TypeConverter.ConvertInt(this.Article[i].Pack[k].OutputDestination);
                            item.Packs[k].OutputPoint = TypeConverter.ConvertInt(this.Article[i].Pack[k].OutputPoint);
                            item.Packs[k].LabelState = TypeConverter.ConvertEnum<StockOutputOrderItemPackLabelState>(this.Article[i].Pack[k].LabelStatus, StockOutputOrderItemPackLabelState.NotLabelled);
                            item.Packs[k].StockLocationID = string.IsNullOrEmpty(this.Article[i].Pack[k].StockLocationId) ? string.Empty : TextConverter.UnescapeInvalidXmlChars(this.Article[i].Pack[k].StockLocationId);
                            item.Packs[k].MachineLocation = string.IsNullOrEmpty(this.Article[i].Pack[k].MachineLocation) ? string.Empty : TextConverter.UnescapeInvalidXmlChars(this.Article[i].Pack[k].MachineLocation);
                        }
                    }
                }
            }

 
            return msg;
        }
    }
}
