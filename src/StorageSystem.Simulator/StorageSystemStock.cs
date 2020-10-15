using CareFusion.Mosaic.Interfaces.Messages.Input;
using CareFusion.Mosaic.Interfaces.Types.Packs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;

namespace StorageSystemSimulator
{
    [DataContract]
    public class StockProduct
    {
        [DataMember]
        private List<RobotPack> stockPackList;
        // here add product info

        public StockProduct()
        {
            this.stockPackList = new List<RobotPack>();
        }
        
        public void AddItem(RobotPack packInfo)
        {
            this.stockPackList.Add(packInfo);
        }

        public void RemoveItem(RobotPack packInfo)
        {
            this.stockPackList.Remove(packInfo);
        }

        public List<RobotPack> GetPackList(string tenantID)
        {
            List<RobotPack> result = new List<RobotPack>();

            foreach (RobotPack pack in this.stockPackList)
            {
                bool matchFilters = true;

                matchFilters = String.IsNullOrEmpty(tenantID) ? matchFilters : pack.TenantID == tenantID;

                if (matchFilters)
                {
                    result.Add(pack);
                }
            }

            return result;
        }

        public List<RobotPack> GetPackList(
            string batchNumber,
            string externalID,
            string machineLocation,
            string stockLocationID,
            long packID,
            string tenantID)
        {
            List<RobotPack> result = new List<RobotPack>();

            foreach (RobotPack pack in this.stockPackList)
            {
                bool matchFilters = true;

                matchFilters &= String.IsNullOrEmpty(batchNumber) ? matchFilters : pack.BatchNumber == batchNumber;
                matchFilters &= String.IsNullOrEmpty(externalID) ? matchFilters : pack.ExternalID == externalID;
                matchFilters &= String.IsNullOrEmpty(machineLocation) ? matchFilters : pack.MachineLocation == machineLocation;
                matchFilters &= String.IsNullOrEmpty(stockLocationID) ? matchFilters : pack.StockLocationID == stockLocationID;
                matchFilters &= (packID == 0) ? matchFilters : pack.ID == packID;
                matchFilters &= String.IsNullOrEmpty(tenantID) ? matchFilters : pack.TenantID == tenantID;

                if (matchFilters)
                {
                    result.Add(pack);
                }
            }

            return result;
        }
    }

    [DataContract]
    public class StorageSystemStock
    {
        [DataMember]
        private int nextPackId = 1;
        [DataMember]
        private Dictionary<string, StockProduct> stockProductList;
        [DataMember]
        private StorageSystemArticleInformationList articleInformationList;
        
        public StorageSystemStock()
        {
            this.stockProductList = new Dictionary<string, StockProduct>();
            this.articleInformationList = new StorageSystemArticleInformationList();
        }

        public void LoadInput(StockInputResponse inputResponse)
        {
            // 1 add Item to the stock.
            for (int i = 0; i < inputResponse.Packs.Count; i++)
            {
                StockProduct currentStockProduct = this.GetStockProduct(inputResponse.Packs[i].RobotArticleCode);
                inputResponse.Packs[i].ID = this.GetNextPackID();
                currentStockProduct.AddItem(inputResponse.Packs[i]);
            }

            // 2 update Article Information
            for (int i = 0; i < inputResponse.Articles.Count; i++)
            {
                StorageSystemArticleInformation currentArticleInformation =
                    this.articleInformationList.GetArticleInformation(inputResponse.Articles[i].Code, true);
                currentArticleInformation.Name = inputResponse.Articles[i].Name;
                currentArticleInformation.DosageForm = inputResponse.Articles[i].DosageForm;
                currentArticleInformation.PackagingUnit = inputResponse.Articles[i].PackagingUnit;
                currentArticleInformation.MaxSubItemQuantity = inputResponse.Articles[i].MaxSubItemQuantity;
            }

            // 3 forward stock update Event.
            this.DoStockUpdated();
        }

        public void LoadInput(string articleCode,
            string articleName,
            string articleDosageForm,
            string articlePackagingUnit,
            int articleMaxSubItemQuantity,
            string batchNumber,
            string externalID,
            DateTime expiryDate,
            int subItemQuantity,
            string machineLocation,
            string tenantID,
            string stockLocationInfoID,
            bool updateUI = true)
        {
            // 1 add Item to the stock.
            StockProduct currentStockProduct = this.GetStockProduct(articleCode);
            RobotPack pack = new RobotPack();
            
            pack.RobotArticleCode = articleCode;
            pack.ID = this.GetNextPackID();
            pack.Depth = 60;
            pack.Height = 60;
            pack.Width = 60;
            pack.Shape = PackShape.Cuboid;

            pack.BatchNumber = batchNumber;
            pack.ExternalID = externalID;
            pack.ExpiryDate = expiryDate;
            pack.SubItemQuantity = subItemQuantity;
            pack.MachineLocation = machineLocation;
            pack.StockLocationID = stockLocationInfoID;
            pack.TenantID = tenantID;
            currentStockProduct.AddItem(pack);
            
            // 2 update Article Information
            StorageSystemArticleInformation currentArticleInformation =
                this.articleInformationList.GetArticleInformation(articleCode, true);
            currentArticleInformation.Name = articleName;
            currentArticleInformation.DosageForm = articleDosageForm;
            currentArticleInformation.PackagingUnit = articlePackagingUnit;
            currentArticleInformation.MaxSubItemQuantity = articleMaxSubItemQuantity;

            // 3 forward stock update Event.
            if (updateUI)
            {
                this.DoStockUpdated();
            }
        }

        public StockProduct GetStockProduct(string productID)
        {
#warning keep that, but change it to PIS code/robot code.
#warning have it return a list of StockProduct related to that code.
#warning StockProduct instance should be share on the article tree. 

            if (!this.stockProductList.ContainsKey(productID))
            {
                this.stockProductList.Add(productID, new StockProduct());
            }

            return this.stockProductList[productID];
        }

        public int GetNextPackID()
        {
            return this.nextPackId++;
        }
        
        public void LoadStock(string fileName)
        {
            this.ClearStock();

            string[] lines = null;
            using (StreamReader reader = new StreamReader(fileName))
            {
                lines = reader.ReadToEnd().Split('\r','\n');
                reader.Close();
            }

#warning this doesn't work for other languague.
            if(lines[0] == "Pos.;Number;Sub-quantity;Barcode;\"Article name\";\"Dosage form\";\"Packing unit\"")
            {
                // don't process the title line.
                lines[0] = "";
            }

            foreach (string line in lines)
            {
                if (!String.IsNullOrEmpty(line))
                {
                    string[] fields = Regex.Split(line, ";(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)");

                    int packCount = int.Parse(fields[1]);

                    string articleName = fields[4].Trim('\"');
                    string articleDosageForm = fields[5].Trim('\"');
                    string articlePackagingUnit = fields[6].Trim('\"');
                    
                    string[] SubQuantityInfo = fields[2].Split('|');
                    int subItemPackCount = int.Parse(SubQuantityInfo[0].Trim('\"'));
                    int subItemQuantity = int.Parse(SubQuantityInfo[1].Trim('\"'));

                    for(int i = 0; i < (packCount - subItemPackCount); i++)
                    {
                        this.LoadInput(fields[3],
                            articleName,
                            articleDosageForm,
                            articlePackagingUnit,
                            0,
                            String.Empty,
                            String.Empty,
                            DateTime.Now.AddMonths(6),
                            0,
                            "999",
                            String.Empty,
                            String.Empty,
                            false);
                    }

                    int loadedSubQuantity = 0;
                    for (int i = 0; i < subItemPackCount; i++)
                    {
                        int subQuantityToLoad = 0;

                        if (i == (subItemPackCount - 1))
                        {
                            // last loop we must load what remains
                            subQuantityToLoad = subItemQuantity - loadedSubQuantity;
                        }
                        else
                        {
                            subQuantityToLoad = (int)Math.Floor((decimal)subItemQuantity / subItemPackCount);
                            loadedSubQuantity += subQuantityToLoad;
                        }

                        this.LoadInput(fields[3],
                            articleName,
                            articleDosageForm,
                            articlePackagingUnit,
                            0,
                            String.Empty,
                            String.Empty,
                            DateTime.Now.AddMonths(6),
                            subQuantityToLoad,
                            "999",
                            String.Empty,
                            String.Empty,
                            false);
                    }

                }
            }

            this.DoStockUpdated();
        }

        public void ClearStock()
        {
            this.stockProductList.Clear();
            this.articleInformationList.Clear();
            this.DoStockUpdated();
        }

        private void DoStockUpdated()
        {
            if (this.StockUpdated != null)
            {
                this.StockUpdated(this, null);
            }
        }

        public Dictionary<string, StockProduct> StockProductList { get { return this.stockProductList; } }

        public StorageSystemArticleInformationList ArticleInformationList { get { return this.articleInformationList; } }
        
        public event EventHandler StockUpdated;
    }
}
