using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Timers;
using CareFusion.Mosaic.Converters.Wwks2.Messages.Hello;
using CareFusion.Mosaic.Converters.Wwks2.Messages.Input;
using CareFusion.Mosaic.Converters.Wwks2.Messages.KeepAlive;
using CareFusion.Mosaic.Converters.Wwks2.Messages.Output;
using CareFusion.Mosaic.Converters.Wwks2.Messages.Status;
using CareFusion.Mosaic.Converters.Wwks2.Messages.Stock;
using CareFusion.Mosaic.Converters.Wwks2.Messages.Task;
using CareFusion.Mosaic.Converters.Wwks2.Types;
using CareFusion.Mosaic.Core.Logging;
using CareFusion.Mosaic.Interfaces.Connectors;
using CareFusion.Mosaic.Interfaces.Converters;
using CareFusion.Mosaic.Interfaces.Messages;
using CareFusion.Mosaic.Interfaces.Messages.Output;
using CareFusion.Mosaic.Interfaces.Messages.Print;
using CareFusion.Mosaic.Interfaces.Types.Output;
using CareFusion.Mosaic.Converters.Wwks2.Messages.Configuration;
using CareFusion.Mosaic.Converters.Wwks2.Messages.ArticleInformation;
using CareFusion.Mosaic.Converters.Wwks2.Messages.Sales;
using MosaicDependency.Convertors.Wwks2.Messages.Unprocessed;

using StorageSystem.Versioning;

namespace CareFusion.Mosaic.Converters.Wwks2
{
    /// <summary>
    /// Class which implements a converter stream for the WWKS 2.0 protocol.
    /// </summary>
    public class WwksConverterStream : IConverterStream
    {
        #region Constants

        /// <summary>
        /// List of capabilities which are supported by Mosaic.
        /// </summary>
        private static Capability[] MosaicCapabilities = new Capability[] 
        { 
            new Capability() { Name="KeepAlive" },
            new Capability() { Name="Status" },
            new Capability() { Name="InitiateInput" },
            new Capability() { Name="Input" },
            new Capability() { Name="ArticleMaster" },
            new Capability() { Name="StockDelivery" },
            new Capability() { Name="StockInfo" },
            new Capability() { Name="Output" },
            new Capability() { Name="TaskInfo" },
            new Capability() { Name="TaskCancel" },
            new Capability() { Name="Configuration" },
            new Capability() { Name="StockLocationInfo" },
            new Capability() { Name="ArticleInfo" },
            new Capability() { Name="ArticlePrice" },
            new Capability() { Name="ShoppingCart" }
        };

        #endregion

        #region Members

        /// <summary>
        /// Holds the identifier of the according converter.
        /// </summary>
        private int _converterID = 0;

        /// <summary>
        /// Subscriber identifier of the connected end point.
        /// </summary>
        private int _destinationID = 0;

        /// <summary>
        /// Tenant identifier of the connected end point. 
        /// </summary>
        private string _tenantID = string.Empty;

        /// <summary>
        /// Holds the reference to the underlying connection object.
        /// </summary>
        private IConnection _connection = null;

        /// <summary>
        /// Holds the reference to the converter configuration object.
        /// </summary>
        private WwksConverterConfiguration _configuration = null;

        /// <summary>
        /// Reference to the XML object stream to use for reading and writing messages.
        /// </summary>
        private XmlObjectStream _objectStream = null;

        /// <summary>
        /// List of messages which are supported by the connected end point.
        /// </summary>
        private List<MessageType> _supportedMessageList = new List<MessageType>();

        /// <summary>
        /// The timer which is used to send WWKS 2.0 keep alives.
        /// </summary>
        private Timer _keepAliveTimer = null;

        /// <summary>
        /// Holds the tickcount of the last successfully sent keep alive.
        /// </summary>
        private int _lastKeepAlive = 0;

        /// <summary>
        /// The keep alive identifier to use.
        /// </summary>
        private int _keepAliveID = 0;

        #endregion

        #region Properties

        /// <summary>
        /// Gets the indentifier of the converter that created the converter stream.
        /// </summary>
        public virtual int ConverterID
        {
            get { return _converterID; }
        }

        /// <summary>
        /// Gets an arbitary destination descriptor which depends on the specific converter implementation.
        /// </summary>
        public virtual string Destination
        {
            get { return _destinationID.ToString(); }
        }

        /// <summary>
        /// Gets the tenant identifier which is assigned to this converter stream.
        /// </summary>
        public virtual string TenantID
        {
            get { return _tenantID; }
        }

        /// <summary>
        /// Gets the instance of the underlying connection used by the converter stream.
        /// </summary>
        public virtual IConnection Connection
        {
            get { return _connection; }
        }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="WwksConverterStream"/> class.
        /// </summary>
        /// <param name="converterID">The identifier of the according converter.</param>
        /// <param name="connection">The underlying connection to use.</param>
        /// <param name="configuration">The converter configuration to use.</param>
        public WwksConverterStream(int converterID, IConnection connection, WwksConverterConfiguration configuration)
        {
            if (connection == null)
            {
                throw new ArgumentException("Invalid connection specified.");
            }

            if (configuration == null)
            {
                throw new ArgumentException("Invalid configuration specified.");
            }

            _converterID = converterID;
            _connection = connection;
            _configuration = configuration;

            _objectStream = new XmlObjectStream(_connection.ConnectionStream,
                                                "WWKS",
                                                _configuration.EnableMessageTrace ? connection.Category.ToString() : null,
                                                _configuration.EnableMessageTrace ? connection.EndPoint : null);

            // add WWKS message set
            _objectStream.AddSupportedType(typeof(KeepAliveRequestEnvelope), typeof(KeepAliveRequest).Name);
            _objectStream.AddSupportedType(typeof(KeepAliveResponseEnvelope), typeof(KeepAliveResponse).Name);
            _objectStream.AddSupportedType(typeof(HelloRequestEnvelope), typeof(HelloRequest).Name);
            _objectStream.AddSupportedType(typeof(HelloResponseEnvelope), typeof(HelloResponse).Name);
            _objectStream.AddSupportedType(typeof(InputMessageEnvelope), typeof(InputMessage).Name);
            _objectStream.AddSupportedType(typeof(InputRequestEnvelope), typeof(InputRequest).Name);
            _objectStream.AddSupportedType(typeof(InputResponseEnvelope), typeof(InputResponse).Name);            
            _objectStream.AddSupportedType(typeof(StatusRequestEnvelope), typeof(StatusRequest).Name);
            _objectStream.AddSupportedType(typeof(StatusResponseEnvelope), typeof(StatusResponse).Name);
            _objectStream.AddSupportedType(typeof(StockInfoRequestEnvelope), typeof(StockInfoRequest).Name);
            _objectStream.AddSupportedType(typeof(TaskCancelRequestEnvelope), typeof(TaskCancelRequest).Name);
            _objectStream.AddSupportedType(typeof(TaskCancelResponseEnvelope), typeof(TaskCancelResponse).Name);
            _objectStream.AddSupportedType(typeof(TaskInfoRequestEnvelope), typeof(TaskInfoRequest).Name);
            _objectStream.AddSupportedType(typeof(TaskInfoResponseEnvelope), typeof(TaskInfoResponse).Name);
            _objectStream.AddSupportedType(typeof(ArticleMasterSetResponseEnvelope), typeof(ArticleMasterSetResponse).Name);
            _objectStream.AddSupportedType(typeof(StockDeliverySetResponseEnvelope), typeof(StockDeliverySetResponse).Name);
            _objectStream.AddSupportedType(typeof(UnprocessedMessageEnvelope), typeof(UnprocessedMessage).Name);
            
            if (_configuration.SmallMessageSet)
            {
                _objectStream.AddSupportedType(typeof(OutputRequestSmallSetEnvelope), typeof(OutputRequest).Name);
                _objectStream.AddSupportedType(typeof(OutputResponseSmallSetEnvelope), typeof(OutputResponse).Name);
                _objectStream.AddSupportedType(typeof(OutputMessageSmallSetEnvelope), typeof(OutputMessage).Name);
                _objectStream.AddSupportedType(typeof(StockInfoResponseSmallSetEnvelope), typeof(StockInfoResponse).Name);
                _objectStream.AddSupportedType(typeof(StockInfoMessageSmallSetEnvelope), typeof(StockInfoMessage).Name);
                _objectStream.AddSupportedType(typeof(ArticleMasterSetRequestSmallSetEnvelope), typeof(ArticleMasterSetRequest).Name);
                _objectStream.AddSupportedType(typeof(StockDeliverySetRequestSmallSetEnvelope), typeof(StockDeliverySetRequest).Name);
            }
            else
            {
                _objectStream.AddSupportedType(typeof(OutputRequestEnvelope), typeof(OutputRequest).Name);
                _objectStream.AddSupportedType(typeof(OutputResponseEnvelope), typeof(OutputResponse).Name);
                _objectStream.AddSupportedType(typeof(OutputMessageEnvelope), typeof(OutputMessage).Name);
                _objectStream.AddSupportedType(typeof(StockInfoResponseEnvelope), typeof(StockInfoResponse).Name);
                _objectStream.AddSupportedType(typeof(StockInfoMessageEnvelope), typeof(StockInfoMessage).Name);
                _objectStream.AddSupportedType(typeof(ArticleMasterSetRequestEnvelope), typeof(ArticleMasterSetRequest).Name);
                _objectStream.AddSupportedType(typeof(StockDeliverySetRequestEnvelope), typeof(StockDeliverySetRequest).Name);
                _objectStream.AddSupportedType(typeof(InitiateInputMessageEnvelope), typeof(InitiateInputMessage).Name);
                _objectStream.AddSupportedType(typeof(InitiateInputRequestEnvelope), typeof(InitiateInputRequest).Name);
                _objectStream.AddSupportedType(typeof(InitiateInputResponseEnvelope), typeof(InitiateInputResponse).Name);
                _objectStream.AddSupportedType(typeof(ConfigurationGetRequestEnvelope), typeof(ConfigurationGetRequest).Name);
                _objectStream.AddSupportedType(typeof(ConfigurationGetResponseEnvelope), typeof(ConfigurationGetResponse).Name);
                _objectStream.AddSupportedType(typeof(StockLocationInfoRequestEnvelope), typeof(StockLocationInfoRequest).Name);
                _objectStream.AddSupportedType(typeof(StockLocationInfoResponseEnvelope), typeof(StockLocationInfoResponse).Name);
            }

            // digital shelf
            _objectStream.AddSupportedType(typeof(ArticleInfoRequestEnvelope), typeof(ArticleInfoRequest).Name);
            _objectStream.AddSupportedType(typeof(ArticleInfoResponseEnvelope), typeof(ArticleInfoResponse).Name);
            _objectStream.AddSupportedType(typeof(ArticlePriceRequestEnvelope), typeof(ArticlePriceRequest).Name);
            _objectStream.AddSupportedType(typeof(ArticlePriceResponseEnvelope), typeof(ArticlePriceResponse).Name);

            _objectStream.AddSupportedType(typeof(ArticleSelectedMessageEnvelope), typeof(ArticleSelectedMessage).Name);
            _objectStream.AddSupportedType(typeof(ShoppingCartRequestEnvelope), typeof(ShoppingCartRequest).Name);
            _objectStream.AddSupportedType(typeof(ShoppingCartResponseEnvelope), typeof(ShoppingCartResponse).Name);
            _objectStream.AddSupportedType(typeof(ShoppingCartUpdateMessageEnvelope), typeof(ShoppingCartUpdateMessage).Name);
            _objectStream.AddSupportedType(typeof(ShoppingCartUpdateRequestEnvelope), typeof(ShoppingCartUpdateRequest).Name);
            _objectStream.AddSupportedType(typeof(ShoppingCartUpdateResponseEnvelope), typeof(ShoppingCartUpdateResponse).Name);

            if (configuration.EnableKeepAlive)
            {
                _keepAliveTimer = new Timer();
                _keepAliveTimer.Elapsed += OnKeepAliveTimerElapsed;
                _keepAliveTimer.Interval = (configuration.KeepAliveInterval > 0) ? configuration.KeepAliveInterval * 1000 : 1000;
                _keepAliveTimer.Enabled = false;
            }
        }

        /// <summary>
        /// Initializes this converter stream by processing the WWKS handshake.
        /// </summary>
        /// <returns><c>true</c> if initialization was successful; <c>false</c> otherwise.</returns>
        public virtual bool Initialize()
        {
            bool handshakeResult = false;

            try
            {
                if (_connection.IsConnected == false)
                {
                    this.Error("The specified connection '{0}' is inactive.", _connection.ID);
                    return false;
                }

                switch (_configuration.Type)
                {
                    case Types.SubscriberType.IMS: handshakeResult = ProcessImsProtocolHandshake(); break;
                    case Types.SubscriberType.Robot: handshakeResult = ProcessRobotProtocolHandshake(); break;
                }
            }
            catch (Exception ex)
            {
                this.Error("Initializing WWKS 2.0 converter failed.", ex);
            }

            if (handshakeResult)
            {
                if (_keepAliveTimer != null)
                {
                    _keepAliveTimer.Start();
                }
            }

            return handshakeResult;
        }

        /// <summary>
        /// Reads the next Mosaic message from the underlying connection and returns it. This method will block until a new Mosaic message
        /// has been read, the converter stream has been cancelled or an error occurred.
        /// </summary>
        /// <returns>
        /// Read Mosaic message if successful; <c>null</c> otherwise.
        /// </returns>
        public MosaicMessage Read()
        {
            while (true)
            {
                IMessageConversion message = null;

                while (message == null)
                {
                    object readMessage = _objectStream.Read();

                    if (readMessage == null)
                    {
                        return null;
                    }

                    if (readMessage.GetType() == typeof(KeepAliveRequestEnvelope))
                    {
                        var request = (KeepAliveRequestEnvelope)readMessage;
                        var response = new KeepAliveResponseEnvelope()
                        {
                            KeepAliveResponse = new KeepAliveResponse()
                            {
                                Id = request.KeepAliveRequest.Id,
                                Source = _configuration.SubscriberID,
                                Destination = request.KeepAliveRequest.Source
                            }
                        };

                        if (_objectStream.Write(response) == false)
                        {
                            this.Error("Sending keep alive response with ID '{0}' failed.", request.KeepAliveRequest.Id);
                            return null;
                        }

                        continue;
                    }

                    if (readMessage.GetType() == typeof(KeepAliveResponseEnvelope))
                    {
                        var response = (KeepAliveResponseEnvelope)readMessage;

                        if (TypeConverter.ConvertInt(response.KeepAliveResponse.Id) == _keepAliveID)
                        {
                            System.Threading.Interlocked.Exchange(ref _lastKeepAlive, 0);
                            continue;
                        }                        

                        this.Error("Received orphan keep alive response with ID '{0}' but expected ID '{1}'.",
                                    response.KeepAliveResponse.Id, _keepAliveID);
                        return null;
                    }

                    message = readMessage as IMessageConversion;

                    if (message == null)
                    {
                        this.Error("Ignored unsupported message of type '{0}'.", readMessage.GetType().FullName);
                        continue;
                    }
                }

                var mosaicMessage = message.ToMosaicMessage(this);

                if (mosaicMessage != null)
                {
                    mosaicMessage.TenantID = _tenantID;
                }

                return mosaicMessage;
            }
        }

        /// <summary>
        /// Writes the specified Mosaic message to the underlying connection. This method will block until the Mosaic message
        /// has been written, the converter has been cancelled or an error occurred.
        /// </summary>
        /// <param name="message">The Mosaic message to write.</param>
        /// <returns>
        ///   <c>true</c>if successful; <c>false</c> otherwise.
        /// </returns>
        public bool Write(MosaicMessage message)
        {
            if (message.Source == 0)
            {
                message.Source = _configuration.SubscriberID;
            }

            if (message.Destination == 0)
            {
                message.Destination = _destinationID;
            }

            if (string.IsNullOrEmpty(message.ID))
                message.ID = "1";

            int msgId = 0;

            if ((int.TryParse(message.ID, out msgId)) &&
                (msgId <= 0))
            {
                message.ID = "1";
            }

            if (SkipMessage(message))
            {
                return true;
            }

            if ((_supportedMessageList.Count > 0) && 
                (_supportedMessageList.Contains(message.Type) == false))
            {
                this.Warning("According to the capabilities of the remote end point, the message '{0}' is not supported.", 
                             message.Type.ToString());
                return false;
            }

            object messageToWrite = ConvertMosaicMessage(message);

            if (messageToWrite == null)
            {
                this.Error("Conversion of message '{0}' is not supported.", message.Type.ToString());
                return false;
            }

            return _objectStream.Write(messageToWrite);
        }

        /// <summary>
        /// Cancels any pending operations like reading or writing messages.
        /// This method will block and not return until all outstanding operations have finished.
        /// </summary>
        public void Cancel()
        {
            _connection.Cancel();
            _objectStream.Cancel();

            if (_keepAliveTimer != null)
            {
                _keepAliveTimer.Stop();
            }
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            _objectStream.Dispose();
            _connection.Dispose();

            if (_keepAliveTimer != null)
            {
                _keepAliveTimer.Stop();
                _keepAliveTimer.Dispose();
                _keepAliveTimer = null;
            }
        }

        /// <summary>
        /// Processes the WWKS 2.0 protocol handshake with IMS role.
        /// </summary>
        /// <returns><c>true</c> if protocol handshake finished successfully;<c>false</c> otherwise.</returns>
        private bool ProcessImsProtocolHandshake()
        {
            this.Info("Converter '{0}' is running in IMS mode.", _converterID);

            HelloRequestEnvelope request = new HelloRequestEnvelope()
            {
                HelloRequest = new HelloRequest()
                {
                    Id = 1000,                    
                    Subscriber = new Types.Subscriber()
                    {
                        Id = _configuration.SubscriberID,
                        Type = Types.SubscriberType.IMS,
                        Manufacturer = VersionInfoProvider.Company,
                        ProductInfo = VersionInfoProvider.Product,
                        VersionInfo = VersionInfoProvider.FileVersion,
                        Capability = MosaicCapabilities
                    }                    
                }
            };

            if (_objectStream.Write(request) == false)
            {
                this.Error("Sending hello request failed!");
                return false;
            }

            object response = _objectStream.Read(_configuration.HandshakeTimeout);
            _objectStream.EnableMessageEcho = _configuration.EnableMessageEcho;

            if (response == null)
            {
                this.Error("Wating for hello response failed!");
                return false;
            }

            if (response.GetType() != typeof(HelloResponseEnvelope))
            {
                this.Error("Received unexpected message of type '{0}'.", response.GetType().Name);
                return false;
            }

            HelloResponseEnvelope resp = (HelloResponseEnvelope)response;
            if (resp.HelloResponse.Subscriber == null)
            {
                this.Error("Received hello response with invalid subscriber information.");
                return false;
            }

            if (resp.HelloResponse.Id != request.HelloRequest.Id)
            {
                this.Error("Received hello response with invalid identifier.");
                return false;
            }

            this.Info("WWKS 2.0 protocol handshake successfully finished -> ID='{0}' Type='{1}' " +
                      "Manufacturer='{2}' ProductInfo='{3}' VersionInfo='{4}'.",
                      resp.HelloResponse.Subscriber.Id, resp.HelloResponse.Subscriber.Type.ToString(),
                      string.IsNullOrEmpty(resp.HelloResponse.Subscriber.Manufacturer) ? string.Empty : resp.HelloResponse.Subscriber.Manufacturer,
                      string.IsNullOrEmpty(resp.HelloResponse.Subscriber.ProductInfo) ? string.Empty : resp.HelloResponse.Subscriber.ProductInfo,
                      string.IsNullOrEmpty(resp.HelloResponse.Subscriber.VersionInfo) ? string.Empty : resp.HelloResponse.Subscriber.VersionInfo);

            UpdateSupportedMessageList(resp.HelloResponse.Subscriber.Capability);
            _destinationID = resp.HelloResponse.Subscriber.Id;
            return true;
        }

        /// <summary>
        /// Processes the WWKS 2.0 protocol handshake with Robot role.
        /// </summary>
        /// <returns><c>true</c> if protocol handshake finished successfully;<c>false</c> otherwise.</returns>
        private bool ProcessRobotProtocolHandshake()
        {
            this.Info("Converter '{0}' is running in Robot mode.", _converterID);

            object request = _objectStream.Read(_configuration.HandshakeTimeout);
            _objectStream.EnableMessageEcho = _configuration.EnableMessageEcho;

            if (request == null)
            {
                this.Error("Waiting for hello request failed!");
                return false;
            }

            if (request.GetType() != typeof(HelloRequestEnvelope))
            {
                this.Error("Received unexpected message of type '{0}'.", request.GetType().Name);
                return false;
            }

            HelloRequestEnvelope req = (HelloRequestEnvelope)request;
            if (req.HelloRequest.Subscriber == null)
            {
                this.Error("Received hello request with invalid subscriber information.");
                return false;
            }

            HelloResponseEnvelope response = new HelloResponseEnvelope()
            {
                HelloResponse = new HelloResponse()
                {
                    Id = req.HelloRequest.Id,
                    Subscriber = new Types.Subscriber()
                    {
                        Id = _configuration.SubscriberID,
                        Type = Types.SubscriberType.Robot,
                        Manufacturer = VersionInfoProvider.Company,
                        ProductInfo = VersionInfoProvider.Product,
                        VersionInfo = VersionInfoProvider.FileVersion,
                        Capability = MosaicCapabilities
                    }                    
                }
            };

            if (_objectStream.Write(response) == false)
            {
                this.Error("Sending hello response failed!");
                return false;
            }

            this.Info("WWKS 2.0 protocol handshake successfully finished -> ID='{0}' Type='{1}' " +
                      "Manufacturer='{2}' ProductInfo='{3}' VersionInfo='{4}'.",
                      req.HelloRequest.Subscriber.Id, req.HelloRequest.Subscriber.Type.ToString(),
                      string.IsNullOrEmpty(req.HelloRequest.Subscriber.Manufacturer) ? string.Empty : req.HelloRequest.Subscriber.Manufacturer,
                      string.IsNullOrEmpty(req.HelloRequest.Subscriber.ProductInfo) ? string.Empty : req.HelloRequest.Subscriber.ProductInfo,
                      string.IsNullOrEmpty(req.HelloRequest.Subscriber.VersionInfo) ? string.Empty : req.HelloRequest.Subscriber.VersionInfo);
            
            UpdateSupportedMessageList(req.HelloRequest.Subscriber.Capability);
            _destinationID = req.HelloRequest.Subscriber.Id;
            _tenantID = string.IsNullOrEmpty(req.HelloRequest.Subscriber.TenantId) ? string.Empty : req.HelloRequest.Subscriber.TenantId;
            return true;
        }

        /// <summary>
        /// Updates the list of messages which are supported by the connected end point. 
        /// </summary>
        /// <param name="capabilityList">List of capabilities of the end point.</param>
        private void UpdateSupportedMessageList(Capability[] capabilityList)
        {
            _supportedMessageList.Clear();

            if ((capabilityList == null) || (capabilityList.Length == 0))
            {
                return;
            }

            bool isKeepAliveSupported = false;

            foreach (var capability in capabilityList)
            {
                if (string.IsNullOrEmpty(capability.Name))
                {
                    continue;
                }

                switch (capability.Name)
                {
                    case "KeepAlive":
                        isKeepAliveSupported = true;
                        break;

                    case "Status":
                        _supportedMessageList.Add(MessageType.StatusRequest);
                        _supportedMessageList.Add(MessageType.StatusResponse);
                        _supportedMessageList.Add(MessageType.StatusMessage);
                        break;

                    case "Input":
                        _supportedMessageList.Add(MessageType.StockInputRequest);
                        _supportedMessageList.Add(MessageType.StockInputResponse);
                        _supportedMessageList.Add(MessageType.StockInputMessage);
                        break;

                    case "InitiateInput":
                        _supportedMessageList.Add(MessageType.InitiateStockInputRequest);
                        _supportedMessageList.Add(MessageType.InitiateStockInputResponse);
                        _supportedMessageList.Add(MessageType.InitiateStockInputMessage);
                        break;

                    case "ArticleMaster":
                        _supportedMessageList.Add(MessageType.ArticleMasterSetRequest);
                        _supportedMessageList.Add(MessageType.ArticleMasterSetResponse);
                        break;

                    case "StockDelivery":
                        _supportedMessageList.Add(MessageType.StockDeliverySetRequest);
                        _supportedMessageList.Add(MessageType.StockDeliverySetResponse);
                        break;

                    case "StockInfo":
                        _supportedMessageList.Add(MessageType.StockInfoRequest);
                        _supportedMessageList.Add(MessageType.StockInfoResponse);
                        _supportedMessageList.Add(MessageType.StockInfoMessage);
                        break;

                    case "Output":
                        _supportedMessageList.Add(MessageType.StockOutputRequest);
                        _supportedMessageList.Add(MessageType.StockOutputResponse);
                        _supportedMessageList.Add(MessageType.StockOutputMessage);
                        break;

                    case "TaskInfo":
                        _supportedMessageList.Add(MessageType.TaskInfoRequest);
                        _supportedMessageList.Add(MessageType.TaskInfoResponse);
                        break;

                    case "TaskCancel":
                        _supportedMessageList.Add(MessageType.TaskCancelRequest);
                        _supportedMessageList.Add(MessageType.TaskCancelResponse);
                        break;

                    case "Configuration":
                        _supportedMessageList.Add(MessageType.ConfigurationGetRequest);
                        _supportedMessageList.Add(MessageType.ConfigurationGetResponse);
                        break;

                    case "StockLocationInfo":
                        _supportedMessageList.Add(MessageType.StockLocationInfoRequest);
                        _supportedMessageList.Add(MessageType.StockLocationInfoResponse);
                        break;

                    case "ArticleInfo":
                        _supportedMessageList.Add(MessageType.ArticleInformationRequest);
                        _supportedMessageList.Add(MessageType.ArticleInformationResponse);
                        break;

                    case "ArticlePrice":
                        _supportedMessageList.Add(MessageType.ArticlePriceRequest);
                        _supportedMessageList.Add(MessageType.ArticlePriceResponse);
                        break;

                    case "ShoppingCart":
                        _supportedMessageList.Add(MessageType.ArticleSelectedMessage);
                        _supportedMessageList.Add(MessageType.ShoppingCartRequest);
                        _supportedMessageList.Add(MessageType.ShoppingCartResponse);
                        _supportedMessageList.Add(MessageType.ShoppingCartUpdateRequest);
                        _supportedMessageList.Add(MessageType.ShoppingCartUpdateResponse);
                        _supportedMessageList.Add(MessageType.ShoppingCartUpdateMessage);
                        break;

                    case "Unprocessed":
                        _supportedMessageList.Add(MessageType.UnprocessedMessage);
                        break;
                }
            }

            if (isKeepAliveSupported == false)
            {
                if (_keepAliveTimer != null)
                {
                    _keepAliveTimer.Elapsed -= OnKeepAliveTimerElapsed;
                    _keepAliveTimer.Dispose();
                    _keepAliveTimer = null;
                }               
            }
        }

        /// <summary>
        /// Converts the specified Mosaic message into a WWKS message.
        /// </summary>
        /// <param name="message">The mosaic message to convert.</param>
        /// <returns>
        /// Converted WWKS message if successful; <c>null</c> otherwise.
        /// </returns>
        private object ConvertMosaicMessage(MosaicMessage message)
        {
            switch (message.Type)
            {
                case MessageType.StockInputMessage: return new InputMessageEnvelope() { InputMessage = new InputMessage(message) };
                case MessageType.StockInputRequest: return new InputRequestEnvelope() { InputRequest = new InputRequest(message) };
                case MessageType.StockInputResponse: return new InputResponseEnvelope() { InputResponse = new InputResponse(message) };
                case MessageType.StatusRequest: return new StatusRequestEnvelope() { StatusRequest = new StatusRequest(message) };
                case MessageType.StatusResponse: return new StatusResponseEnvelope() { StatusResponse = new StatusResponse(message) };
                case MessageType.StockInfoRequest: return new StockInfoRequestEnvelope() { StockInfoRequest = new StockInfoRequest(message) };                
                case MessageType.TaskCancelRequest: return new TaskCancelRequestEnvelope() { TaskCancelRequest = new TaskCancelRequest(message) };
                case MessageType.TaskCancelResponse: return new TaskCancelResponseEnvelope() { TaskCancelResponse = new TaskCancelResponse(message) };
                case MessageType.TaskInfoRequest: return new TaskInfoRequestEnvelope() { TaskInfoRequest = new TaskInfoRequest(message) };
                case MessageType.TaskInfoResponse: return new TaskInfoResponseEnvelope() { TaskInfoResponse = new TaskInfoResponse(message) };
                case MessageType.ArticleMasterSetResponse: return new ArticleMasterSetResponseEnvelope() { ArticleMasterSetResponse = new ArticleMasterSetResponse(message) };
                case MessageType.StockDeliverySetResponse: return new StockDeliverySetResponseEnvelope() { StockDeliverySetResponse = new StockDeliverySetResponse(message) };
                case MessageType.InitiateStockInputRequest: return new InitiateInputRequestEnvelope() { InitiateInputRequest = new InitiateInputRequest(message) };
                case MessageType.InitiateStockInputResponse: return new InitiateInputResponseEnvelope() { InitiateInputResponse = new InitiateInputResponse(message) };
                case MessageType.InitiateStockInputMessage: return new InitiateInputMessageEnvelope() { InitiateInputMessage = new InitiateInputMessage(message) };
                case MessageType.ConfigurationGetRequest: return new ConfigurationGetRequestEnvelope() { ConfigurationGetRequest = new ConfigurationGetRequest(message) };
                case MessageType.ConfigurationGetResponse: return new ConfigurationGetResponseEnvelope() { ConfigurationGetResponse = new ConfigurationGetResponse(message) };
                case MessageType.StockLocationInfoRequest: return new StockLocationInfoRequestEnvelope() { StockLocationInfoRequest = new StockLocationInfoRequest(message) };
                case MessageType.StockLocationInfoResponse: return new StockLocationInfoResponseEnvelope() { StockLocationInfoResponse = new StockLocationInfoResponse(message) };
                case MessageType.UnprocessedMessage: return new UnprocessedMessageEnvelope() { UnprocessedMessage = new UnprocessedMessage(message) };
                case MessageType.ArticleInfoRequest: return new ArticleInfoRequestEnvelope() { ArticleInfoRequest = new ArticleInfoRequest(message) };
                case MessageType.ArticleInfoResponse: return new ArticleInfoResponseEnvelope() { ArticleInfoResponse = new ArticleInfoResponse(message) };

                case MessageType.StockInfoMessage:
                {
                    if (_configuration.SmallMessageSet)
                    {
                        return new StockInfoMessageSmallSetEnvelope() { StockInfoMessage = new StockInfoMessageSmallSet(message) };
                    }
                    else
                    {
                        return new StockInfoMessageEnvelope() { StockInfoMessage = new StockInfoMessage(message) };
                    }
                }

                case MessageType.StockInfoResponse: 
                {
                    if (_configuration.SmallMessageSet)
                    {
                        return new StockInfoResponseSmallSetEnvelope() { StockInfoResponse = new StockInfoResponseSmallSet(message) };
                    }
                    else
                    {
                        return new StockInfoResponseEnvelope() { StockInfoResponse = new StockInfoResponse(message) };
                    }
                }

                case MessageType.StockOutputRequest:
                {
                    if (_configuration.SmallMessageSet)
                    {
                        return new OutputRequestSmallSetEnvelope() { OutputRequest = new OutputRequestSmallSet(message) };
                    }
                    else
                    {
                        return new OutputRequestEnvelope() { OutputRequest = new OutputRequest(message) };
                    }
                }
                    
                case MessageType.StockOutputResponse:
                {
                    if (_configuration.SmallMessageSet)
                    {
                        return new OutputResponseSmallSetEnvelope() { OutputResponse = new OutputResponseSmallSet(message) };
                    }
                    else
                    {
                        return new OutputResponseEnvelope() { OutputResponse = new OutputResponse(message) };
                    }
                }

                case MessageType.StockOutputMessage:
                {
                    if (_configuration.SmallMessageSet)
                    {
                        return new OutputMessageSmallSetEnvelope() { OutputMessage = new OutputMessageSmallSet(message) };
                    }
                    else
                    {
                        return new OutputMessageEnvelope() { OutputMessage = new OutputMessage(message) };
                    }
                }

                case MessageType.ArticleMasterSetRequest:
                {
                    if (_configuration.SmallMessageSet)
                    {
                        return new ArticleMasterSetRequestSmallSetEnvelope() { ArticleMasterSetRequest = new ArticleMasterSetRequestSmallSet(message) };
                    }
                    else
                    {
                        return new ArticleMasterSetRequestEnvelope() { ArticleMasterSetRequest = new ArticleMasterSetRequest(message) };
                    }
                }

                case MessageType.StockDeliverySetRequest:
                {
                    if (_configuration.SmallMessageSet)
                    {
                        return new StockDeliverySetRequestSmallSetEnvelope() { StockDeliverySetRequest = new StockDeliverySetRequestSmallSet(message) };
                    }
                    else
                    {
                        return new StockDeliverySetRequestEnvelope() { StockDeliverySetRequest = new StockDeliverySetRequest(message) };
                    }
                }

                // digital shelf
                case MessageType.ArticleInformationRequest: return new ArticleInfoRequestEnvelope() { ArticleInfoRequest = new ArticleInfoRequest(message) };
                case MessageType.ArticleInformationResponse: return new ArticleInfoResponseEnvelope() { ArticleInfoResponse = new ArticleInfoResponse(message) };
                case MessageType.ArticlePriceRequest: return new ArticlePriceRequestEnvelope() { ArticlePriceRequest = new ArticlePriceRequest(message) };
                case MessageType.ArticlePriceResponse: return new ArticlePriceResponseEnvelope() { ArticlePriceResponse = new ArticlePriceResponse(message) };

                case MessageType.ArticleSelectedMessage: return new ArticleSelectedMessageEnvelope() { ArticleSelectedMessage = new ArticleSelectedMessage(message) };
                case MessageType.ShoppingCartRequest: return new ShoppingCartRequestEnvelope() { ShoppingCartRequest = new ShoppingCartRequest(message) };
                case MessageType.ShoppingCartResponse: return new ShoppingCartResponseEnvelope() { ShoppingCartResponse = new ShoppingCartResponse(message) };
                case MessageType.ShoppingCartUpdateMessage: return new ShoppingCartUpdateMessageEnvelope() { ShoppingCartUpdateMessage = new ShoppingCartUpdateMessage(message) };
                case MessageType.ShoppingCartUpdateRequest: return new ShoppingCartUpdateRequestEnvelope() { ShoppingCartUpdateRequest = new ShoppingCartUpdateRequest(message) };
                case MessageType.ShoppingCartUpdateResponse: return new ShoppingCartUpdateResponseEnvelope() { ShoppingCartUpdateResponse = new ShoppingCartUpdateResponse(message) };
            }

            return null;
        }

        /// <summary>
        /// Checks whether the specified message is a message which does not fit
        /// to the WWKS2 workflow and should be skipped.
        /// </summary>
        /// <param name="message">The message to check.</param>
        /// <returns><c>true</c> if the message does not fit the WWKS2 workflow and should be skipped.<c>false</c> otherwise.</returns>
        private bool SkipMessage(MosaicMessage message)
        {
            switch (message.Type)
            {
                case MessageType.StockOutputMessage:
                {
                    if (((StockOutputMessage)message).Order.State == StockOutputOrderState.InProcess)
                    {
                        return true;
                    }
                    break;
                }

                case MessageType.LabelPrintMessage:
                {
                    return true;
                }               

                case MessageType.LabelPrintRequest:
                {
                    var request = (LabelPrintRequest)message;
                    var response = new LabelPrintResponse();
                    response.AdoptHeader(request);
                    response.SourceName = "Mosaic";
                    response.OrderNumber = request.OrderNumber;
                    response.ArticleCode = request.ArticleCode;
                    response.LabelId = request.LabelId;
                    response.TemplateId = request.TemplateId;
                    response.PrintLabel = false;
                    request.ConverterStream.Write(response);
                    return true;
                }

                case MessageType.StockInfoMessage:
                {
                    if (((Interfaces.Messages.Stock.StockInfoMessage)message).Packs.Count == 0)
                    {
                        return true;
                    }

                    if ((((Interfaces.Messages.Stock.StockInfoMessage)message).StockInfoType != Interfaces.Messages.Stock.StockInfoType.StockUpdate) &&
                        (((Interfaces.Messages.Stock.StockInfoMessage)message).StockInfoType != Interfaces.Messages.Stock.StockInfoType.PackInput))
                    {
                        return true;
                    }

                    // Singapur workaround -> StockInfoMessage signals pack input only
                    if ((_configuration.SmallMessageSet) && 
                        ((((Interfaces.Messages.Stock.StockInfoMessage)message).StockInfoType == Interfaces.Messages.Stock.StockInfoType.StockUpdate)))
                    {
                        return true;
                    }

                    break;
                }
            }

            return false;
        }

        /// <summary>
        /// Is called when the keep alive timer elapsed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="ElapsedEventArgs"/> instance containing the event data.</param>
        private void OnKeepAliveTimerElapsed(object sender, ElapsedEventArgs e)
        {
            if (_lastKeepAlive == 0)
            {
                if (System.Threading.Interlocked.Increment(ref _keepAliveID) > 100000)
                {
                    System.Threading.Interlocked.Exchange(ref _keepAliveID, 1);
                }

                var message = new KeepAliveRequestEnvelope() { KeepAliveRequest = new KeepAliveRequest() };
                message.KeepAliveRequest.Id = _keepAliveID.ToString();
                message.KeepAliveRequest.Source = _configuration.SubscriberID;
                message.KeepAliveRequest.Destination = _destinationID;

                System.Threading.Interlocked.Exchange(ref _lastKeepAlive, Environment.TickCount);

                if (_objectStream.Write(message) == false)
                {
                    this.Error("Sending keep alive request with ID '{0}' failed -> cancel connection to enforce reconnect.", _keepAliveID);
                    this.Cancel();
                    return;
                }
            }
            else
            {
                int tickNow = Environment.TickCount;

                if (tickNow > _lastKeepAlive)
                {
                    if ((tickNow - _lastKeepAlive) >= _configuration.KeepAliveTimeOut * 1000)
                    {
                        System.Threading.Interlocked.Exchange(ref _lastKeepAlive, 0);
                        this.Error("Waiting for keep alive response with ID '{0}' timed out -> cancel connection to enforce reconnect.", _keepAliveID);
                        this.Cancel();
                        return;
                    }
                }
                else
                { 
                    // tickcount round robin -> reset keep alive timestamp
                    System.Threading.Interlocked.Exchange(ref _lastKeepAlive, tickNow);
                }
            }
        }

        /// <inheritdoc/>
        public void WriteRaw(byte[] message)
        {
            this._objectStream.WriteRaw(message);
        }
    }
}
