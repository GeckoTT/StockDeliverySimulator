using System.Xml.Serialization;
using CareFusion.Mosaic.Interfaces.Converters;
using CareFusion.Mosaic.Interfaces.Messages;

namespace CareFusion.Mosaic.Converters.Wwks2.Messages.Task
{
    /// <summary>
    /// Class which represents the WWKS 2.0 TaskCancelRequest message envelope.
    /// </summary>
    [XmlType(TypeName = "WWKS")]
    public class TaskCancelRequestEnvelope : EnvelopeBase, IMessageConversion
    {
        [XmlElement]
        public TaskCancelRequest TaskCancelRequest { get; set; }

        /// <summary>
        /// Translates this object instance into a Mosaic message.
        /// </summary>
        /// <param name="converterStream">The converter stream instance which request the message conversion.</param>
        /// <returns>
        /// The Mosaic message representation of this object.
        /// </returns>
        public MosaicMessage ToMosaicMessage(IConverterStream converterStream)
        {
            return this.TaskCancelRequest.ToMosaicMessage(converterStream);
        }
    }

    /// <summary>
    /// Class which represents the WWKS 2.0 TaskCancelRequest message.
    /// <see cref="https://portalrowa.carefusion.com/Unternehmen/Entwicklung/TechCom/Writing/P-010-044-B-I-388-DEU.docx" />
    /// </summary>
    public class TaskCancelRequest : MessageBase, IMessageConversion
    {
        #region Properties

        [XmlElement]
        public Types.Task[] Task { get; set; }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="TaskCancelRequest"/> class.
        /// </summary>
        public TaskCancelRequest()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TaskCancelRequest"/> class.
        /// </summary>
        /// <param name="message">The message to use for initialization.</param>
        public TaskCancelRequest(MosaicMessage message)
        {
            var request = (Interfaces.Messages.Task.TaskCancelRequest)message;

            this.Id = request.ID;
            this.Source = request.Source;
            this.Destination = request.Destination;

            if (request.Tasks.Count > 0)
            {
                this.Task = new Types.Task[request.Tasks.Count];

                for (int i = 0; i < this.Task.Length; ++i)
                { 
                    var task = request.Tasks[i];
                    this.Task[i] = new Types.Task() { Id = task.ID, Type = task.Type.ToString() };
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
        public MosaicMessage ToMosaicMessage(IConverterStream converterStream)
        {
            var request = new Interfaces.Messages.Task.TaskCancelRequest(converterStream);

            request.ID = this.Id;
            request.Source = this.Source;
            request.Destination = this.Destination;

            if (this.Task != null)
            {
                for (int i = 0; i < this.Task.Length; ++i)
                {
                    request.Tasks.Add(new Interfaces.Messages.Task.Task() 
                    { 
                        ID = this.Task[i].Id, 
                        Type = TypeConverter.ConvertEnum<Interfaces.Messages.Task.TaskType>(this.Task[i].Type, Interfaces.Messages.Task.TaskType.Output) 
                    });
                }
            }

            return request;
        }
    }
}
