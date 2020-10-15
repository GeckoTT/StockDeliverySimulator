using CareFusion.Mosaic.Interfaces.Messages.Stock;
using CareFusion.Mosaic.Interfaces.Messages.Task;
using CareFusion.Mosaic.Interfaces.Types.Input;
using StorageSystemSimulator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace StorageSystemSimulator.Cores
{
    [DataContract]
    public class SimulatorStockDeliverySetCore
    {
        private StorageSystemStock stock;
        [DataMember]
        private List<StockDelivery> stockDeliveryList;

        private bool stockDeliveryResult = true;
        private string stockDeliveryResultText;

        public SimulatorStockDeliverySetCore()
        {
            this.stockDeliveryList = new List<StockDelivery>();
        }

        public void Initialize(StorageSystemStock stock)
        {
            this.stock = stock;
        }

        public void ProcessStockDeliverySetRequest(StockDeliverySetRequest stockDeliverySetRequest)
        {
            if (this.stockDeliveryResult)
            {
                // fix tenant
                foreach (StockDelivery stockDelivery in stockDeliverySetRequest.StockDeliveries)
                {
                    if (String.IsNullOrEmpty(stockDelivery.TenantID)) // if PMR doesn't set the tenant, default it to the PMR tenant.
                    {
                        stockDelivery.TenantID = stockDeliverySetRequest.TenantID;
                    }

                    foreach(StockDeliveryItem stockDeliveryItem in stockDelivery.Items)
                    {
                        if (String.IsNullOrEmpty(stockDeliveryItem.TenantID)) // if PMR doesn't set the tenant, default it to the PMR tenant.
                        {
                            stockDeliveryItem.TenantID = stockDeliverySetRequest.TenantID;
                        }
                    }
                }

                // check if delivery is already know
                foreach (StockDelivery newStockDelivery in stockDeliverySetRequest.StockDeliveries)
                {
                    bool addDelivery = true;

                    foreach (StockDelivery existingStockDelivery in this.stockDeliveryList)
                    {
                        if (existingStockDelivery.DeliveryNumber == newStockDelivery.DeliveryNumber)
                        {
                            // if delivery existe
                            if ((existingStockDelivery.State == StockDeliveryState.Queued)
                                || (existingStockDelivery.State == StockDeliveryState.InProcess))
                            {
                                // and is not finished, update it
                                addDelivery = false;

                                foreach (StockDeliveryItem newStockDeliveryItem in newStockDelivery.Items)
                                {
                                    bool foundItem = false;
                                    foreach (StockDeliveryItem existingStockDeliveryItem in existingStockDelivery.Items)
                                    {
                                        if (existingStockDeliveryItem.ArticleCode == newStockDeliveryItem.ArticleCode)
                                        {
                                            foundItem = true;
                                            existingStockDeliveryItem.RequestedQuantity = newStockDeliveryItem.RequestedQuantity;
#warning should copy more
                                        }
                                    }

                                    if (!foundItem)
                                    {
                                        existingStockDelivery.Items.Add(newStockDeliveryItem);
                                    }
                                }
                            }

                            break;
                        }
                    }

                    if (addDelivery)
                    {
                        // add not existing delivery
                        this.stockDeliveryList.Add(newStockDelivery);
                    }
                }
                
                this.DoStockDeliveryUpdated();
            }

            StockDeliverySetResponse stockDeliverySetResponse = new StockDeliverySetResponse(stockDeliverySetRequest.ConverterStream);
            stockDeliverySetResponse.AdoptHeader(stockDeliverySetRequest);
            stockDeliverySetResponse.SetResult = this.stockDeliveryResult;
            stockDeliverySetResponse.SetResultText = this.stockDeliveryResultText;

            stockDeliverySetResponse.ConverterStream.Write(stockDeliverySetResponse);
        }

        public Task GetTaskInformation(Task requestedTask, bool includeTaskDetails)
        {
            if (this.stockDeliveryList != null)
            {
                foreach (StockDelivery stockDelivery in this.stockDeliveryList)
                {
                    if (stockDelivery.DeliveryNumber == requestedTask.ID)
                    {
                        Task result = new Task();
                        result.ID = requestedTask.ID;
                        result.State = this.StockDeliveryStateToTaskState(stockDelivery.State);
                        result.Type = TaskType.Output;
                        if (includeTaskDetails)
                        {
                            result.DeliveryItems.AddRange(stockDelivery.Items);
                        }

                        return result;
                    }
                }
            }

            return requestedTask;
        } 

        public void CompleteDelivery(StockDelivery stockDelivery)
        {
            // chould we check that all epxected pack have been loaded and set state to complete / imcomplete
            stockDelivery.State = StockDeliveryState.Completed;
        }

        public bool LoadStockDeliveryItem(StockDelivery stockDelivery, StockDeliveryItem stockDeliveryItem)
        {
            if ((stockDelivery.State != StockDeliveryState.Queued)
                && ((stockDelivery.State != StockDeliveryState.InProcess)))
            {
                // delivery doesn't expect any more packs.
                return false;
            }

            if ((stockDeliveryItem.RequestedQuantity <= stockDeliveryItem.ProcessedQuantity)
                && (stockDeliveryItem.RequestedQuantity != 0))
            {
                // this item doesn't expect any more packs.
                return false;
            }

            if (stockDelivery.State == StockDeliveryState.Queued)
            {
                stockDelivery.State = StockDeliveryState.InProcess;
            }

            stockDeliveryItem.ProcessedQuantity++;

            this.stock.LoadInput(stockDeliveryItem.ArticleCode,
                stockDeliveryItem.Name,
                stockDeliveryItem.DosageForm,
                stockDeliveryItem.PackagingUnit,
                stockDeliveryItem.MaxSubItemQuantity,
                stockDeliveryItem.BatchNumber,
                stockDeliveryItem.ExternalID,
                stockDeliveryItem.ExpiryDate,
                0, // is stock delivery always for full packs ?
                stockDeliveryItem.MachineLocation,
                stockDeliveryItem.TenantID,
                stockDeliveryItem.StockLocationID);


            return true;
        }

        private TaskState StockDeliveryStateToTaskState(StockDeliveryState stockDeliveryState)
        {
            switch (stockDeliveryState)
            {
                case StockDeliveryState.Queued: return TaskState.Queued;
                case StockDeliveryState.InProcess: return TaskState.InProcess;
                case StockDeliveryState.Aborted: return TaskState.Aborted;
                case StockDeliveryState.Completed: return TaskState.Completed;
                case StockDeliveryState.Incomplete:
                case StockDeliveryState.HasError:
                    {
                        return TaskState.Incomplete;
                    }

                default: return TaskState.Unknown;
            }
        }

        private void DoStockDeliveryUpdated()
        {
            if (this.StockDeliveryUpdated != null)
            {
                this.StockDeliveryUpdated(this, null);
            }
        }

        public bool StockDeliveryResult { get { return this.stockDeliveryResult; } set { this.stockDeliveryResult = value; } }

        public string StockDeliveryResultText { get { return this.stockDeliveryResultText; } set { this.stockDeliveryResultText = value; } }

        public List<StockDelivery> StockDeliveryList { get { return this.stockDeliveryList; } }

        public event EventHandler StockDeliveryUpdated;
    }
}
