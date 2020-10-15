using System.Xml.Serialization;
using CareFusion.Mosaic.Interfaces.Converters;
using CareFusion.Mosaic.Interfaces.Messages;
using System.Collections.Generic;
using CareFusion.Mosaic.Interfaces.Types.Packs;
using CareFusion.Mosaic.Interfaces.Types.Output;
using CareFusion.Mosaic.Interfaces.Messages.Task;

namespace CareFusion.Mosaic.Converters.Wwks2.Messages.Task
{
    /// <summary>
    /// Class which represents the WWKS 2.0 TaskInfoResponse message envelope.
    /// </summary>
    [XmlType(TypeName = "WWKS")]
    public class TaskInfoResponseEnvelope : EnvelopeBase, IMessageConversion
    {
        [XmlElement]
        public TaskInfoResponse TaskInfoResponse { get; set; }

        /// <summary>
        /// Translates this object instance into a Mosaic message.
        /// </summary>
        /// <param name="converterStream">The converter stream instance which request the message conversion.</param>
        /// <returns>
        /// The Mosaic message representation of this object.
        /// </returns>
        public MosaicMessage ToMosaicMessage(IConverterStream converterStream)
        {
            return this.TaskInfoResponse.ToMosaicMessage(converterStream);
        }
    }

    /// <summary>
    /// Class which represents the WWKS 2.0 TaskInfoResponse message.
    /// <see cref="https://portalrowa.carefusion.com/Unternehmen/Entwicklung/TechCom/Writing/P-010-044-B-I-388-DEU.docx" />
    /// </summary>
    public class TaskInfoResponse : MessageBase, IMessageConversion
    {
        #region Properties

        [XmlElement]
        public Types.Task[] Task { get; set; }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="TaskInfoResponse"/> class.
        /// </summary>
        public TaskInfoResponse()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TaskInfoResponse"/> class.
        /// </summary>
        /// <param name="message">The message to use for initialization.</param>
        public TaskInfoResponse(MosaicMessage message)
        {
            var response = (Interfaces.Messages.Task.TaskInfoResponse)message;

            this.Id = response.ID;
            this.Source = response.Source;
            this.Destination = response.Destination;

            if (response.Tasks.Count == 0)
            {
                return;
            }

            this.Task = new Types.Task[response.Tasks.Count];

            for (int i = 0; i < this.Task.Length; ++i)
            {
                var task = response.Tasks[i];
                List<Types.Article> articles = new List<Types.Article>();
                List<Types.Box> boxes = new List<Types.Box>();

                foreach (string boxNumber in task.BoxNumbers)
                    boxes.Add(new Types.Box() { Number = boxNumber });

                if (task.OutputPacks.Count > 0)
                {
                    foreach (var pack in task.OutputPacks)
                    {
                        var article = articles.Find(a => string.Compare(a.Id, pack.RobotArticleCode) == 0);

                        if (article == null)
                        {
                            article = new Types.Article()
                            {
                                Id = TextConverter.EscapeInvalidXmlChars(pack.RobotArticleCode),
                                Pack = new List<Types.Pack>()
                            };
                            articles.Add(article);
                        }

                        article.Pack.Add(new Types.Pack()
                        {
                            Id = ((ulong)pack.ID).ToString(),
                            BatchNumber = TextConverter.EscapeInvalidXmlChars(pack.BatchNumber),
                            ExternalId = TextConverter.EscapeInvalidXmlChars(pack.ExternalID),
                            ExpiryDate = TypeConverter.ConvertDateNull(pack.ExpiryDate),
                            StockInDate = TypeConverter.ConvertDateNull(pack.StockInDate),
                            ScanCode = TextConverter.EscapeInvalidXmlChars(pack.ScanCode),
                            DeliveryNumber = TextConverter.EscapeInvalidXmlChars(pack.DeliveryNumber),
                            Depth = pack.Depth.ToString(),
                            Width = pack.Width.ToString(),
                            Height = pack.Height.ToString(),
                            Shape = pack.Shape.ToString(),
                            IsInFridge = pack.IsInFridge.ToString(),
                            BoxNumber = TextConverter.EscapeInvalidXmlChars(pack.BoxNumber),
                            SubItemQuantity = pack.SubItemQuantity.ToString(),
                            LabelStatus = pack.LabelState.ToString(),
                            OutputDestination = pack.OutputNumber.ToString(),
                            OutputPoint = pack.OutputPoint.ToString(),
                            StockLocationId = TextConverter.EscapeInvalidXmlChars(pack.StockLocationID),
                            MachineLocation = TextConverter.EscapeInvalidXmlChars(pack.MachineLocation)
                        });
                    }
                }
                else if (task.DeliveryItems.Count > 0)
                {
                    foreach (var item in task.DeliveryItems)
                    {
                        var article = new Types.Article() 
                        {
                            Id = TextConverter.EscapeInvalidXmlChars(item.ArticleCode),
                            Quantity = item.RequestedQuantity.ToString(),
                            Pack = item.Packs.Count > 0 ? new List<Types.Pack>() : null
                        };

                        foreach (var pack in item.Packs)
                        {
                            article.Pack.Add(new Types.Pack()
                            {
                                Id = ((ulong)pack.ID).ToString(),
                                BatchNumber = TextConverter.EscapeInvalidXmlChars(pack.BatchNumber),
                                ExternalId = TextConverter.EscapeInvalidXmlChars(pack.ExternalID),
                                ExpiryDate = TypeConverter.ConvertDateNull(pack.ExpiryDate),
                                StockInDate = TypeConverter.ConvertDateNull(pack.StockInDate),
                                ScanCode = TextConverter.EscapeInvalidXmlChars(pack.ScanCode),
                                DeliveryNumber = TextConverter.EscapeInvalidXmlChars(task.ID),
                                Depth = pack.Depth.ToString(),
                                Width = pack.Width.ToString(),
                                Height = pack.Height.ToString(),
                                Shape = pack.Shape.ToString(),
                                IsInFridge = pack.IsInFridge.ToString(),
                                SubItemQuantity = pack.SubItemQuantity.ToString(),
                                StockLocationId = TextConverter.EscapeInvalidXmlChars(pack.StockLocationID),
                                MachineLocation = TextConverter.EscapeInvalidXmlChars(pack.MachineLocation)
                            });
                        }

                        articles.Add(article);
                    }
                }

                this.Task[i] = new Types.Task()
                {
                    Id = task.ID,
                    Status = task.State.ToString(),
                    Type = task.Type.ToString(),
                    Article = articles.Count > 0 ? articles.ToArray() : null,
                    Box = boxes.Count > 0 ? boxes.ToArray() : null
                }; 
            }
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
            var response = new Interfaces.Messages.Task.TaskInfoResponse(converterStream);

            response.ID = this.Id;
            response.Source = this.Source;
            response.Destination = this.Destination;

            if (this.Task != null)
            {
                for (int i = 0; i < this.Task.Length; ++i)
                {
                    var task = this.Task[i];
                    var msgTask = new Interfaces.Messages.Task.Task()
                    {
                        ID = task.Id,
                        State = TypeConverter.ConvertTaskState(task.Status),
                        Type = TypeConverter.ConvertEnum<Interfaces.Messages.Task.TaskType>(task.Type, Interfaces.Messages.Task.TaskType.Output) 
                    };

                    if (task.Article == null)
                    {
                        response.Tasks.Add(msgTask);
                        continue;
                    }

                    foreach (var article in task.Article)
                    {
                        if (msgTask.Type == Interfaces.Messages.Task.TaskType.Output)
                        {
                            if (article.Pack == null)
                                continue;

                            foreach (var pack in article.Pack)
                            {
                                msgTask.OutputPacks.Add(new Interfaces.Types.Output.StockOutputOrderItemPack()
                                {
                                    RobotArticleCode = article.Id,
                                    ID = (long)TypeConverter.ConvertULong(pack.Id),
                                    BatchNumber = TextConverter.UnescapeInvalidXmlChars(pack.BatchNumber),
                                    ExternalID = TextConverter.UnescapeInvalidXmlChars(pack.ExternalId),
                                    ExpiryDate = TypeConverter.ConvertDate(pack.ExpiryDate),
                                    StockInDate = TypeConverter.ConvertDate(pack.StockInDate),
                                    ScanCode = TextConverter.UnescapeInvalidXmlChars(pack.ScanCode),
                                    DeliveryNumber = TextConverter.UnescapeInvalidXmlChars(pack.DeliveryNumber),
                                    Depth = TypeConverter.ConvertInt(pack.Depth),
                                    Width = TypeConverter.ConvertInt(pack.Width),
                                    Height = TypeConverter.ConvertInt(pack.Height),
                                    Shape = TypeConverter.ConvertEnum<PackShape>(pack.Shape, PackShape.Cuboid),
                                    IsInFridge = TypeConverter.ConvertBool(pack.IsInFridge),
                                    BoxNumber = TextConverter.UnescapeInvalidXmlChars(pack.BoxNumber),
                                    SubItemQuantity = TypeConverter.ConvertInt(pack.SubItemQuantity),
                                    LabelState = TypeConverter.ConvertEnum<StockOutputOrderItemPackLabelState>(pack.LabelStatus, StockOutputOrderItemPackLabelState.NotLabelled),
                                    OutputNumber = TypeConverter.ConvertInt(pack.OutputDestination),
                                    OutputPoint = TypeConverter.ConvertInt(pack.OutputPoint),
                                    StockLocationID = TextConverter.UnescapeInvalidXmlChars(pack.StockLocationId),
                                    MachineLocation = TextConverter.UnescapeInvalidXmlChars(pack.MachineLocation)
                                });
                            }
                        }
                        else
                        {
                            var deliveryItem = new Interfaces.Types.Input.StockDeliveryItem()
                            {
                                ArticleCode = TextConverter.UnescapeInvalidXmlChars(article.Id),
                                RequestedQuantity = TypeConverter.ConvertInt(article.Quantity)
                            };

                            foreach (var pack in article.Pack)
                            {
                                deliveryItem.Packs.Add(new Interfaces.Types.Input.StockDeliveryItemPack()
                                {
                                    ID = (long)TypeConverter.ConvertULong(pack.Id),
                                    BatchNumber = TextConverter.UnescapeInvalidXmlChars(pack.BatchNumber),
                                    ExternalID = TextConverter.UnescapeInvalidXmlChars(pack.ExternalId),
                                    ExpiryDate = TypeConverter.ConvertDate(pack.ExpiryDate),
                                    StockInDate = TypeConverter.ConvertDate(pack.StockInDate),
                                    ScanCode = TextConverter.UnescapeInvalidXmlChars(pack.ScanCode),
                                    Depth = TypeConverter.ConvertInt(pack.Depth),
                                    Width = TypeConverter.ConvertInt(pack.Width),
                                    Height = TypeConverter.ConvertInt(pack.Height),
                                    Shape = TypeConverter.ConvertEnum<PackShape>(pack.Shape, PackShape.Cuboid),
                                    IsInFridge = TypeConverter.ConvertBool(pack.IsInFridge),
                                    SubItemQuantity = TypeConverter.ConvertInt(pack.SubItemQuantity),
                                    StockLocationID = TextConverter.UnescapeInvalidXmlChars(pack.StockLocationId),
                                    MachineLocation = TextConverter.UnescapeInvalidXmlChars(pack.MachineLocation)
                                });
                            }

                            msgTask.DeliveryItems.Add(deliveryItem);
                        }
                    }

                    response.Tasks.Add(msgTask);
                }
            }

            return response;
        }
    }
}
