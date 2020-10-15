using CareFusion.Mosaic.Converters.Wwks2.Messages;
using CareFusion.Mosaic.Interfaces.Converters;
using CareFusion.Mosaic.Interfaces.Messages.Stock;
using CareFusion.Mosaic.Interfaces.Types.Articles;
using CareFusion.Mosaic.Interfaces.Types.Packs;
using System;
using System.Collections.Generic;

namespace StorageSystemSimulator.Cores
{
    public class SimulatorStockInfoCore
    {
        private List<IConverterStream> converterStreamList;
        private StorageSystemStock stock;


        public SimulatorStockInfoCore()
        {
        }

        public void Initialize(List<IConverterStream> converterStreamList, StorageSystemStock stock)
        {
            this.converterStreamList = converterStreamList;
            this.stock = stock;
        }


        public void ProcessStockInfoRequest(StockInfoRequest stockInfoRequest)
        {
            StockInfoResponse stockInfoResponse = new StockInfoResponse(stockInfoRequest.ConverterStream);
            stockInfoResponse.AdoptHeader(stockInfoRequest);

            foreach (StockInfoCriteria criteria in stockInfoRequest.Criteria)
            {
                List<StockProduct> matchingProduct;

                var articleCode = String.IsNullOrWhiteSpace(criteria.RobotArticleCode) ? 
                    criteria.PISArticleCode : criteria.RobotArticleCode;

                if (String.IsNullOrEmpty(articleCode))
                {
                    matchingProduct = new List<StockProduct>(this.stock.StockProductList.Values);
                }
                else
                {
                    matchingProduct = new List<StockProduct>
                    {
                        this.stock.GetStockProduct(articleCode)
                    };
                }

#warning to do test Tenant change
                foreach (StockProduct stockProduct in matchingProduct)
                {
                    List<RobotPack> stockPackList = stockProduct.GetPackList(
                        criteria.BatchNumber,
                        criteria.ExternalID,
                        criteria.MachineLocation,
                        criteria.StockLocationID,
                        0,
                        stockInfoRequest.TenantID);

                    stockInfoResponse.Packs.AddRange(stockPackList);
                }
            }

            if (stockInfoRequest.Criteria.Count == 0)
            {
                // load all stock.

                foreach (KeyValuePair<string, StockProduct> stockProduct in this.stock.StockProductList)
                {
                    stockInfoResponse.Packs.AddRange(stockProduct.Value.GetPackList(stockInfoRequest.TenantID));
                }
            }
            
            // add article information
            stockInfoResponse.Articles.AddRange(this.BuildArticleList(stockInfoResponse.Packs, stockInfoRequest.IncludeArticleDetails));
            
            if (!stockInfoRequest.IncludePacks)
            {
                stockInfoResponse.Packs.Clear();
            }

            stockInfoResponse.ConverterStream.Write(stockInfoResponse);
        }

        public void SendStockInfoMessage(string productID)
        {
            // send a StockInfoMessage to every PMR conencted  for there related tenant stock.
            foreach (IConverterStream stream in this.converterStreamList)
            {
                StockInfoMessage stockInfoMessage = new StockInfoMessage(stream)
                {
                    ID = MessageId.Next,
                    TenantID = stream.TenantID,
                    Source = 999, // 999 is Mosaic
                    Destination = 100,
                    StockInfoType = StockInfoType.StockUpdate
                };

                StockProduct stockProduct = this.stock.GetStockProduct(productID);
                stockInfoMessage.Packs.AddRange(stockProduct.GetPackList(stream.TenantID));
                stockInfoMessage.Articles.AddRange(this.BuildArticleList(stockInfoMessage.Packs, true));

                stream.Write(stockInfoMessage);
            }
        }
        private List<RobotArticle> BuildArticleList(List<RobotPack> packList, bool includeArticleDetails)
        {
            List<RobotArticle> articleList = new List<RobotArticle>();

            foreach (RobotPack pack in packList)
            {
                RobotArticle currentArticle = null;

                foreach (RobotArticle Article in articleList)
                {
                    if (Article.Code == pack.RobotArticleCode)
                    {
                        currentArticle = Article;
                        break;
                    }
                }

                if (currentArticle == null)
                {
                    if (includeArticleDetails)
                    {
                        StorageSystemArticleInformation articleInformation = this.stock.ArticleInformationList.GetArticleInformation(pack.RobotArticleCode, false);
                        currentArticle = new RobotArticle
                        {
                            Code = articleInformation.Code,
                            Name = articleInformation.Name,
                            DosageForm = articleInformation.DosageForm,
                            PackagingUnit = articleInformation.PackagingUnit,
                            MaxSubItemQuantity = articleInformation.MaxSubItemQuantity
                        };
                        articleList.Add(currentArticle);
                    }
                    else
                    {
                        currentArticle = new RobotArticle
                        {
                            Code = pack.RobotArticleCode
                        };
                        articleList.Add(currentArticle);
                    }
                }

                currentArticle.PackCount++;
            }

            return articleList;
        }
    }
}
