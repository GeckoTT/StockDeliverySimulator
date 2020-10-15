using CareFusion.Mosaic.Interfaces.Messages.Stock;
using CareFusion.Mosaic.Interfaces.Types.Stock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageSystemSimulator.Cores
{
    public class StockLocationInfo
    {
        private string GetDisplayText()
        {
            return String.Format("[{0}] {1}", this.ID, this.Description);
        }

        public string ID { get; set; }

        public string Description { get; set; }

        public string DisplayText { get { return this.GetDisplayText(); } }
    }

    public class SimulatorStockLocation
    {
        private List<StockLocationInfo> stockLocationList;

        public SimulatorStockLocation()
        {
            this.stockLocationList = new List<StockLocationInfo>();
        }

        public void Initialize()
        {
            if (this.stockLocationList.Count == 0)
            {
                this.stockLocationList.Add(new StockLocationInfo());
                this.stockLocationList[0].ID = "NONE";
                this.stockLocationList[0].Description = "";
            }
        }

        public string GetDescription(string id)
        {
            foreach(StockLocationInfo stockLocationInfo in this.stockLocationList)
            {
                if (stockLocationInfo.ID == id)
                {
                    return stockLocationInfo.Description;
                }
            }

            return "";
        }

        public bool Contains(string id)
        {
            foreach (StockLocationInfo stockLocationInfo in this.stockLocationList)
            {
                if (stockLocationInfo.ID == id)
                {
                    return true;
                }
            }

            if (String.IsNullOrEmpty(id))
            {
                return true;
            }

            return false;
        }

        public void ProcessStockLocationInfoRequest(StockLocationInfoRequest stockLocationInfoRequest)
        {
            StockLocationInfoResponse stockLocationInfoResponse = new StockLocationInfoResponse();
            stockLocationInfoResponse.AdoptHeader(stockLocationInfoRequest);

            foreach(StockLocationInfo stockLocationInfo in this.stockLocationList)
            {
                StockLocation stockLocation = new StockLocation();
                stockLocation.ID = stockLocationInfo.ID;
                stockLocation.Description = stockLocationInfo.Description;
                stockLocationInfoResponse.StockLocations.Add(stockLocation);
            }


            stockLocationInfoResponse.ConverterStream.Write(stockLocationInfoResponse);
        }

        public List<StockLocationInfo> StockLocationList { get { return this.stockLocationList; } }
    }
}
