using CareFusion.Lib.StorageSystem;
using CareFusion.Lib.StorageSystem.Input;
using CareFusion.Lib.StorageSystem.Output;
using CareFusion.Lib.StorageSystem.State;
using CareFusion.Lib.StorageSystem.Stock;
using System;
using System.Collections.Generic;

namespace StorageSystem.Sample
{
    class Program
    {
        static void Main(string[] args)
        {


            using (IStorageSystem storageSystem = new RowaStorageSystem())
            {
                /*DigitalShelfSample digitalShelfSample = new DigitalShelfSample();
                digitalShelfSample.Run();

                Console.WriteLine();
                Console.WriteLine("PRESS ENTER TO QUIT");
                Console.ReadLine();*/
                

                storageSystem.StateChanged += StorageSystem_StateChanged;
                //storageSystem.ComponentStateChanged += StorageSystem_ComponentStateChanged;
                storageSystem.PackDispensed += StorageSystem_PackDispensed;
                storageSystem.PackInputRequested += StorageSystem_PackInputRequested;
                storageSystem.PackStored += StorageSystem_PackStored;
                storageSystem.PackInputFinished += StorageSystem_PackInputFinished;
                storageSystem.StockUpdated += StorageSystem_StockUpdated;
                storageSystem.ArticleInfoRequested += StorageSystem_ArticleInfoRequested;

                Console.WriteLine("Connecting...");
                storageSystem.Connect("127.0.0.1", 6050);
                
                Console.WriteLine("Request stock without packs.");
                //var stockList = storageSystem.GetStock(true, true, "reiofjoi");

                Console.WriteLine("Request stock with packs.");
                //stockList = storageSystem.GetStock();
                
                Console.WriteLine("Request stock for a specific article.");
                //var stockList = storageSystem.GetStock(true, true, "Virtual-23458");
                /*stockList = storageSystem.GetStock(true, true, "126");
                stockList = storageSystem.GetStock(true, true, "1126");

                Console.WriteLine("Request state.");
                var state = storageSystem.State;*/

#warning Master article doesn't work yet.

                Console.WriteLine("Sending Master Article");
                var masterArticleList = new List<IMasterArticle>();
                
                masterArticleList.Add(storageSystem.CreateMasterArticle("47463736",
                        "Article Number 1",
                        "Dosage Form",
                        "Packaging Unit",
                        false,
                        0,
                        null,
                        null,
                        "Virtual-47463736",
                        "Virtual Article Number 1"));

                masterArticleList.Add(storageSystem.CreateMasterArticle("78695739",
                        "Article Number 2",
                        "Dosage Form",
                        "Packaging Unit"));
                storageSystem.UpdateMasterArticles(masterArticleList);
                
                /*Console.WriteLine("Output packs.");
                var output = storageSystem.CreateOutputProcess(1, 1);
                output.AddCriteria("123", 1);
                output.Finished += OutputProcess_Finished;
                output.Start();/**/

                /* System.Threading.Thread.Sleep(10000);

                  Console.WriteLine("Output packs and cancel outut process.");
                  output = storageSystem.CreateOutputProcess(124, 1);
                  output.AddCriteria("0004-24-017-W0015001", 2);
                  output.Finished += OutputProcess_Finished;
                  output.Start();
                  output.Cancel();


                  // retrieve the detailed information of output process 124 
                  IOutputProcessInfo outputInfo = storageSystem.GetOutputProcessInfo(124);

                  // retrieve the detailed information of stock delivery 1234 
                  IStockDeliveryInfo stockDeliveryInfo = storageSystem.GetStockDeliveryInfo("1234");


                  // create new input process with id 111 and input source 3 for destination 998
                  var initiateInput = storageSystem.CreateInitiateInputRequest(111, 3, 998);

                  // define a pack with the scan code "584638439" for input
                  initiateInput.AddInputPack("584638439");

                  // register for "Finished" event.
                  initiateInput.Finished += OnInitiateInput_Finished;

                  // start the input process
                  initiateInput.Start();*/


                Console.WriteLine();
                Console.WriteLine("PRESS ENTER TO QUIT");
                Console.ReadLine();

            }
        }

        static void OnInitiateInput_Finished(object sender, EventArgs e)
        {
            var initiateInput = sender as IInitiateInputRequest;
            
            if (initiateInput.State == InitiateInputRequestState.Completed)
            {
                // everything is ok -> access the list of processed articles
                // with detailed article and pack information of the affected packs
                var inputArticles = initiateInput.InputArticles;
            }
            else
            {
                // at least one pack failed to input
                foreach (var article in initiateInput.InputArticles)
                {
                    foreach (var pack in article.Packs)
                    {
                        string errorText;
                        InputErrorType errorType;
                        
                        if (initiateInput.GetProcessedPackError(pack, out errorType, out errorText))
                        {
                            // process pack error details
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Event which is raised when an output process finished execution.
        /// </summary>
        /// <param name="sender">Output process instance which raised the event.</param>
        /// <param name="e">Event parameters which are not used here.</param>
        static void OutputProcess_Finished(object sender, EventArgs e)
        {
            var output = sender as IOutputProcess;

            Console.WriteLine("Output process '{0}' finished with result '{1}'.", output.OrderNumber, output.State.ToString());

            foreach (var pack in output.Packs)
            {
                Console.WriteLine("Pack '{0}' with ScanCode '{1}' and StockInDate '{2}' was dispensed by output process {3}.", pack.Id, pack.ScanCode, pack.StockInDate.ToShortDateString(), output.OrderNumber);
            }
        }

        /// <summary>
        /// Event which is raised whenever the state of a storage system changes.
        /// </summary>
        /// <param name="sender">Object instance which raised the event.</param>
        /// <param name="state">New state of the storage system.</param>
        static void StorageSystem_StateChanged(IStorageSystem sender, ComponentState state)
        {
            Console.WriteLine("Storage system changed state to '{0}'.", state.ToString());
        }

        private static void StorageSystem_StockUpdated(IStorageSystem sender, IArticle[] articleList)
        {
            foreach (var article in articleList)
            {
                foreach (var pack in article.Packs)
                {
                    Console.WriteLine("Pack '{0}' with ScanCode '{1}' and StockInDate '{2}' Stock update.", pack.Id, pack.ScanCode, pack.StockInDate.ToShortDateString());
                }
            }
        }

        /// <summary>
        /// Event which is raised when detailed information for one or more articles is requested.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="articleList">List of articles request.</param>
        private static void StorageSystem_ArticleInfoRequested(IStorageSystem sender, IStorageSystemArticleInfoRequest request)
        {
            foreach (var article in request.ArticleList)
            {
                Console.WriteLine("Article Info Request for id '{0}', Depth '{1}', Width '{2}', Height '{3}', Weight {4}",
                    article.Id, article.Depth, article.Width, article.Height, article.Weight);

                List<string> productCodeList = new List<string>();
                productCodeList.Add("123-1");
                productCodeList.Add("123-2");
                productCodeList.Add("123-3");

                article.SetArticleInformation(article.Id,
                                            string.Format("My Article {0}", article.Id),
                                            "Dosage Form",
                                            "Packaging Unit",
                                            0,
                                            string.Format("Virtual-{0}", article.Id),
                                            string.Format("My Article {0}", article.Id),
                                            false,
                                            DateTime.Now,
                                            productCodeList);
            }
            request.Finish();
        }

        /// <summary>
        /// Event which is raised whenever the state of a storage system component changes.
        /// </summary>
        /// <param name="sender">Object instance which raised the event.</param>
        /// <param name="component">Component that has changed.</param>
        static void StorageSystem_ComponentStateChanged(IStorageSystem sender, IComponent component)
        {
            Console.WriteLine("Component '{0}' has changed state to '{1}'.", component.Description, component.State.ToString());
        }

        /// <summary>
        /// Event which is raised whenever a pack was dispensed by an output
        /// process that was not initiated by this storage system connection (e.g. at the UI of the storage system).
        /// </summary>
        /// <param name="sender">Object instance which raised the event.</param>
        /// <param name="articleList">List of articles with the packs that were dispensed.</param>
        static void StorageSystem_PackDispensed(IStorageSystem sender, IArticle[] articleList)
        {
            foreach (var article in articleList)
            {
                foreach (var pack in article.Packs)
                {
                    Console.WriteLine("Pack '{0}' with ScanCode '{1}' and StockInDate '{2}' has been dispensed by GUI.", pack.Id, pack.ScanCode, pack.StockInDate.ToShortDateString());
                }
            }

            Console.WriteLine("Requesting complete stock...");
            sender.GetStock();
            Console.WriteLine("Requesting complete stock finished.");
        }

        /// <summary>
        /// Event which is raised whenever a connected storage system requests
        /// permission for pack input. The specified request object is used to get further details about 
        /// the requested pack input and to allow or deny the pack input.
        /// </summary>
        /// <param name="sender">Object instance which raised the event.</param>
        /// <param name="request">Object which contains the details about the requested pack input.</param>
        static void StorageSystem_PackInputRequested(IStorageSystem sender, IInputRequest request)
        {
            // for now just accept every input request
            foreach (var pack in request.Packs)
            {
                Console.WriteLine("Pack '{0}' requested input via request '{1}' from source '{2}'.", pack.ScanCode, request.Id, request.Source);

                var articleCode = pack.ScanCode;
                if (articleCode.Length < 8)
                    articleCode = articleCode.PadLeft(8, '0');


                // set dummy article information
                pack.SetArticleInformation(articleCode,
                                            string.Format("My Article {0}", articleCode),
                                            "Dosage Form",
                                            "Packaging Unit",
                                            0,
                                            string.Format("Virtual-{0}", articleCode),
                                            string.Format("My Article {0}", articleCode));
                
                /*/pack.SetVirtualArticleInformation("Virtual_" + pack.ScanCode,
                            string.Format("My VirtualArticle {0}", pack.ScanCode),
                            "Dosage Form",
                            "Packaging Unit");*/
                

                // allow pack input
                pack.SetHandling(InputHandling.Allowed);
            }

            request.Finish();
        }

        /// <summary>
        /// Event which is raised whenever a new pack was successfully stored in a storage system. 
        /// </summary>
        /// <param name="sender">Object instance which raised the event.</param>
        /// <param name="articleList">List of articles with the packs that were stored.</param>
        static void StorageSystem_PackStored(IStorageSystem sender, IArticle[] articleList)
        {
            foreach (var article in articleList)
            {
                foreach (var pack in article.Packs)
                {
                    Console.WriteLine("Pack '{0}' with ScanCode '{1}' and StockInDate '{2}' has been stored in the storage system.", pack.Id, pack.ScanCode, pack.StockInDate.ToShortDateString());
                }
            }
        }

        private static void StorageSystem_PackInputFinished(IStorageSystem sender, int source, string inputRequestId, InputResult result, IArticle[] articleList)
        {
            Console.WriteLine("Input request '{0}' of source {1} finished with result '{2}'.", inputRequestId, source, result.ToString());
        }

    }
}
