﻿using System.Xml.Serialization;
using CareFusion.Mosaic.Converters.Wwks2.Types;
using CareFusion.Mosaic.Interfaces.Converters;
using CareFusion.Mosaic.Interfaces.Messages;

namespace CareFusion.Mosaic.Converters.Wwks2.Messages.Stock
{
    /// <summary>
    /// Class which represents the WWKS 2.0 ArticleMasterSetResponse message envelope.
    /// </summary>
    [XmlType(TypeName = "WWKS")]
    public class ArticleMasterSetResponseEnvelope : EnvelopeBase, IMessageConversion
    {
        [XmlElement]
        public ArticleMasterSetResponse ArticleMasterSetResponse { get; set; }

        /// <summary>
        /// Translates this object instance into a Mosaic message.
        /// </summary>
        /// <param name="converterStream">The converter stream instance which request the message conversion.</param>
        /// <returns>
        /// The Mosaic message representation of this object.
        /// </returns>
        public MosaicMessage ToMosaicMessage(IConverterStream converterStream)
        {
            return this.ArticleMasterSetResponse.ToMosaicMessage(converterStream);
        }
    }

    /// <summary>
    /// Class which represents the WWKS 2.0 ArticleMasterSetResponse message.
    /// <see cref="https://portalrowa.carefusion.com/Unternehmen/Entwicklung/TechCom/Writing/P-010-044-B-I-388-DEU.docx" />
    /// </summary>
    public class ArticleMasterSetResponse : MessageBase, IMessageConversion
    {
        #region Properties

        [XmlElement]
        public SetResult SetResult { get; set; }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="ArticleMasterSetResponse"/> class.
        /// </summary>
        public ArticleMasterSetResponse()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArticleMasterSetResponse"/> class.
        /// </summary>
        /// <param name="message">The message to use for initialization.</param>
        public ArticleMasterSetResponse(MosaicMessage message)
        {
            var response = (Interfaces.Messages.Stock.ArticleMasterSetResponse)message;

            this.Id = response.ID;
            this.Source = response.Source;
            this.Destination = response.Destination;

            this.SetResult = new SetResult() 
            {
                Value = response.SetResult ? "Accepted" : "Rejected",
                Text = string.IsNullOrEmpty(response.SetResultText) ? null : TextConverter.EscapeInvalidXmlChars(response.SetResultText)
            };
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
            var response = new Interfaces.Messages.Stock.ArticleMasterSetResponse(converterStream);

            response.ID = this.Id;
            response.Source = this.Source;
            response.Destination = this.Destination;

            if (this.SetResult != null)
            {
                response.SetResult = (string.Compare(this.SetResult.Value, "Accepted") == 0);
                response.SetResultText = string.IsNullOrEmpty(this.SetResult.Text) ? string.Empty : TextConverter.UnescapeInvalidXmlChars(this.SetResult.Text);
            }

            return response;
        }
    }
}
