
namespace CareFusion.Mosaic.Interfaces.Messages
{
    /// <summary>
    /// Enum which defines the different supported types of Mosaic messages.
    /// </summary>
    public enum MessageType
    {
        // Stock Input
        StartStockDeliveryRequest,
        StockInputRequest,
        StockInputResponse,
        StockInputMessage,
        EndStockDeliveryRequest,
        StartEndStockDeliveryResponse,
        InitiateStockInputRequest,
        InitiateStockInputResponse,
        InitiateStockInputMessage,

        // Stock Output
        StockOutputRequest,
        StockOutputResponse,
        StockOutputMessage,

        // Status 
        StatusRequest,
        StatusResponse,
        StatusMessage,

        // Stock Info
        StockInfoRequest,
        StockInfoResponse,
        StockInfoMessage,
        ArticleInfoRequest,
        ArticleInfoResponse,
        ArticleMasterSetRequest,
        ArticleMasterSetResponse,
        StockDeliverySetRequest,
        StockDeliverySetResponse,
        
        // Task Info
        TaskInfoRequest,
        TaskInfoResponse,

        // Task Cancellation
        TaskCancelRequest,
        TaskCancelResponse,

        // Transport System
        TransportSystemConfigRequest,
        TransportSystemConfigResponse,
        TransportSystemOrderRequest,
        TransportSystemOrderResponse,
        TransportSystemStatusRequest,
        TransportSystemStatusResponse,
        TransportSystemOrderComplete,
        TransportSystemManualOrderMessage,
        TransportSystemTransferPointStatus,

        // Printing
        LabelPrintRequest,
        LabelPrintResponse,
        LabelPrintMessage,

        // Configuration
        ConfigurationGetRequest,
        ConfigurationGetResponse,
        InputConfigurationRequest,
        InputConfigurationResponse,
        InputConfigurationMessage,
        ConveyorConfigGetRequest,
        ConveyorConfigGetResponse,

        // Stock Locations
        StockLocationInfoRequest,
        StockLocationInfoResponse,
        
        // Legacy Messages
        CommandRequest,

        // Article Information
        ArticleInformationRequest,
        ArticleInformationResponse,
        ArticlePriceRequest,
        ArticlePriceResponse,

        // Sales
        ArticleSelectedMessage,
        ShoppingCartRequest,
        ShoppingCartResponse,
        ShoppingCartUpdateRequest,
        ShoppingCartUpdateResponse,
        ShoppingCartUpdateMessage,

        // Unprocessed
        UnprocessedMessage
    }
}
