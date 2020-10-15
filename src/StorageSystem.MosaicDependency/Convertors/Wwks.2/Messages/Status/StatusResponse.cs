using System;
using System.Xml.Serialization;
using CareFusion.Mosaic.Interfaces.Converters;
using CareFusion.Mosaic.Interfaces.Messages;
using CareFusion.Mosaic.Interfaces.Messages.Status;
using CareFusion.Mosaic.Converters.Wwks2.Types;
using System.Collections.Generic;

namespace CareFusion.Mosaic.Converters.Wwks2.Messages.Status
{
    /// <summary>
    /// Class which represents the WWKS 2.0 StatusResponse message envelope.
    /// </summary>
    [XmlType(TypeName = "WWKS")]
    public class StatusResponseEnvelope : EnvelopeBase, IMessageConversion
    {
        [XmlElement]
        public StatusResponse StatusResponse { get; set; }

        /// <summary>
        /// Translates this object instance into a Mosaic message.
        /// </summary>
        /// <param name="converterStream">The converter stream instance which request the message conversion.</param>
        /// <returns>
        /// The Mosaic message representation of this object.
        /// </returns>
        public MosaicMessage ToMosaicMessage(IConverterStream converterStream)
        {
            return this.StatusResponse.ToMosaicMessage(converterStream);
        }
    }

    /// <summary>
    /// Class which represents the WWKS 2.0 StatusResponse message.
    /// <see cref="https://portalrowa.carefusion.com/Unternehmen/Entwicklung/TechCom/Writing/P-010-044-B-I-388-DEU.docx" />
    /// </summary>
    public class StatusResponse : MessageBase, IMessageConversion
    {
        #region Properties

        [XmlAttribute]
        public string State { get; set; }

        [XmlAttribute]
        public string StateText { get; set; }

        [XmlElement]
        public Component[] Component { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Initializes a new instance of the <see cref="StatusResponse"/> class.
        /// </summary>
        public StatusResponse()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StatusResponse"/> class.
        /// </summary>
        /// <param name="message">The message to use for initialization.</param>
        public StatusResponse(MosaicMessage message)
        {
            var response = (Interfaces.Messages.Status.StatusResponse)message;

            this.Id = response.ID;
            this.Source = response.Source;
            this.Destination = response.Destination;
            this.State = response.Component.State.ToString();
            this.StateText = response.Component.StateDescription;

            if ((response.Component.SubComponents != null) &&
                (response.Component.SubComponents.Length > 0))
            {
                this.Component = new Component[response.Component.SubComponents.Length];

                for (int i = 0; i < response.Component.SubComponents.Length; ++i)
                {
                    var subComponent = response.Component.SubComponents[i];

                    this.Component[i] = new Component() 
                    {
                        Description = TextConverter.EscapeInvalidXmlChars(subComponent.Description),
                        State = subComponent.State.ToString(),
                        StateText = TextConverter.EscapeInvalidXmlChars(subComponent.StateDescription),
                        Type = subComponent.Type
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
            var response = new Interfaces.Messages.Status.StatusResponse(converterStream);

            response.ID = this.Id;
            response.Source = this.Source;
            response.Destination = this.Destination;
            response.Component = new StatusComponent();
            response.Component.State = TypeConverter.ConvertEnum<StatusType>(this.State, StatusType.NotReady);
            response.Component.StateDescription = this.StateText;

            if (this.Component != null)
            {
                var subComponents = new List<StatusComponent>();

                foreach (var component in this.Component)
                {
                    subComponents.Add(new StatusComponent() 
                    { 
                        Description = component.Description != null ? TextConverter.UnescapeInvalidXmlChars(component.Description) : string.Empty,
                        State = TypeConverter.ConvertEnum<StatusType>(component.State, StatusType.NotReady),
                        StateDescription = component.StateText != null ? TextConverter.UnescapeInvalidXmlChars(component.StateText) : string.Empty,
                        Type = component.Type != null ? component.Type : string.Empty
                    });
                }

                response.Component.SubComponents = subComponents.ToArray();
            }

            return response;
        }

        #endregion
    }
}
