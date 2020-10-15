using CareFusion.Mosaic.Converters.Wwks2.Messages;
using CareFusion.Mosaic.Interfaces.Converters;
using CareFusion.Mosaic.Interfaces.Messages.Input;
using CareFusion.Mosaic.Interfaces.Types.Articles;
using CareFusion.Mosaic.Interfaces.Types.Packs;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace StorageSystemSimulator.Cores
{
    public delegate void InputResponseReceivedEventHandler(object sender, StockInputResponse inputResponse);

    public class SimulatorInputCore
    {
        private int subscriberID;
        private List<IConverterStream> converterStreamList;
        private StorageSystemStock stock;

        private InitiateStockInputState initiateStockInputState;
        private InitiateStockInputResponse initiateStockInputWaitForInputResponse;

        public SimulatorInputCore()
        {
        }

        public void Initialize(List<IConverterStream> converterStreamList, StorageSystemStock stock)
        {
            this.converterStreamList = converterStreamList;
            this.stock = stock;
        }

        public void ScanPack(string tenantId, string stockLocationId, bool setPickingIndicator,
            bool isDeliveryInput, List<RobotPack> packs)
        {
            foreach (IConverterStream stream in this.converterStreamList)
            {
                if ((tenantId != stream.TenantID)
                    && (!string.IsNullOrEmpty(tenantId)))
                {
                    continue;
                }

                StockInputRequest inputRequest = new StockInputRequest(stream)
                {
                    ID = MessageId.Next,
                    Source = this.subscriberID, // default
                    Destination = int.Parse(stream.Destination),
                    SetPickingIndicator = setPickingIndicator,
                    IsDeliveryInput = isDeliveryInput
                };

                foreach (RobotPack pack in packs)
                {
                    pack.TenantID = tenantId;
                    if (!String.IsNullOrEmpty(stockLocationId))
                    {
                        pack.StockLocationID = stockLocationId;
                    }

                    int machineLocation;
                    if (int.TryParse(pack.MachineLocation, out machineLocation))
                    {
                        inputRequest.Source = machineLocation;
                    }
                    inputRequest.Packs.Add(pack);
                }

                stream.Write(inputRequest);
            }
        }

        public void SendInputMessage(string tenantId, StockInputResponse inputResponse,
            List<RobotPack> inputRequestPackList, bool isLoaded)
        {
            if (isLoaded)
            {
                this.stock.LoadInput(inputResponse);
            }

            var inputRequestPackListIsEmpty = inputRequestPackList == null || inputRequestPackList.Count == 0;

            foreach (IConverterStream stream in this.converterStreamList)
            {
                if (tenantId != stream.TenantID)
                {
                    continue;
                }

                StockInputMessage inputMessage = new StockInputMessage(stream)
                {
                    IsNewDelivery = inputResponse.IsDeliveryInput
                };
                inputMessage.AdoptHeader(inputResponse);

                inputMessage.Articles.AddRange(inputResponse.Articles.ToArray());
                inputMessage.Packs.AddRange(inputResponse.Packs.ToArray());



                for (int i = 0; i < inputMessage.Packs.Count; i++)
                {
                    inputMessage.Packs[i].Depth = 60;
                    inputMessage.Packs[i].Width = 60;
                    inputMessage.Packs[i].Height = 60;



                    if (!inputRequestPackListIsEmpty)
                    {
                        inputMessage.Packs[i].Shape = inputRequestPackList[i].Shape; //IT cannot define the shape.
                        inputMessage.Packs[i].MachineLocation =
                            inputRequestPackList[i].MachineLocation; //IT cannot define the Machine location.
                        inputMessage.Packs[i].TenantID =
                            inputRequestPackList[i].TenantID; //IT cannot define the tenant.
                    }

                    inputMessage.Handlings.Add(inputMessage.Packs[i],
                        isLoaded ? StockInputHandlingType.Completed : StockInputHandlingType.Aborted);
                }

                stream.Write(inputMessage);
            }


        }

        public void ProcessInputResponse(StockInputResponse inputReponse)
        {
            if (this.initiateStockInputWaitForInputResponse != null)
            {
                this.SendInputMessage(inputReponse.TenantID, inputReponse, inputReponse.Packs,
                    (this.initiateStockInputState == InitiateStockInputState.Accepted));

                InitiateStockInputMessage initiateStockInputMessage = new InitiateStockInputMessage();
                initiateStockInputMessage.AdoptHeader(initiateStockInputWaitForInputResponse);
                initiateStockInputMessage.InputSource = this.initiateStockInputWaitForInputResponse.InputSource;
                initiateStockInputMessage.InputPoint = this.initiateStockInputWaitForInputResponse.InputPoint;
                initiateStockInputMessage.Status = this.initiateStockInputState;

                initiateStockInputMessage.Articles.AddRange(this.initiateStockInputWaitForInputResponse.Articles);
                initiateStockInputMessage.Packs.AddRange(this.initiateStockInputWaitForInputResponse.Packs);

                if (this.initiateStockInputState != InitiateStockInputState.Accepted)
                {
                    StockInputError inputError = new StockInputError();
                    inputError.Type = StockInputErrorType.Rejected;
                    foreach (RobotPack pack in initiateStockInputMessage.Packs)
                    {
                        initiateStockInputMessage.PackErrors.Add(pack, inputError);
                    }
                }

                this.initiateStockInputWaitForInputResponse = null;
            }
            else
            {
                this.DoInputResponseReceived(inputReponse);
            }
        }

        public void ProcessInitiateStockInputRequest(InitiateStockInputRequest initiateInputRequest)
        {
            InitiateStockInputResponse initiateInputReponse = new InitiateStockInputResponse();
            initiateInputReponse.AdoptHeader(initiateInputRequest);
            initiateInputReponse.IsDeliveryInput = initiateInputRequest.IsDeliveryInput;
            initiateInputReponse.SetPickingIndicator = initiateInputRequest.SetPickingIndicator;
            initiateInputReponse.InputSource = initiateInputRequest.InputSource;
            initiateInputReponse.InputPoint = initiateInputRequest.InputPoint;
            initiateInputReponse.Status = this.initiateStockInputState;

            foreach (RobotPack pack in initiateInputRequest.Packs)
            {
                bool articleInfoFound = false;
                foreach (RobotArticle article in initiateInputReponse.Articles)
                {
                    if (article.Code == pack.RobotArticleCode)
                    {
                        articleInfoFound = true;
                        break;
                    }
                }

                if (!articleInfoFound)
                {
                    // get article Info
                    StorageSystemArticleInformation articleInformation =
                        this.stock.ArticleInformationList.GetArticleInformation(pack.RobotArticleCode, false);

                    if (articleInformation == null)
                    {
                        // article not found ? try with the scan code.
                        articleInformation = this.stock.ArticleInformationList.GetArticleInformation(pack.ScanCode, false);
                    }

                    if (articleInformation != null)
                    {
                        RobotArticle newArticle = new RobotArticle();
                        newArticle.Code = articleInformation.Code;
                        newArticle.Name = articleInformation.Name;
                        newArticle.DosageForm = articleInformation.DosageForm;
                        newArticle.PackagingUnit = articleInformation.PackagingUnit;
                        newArticle.MaxSubItemQuantity = articleInformation.MaxSubItemQuantity;
                        initiateInputReponse.Articles.Add(newArticle);
                    }
                }
            }

            initiateInputReponse.Packs.AddRange(initiateInputRequest.Packs);
            initiateInputReponse.ConverterStream.Write(initiateInputReponse);

            if (initiateInputReponse.Status == InitiateStockInputState.Accepted)
            {
                this.initiateStockInputWaitForInputResponse = initiateInputReponse;
                this.ScanPack(initiateInputReponse.TenantID,
                    "",
                    initiateInputRequest.SetPickingIndicator,
                    initiateInputRequest.IsDeliveryInput,
                    initiateInputReponse.Packs);
            }

        }

        public void SetSubscriberID(int subscriberID)
        {
            this.subscriberID = subscriberID;
        }

        private void DoInputResponseReceived(StockInputResponse inputResponse)
        {
            if (this.InputResponseReceived != null)
            {
                this.InputResponseReceived(this, inputResponse);
            }
        }

        public event InputResponseReceivedEventHandler InputResponseReceived;

        public InitiateStockInputState InitiateStockInputState { get { return this.initiateStockInputState; } set { this.initiateStockInputState = value; } }

    }
}
