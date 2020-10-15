using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using CareFusion.Mosaic.Converters.Wwks2.Messages.Hello;
using CareFusion.Mosaic.Converters.Wwks2.Messages.Input;
using CareFusion.Mosaic.Converters.Wwks2.Messages.KeepAlive;
using CareFusion.Mosaic.Converters.Wwks2.Messages.Output;
using CareFusion.Mosaic.Converters.Wwks2.Messages.Status;
using CareFusion.Mosaic.Converters.Wwks2.Messages.Stock;
using CareFusion.Mosaic.Converters.Wwks2.Messages.Task;
using CareFusion.Mosaic.Core.Logging;
using CareFusion.Mosaic.Interfaces.Components;
using CareFusion.Mosaic.Interfaces.Connectors;
using CareFusion.Mosaic.Interfaces.Converters;
using CareFusion.Mosaic.Interfaces.Types.Components;
using CareFusion.Mosaic.Converters.Wwks2.Messages.Configuration;
using CareFusion.Mosaic.Converters.Wwks2.Messages.ArticleInformation;
using CareFusion.Mosaic.Converters.Wwks2.Messages.Sales;
using MosaicDependency.Convertors.Wwks2.Messages.Unprocessed;

namespace CareFusion.Mosaic.Converters.Wwks2
{
    /// <summary>
    /// Class which implements a converter for the WWKS 2.0 protocol.
    /// </summary>
    public class WwksConverter : IConverter
    {
        #region Members

        /// <summary>
        /// Holds the converter configuration. 
        /// </summary>
        private WwksConverterConfiguration _configuration = null;

        /// <summary>
        /// Flag whether the converter related XML serializers are initialized.
        /// </summary>
        protected static bool _serializerInitialized = false;

        #endregion

        #region Properties

        /// <summary>
        /// Gets the indentifier of the converter which has been passed to the Initialize method.
        /// </summary>
        public virtual int ID
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets an informational English description of the converter (e.g. "WWKS 1.14 Converter").
        /// </summary>
        public virtual string Description
        {
            get { return "WWKS 2.0 Converter"; }
        }

        #endregion

        /// <summary>
        /// Gets an object with public properties which defines a configuration for this type of converter.
        /// </summary>
        /// <returns>
        /// Appropriate configuration object for this type of converter.
        /// </returns>
        public IComponentConfiguration GetConfigurationObject()
        {
            return new WwksConverterConfiguration();
        }

        /// <summary>
        /// Initializes the connector with the specified configuration.
        /// </summary>
        /// <param name="converterID">The identifier of the converter.</param>
        /// <param name="configurationValueList">The list of configuration values, assigned to this converter.</param>
        /// <returns>
        ///   <c>true</c> if initialization was successful; <c>false</c> otherwise.
        /// </returns>
        public bool Initialize(int converterID, List<ConfigurationValue> configurationValueList)
        {
            this.ID = converterID;
            _configuration = new WwksConverterConfiguration(configurationValueList);
            return InitializeXmlSerializer();
        }

        /// <summary>
        /// Creates a new converter stream instance which is bound to the specified connection.
        /// </summary>
        /// <param name="connection">The connection which is used by the converter to read and write messages.</param>
        /// <returns>
        /// Newly created converter stream instance if successful; <c>null</c> otherwise.
        /// </returns>
        public IConverterStream CreateStream(IConnection connection)
        {
            WwksConverterStream stream = new WwksConverterStream(this.ID, connection, _configuration);

            if (stream.Initialize() == false)
            {
                stream.Dispose();
                return null;
            }

            this.Trace("Successfully created WWKS 2.0 converter for connection '{0}' of connector '{1}' to '{2}'.",
                       connection.ID, connection.ConnectorID, connection.EndPoint);

            return stream;
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            // nothing to dispose
        }

        /// <summary>
        /// Initializes the XML serializer for the WWKS 114 messages.
        /// </summary>
        /// <returns><c>true</c> if initialization was successful; <c>false</c> otherwise.</returns>
        protected virtual bool InitializeXmlSerializer()
        {
            if (_serializerInitialized)
            {
                return true;
            }

            this.Trace("Initializing WWKS 2.0 XmlSerializer ...");

            try
            {
                XmlSerializer hreq = new XmlSerializer(typeof(HelloRequestEnvelope));
                XmlSerializer hresp = new XmlSerializer(typeof(HelloResponseEnvelope));
                XmlSerializer imsg = new XmlSerializer(typeof(InputMessageEnvelope));
                XmlSerializer ireq = new XmlSerializer(typeof(InputRequestEnvelope));
                XmlSerializer iresp = new XmlSerializer(typeof(InputResponseEnvelope));
                XmlSerializer iireq = new XmlSerializer(typeof(InitiateInputRequestEnvelope));
                XmlSerializer iires = new XmlSerializer(typeof(InitiateInputResponseEnvelope));
                XmlSerializer iimsg = new XmlSerializer(typeof(InitiateInputMessageEnvelope));
                XmlSerializer omsg = new XmlSerializer(typeof(OutputMessageEnvelope));
                XmlSerializer omsg2 = new XmlSerializer(typeof(OutputMessageSmallSetEnvelope));
                XmlSerializer oreq = new XmlSerializer(typeof(OutputRequestEnvelope));
                XmlSerializer oreq2 = new XmlSerializer(typeof(OutputRequestSmallSetEnvelope));
                XmlSerializer oresp = new XmlSerializer(typeof(OutputResponseEnvelope));
                XmlSerializer oresp2 = new XmlSerializer(typeof(OutputResponseSmallSetEnvelope));
                XmlSerializer sreq = new XmlSerializer(typeof(StatusRequestEnvelope));
                XmlSerializer sresp = new XmlSerializer(typeof(StatusResponseEnvelope));               
                XmlSerializer sireq = new XmlSerializer(typeof(StockInfoRequestEnvelope));
                XmlSerializer siresp = new XmlSerializer(typeof(StockInfoResponseEnvelope));
                XmlSerializer siresp2 = new XmlSerializer(typeof(StockInfoResponseSmallSetEnvelope));
                XmlSerializer simsg = new XmlSerializer(typeof(StockInfoMessageEnvelope));
                XmlSerializer simsg2 = new XmlSerializer(typeof(StockInfoMessageSmallSetEnvelope));
                XmlSerializer mareq = new XmlSerializer(typeof(ArticleMasterSetRequestEnvelope));
                XmlSerializer mareq2 = new XmlSerializer(typeof(ArticleMasterSetRequestSmallSetEnvelope));
                XmlSerializer maresp = new XmlSerializer(typeof(ArticleMasterSetResponseEnvelope));
                XmlSerializer sdreq = new XmlSerializer(typeof(StockDeliverySetRequestEnvelope));
                XmlSerializer sdreq2 = new XmlSerializer(typeof(StockDeliverySetRequestSmallSetEnvelope));
                XmlSerializer sdresp = new XmlSerializer(typeof(StockDeliverySetResponseEnvelope));
                XmlSerializer tcreq = new XmlSerializer(typeof(TaskCancelRequestEnvelope));
                XmlSerializer tcresp = new XmlSerializer(typeof(TaskCancelResponseEnvelope));
                XmlSerializer tireq = new XmlSerializer(typeof(TaskInfoRequestEnvelope));
                XmlSerializer tiresp = new XmlSerializer(typeof(TaskInfoResponseEnvelope));
                XmlSerializer kareq = new XmlSerializer(typeof(KeepAliveRequestEnvelope));
                XmlSerializer karesp = new XmlSerializer(typeof(KeepAliveResponseEnvelope));
                XmlSerializer confreq = new XmlSerializer(typeof(ConfigurationGetRequestEnvelope));
                XmlSerializer confresp = new XmlSerializer(typeof(ConfigurationGetResponseEnvelope));
                XmlSerializer aireq = new XmlSerializer(typeof(ArticleInfoRequestEnvelope));
                XmlSerializer aires = new XmlSerializer(typeof(ArticleInfoResponseEnvelope));
                XmlSerializer apreq = new XmlSerializer(typeof(ArticlePriceRequestEnvelope));
                XmlSerializer apres = new XmlSerializer(typeof(ArticlePriceResponseEnvelope));
                XmlSerializer asmes = new XmlSerializer(typeof(ArticleSelectedMessageEnvelope));
                XmlSerializer screq = new XmlSerializer(typeof(ShoppingCartRequestEnvelope));
                XmlSerializer scres = new XmlSerializer(typeof(ShoppingCartResponseEnvelope));
                XmlSerializer scumes = new XmlSerializer(typeof(ShoppingCartUpdateMessageEnvelope));
                XmlSerializer scureq = new XmlSerializer(typeof(ShoppingCartUpdateRequestEnvelope));
                XmlSerializer scures = new XmlSerializer(typeof(ShoppingCartUpdateResponseEnvelope));
                XmlSerializer unprmsg = new XmlSerializer(typeof(UnprocessedMessageEnvelope));

                this.Trace("Initialization of WWKS 2.0 XmlSerializer finished.");
                _serializerInitialized = true;
                return true;
            }
            catch (Exception ex)
            {
                this.Error("Initializing WWKS 2.0 XmlSerializer failed!", ex);
            }

            return false;
        }
    }
}
