
using System;
using System.Collections.Generic;
using System.Threading;
using CareFusion.Mosaic.Interfaces.Converters;
using CareFusion.Mosaic.Connectors.Tcp;
using CareFusion.Mosaic.Converters.Wwks2;
using CareFusion.Mosaic.Interfaces.Connectors;
using CareFusion.Mosaic.Interfaces.Messages;
using CareFusion.Mosaic.Interfaces.Messages.Input;
using CareFusion.Mosaic.Interfaces.Messages.Status;
using CareFusion.Mosaic.Interfaces.Types.Components;
using CareFusion.Mosaic.Interfaces.Types.Packs;
using CareFusion.Mosaic.Interfaces.Types.Articles;
using CareFusion.Mosaic.Interfaces.Messages.Stock;
using CareFusion.Mosaic.Interfaces.Types.Input;
using CareFusion.Mosaic.Interfaces.Messages.Output;
using StorageSystemSimulator.Cores;
using CareFusion.Mosaic.Interfaces.Messages.Task;
using System.Xml.Serialization;
using System.IO;
using MosaicDependency.Interfaces.Messages.Unprocessed;

namespace StorageSystemSimulator
{
    public delegate void ConnectionAddEventHandler(object sender, IConnection connection);
    public delegate void ConnectionRemoveEventHandler(object sender, IConnection connection);

    public delegate void StreamAddEventHandler(object sender, IConverterStream stream);
    public delegate void StreamRemoveEventHandler(object sender, IConverterStream stream);
    
    public class StorageSystemSimulatorCore
    {
        private bool listening;
        private IInboundConnector inConnector;
        private WwksConverter convertor;
        private List<IConverterStream> converterStreamList;
        
        private Thread listenThread;
        private int numberReadingThread;
        private ManualResetEvent shutdownEvent = new ManualResetEvent(false);
        
        // Helpers
        private SimulatorTenant simulatorTenant;
        private SimulatorStockLocation simulatorStockLocation;
        private StorageSystemStock stock;

        // Cores
        private SimulatorStatusCore statusCore;
        private SimulatorInputCore inputCore;
        private SimulatorArticleMasterSetCore articleMasterSetCore;
        private SimulatorStockDeliverySetCore stockDeliverySetCore;
        private SimulatorArticleInfoCore _simulatorArticleInfoCore;
        private SimulatorStockInfoCore stockInfoCore;
        private SimulatorOutputCore outputCore;
        private SimulatorTaskInfoCore taskInfoCore;
        private SimulatorRawXmlCore rawXmlCore;

        public StorageSystemSimulatorCore()
        {
            this.converterStreamList = new List<IConverterStream>();

            this.simulatorTenant = new SimulatorTenant();
            this.simulatorStockLocation = new SimulatorStockLocation();
            this.stock = new StorageSystemStock();

            this.statusCore = new SimulatorStatusCore();
            this.inputCore = new SimulatorInputCore();
            this.articleMasterSetCore = new SimulatorArticleMasterSetCore();
            this.stockDeliverySetCore = new SimulatorStockDeliverySetCore();
            _simulatorArticleInfoCore = new SimulatorArticleInfoCore();
            this.stockInfoCore = new SimulatorStockInfoCore();
            this.outputCore = new SimulatorOutputCore();
            this.taskInfoCore = new SimulatorTaskInfoCore();
            this.rawXmlCore = new SimulatorRawXmlCore();

            this.InitializeCores();
        }
        
        public bool Listen(int port, int subscriberID, int handshakeTimeout, bool enableKeepAlive,
            int keepAliveInterval, int keepAliveTimeOut, bool useExternalIdAsSerialNumber)
        {
            if (this.listening)
            {
                throw new System.Exception("StorageSystemSimulatorCore already Listening");
            }

            List<ConfigurationValue> configurationForTcpInConnector = this.GetConfigurationForTcpInConnector(port);
            this.inConnector = new TcpInConnector();

            if (!this.inConnector.Initialize(1, configurationForTcpInConnector))
            {
                return false;
            }

            List<ConfigurationValue> configurationForWwksConverter = this.GetConfigurationForWwksConverter(
                subscriberID, handshakeTimeout, enableKeepAlive, keepAliveInterval, keepAliveTimeOut, useExternalIdAsSerialNumber);
            this.convertor = new WwksConverter();
            this.convertor.Initialize(2, configurationForWwksConverter);

            this.inputCore.SetSubscriberID(subscriberID);
            _simulatorArticleInfoCore.SetSubscriberID(subscriberID);
            this.listening = true;

            this.listenThread = new Thread(this.ExecuteListen);
            this.listenThread.Name = "StorageSystemSimulator Listen thread";
            this.listenThread.Start();
            
            StorageSystemSerializer storageSystemSerializer = new StorageSystemSerializer();
            storageSystemSerializer.SaveConnectionInformation("Connection.xml",
                configurationForTcpInConnector, configurationForWwksConverter);

            return true;
        }

        public void Stop()
        {
            this.listening = false;
            this.inConnector.Cancel();
            this.listenThread.Join();
            this.inConnector.Dispose();
            this.inConnector = null;

            this.convertor.Dispose();
            this.convertor = null;

            this.shutdownEvent.Set();
            foreach(IConverterStream converterStream in this.converterStreamList.ToArray())
            {
                converterStream.Cancel();
                converterStream.Dispose();
            }

            while (Interlocked.CompareExchange(ref this.numberReadingThread, 0, 0) != 0)
            {
                Thread.Sleep(50);
            }

            this.shutdownEvent.Reset();
        }
        
        public void Save()
        {
            StorageSystemSerializer storageSystemSerializer = new StorageSystemSerializer();
            storageSystemSerializer.Save("Tenant.xml", this.simulatorTenant, typeof(SimulatorTenant));
            storageSystemSerializer.Save("StockLocation.xml", this.simulatorStockLocation, typeof(SimulatorStockLocation));
            storageSystemSerializer.SaveWithDataContract("Stock.xml", this.stock, typeof(StorageSystemStock));
            storageSystemSerializer.Save("ArticleMasterSet.xml", this.articleMasterSetCore, typeof(SimulatorArticleMasterSetCore));
            storageSystemSerializer.SaveWithDataContract("StockDeliverySet.xml", this.stockDeliverySetCore, typeof(SimulatorStockDeliverySetCore));
        }

        public void Load()
        {
            StorageSystemSerializer storageSystemSerializer = new StorageSystemSerializer();

            SimulatorTenant loadedTenant = (SimulatorTenant)storageSystemSerializer.Load("Tenant.xml", typeof(SimulatorTenant));
            this.simulatorTenant = loadedTenant != null ? loadedTenant : this.simulatorTenant;

            SimulatorStockLocation loadedStockLocation = (SimulatorStockLocation)storageSystemSerializer.Load("StockLocation.xml", typeof(SimulatorStockLocation));
            this.simulatorStockLocation = loadedStockLocation != null ? loadedStockLocation : this.simulatorStockLocation;

            StorageSystemStock loadedStock = (StorageSystemStock)storageSystemSerializer.LoadWithDataContract("Stock.xml", typeof(StorageSystemStock));
            this.stock = loadedStock != null ? loadedStock : this.stock;

            SimulatorArticleMasterSetCore loadedArticleMasterSetCore = (SimulatorArticleMasterSetCore)storageSystemSerializer.Load("ArticleMasterSet.xml", typeof(SimulatorArticleMasterSetCore));
            this.articleMasterSetCore = loadedArticleMasterSetCore != null ? loadedArticleMasterSetCore : this.articleMasterSetCore;

            SimulatorStockDeliverySetCore loadedStockDeliverySetCore = (SimulatorStockDeliverySetCore)storageSystemSerializer.LoadWithDataContract("StockDeliverySet.xml", typeof(SimulatorStockDeliverySetCore));
            this.stockDeliverySetCore = loadedStockDeliverySetCore != null ? loadedStockDeliverySetCore : this.stockDeliverySetCore;

            this.InitializeCores();
        }

        public void ClearSavedState()
        {
            StorageSystemSerializer storageSystemSerializer = new StorageSystemSerializer();
            storageSystemSerializer.DeleteFile("Tenant.xml");
            storageSystemSerializer.DeleteFile("StockLocation.xml");
            storageSystemSerializer.DeleteFile("Stock.xml");
            storageSystemSerializer.DeleteFile("ArticleMasterSet.xml");
            storageSystemSerializer.DeleteFile("StockDeliverySet.xml");
        }

        private void InitializeCores()
        {
            this.SimulatorStockLocation.Initialize();

            this.inputCore.Initialize(this.converterStreamList, this.stock);
            this.stockDeliverySetCore.Initialize(this.stock);
            this.stockInfoCore.Initialize(this.converterStreamList, this.stock);
            _simulatorArticleInfoCore.Initialize(this.converterStreamList);
            this.outputCore.Initialize(this.converterStreamList, this.stock, this.simulatorTenant, this.simulatorStockLocation);
            this.taskInfoCore.Initialize(this.outputCore, this.stockDeliverySetCore);
            this.rawXmlCore.Initialize(this.converterStreamList);
        }

        private void ExecuteListen()
        {
            while (this.listening)
            {
                IConnection connection = this.inConnector.WaitForConnections();

                if (connection != null)
                {
                    // new connection.
                    this.DoConnectionAdd(connection);

                    IConverterStream converterStream = this.convertor.CreateStream(connection);

                    if (converterStream == null)
                    {
                        // Handshake failed, connection closed
                        this.DoConnectionRemove(connection);

                        connection.Dispose();
                    }
                    else
                    {
                        // handshake completed
                        this.DoStreamAdd(converterStream);

                        Interlocked.Increment(ref this.numberReadingThread);
                        if (ThreadPool.QueueUserWorkItem(new WaitCallback(ExecuteReadMessage), converterStream) == false)
                        {
                            Interlocked.Decrement(ref this.numberReadingThread);
                            this.DoStreamRemove(converterStream);
                        }
                    }
                }
            }
        }

        private void ExecuteReadMessage(object converterStream)
        {
            IConverterStream stream = (IConverterStream)converterStream;
            
            try
            {
                while (this.shutdownEvent.WaitOne(0) == false)
                {
                    MosaicMessage message = stream.Read();

                    if (message != null)
                    {
                        switch(message.Type)
                        {
                            case MessageType.StatusRequest:
                                this.statusCore.ProcessStatus(message as StatusRequest);
                                break;
                            case MessageType.StockInputResponse:
                                this.inputCore.ProcessInputResponse(message as StockInputResponse);
                                break;
                            case MessageType.InitiateStockInputRequest:
                                this.inputCore.ProcessInitiateStockInputRequest(message as InitiateStockInputRequest);
                                break;
                            case MessageType.ArticleMasterSetRequest:
                                this.articleMasterSetCore.ProcessArticleMasterSetRequest(message as ArticleMasterSetRequest);
                                break;
                            case MessageType.StockDeliverySetRequest:
                                this.stockDeliverySetCore.ProcessStockDeliverySetRequest(message as StockDeliverySetRequest);
                                break;
                            case MessageType.StockInfoRequest:
                                this.stockInfoCore.ProcessStockInfoRequest(message as StockInfoRequest);
                                break;
                            case MessageType.StockOutputRequest:
                                this.outputCore.ProcessStockOutputRequest(message as StockOutputRequest);
                                break;
                            case MessageType.TaskInfoRequest:
                                this.taskInfoCore.ProcessTaskInfoRequest(message as TaskInfoRequest);
                                break;
                            case MessageType.TaskCancelRequest:
                                this.outputCore.ProcessTaskCancelRequest(message as TaskCancelRequest);
                                break;
                            case MessageType.StockLocationInfoRequest:
                                this.SimulatorStockLocation.ProcessStockLocationInfoRequest(message as StockLocationInfoRequest);
                                break;
                            case MessageType.ArticleInformationResponse:
                                this._simulatorArticleInfoCore.ProcessArticleInfoResponse(message as CareFusion.Mosaic.Interfaces.Messages.ArticleInformation.ArticleInfoResponse);
                                break;
                            //case MessageType.UnprocessedMessage:
                            //    this.rawXmlCore.ProcessRawXmlMessage(message as UnprocessedMessage);
                            //    break;
                            default:
                                break;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }
            finally
            {
                // stream closed.
                this.DoStreamRemove(stream);

                stream.Dispose();
            }

            Interlocked.Decrement(ref this.numberReadingThread);
        }
        
        private List<ConfigurationValue> GetConfigurationForTcpInConnector(int port)
        {
            TcpInConnectorConfiguration config = new TcpInConnectorConfiguration();
            config.Port = (ushort)port;
            config.Category = ConnectionCategory.StorageSystem;
            config.MaxConcurrentConnections = 10;
            return config.ToConfigurationValueList();
        }

        private List<ConfigurationValue> GetConfigurationForWwksConverter(
            int subscriberID, int handshakeTimeout, bool enableKeepAlive, 
            int keepAliveInterval, int keepAliveTimeOut, bool useExternalIdAsSerialNumber)
        {
            WwksConverterConfiguration config = new WwksConverterConfiguration();
            config.SubscriberID = subscriberID;
            config.Type = CareFusion.Mosaic.Converters.Wwks2.Types.SubscriberType.Robot;
            config.HandshakeTimeout = handshakeTimeout;
            config.EnableKeepAlive = enableKeepAlive;
            config.KeepAliveInterval = keepAliveInterval;
            config.KeepAliveTimeOut = keepAliveTimeOut;
            config.EnableMessageTrace = true;
            config.UseExternalIdAsSerialNumber = useExternalIdAsSerialNumber;

            return config.ToConfigurationValueList();
        }

        private void DoConnectionAdd(IConnection connection)
        {
            if(this.ConnectionAdd != null)
            {
                this.ConnectionAdd(this, connection);
            }
        }
        private void DoConnectionRemove(IConnection connection)
        {
            if (this.ConnectionRemove != null)
            {
                this.ConnectionRemove(this, connection);
            }
        }
        private void DoStreamAdd(IConverterStream stream)
        {
            this.converterStreamList.Add(stream);

            if (this.StreamAdd != null)
            {
                this.StreamAdd(this, stream);
            }
        }
        private void DoStreamRemove(IConverterStream stream)
        {
            this.converterStreamList.Remove(stream);

            if (this.StreamRemove != null)
            {
                this.StreamRemove(this, stream);
            }
        }

        public bool IsListening { get { return this.listening; } }

        
        public SimulatorTenant SimulatorTenant { get { return this.simulatorTenant; } }

        public SimulatorStockLocation SimulatorStockLocation { get { return this.simulatorStockLocation; } }

        public StorageSystemStock Stock { get { return this.stock; } }
        
        public SimulatorStatusCore StatusCore { get { return this.statusCore; } }

        public SimulatorInputCore InputCore { get { return this.inputCore; } }

        public SimulatorArticleMasterSetCore ArticleMasterSetCore { get { return this.articleMasterSetCore; } }

        public SimulatorStockDeliverySetCore StockDeliverySetCore { get { return this.stockDeliverySetCore; } }

        public SimulatorArticleInfoCore ArticleInfoCore { get { return _simulatorArticleInfoCore; } }

        public SimulatorStockInfoCore StockInfoCore { get { return this.stockInfoCore; } }

        public SimulatorOutputCore OutputCore { get { return this.outputCore; } }

        public SimulatorRawXmlCore RawXmlCore { get { return this.rawXmlCore; } }

        public event ConnectionAddEventHandler ConnectionAdd;
        public event ConnectionRemoveEventHandler ConnectionRemove;

        public event StreamAddEventHandler StreamAdd;
        public event StreamRemoveEventHandler StreamRemove;
    }
}
