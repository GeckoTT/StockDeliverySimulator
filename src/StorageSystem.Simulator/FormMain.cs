using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CareFusion.Mosaic.Interfaces.Connectors;
using CareFusion.Mosaic.Interfaces.Converters;
using CareFusion.Mosaic.Interfaces.Messages.ArticleInformation;
using CareFusion.Mosaic.Interfaces.Messages.Input;
using CareFusion.Mosaic.Interfaces.Messages.Status;
using CareFusion.Mosaic.Interfaces.Types.Articles;
using CareFusion.Mosaic.Interfaces.Types.Packs;
using CareFusion.Mosaic.Interfaces.Types.Input;
using CareFusion.Mosaic.Interfaces.Types.Output;
using StorageSystemSimulator.Cores;
using System.IO;
using System.Xml;
using System.Text;
using CareFusion.Mosaic.Connectors.Tcp;
using CareFusion.Mosaic.Converters.Wwks2;

namespace StorageSystemSimulator
{
    public partial class FormMain: Form
    {
        private StorageSystemSimulatorCore simulatorCore;
        private WwiLogger wwiLogger;
        private List<RobotPack> inputRequestPackList;
        private StockInputResponse inputInProgress = null;

        public FormMain()
        {
            InitializeComponent();
            this.simulatorCore = new StorageSystemSimulatorCore();
            this.simulatorCore.Load();

            this.simulatorCore.ConnectionAdd += this.StorageSystemSimulatorCore_ConnectionAdd;
            this.simulatorCore.ConnectionRemove += this.StorageSystemSimulatorCore_ConnectionRemove;
            this.simulatorCore.StreamAdd += this.StorageSystemSimulatorCore_StreamAdd;
            this.simulatorCore.StreamRemove += this.StorageSystemSimulatorCore_StreamRemove;
            this.simulatorCore.InputCore.InputResponseReceived += this.StorageSystemSimulatorCore_InputResponseReceived;
            this.simulatorCore.ArticleMasterSetCore.MasterArticleUpdated += this.StorageSystemSimulatorCore_MasterArticleUpdated;
            this.simulatorCore.StockDeliverySetCore.StockDeliveryUpdated += this.StorageSystemSimulatorCore_StockDeliveryUpdated;
            this.simulatorCore.Stock.StockUpdated += this.StorageSystemSimulatorCore_StockUpdated;
            this.simulatorCore.OutputCore.OutputOrderListUpdated += this.StorageSystemSimulatorCore_OutputOrderListUpdated;
            this.simulatorCore.ArticleInfoCore.ArticleInfoResponseReceived += this.ArticleInfoCore_ArticleInfoResponseReceived;

            this.wwiLogger = new WwiLogger();
            this.wwiLogger.WwiMessage += this.WwiLogger_WwiMessage;

            // tenant
            dataGridViewTenantList.AutoGenerateColumns = false;
            dataGridViewTenantList.DataSource = new BindingSource(this.simulatorCore.SimulatorTenant.TenantList, "");
            this.DataGridViewSetAutoSize(dataGridViewTenantList);

            // stock location
            dataGridViewStockLocationList.AutoGenerateColumns = false;
            dataGridViewStockLocationList.DataSource = new BindingSource(this.simulatorCore.SimulatorStockLocation.StockLocationList, "");
            this.DataGridViewSetAutoSize(dataGridViewStockLocationList);

            // Input
            this.inputRequestPackList = new List<RobotPack>();
            dataGridViewInputRequestPackList.AutoGenerateColumns = false;
            dataGridViewInputRequestPackList.DataSource = new BindingSource(inputRequestPackList, "");
            this.DataGridViewSetAutoSize(dataGridViewInputRequestPackList);

            // Master Article
            dataGridViewMasterArticle.AutoGenerateColumns = false;
            this.UpdateDataGridView(dataGridViewMasterArticle,
                this.simulatorCore.ArticleMasterSetCore.MasterArticleList);
            this.DataGridViewSetAutoSize(dataGridViewMasterArticle);

            // stock delivery
            dataGridViewStockDeliveryMaster.AutoGenerateColumns = false;
            this.UpdateDataGridView(dataGridViewStockDeliveryMaster,
                this.simulatorCore.StockDeliverySetCore.StockDeliveryList);
            dataGridViewStockDeliveryDetail.AutoGenerateColumns = false;
            this.DataGridViewSetAutoSize(dataGridViewStockDeliveryDetail);

            // Article Info
            dataGridViewArticleInfoArticleList.AutoGenerateColumns = false;
            this.UpdateDataGridView(dataGridViewArticleInfoArticleList,
                this.simulatorCore.ArticleInfoCore.ArticleList);
            this.DataGridViewSetAutoSize(dataGridViewArticleInfoArticleList);

            // Stock
            this.DataGridViewSetAutoSize(dataGridViewProductStock);
            this.UpdateDataGridView(dataGridViewProductStock,
                this.simulatorCore.Stock.ArticleInformationList.ArticlesAsList);
            dataGridViewPackStock.AutoGenerateColumns = false;
            this.DataGridViewSetAutoSize(dataGridViewPackStock);

            // Output
            dataGridViewOutputOrderList.AutoGenerateColumns = false;
            this.DataGridViewSetAutoSize(dataGridViewOutputOrderList);
            dataGridViewOutputOrderItems.AutoGenerateColumns = false;
            this.DataGridViewSetAutoSize(dataGridViewOutputOrderItems);
            dataGridViewOutputDispensedPack.AutoGenerateColumns = false;
            this.DataGridViewSetAutoSize(dataGridViewOutputDispensedPack);

            dateTimePickerMasterDataExpiryDate.Value = DateTime.Now.AddMonths(6);

            tabControl.TabPages.Remove(tabPage5);

            TcpInConnectorConfiguration tcpInConnectorConfiguration = new TcpInConnectorConfiguration();
            WwksConverterConfiguration wwksConverterConfiguration = new WwksConverterConfiguration();

            if (StorageSystemSerializer.LoadConnectionInformation("Connection.xml",
                tcpInConnectorConfiguration,
                wwksConverterConfiguration))
            {
                numericUpDownPort.Value = tcpInConnectorConfiguration.Port;

                numericUpDownSubscriberID.Value = wwksConverterConfiguration.SubscriberID;
                numericUpDownHandShakeTimeOut.Value = wwksConverterConfiguration.HandshakeTimeout;
                checkBoxEnableKeepAlive.Checked = wwksConverterConfiguration.EnableKeepAlive;
                numericUpDownKeepAliveInterval.Value = wwksConverterConfiguration.KeepAliveInterval;
                numericUpDownKeepAliveTimeout.Value = wwksConverterConfiguration.KeepAliveTimeOut;
                checkBoxUseExternalIdAsSerialNumber.Checked = wwksConverterConfiguration.UseExternalIdAsSerialNumber;
            }
        }

        private void StorageSystemSimulatorCore_ConnectionAdd(object sender, IConnection connection)
        {
            if (this.listViewConnections.InvokeRequired)
            {
                this.listViewConnections.BeginInvoke(new ConnectionAddEventHandler(StorageSystemSimulatorCore_ConnectionAdd),
                    new object[] { sender, connection });
                return;
            }

            ListViewItem newConnection = new ListViewItem(connection.EndPoint);
            newConnection.SubItems.Add("No");
            newConnection.Tag = connection;
            this.listViewConnections.Items.Add(newConnection);
        }

        private void StorageSystemSimulatorCore_ConnectionRemove(object sender, IConnection connection)
        {
            if (this.listViewConnections.InvokeRequired)
            {
                this.listViewConnections.BeginInvoke(new ConnectionRemoveEventHandler(StorageSystemSimulatorCore_ConnectionRemove),
                    new object[] { sender, connection });
                return;
            }

            foreach(ListViewItem item in this.listViewConnections.Items)
            {
                if (item.Tag == connection)
                {
                    this.listViewConnections.Items.Remove(item);
                }
            }
        }

        private void StorageSystemSimulatorCore_StreamAdd(object sender, IConverterStream stream)
        {
            if (this.listViewConnections.InvokeRequired)
            {
                this.listViewConnections.BeginInvoke(new StreamAddEventHandler(StorageSystemSimulatorCore_StreamAdd),
                    new object[] { sender, stream });
                return;
            }

            foreach (ListViewItem item in this.listViewConnections.Items)
            {
                if (item.Tag == stream.Connection)
                {
                    this.listViewConnections.Items.Remove(item);
                }
            }

            ListViewItem newStream = new ListViewItem(stream.Connection.EndPoint);
            newStream.SubItems.Add("Yes");
            newStream.SubItems.Add(stream.Destination);
            newStream.SubItems.Add(stream.TenantID);
            newStream.Tag = stream;
            this.listViewConnections.Items.Add(newStream);
        }

        private void StorageSystemSimulatorCore_StreamRemove(object sender, IConverterStream stream)
        {
            if (this.listViewConnections.InvokeRequired)
            {
                this.listViewConnections.BeginInvoke(new StreamRemoveEventHandler(StorageSystemSimulatorCore_StreamRemove),
                    new object[] { sender, stream });
                return;
            }

            foreach (ListViewItem item in this.listViewConnections.Items)
            {
                if (item.Tag == stream)
                {
                    this.listViewConnections.Items.Remove(item);
                }
            }
        }
        
        private void StorageSystemSimulatorCore_InputResponseReceived(object sender, StockInputResponse inputResponse)
        {
            if (this.listViewScannedPackInformation.InvokeRequired)
            {
                this.listViewScannedPackInformation.BeginInvoke(new InputResponseReceivedEventHandler(StorageSystemSimulatorCore_InputResponseReceived),
                    new object[] { sender, inputResponse });
                return;
            }

            bool allowToLoad = true;
            this.listViewScannedPackInformation.Items.Clear();

            foreach (RobotPack pack in inputResponse.Packs)
            {
                ListViewItem newScannedPack = new ListViewItem("");
                newScannedPack.SubItems.Add(pack.RobotArticleCode);

                RobotArticle foundArticle = null;

                foreach (RobotArticle article in inputResponse.Articles)
                {
                    if (article.Code == pack.RobotArticleCode)
                    {
                        foundArticle = article;
                    }
                }

                if (foundArticle != null)
                {
                    newScannedPack.SubItems.Add(foundArticle.Name);
                    newScannedPack.SubItems.Add(foundArticle.DosageForm);
                    newScannedPack.SubItems.Add(foundArticle.PackagingUnit);
                    newScannedPack.SubItems.Add(foundArticle.MaxSubItemQuantity.ToString());
                }
                else
                {
                    newScannedPack.SubItems.Add("");
                    newScannedPack.SubItems.Add("");
                    newScannedPack.SubItems.Add("");
                    newScannedPack.SubItems.Add("");
                }
                
                newScannedPack.SubItems.Add(pack.BatchNumber);
                newScannedPack.SubItems.Add(pack.ExpiryDate.ToString("dd/MM/yyyy"));
                newScannedPack.SubItems.Add(pack.ExternalID);
                newScannedPack.SubItems.Add(pack.SubItemQuantity.ToString());
                newScannedPack.SubItems.Add(pack.StockLocationID);
                newScannedPack.SubItems.Add((inputResponse.Handlings[pack].Handling == StockInputHandlingType.AllowedForFridge).ToString());

                newScannedPack.SubItems.Add(inputResponse.Handlings[pack].Handling.ToString());
                newScannedPack.SubItems.Add(inputResponse.Handlings[pack].Description);

                this.listViewScannedPackInformation.Items.Add(newScannedPack);

                allowToLoad &= ((inputResponse.Handlings[pack].Handling == StockInputHandlingType.Allowed)
                    || ((inputResponse.Handlings[pack].Handling == StockInputHandlingType.AllowedForFridge)
                        && (checkBoxAcceptFridge.Checked)));

                allowToLoad &= this.simulatorCore.SimulatorStockLocation.Contains(pack.StockLocationID);
            }

            if (checkBoxInputMessageAuto.Checked)
            {
                // send automaticaly message back.
                this.simulatorCore.InputCore.SendInputMessage(this.GetSelectedInputTenant(),
                    inputResponse, this.inputRequestPackList, allowToLoad);
                this.dataGridViewInputRequestPackList.Enabled = true;
            }
            else
            {
                // Enabled buttons to load the pack.
                this.inputInProgress = inputResponse;
                this.UpdateInputMessageButtons();
            }
        }

        private void StorageSystemSimulatorCore_MasterArticleUpdated(object sender, EventArgs e)
        {
            if (this.dataGridViewMasterArticle.InvokeRequired)
            {
                this.dataGridViewMasterArticle.BeginInvoke(new EventHandler(this.StorageSystemSimulatorCore_MasterArticleUpdated),
                    new object[] { sender });
                return;
            }

            this.UpdateDataGridView(dataGridViewMasterArticle,
                this.simulatorCore.ArticleMasterSetCore.MasterArticleList);
        }
        
        private void StorageSystemSimulatorCore_StockDeliveryUpdated(object sender, EventArgs e)
        {
            if (this.dataGridViewStockDeliveryMaster.InvokeRequired)
            {
                this.dataGridViewStockDeliveryMaster.BeginInvoke(new EventHandler(this.StorageSystemSimulatorCore_StockDeliveryUpdated),
                    new object[] { sender });
                return;
            }

            this.UpdateDataGridView(dataGridViewStockDeliveryMaster,
                this.simulatorCore.StockDeliverySetCore.StockDeliveryList);
        }

        private void StorageSystemSimulatorCore_StockUpdated(object sender, EventArgs e)
        {
            if (this.dataGridViewProductStock.InvokeRequired)
            {
                this.dataGridViewProductStock.BeginInvoke(new EventHandler(this.StorageSystemSimulatorCore_StockUpdated),
                    new object[] { sender });
                return;
            }

            this.UpdateDataGridView(dataGridViewProductStock,
                this.simulatorCore.Stock.ArticleInformationList.ArticlesAsList);

            if (this.simulatorCore.Stock.ArticleInformationList.ArticlesAsList.Count == 0)
            {
                dataGridViewPackStock.DataSource = new BindingSource();
            }
        }

        private void StorageSystemSimulatorCore_OutputOrderListUpdated(object sender, EventArgs e)
        {
            if (this.dataGridViewOutputOrderList.InvokeRequired)
            {
                this.dataGridViewOutputOrderList.BeginInvoke(new EventHandler(this.StorageSystemSimulatorCore_OutputOrderListUpdated),
                    new object[] { sender });
                return;
            }

            this.UpdateDataGridView(dataGridViewOutputOrderList,
                this.simulatorCore.OutputCore.OrderList);
            
            // update stock after output finishes.
            this.StorageSystemSimulatorCore_StockUpdated(sender, e);
        }

        private void ArticleInfoCore_ArticleInfoResponseReceived(object sender, ArticleInfoResponse articleInfoResponse)
        {
            if (this.listViewArticleInfoRequested.InvokeRequired)
            {
                this.listViewArticleInfoRequested.BeginInvoke(new ArticleInfoResponseReceivedEventHandler(ArticleInfoCore_ArticleInfoResponseReceived),
                    new object[] { sender, articleInfoResponse });
                return;
            }
            
            this.listViewArticleInfoRequested.Items.Clear();

            foreach (CareFusion.Mosaic.Converters.Wwks2.Types.Article article in articleInfoResponse.Articles)
            {
                ListViewItem newrequestedArticle = new ListViewItem(article.Id);
                newrequestedArticle.SubItems.Add(article.Name);
                newrequestedArticle.SubItems.Add(article.DosageForm);
                newrequestedArticle.SubItems.Add(article.PackagingUnit);
                newrequestedArticle.SubItems.Add(article.MaxSubItemQuantity.ToString());
                newrequestedArticle.SubItems.Add(article.SerialNumberSinceExpiryDate);

                string productCodes = String.Empty;
                foreach (CareFusion.Mosaic.Converters.Wwks2.Types.ProductCode productCode in article.ProductCode)
                {
                    productCodes += productCode.Code + ";";
                }

                newrequestedArticle.SubItems.Add(productCodes);
                this.listViewArticleInfoRequested.Items.Add(newrequestedArticle);
            }
        }

        private void WwiLogger_WwiMessage(object sender, string message, bool isIncommingMessage)
        {
            if (this.listViewWwks2Log.InvokeRequired)
            {
                this.listViewWwks2Log.BeginInvoke(new WwiMessageEventHandler(this.WwiLogger_WwiMessage),
                    new object[] { sender, message, isIncommingMessage });
                return;
            }
            ListViewItem listNewItem = new ListViewItem(DateTime.Now.ToString());
            listNewItem.SubItems.Add(isIncommingMessage ? "Received" : "Sent");
            listNewItem.SubItems.Add(message);
            listViewWwks2Log.Items.Add(listNewItem);
            listNewItem.EnsureVisible();
        }


        private void UpdateDataGridView(DataGridView dataGridView, object dataSource)
        {
            int? previousSelectedIndex = null;
            if (dataGridView.CurrentRow != null)
            {
                previousSelectedIndex = dataGridView.CurrentRow.Index;
            }

            dataGridView.DataSource = new BindingSource(dataSource, "");

            if ((previousSelectedIndex.HasValue)
                && (previousSelectedIndex.Value < dataGridView.Rows.Count))
            {
                dataGridView.Rows[previousSelectedIndex.Value].Selected = true;
                dataGridView.CurrentCell = dataGridView.Rows[previousSelectedIndex.Value].Cells[0];
            }
        }

        private void DataGridViewSetAutoSize(DataGridView dataGridView)
        {
            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            if (this.simulatorCore.IsListening)
            {
                this.simulatorCore.Stop();
                this.buttonConnect.Text = "Listen";
                this.dataGridViewTenantList.Enabled = true;
                btnSendRawXml.Enabled = true;
            }
            else
            {
                if (this.simulatorCore.Listen(
                    (int) numericUpDownPort.Value,
                    (int) numericUpDownSubscriberID.Value,
                    (int) numericUpDownHandShakeTimeOut.Value,
                    checkBoxEnableKeepAlive.Checked,
                    (int) this.numericUpDownKeepAliveInterval.Value,
                    (int) this.numericUpDownKeepAliveTimeout.Value,
                    checkBoxUseExternalIdAsSerialNumber.Checked))
                {
                    this.buttonConnect.Text = "Stop";
                    this.dataGridViewTenantList.Enabled = false;
                    btnSendRawXml.Enabled = true;

                    labelSelectInputTenant.Visible = (this.simulatorCore.SimulatorTenant.TenantList.Count > 0);
                    comboBoxInputSelectTenant.Visible = (this.simulatorCore.SimulatorTenant.TenantList.Count > 0);
                    comboBoxInputSelectTenant.DataSource = new BindingSource(this.simulatorCore.SimulatorTenant.TenantList, "");

                    labelSelectMasterDataTenant.Visible = (this.simulatorCore.SimulatorTenant.TenantList.Count > 0);
                    comboBoxMasterDataSelectTenant.Visible = (this.simulatorCore.SimulatorTenant.TenantList.Count > 0);
                    comboBoxMasterDataSelectTenant.DataSource = new BindingSource(this.simulatorCore.SimulatorTenant.TenantList, "");

                    labelArticleInfoSelectTenant.Visible = (this.simulatorCore.SimulatorTenant.TenantList.Count > 0);
                    comboBoxArticleInfoSelectTenant.Visible = (this.simulatorCore.SimulatorTenant.TenantList.Count > 0);
                    comboBoxArticleInfoSelectTenant.DataSource = new BindingSource(this.simulatorCore.SimulatorTenant.TenantList, "");

                    labelSelectInputLocation.Visible = (this.simulatorCore.SimulatorStockLocation.StockLocationList.Count > 1);
                    comboBoxInputSelectLocation.Visible = (this.simulatorCore.SimulatorStockLocation.StockLocationList.Count > 1);
                    comboBoxInputSelectLocation.DataSource = new BindingSource(this.simulatorCore.SimulatorStockLocation.StockLocationList, "");

                    labelSelectMasterDataLocation.Visible = (this.simulatorCore.SimulatorStockLocation.StockLocationList.Count > 1);
                    comboBoxMasterDataSelectLocation.Visible = (this.simulatorCore.SimulatorStockLocation.StockLocationList.Count > 1);
                    comboBoxMasterDataSelectLocation.DataSource = new BindingSource(this.simulatorCore.SimulatorStockLocation.StockLocationList, "");
                }
                else
                {
                    MessageBox.Show("The listening port is already blocked by another application");
                }
            }
        }
        
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.simulatorCore.IsListening)
            {
                this.simulatorCore.Stop();
            }
        }


        // status
        private void UpdateStatusComponent()
        {
            listViewStatusComponent.Items.Clear();

            foreach (StatusComponent statusComponent in this.simulatorCore.StatusCore.StatusSubComponentList)
            {
                ListViewItem statusComponentItem = new ListViewItem(statusComponent.Type);
                statusComponentItem.SubItems.Add(statusComponent.Description);
                statusComponentItem.SubItems.Add(statusComponent.State == StatusType.Ready? "Ready" : "Not Ready");
                statusComponentItem.SubItems.Add(statusComponent.StateDescription);
                statusComponentItem.Tag = statusComponent;

                listViewStatusComponent.Items.Add(statusComponentItem);
            }
        }
        
        private void radioButtonReady_CheckedChanged(object sender, EventArgs e)
        {
            this.simulatorCore.StatusCore.Status = this.radioButtonReady.Checked ? StatusType.Ready : StatusType.NotReady;
            this.simulatorCore.StatusCore.StateDescriptions = textBoxStatusText.Text;
        }

        private void buttonAddComponent_Click(object sender, EventArgs e)
        {
            AddStatusComponent form = new AddStatusComponent();
            
            if (form.ShowDialog() == DialogResult.OK)
            { 
                this.simulatorCore.StatusCore.StatusSubComponentList.Add(form.GetStatusComponent());
            }

            this.UpdateStatusComponent();
        }

        private void buttonRemoveComponent_Click(object sender, EventArgs e)
        {
            if (this.listViewStatusComponent.SelectedItems.Count >= 1)
            {
                this.simulatorCore.StatusCore.StatusSubComponentList.Remove(
                    (StatusComponent)this.listViewStatusComponent.SelectedItems[0].Tag);
            }

            this.UpdateStatusComponent();
        }


        // input
        private void dataGridViewInputRequestPackList_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells[this.ColumnMachineLocation.Index].Value = "999";
            e.Row.Cells[this.ColumnExpiryDate.Index].Value = DateTime.Now.AddMonths(6).ToString("dd/MM/yyyy");
            e.Row.Cells[this.ColumnShape.Index].Value = 0;
        }

        private void dataGridViewInputRequestPackList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            if (e.ColumnIndex == this.ColumnSelectShape.Index)
            {
                PackShape packShape = (PackShape)this.dataGridViewInputRequestPackList.CurrentRow.Cells[this.ColumnShape.Index].Value;
                FormSelectPackShape form = new FormSelectPackShape(packShape);

                if (form.ShowDialog() == DialogResult.OK)
                {
                    this.dataGridViewInputRequestPackList.CurrentRow.Cells[this.ColumnShape.Index].Value = form.GetSelectedShape();
                }
            }
        }

        private void dataGridViewInputRequestPackList_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == ColumnExpiryDate.Index)
            {
                DateTime validationDateTime = new DateTime();

                if (DateTime.TryParse((string)dataGridViewInputRequestPackList.Rows[e.RowIndex].Cells[ColumnExpiryDate.Index].Value, out validationDateTime))
                {
                    dataGridViewInputRequestPackList.Rows[e.RowIndex].Cells[ColumnHidenExpiryDate.Index].Value =
                        dataGridViewInputRequestPackList.Rows[e.RowIndex].Cells[ColumnExpiryDate.Index].Value;
                }
                else
                {
                    dataGridViewInputRequestPackList.Rows[e.RowIndex].Cells[ColumnHidenExpiryDate.Index].Value = null;
                }
            }
        }

        private void checkBoxInputMessageAuto_CheckedChanged(object sender, EventArgs e)
        {
            if ((this.inputInProgress != null)
                && (this.checkBoxInputMessageAuto.Checked))
            {
                if (this.IsInputInProgressAllowToLoad())
                {
                    this.buttonInputMessageLoad_Click(null, null);
                }
                else
                {
                    this.buttonInputMessageNotLoad_Click(null, null);
                }
            }

            this.UpdateInputMessageButtons();
        }

        private void checkBoxAcceptFridge_CheckedChanged(object sender, EventArgs e)
        {
            this.UpdateInputMessageButtons();
        }

        private void buttonScanPack_Click(object sender, EventArgs e)
        {
            if (this.inputRequestPackList.Count != 0)
            {
                if (this.inputInProgress != null)
                {
                    this.buttonInputMessageNotLoad_Click(null, null);
                }

                this.listViewScannedPackInformation.Items.Clear();
                this.dataGridViewInputRequestPackList.Enabled = false;
                this.simulatorCore.InputCore.ScanPack(this.GetSelectedInputTenant(), this.GetSelectedInputStockLocation(),
                    checkBoxSetPickingIndicator.Checked, checkBoxIsDeliveryInput.Checked, this.inputRequestPackList);
            }
        }

        private void buttonInputMessageLoad_Click(object sender, EventArgs e)
        {
            this.simulatorCore.InputCore.SendInputMessage(this.GetSelectedInputTenant(),
                this.inputInProgress, this.inputRequestPackList, true);
            this.inputInProgress = null;
            this.dataGridViewInputRequestPackList.Enabled = true;
            this.UpdateInputMessageButtons();
        }

        private void buttonInputMessageNotLoad_Click(object sender, EventArgs e)
        {
            this.simulatorCore.InputCore.SendInputMessage(this.GetSelectedInputTenant(),
                this.inputInProgress, this.inputRequestPackList, false);
            this.inputInProgress = null;
            this.dataGridViewInputRequestPackList.Enabled = true;
            this.UpdateInputMessageButtons();
        }

        private void UpdateInputMessageButtons()
        {
            if (this.inputInProgress != null)
            {
                this.buttonInputMessageLoad.Enabled = (!this.checkBoxInputMessageAuto.Checked) && this.IsInputInProgressAllowToLoad();
                this.buttonInputMessageNotLoad.Enabled = !this.checkBoxInputMessageAuto.Checked;
            }
            else
            {
                this.buttonInputMessageLoad.Enabled = false;
                this.buttonInputMessageNotLoad.Enabled = false;
            }
        }

        private bool IsInputInProgressAllowToLoad()
        {
            bool allowToLoad = true;
            foreach (RobotPack pack in this.inputInProgress.Packs)
            {
                allowToLoad &= ((this.inputInProgress.Handlings[pack].Handling == StockInputHandlingType.Allowed)
                    || ((this.inputInProgress.Handlings[pack].Handling == StockInputHandlingType.AllowedForFridge)
                        && (checkBoxAcceptFridge.Checked)));

                allowToLoad &= this.simulatorCore.SimulatorStockLocation.Contains(pack.StockLocationID);
            }

            return allowToLoad;
        }

        private string GetSelectedInputTenant()
        {
            string selectedTenantId = "";
            TenantInfo selectedTenant = (TenantInfo)comboBoxInputSelectTenant.SelectedItem;
            if (selectedTenant != null)
            {
                selectedTenantId = selectedTenant.ID;
            }

            return selectedTenantId;
        }

        private string GetSelectedInputStockLocation()
        {
            string selectedStockLocationId = "";
            StockLocationInfo selectedStockLocation = (StockLocationInfo)comboBoxInputSelectLocation.SelectedItem;
            if (selectedStockLocation != null)
            {
                selectedStockLocationId = selectedStockLocation.ID;
            }

            return selectedStockLocationId;
        }


        // initiate input
        private void radioButtonInitiateInputAccept_CheckedChanged(object sender, EventArgs e)
        {
            this.simulatorCore.InputCore.InitiateStockInputState = 
                this.radioButtonInitiateInputAccept.Checked ? InitiateStockInputState.Accepted : InitiateStockInputState.Rejected;
        }

        // Master article
        private void radioButtonMasterArticleAccept_CheckedChanged(object sender, EventArgs e)
        {
            this.simulatorCore.ArticleMasterSetCore.ArticleMasterResult = radioButtonMasterArticleAccept.Checked;
            this.simulatorCore.ArticleMasterSetCore.ArticleMasterResultText = textBoxMasterArticleText.Text;
        }

        private void dataGridViewMasterArticle_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            if (e.ColumnIndex == this.dataGridViewMasterArticleLoadPack.Index)
            {
                TenantInfo selectedTenant = (TenantInfo)comboBoxMasterDataSelectTenant.SelectedItem;
                StockLocationInfo selectedStockLocationInfo = (StockLocationInfo)comboBoxMasterDataSelectLocation.SelectedItem;
                PISArticle pisArticle = (dataGridViewMasterArticle.Rows[e.RowIndex].DataBoundItem as PISArticle);
                this.simulatorCore.Stock.LoadInput(pisArticle.Code,
                    pisArticle.Name,
                    pisArticle.DosageForm,
                    pisArticle.PackagingUnit,
                    pisArticle.MaxSubItemQuantity,
                    textBoxMasterDataBatchNumber.Text,
                    textBoxMasterDataExternalID.Text,
                    dateTimePickerMasterDataExpiryDate.Value,
                    (int)numericUpDownSubItemQuantity.Value,
                    numericUpDownMasterDataMachineLocation.Value.ToString(),
                    (selectedTenant != null) ? selectedTenant.ID : "",
                    (selectedStockLocationInfo != null) ? selectedStockLocationInfo.ID : "");
            }
        }

        // stock delivery
        private void radioButtonStockDeliveryAccept_CheckedChanged(object sender, EventArgs e)
        {
            this.simulatorCore.StockDeliverySetCore.StockDeliveryResult = radioButtonStockDeliveryAccept.Checked;
            this.simulatorCore.StockDeliverySetCore.StockDeliveryResultText = textBoxStockDeliveryText.Text;
        }

        private void dataGridViewStockDeliveryMaster_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            StockDelivery stockDelivery = (dataGridViewStockDeliveryMaster.Rows[e.RowIndex].DataBoundItem as StockDelivery);
            dataGridViewStockDeliveryDetail.DataSource = new BindingSource(stockDelivery.Items, "");
        }

        private void dataGridViewStockDeliveryMaster_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            if (e.ColumnIndex == this.ColumnStockDeliveryMasterComplete.Index)
            {
                StockDelivery stockDelivery = (dataGridViewStockDeliveryMaster.CurrentRow.DataBoundItem as StockDelivery);

                this.simulatorCore.StockDeliverySetCore.CompleteDelivery(stockDelivery);

                //update UI.
                this.StorageSystemSimulatorCore_StockDeliveryUpdated(this, null);
            }
        }
        
        private void dataGridViewStockDeliveryDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            if (e.ColumnIndex == this.ColumnStockDeliveryLoadPack.Index)
            {
                StockDelivery stockDelivery = (dataGridViewStockDeliveryMaster.CurrentRow.DataBoundItem as StockDelivery);
                StockDeliveryItem stockDeliveryItem = (dataGridViewStockDeliveryDetail.Rows[e.RowIndex].DataBoundItem as StockDeliveryItem);
                
                this.simulatorCore.StockDeliverySetCore.LoadStockDeliveryItem(stockDelivery, stockDeliveryItem);
                
                //update UI.
                this.StorageSystemSimulatorCore_StockDeliveryUpdated(this, null);
            }
        }

        // Article Info
        private void buttonSendArticleInfoRequest_Click(object sender, EventArgs e)
        {
            string selectedTenantId = "";
            TenantInfo selectedTenant = (TenantInfo)comboBoxArticleInfoSelectTenant.SelectedItem;
            if (selectedTenant != null)
            {
                selectedTenantId = selectedTenant.ID;
            }

            this.simulatorCore.ArticleInfoCore.SendArticleInfoRequest(selectedTenantId);
        }

        private void listViewArticleInfoRequested_SizeChanged(object sender, EventArgs e)
        {
            var columnWidth = (listViewArticleInfoRequested.Width - 35) / listViewArticleInfoRequested.Columns.Count;

            for (int i = 0; i < listViewArticleInfoRequested.Columns.Count; ++i)
                listViewArticleInfoRequested.Columns[i].Width = columnWidth;
        }

        // Inventory checking
        private void buttonLoadStock_Click(object sender, EventArgs e)
        {
            if (openFileDialogLoadStock.ShowDialog(this) == DialogResult.OK)
            {
                this.simulatorCore.Stock.LoadStock(openFileDialogLoadStock.FileName);
            }
        }

        private void buttonClearStock_Click(object sender, EventArgs e)
        {
            this.simulatorCore.Stock.ClearStock();
        }

        private void dataGridViewProductStock_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            string ArticleCode = (dataGridViewProductStock.Rows[e.RowIndex].DataBoundItem as StorageSystemArticleInformation).Code;
            StockProduct stockProduct = this.simulatorCore.Stock.GetStockProduct(ArticleCode);

            dataGridViewPackStock.DataSource = new BindingSource(stockProduct.GetPackList(""), "");
        }

        private void dataGridViewProductStock_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            for (int index = e.RowIndex; index <= e.RowIndex + e.RowCount - 1; index++)
            {
                string ArticleCode = (dataGridViewProductStock.Rows[index].DataBoundItem as StorageSystemArticleInformation).Code;
                StockProduct stockProduct = this.simulatorCore.Stock.GetStockProduct(ArticleCode);
                dataGridViewProductStock.Rows[index].Cells["dataGridViewTextBoxColumnStockListPackCount"].Value = stockProduct.GetPackList("").Count;
            }
        }
        
        private void dataGridViewProductStock_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            //Pack selectedPack = (dataGridViewPackStock.Rows[e.RowIndex].DataBoundItem as Pack);

            if (e.ColumnIndex == this.ColumnSendStockInfoMessage.Index)
            {
                this.simulatorCore.StockInfoCore.SendStockInfoMessage((dataGridViewProductStock.Rows[e.RowIndex].DataBoundItem as StorageSystemArticleInformation).Code);
            }
        }

        private void dataGridViewPackStock_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            RobotPack selectedPack = (dataGridViewPackStock.Rows[e.RowIndex].DataBoundItem as RobotPack);

            if (e.ColumnIndex == this.ColumnStockOutputPack.Index)
            {
                this.simulatorCore.OutputCore.DirectOutput(selectedPack);
            }

            if (e.ColumnIndex == this.ColumnStockDeletePack.Index)
            {
                StockProduct stockProduct = this.simulatorCore.Stock.GetStockProduct(selectedPack.RobotArticleCode);
                stockProduct.RemoveItem(selectedPack);
                List<RobotPack> productPackList = stockProduct.GetPackList("");
                this.UpdateDataGridView(dataGridViewPackStock, productPackList);

                dataGridViewProductStock.CurrentRow.Cells["dataGridViewTextBoxColumnStockListPackCount"].Value = productPackList.Count;
            }
        }
        
        // Output
        private void checkBoxOutputAutoReply_CheckedChanged(object sender, EventArgs e)
        {
            this.simulatorCore.OutputCore.EnableAutoReply = checkBoxOutputAutoReply.Checked;
        }

        private void checkBoxOutputGenerateBoxID_CheckedChanged(object sender, EventArgs e)
        {
            this.simulatorCore.OutputCore.GenerateBoxId = checkBoxOutputGenerateBoxID.Checked;
        }

        private void radioButtonStockOutputAlwaysComplete_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonStockOutputAlwaysComplete.Checked)
            {
                this.simulatorCore.OutputCore.OutputResult = OutputResult.AlwaysComplete;
            }
            if (radioButtonStockOutputAlwaysIncomplete.Checked)
            {
                this.simulatorCore.OutputCore.OutputResult = OutputResult.AlwaysIncomplete;
            }
            if (radioButtonStockOutputFrozenStock.Checked)
            {
                this.simulatorCore.OutputCore.OutputResult = OutputResult.FrozenStock;
            }
            if (radioButtonStockOutputUpdateStock.Checked)
            {
                this.simulatorCore.OutputCore.OutputResult = OutputResult.Normal;
            }
        }
        
        private void dataGridViewOutputOrderList_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            SimulatorOutputOrder selectedOrder = (SimulatorOutputOrder)dataGridViewOutputOrderList.Rows[e.RowIndex].DataBoundItem;
            dataGridViewOutputOrderItems.DataSource = new BindingSource(selectedOrder.Items, "");

            if (selectedOrder.Items.Count == 0)
            {
                // if nothing is requested, make sure to clear the dispensed pack.
                dataGridViewOutputDispensedPack.DataSource = new BindingSource();
            }
        }

        private void dataGridViewOutputOrderItems_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            StockOutputOrderItem selectedItem = (StockOutputOrderItem)dataGridViewOutputOrderItems.Rows[e.RowIndex].DataBoundItem;
            dataGridViewOutputDispensedPack.DataSource = new BindingSource(selectedItem.Packs, "");
        }


        // log
        private void listViewWwks2Log_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listViewWwks2Log.SelectedItems.Count == 1)
            {
                MemoryStream memoryStream = new MemoryStream();
                XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.Unicode);
                xmlTextWriter.Formatting = Formatting.Indented;

                XmlDocument xmlDocument = new XmlDocument();

                try
                {
                    // Load the XmlDocument with the XML.
                    xmlDocument.LoadXml(((this.listViewWwks2Log.SelectedItems[0]).SubItems[2]).Text);

                    // Write the XML into a formatting XmlTextWriter
                    xmlDocument.WriteContentTo(xmlTextWriter);
                    xmlTextWriter.Flush();
                    memoryStream.Flush();

                    // Have to rewind the MemoryStream in order to read
                    // its contents.
                    memoryStream.Position = 0;

                    // Read MemoryStream contents into a StreamReader.
                    StreamReader streamReader = new StreamReader(memoryStream);

                    // Extract the text from the StreamReader.
                    richTextBoxDetailLog.Text = streamReader.ReadToEnd();
                }
                catch (XmlException)
                {
                }

                memoryStream.Close();
                xmlTextWriter.Close();
            }
        }

        private void listViewWwks2Log_SizeChanged(object sender, EventArgs e)
        {
            listViewWwks2Log.Columns[2].Width = listViewWwks2Log.Width - 35 - listViewWwks2Log.Columns[0].Width - listViewWwks2Log.Columns[1].Width;
        }

        private void buttonSaveSimulatorState_Click(object sender, EventArgs e)
        {
            this.simulatorCore.Save();
        }

        private void buttonClearSavedState_Click(object sender, EventArgs e)
        {
            this.simulatorCore.ClearSavedState();
        }

        private void listViewScannedPackInformation_SizeChanged(object sender, EventArgs e)
        {
            var columnWidth = (listViewScannedPackInformation.Width - 35) / listViewScannedPackInformation.Columns.Count;

            for (int i = 0; i < listViewScannedPackInformation.Columns.Count; ++i)
                listViewScannedPackInformation.Columns[i].Width = columnWidth;
        }

        private void checkBoxEnableKeepAlive_CheckedChanged(object sender, EventArgs e)
        {
            StopAndStartListen(sender, e);
        }

        private void numericUpDownKeepAliveInterval_ValueChanged(object sender, EventArgs e)
        {
            StopAndStartListen(sender, e);
        }

        private void numericUpDownKeepAliveTimeout_ValueChanged(object sender, EventArgs e)
        {
            StopAndStartListen(sender, e);
        }

        private void checkBoxUseExternalIdAsSerialNumber_CheckedChanged(object sender, EventArgs e)
        {
            StopAndStartListen(sender, e);
        }

        private void StopAndStartListen(object sender, EventArgs e)
        {
            if (this.simulatorCore.IsListening)
            {
                this.simulatorCore.Stop();
                buttonConnect_Click(sender, e);
            }
        }

        private void btnSendRawXml_Click(object sender, EventArgs e)
        {
            this.simulatorCore.RawXmlCore.SendRaw(Encoding.UTF8.GetBytes(txtRawXml.Text));
        }

        private void txtRawXml_TextChanged(object sender, EventArgs e)
        {
            if (this.simulatorCore.IsListening)
            {
                btnSendRawXml.Enabled = String.IsNullOrWhiteSpace(txtRawXml.Text) ? false : true;
            }
            else
            {
                btnSendRawXml.Enabled = false;
            }
        }

        private void btnClearRawXml_Click(object sender, EventArgs e)
        {
            txtRawXml.Clear();
        }

    }
}
