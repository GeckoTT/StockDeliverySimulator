using System;
using System.Windows.Forms;
using CareFusion.Lib.StorageSystem;
using System.Collections.Generic;
using System.ComponentModel;
using CareFusion.Lib.StorageSystem.Stock;
using System.Data;
using CareFusion.Lib.StorageSystem.Input;
using Microsoft.Win32;
using CareFusion.Lib.StorageSystem.State;
using CareFusion.Lib.StorageSystem.Sales;

namespace CareFusion.ITSystemSimulator
{
    #region Predefined Delegates

    /// <summary>
    /// Delegate definition for a log entry writer.
    /// </summary>
    /// <param name="format">Format string of the log.</param>
    /// <param name="args">Format arguments of the log.</param>
    public delegate void WriteLog(string format, params object[] args);

    #endregion

    /// <summary>
    /// The IT system simulator main form.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class FMain : Form
    {
        #region Members

        /// <summary>
        /// Holds the reference to the storage system instance.
        /// </summary>
        private IStorageSystem _storageSystem;

        /// <summary>
        /// Holds the reference to the digital shelf instance.
        /// </summary>
        private IDigitalShelf _digitalShelf = new RowaDigitalShelf();

        /// <summary>
        /// Holds the reference to the digital shelf instance.
        /// </summary>
        private IShoppingCartUpdateRequest _currentShoppingCartUpdateRequest = null;


        /// <summary>
        /// Holds the stock model for the stock overview.
        /// </summary>
        private StockModel _stockModel = new StockModel();

        /// <summary>
        /// Holds the master article data model.
        /// </summary>
        private MasterArticleModel _masterArticleModel = new MasterArticleModel();

        /// <summary>
        /// Holds the stock delivery data model.
        /// </summary>
        private StockDeliveryModel _stockDeliveryModel = new StockDeliveryModel();

        /// <summary>
        /// Holds the output order model for the output overview.
        /// </summary>
        private OrderModel _orderModel;

        /// <summary>
        /// Holds the list of currently active initiated inputs.
        /// </summary>
        private List<IInitiateInputRequest> _activeInitiatedInputs = new List<IInitiateInputRequest>();

        /// <summary>
        /// Holds the task information model for the task overview.
        /// </summary>
        private TaskModel _taskModel = new TaskModel();

        /// <summary>
        /// Holds the components status model for the components overview.
        /// </summary>
        private ComponentsModel _componentsModel = new ComponentsModel();

        /// <summary>
        /// Holds the stock locations model for the stock locations overview.
        /// </summary>
        private StockLocationModel _stockLocationModel = new StockLocationModel();

        /// <summary>
        /// The list of articles that are allowed for input.
        /// </summary>
        private InputArticleList _inputArticles = new InputArticleList();

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="FMain"/> class.
        /// </summary>
        public FMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Load event of the FMain control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void FMain_Load(object sender, EventArgs e)
        {
            InitGuiElementsMain();
            InitGuiElementsDigitalShelf();
            LoadStoredValuesFromRegistry();
        }

        /// <summary>
        /// Initialyse Storage system UI Stuff
        /// </summary>
        private void InitGuiElementsMain()
        {

            dataGridDeliveryItems.DataSource = _stockDeliveryModel.StockDeliveryItems;
            dataGridDeliveryItems_SizeChanged(dataGridDeliveryItems, null);

            cmbPackShape.SelectedIndex = 0;
            cmbTaskType.SelectedIndex = 0;
        }

        /// <summary>
        /// Initialyse Digital shelf UI Stuff
        /// </summary>
        private void InitGuiElementsDigitalShelf()
        {
            comboBoxShoppingCartStatus.Items.Add(ShoppingCartStatus.Active);
            comboBoxShoppingCartStatus.Items.Add(ShoppingCartStatus.Finished);
            comboBoxShoppingCartStatus.Items.Add(ShoppingCartStatus.Discarded);
            comboBoxShoppingCartStatus.SelectedIndex = 0;

            comboBoxShoppingCartInfoStatus.Items.Add("");
            comboBoxShoppingCartInfoStatus.Items.Add(ShoppingCartStatus.Active);
            comboBoxShoppingCartInfoStatus.Items.Add(ShoppingCartStatus.Finished);
            comboBoxShoppingCartInfoStatus.Items.Add(ShoppingCartStatus.Discarded);
            comboBoxShoppingCartInfoStatus.SelectedIndex = 0;

            checkBoxTagAutoGenerate_Click(null, null);
            checkBoxCrossSellingArticleAutoGenerate_Click(null, null);
            checkBoxAlternativeArticlesAutoGenerate_Click(null, null);
            checkBoxAlternativePackSizeAutoGenerated_Click(null, null);
            checkBoxPriceInformationAutoGenerate_Click(null, null);
            checkBoxArticleInformationAutoGenerate_Click(null, null);
        }

        /// <summary>
        /// Load configuration from Registry
        /// </summary>
        private void LoadStoredValuesFromRegistry()
        {
            using (var key = Registry.CurrentUser.CreateSubKey("Software\\CareFusion\\ITSystemSimulator"))
            {
                var address = (string) key.GetValue("StorageSystemAddress");
                var port = key.GetValue("StorageSystemPort");
                var autoconnect = (string) key.GetValue("AutoConnectEnable");
                var allowdeliveryinput = (string) key.GetValue("AllowDeliveryInput");
                var allowstockretinput = (string) key.GetValue("AllowStockReturnInput");
                var onlyfridgeinput = (string) key.GetValue("OnlyFridgeInput");
                var onlyarticlesfromlist = (string) key.GetValue("OnlyArticlesFromList");
                var enforcepickingindicator = (string) key.GetValue("EnforcePickingIndicator");
                var enforceexpirydatereturn = (string) key.GetValue("EnforceExpiryDateStockReturn");
                var enforceexpirydatedelivery = (string) key.GetValue("EnforceExpiryDateDelivery");
                var enforcebatchreturn = (string) key.GetValue("EnforceBatchStockReturn");
                var enforcebatchdelivery = (string) key.GetValue("EnforceBatchDelivery");
                var enforcelocationreturn = (string) key.GetValue("EnforceLocationStockReturn");
                var enforcelocationnewdelivery = (string) key.GetValue("EnforceLocationNewDelivery");
                var enforceSerialNumberStockReturn = (string) key.GetValue("EnforceSerialNumberStockReturn");
                var enforceSerialNumberNewDelivery = (string) key.GetValue("EnforceSerialNumberNewDelivery");
                var setsubitemquantity = (string) key.GetValue("SetSubItemQuantity");
                var boxsetvirtualarticle = (string) key.GetValue("BoxSetVirtualArticle");
                var boxaddotherrobotarticle = (string) key.GetValue("BoxAddOtherRobotArticle");
                var overwritelocation = (string) key.GetValue("OverwriteStockLocation");
                var overwritelocationtext = (string) key.GetValue("OverwriteStockLocationText");

                txtAddress.Text = string.IsNullOrEmpty(address) ? "localhost" : address;
                numPort.Value = (port != null) ? (int) port : 6050;

                checkAutoConnect.Checked = string.IsNullOrEmpty(autoconnect) ? false : bool.Parse(autoconnect);

                checkAllowDeliveryInput.Checked = string.IsNullOrEmpty(allowdeliveryinput)
                    ? false
                    : bool.Parse(allowdeliveryinput);
                checkAllowStockReturnInput.Checked = string.IsNullOrEmpty(allowstockretinput)
                    ? false
                    : bool.Parse(allowstockretinput);
                checkOnlyFridgeInput.Checked = string.IsNullOrEmpty(onlyfridgeinput) ? false : bool.Parse(onlyfridgeinput);
                checkOnlyArticlesFromList.Checked = string.IsNullOrEmpty(onlyarticlesfromlist)
                    ? false
                    : bool.Parse(onlyarticlesfromlist);
                checkEnforcePickingIndicator.Checked = string.IsNullOrEmpty(enforcepickingindicator)
                    ? false
                    : bool.Parse(enforcepickingindicator);

                checkEnforceExpiryDateStockReturn.Checked = string.IsNullOrEmpty(enforceexpirydatereturn)
                    ? false
                    : bool.Parse(enforceexpirydatereturn);
                checkEnforceExpiryDateDelivery.Checked = string.IsNullOrEmpty(enforceexpirydatedelivery)
                    ? false
                    : bool.Parse(enforceexpirydatedelivery);
                checkEnforceBatchStockReturn.Checked = string.IsNullOrEmpty(enforcebatchreturn)
                    ? false
                    : bool.Parse(enforcebatchreturn);
                checkEnforceBatchDelivery.Checked = string.IsNullOrEmpty(enforcebatchdelivery)
                    ? false
                    : bool.Parse(enforcebatchdelivery);
                checkEnforceLocationStockReturn.Checked = string.IsNullOrEmpty(enforcelocationreturn)
                    ? false
                    : bool.Parse(enforcelocationreturn);
                
                checkEnforceLocationNewDelivery.Checked = string.IsNullOrEmpty(enforcelocationnewdelivery)
                    ? false
                    : bool.Parse(enforcelocationnewdelivery);
                checkEnforceSerialNumberStockReturn.Checked = string.IsNullOrEmpty(enforceSerialNumberStockReturn)
                    ? false
                    : bool.Parse(enforceSerialNumberStockReturn);
                checkEnforceSerialNumberNewDelivery.Checked = string.IsNullOrEmpty(enforceSerialNumberNewDelivery)
                    ? false
                    : bool.Parse(enforceSerialNumberNewDelivery);

                checkSetSubItemQuantity.Checked = string.IsNullOrEmpty(setsubitemquantity)
                    ? false
                    : bool.Parse(setsubitemquantity);
                checkBoxSetVirtualArticle.Checked = string.IsNullOrEmpty(boxsetvirtualarticle)
                    ? false
                    : bool.Parse(boxsetvirtualarticle);
                checkOverwriteStockLocation.Checked = string.IsNullOrEmpty(overwritelocation)
                    ? false
                    : bool.Parse(overwritelocation);

                txtOverwriteStockLocation.Text = string.IsNullOrEmpty(overwritelocationtext)
                    ? string.Empty
                    : overwritelocationtext;

                var digitalShelfaddress = (string) key.GetValue("DigitalShelfAddress");
                var digitalShelfport = key.GetValue("DigitalShelfPort");

                textBoxDigitalShelfAddress.Text = string.IsNullOrEmpty(digitalShelfaddress) ? "localhost" : digitalShelfaddress;
                numericUpDownDigitalShelfPort.Value = (digitalShelfport != null) ? (int) digitalShelfport : 6052;
            }
        }
        
        /// <summary>
        /// Handles the DoWork event of the bgConnect control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.ComponentModel.DoWorkEventArgs"/> instance containing the event data.</param>
        private void bgConnect_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                var connectParams = (string[])e.Argument;
                _storageSystem.Connect(connectParams[0], ushort.Parse(connectParams[1]));
                e.Result = true;
            }
            catch (Exception)
            {
                e.Result = false;
            }
        }

        /// <summary>
        /// Handles the RunWorkerCompleted event of the bgConnect control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.ComponentModel.RunWorkerCompletedEventArgs"/> instance containing the event data.</param>
        private void bgConnect_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if ((e.Result == null) || ((bool)e.Result == false))
            {
                if (checkAutoConnect.Checked)
                {
                    ConnectStorageSystem();
                }
                else
                {
                    MessageBox.Show(string.Format("Connecting to storage system '{0}' failed.", txtAddress.Text),
                                    "IT System Simulator");
                    btnConnect.Enabled = true;
                }
            }
            else
            {
                btnDisconnect.Enabled = true;
            }
            
             if (checkAutomaticStateObservation.Checked == false)
            {
                StorageSystem_StateChanged(_storageSystem, ComponentState.Ready);
            }
        }

        /// <summary>
        /// Connects the Storage system. Will not do anything is already connected.
        /// </summary>
        private void ConnectStorageSystem()
        {
            if (_storageSystem != null)
            {
                if (_storageSystem.Connected)
                {
                    // already connected, don't do anything.
                    return;
                }

                // Make sure the storage system is Disposed.
                DisconnectStorageSystem();
            }

            if (string.IsNullOrEmpty(txtTenantId.Text))
            {
                _storageSystem = new RowaStorageSystem();
            }
            else
            {
                _storageSystem = new RowaStorageSystem(txtTenantId.Text);
            }

            _storageSystem.EnableAutomaticStateObservation = checkAutomaticStateObservation.Checked;
            _storageSystem.PackDispensed += StorageSystem_PackDispensed;
            _storageSystem.PackInputRequested += StorageSystem_PackInputRequested;
            _storageSystem.ArticleInfoRequested += StorageSystem_ArticleInfoRequested;
            _storageSystem.PackStored += StorageSystem_PackStored;
            _storageSystem.StateChanged += StorageSystem_StateChanged;
            
            var connectParams = new string[] { txtAddress.Text, numPort.Value.ToString() };
            bgConnect.RunWorkerAsync(connectParams);
        }

        /// <summary>
        /// Disconnects and disposes the Storage system instance.
        /// </summary>
        private void DisconnectStorageSystem()
        {
            if (_storageSystem != null)
            {
                _storageSystem.Disconnect();
                _storageSystem.PackDispensed -= StorageSystem_PackDispensed;
                _storageSystem.PackInputRequested -= StorageSystem_PackInputRequested;
                _storageSystem.ArticleInfoRequested -= StorageSystem_ArticleInfoRequested;
                _storageSystem.PackStored -= StorageSystem_PackStored;
                _storageSystem.StateChanged -= StorageSystem_StateChanged;
                _storageSystem.Dispose();
                _storageSystem = null;
            }
        }


        /// <summary>
        /// Handles the FormClosing event of the FMain control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="FormClosingEventArgs"/> instance containing the event data.</param>
        private void FMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            DisconnectStorageSystem();

            _digitalShelf.Disconnect();
            _digitalShelf.ArticleInfoRequested -= DigitalShelf_ArticleInfoRequested;
            _digitalShelf.ArticlePriceRequested -= DigitalShelf_ArticlePriceRequested;
            _digitalShelf.ArticleSelected -= DigitalShelf_ArticleSelected;
            _digitalShelf.ShoppingCartRequested -= DigitalShelf_ShoppingCartRequested;
            _digitalShelf.ShoppingCartUpdateRequested -= DigitalShelf_ShoppingCartUpdateRequested;
            _digitalShelf.Dispose();

            // store as last known working
            SaveConfigurationsToRegistry();
        }

        /// <summary>
        /// Save configuration To Registry
        /// </summary>
        private void SaveConfigurationsToRegistry()
        {
            using (var key = Registry.CurrentUser.CreateSubKey("Software\\CareFusion\\ITSystemSimulator"))
            {
                //Ip stuff
                key.SetValue("StorageSystemAddress", txtAddress.Text);
                key.SetValue("StorageSystemPort", (int) numPort.Value, RegistryValueKind.DWord);
                //Auto Connect
                key.SetValue("AutoConnectEnable", checkAutoConnect.Checked.ToString());
                //Input Tab
                key.SetValue("AllowDeliveryInput", checkAllowDeliveryInput.Checked.ToString());
                key.SetValue("AllowStockReturnInput", checkAllowStockReturnInput.Checked.ToString());
                key.SetValue("OnlyFridgeInput", checkOnlyFridgeInput.Checked.ToString());
                key.SetValue("OnlyArticlesFromList", checkOnlyArticlesFromList.Checked.ToString());
                key.SetValue("EnforcePickingIndicator", checkEnforcePickingIndicator.Checked.ToString());
                key.SetValue("EnforceExpiryDateStockReturn", checkEnforceExpiryDateStockReturn.Checked.ToString());
                key.SetValue("EnforceExpiryDateDelivery", checkEnforceExpiryDateDelivery.Checked.ToString());
                key.SetValue("EnforceBatchStockReturn", checkEnforceBatchStockReturn.Checked.ToString());
                key.SetValue("EnforceBatchDelivery", checkEnforceBatchDelivery.Checked.ToString());
                key.SetValue("EnforceLocationStockReturn", checkEnforceLocationStockReturn.Checked.ToString());
                key.SetValue("EnforceLocationNewDelivery", checkEnforceLocationNewDelivery.Checked.ToString());
                key.SetValue("EnforceSerialNumberStockReturn", checkEnforceSerialNumberStockReturn.Checked.ToString());
                key.SetValue("EnforceSerialNumberNewDelivery", checkEnforceSerialNumberNewDelivery.Checked.ToString());
                key.SetValue("SetSubItemQuantity", checkSetSubItemQuantity.Checked.ToString());
                key.SetValue("BoxSetVirtualArticle", checkBoxSetVirtualArticle.Checked.ToString());
                key.SetValue("OverwriteStockLocation", checkOverwriteStockLocation.Checked.ToString());

                key.SetValue("OverwriteStockLocationText", txtOverwriteStockLocation.Text);
            }
        }

        /// <summary>
        /// Handles the TextChanged event of the txtAddress control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void txtAddress_TextChanged(object sender, EventArgs e)
        {
            btnConnect.Enabled = (string.IsNullOrEmpty(txtAddress.Text) == false);
        }

        /// <summary>
        /// Handles the Click event of the btnConnect control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnConnect_Click(object sender, EventArgs e)
        {
            btnConnect.Enabled = false;
            ConnectStorageSystem();
        }

        /// <summary>
        /// Handles the Click event of the btnDisconnect control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            checkAutoConnect.Checked = false; // if manually disconnect, disable auto-connect.
            btnDisconnect.Enabled = false;
            DisconnectStorageSystem();
            btnConnect.Enabled = true;  
        }

        /// <summary>
        /// Handles the CheckedChanged event of the checkAutomaticStateObservation control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void checkAutomaticStateObservation_CheckedChanged(object sender, EventArgs e)
        {
            if (_storageSystem != null)
            {
                _storageSystem.EnableAutomaticStateObservation = checkAutomaticStateObservation.Checked;
            }
        }

        /// <summary>
        /// Handles the TextChanged event of the txtArticleFilter control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        

        /// <summary>
        /// Handles the DoWork event of the bgStock control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.ComponentModel.DoWorkEventArgs"/> instance containing the event data.</param>
        private void bgStock_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                var articleFilter = e.Argument as string;

                if (string.IsNullOrEmpty(articleFilter))
                {
                    e.Result = _storageSystem.GetStock(true, true);
                }
                else
                {
                    e.Result = _storageSystem.GetStock(true, true, articleFilter);
                }
            }
            catch (Exception)
            {
                e.Result = null;
            }
        }

        /// <summary>
        /// Handles the RunWorkerCompleted event of the bgStock control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.ComponentModel.RunWorkerCompletedEventArgs"/> instance containing the event data.</param>
        private void bgStock_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (e.Result != null)
            {

                _stockModel.Replace((List<IArticle>)e.Result);

                btnBulkOrder.Enabled = _stockModel.ArticleList.Length > 0;
            }
            else
            {
                MessageBox.Show("Loading stock failed.", "IT System Simulator");
            }

        }
        
        /// <summary>
        /// Handles the Click event of the btnSendInitInputRequest control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnSendInitInputRequest_Click(object sender, EventArgs e)
        {
            btnSendInitInputRequest.Enabled = false;

            var request = _storageSystem.CreateInitiateInputRequest(numInitInputID.Value.ToString(),
                                                                    (int)numInputSource.Value,
                                                                    (int)numInputPoint.Value,
                                                                    (int)numDestination.Value,
                                                                    string.IsNullOrEmpty(txtDeliveryNumber.Text) ? null : txtDeliveryNumber.Text,
                                                                    chkSetPickingIndicator.Checked);

            if (request == null)
            {
                MessageBox.Show("Input initiation is not supported by the storage system.");
                return;
            }

            request.Finished += OnInitiateInputRequest_Finished;

            lock (_activeInitiatedInputs)
            {
                _activeInitiatedInputs.Add(request);
            }

            DateTime? expiryDate = null;
            DateTime expiryDateCheck;
            if (DateTime.TryParse(txtPackExpiryDate.Text, out expiryDateCheck))
            {
                expiryDate = expiryDateCheck;
            }

            request.AddInputPack(txtPackScanCode.Text,
                                 txtPackBatchNumber.Text,
                                 null,
                                 expiryDate,
                                 (int)numPackSubItemQuantity.Value,
                                 (int)numPackDepth.Value,
                                 (int)numPackWidth.Value,
                                 (int)numPackHeight.Value,
                                 (PackShape)Enum.Parse(typeof(PackShape), cmbPackShape.Text),
                                 string.IsNullOrEmpty(txtPackStockLocation.Text) ? null : txtPackStockLocation.Text);

            bgInitInput.RunWorkerAsync(request);
        }

        /// <summary>
        /// Handles the DoWork event of the bgInitInput control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.ComponentModel.DoWorkEventArgs"/> instance containing the event data.</param>
        private void bgInitInput_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            var request = (IInitiateInputRequest)e.Argument;

            bgInitInput.ReportProgress(1, string.Format("Sending InitiateInputRequest({0}) ...", request.Id));

            try
            {
                request.Start();

                bgInitInput.ReportProgress(1, string.Format("InitiateInputRequest({0}) successfully sent.", request.Id));
                bgInitInput.ReportProgress(1, string.Format("  -> Selected InputSource = {0}", request.InputSource));
                bgInitInput.ReportProgress(1, string.Format("  -> Selected InputPoint = {0}", request.InputPoint));

                foreach (var article in request.InputArticles)
                {
                    bgInitInput.ReportProgress(1, string.Format("  -> Seems to be Article:\n\tID: '{0}'\n\tName: '{1}'\n\tDosageForm: '{2}'\n\tPackagingUnit: '{3}'.",
                                                                article.Id, article.Name, article.DosageForm, article.PackagingUnit));

                }

                e.Result = true;
            }
            catch (Exception ex)
            {
                bgInitInput.ReportProgress(1, string.Format("Sending InitiateInputRequest({0}) failed with error '{1}'.", request.Id, ex.Message));
                e.Result = ex;
            }
        }

        /// <summary>
        /// Handles the ProgressChanged event of the bgInitInput control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.ComponentModel.ProgressChangedEventArgs"/> instance containing the event data.</param>
        private void bgInitInput_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            if (e.UserState != null)
                WriteInitiateInputLog((string)e.UserState);
        }

        /// <summary>
        /// Handles the RunWorkerCompleted event of the bgInitInput control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.ComponentModel.RunWorkerCompletedEventArgs"/> instance containing the event data.</param>
        private void bgInitInput_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if ((e.Result != null) && (e.Result is Exception))
            {
                MessageBox.Show("Sending Input Initiation failed.", "IT System Simulator");
            }

            btnSendInitInputRequest.Enabled = btnNewOrder.Enabled;
        }

        /// <summary>
        /// Handles the Click event of the btnClearInputLog control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnClearInputLog_Click(object sender, EventArgs e)
        {
            listInputLog.Items.Clear();
        }
        
        /// <summary>
        /// Handles the Click event of the btnNewOrder control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnNewOrder_Click(object sender, EventArgs e)
        {
            FOrder newOrder = new FOrder(_storageSystem, _stockModel.ArticleList);
            newOrder.ShowDialog(this);

            if (newOrder.Order != null)
            {
                _orderModel.AddOrder(newOrder.Order);
            }
        }

        /// <summary>
        /// Handles the Click event of the btnBulkOrder control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnBulkOrder_Click(object sender, EventArgs e)
        {
            FBulkOrder newBulkOrder = new FBulkOrder(_storageSystem, _stockModel.ArticlePacks);

            if (newBulkOrder.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                dataGridOrders.DataSource = null;

                foreach (var order in newBulkOrder.Orders)
                {
                    _orderModel.AddOrder(order);
                }

            }
        }

        /// <summary>
        /// Handles the Click event of the btnSendOrder control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnSendOrder_Click(object sender, EventArgs e)
        {
            btnSendOrder.Enabled = false;
            _orderModel.SendOrders();
            btnSendOrder.Enabled = true;
        }

        /// <summary>
        /// Handles the Click event of the btnCancelOrder control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnCancelOrder_Click(object sender, EventArgs e)
        {
            btnCancelOrder.Enabled = false;
            _orderModel.CancelCurrentOrder();
            btnCancelOrder.Enabled = true;
        }

        /// <summary>
        /// Handles the Click event of the btnClearOrders control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnClearOrders_Click(object sender, EventArgs e)
        {
            _orderModel.Clear();
        }

        /// <summary>
        /// Handles the SelectionChanged event of the dataGridOrders control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void dataGridOrders_SelectionChanged(object sender, EventArgs e)
        {
            if ((dataGridOrders.SelectedRows == null) || (dataGridOrders.SelectedRows.Count == 0))
            {
                _orderModel.ClearOrderSelection();
            }
            else
            {
                DataRowView rowView = dataGridOrders.SelectedRows[0].DataBoundItem as DataRowView;
                _orderModel.SelectOrder((string)rowView.Row[0]);
            }
        }

        /// <summary>
        /// Handles the SelectionChanged event of the dataGridOrderItems control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void dataGridOrderItems_SelectionChanged(object sender, EventArgs e)
        {
            if ((dataGridOrderItems.SelectedRows == null) || (dataGridOrderItems.SelectedRows.Count == 0))
            {
                _orderModel.ClearOrderItemSelection();
            }
            else
            {
                DataRowView rowView = dataGridOrderItems.SelectedRows[0].DataBoundItem as DataRowView;
                _orderModel.SelectOrderItem((int)rowView.Row[0]);
            }
        }

        /// <summary>
        /// Handles the SizeChanged event of the dataGridMasterArticles control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void dataGridMasterArticles_SizeChanged(object sender, EventArgs e)
        {
            if (dataGridMasterArticles.Columns.Count >= 10)
            {
                dataGridMasterArticles.Columns[2].Width = 80;
                dataGridMasterArticles.Columns[3].Width = 80;
                dataGridMasterArticles.Columns[4].Width = 80;
                dataGridMasterArticles.Columns[5].Width = 80;
                dataGridMasterArticles.Columns[8].Width = 80;
                dataGridMasterArticles.Columns[9].Width = 80;


                dataGridMasterArticles.Columns[0].Width = (dataGridMasterArticles.Width - 550) / 4;
                dataGridMasterArticles.Columns[1].Width = dataGridMasterArticles.Columns[0].Width;
                dataGridMasterArticles.Columns[6].Width = dataGridMasterArticles.Columns[0].Width;
                dataGridMasterArticles.Columns[7].Width = dataGridMasterArticles.Columns[0].Width;

                /*for (int i = 1; i < 8; ++i)
                {
                    dataGridMasterArticles.Columns[i].Width = dataGridMasterArticles.Columns[0].Width;
                }*/
            }
        }

        /// <summary>
        /// Update dataGridMasterArticlesDisplay when selection change
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void dataGridMasterArticles_SelectionChanged(object sender, EventArgs e)
        {
            UpdateDataGridMasterArticlesDisplay();
        }

        /// <summary>
        /// Update dataGridMasterArticlesDisplay when selection change
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void dataGridMasterArticles_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            UpdateDataGridMasterArticlesDisplay();
        }

        /// <summary>
        /// Update dataGridMasterArticlesDisplay when selection change
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void dataGridMasterArticles_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            UpdateDataGridMasterArticlesDisplay();
        }

        /// <summary>
        /// Update dataGridMasterArticlesDisplay when selection change
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void UpdateDataGridMasterArticlesDisplay()
        {
            int? selectedRowIndex = null;
            if (dataGridMasterArticles.SelectedCells != null)
            {
                foreach (DataGridViewCell selectCell in dataGridMasterArticles.SelectedCells)
                {
                    if (!selectedRowIndex.HasValue)
                    {
                        selectedRowIndex = selectCell.RowIndex;
                    }
                    else
                    {
                        if (selectedRowIndex.Value != selectCell.RowIndex)
                        {
                        }
                    }
                }
            }

            if (dataGridMasterArticles.SelectedRows != null)
            {
                foreach (DataGridViewRow selectRow in dataGridMasterArticles.SelectedRows)
                {
                    if (!selectedRowIndex.HasValue)
                    {
                        selectedRowIndex = selectRow.Index;
                    }
                    else
                    {
                        if (selectedRowIndex.Value != selectRow.Index)
                        {
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the btnGenerateArticles control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnGenerateArticles_Click(object sender, EventArgs e)
        {
            dataGridMasterArticles.DataSource = null;
            dataGridMasterArticles.Refresh();
            _masterArticleModel.GenerateMasterArticles();
            dataGridMasterArticles.DataSource = _masterArticleModel.MasterArticles;
            dataGridMasterArticles_SizeChanged(sender, e);
            dataGridMasterArticles.Refresh();
        }

        /// <summary>
        /// Handles the SizeChanged event of the dataGridDeliveyItems control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void dataGridDeliveryItems_SizeChanged(object sender, EventArgs e)
        {
            if (dataGridDeliveryItems.Columns.Count >= 13)
            {
                dataGridDeliveryItems.Columns[0].Width = (dataGridDeliveryItems.Width - 70) / 13;

                for (int i = 1; i < 13; ++i)
                {
                    dataGridDeliveryItems.Columns[i].Width = dataGridDeliveryItems.Columns[0].Width;
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the btnSendStockDeliveries control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnSendStockDeliveries_Click(object sender, EventArgs e)
        {
            try
            {
                btnSendStockDeliveries.Enabled = false;
                _stockDeliveryModel.Send(_storageSystem);
            }
            catch (Exception ex)
            {
                var msg = string.Format("Adding stock deliveries failed!\n\n{0}", ex.Message);
                MessageBox.Show(msg, "IT System Simulator");
            }

            btnSendStockDeliveries.Enabled = true;
        }

        /// <summary>
        /// Handles the Click event of the btnGetConfig control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnGetConfig_Click(object sender, EventArgs e)
        {
            txtConfiguration.Text = string.Empty;

            if ((_storageSystem != null) && (_storageSystem.Connected))
            {
                txtConfiguration.Text = _storageSystem.Configuration.Replace("><", ">\r\n<");
            }
        }

        /// <summary>
        /// Handles the SizeChanged event of the dataGridArticleInfo control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void dataGridArticleInfo_SizeChanged(object sender, EventArgs e)
        {
            if (dataGridArticleInfo.Columns.Count >= 2)
            {
                dataGridArticleInfo.Columns[0].Width = (dataGridArticleInfo.Width - 80);
                dataGridArticleInfo.Columns[1].Width = 50;
            }
        }

        /// <summary>
        /// Handles the SelectionChanged event of the dataGridArticleInfo control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void dataGridArticleInfo_SelectionChanged(object sender, EventArgs e)
        {
            if ((dataGridArticleInfo.SelectedRows == null) || (dataGridArticleInfo.SelectedRows.Count == 0))
            {
                _taskModel.ClearArticleSelection();
            }
            else
            {
                DataRowView rowView = dataGridArticleInfo.SelectedRows[0].DataBoundItem as DataRowView;
                _taskModel.SelectArticle(rowView.Row[0] as string);
            }
        }

        /// <summary>
        /// Handles the SizeChanged event of the dataGridPackInfo control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void dataGridPackInfo_SizeChanged(object sender, EventArgs e)
        {
            if (dataGridPackInfo.Columns.Count >= 14)
            {
                dataGridPackInfo.Columns[0].Width = (dataGridPackInfo.Width - 30) / 14;

                for (int i = 1; i < 14; ++i)
                {
                    dataGridPackInfo.Columns[i].Width = dataGridPackInfo.Columns[0].Width;
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the btnGetTaskInfo control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnGetTaskInfo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTaskID.Text))
                return;

            if (cmbTaskType.SelectedIndex == 0)
            {
                var info = _storageSystem.GetOutputProcessInfo(txtTaskID.Text);
                lblTaskState.Text = info.State.ToString();
                _taskModel.Update(info.Packs);
            }
            else
            {
                var info = _storageSystem.GetStockDeliveryInfo(txtTaskID.Text);
                lblTaskState.Text = info.State.ToString();
                _taskModel.Update(info.InputArticles);
            }
        }

        /// <summary>
        /// Handles the Click event of the btnClearInitInputLog control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnClearInitInputLog_Click(object sender, EventArgs e)
        {
            listInitInputLog.Items.Clear();
        }

        /// <summary>
        /// Handles the SizeChanged event of the dataGridComponents control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void dataGridComponents_SizeChanged(object sender, EventArgs e)
        {
            if (dataGridComponents.Columns.Count >= 4)
            {
                dataGridComponents.Columns[0].Width = (dataGridComponents.Width - 30) / 4;

                for (int i = 1; i < 4; ++i)
                {
                    dataGridComponents.Columns[i].Width = dataGridComponents.Columns[0].Width;
                }
            }
        }

        /// <summary>
        /// Handles the SizeChanged event of the dataGridStockLocations control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void dataGridStockLocations_SizeChanged(object sender, EventArgs e)
        {
            if (dataGridStockLocations.Columns.Count >= 2)
            {
                dataGridStockLocations.Columns[0].Width = (dataGridStockLocations.Width - 30) / 2;

                for (int i = 1; i < 2; ++i)
                {
                    dataGridStockLocations.Columns[i].Width = dataGridStockLocations.Columns[0].Width;
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the btnReloadComponents control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnReloadComponents_Click(object sender, EventArgs e)
        {
            btnReloadComponents.Enabled = false;
            _componentsModel.Update(_storageSystem.ComponentStates);
            btnReloadComponents.Enabled = true;
        }

        /// <summary>
        /// Handles the Click event of the btnReloadStockLocations control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnReloadStockLocations_Click(object sender, EventArgs e)
        {
            btnReloadStockLocations.Enabled = false;
            _stockLocationModel.Update(_storageSystem.StockLocations);
            btnReloadStockLocations.Enabled = true;
        }

        /// <summary>
        /// Handles the CheckedChanged event of the checkOverwriteStockLocation control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void checkOverwriteStockLocation_CheckedChanged(object sender, EventArgs e)
        {
            txtOverwriteStockLocation.Enabled = checkOverwriteStockLocation.Checked;
        }

        /// <summary>
        /// Event that the specified initiated input process finished.
        /// </summary>
        /// <param name="sender">Sender which raised the event.</param>
        /// <param name="e">Always null.</param>
        private void OnInitiateInputRequest_Finished(object sender, EventArgs e)
        {
            var request = (IInitiateInputRequest)sender;

            WriteInitiateInputLog("InitiateInputRequest({0}) finshed with result '{1}'!", request.Id, request.State.ToString());

            foreach (var article in request.InputArticles)
            {
                WriteInitiateInputLog("  -> Processed Article:\n\tID: '{0}'\n\tName: '{1}'\n\tDosageForm: '{2}'\n\tPackagingUnit: '{3}'.",
                                      article.Id, article.Name, article.DosageForm, article.PackagingUnit);

                foreach (var pack in article.Packs)
                {
                    InputErrorType errorType;
                    string errorText;

                    if (request.GetProcessedPackError(pack, out errorType, out errorText))
                    {
                        WriteInitiateInputLog("  -> Got pack error '{0}' / '{1}'.", errorType.ToString(), errorText);
                    }
                    else
                    {
                        WriteInitiateInputLog("  -> Stored Pack with ID '{0}'.", pack.Id);
                    }
                }
            }

            lock (_activeInitiatedInputs)
            {
                _activeInitiatedInputs.Remove(request);
            }
        }
        /// <summary>
        /// Handles the state change of a storage system.
        /// </summary>
        /// <param name="sender">Object instance which raised the event.</param>
        /// <param name="state">New state of the storage system.</param>
        private void StorageSystem_StateChanged(IStorageSystem sender, ComponentState state)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new StateChangedEventHandler(StorageSystem_StateChanged), sender, state);
                return;
            }

            lblStorageSystemStatus.Text = string.Format("Robot Status: {0}", state.ToString());

            btnNewOrder.Enabled = (state != ComponentState.NotConnected);
            btnSendOrder.Enabled = btnNewOrder.Enabled;
            btnCancelOrder.Enabled = btnNewOrder.Enabled;
            btnSendStockDeliveries.Enabled = btnNewOrder.Enabled;
            btnImportStockDeliveries.Enabled = btnNewOrder.Enabled;
            btnSendInitInputRequest.Enabled = btnNewOrder.Enabled;
            btnGetTaskInfo.Enabled = btnNewOrder.Enabled;
            btnReloadComponents.Enabled = btnNewOrder.Enabled;
            btnReloadStockLocations.Enabled = btnNewOrder.Enabled;

            if (btnNewOrder.Enabled)
            {
                btnBulkOrder.Enabled = _stockModel.ArticleList.Length > 0;
            }
            else
            {
                btnBulkOrder.Enabled = false;
            }


            if (checkAutoConnect.Checked)
            {
                btnConnect.Enabled = false;
                if (state == ComponentState.NotConnected)
                {
                    ConnectStorageSystem();
                }
            }
            else
            {
                btnConnect.Enabled = (state == ComponentState.NotConnected);
            }
            btnDisconnect.Enabled = (state != ComponentState.NotConnected);
        }

     
        /// <summary>
        /// Event which is raised whenever a connected storage system requests
        /// permission for pack input. The specified request object is used to get further details 
        /// and to allow or deny the pack input.
        /// </summary>
        /// <param name="sender">Object instance which raised the event.</param>
        /// <param name="request">Object which contains the details about the requested pack input.</param>
        private void StorageSystem_PackInputRequested(IStorageSystem sender, IInputRequest request)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new PackInputRequestEventHandler(StorageSystem_PackInputRequested), sender, request);
                return;
            }

            if (request.DeliveryNumber == null)
                HandleStockReturnInput(request);
            else
                HandleStockDeliveryInput(request);

            request.Finish();
        }

        /// <summary>
        /// Handles the specified stock return input.
        /// </summary>
        /// <param name="request">The input request to handle.</param>
        private void HandleStockReturnInput(IInputRequest request)
        {
            WriteInputLog("Received input request for stock return.");

            if (checkAllowStockReturnInput.Checked == false)
            {
                WriteInputLog("Rejecting all packs.");

                // reject all packs
                foreach (var pack in request.Packs)
                    pack.SetHandling(InputHandling.Rejected);

                return;
            }

            if ((checkEnforcePickingIndicator.Checked) && (request.PickingIndicator == false))
            {
                WriteInputLog("Rejecting all packs because of missing picking indicator.");

                // reject all packs due to missing picking indicator
                foreach (var pack in request.Packs)
                {
                    var article = _inputArticles.GetArticleByScanCodeOrDefault(pack.ScanCode);
                    pack.SetArticleInformation(article.Id,
                        article.Name,
                        article.DosageForm,
                        article.PackagingUnit,
                        checkSetSubItemQuantity.Checked ? article.MaxSubItemQuantity : 0,
                        null,
                        null,
                        article.RequiresFridge);

                    pack.SetHandling(InputHandling.RejectedNoPickingIndicator);
                }

                return;
            }

            if (checkOnlyArticlesFromList.Checked)
            {
                var rejectPacks = false;

                // check whether at least one unknown article is in the list
                foreach (var pack in request.Packs)
                {
                    if (_inputArticles.GetArticleByScanCode(pack.ScanCode) == null)
                    {
                        rejectPacks = true;
                        break;
                    }
                }

                if (rejectPacks)
                {
                    WriteInputLog("Rejecting all packs because at least one article is not in the list.");

                    // reject all packs due to missing picking indicator
                    foreach (var pack in request.Packs)
                    {
                        var article = _inputArticles.GetArticleByScanCodeOrDefault(pack.ScanCode);
                        pack.SetArticleInformation(article.Id,
                            article.Name,
                            article.DosageForm,
                            article.PackagingUnit,
                            checkSetSubItemQuantity.Checked ? article.MaxSubItemQuantity : 0,
                            null,
                            null,
                            article.RequiresFridge);

                        pack.SetHandling(InputHandling.Rejected, "Unknown article.");
                    }

                    return;
                }
            }


            foreach (var pack in request.Packs)
            {
                var article = _inputArticles.GetArticleByScanCodeOrDefault(pack.ScanCode);

                SetPackInformation(pack, article);

                if ((checkEnforceExpiryDateStockReturn.Checked) && (pack.ExpiryDate.HasValue == false))
                {
                    WriteInputLog("Rejecting pack '{0}' because of missing expiry date.", pack.ScanCode);
                    pack.SetHandling(InputHandling.RejectedNoExpiryDate);
                    continue;
                }

                if ((checkEnforceBatchStockReturn.Checked) && (string.IsNullOrEmpty(pack.BatchNumber)))
                {
                    WriteInputLog("Rejecting pack '{0}' because of missing batch number.", pack.ScanCode);
                    pack.SetHandling(InputHandling.RejectedNoBatchNumber);
                    continue;
                }

                if ((checkEnforceLocationStockReturn.Checked) && (string.IsNullOrEmpty(pack.StockLocationId)))
                {
                    WriteInputLog("Rejecting pack '{0}' because of missing stock location.", pack.ScanCode);
                    pack.SetHandling(InputHandling.RejectedNoStockLocation);
                    continue;
                }

                if ((checkEnforceSerialNumberStockReturn.Checked) && (string.IsNullOrEmpty(pack.SerialNumber)))
                {
                    WriteInputLog("Rejecting pack '{0}' because of missing serial number.", pack.SerialNumber);
                    pack.SetHandling(InputHandling.RejectedNoSerialNumber);
                    continue;
                }

                DateTime? expiryDate = pack.ExpiryDate.HasValue ? pack.ExpiryDate : DateTime.Now.AddMonths((int)numExpiryDateMonth.Value);
                expiryDate = numExpiryDateMonth.Value > 0 ? expiryDate : null;

                if (checkOverwriteStockLocation.Checked)
                {
                    pack.SetPackInformation(string.IsNullOrEmpty(pack.BatchNumber) ? string.Format("BATCH-{0}", pack.ScanCode) : pack.BatchNumber,
                                            string.Format("EXTID-{0}", pack.ScanCode),
                                            expiryDate,
                                            0,
                                            txtOverwriteStockLocation.Text);
                }
                else
                {
                    pack.SetPackInformation(string.IsNullOrEmpty(pack.BatchNumber) ? string.Format("BATCH-{0}", pack.ScanCode) : pack.BatchNumber,
                                        string.Format("EXTID-{0}", pack.ScanCode),
                                        expiryDate,
                                        0);
                }

                WriteInputLog("Accepting pack '{0}'.", pack.ScanCode);
                pack.SetHandling(article.RequiresFridge ? InputHandling.AllowedForFridge : InputHandling.Allowed);
            }
        }

        /// <summary>
        /// Handles the specified stock delivery input.
        /// </summary>
        /// <param name="request">The input request to handle.</param>
        private void HandleStockDeliveryInput(IInputRequest request)
        {
            WriteInputLog("Received input request for delivery '{0}'.", request.DeliveryNumber);

            if (checkAllowDeliveryInput.Checked == false)
            {
                WriteInputLog("Rejecting all packs.");

                // reject all packs
                foreach (var pack in request.Packs)
                    pack.SetHandling(InputHandling.Rejected);

                request.Finish();
                return;
            }

            if ((checkEnforcePickingIndicator.Checked) && (request.PickingIndicator == false))
            {
                WriteInputLog("Rejecting all packs because of missing picking indicator.");

                // reject all packs due to missing picking indicator
                foreach (var pack in request.Packs)
                {
                    var article = _inputArticles.GetArticleByScanCodeOrDefault(pack.ScanCode);
                    SetPackInformation(pack, article);
                    pack.SetHandling(InputHandling.RejectedNoPickingIndicator);
                }

                request.Finish();
                return;
            }

            if (checkOnlyArticlesFromList.Checked)
            {
                var rejectPacks = false;

                // check whether at least one unknown article is in the list
                foreach (var pack in request.Packs)
                {
                    if (_inputArticles.GetArticleByScanCode(pack.ScanCode) == null)
                    {
                        rejectPacks = true;
                        break;
                    }
                }

                if (rejectPacks)
                {
                    WriteInputLog("Rejecting all packs because at least one article is not in the list.");

                    // reject all packs due to missing picking indicator
                    foreach (var pack in request.Packs)
                    {
                        var article = _inputArticles.GetArticleByScanCodeOrDefault(pack.ScanCode);
                        SetPackInformation(pack, article);
                        pack.SetHandling(InputHandling.Rejected, "Unknown article.");
                    }

                    return;
                }
            }

            foreach (var pack in request.Packs)
            {
                var article = _inputArticles.GetArticleByScanCodeOrDefault(pack.ScanCode);
                SetPackInformation(pack, article);

                if ((checkEnforceExpiryDateDelivery.Checked) && (pack.ExpiryDate.HasValue == false))
                {
                    WriteInputLog("Rejecting pack '{0}' because of missing expiry date.", pack.ScanCode);
                    pack.SetHandling(InputHandling.RejectedNoExpiryDate);
                    continue;
                }

                if ((checkEnforceBatchDelivery.Checked) && (string.IsNullOrEmpty(pack.BatchNumber)))
                {
                    WriteInputLog("Rejecting pack '{0}' because of missing batch number.", pack.ScanCode);
                    pack.SetHandling(InputHandling.RejectedNoBatchNumber);
                    continue;
                }

                if ((checkEnforceLocationNewDelivery.Checked) && (string.IsNullOrEmpty(pack.StockLocationId)))
                {
                    WriteInputLog("Rejecting pack '{0}' because of missing stock location.", pack.ScanCode);
                    pack.SetHandling(InputHandling.RejectedNoStockLocation);
                    continue;
                }

                if ((checkEnforceSerialNumberNewDelivery.Checked) && (string.IsNullOrEmpty(pack.SerialNumber)))
                {
                    WriteInputLog("Rejecting pack '{0}' because of missing serial number.", pack.SerialNumber);
                    pack.SetHandling(InputHandling.RejectedNoSerialNumber);
                    continue;
                }

                DateTime? expiryDate = pack.ExpiryDate.HasValue ? pack.ExpiryDate : DateTime.Now.AddMonths((int)numExpiryDateMonth.Value);
                expiryDate = numExpiryDateMonth.Value > 0 ? expiryDate : null;

                if (checkOverwriteStockLocation.Checked)
                {
                    pack.SetPackInformation(string.IsNullOrEmpty(pack.BatchNumber) ? string.Format("BATCH-{0}", pack.ScanCode) : pack.BatchNumber,
                                            string.Format("EXTID-{0}", pack.ScanCode),
                                            expiryDate,
                                            0,
                                            txtOverwriteStockLocation.Text);
                }
                else
                {
                    pack.SetPackInformation(string.IsNullOrEmpty(pack.BatchNumber) ? string.Format("BATCH-{0}", pack.ScanCode) : pack.BatchNumber,
                                            string.Format("EXTID-{0}", pack.ScanCode),
                                            expiryDate,
                                            0);
                }

                WriteInputLog("Accepting pack '{0}'.", pack.ScanCode);
                pack.SetHandling(article.RequiresFridge ? InputHandling.AllowedForFridge : InputHandling.Allowed);
            }
        }

        /// <summary>
        /// Set Pack information and Virtual pack information
        /// </summary>
        /// <param name="pack">The pack to receive information</param>
        /// <param name="article">Source Article information</param>
        private void SetPackInformation(IInputPack pack, InputArticle article)
        {
            pack.SetArticleInformation(article.Id,
                article.Name,
                article.DosageForm,
                article.PackagingUnit,
                checkSetSubItemQuantity.Checked ? article.MaxSubItemQuantity : 0,
                checkBoxSetVirtualArticle.Checked ? "Virtual-" + article.Id.Substring(0, article.Id.Length - 1) : null,
                checkBoxSetVirtualArticle.Checked ? "Virtual-" + article.Name : null,
                article.RequiresFridge);
        }
        
        /// <summary>
        /// Event which is raised when detailed information for one or more articles is requested.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="articleList">List of articles request.</param>
        private void StorageSystem_ArticleInfoRequested(IStorageSystem sender, IStorageSystemArticleInfoRequest request)
        {
            foreach (var article in request.ArticleList)
            {
                WriteInputLog("Article information requested for ID {0}, , Depth '{1}', Width '{2}', Height '{3}', Weight '{4}'.",
                    article.Id, article.Depth, article.Width, article.Height, article.Weight);

                var articleInfo = _inputArticles.GetArticleByScanCodeOrDefault(article.Id);
                List<string> productCodeList = new List<string>();
                productCodeList.Add(articleInfo.Id);
                productCodeList.Add(articleInfo.Id + "-1");
                productCodeList.Add(articleInfo.Id + "-2");

                article.SetArticleInformation(articleInfo.Id,
                    articleInfo.Name,
                    articleInfo.DosageForm,
                    articleInfo.PackagingUnit,
                    checkSetSubItemQuantity.Checked ? articleInfo.MaxSubItemQuantity : 0,
                    checkBoxSetVirtualArticle.Checked ? "Virtual-" + articleInfo.Id.Substring(0, articleInfo.Id.Length - 1) : null,
                    checkBoxSetVirtualArticle.Checked ? "Virtual-" + articleInfo.Name : null,
                    articleInfo.RequiresFridge,
                    DateTime.Now,
                    productCodeList);
            }

            request.Finish();
        }

        /// <summary>
        /// Event which is raised whenever a new pack was successfully stored in a storage system. 
        /// </summary>
        /// <param name="sender">Object instance which raised the event.</param>
        /// <param name="articleList">List of articles with the packs that were stored.</param>
        private void StorageSystem_PackStored(IStorageSystem sender, IArticle[] articleList)
        {
            if ((articleList == null) || (articleList.Length == 0))
            {
                return;
            }

            if (this.InvokeRequired)
            {
                this.Invoke(new PackStoredEventHandler(StorageSystem_PackStored), sender, articleList);
                return;
            }
            foreach (var article in articleList)
            {
                foreach (var pack in article.Packs)
                {
                    WriteInputLog("Pack '{0}' for article '{1}' was stored.", pack.Id, article.Id);
                }
            }

            dataGridArticles.DataSource = null;
            dataGridPacks.DataSource = null;

            _stockModel.Add(articleList);

        }

        /// <summary>
        /// Event which is raised whenever a pack was dispensed by an output
        /// process that was not initiated by this storage system connection (e.g. at the UI of the storage system).
        /// </summary>
        /// <param name="sender">Object instance which raised the event.</param>
        /// <param name="articleList">List of articles with the packs that were dispensed.</param>
        private void StorageSystem_PackDispensed(IStorageSystem sender, IArticle[] articleList)
        {
            if ((articleList == null) || (articleList.Length == 0))
            {
                return;
            }

            if (this.InvokeRequired)
            {
                this.Invoke(new PackDispensedEventHandler(StorageSystem_PackDispensed), sender, articleList);
                return;
            }
            
            foreach (var article in articleList)
            {
                foreach (var pack in article.Packs)
                {
                    WriteInputLog("Pack '{0}' for article '{1}' was dispensed.", pack.Id, article.Id);
                }
            }


            dataGridArticles.DataSource = null;
            dataGridPacks.DataSource = null;

            _stockModel.Remove(articleList);

        }

       

        /// <summary>
        /// Event which is thrown when a box is released.
        /// </summary>
        /// <param name="sender">Sender of the event.</param>
        /// <param name="e">Box releasing event args.</param>
        private void OrderModel_BoxReleased(object sender, EventArgs e)
        {
            dataGridOrderBoxes.DataSource = null;

            dataGridOrderBoxes.DataSource = ((BoxReleasedArgs)e).Boxes;
        }

        /// <summary>
        /// Writes the specified input log.
        /// </summary>
        /// <param name="format">The format string of the log entry.</param>
        /// <param name="args">The arguments of the log entry.</param>
        private void WriteInputLog(string format, params object[] args)
        {
            if (InvokeRequired)
            {
                Invoke(new WriteLog((f, a) => { WriteInputLog(f, a); }), format, args);
                return;
            }

            string logMessage = string.Format(format, args);
            listInputLog.TopIndex = listInputLog.Items.Add(string.Format("{0:HH:mm:ss,fff}  {1}", DateTime.Now, logMessage));
        }


        /// <summary>
        /// Writes the specified initiated input log.
        /// </summary>
        /// <param name="format">The format string of the log entry.</param>
        /// <param name="args">The arguments of the log entry.</param>
        private void WriteInitiateInputLog(string format, params object[] args)
        {
            if (InvokeRequired)
            {
                Invoke(new WriteLog((f, a) => { WriteInitiateInputLog(f, a); }), format, args);
                return;
            }

            string logMessage = string.Format(format, args);
            listInitInputLog.TopIndex = listInitInputLog.Items.Add(string.Format("{0:HH:mm:ss,fff}  {1}", DateTime.Now, logMessage));
        }

        /// <summary>
        /// Handles the Click event of the btnImportSelectArticles control.
        /// </summary>
        /// <param name="sender">Sender of the event.</param>
        /// <param name="e">Dispensing event args.</param>
        private void btnImportSelectArticles_Click(object sender, EventArgs e)
        {
            if (openArticleFileDialog.ShowDialog() != DialogResult.OK)
                return;

            dataGridMasterArticles.DataSource = null;
            dataGridMasterArticles.Refresh();
            _masterArticleModel.GenerateFromSelectArticleFile(openArticleFileDialog.FileName);
            dataGridMasterArticles.DataSource = _masterArticleModel.MasterArticles;
            dataGridMasterArticles.Refresh();
        }

        /// <summary>
        /// processs DigitalShelf ArticleInfoRequested message
        /// </summary>
        /// <param name="sender">Sender of the event.</param>
        /// <param name="request">request message</param>
        private void DigitalShelf_ArticleInfoRequested(IDigitalShelf sender, IArticleInfoRequest request)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new ArticleInfoRequestEventHandler(DigitalShelf_ArticleInfoRequested),
                    new object[] { sender, request });
                return;
            }

            listBoxDigitalShelfLog.Items.Add(string.Format("Article information for '{0}' articles has been requested from the digital shelf.", request.Articles.Length));

            foreach (var article in request.Articles)
            {
                article.SetArticleInformation(article.Id, textBoxArticleName.Text, textBoxDosageForm.Text, textBoxPackagingUnit.Text, (uint)numericUpDownMaxSubItemQuantity.Value);
                
                foreach (var tag in listBoxTag.Items)
                {
                    article.AddTag((string)tag);
                }

                if (request.IncludeCrossSellingArticles)
                {
                    foreach(var crossSellingArticleId in listBoxCrossSellingArticle.Items)
                    {
                        article.AddCrossSellingArticle((string)crossSellingArticleId);
                    }
                }

                if (request.IncludeAlternativeArticles)
                {
                    foreach (var alternativeArticleId in listBoxAlternativeArticle.Items)
                    {
                        article.AddAlternativeArticle((string)alternativeArticleId);
                    }
                }

                if (request.IncludeAlternativePackSizeArticles)
                {
                    foreach (var AlternativePackSizeArticleId in listBoxAlternativePackSizeArticle.Items)
                    {
                        article.AddAlternativePackSizeArticle((string)AlternativePackSizeArticleId);
                    }
                }
            }

            request.Finish();
        }
        
        /// <summary>
        /// processs DigitalShelf ArticlePriceRequested message
        /// </summary>
        /// <param name="sender">Sender of the event.</param>
        /// <param name="request">request message</param>
        private void DigitalShelf_ArticlePriceRequested(IDigitalShelf sender, IArticlePriceRequest request)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new ArticlePriceRequestEventHandler(DigitalShelf_ArticlePriceRequested),
                    new object[] { sender, request });
                return;
            }

            listBoxDigitalShelfLog.Items.Add(string.Format("Price information for '{0}' articles has been requested from the digital shelf.", request.Articles.Length));

            foreach (var article in request.Articles)
            {
                foreach(var priceInformationItem in listBoxPriceInformation.Items)
                {
                    String[] priceInformations = ((string)priceInformationItem).Split(':');

                    PriceCategory priceCategory;
                    Enum.TryParse<PriceCategory>(priceInformations[0].Trim(), out priceCategory);

                    article.AddPriceInformation(priceCategory,
                        decimal.Parse(priceInformations[1].Trim()),
                        uint.Parse(priceInformations[2].Trim()),
                        decimal.Parse(priceInformations[3].Trim()),
                        priceInformations[4].Trim(),
                        decimal.Parse(priceInformations[5].Trim()),
                        priceInformations[6].Trim());
                }
            }

            request.Finish();
        }

        /// <summary>
        /// processs DigitalShelf ArticleSelected message
        /// </summary>
        /// <param name="sender">Sender of the event.</param>
        /// <param name="request">request message</param>
        private void DigitalShelf_ArticleSelected(IDigitalShelf sender, IDigitalShelfArticle article)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new ArticleSelectedEventHandler(DigitalShelf_ArticleSelected),
                    new object[] { sender, article });
                return;
            }

            listBoxDigitalShelfLog.Items.Add(string.Format("Article '{0} - {1}' has been selected on the digital shelf screen.", article.Id, article.Name));
        }

        /// <summary>
        /// processs DigitalShelf ShoppingCartRequested message
        /// </summary>
        /// <param name="sender">Sender of the event.</param>
        /// <param name="request">request message</param>
        private void DigitalShelf_ShoppingCartRequested(IDigitalShelf sender, IShoppingCartRequest request)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new ShoppingCartRequestEventHandler(DigitalShelf_ShoppingCartRequested),
                    new object[] { sender, request });
                return;
            }

            listBoxDigitalShelfLog.Items.Add(string.Format("Shopping cart has been requested from the digital shelf."));
            var shoppingCart = _digitalShelf.CreateShoppingCart(
                String.IsNullOrEmpty(request.Criteria.ShoppingCartId) ? new Random().Next().ToString() : request.Criteria.ShoppingCartId,
                (ShoppingCartStatus)comboBoxShoppingCartStatus.SelectedItem,
                string.IsNullOrEmpty(textBoxShoppingCartCustomerID.Text) ? request.Criteria.CustomerId : textBoxShoppingCartCustomerID.Text,
                string.IsNullOrEmpty(textBoxShoppingCartSalesPersonId.Text) ? request.Criteria.SalesPersonId : textBoxShoppingCartSalesPersonId.Text,
                string.IsNullOrEmpty(textBoxShoppingCartSalesPointID.Text) ? request.Criteria.SalesPointId : textBoxShoppingCartSalesPointID.Text,
                string.IsNullOrEmpty(textBoxShoppingCartViewPointID.Text) ? request.Criteria.ViewPointId : textBoxShoppingCartViewPointID.Text);

            foreach (ListViewItem item in listViewShoppingCartItemsForRequest.Items)
            {
                String[] ShoppingCartItemInformations = ((string)item.Tag).Split(':');

                shoppingCart.AddItem(ShoppingCartItemInformations[0],
                    uint.Parse(ShoppingCartItemInformations[2]),
                    uint.Parse(ShoppingCartItemInformations[3]),
                    uint.Parse(ShoppingCartItemInformations[4]),
                    ShoppingCartItemInformations[5],
                    ShoppingCartItemInformations[1]);
            }

            if (radioButtonShoppingCartAccept.Checked)
            {
                request.Accept(shoppingCart);
                listBoxDigitalShelfLog.Items.Add(string.Format("Shopping cart (ID:{0}) has been accepted from the digital shelf.", shoppingCart.Id));
            }
            else
            {
                request.Reject();
                listBoxDigitalShelfLog.Items.Add(string.Format("Shopping cart has been rejected from the digital shelf."));
            }

        }

        /// <summary>
        /// Handles the Click event of the buttonAddShoppingCartItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void buttonAddShoppingCartItem_Click(object sender, EventArgs e)
        {
            FAddShoppingCartItem addShoppingCartItem = new FAddShoppingCartItem();
            if (addShoppingCartItem.ShowDialog(this) == DialogResult.OK)
            {
                ListViewItem listNewItem = new ListViewItem(addShoppingCartItem.ArticleId);
                listNewItem.SubItems.Add(addShoppingCartItem.Currency);
                listNewItem.SubItems.Add(addShoppingCartItem.DispensedQuantity.ToString());
                listNewItem.SubItems.Add(addShoppingCartItem.OrderedQuantity.ToString());
                listNewItem.SubItems.Add(addShoppingCartItem.PaidQuantity.ToString());
                listNewItem.SubItems.Add(addShoppingCartItem.Price.ToString());
                listNewItem.Tag = addShoppingCartItem.ArticleId + ":" + addShoppingCartItem.Currency + ":" +
                                  addShoppingCartItem.DispensedQuantity + ":"
                                  + addShoppingCartItem.OrderedQuantity + ":" + addShoppingCartItem.PaidQuantity + ":" +
                                  addShoppingCartItem.Price;
                listViewShoppingCartItemsForRequest.Items.Add(listNewItem);
            }
        }

        /// <summary>
        /// Handles the Click event of the buttonRemovePriceInformation control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void buttonRemoveShoppingCartItem_Click(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection selectedItems = listViewShoppingCartItemsForRequest.SelectedItems;
            for (int i = selectedItems.Count - 1; i >= 0; i--)
            {
                listViewShoppingCartItemsForRequest.Items.Remove(selectedItems[i]);
            }
        }

        /// <summary>
        /// processs DigitalShelf ShoppingCartUpdateRequested message
        /// </summary>
        /// <param name="sender">Sender of the event.</param>
        /// <param name="request">request message</param>
        private void DigitalShelf_ShoppingCartUpdateRequested(IDigitalShelf sender, IShoppingCartUpdateRequest request)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new ShoppingCartUpdateRequestEventHandler(DigitalShelf_ShoppingCartUpdateRequested),
                    new object[] { sender, request });
                return;
            }

            listBoxDigitalShelfLog.Items.Add(string.Format("Shopping cart update has been requested from the digital shelf."));
            
            textBoxShoppingCartInfoID.Text = request.ShoppingCart.Id;
            comboBoxShoppingCartInfoStatus.SelectedItem = request.ShoppingCart.Status;
            textBoxShoppingCartInfoCustomerID.Text = request.ShoppingCart.CustomerId;
            textBoxShoppingCartInfoSalesPersonID.Text = request.ShoppingCart.SalesPersonId;
            textBoxShoppingCartInfoSalesPointID.Text = request.ShoppingCart.SalesPointId;
            textBoxShoppingCartInfoViewPointID.Text = request.ShoppingCart.ViewPointId;

            listViewShoppingCartItemsForUpdate.Items.Clear();
            foreach (IShoppingCartItem item in request.ShoppingCart.ShoppingCartItems)
            {
                ListViewItem listNewItem = new ListViewItem(item.ArticleId);
                listNewItem.SubItems.Add(item.Currency);
                listNewItem.SubItems.Add(item.DispensedQuantity.ToString());
                listNewItem.SubItems.Add(item.OrderedQuantity.ToString());
                listNewItem.SubItems.Add(item.PaidQuantity.ToString());
                listNewItem.SubItems.Add(item.Price.ToString());
                listViewShoppingCartItemsForUpdate.Items.Add(listNewItem);
            }

            _currentShoppingCartUpdateRequest = request;

            if (radioButtonShoppingCartUpdateAutoAccept.Checked)
            {
                buttonShoppingCartUpdateAutoAccept_Click(null, null);
            }
            else if (radioButtonShoppingCartUpdateAutoReject.Checked)
            {
                buttonShoppingCartUpdateAutoReject_Click(null, null);
                listViewShoppingCartItemsForUpdate.Items.RemoveAt(listViewShoppingCartItemsForUpdate.Items.Count - 1);
            }
            buttonShoppingCartUpdateAutoAccept.Enabled = _currentShoppingCartUpdateRequest != null;
            buttonShoppingCartUpdateAutoReject.Enabled = _currentShoppingCartUpdateRequest != null;
        }

        /// <summary>
        /// Handles the Click event of the  buttonShoppingCartUpdateAutoAccept control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void buttonShoppingCartUpdateAutoAccept_Click(object sender, EventArgs e)
        {
            _currentShoppingCartUpdateRequest.Accept(textBoxShoppingCartUpdateHandlingDescription.Text);
            _currentShoppingCartUpdateRequest = null;
            buttonShoppingCartUpdateAutoAccept.Enabled = false;
            buttonShoppingCartUpdateAutoReject.Enabled = false;
        }

        /// <summary>
        /// Handles the Click event of the  buttonShoppingCartUpdateAutoReject control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void buttonShoppingCartUpdateAutoReject_Click(object sender, EventArgs e)
        {
            _currentShoppingCartUpdateRequest.Reject(_currentShoppingCartUpdateRequest.ShoppingCart, textBoxShoppingCartUpdateHandlingDescription.Text);
            _currentShoppingCartUpdateRequest = null;
            buttonShoppingCartUpdateAutoAccept.Enabled = false;
            buttonShoppingCartUpdateAutoReject.Enabled = false;
        }

        /// <summary>
        /// Handles the Click event of the  buttonClearInputLog control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void buttonClearInputLog_Click(object sender, EventArgs e)
        {
            listBoxDigitalShelfLog.Items.Clear();
        }

        /// <summary>
        /// Handles the Click event of the  buttonDigitalShelfConnect control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void buttonDigitalShelfConnect_Click(object sender, EventArgs e)
        {
            buttonDigitalShelfDisconnect_Click(sender, e);
            buttonDigitalShelfConnect.Enabled = false;

            _digitalShelf = new RowaDigitalShelf();
            _digitalShelf.ArticleInfoRequested += DigitalShelf_ArticleInfoRequested;
            _digitalShelf.ArticlePriceRequested += DigitalShelf_ArticlePriceRequested;
            _digitalShelf.ArticleSelected += DigitalShelf_ArticleSelected;
            _digitalShelf.ShoppingCartRequested += DigitalShelf_ShoppingCartRequested;
            _digitalShelf.ShoppingCartUpdateRequested += DigitalShelf_ShoppingCartUpdateRequested;
            
            var connectParams = new string[] { textBoxDigitalShelfAddress.Text, numericUpDownDigitalShelfPort.Value.ToString() };
            backgroundWorkerConnectDigitalShelf.RunWorkerAsync(connectParams);
        }

        /// <summary>
        /// Handles the Click event of the  buttonDigitalShelfDisconnect control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void buttonDigitalShelfDisconnect_Click(object sender, EventArgs e)
        {
            buttonDigitalShelfDisconnect.Enabled = false;
            _digitalShelf.Disconnect();
            _digitalShelf.ArticleInfoRequested -= DigitalShelf_ArticleInfoRequested;
            _digitalShelf.ArticlePriceRequested -= DigitalShelf_ArticlePriceRequested;
            _digitalShelf.ArticleSelected -= DigitalShelf_ArticleSelected;
            _digitalShelf.ShoppingCartRequested -= DigitalShelf_ShoppingCartRequested;
            _digitalShelf.ShoppingCartUpdateRequested -= DigitalShelf_ShoppingCartUpdateRequested;

            _digitalShelf.Dispose();
            buttonDigitalShelfConnect.Enabled = true;
            btnSendRawXmlDigitalShelf.Enabled = false;
        }

        /// <summary>
        /// Handles the DoWork event of the backgroundWorkerConnectDigitalShelf control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.ComponentModel.DoWorkEventArgs"/> instance containing the event data.</param>
        private void backgroundWorkerConnectDigitalShelf_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                var connectParams = (string[])e.Argument;
                _digitalShelf.Connect(connectParams[0], ushort.Parse(connectParams[1]));
                e.Result = true;
            }
            catch (Exception)
            {
                e.Result = false;
            }
        }

        /// <summary>
        /// Handles the RunWorkerCompleted event of the backgroundWorkerConnectDigitalShelf control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.ComponentModel.RunWorkerCompletedEventArgs"/> instance containing the event data.</param>
        private void backgroundWorkerConnectDigitalShelf_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if ((e.Result == null) || ((bool)e.Result == false))
            {
                MessageBox.Show(string.Format("Connecting to digital shelf '{0}' failed.", textBoxDigitalShelfAddress.Text),
                                "IT System Simulator");

                buttonDigitalShelfConnect.Enabled = true;
            }
            else
            {
                // store as last known working
                using (var key = Registry.CurrentUser.CreateSubKey("Software\\CareFusion\\ITSystemSimulator"))
                {
                    key.SetValue("DigitalShelfAddress", textBoxDigitalShelfAddress.Text);
                    key.SetValue("DigitalShelfPort", (int)numericUpDownDigitalShelfPort.Value, RegistryValueKind.DWord);
                }
                buttonDigitalShelfDisconnect.Enabled = true;
                btnSendRawXmlDigitalShelf.Enabled = true;
            }
        }

        /// <summary>
        /// Handles the Click event of the buttonAddTag control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void buttonAddTag_Click(object sender, EventArgs e)
        {
            FArticleId newArticleID = new FArticleId();
            if (newArticleID.ShowDialog(this) == DialogResult.OK)
            {
                listBoxTag.Items.Add(newArticleID.ArticleId);
            }
        }

        /// <summary>
        /// Handles the Click event of the buttonRemoveTag control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void buttonRemoveTag_Click(object sender, EventArgs e)
        {
            ListBox.SelectedObjectCollection selectedItems = new ListBox.SelectedObjectCollection(listBoxTag);
            selectedItems = listBoxTag.SelectedItems;
            for (int i = selectedItems.Count - 1; i >= 0; i--)
            {
                listBoxTag.Items.Remove(selectedItems[i]);
            }
        }

        /// <summary>
        /// Handles the Click event of the buttonAddCrossSellingArticle control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void buttonAddCrossSellingArticle_Click(object sender, EventArgs e)
        {
            FArticleId newArticleID = new FArticleId();
            if (newArticleID.ShowDialog(this) == DialogResult.OK)
            {
                listBoxCrossSellingArticle.Items.Add(newArticleID.ArticleId);
            }
        }

        /// <summary>
        /// Handles the Click event of the buttonRemoveCrossSellingArticle control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void buttonRemoveCrossSellingArticle_Click(object sender, EventArgs e)
        {
            ListBox.SelectedObjectCollection selectedItems = new ListBox.SelectedObjectCollection(listBoxCrossSellingArticle);
            selectedItems = listBoxCrossSellingArticle.SelectedItems;
            for (int i = selectedItems.Count - 1; i >= 0; i--)
            {
                listBoxCrossSellingArticle.Items.Remove(selectedItems[i]);
            }
        }

        /// <summary>
        /// Handles the Click event of the buttonAddAlternativeArticle control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void buttonAddAlternativeArticle_Click(object sender, EventArgs e)
        {
            FArticleId newArticleID = new FArticleId();
            if (newArticleID.ShowDialog(this) == DialogResult.OK)
            {
                listBoxAlternativeArticle.Items.Add(newArticleID.ArticleId);
            }
        }

        /// <summary>
        /// Handles the Click event of the buttonRemoveAlternativeArticle control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void buttonRemoveAlternativeArticle_Click(object sender, EventArgs e)
        {
            ListBox.SelectedObjectCollection selectedItems = new ListBox.SelectedObjectCollection(listBoxAlternativeArticle);
            selectedItems = listBoxAlternativeArticle.SelectedItems;
            for (int i = selectedItems.Count - 1; i >= 0; i--)
            {
                listBoxAlternativeArticle.Items.Remove(selectedItems[i]);
            }
        }

        /// <summary>
        /// Handles the Click event of the buttonAddAlternativePackSizeArticle control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void buttonAddAlternativePackSizeArticle_Click(object sender, EventArgs e)
        {
            FArticleId newArticleID = new FArticleId();
            if (newArticleID.ShowDialog(this) == DialogResult.OK)
            {
                listBoxAlternativePackSizeArticle.Items.Add(newArticleID.ArticleId);
            }
        }

        /// <summary>
        /// Handles the Click event of the buttonRemoveAlternativePackSizeArticle control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void buttonRemoveAlternativePackSizeArticle_Click(object sender, EventArgs e)
        {
            ListBox.SelectedObjectCollection selectedItems = new ListBox.SelectedObjectCollection(listBoxAlternativePackSizeArticle);
            selectedItems = listBoxAlternativePackSizeArticle.SelectedItems;
            for (int i = selectedItems.Count - 1; i >= 0; i--)
            {
                listBoxAlternativePackSizeArticle.Items.Remove(selectedItems[i]);
            }
        }

        /// <summary>
        /// Handles the Click event of the buttonAddPriceInformation control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void buttonAddPriceInformation_Click(object sender, EventArgs e)
        {
            FAddPriceInformation addPriceInformation = new FAddPriceInformation();
            if (addPriceInformation.ShowDialog(this) == DialogResult.OK)
            {
                listBoxPriceInformation.Items.Add(
                    string.Format("{0} : {1} : {2} : {3} : {4} : {5} : {6}",
                        addPriceInformation.PriceCategory.ToString(),
                        addPriceInformation.Price,
                        addPriceInformation.Quantity,
                        addPriceInformation.BasePrice,
                        addPriceInformation.BasePriceUnit,
                        addPriceInformation.VAT,
                        addPriceInformation.Description));

            }
        }

        /// <summary>
        /// Handles the Click event of the buttonRemovePriceInformation control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void buttonRemovePriceInformation_Click(object sender, EventArgs e)
        {
            ListBox.SelectedObjectCollection selectedItems = new ListBox.SelectedObjectCollection(listBoxPriceInformation);
            selectedItems = listBoxPriceInformation.SelectedItems;
            for (int i = selectedItems.Count - 1; i >= 0; i--)
            {
                listBoxPriceInformation.Items.Remove(selectedItems[i]);
            }
        }

        /// <summary>
        /// Handles the Click event of the buttonClearDigitalShelfLog control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void buttonClearDigitalShelfLog_Click(object sender, EventArgs e)
        {
            listInputLog.Items.Clear();
        }

        /// <summary>
        /// Handles the Click event of the checkBoxTagAutoGenerate control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void checkBoxTagAutoGenerate_Click(object sender, EventArgs e)
        {
            listBoxTag.Enabled = !checkBoxTagAutoGenerate.Checked;
            buttonAddTag.Enabled = !checkBoxTagAutoGenerate.Checked;
            buttonRemoveTag.Enabled = !checkBoxTagAutoGenerate.Checked;
            
            listBoxTag.Items.Clear();

            if (checkBoxTagAutoGenerate.Checked)
            {
                listBoxTag.Items.Add("123");
                listBoxTag.Items.Add("124");
                listBoxTag.Items.Add("125");
            }
        }

        /// <summary>
        /// Handles the Click event of the checkBoxCrossSellingArticleAutoGenerate control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void checkBoxCrossSellingArticleAutoGenerate_Click(object sender, EventArgs e)
        {
            listBoxCrossSellingArticle.Enabled = !checkBoxCrossSellingArticleAutoGenerate.Checked;
            buttonAddCrossSellingArticle.Enabled = !checkBoxCrossSellingArticleAutoGenerate.Checked;
            buttonRemoveCrossSellingArticle.Enabled = !checkBoxCrossSellingArticleAutoGenerate.Checked;

            listBoxCrossSellingArticle.Items.Clear();

            if (checkBoxCrossSellingArticleAutoGenerate.Checked)
            {
                listBoxCrossSellingArticle.Items.Add("223");
                listBoxCrossSellingArticle.Items.Add("224");
                listBoxCrossSellingArticle.Items.Add("225");
            }
        }

        /// <summary>
        /// Handles the Click event of the checkBoxAlternativeArticlesAutoGenerate control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void checkBoxAlternativeArticlesAutoGenerate_Click(object sender, EventArgs e)
        {
            listBoxAlternativeArticle.Enabled = !checkBoxAlternativeArticlesAutoGenerate.Checked;
            buttonAddAlternativeArticle.Enabled = !checkBoxAlternativeArticlesAutoGenerate.Checked;
            buttonRemoveAlternativeArticle.Enabled = !checkBoxAlternativeArticlesAutoGenerate.Checked;

            listBoxAlternativeArticle.Items.Clear();

            if (checkBoxAlternativeArticlesAutoGenerate.Checked)
            {
                listBoxAlternativeArticle.Items.Add("323");
                listBoxAlternativeArticle.Items.Add("324");
                listBoxAlternativeArticle.Items.Add("325");
            }
        }

        /// <summary>
        /// Handles the Click event of the checkBoxAlternativePackSizeAutoGenerated control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void checkBoxAlternativePackSizeAutoGenerated_Click(object sender, EventArgs e)
        {
            listBoxAlternativePackSizeArticle.Enabled = !checkBoxAlternativeArticlesAutoGenerate.Checked;
            buttonAddAlternativePackSizeArticle.Enabled = !checkBoxAlternativeArticlesAutoGenerate.Checked;
            buttonRemoveAlternativePackSizeArticle.Enabled = !checkBoxAlternativeArticlesAutoGenerate.Checked;

            listBoxAlternativePackSizeArticle.Items.Clear();

            if (checkBoxAlternativeArticlesAutoGenerate.Checked)
            {
                listBoxAlternativePackSizeArticle.Items.Add("423");
                listBoxAlternativePackSizeArticle.Items.Add("424");
                listBoxAlternativePackSizeArticle.Items.Add("425");
            }
        }

        /// <summary>
        /// Handles the Click event of the checkBoxPriceInformationAutoGenerate control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void checkBoxPriceInformationAutoGenerate_Click(object sender, EventArgs e)
        {
            listBoxPriceInformation.Enabled = !checkBoxPriceInformationAutoGenerate.Checked;
            buttonAddPriceInformation.Enabled = !checkBoxPriceInformationAutoGenerate.Checked;
            buttonRemovePriceInformation.Enabled = !checkBoxPriceInformationAutoGenerate.Checked;

            listBoxPriceInformation.Items.Clear();

            if (checkBoxPriceInformationAutoGenerate.Checked)
            {
                listBoxPriceInformation.Items.Add(string.Format("{0} : {1} : {2} : {3} : {4} : {5} : {6}", PriceCategory.RRP.ToString(), 100, 1, 100, "EUR", 5, "Base price"));
                listBoxPriceInformation.Items.Add(string.Format("{0} : {1} : {2} : {3} : {4} : {5} : {6}", PriceCategory.Offer.ToString(), 80, 2, 100, "EUR", 5, "two for 80%"));
                listBoxPriceInformation.Items.Add(string.Format("{0} : {1} : {2} : {3} : {4} : {5} : {6}", PriceCategory.Other.ToString(), 50, 100, 100, "EUR", 5, ""));
            }
        }

        /// <summary>
        /// Handles the Click event of the checkBoxArticleInformationAutoGenerate control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void checkBoxArticleInformationAutoGenerate_Click(object sender, EventArgs e)
        {
            textBoxArticleName.Enabled = !checkBoxArticleInformationAutoGenerate.Checked;
            textBoxDosageForm.Enabled = !checkBoxArticleInformationAutoGenerate.Checked;
            textBoxPackagingUnit.Enabled = !checkBoxArticleInformationAutoGenerate.Checked;
            numericUpDownMaxSubItemQuantity.Enabled = !checkBoxArticleInformationAutoGenerate.Checked;
            
            if (checkBoxAlternativeArticlesAutoGenerate.Checked)
            {
                textBoxArticleName.Text = "BD | Digital Shelf Article";
                textBoxDosageForm.Text = "";
                textBoxPackagingUnit.Text = "";
                numericUpDownMaxSubItemQuantity.Value = 10;
            }
        }
     
        private void dataGridOrderBoxes_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void btnClearRawXml_Click(object sender, EventArgs e)
        {
            txtRawXml.Clear();
        }
        private void btnClearRawXmlDigitalShelf_Click(object sender, EventArgs e)
        {
            txtRawXmlDigitalShelf.Clear();
        }

        private void txtRawXml_TextChanged(object sender, EventArgs e)
        {
            btnSendRawXml.Enabled = (String.IsNullOrWhiteSpace(txtRawXml.Text) ? false : true)
                                    && (_storageSystem != null && _storageSystem.Connected);
        }

        private void btnSendRawXml_Click(object sender, EventArgs e)
        {
            if (_storageSystem != null && _storageSystem.Connected)
            {
                _storageSystem.SendRawXml(System.Text.Encoding.UTF8.GetBytes(txtRawXml.Text));
            }
        }

        private void btnSendRawXmlDigitalShelf_Click(object sender, EventArgs e)
        {
            if (_digitalShelf != null && _digitalShelf.Connected)
            {
                _digitalShelf.SendRawXml(System.Text.Encoding.UTF8.GetBytes(txtRawXmlDigitalShelf.Text));
            }
        }

        /// <summary>
        /// Handles the Click event of the checkAutoConnect control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void checkAutoConnect_CheckedChanged(object sender, EventArgs e)
        {
            if (checkAutoConnect.Checked)
            {
                btnConnect.Enabled = false;
                ConnectStorageSystem();
            }
            else
            {
                btnConnect.Enabled = !_storageSystem.Connected;
            }
        }


        private void btnImportStockDeliveries_Click(object sender, EventArgs e)
        {
            try
            {
                btnImportStockDeliveries.Enabled = false;
                if (openStockDeliveryFileDialog.ShowDialog(this) == DialogResult.OK)
                {
                    _stockDeliveryModel.LoadStockDelivery(openStockDeliveryFileDialog.FileName);
                    dataGridDeliveryItems.DataSource = _stockDeliveryModel.StockDeliveryItems;
                    dataGridDeliveryItems_SizeChanged(dataGridDeliveryItems, null);
                }

            }
            catch (Exception ex)
            {
                var msg = string.Format("Importing stock deliveries failed!\n\n{0}", ex.Message);
                MessageBox.Show(msg, "IT System Simulator");
            }

            btnImportStockDeliveries.Enabled = true;
        }
        
    }
}
