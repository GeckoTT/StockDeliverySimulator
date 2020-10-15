
using System.Collections.Generic;
using StorageSystemSimulator;
using CareFusion.Mosaic.Interfaces.Messages.Output;
using CareFusion.Mosaic.Interfaces.Types.Output;
using System.Threading;
using CareFusion.Mosaic.Interfaces.Types.Packs;
using CareFusion.Mosaic.Interfaces.Messages.Task;
using System;
using CareFusion.Mosaic.Interfaces.Converters;
using System.Threading.Tasks;
using Task = CareFusion.Mosaic.Interfaces.Messages.Task.Task;

namespace StorageSystemSimulator.Cores
{
    public enum OutputResult
    {
        AlwaysComplete,
        AlwaysIncomplete,
        FrozenStock,
        Normal
    }

    public class SimulatorOutputOrder
    {
        private StorageSystemStock stock;
        private SimulatorTenant simulatorTenant;
        private SimulatorStockLocation simulatorStockLocation;
        private StockOutputRequest outputRequest;
        private StockOutputMessage stockOutputMessage;
        private OutputResult outputResult;
        private bool enableAutoReply;
        private bool cancelled;
        private Timer toCompleteTimer;
        private List<IConverterStream> converterStreamList;

        public SimulatorOutputOrder(
            StorageSystemStock stock,
            SimulatorTenant simulatorTenant,
            SimulatorStockLocation simulatorStockLocation,
            StockOutputRequest outputRequest,
            OutputResult outputResult,
            bool enableAutoReply,
            List<IConverterStream> converterStreamList)
        {
            this.stock = stock;
            this.simulatorTenant = simulatorTenant;
            this.simulatorStockLocation = simulatorStockLocation;
            this.outputRequest = outputRequest;
            this.outputResult = outputResult;
            this.stockOutputMessage = null;
            this.enableAutoReply = enableAutoReply;
            this.cancelled = false;
            this.converterStreamList = converterStreamList;

            this.toCompleteTimer = new System.Threading.Timer(
                this.OutputCompletedTimer,
                null,
                5000, 5000);
        }

        public Task GetTaskInformation(bool includeTaskDetails)
        {
            Task result = new Task();
            result.ID = this.outputRequest.ID.ToString();
            //result.BoxNumbers = this.outputRequest.;
            if (this.stockOutputMessage == null)
            {
                result.State = this.cancelled ? TaskState.Aborted : TaskState.InProcess;
            }
            else
            {
                result.State = this.OutputStateToTaskState(this.stockOutputMessage.Order.State);
            }
            result.Type = TaskType.Output;

            if (includeTaskDetails)
            {
                if (this.stockOutputMessage != null)
                {
                    foreach (StockOutputOrderItem item in this.stockOutputMessage.Order.Items)
                    {
                        result.OutputPacks.AddRange(item.Packs);
                    }
                }
            }

            return result;
        }
        
        public Task CancelOrder()
        {
            // stop feedback timer
            this.toCompleteTimer.Change(Timeout.Infinite, Timeout.Infinite);

            // order is cancelled
            this.cancelled = true;

            // update UI
            this.DoOutputOrderUpdated();

            Task result = new Task();
            result.ID = this.outputRequest.ID.ToString();
            result.State = this.stockOutputMessage == null ? TaskState.Cancelled : TaskState.CancelError; // error cancel if order finished.
            result.Type = TaskType.Output;

            return result;
        }
        
        private TaskState OutputStateToTaskState(StockOutputOrderState outputState)
        {
            switch (outputState)
            {
                case StockOutputOrderState.Queued:  return TaskState.Queued;
                case StockOutputOrderState.InProcess: return TaskState.InProcess;
                case StockOutputOrderState.Aborting: return TaskState.Aborting;
                case StockOutputOrderState.Aborted: return TaskState.Aborted;
                case StockOutputOrderState.Completed: return TaskState.Completed;
                case StockOutputOrderState.Incomplete:
                case StockOutputOrderState.HasError:
                    {
                        return TaskState.Incomplete;
                    }

                default: return TaskState.Unknown;
            }
        }

        // should be changed to do one pack at the time ?
        private void OutputCompletedTimer(object stateInfo)
        {
            // stop feedback timer
            this.toCompleteTimer.Change(Timeout.Infinite, Timeout.Infinite);

            this.stockOutputMessage = new StockOutputMessage(this.outputRequest.ConverterStream);
            this.stockOutputMessage.AdoptHeader(this.outputRequest);
            this.stockOutputMessage.Order = this.outputRequest.Order.Clone();

            switch (this.outputResult)
            {
                case OutputResult.AlwaysComplete:
                    this.BuildMessageAlwaysComplete(this.stockOutputMessage);
                    this.stockOutputMessage.Order.State = StockOutputOrderState.Completed;
                    break;
                case OutputResult.AlwaysIncomplete:
                    this.stockOutputMessage.Order.State = StockOutputOrderState.Incomplete;
                    break;
                case OutputResult.FrozenStock:
                case OutputResult.Normal:
                    bool isCompleted = this.BuildMessageAccordingToStock(this.stockOutputMessage, this.outputResult == OutputResult.Normal);
                    this.stockOutputMessage.Order.State = isCompleted ? StockOutputOrderState.Completed : StockOutputOrderState.Incomplete;
                    break;
                default:
                    this.stockOutputMessage.Order.State = StockOutputOrderState.Incomplete;
                    break;
            }

            if (this.enableAutoReply)
            {
                Parallel.ForEach(this.converterStreamList, stream => stream.Write(this.stockOutputMessage));
            }

            this.DoOutputOrderUpdated();
        }

        private void BuildMessageAlwaysComplete(StockOutputMessage stockOutputMessage)
        {
            foreach (StockOutputOrderItem stockOutputOrderItem in stockOutputMessage.Order.Items)
            {
                StorageSystemArticleInformation articleInformation = this.stock.ArticleInformationList.GetArticleInformation(string.IsNullOrWhiteSpace(stockOutputOrderItem.RobotArticleCode) ? 
                    stockOutputOrderItem.PISArticleCode : stockOutputOrderItem.RobotArticleCode, false);

                stockOutputOrderItem.ProcessedQuantity = stockOutputOrderItem.RequestedQuantity;
                stockOutputOrderItem.ProcessedSubItemQuantity = stockOutputOrderItem.RequestedSubItemQuantity;

                if ((stockOutputOrderItem.PackID != 0) && (stockOutputOrderItem.ProcessedQuantity > 1))
                {
                    // if requesting a specific Pack ID, only this pack will be dispened. 
                    stockOutputOrderItem.ProcessedQuantity = 1;
                }

                for (int i = 0; i < stockOutputOrderItem.ProcessedQuantity || (i == 0 && stockOutputOrderItem.ProcessedSubItemQuantity > 0); i++)
                {
                    StockOutputOrderItemPack newPack = new StockOutputOrderItemPack();
                    if (articleInformation != null)
                    {
                        newPack.RobotArticleCode = articleInformation.Code;
                        newPack.RobotArticleName = articleInformation.Name;
                        newPack.RobotArticleDosageForm = articleInformation.DosageForm;
                        newPack.RobotArticlePackagingUnit = articleInformation.PackagingUnit;
                        newPack.RobotArticleMaxSubItemQuantity = articleInformation.MaxSubItemQuantity;
                    }
                    else
                    {
                        newPack.RobotArticleCode = string.IsNullOrWhiteSpace(stockOutputOrderItem.RobotArticleCode) ? stockOutputOrderItem.PISArticleCode : stockOutputOrderItem.RobotArticleCode;
                    }

                    newPack.BoxNumber = stockOutputMessage.Order.BoxNumber;
                    newPack.BatchNumber = stockOutputOrderItem.BatchNumber;
                    newPack.Depth = 60;
                    newPack.Height = 60;
                    newPack.Width = 60;
                    if (stockOutputOrderItem.ExpiryDate.Ticks == 0)
                    {
                        // PMR is not requesting a specific date, we need to set a valide date.
                        newPack.ExpiryDate = DateTime.Now.AddMonths(3);
                    }
                    else
                    {
                        newPack.ExpiryDate = stockOutputOrderItem.ExpiryDate;
                    }
                    
                    newPack.ExternalID = stockOutputOrderItem.ExternalID;
                    newPack.ID = stockOutputOrderItem.PackID != 0 ? stockOutputOrderItem.PackID : this.stock.GetNextPackID(); ;
                    newPack.LabelState = StockOutputOrderItemPackLabelState.Labelled;
                    newPack.OutputNumber = stockOutputMessage.Order.OutputNumber;
                    newPack.OutputPoint = stockOutputMessage.Order.OutputPoint;
                    newPack.Shape = PackShape.Cuboid;
                    newPack.SubItemQuantity = stockOutputOrderItem.RequestedSubItemQuantity;
                    
                    newPack.MachineLocation = stockOutputOrderItem.MachineLocation;
                    newPack.StockLocationID = stockOutputOrderItem.StockLocationID;
                    newPack.StockLocationDescription = this.simulatorStockLocation.GetDescription(newPack.StockLocationID);
                    newPack.TenantID = stockOutputOrderItem.TenantID;
                    newPack.TenantDescription = this.simulatorTenant.GetDescription(newPack.TenantID);

                    stockOutputOrderItem.Packs.Add(newPack);
                }
            }
        }

        private bool BuildMessageAccordingToStock(StockOutputMessage stockOutputMessage, bool affectStockLevel)
        {
            bool outputCompleted = true;

            foreach (StockOutputOrderItem stockOutputOrderItem in stockOutputMessage.Order.Items)
            {
                // 1) get packs from stock
                List<RobotPack> availableStock = this.GetStock(stockOutputOrderItem, stockOutputMessage.TenantID);
                List<RobotPack> usedStock = new List<RobotPack>();

                // 2) create StockOutputOrderItemPack from stock list
                stockOutputOrderItem.Packs.AddRange(this.GetOrderItemFromStock(
                    stockOutputMessage,
                    stockOutputOrderItem,
                    availableStock,
                    usedStock));


                // 3) remove packs uses 
                if (affectStockLevel)
                {
                    this.RemoveUsedPackFromStock(usedStock);
                }

                // 4) update output Status
                outputCompleted &= (stockOutputOrderItem.ProcessedQuantity == stockOutputOrderItem.RequestedQuantity);
                outputCompleted &= (stockOutputOrderItem.ProcessedSubItemQuantity == stockOutputOrderItem.RequestedSubItemQuantity);
            }

            return outputCompleted;
        }

        private List<RobotPack> GetStock(StockOutputOrderItem stockOutputOrderItem, string tenantID)
        {
            var articleCode = String.IsNullOrWhiteSpace(stockOutputOrderItem.RobotArticleCode) ? 
                stockOutputOrderItem.PISArticleCode : stockOutputOrderItem.RobotArticleCode;

            StockProduct productStock = this.stock.GetStockProduct(articleCode);

            if (productStock != null)
            {
                return productStock.GetPackList(
                    stockOutputOrderItem.BatchNumber,
                    stockOutputOrderItem.ExternalID,
                    stockOutputOrderItem.MachineLocation,
                    stockOutputOrderItem.StockLocationID,
                    stockOutputOrderItem.PackID,
                    tenantID);
            }
            else
            {
                return new List<RobotPack>();
            }
        }

        private List<StockOutputOrderItemPack> GetOrderItemFromStock(
            StockOutputMessage stockOutputMessage,
            StockOutputOrderItem stockOutputOrderItem,
            List<RobotPack> availableStock,
            List<RobotPack> usedStock)
        {
            List<StockOutputOrderItemPack> result = new List<StockOutputOrderItemPack>();
            StorageSystemArticleInformation articleInformation = this.stock.ArticleInformationList.GetArticleInformation(string.IsNullOrWhiteSpace(stockOutputOrderItem.RobotArticleCode) ?
                    stockOutputOrderItem.PISArticleCode : stockOutputOrderItem.RobotArticleCode, false);
            string pickedBatchNumber = String.Empty;
            int subIemQuantityInStock = 0;

            // if possible pick a pack that match exactly the requested subquantity. 
            foreach (RobotPack availablePack in availableStock)
            {
                if (stockOutputOrderItem.ProcessedSubItemQuantity < stockOutputOrderItem.RequestedSubItemQuantity)
                {
                    if (availablePack.SubItemQuantity == stockOutputOrderItem.RequestedSubItemQuantity)
                    {
                        stockOutputOrderItem.ProcessedSubItemQuantity += availablePack.SubItemQuantity;
                        result.Add(this.GetOrderItemPackFromStock(
                            stockOutputMessage.Order,
                            articleInformation,
                            availablePack));
                        usedStock.Add(availablePack);
                        pickedBatchNumber = availablePack.BatchNumber;
                    }
                }
                subIemQuantityInStock += availablePack.SubItemQuantity;
            }

            // update available stock
            foreach (RobotPack usedPack in usedStock)
            {
                if (availableStock.Contains(usedPack))
                {
                    availableStock.Remove(usedPack);
                }
            }

            // Normal picking.
            foreach (RobotPack availablePack in availableStock)
            {
                if (availablePack.SubItemQuantity == 0)
                {
                    // Full pack
                    if ((stockOutputOrderItem.ProcessedQuantity < stockOutputOrderItem.RequestedQuantity)
                        && (!stockOutputOrderItem.SingleBatchNumber || (pickedBatchNumber == availablePack.BatchNumber) || (String.IsNullOrEmpty(pickedBatchNumber))))
                    {
                        stockOutputOrderItem.ProcessedQuantity++;
                        result.Add(this.GetOrderItemPackFromStock(
                            stockOutputMessage.Order,
                            articleInformation,
                            availablePack));
                        usedStock.Add(availablePack);
                        pickedBatchNumber = availablePack.BatchNumber;
                    }
                    else
                    {
                        // if we don't have enough open pack in stock, add full packs
                        if (subIemQuantityInStock < stockOutputOrderItem.RequestedSubItemQuantity)
                        {
                            if (articleInformation.MaxSubItemQuantity != 0)
                            {
                                if ((stockOutputOrderItem.ProcessedSubItemQuantity < stockOutputOrderItem.RequestedSubItemQuantity)
                                    && (!stockOutputOrderItem.SingleBatchNumber || (pickedBatchNumber == availablePack.BatchNumber)))
                                {
                                    stockOutputOrderItem.ProcessedSubItemQuantity += articleInformation.MaxSubItemQuantity;
                                    result.Add(this.GetOrderItemPackFromStock(
                                        stockOutputMessage.Order,
                                        articleInformation,
                                        availablePack));
                                    usedStock.Add(availablePack);
                                    pickedBatchNumber = availablePack.BatchNumber;
                                }
                            }
                            else
                            {
                                if ((stockOutputOrderItem.ProcessedSubItemQuantity < stockOutputOrderItem.RequestedSubItemQuantity)
                                    && (!stockOutputOrderItem.SingleBatchNumber || (pickedBatchNumber == availablePack.BatchNumber)))
                                {
                                    stockOutputOrderItem.ProcessedQuantity += 1;
                                    result.Add(this.GetOrderItemPackFromStock(
                                        stockOutputMessage.Order,
                                        articleInformation,
                                        availablePack));
                                    usedStock.Add(availablePack);
                                    pickedBatchNumber = availablePack.BatchNumber;
                                }
                                break;
                            }
                        }
                    }
                }
                else
                {
                    // Open pack
                    if ((stockOutputOrderItem.ProcessedSubItemQuantity < stockOutputOrderItem.RequestedSubItemQuantity)
                        && (!stockOutputOrderItem.SingleBatchNumber || (pickedBatchNumber == availablePack.BatchNumber)))
                    {
                        stockOutputOrderItem.ProcessedSubItemQuantity += availablePack.SubItemQuantity;
                        result.Add(this.GetOrderItemPackFromStock(
                            stockOutputMessage.Order,
                            articleInformation,
                            availablePack));
                        usedStock.Add(availablePack);
                        pickedBatchNumber = availablePack.BatchNumber;
                    }
                }

                if ((stockOutputOrderItem.ProcessedQuantity >= stockOutputOrderItem.RequestedQuantity)
                    && (stockOutputOrderItem.ProcessedSubItemQuantity >= stockOutputOrderItem.RequestedSubItemQuantity))
                {
                    break;
                }
            }

            // update available stock
            foreach (RobotPack usedPack in usedStock)
            {
                if (availableStock.Contains(usedPack))
                {
                    availableStock.Remove(usedPack);
                }
            }

            return result;
        }

        private StockOutputOrderItemPack GetOrderItemPackFromStock(
            StockOutputOrder outputOrder,
            StorageSystemArticleInformation articleInformation,
            RobotPack packInStock)
        {
            StockOutputOrderItemPack result = new StockOutputOrderItemPack();

            if (articleInformation != null)
            {
                result.RobotArticleCode = articleInformation.Code;
                result.RobotArticleName = articleInformation.Name;
                result.RobotArticleDosageForm = articleInformation.DosageForm;
                result.RobotArticlePackagingUnit = articleInformation.PackagingUnit;
                result.RobotArticleMaxSubItemQuantity = articleInformation.MaxSubItemQuantity;
            }
            else
            {
                result.RobotArticleCode = packInStock.RobotArticleCode;
            }

            result.BoxNumber = outputOrder.BoxNumber;
            result.BatchNumber = packInStock.BatchNumber;
            result.Depth = packInStock.Depth;
            result.Height = packInStock.Height;
            result.Width = packInStock.Width;
            result.ExpiryDate = packInStock.ExpiryDate;
            result.ExternalID = packInStock.ExternalID;
            result.ID = packInStock.ID;
            result.LabelState = StockOutputOrderItemPackLabelState.Labelled;
            result.OutputNumber = outputOrder.OutputNumber;
            result.OutputPoint = outputOrder.OutputPoint;
            result.Shape = packInStock.Shape;
            result.SubItemQuantity = packInStock.SubItemQuantity;

            result.MachineLocation = packInStock.MachineLocation;
            result.StockLocationID = packInStock.StockLocationID;
            result.StockLocationDescription = this.simulatorStockLocation.GetDescription(result.StockLocationID);
            result.TenantID = packInStock.TenantID;
            result.TenantDescription = this.simulatorTenant.GetDescription(result.TenantID);

            return result;
        }

        private void RemoveUsedPackFromStock(List<RobotPack> usedStock)
        {
            if (usedStock.Count == 0)
            {
                return;
            }

            StockProduct productStock = this.stock.GetStockProduct(usedStock[0].RobotArticleCode);

            if (productStock != null)
            {
                foreach (RobotPack usedPack in usedStock)
                {
                    productStock.RemoveItem(usedPack);
                }
            }
        }
        
        private string GetStatusString()
        {
            StockOutputOrderState currentState = this.stockOutputMessage == null ? StockOutputOrderState.InProcess : this.stockOutputMessage.Order.State;
            if (this.cancelled)
            {
                currentState = StockOutputOrderState.Aborted;
            }
            return currentState.ToString();
        }

        private void DoOutputOrderUpdated()
        {
            if (this.OutputOrderUpdated != null)
            {
                this.OutputOrderUpdated(this, null);
            }
        }

        public string ID { get { return this.outputRequest.ID; } }

        public int Priority { get { return this.outputRequest.Order.Priority; } }

        public int Output { get { return this.outputRequest.Order.OutputNumber; } }

        public int Point { get { return this.outputRequest.Order.OutputPoint; } }

        public string Box { get { return this.outputRequest.Order.BoxNumber; } }

        public string State { get { return this.GetStatusString(); } }

        public string TenantID { get { return this.outputRequest.TenantID; } }

        public List<StockOutputOrderItem> Items { get { return this.stockOutputMessage != null ? this.stockOutputMessage.Order.Items : outputRequest.Order.Items; } }

        public event EventHandler OutputOrderUpdated;
    }

    public class SimulatorOutputCore
    {
        private List<IConverterStream> converterStreamList;
        private StorageSystemStock stock;
        private SimulatorTenant simulatorTenant;
        private SimulatorStockLocation simulatorStockLocation;

        private List<SimulatorOutputOrder> orderList;
        private OutputResult outputResult;
        private bool enableAutoReply = true;
        private bool generateBoxId = false;
        private int nextBoxId = 1;

        public SimulatorOutputCore()
        {
            this.orderList = new List<SimulatorOutputOrder>();
        }

        public void Initialize(List<IConverterStream> converterStreamList,
            StorageSystemStock stock,
            SimulatorTenant simulatorTenant,
            SimulatorStockLocation simulatorStockLocation)
        {
            this.converterStreamList = converterStreamList;
            this.stock = stock;
            this.simulatorTenant = simulatorTenant;
            this.simulatorStockLocation = simulatorStockLocation;
        }

        public void ProcessStockOutputRequest(StockOutputRequest stockOutputRequest)
        {
            StockOutputResponse stockOutputResponse = new StockOutputResponse(stockOutputRequest.ConverterStream);
            stockOutputResponse.AdoptHeader(stockOutputRequest);
            stockOutputResponse.Order = stockOutputRequest.Order.Clone();

            if ((this.generateBoxId)
                && (String.IsNullOrEmpty(stockOutputRequest.Order.BoxNumber)))
            {
                stockOutputRequest.Order.BoxNumber = nextBoxId.ToString();
                nextBoxId++;
            }

            // create SimulatorOutputOrder to handle output result.
            SimulatorOutputOrder outputOrder = new SimulatorOutputOrder(
                this.stock,
                this.simulatorTenant,
                this.simulatorStockLocation,
                stockOutputRequest,
                this.outputResult,
                this.enableAutoReply,
                this.converterStreamList);
            outputOrder.OutputOrderUpdated += this.OutputOrder_OutputOrderUpdated;
            this.orderList.Add(outputOrder);

            stockOutputResponse.ConverterStream.Write(stockOutputResponse);

            this.DoOutputOrderListUpdated();
        }

        public Task GetTaskInformation(Task requestedTask, bool includeTaskDetails)
        {
            SimulatorOutputOrder outputOrder = this.GetOutputOrderByID(requestedTask.ID);

            if (outputOrder != null)
            {
                return outputOrder.GetTaskInformation(includeTaskDetails);
            }

            return requestedTask;
        }

        public void ProcessTaskCancelRequest(TaskCancelRequest taskCancelRequest)
        {
            TaskCancelResponse taskCancelResponse = new TaskCancelResponse();
            taskCancelResponse.AdoptHeader(taskCancelRequest);
            
            foreach (Task task in taskCancelRequest.Tasks)
            {

                SimulatorOutputOrder outputOrder = this.GetOutputOrderByID(task.ID);

                if (outputOrder != null)
                {
                    taskCancelResponse.Tasks.Add(outputOrder.CancelOrder());
                }
            }

            taskCancelResponse.ConverterStream.Write(taskCancelResponse);
        }

        public void DirectOutput(RobotPack pack)
        {
            // send a output response to every PMR conencted and matching tenant.
            foreach (IConverterStream stream in this.converterStreamList)
            {
                if (pack.TenantID != stream.TenantID)
                {
                    continue;
                }
                
                StockOutputRequest stockOutputRequest = new StockOutputRequest(stream);
                stockOutputRequest.ID = "1";  // is always 1
                stockOutputRequest.TenantID = pack.TenantID;

                int machineLocation;
                if (int.TryParse(pack.MachineLocation, out machineLocation))
                {
                    stockOutputRequest.Source = machineLocation;
                }
                stockOutputRequest.Destination = 100;

                stockOutputRequest.Order = new StockOutputOrder();
                stockOutputRequest.Order.OutputNumber = 1;

                StockOutputOrderItem orderItem = new StockOutputOrderItem();
                orderItem.RobotArticleCode = pack.RobotArticleCode;
                orderItem.PackID = pack.ID;
                if (pack.SubItemQuantity == 0)
                {
                    orderItem.RequestedQuantity = 1;
                }
                else
                {
                    orderItem.RequestedSubItemQuantity = pack.SubItemQuantity;
                }

                stockOutputRequest.Order.Items.Add(orderItem);

                // create SimulatorOutputOrder to handle output result.
                SimulatorOutputOrder outputOrder = new SimulatorOutputOrder(
                    this.stock,
                    this.simulatorTenant,
                    this.simulatorStockLocation,
                    stockOutputRequest,
                    OutputResult.Normal,
                    this.enableAutoReply,
                    this.converterStreamList);
                outputOrder.OutputOrderUpdated += this.OutputOrder_OutputOrderUpdated;
                this.orderList.Add(outputOrder);

                this.DoOutputOrderListUpdated();
            }
        }
        
        private SimulatorOutputOrder GetOutputOrderByID(string orderID)
        {
            SimulatorOutputOrder result = null;

            foreach (SimulatorOutputOrder outputOrder in this.orderList)
            {
                if (outputOrder.ID.ToString() == orderID)
                {
                    // if multiple order exist with the same ID, select lastest order.
                    result = outputOrder;
                }
            }

            return result;
        }

        private void DoOutputOrderListUpdated()
        {
            if (this.OutputOrderListUpdated != null)
            {
                this.OutputOrderListUpdated(this, null);
            }
        }
        
        private void OutputOrder_OutputOrderUpdated(object sender, EventArgs e)
        {
            this.DoOutputOrderListUpdated();
        }

        public List<SimulatorOutputOrder> OrderList { get { return this.orderList; } }

        public OutputResult OutputResult { set { this.outputResult = value; } }

        public bool EnableAutoReply { set { this.enableAutoReply = value; } }

        public bool GenerateBoxId { set { this.generateBoxId = value; } }

        public event EventHandler OutputOrderListUpdated;
    }
}
