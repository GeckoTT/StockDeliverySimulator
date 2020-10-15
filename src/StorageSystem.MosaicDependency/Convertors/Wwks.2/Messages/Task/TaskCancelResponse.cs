using System.Xml.Serialization;
using CareFusion.Mosaic.Interfaces.Converters;
using CareFusion.Mosaic.Interfaces.Messages;

namespace CareFusion.Mosaic.Converters.Wwks2.Messages.Task
{
    /// <summary>
    /// Class which represents the WWKS 2.0 TaskCancelResponse message envelope.
    /// </summary>
    [XmlType(TypeName = "WWKS")]
    public class TaskCancelResponseEnvelope : EnvelopeBase, IMessageConversion
    {
        [XmlElement]
        public TaskCancelResponse TaskCancelResponse { get; set; }

        /// <summary>
        /// Translates this object instance into a Mosaic message.
        /// </summary>
        /// <param name="converterStream">The converter stream instance which request the message conversion.</param>
        /// <returns>
        /// The Mosaic message representation of this object.
        /// </returns>
        public MosaicMessage ToMosaicMessage(IConverterStream converterStream)
        {
            return this.TaskCancelResponse.ToMosaicMessage(converterStream);
        }
    }

    /// <summary>
    /// Class which represents the WWKS 2.0 TaskCancelResponse message.
    /// <see cref="https://portalrowa.carefusion.com/Unternehmen/Entwicklung/TechCom/Writing/P-010-044-B-I-388-DEU.docx" />
    /// </summary>
    public class TaskCancelResponse : MessageBase, IMessageConversion
    {
        #region Properties

        [XmlElement]
        public Types.Task[] Task { get; set; }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="TaskCancelResponse"/> class.
        /// </summary>
        public TaskCancelResponse()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TaskCancelResponse"/> class.
        /// </summary>
        /// <param name="message">The message to use for initialization.</param>
        public TaskCancelResponse(MosaicMessage message)
        {
            var response = (Interfaces.Messages.Task.TaskCancelResponse)message;

            this.Id = response.ID;
            this.Source = response.Source;
            this.Destination = response.Destination;

            if (response.Tasks.Count > 0)
            {
                this.Task = new Types.Task[response.Tasks.Count];

                for (int i = 0; i < this.Task.Length; ++i)
                {
                    var task = response.Tasks[i];
                    this.Task[i] = new Types.Task() 
                    { 
                        Id = task.ID, 
                        Status = task.State.ToString(),
                        Type = task.Type.ToString() 
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
        public MosaicMessage ToMosaicMessage(IConverterStream converterStream)
        {
            var response = new Interfaces.Messages.Task.TaskCancelResponse(converterStream);

            response.ID = this.Id;
            response.Source = this.Source;
            response.Destination = this.Destination;

            if (this.Task != null)
            {
                for (int i = 0; i < this.Task.Length; ++i)
                {
                    var task = this.Task[i];

                    response.Tasks.Add(new Interfaces.Messages.Task.Task()
                    {
                        ID = task.Id,
                        State = TypeConverter.ConvertTaskState(task.Status),
                        Type = TypeConverter.ConvertEnum<Interfaces.Messages.Task.TaskType>(task.Type, Interfaces.Messages.Task.TaskType.Output) 
                    });
                }
            }

            return response;
        }
    }
}
