namespace CareFusion.ITSystemSimulator
{
    partial class FMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FMain));
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblStorageSystemStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.numPort = new System.Windows.Forms.NumericUpDown();
            this.btnConnect = new System.Windows.Forms.Button();
            this.groupConnection = new System.Windows.Forms.GroupBox();
            this.checkAutoConnect = new System.Windows.Forms.CheckBox();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.lblTenantId = new System.Windows.Forms.Label();
            this.txtTenantId = new System.Windows.Forms.TextBox();
            this.checkAutomaticStateObservation = new System.Windows.Forms.CheckBox();
            this.tabControlStorageSystem = new System.Windows.Forms.TabControl();
            this.tabStockDeliveries = new System.Windows.Forms.TabPage();
            this.btnImportStockDeliveries = new System.Windows.Forms.Button();
            this.dataGridDeliveryItems = new System.Windows.Forms.DataGridView();
            this.btnSendStockDeliveries = new System.Windows.Forms.Button();
            this.openArticleFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.bgInitInput = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerConnectDigitalShelf = new System.ComponentModel.BackgroundWorker();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPageStorageSystem = new System.Windows.Forms.TabPage();
            this.bgConnect = new System.ComponentModel.BackgroundWorker();
            this.bgStock = new System.ComponentModel.BackgroundWorker();
            this.textBoxDigitalShelfAddress = new System.Windows.Forms.TextBox();
            this.numericUpDownDigitalShelfPort = new System.Windows.Forms.NumericUpDown();
            this.buttonDigitalShelfConnect = new System.Windows.Forms.Button();
            this.buttonDigitalShelfDisconnect = new System.Windows.Forms.Button();
            this.tabRawXmlDigitalShelf = new System.Windows.Forms.TabPage();
            this.groupRawXmlDigitalShelf = new System.Windows.Forms.GroupBox();
            this.txtRawXmlDigitalShelf = new System.Windows.Forms.RichTextBox();
            this.btnSendRawXmlDigitalShelf = new System.Windows.Forms.Button();
            this.btnClearRawXmlDigitalShelf = new System.Windows.Forms.Button();
            this.tabPageShoppingCartRequested = new System.Windows.Forms.TabPage();
            this.tabControlShoppingCart = new System.Windows.Forms.TabControl();
            this.tabPageUpdate = new System.Windows.Forms.TabPage();
            this.groupBoxShoppingCartInfo = new System.Windows.Forms.GroupBox();
            this.labelShoppingCartInfoStatus = new System.Windows.Forms.Label();
            this.labelShoppingCartInfoSalesPersonID = new System.Windows.Forms.Label();
            this.labelShoppingCartInfoCustomerID = new System.Windows.Forms.Label();
            this.labelShoppingCartInfoSalesPointID = new System.Windows.Forms.Label();
            this.labelShoppingCartInfoViewPointID = new System.Windows.Forms.Label();
            this.labelShoppingCartInfoID = new System.Windows.Forms.Label();
            this.comboBoxShoppingCartInfoStatus = new System.Windows.Forms.ComboBox();
            this.textBoxShoppingCartInfoViewPointID = new System.Windows.Forms.TextBox();
            this.textBoxShoppingCartInfoSalesPointID = new System.Windows.Forms.TextBox();
            this.textBoxShoppingCartInfoSalesPersonID = new System.Windows.Forms.TextBox();
            this.textBoxShoppingCartInfoCustomerID = new System.Windows.Forms.TextBox();
            this.textBoxShoppingCartInfoID = new System.Windows.Forms.TextBox();
            this.groupBoxShoppingCartUpdateHandling = new System.Windows.Forms.GroupBox();
            this.labelShoppingCartUpdateHandlingManuel = new System.Windows.Forms.Label();
            this.labelShoppingCartUpdateHandlingAuto = new System.Windows.Forms.Label();
            this.buttonShoppingCartUpdateAutoAccept = new System.Windows.Forms.Button();
            this.buttonShoppingCartUpdateAutoReject = new System.Windows.Forms.Button();
            this.textBoxShoppingCartUpdateHandlingDescription = new System.Windows.Forms.TextBox();
            this.labelShoppingCartUpdateHandlingDescription = new System.Windows.Forms.Label();
            this.radioButtonShoppingCartUpdateAutoAccept = new System.Windows.Forms.RadioButton();
            this.radioButtonShoppingCartUpdateAutoReject = new System.Windows.Forms.RadioButton();
            this.radioButtonShoppingCartUpdateAutoManual = new System.Windows.Forms.RadioButton();
            this.groupBoxShoppingCartItemsForUpdate = new System.Windows.Forms.GroupBox();
            this.listViewShoppingCartItemsForUpdate = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPageRequest = new System.Windows.Forms.TabPage();
            this.groupBoxShoppingCartRequest = new System.Windows.Forms.GroupBox();
            this.labelStatus = new System.Windows.Forms.Label();
            this.labelSalesPersonId = new System.Windows.Forms.Label();
            this.labelCustomerId = new System.Windows.Forms.Label();
            this.labelSalesPointId = new System.Windows.Forms.Label();
            this.comboBoxShoppingCartStatus = new System.Windows.Forms.ComboBox();
            this.labelViewPointId = new System.Windows.Forms.Label();
            this.textBoxShoppingCartViewPointID = new System.Windows.Forms.TextBox();
            this.radioButtonShoppingCartAccept = new System.Windows.Forms.RadioButton();
            this.textBoxShoppingCartSalesPointID = new System.Windows.Forms.TextBox();
            this.radioButtonShoppingCartReject = new System.Windows.Forms.RadioButton();
            this.textBoxShoppingCartSalesPersonId = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBoxShoppingCartCustomerID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxShoppingCartItemsForRequest = new System.Windows.Forms.GroupBox();
            this.listViewShoppingCartItemsForRequest = new System.Windows.Forms.ListView();
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonAddShoppingCartItem = new System.Windows.Forms.Button();
            this.buttonRemoveShoppingCartItem = new System.Windows.Forms.Button();
            this.tabPagePriceInformation = new System.Windows.Forms.TabPage();
            this.groupBoxPriceInformation = new System.Windows.Forms.GroupBox();
            this.listBoxPriceInformation = new System.Windows.Forms.ListBox();
            this.buttonAddPriceInformation = new System.Windows.Forms.Button();
            this.buttonRemovePriceInformation = new System.Windows.Forms.Button();
            this.checkBoxPriceInformationAutoGenerate = new System.Windows.Forms.CheckBox();
            this.tabPageArticleInfo = new System.Windows.Forms.TabPage();
            this.groupBoxCrossSellingArticle = new System.Windows.Forms.GroupBox();
            this.listBoxCrossSellingArticle = new System.Windows.Forms.ListBox();
            this.buttonAddCrossSellingArticle = new System.Windows.Forms.Button();
            this.buttonRemoveCrossSellingArticle = new System.Windows.Forms.Button();
            this.checkBoxCrossSellingArticleAutoGenerate = new System.Windows.Forms.CheckBox();
            this.groupBoxAlternativeArticle = new System.Windows.Forms.GroupBox();
            this.listBoxAlternativeArticle = new System.Windows.Forms.ListBox();
            this.buttonAddAlternativeArticle = new System.Windows.Forms.Button();
            this.buttonRemoveAlternativeArticle = new System.Windows.Forms.Button();
            this.checkBoxAlternativeArticlesAutoGenerate = new System.Windows.Forms.CheckBox();
            this.groupBoxAlternativePackSizeArticle = new System.Windows.Forms.GroupBox();
            this.listBoxAlternativePackSizeArticle = new System.Windows.Forms.ListBox();
            this.buttonAddAlternativePackSizeArticle = new System.Windows.Forms.Button();
            this.buttonRemoveAlternativePackSizeArticle = new System.Windows.Forms.Button();
            this.checkBoxAlternativePackSizeAutoGenerated = new System.Windows.Forms.CheckBox();
            this.groupBoxTag = new System.Windows.Forms.GroupBox();
            this.listBoxTag = new System.Windows.Forms.ListBox();
            this.buttonAddTag = new System.Windows.Forms.Button();
            this.buttonRemoveTag = new System.Windows.Forms.Button();
            this.checkBoxTagAutoGenerate = new System.Windows.Forms.CheckBox();
            this.groupBoxArticleInformation = new System.Windows.Forms.GroupBox();
            this.checkBoxArticleInformationAutoGenerate = new System.Windows.Forms.CheckBox();
            this.textBoxArticleName = new System.Windows.Forms.TextBox();
            this.labelArticleName = new System.Windows.Forms.Label();
            this.labelDosageForm = new System.Windows.Forms.Label();
            this.textBoxDosageForm = new System.Windows.Forms.TextBox();
            this.labelPackagingUnit = new System.Windows.Forms.Label();
            this.textBoxPackagingUnit = new System.Windows.Forms.TextBox();
            this.labelMaxSubItemQuantity = new System.Windows.Forms.Label();
            this.numericUpDownMaxSubItemQuantity = new System.Windows.Forms.NumericUpDown();
            this.tabPageLog = new System.Windows.Forms.TabPage();
            this.listBoxDigitalShelfLog = new System.Windows.Forms.ListBox();
            this.buttonClearDigitalShelfLog = new System.Windows.Forms.Button();
            this.btnSendRawXml = new System.Windows.Forms.Button();
            this.btnClearRawXml = new System.Windows.Forms.Button();
            this.txtRawXml = new System.Windows.Forms.RichTextBox();
            this.btnReloadStockLocations = new System.Windows.Forms.Button();
            this.dataGridStockLocations = new System.Windows.Forms.DataGridView();
            this.btnReloadComponents = new System.Windows.Forms.Button();
            this.dataGridComponents = new System.Windows.Forms.DataGridView();
            this.dataGridArticleInfo = new System.Windows.Forms.DataGridView();
            this.dataGridPackInfo = new System.Windows.Forms.DataGridView();
            this.lblTaskID = new System.Windows.Forms.Label();
            this.txtTaskID = new System.Windows.Forms.TextBox();
            this.lblTaskType = new System.Windows.Forms.Label();
            this.cmbTaskType = new System.Windows.Forms.ComboBox();
            this.lblTaskStateDesc = new System.Windows.Forms.Label();
            this.lblTaskState = new System.Windows.Forms.Label();
            this.btnGetTaskInfo = new System.Windows.Forms.Button();
            this.dataGridMasterArticles = new System.Windows.Forms.DataGridView();
            this.dataGridOrderItems = new System.Windows.Forms.DataGridView();
            this.dataGridItemLabels = new System.Windows.Forms.DataGridView();
            this.dataGridDispensedPacks = new System.Windows.Forms.DataGridView();
            this.dataGridOrders = new System.Windows.Forms.DataGridView();
            this.btnNewOrder = new System.Windows.Forms.Button();
            this.btnSendOrder = new System.Windows.Forms.Button();
            this.btnCancelOrder = new System.Windows.Forms.Button();
            this.btnClearOrders = new System.Windows.Forms.Button();
            this.btnBulkOrder = new System.Windows.Forms.Button();
            this.dataGridOrderBoxes = new System.Windows.Forms.DataGridView();
            this.chkSetPickingIndicator = new System.Windows.Forms.CheckBox();
            this.lblInitInputID = new System.Windows.Forms.Label();
            this.txtDeliveryNumber = new System.Windows.Forms.TextBox();
            this.numInitInputID = new System.Windows.Forms.NumericUpDown();
            this.lblDeliveryNumber = new System.Windows.Forms.Label();
            this.lblInputSource = new System.Windows.Forms.Label();
            this.numInputSource = new System.Windows.Forms.NumericUpDown();
            this.txtPackScanCode = new System.Windows.Forms.TextBox();
            this.lblPackScanCode = new System.Windows.Forms.Label();
            this.txtPackBatchNumber = new System.Windows.Forms.TextBox();
            this.lblPackBatchNumber = new System.Windows.Forms.Label();
            this.txtPackExpiryDate = new System.Windows.Forms.TextBox();
            this.lblPackExpiryDate = new System.Windows.Forms.Label();
            this.lblPackSubItemQuantity = new System.Windows.Forms.Label();
            this.numPackSubItemQuantity = new System.Windows.Forms.NumericUpDown();
            this.lblPackDepth = new System.Windows.Forms.Label();
            this.numPackDepth = new System.Windows.Forms.NumericUpDown();
            this.lblPackWidth = new System.Windows.Forms.Label();
            this.numPackWidth = new System.Windows.Forms.NumericUpDown();
            this.lblPackHeight = new System.Windows.Forms.Label();
            this.numPackHeight = new System.Windows.Forms.NumericUpDown();
            this.lblPackShape = new System.Windows.Forms.Label();
            this.cmbPackShape = new System.Windows.Forms.ComboBox();
            this.btnSendInitInputRequest = new System.Windows.Forms.Button();
            this.lblInputPoint = new System.Windows.Forms.Label();
            this.numInputPoint = new System.Windows.Forms.NumericUpDown();
            this.lblDestination = new System.Windows.Forms.Label();
            this.numDestination = new System.Windows.Forms.NumericUpDown();
            this.txtPackStockLocation = new System.Windows.Forms.TextBox();
            this.lblStockLocation = new System.Windows.Forms.Label();
            this.listInitInputLog = new System.Windows.Forms.ListBox();
            this.btnClearInitInputLog = new System.Windows.Forms.Button();
            this.txtConfiguration = new System.Windows.Forms.TextBox();
            this.lblConfiguration = new System.Windows.Forms.Label();
            this.btnGetConfig = new System.Windows.Forms.Button();
            this.checkAllowDeliveryInput = new System.Windows.Forms.CheckBox();
            this.checkEnforceBatchStockReturn = new System.Windows.Forms.CheckBox();
            this.checkEnforceBatchDelivery = new System.Windows.Forms.CheckBox();
            this.checkEnforceExpiryDateStockReturn = new System.Windows.Forms.CheckBox();
            this.checkEnforceExpiryDateDelivery = new System.Windows.Forms.CheckBox();
            this.checkAllowStockReturnInput = new System.Windows.Forms.CheckBox();
            this.checkOnlyFridgeInput = new System.Windows.Forms.CheckBox();
            this.checkEnforcePickingIndicator = new System.Windows.Forms.CheckBox();
            this.checkSetSubItemQuantity = new System.Windows.Forms.CheckBox();
            this.checkEnforceLocationStockReturn = new System.Windows.Forms.CheckBox();
            this.checkEnforceLocationNewDelivery = new System.Windows.Forms.CheckBox();
            this.numExpiryDateMonth = new System.Windows.Forms.NumericUpDown();
            this.lblDefExpiryDate = new System.Windows.Forms.Label();
            this.checkOverwriteStockLocation = new System.Windows.Forms.CheckBox();
            this.txtOverwriteStockLocation = new System.Windows.Forms.TextBox();
            this.checkOnlyArticlesFromList = new System.Windows.Forms.CheckBox();
            this.checkBoxSetVirtualArticle = new System.Windows.Forms.CheckBox();
            this.checkEnforceSerialNumberStockReturn = new System.Windows.Forms.CheckBox();
            this.checkEnforceSerialNumberNewDelivery = new System.Windows.Forms.CheckBox();
            this.listInputLog = new System.Windows.Forms.ListBox();
            this.btnClearInputLog = new System.Windows.Forms.Button();
            this.dataGridPacks = new System.Windows.Forms.DataGridView();
            this.dataGridArticles = new System.Windows.Forms.DataGridView();
            this.openStockDeliveryFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPort)).BeginInit();
            this.groupConnection.SuspendLayout();
            this.tabControlStorageSystem.SuspendLayout();
            this.tabStockDeliveries.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDeliveryItems)).BeginInit();
            this.tabControlMain.SuspendLayout();
            this.tabPageStorageSystem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDigitalShelfPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxSubItemQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridStockLocations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridComponents)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridArticleInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPackInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridMasterArticles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridOrderItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridItemLabels)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDispensedPacks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridOrderBoxes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numInitInputID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numInputSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPackSubItemQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPackDepth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPackWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPackHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numInputPoint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDestination)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numExpiryDateMonth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPacks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridArticles)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStorageSystemStatus});
            this.statusStrip.Location = new System.Drawing.Point(0, 1231);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(2, 0, 28, 0);
            this.statusStrip.Size = new System.Drawing.Size(1992, 42);
            this.statusStrip.TabIndex = 0;
            this.statusStrip.Text = "statusStrip";
            // 
            // lblStorageSystemStatus
            // 
            this.lblStorageSystemStatus.Name = "lblStorageSystemStatus";
            this.lblStorageSystemStatus.Size = new System.Drawing.Size(262, 32);
            this.lblStorageSystemStatus.Text = "Robot Status: Unknown";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(26, 38);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(6);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(196, 31);
            this.txtAddress.TabIndex = 1;
            this.txtAddress.Text = "localhost";
            this.txtAddress.TextChanged += new System.EventHandler(this.txtAddress_TextChanged);
            // 
            // numPort
            // 
            this.numPort.Location = new System.Drawing.Point(240, 38);
            this.numPort.Margin = new System.Windows.Forms.Padding(6);
            this.numPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numPort.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numPort.Name = "numPort";
            this.numPort.Size = new System.Drawing.Size(144, 31);
            this.numPort.TabIndex = 2;
            this.numPort.Value = new decimal(new int[] {
            6050,
            0,
            0,
            0});
            // 
            // btnConnect
            // 
            this.btnConnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConnect.Location = new System.Drawing.Point(1620, 35);
            this.btnConnect.Margin = new System.Windows.Forms.Padding(6);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(150, 44);
            this.btnConnect.TabIndex = 6;
            this.btnConnect.Text = "&Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // groupConnection
            // 
            this.groupConnection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupConnection.Controls.Add(this.checkAutoConnect);
            this.groupConnection.Controls.Add(this.btnDisconnect);
            this.groupConnection.Controls.Add(this.lblTenantId);
            this.groupConnection.Controls.Add(this.txtTenantId);
            this.groupConnection.Controls.Add(this.checkAutomaticStateObservation);
            this.groupConnection.Controls.Add(this.btnConnect);
            this.groupConnection.Controls.Add(this.numPort);
            this.groupConnection.Controls.Add(this.txtAddress);
            this.groupConnection.Location = new System.Drawing.Point(12, 12);
            this.groupConnection.Margin = new System.Windows.Forms.Padding(6);
            this.groupConnection.Name = "groupConnection";
            this.groupConnection.Padding = new System.Windows.Forms.Padding(6);
            this.groupConnection.Size = new System.Drawing.Size(1952, 104);
            this.groupConnection.TabIndex = 0;
            this.groupConnection.TabStop = false;
            this.groupConnection.Text = "Storage System";
            // 
            // checkAutoConnect
            // 
            this.checkAutoConnect.AutoSize = true;
            this.checkAutoConnect.Location = new System.Drawing.Point(686, 46);
            this.checkAutoConnect.Margin = new System.Windows.Forms.Padding(6);
            this.checkAutoConnect.Name = "checkAutoConnect";
            this.checkAutoConnect.Size = new System.Drawing.Size(174, 29);
            this.checkAutoConnect.TabIndex = 8;
            this.checkAutoConnect.Text = "Auto Connect";
            this.checkAutoConnect.UseVisualStyleBackColor = true;
            this.checkAutoConnect.CheckedChanged += new System.EventHandler(this.checkAutoConnect_CheckedChanged);
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDisconnect.Enabled = false;
            this.btnDisconnect.Location = new System.Drawing.Point(1782, 33);
            this.btnDisconnect.Margin = new System.Windows.Forms.Padding(6);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(150, 44);
            this.btnDisconnect.TabIndex = 7;
            this.btnDisconnect.Text = "&Disconnect";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // lblTenantId
            // 
            this.lblTenantId.AutoSize = true;
            this.lblTenantId.Location = new System.Drawing.Point(394, 44);
            this.lblTenantId.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblTenantId.Name = "lblTenantId";
            this.lblTenantId.Size = new System.Drawing.Size(108, 25);
            this.lblTenantId.TabIndex = 3;
            this.lblTenantId.Text = "Tenant Id:";
            // 
            // txtTenantId
            // 
            this.txtTenantId.Location = new System.Drawing.Point(518, 37);
            this.txtTenantId.Margin = new System.Windows.Forms.Padding(6);
            this.txtTenantId.Name = "txtTenantId";
            this.txtTenantId.Size = new System.Drawing.Size(128, 31);
            this.txtTenantId.TabIndex = 4;
            // 
            // checkAutomaticStateObservation
            // 
            this.checkAutomaticStateObservation.AutoSize = true;
            this.checkAutomaticStateObservation.Checked = true;
            this.checkAutomaticStateObservation.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkAutomaticStateObservation.Location = new System.Drawing.Point(944, 46);
            this.checkAutomaticStateObservation.Margin = new System.Windows.Forms.Padding(6);
            this.checkAutomaticStateObservation.Name = "checkAutomaticStateObservation";
            this.checkAutomaticStateObservation.Size = new System.Drawing.Size(317, 29);
            this.checkAutomaticStateObservation.TabIndex = 5;
            this.checkAutomaticStateObservation.Text = "Automatic State Observation";
            this.checkAutomaticStateObservation.UseVisualStyleBackColor = true;
            this.checkAutomaticStateObservation.CheckedChanged += new System.EventHandler(this.checkAutomaticStateObservation_CheckedChanged);
            // 
            // tabControlStorageSystem
            // 
            this.tabControlStorageSystem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlStorageSystem.Controls.Add(this.tabStockDeliveries);
            this.tabControlStorageSystem.Location = new System.Drawing.Point(0, 127);
            this.tabControlStorageSystem.Margin = new System.Windows.Forms.Padding(6);
            this.tabControlStorageSystem.Name = "tabControlStorageSystem";
            this.tabControlStorageSystem.SelectedIndex = 0;
            this.tabControlStorageSystem.Size = new System.Drawing.Size(1980, 1052);
            this.tabControlStorageSystem.TabIndex = 8;
            // 
            // tabStockDeliveries
            // 
            this.tabStockDeliveries.Controls.Add(this.btnImportStockDeliveries);
            this.tabStockDeliveries.Controls.Add(this.dataGridDeliveryItems);
            this.tabStockDeliveries.Controls.Add(this.btnSendStockDeliveries);
            this.tabStockDeliveries.Location = new System.Drawing.Point(8, 39);
            this.tabStockDeliveries.Margin = new System.Windows.Forms.Padding(6);
            this.tabStockDeliveries.Name = "tabStockDeliveries";
            this.tabStockDeliveries.Padding = new System.Windows.Forms.Padding(6);
            this.tabStockDeliveries.Size = new System.Drawing.Size(1964, 1005);
            this.tabStockDeliveries.TabIndex = 4;
            this.tabStockDeliveries.Text = "Stock Deliveries";
            this.tabStockDeliveries.UseVisualStyleBackColor = true;
            // 
            // btnImportStockDeliveries
            // 
            this.btnImportStockDeliveries.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnImportStockDeliveries.Enabled = false;
            this.btnImportStockDeliveries.Location = new System.Drawing.Point(16, 906);
            this.btnImportStockDeliveries.Margin = new System.Windows.Forms.Padding(6);
            this.btnImportStockDeliveries.Name = "btnImportStockDeliveries";
            this.btnImportStockDeliveries.Size = new System.Drawing.Size(309, 44);
            this.btnImportStockDeliveries.TabIndex = 10;
            this.btnImportStockDeliveries.Text = "Import from Select ...";
            this.btnImportStockDeliveries.UseVisualStyleBackColor = true;
            this.btnImportStockDeliveries.Click += new System.EventHandler(this.btnImportStockDeliveries_Click);
            // 
            // dataGridDeliveryItems
            // 
            this.dataGridDeliveryItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridDeliveryItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridDeliveryItems.Location = new System.Drawing.Point(16, 12);
            this.dataGridDeliveryItems.Margin = new System.Windows.Forms.Padding(6);
            this.dataGridDeliveryItems.Name = "dataGridDeliveryItems";
            this.dataGridDeliveryItems.RowHeadersWidth = 82;
            this.dataGridDeliveryItems.Size = new System.Drawing.Size(1920, 883);
            this.dataGridDeliveryItems.TabIndex = 9;
            this.dataGridDeliveryItems.SizeChanged += new System.EventHandler(this.dataGridDeliveryItems_SizeChanged);
            // 
            // btnSendStockDeliveries
            // 
            this.btnSendStockDeliveries.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSendStockDeliveries.Enabled = false;
            this.btnSendStockDeliveries.Location = new System.Drawing.Point(1782, 906);
            this.btnSendStockDeliveries.Margin = new System.Windows.Forms.Padding(6);
            this.btnSendStockDeliveries.Name = "btnSendStockDeliveries";
            this.btnSendStockDeliveries.Size = new System.Drawing.Size(150, 44);
            this.btnSendStockDeliveries.TabIndex = 11;
            this.btnSendStockDeliveries.Text = "Send";
            this.btnSendStockDeliveries.UseVisualStyleBackColor = true;
            this.btnSendStockDeliveries.Click += new System.EventHandler(this.btnSendStockDeliveries_Click);
            // 
            // openArticleFileDialog
            // 
            this.openArticleFileDialog.DefaultExt = "txt";
            this.openArticleFileDialog.FileName = "ArtikelNamen.txt";
            this.openArticleFileDialog.Filter = "Article Files|*.txt|All files|*.*";
            this.openArticleFileDialog.Title = "Select the Article Export File";
            // 
            // bgInitInput
            // 
            this.bgInitInput.WorkerReportsProgress = true;
            this.bgInitInput.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgInitInput_DoWork);
            this.bgInitInput.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgInitInput_ProgressChanged);
            this.bgInitInput.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgInitInput_RunWorkerCompleted);
            // 
            // backgroundWorkerConnectDigitalShelf
            // 
            this.backgroundWorkerConnectDigitalShelf.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerConnectDigitalShelf_DoWork);
            this.backgroundWorkerConnectDigitalShelf.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerConnectDigitalShelf_RunWorkerCompleted);
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabPageStorageSystem);
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.Location = new System.Drawing.Point(0, 0);
            this.tabControlMain.Margin = new System.Windows.Forms.Padding(6);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(1992, 1231);
            this.tabControlMain.TabIndex = 10;
            // 
            // tabPageStorageSystem
            // 
            this.tabPageStorageSystem.Controls.Add(this.groupConnection);
            this.tabPageStorageSystem.Controls.Add(this.tabControlStorageSystem);
            this.tabPageStorageSystem.Location = new System.Drawing.Point(8, 39);
            this.tabPageStorageSystem.Margin = new System.Windows.Forms.Padding(6);
            this.tabPageStorageSystem.Name = "tabPageStorageSystem";
            this.tabPageStorageSystem.Padding = new System.Windows.Forms.Padding(6);
            this.tabPageStorageSystem.Size = new System.Drawing.Size(1976, 1184);
            this.tabPageStorageSystem.TabIndex = 0;
            this.tabPageStorageSystem.Text = "Storage System";
            this.tabPageStorageSystem.UseVisualStyleBackColor = true;
            // 
            // bgConnect
            // 
            this.bgConnect.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgConnect_DoWork);
            this.bgConnect.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgConnect_RunWorkerCompleted);
            // 
            // bgStock
            // 
            this.bgStock.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgStock_DoWork);
            this.bgStock.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgStock_RunWorkerCompleted);
            // 
            // textBoxDigitalShelfAddress
            // 
            this.textBoxDigitalShelfAddress.Location = new System.Drawing.Point(26, 38);
            this.textBoxDigitalShelfAddress.Margin = new System.Windows.Forms.Padding(6);
            this.textBoxDigitalShelfAddress.Name = "textBoxDigitalShelfAddress";
            this.textBoxDigitalShelfAddress.Size = new System.Drawing.Size(196, 31);
            this.textBoxDigitalShelfAddress.TabIndex = 1;
            // 
            // numericUpDownDigitalShelfPort
            // 
            this.numericUpDownDigitalShelfPort.Location = new System.Drawing.Point(240, 38);
            this.numericUpDownDigitalShelfPort.Margin = new System.Windows.Forms.Padding(6);
            this.numericUpDownDigitalShelfPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numericUpDownDigitalShelfPort.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownDigitalShelfPort.Name = "numericUpDownDigitalShelfPort";
            this.numericUpDownDigitalShelfPort.Size = new System.Drawing.Size(144, 31);
            this.numericUpDownDigitalShelfPort.TabIndex = 2;
            this.numericUpDownDigitalShelfPort.Value = new decimal(new int[] {
            6050,
            0,
            0,
            0});
            // 
            // buttonDigitalShelfConnect
            // 
            this.buttonDigitalShelfConnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDigitalShelfConnect.Location = new System.Drawing.Point(1620, 35);
            this.buttonDigitalShelfConnect.Margin = new System.Windows.Forms.Padding(6);
            this.buttonDigitalShelfConnect.Name = "buttonDigitalShelfConnect";
            this.buttonDigitalShelfConnect.Size = new System.Drawing.Size(150, 44);
            this.buttonDigitalShelfConnect.TabIndex = 6;
            this.buttonDigitalShelfConnect.Text = "&Connect";
            this.buttonDigitalShelfConnect.UseVisualStyleBackColor = true;
            this.buttonDigitalShelfConnect.Click += new System.EventHandler(this.buttonDigitalShelfConnect_Click);
            // 
            // buttonDigitalShelfDisconnect
            // 
            this.buttonDigitalShelfDisconnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDigitalShelfDisconnect.Enabled = false;
            this.buttonDigitalShelfDisconnect.Location = new System.Drawing.Point(1782, 33);
            this.buttonDigitalShelfDisconnect.Margin = new System.Windows.Forms.Padding(6);
            this.buttonDigitalShelfDisconnect.Name = "buttonDigitalShelfDisconnect";
            this.buttonDigitalShelfDisconnect.Size = new System.Drawing.Size(150, 44);
            this.buttonDigitalShelfDisconnect.TabIndex = 7;
            this.buttonDigitalShelfDisconnect.Text = "&Disconnect";
            this.buttonDigitalShelfDisconnect.UseVisualStyleBackColor = true;
            this.buttonDigitalShelfDisconnect.Click += new System.EventHandler(this.buttonDigitalShelfDisconnect_Click);
            // 
            // tabRawXmlDigitalShelf
            // 
            this.tabRawXmlDigitalShelf.Location = new System.Drawing.Point(8, 39);
            this.tabRawXmlDigitalShelf.Margin = new System.Windows.Forms.Padding(6);
            this.tabRawXmlDigitalShelf.Name = "tabRawXmlDigitalShelf";
            this.tabRawXmlDigitalShelf.Size = new System.Drawing.Size(1960, 995);
            this.tabRawXmlDigitalShelf.TabIndex = 4;
            this.tabRawXmlDigitalShelf.Text = "Raw XML";
            this.tabRawXmlDigitalShelf.UseVisualStyleBackColor = true;
            // 
            // groupRawXmlDigitalShelf
            // 
            this.groupRawXmlDigitalShelf.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupRawXmlDigitalShelf.Location = new System.Drawing.Point(8, 6);
            this.groupRawXmlDigitalShelf.Margin = new System.Windows.Forms.Padding(6);
            this.groupRawXmlDigitalShelf.Name = "groupRawXmlDigitalShelf";
            this.groupRawXmlDigitalShelf.Padding = new System.Windows.Forms.Padding(6);
            this.groupRawXmlDigitalShelf.Size = new System.Drawing.Size(1934, 940);
            this.groupRawXmlDigitalShelf.TabIndex = 0;
            this.groupRawXmlDigitalShelf.TabStop = false;
            // 
            // txtRawXmlDigitalShelf
            // 
            this.txtRawXmlDigitalShelf.AutoWordSelection = true;
            this.txtRawXmlDigitalShelf.Location = new System.Drawing.Point(16, 62);
            this.txtRawXmlDigitalShelf.Margin = new System.Windows.Forms.Padding(6);
            this.txtRawXmlDigitalShelf.Name = "txtRawXmlDigitalShelf";
            this.txtRawXmlDigitalShelf.Size = new System.Drawing.Size(1162, 492);
            this.txtRawXmlDigitalShelf.TabIndex = 4;
            this.txtRawXmlDigitalShelf.Text = "";
            // 
            // btnSendRawXmlDigitalShelf
            // 
            this.btnSendRawXmlDigitalShelf.Enabled = false;
            this.btnSendRawXmlDigitalShelf.Location = new System.Drawing.Point(1032, 569);
            this.btnSendRawXmlDigitalShelf.Margin = new System.Windows.Forms.Padding(6);
            this.btnSendRawXmlDigitalShelf.Name = "btnSendRawXmlDigitalShelf";
            this.btnSendRawXmlDigitalShelf.Size = new System.Drawing.Size(150, 44);
            this.btnSendRawXmlDigitalShelf.TabIndex = 5;
            this.btnSendRawXmlDigitalShelf.Text = "Send";
            this.btnSendRawXmlDigitalShelf.UseVisualStyleBackColor = true;
            this.btnSendRawXmlDigitalShelf.Click += new System.EventHandler(this.btnSendRawXmlDigitalShelf_Click);
            // 
            // btnClearRawXmlDigitalShelf
            // 
            this.btnClearRawXmlDigitalShelf.Location = new System.Drawing.Point(870, 569);
            this.btnClearRawXmlDigitalShelf.Margin = new System.Windows.Forms.Padding(6);
            this.btnClearRawXmlDigitalShelf.Name = "btnClearRawXmlDigitalShelf";
            this.btnClearRawXmlDigitalShelf.Size = new System.Drawing.Size(150, 44);
            this.btnClearRawXmlDigitalShelf.TabIndex = 6;
            this.btnClearRawXmlDigitalShelf.Text = "Clear";
            this.btnClearRawXmlDigitalShelf.UseVisualStyleBackColor = true;
            this.btnClearRawXmlDigitalShelf.Click += new System.EventHandler(this.btnClearRawXmlDigitalShelf_Click);
            // 
            // tabPageShoppingCartRequested
            // 
            this.tabPageShoppingCartRequested.Location = new System.Drawing.Point(8, 39);
            this.tabPageShoppingCartRequested.Margin = new System.Windows.Forms.Padding(6);
            this.tabPageShoppingCartRequested.Name = "tabPageShoppingCartRequested";
            this.tabPageShoppingCartRequested.Size = new System.Drawing.Size(1960, 995);
            this.tabPageShoppingCartRequested.TabIndex = 3;
            this.tabPageShoppingCartRequested.Text = "Shopping Cart";
            this.tabPageShoppingCartRequested.UseVisualStyleBackColor = true;
            // 
            // tabControlShoppingCart
            // 
            this.tabControlShoppingCart.Location = new System.Drawing.Point(4, 6);
            this.tabControlShoppingCart.Margin = new System.Windows.Forms.Padding(6);
            this.tabControlShoppingCart.Name = "tabControlShoppingCart";
            this.tabControlShoppingCart.SelectedIndex = 0;
            this.tabControlShoppingCart.Size = new System.Drawing.Size(1948, 963);
            this.tabControlShoppingCart.TabIndex = 16;
            // 
            // tabPageUpdate
            // 
            this.tabPageUpdate.Location = new System.Drawing.Point(8, 39);
            this.tabPageUpdate.Margin = new System.Windows.Forms.Padding(6);
            this.tabPageUpdate.Name = "tabPageUpdate";
            this.tabPageUpdate.Padding = new System.Windows.Forms.Padding(6);
            this.tabPageUpdate.Size = new System.Drawing.Size(1932, 916);
            this.tabPageUpdate.TabIndex = 1;
            this.tabPageUpdate.Text = "Update";
            this.tabPageUpdate.UseVisualStyleBackColor = true;
            // 
            // groupBoxShoppingCartInfo
            // 
            this.groupBoxShoppingCartInfo.Location = new System.Drawing.Point(12, 12);
            this.groupBoxShoppingCartInfo.Margin = new System.Windows.Forms.Padding(6);
            this.groupBoxShoppingCartInfo.Name = "groupBoxShoppingCartInfo";
            this.groupBoxShoppingCartInfo.Padding = new System.Windows.Forms.Padding(6);
            this.groupBoxShoppingCartInfo.Size = new System.Drawing.Size(466, 354);
            this.groupBoxShoppingCartInfo.TabIndex = 11;
            this.groupBoxShoppingCartInfo.TabStop = false;
            // 
            // labelShoppingCartInfoStatus
            // 
            this.labelShoppingCartInfoStatus.AutoSize = true;
            this.labelShoppingCartInfoStatus.Location = new System.Drawing.Point(12, 94);
            this.labelShoppingCartInfoStatus.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelShoppingCartInfoStatus.Name = "labelShoppingCartInfoStatus";
            this.labelShoppingCartInfoStatus.Size = new System.Drawing.Size(85, 25);
            this.labelShoppingCartInfoStatus.TabIndex = 14;
            // 
            // labelShoppingCartInfoSalesPersonID
            // 
            this.labelShoppingCartInfoSalesPersonID.AutoSize = true;
            this.labelShoppingCartInfoSalesPersonID.Location = new System.Drawing.Point(10, 196);
            this.labelShoppingCartInfoSalesPersonID.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelShoppingCartInfoSalesPersonID.Name = "labelShoppingCartInfoSalesPersonID";
            this.labelShoppingCartInfoSalesPersonID.Size = new System.Drawing.Size(175, 25);
            this.labelShoppingCartInfoSalesPersonID.TabIndex = 15;
            // 
            // labelShoppingCartInfoCustomerID
            // 
            this.labelShoppingCartInfoCustomerID.AutoSize = true;
            this.labelShoppingCartInfoCustomerID.Location = new System.Drawing.Point(12, 146);
            this.labelShoppingCartInfoCustomerID.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelShoppingCartInfoCustomerID.Name = "labelShoppingCartInfoCustomerID";
            this.labelShoppingCartInfoCustomerID.Size = new System.Drawing.Size(139, 25);
            this.labelShoppingCartInfoCustomerID.TabIndex = 13;
            // 
            // labelShoppingCartInfoSalesPointID
            // 
            this.labelShoppingCartInfoSalesPointID.AutoSize = true;
            this.labelShoppingCartInfoSalesPointID.Location = new System.Drawing.Point(12, 246);
            this.labelShoppingCartInfoSalesPointID.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelShoppingCartInfoSalesPointID.Name = "labelShoppingCartInfoSalesPointID";
            this.labelShoppingCartInfoSalesPointID.Size = new System.Drawing.Size(156, 25);
            this.labelShoppingCartInfoSalesPointID.TabIndex = 16;
            // 
            // labelShoppingCartInfoViewPointID
            // 
            this.labelShoppingCartInfoViewPointID.AutoSize = true;
            this.labelShoppingCartInfoViewPointID.Location = new System.Drawing.Point(12, 296);
            this.labelShoppingCartInfoViewPointID.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelShoppingCartInfoViewPointID.Name = "labelShoppingCartInfoViewPointID";
            this.labelShoppingCartInfoViewPointID.Size = new System.Drawing.Size(148, 25);
            this.labelShoppingCartInfoViewPointID.TabIndex = 17;
            // 
            // labelShoppingCartInfoID
            // 
            this.labelShoppingCartInfoID.AutoSize = true;
            this.labelShoppingCartInfoID.Location = new System.Drawing.Point(12, 44);
            this.labelShoppingCartInfoID.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelShoppingCartInfoID.Name = "labelShoppingCartInfoID";
            this.labelShoppingCartInfoID.Size = new System.Drawing.Size(44, 25);
            this.labelShoppingCartInfoID.TabIndex = 12;
            // 
            // comboBoxShoppingCartInfoStatus
            // 
            this.comboBoxShoppingCartInfoStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxShoppingCartInfoStatus.Enabled = false;
            this.comboBoxShoppingCartInfoStatus.FormattingEnabled = true;
            this.comboBoxShoppingCartInfoStatus.Location = new System.Drawing.Point(196, 88);
            this.comboBoxShoppingCartInfoStatus.Margin = new System.Windows.Forms.Padding(6);
            this.comboBoxShoppingCartInfoStatus.Name = "comboBoxShoppingCartInfoStatus";
            this.comboBoxShoppingCartInfoStatus.Size = new System.Drawing.Size(238, 33);
            this.comboBoxShoppingCartInfoStatus.TabIndex = 23;
            // 
            // textBoxShoppingCartInfoViewPointID
            // 
            this.textBoxShoppingCartInfoViewPointID.Enabled = false;
            this.textBoxShoppingCartInfoViewPointID.Location = new System.Drawing.Point(196, 290);
            this.textBoxShoppingCartInfoViewPointID.Margin = new System.Windows.Forms.Padding(6);
            this.textBoxShoppingCartInfoViewPointID.Name = "textBoxShoppingCartInfoViewPointID";
            this.textBoxShoppingCartInfoViewPointID.Size = new System.Drawing.Size(238, 31);
            this.textBoxShoppingCartInfoViewPointID.TabIndex = 22;
            // 
            // textBoxShoppingCartInfoSalesPointID
            // 
            this.textBoxShoppingCartInfoSalesPointID.Enabled = false;
            this.textBoxShoppingCartInfoSalesPointID.Location = new System.Drawing.Point(196, 240);
            this.textBoxShoppingCartInfoSalesPointID.Margin = new System.Windows.Forms.Padding(6);
            this.textBoxShoppingCartInfoSalesPointID.Name = "textBoxShoppingCartInfoSalesPointID";
            this.textBoxShoppingCartInfoSalesPointID.Size = new System.Drawing.Size(238, 31);
            this.textBoxShoppingCartInfoSalesPointID.TabIndex = 21;
            // 
            // textBoxShoppingCartInfoSalesPersonID
            // 
            this.textBoxShoppingCartInfoSalesPersonID.Enabled = false;
            this.textBoxShoppingCartInfoSalesPersonID.Location = new System.Drawing.Point(196, 190);
            this.textBoxShoppingCartInfoSalesPersonID.Margin = new System.Windows.Forms.Padding(6);
            this.textBoxShoppingCartInfoSalesPersonID.Name = "textBoxShoppingCartInfoSalesPersonID";
            this.textBoxShoppingCartInfoSalesPersonID.Size = new System.Drawing.Size(238, 31);
            this.textBoxShoppingCartInfoSalesPersonID.TabIndex = 20;
            // 
            // textBoxShoppingCartInfoCustomerID
            // 
            this.textBoxShoppingCartInfoCustomerID.Enabled = false;
            this.textBoxShoppingCartInfoCustomerID.Location = new System.Drawing.Point(196, 140);
            this.textBoxShoppingCartInfoCustomerID.Margin = new System.Windows.Forms.Padding(6);
            this.textBoxShoppingCartInfoCustomerID.Name = "textBoxShoppingCartInfoCustomerID";
            this.textBoxShoppingCartInfoCustomerID.Size = new System.Drawing.Size(238, 31);
            this.textBoxShoppingCartInfoCustomerID.TabIndex = 19;
            // 
            // textBoxShoppingCartInfoID
            // 
            this.textBoxShoppingCartInfoID.Enabled = false;
            this.textBoxShoppingCartInfoID.Location = new System.Drawing.Point(196, 38);
            this.textBoxShoppingCartInfoID.Margin = new System.Windows.Forms.Padding(6);
            this.textBoxShoppingCartInfoID.Name = "textBoxShoppingCartInfoID";
            this.textBoxShoppingCartInfoID.Size = new System.Drawing.Size(238, 31);
            this.textBoxShoppingCartInfoID.TabIndex = 18;
            // 
            // groupBoxShoppingCartUpdateHandling
            // 
            this.groupBoxShoppingCartUpdateHandling.Location = new System.Drawing.Point(12, 377);
            this.groupBoxShoppingCartUpdateHandling.Margin = new System.Windows.Forms.Padding(6);
            this.groupBoxShoppingCartUpdateHandling.Name = "groupBoxShoppingCartUpdateHandling";
            this.groupBoxShoppingCartUpdateHandling.Padding = new System.Windows.Forms.Padding(6);
            this.groupBoxShoppingCartUpdateHandling.Size = new System.Drawing.Size(466, 300);
            this.groupBoxShoppingCartUpdateHandling.TabIndex = 13;
            this.groupBoxShoppingCartUpdateHandling.TabStop = false;
            // 
            // labelShoppingCartUpdateHandlingManuel
            // 
            this.labelShoppingCartUpdateHandlingManuel.AutoSize = true;
            this.labelShoppingCartUpdateHandlingManuel.Location = new System.Drawing.Point(12, 187);
            this.labelShoppingCartUpdateHandlingManuel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelShoppingCartUpdateHandlingManuel.Name = "labelShoppingCartUpdateHandlingManuel";
            this.labelShoppingCartUpdateHandlingManuel.Size = new System.Drawing.Size(89, 25);
            this.labelShoppingCartUpdateHandlingManuel.TabIndex = 16;
            // 
            // labelShoppingCartUpdateHandlingAuto
            // 
            this.labelShoppingCartUpdateHandlingAuto.AutoSize = true;
            this.labelShoppingCartUpdateHandlingAuto.Location = new System.Drawing.Point(12, 48);
            this.labelShoppingCartUpdateHandlingAuto.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelShoppingCartUpdateHandlingAuto.Name = "labelShoppingCartUpdateHandlingAuto";
            this.labelShoppingCartUpdateHandlingAuto.Size = new System.Drawing.Size(62, 25);
            this.labelShoppingCartUpdateHandlingAuto.TabIndex = 17;
            // 
            // buttonShoppingCartUpdateAutoAccept
            // 
            this.buttonShoppingCartUpdateAutoAccept.Enabled = false;
            this.buttonShoppingCartUpdateAutoAccept.Location = new System.Drawing.Point(116, 177);
            this.buttonShoppingCartUpdateAutoAccept.Margin = new System.Windows.Forms.Padding(6);
            this.buttonShoppingCartUpdateAutoAccept.Name = "buttonShoppingCartUpdateAutoAccept";
            this.buttonShoppingCartUpdateAutoAccept.Size = new System.Drawing.Size(150, 44);
            this.buttonShoppingCartUpdateAutoAccept.TabIndex = 18;
            this.buttonShoppingCartUpdateAutoAccept.Text = "Accept";
            this.buttonShoppingCartUpdateAutoAccept.UseVisualStyleBackColor = true;
            this.buttonShoppingCartUpdateAutoAccept.Click += new System.EventHandler(this.buttonShoppingCartUpdateAutoAccept_Click);
            // 
            // buttonShoppingCartUpdateAutoReject
            // 
            this.buttonShoppingCartUpdateAutoReject.Enabled = false;
            this.buttonShoppingCartUpdateAutoReject.Location = new System.Drawing.Point(278, 177);
            this.buttonShoppingCartUpdateAutoReject.Margin = new System.Windows.Forms.Padding(6);
            this.buttonShoppingCartUpdateAutoReject.Name = "buttonShoppingCartUpdateAutoReject";
            this.buttonShoppingCartUpdateAutoReject.Size = new System.Drawing.Size(150, 44);
            this.buttonShoppingCartUpdateAutoReject.TabIndex = 19;
            this.buttonShoppingCartUpdateAutoReject.Text = "Reject";
            this.buttonShoppingCartUpdateAutoReject.UseVisualStyleBackColor = true;
            this.buttonShoppingCartUpdateAutoReject.Click += new System.EventHandler(this.buttonShoppingCartUpdateAutoReject_Click);
            // 
            // textBoxShoppingCartUpdateHandlingDescription
            // 
            this.textBoxShoppingCartUpdateHandlingDescription.Location = new System.Drawing.Point(198, 242);
            this.textBoxShoppingCartUpdateHandlingDescription.Margin = new System.Windows.Forms.Padding(6);
            this.textBoxShoppingCartUpdateHandlingDescription.Name = "textBoxShoppingCartUpdateHandlingDescription";
            this.textBoxShoppingCartUpdateHandlingDescription.Size = new System.Drawing.Size(226, 31);
            this.textBoxShoppingCartUpdateHandlingDescription.TabIndex = 22;
            // 
            // labelShoppingCartUpdateHandlingDescription
            // 
            this.labelShoppingCartUpdateHandlingDescription.AutoSize = true;
            this.labelShoppingCartUpdateHandlingDescription.Location = new System.Drawing.Point(8, 248);
            this.labelShoppingCartUpdateHandlingDescription.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelShoppingCartUpdateHandlingDescription.Name = "labelShoppingCartUpdateHandlingDescription";
            this.labelShoppingCartUpdateHandlingDescription.Size = new System.Drawing.Size(132, 25);
            this.labelShoppingCartUpdateHandlingDescription.TabIndex = 23;
            // 
            // radioButtonShoppingCartUpdateAutoAccept
            // 
            this.radioButtonShoppingCartUpdateAutoAccept.AutoSize = true;
            this.radioButtonShoppingCartUpdateAutoAccept.Checked = true;
            this.radioButtonShoppingCartUpdateAutoAccept.Location = new System.Drawing.Point(88, 44);
            this.radioButtonShoppingCartUpdateAutoAccept.Margin = new System.Windows.Forms.Padding(6);
            this.radioButtonShoppingCartUpdateAutoAccept.Name = "radioButtonShoppingCartUpdateAutoAccept";
            this.radioButtonShoppingCartUpdateAutoAccept.Size = new System.Drawing.Size(109, 29);
            this.radioButtonShoppingCartUpdateAutoAccept.TabIndex = 24;
            this.radioButtonShoppingCartUpdateAutoAccept.TabStop = true;
            this.radioButtonShoppingCartUpdateAutoAccept.Text = "Accept";
            this.radioButtonShoppingCartUpdateAutoAccept.UseVisualStyleBackColor = true;
            // 
            // radioButtonShoppingCartUpdateAutoReject
            // 
            this.radioButtonShoppingCartUpdateAutoReject.AutoSize = true;
            this.radioButtonShoppingCartUpdateAutoReject.Location = new System.Drawing.Point(88, 88);
            this.radioButtonShoppingCartUpdateAutoReject.Margin = new System.Windows.Forms.Padding(6);
            this.radioButtonShoppingCartUpdateAutoReject.Name = "radioButtonShoppingCartUpdateAutoReject";
            this.radioButtonShoppingCartUpdateAutoReject.Size = new System.Drawing.Size(104, 29);
            this.radioButtonShoppingCartUpdateAutoReject.TabIndex = 25;
            this.radioButtonShoppingCartUpdateAutoReject.Text = "Reject";
            this.radioButtonShoppingCartUpdateAutoReject.UseVisualStyleBackColor = true;
            // 
            // radioButtonShoppingCartUpdateAutoManual
            // 
            this.radioButtonShoppingCartUpdateAutoManual.AutoSize = true;
            this.radioButtonShoppingCartUpdateAutoManual.Location = new System.Drawing.Point(88, 133);
            this.radioButtonShoppingCartUpdateAutoManual.Margin = new System.Windows.Forms.Padding(6);
            this.radioButtonShoppingCartUpdateAutoManual.Name = "radioButtonShoppingCartUpdateAutoManual";
            this.radioButtonShoppingCartUpdateAutoManual.Size = new System.Drawing.Size(114, 29);
            this.radioButtonShoppingCartUpdateAutoManual.TabIndex = 26;
            this.radioButtonShoppingCartUpdateAutoManual.Text = "Manual";
            this.radioButtonShoppingCartUpdateAutoManual.UseVisualStyleBackColor = true;
            // 
            // groupBoxShoppingCartItemsForUpdate
            // 
            this.groupBoxShoppingCartItemsForUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxShoppingCartItemsForUpdate.Location = new System.Drawing.Point(490, 12);
            this.groupBoxShoppingCartItemsForUpdate.Margin = new System.Windows.Forms.Padding(6);
            this.groupBoxShoppingCartItemsForUpdate.Name = "groupBoxShoppingCartItemsForUpdate";
            this.groupBoxShoppingCartItemsForUpdate.Padding = new System.Windows.Forms.Padding(6);
            this.groupBoxShoppingCartItemsForUpdate.Size = new System.Drawing.Size(1414, 848);
            this.groupBoxShoppingCartItemsForUpdate.TabIndex = 12;
            this.groupBoxShoppingCartItemsForUpdate.TabStop = false;
            // 
            // listViewShoppingCartItemsForUpdate
            // 
            this.listViewShoppingCartItemsForUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewShoppingCartItemsForUpdate.FullRowSelect = true;
            this.listViewShoppingCartItemsForUpdate.HideSelection = false;
            this.listViewShoppingCartItemsForUpdate.Location = new System.Drawing.Point(0, 37);
            this.listViewShoppingCartItemsForUpdate.Margin = new System.Windows.Forms.Padding(6);
            this.listViewShoppingCartItemsForUpdate.Name = "listViewShoppingCartItemsForUpdate";
            this.listViewShoppingCartItemsForUpdate.Size = new System.Drawing.Size(1392, 794);
            this.listViewShoppingCartItemsForUpdate.TabIndex = 0;
            this.listViewShoppingCartItemsForUpdate.UseCompatibleStateImageBehavior = false;
            this.listViewShoppingCartItemsForUpdate.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.DisplayIndex = 0;
            this.columnHeader1.Text = "Article Id";
            // 
            // columnHeader2
            // 
            this.columnHeader2.DisplayIndex = 1;
            this.columnHeader2.Text = "Currency";
            // 
            // columnHeader3
            // 
            this.columnHeader3.DisplayIndex = 2;
            this.columnHeader3.Text = "DispensedQuantity";
            // 
            // columnHeader4
            // 
            this.columnHeader4.DisplayIndex = 3;
            this.columnHeader4.Text = "OrderedQuantity";
            // 
            // columnHeader5
            // 
            this.columnHeader5.DisplayIndex = 4;
            this.columnHeader5.Text = "PaidQuantity";
            // 
            // columnHeader6
            // 
            this.columnHeader6.DisplayIndex = 5;
            this.columnHeader6.Text = "Price";
            // 
            // tabPageRequest
            // 
            this.tabPageRequest.Location = new System.Drawing.Point(8, 39);
            this.tabPageRequest.Margin = new System.Windows.Forms.Padding(6);
            this.tabPageRequest.Name = "tabPageRequest";
            this.tabPageRequest.Padding = new System.Windows.Forms.Padding(6);
            this.tabPageRequest.Size = new System.Drawing.Size(1932, 916);
            this.tabPageRequest.TabIndex = 0;
            this.tabPageRequest.Text = "Request";
            this.tabPageRequest.UseVisualStyleBackColor = true;
            // 
            // groupBoxShoppingCartRequest
            // 
            this.groupBoxShoppingCartRequest.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBoxShoppingCartRequest.Location = new System.Drawing.Point(12, 12);
            this.groupBoxShoppingCartRequest.Margin = new System.Windows.Forms.Padding(6);
            this.groupBoxShoppingCartRequest.Name = "groupBoxShoppingCartRequest";
            this.groupBoxShoppingCartRequest.Padding = new System.Windows.Forms.Padding(6);
            this.groupBoxShoppingCartRequest.Size = new System.Drawing.Size(466, 848);
            this.groupBoxShoppingCartRequest.TabIndex = 17;
            this.groupBoxShoppingCartRequest.TabStop = false;
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(12, 42);
            this.labelStatus.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(85, 25);
            this.labelStatus.TabIndex = 8;
            // 
            // labelSalesPersonId
            // 
            this.labelSalesPersonId.AutoSize = true;
            this.labelSalesPersonId.Location = new System.Drawing.Point(12, 144);
            this.labelSalesPersonId.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelSalesPersonId.Name = "labelSalesPersonId";
            this.labelSalesPersonId.Size = new System.Drawing.Size(175, 25);
            this.labelSalesPersonId.TabIndex = 9;
            // 
            // labelCustomerId
            // 
            this.labelCustomerId.AutoSize = true;
            this.labelCustomerId.Location = new System.Drawing.Point(12, 94);
            this.labelCustomerId.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelCustomerId.Name = "labelCustomerId";
            this.labelCustomerId.Size = new System.Drawing.Size(139, 25);
            this.labelCustomerId.TabIndex = 7;
            // 
            // labelSalesPointId
            // 
            this.labelSalesPointId.AutoSize = true;
            this.labelSalesPointId.Location = new System.Drawing.Point(12, 194);
            this.labelSalesPointId.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelSalesPointId.Name = "labelSalesPointId";
            this.labelSalesPointId.Size = new System.Drawing.Size(156, 25);
            this.labelSalesPointId.TabIndex = 10;
            // 
            // comboBoxShoppingCartStatus
            // 
            this.comboBoxShoppingCartStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxShoppingCartStatus.FormattingEnabled = true;
            this.comboBoxShoppingCartStatus.Location = new System.Drawing.Point(236, 37);
            this.comboBoxShoppingCartStatus.Margin = new System.Windows.Forms.Padding(6);
            this.comboBoxShoppingCartStatus.Name = "comboBoxShoppingCartStatus";
            this.comboBoxShoppingCartStatus.Size = new System.Drawing.Size(214, 33);
            this.comboBoxShoppingCartStatus.TabIndex = 5;
            // 
            // labelViewPointId
            // 
            this.labelViewPointId.AutoSize = true;
            this.labelViewPointId.Location = new System.Drawing.Point(12, 244);
            this.labelViewPointId.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelViewPointId.Name = "labelViewPointId";
            this.labelViewPointId.Size = new System.Drawing.Size(148, 25);
            this.labelViewPointId.TabIndex = 11;
            // 
            // textBoxShoppingCartViewPointID
            // 
            this.textBoxShoppingCartViewPointID.Location = new System.Drawing.Point(224, 238);
            this.textBoxShoppingCartViewPointID.Margin = new System.Windows.Forms.Padding(6);
            this.textBoxShoppingCartViewPointID.Name = "textBoxShoppingCartViewPointID";
            this.textBoxShoppingCartViewPointID.Size = new System.Drawing.Size(226, 31);
            this.textBoxShoppingCartViewPointID.TabIndex = 4;
            // 
            // radioButtonShoppingCartAccept
            // 
            this.radioButtonShoppingCartAccept.AutoSize = true;
            this.radioButtonShoppingCartAccept.Checked = true;
            this.radioButtonShoppingCartAccept.Location = new System.Drawing.Point(30, 288);
            this.radioButtonShoppingCartAccept.Margin = new System.Windows.Forms.Padding(6);
            this.radioButtonShoppingCartAccept.Name = "radioButtonShoppingCartAccept";
            this.radioButtonShoppingCartAccept.Size = new System.Drawing.Size(109, 29);
            this.radioButtonShoppingCartAccept.TabIndex = 12;
            this.radioButtonShoppingCartAccept.TabStop = true;
            this.radioButtonShoppingCartAccept.Text = "Accept";
            this.radioButtonShoppingCartAccept.UseVisualStyleBackColor = true;
            // 
            // textBoxShoppingCartSalesPointID
            // 
            this.textBoxShoppingCartSalesPointID.Location = new System.Drawing.Point(224, 188);
            this.textBoxShoppingCartSalesPointID.Margin = new System.Windows.Forms.Padding(6);
            this.textBoxShoppingCartSalesPointID.Name = "textBoxShoppingCartSalesPointID";
            this.textBoxShoppingCartSalesPointID.Size = new System.Drawing.Size(226, 31);
            this.textBoxShoppingCartSalesPointID.TabIndex = 3;
            // 
            // radioButtonShoppingCartReject
            // 
            this.radioButtonShoppingCartReject.AutoSize = true;
            this.radioButtonShoppingCartReject.Location = new System.Drawing.Point(30, 333);
            this.radioButtonShoppingCartReject.Margin = new System.Windows.Forms.Padding(6);
            this.radioButtonShoppingCartReject.Name = "radioButtonShoppingCartReject";
            this.radioButtonShoppingCartReject.Size = new System.Drawing.Size(104, 29);
            this.radioButtonShoppingCartReject.TabIndex = 13;
            this.radioButtonShoppingCartReject.Text = "Reject";
            this.radioButtonShoppingCartReject.UseVisualStyleBackColor = true;
            // 
            // textBoxShoppingCartSalesPersonId
            // 
            this.textBoxShoppingCartSalesPersonId.Location = new System.Drawing.Point(236, 138);
            this.textBoxShoppingCartSalesPersonId.Margin = new System.Windows.Forms.Padding(6);
            this.textBoxShoppingCartSalesPersonId.Name = "textBoxShoppingCartSalesPersonId";
            this.textBoxShoppingCartSalesPersonId.Size = new System.Drawing.Size(214, 31);
            this.textBoxShoppingCartSalesPersonId.TabIndex = 2;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(224, 365);
            this.textBox1.Margin = new System.Windows.Forms.Padding(6);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(226, 31);
            this.textBox1.TabIndex = 14;
            // 
            // textBoxShoppingCartCustomerID
            // 
            this.textBoxShoppingCartCustomerID.Location = new System.Drawing.Point(236, 88);
            this.textBoxShoppingCartCustomerID.Margin = new System.Windows.Forms.Padding(6);
            this.textBoxShoppingCartCustomerID.Name = "textBoxShoppingCartCustomerID";
            this.textBoxShoppingCartCustomerID.Size = new System.Drawing.Size(214, 31);
            this.textBoxShoppingCartCustomerID.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 371);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(199, 25);
            this.label1.TabIndex = 15;
            // 
            // groupBoxShoppingCartItemsForRequest
            // 
            this.groupBoxShoppingCartItemsForRequest.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxShoppingCartItemsForRequest.Location = new System.Drawing.Point(490, 12);
            this.groupBoxShoppingCartItemsForRequest.Margin = new System.Windows.Forms.Padding(6);
            this.groupBoxShoppingCartItemsForRequest.Name = "groupBoxShoppingCartItemsForRequest";
            this.groupBoxShoppingCartItemsForRequest.Padding = new System.Windows.Forms.Padding(6);
            this.groupBoxShoppingCartItemsForRequest.Size = new System.Drawing.Size(1414, 848);
            this.groupBoxShoppingCartItemsForRequest.TabIndex = 18;
            this.groupBoxShoppingCartItemsForRequest.TabStop = false;
            // 
            // listViewShoppingCartItemsForRequest
            // 
            this.listViewShoppingCartItemsForRequest.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewShoppingCartItemsForRequest.FullRowSelect = true;
            this.listViewShoppingCartItemsForRequest.HideSelection = false;
            this.listViewShoppingCartItemsForRequest.Location = new System.Drawing.Point(6, 31);
            this.listViewShoppingCartItemsForRequest.Margin = new System.Windows.Forms.Padding(6);
            this.listViewShoppingCartItemsForRequest.Name = "listViewShoppingCartItemsForRequest";
            this.listViewShoppingCartItemsForRequest.Size = new System.Drawing.Size(1392, 744);
            this.listViewShoppingCartItemsForRequest.TabIndex = 0;
            this.listViewShoppingCartItemsForRequest.UseCompatibleStateImageBehavior = false;
            this.listViewShoppingCartItemsForRequest.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader7
            // 
            this.columnHeader7.DisplayIndex = 0;
            this.columnHeader7.Text = "Article Id";
            // 
            // columnHeader8
            // 
            this.columnHeader8.DisplayIndex = 1;
            this.columnHeader8.Text = "Currency";
            // 
            // columnHeader9
            // 
            this.columnHeader9.DisplayIndex = 2;
            this.columnHeader9.Text = "DispensedQuantity";
            // 
            // columnHeader10
            // 
            this.columnHeader10.DisplayIndex = 3;
            this.columnHeader10.Text = "OrderedQuantity";
            // 
            // columnHeader11
            // 
            this.columnHeader11.DisplayIndex = 4;
            this.columnHeader11.Text = "PaidQuantity";
            // 
            // columnHeader12
            // 
            this.columnHeader12.DisplayIndex = 5;
            this.columnHeader12.Text = "Price";
            // 
            // buttonAddShoppingCartItem
            // 
            this.buttonAddShoppingCartItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAddShoppingCartItem.Location = new System.Drawing.Point(1090, 790);
            this.buttonAddShoppingCartItem.Margin = new System.Windows.Forms.Padding(6);
            this.buttonAddShoppingCartItem.Name = "buttonAddShoppingCartItem";
            this.buttonAddShoppingCartItem.Size = new System.Drawing.Size(150, 44);
            this.buttonAddShoppingCartItem.TabIndex = 21;
            this.buttonAddShoppingCartItem.Text = "Add...";
            this.buttonAddShoppingCartItem.UseVisualStyleBackColor = true;
            this.buttonAddShoppingCartItem.Click += new System.EventHandler(this.buttonAddShoppingCartItem_Click);
            // 
            // buttonRemoveShoppingCartItem
            // 
            this.buttonRemoveShoppingCartItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRemoveShoppingCartItem.Location = new System.Drawing.Point(1252, 790);
            this.buttonRemoveShoppingCartItem.Margin = new System.Windows.Forms.Padding(6);
            this.buttonRemoveShoppingCartItem.Name = "buttonRemoveShoppingCartItem";
            this.buttonRemoveShoppingCartItem.Size = new System.Drawing.Size(150, 44);
            this.buttonRemoveShoppingCartItem.TabIndex = 22;
            this.buttonRemoveShoppingCartItem.Text = "Remove";
            this.buttonRemoveShoppingCartItem.UseVisualStyleBackColor = true;
            this.buttonRemoveShoppingCartItem.Click += new System.EventHandler(this.buttonRemoveShoppingCartItem_Click);
            // 
            // tabPagePriceInformation
            // 
            this.tabPagePriceInformation.Location = new System.Drawing.Point(8, 39);
            this.tabPagePriceInformation.Margin = new System.Windows.Forms.Padding(6);
            this.tabPagePriceInformation.Name = "tabPagePriceInformation";
            this.tabPagePriceInformation.Padding = new System.Windows.Forms.Padding(6);
            this.tabPagePriceInformation.Size = new System.Drawing.Size(1960, 995);
            this.tabPagePriceInformation.TabIndex = 2;
            this.tabPagePriceInformation.Text = "Price Information";
            this.tabPagePriceInformation.UseVisualStyleBackColor = true;
            // 
            // groupBoxPriceInformation
            // 
            this.groupBoxPriceInformation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxPriceInformation.Location = new System.Drawing.Point(8, 8);
            this.groupBoxPriceInformation.Margin = new System.Windows.Forms.Padding(6);
            this.groupBoxPriceInformation.Name = "groupBoxPriceInformation";
            this.groupBoxPriceInformation.Padding = new System.Windows.Forms.Padding(6);
            this.groupBoxPriceInformation.Size = new System.Drawing.Size(1932, 931);
            this.groupBoxPriceInformation.TabIndex = 10;
            this.groupBoxPriceInformation.TabStop = false;
            // 
            // listBoxPriceInformation
            // 
            this.listBoxPriceInformation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxPriceInformation.FormattingEnabled = true;
            this.listBoxPriceInformation.Location = new System.Drawing.Point(12, 75);
            this.listBoxPriceInformation.Margin = new System.Windows.Forms.Padding(6);
            this.listBoxPriceInformation.Name = "listBoxPriceInformation";
            this.listBoxPriceInformation.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxPriceInformation.Size = new System.Drawing.Size(1904, 729);
            this.listBoxPriceInformation.TabIndex = 29;
            // 
            // buttonAddPriceInformation
            // 
            this.buttonAddPriceInformation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAddPriceInformation.Location = new System.Drawing.Point(1608, 873);
            this.buttonAddPriceInformation.Margin = new System.Windows.Forms.Padding(6);
            this.buttonAddPriceInformation.Name = "buttonAddPriceInformation";
            this.buttonAddPriceInformation.Size = new System.Drawing.Size(150, 44);
            this.buttonAddPriceInformation.TabIndex = 30;
            this.buttonAddPriceInformation.Text = "Add...";
            this.buttonAddPriceInformation.UseVisualStyleBackColor = true;
            this.buttonAddPriceInformation.Click += new System.EventHandler(this.buttonAddPriceInformation_Click);
            // 
            // buttonRemovePriceInformation
            // 
            this.buttonRemovePriceInformation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRemovePriceInformation.Location = new System.Drawing.Point(1770, 873);
            this.buttonRemovePriceInformation.Margin = new System.Windows.Forms.Padding(6);
            this.buttonRemovePriceInformation.Name = "buttonRemovePriceInformation";
            this.buttonRemovePriceInformation.Size = new System.Drawing.Size(150, 44);
            this.buttonRemovePriceInformation.TabIndex = 31;
            this.buttonRemovePriceInformation.Text = "Remove";
            this.buttonRemovePriceInformation.UseVisualStyleBackColor = true;
            this.buttonRemovePriceInformation.Click += new System.EventHandler(this.buttonRemovePriceInformation_Click);
            // 
            // checkBoxPriceInformationAutoGenerate
            // 
            this.checkBoxPriceInformationAutoGenerate.AutoSize = true;
            this.checkBoxPriceInformationAutoGenerate.Checked = true;
            this.checkBoxPriceInformationAutoGenerate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxPriceInformationAutoGenerate.Location = new System.Drawing.Point(14, 37);
            this.checkBoxPriceInformationAutoGenerate.Margin = new System.Windows.Forms.Padding(6);
            this.checkBoxPriceInformationAutoGenerate.Name = "checkBoxPriceInformationAutoGenerate";
            this.checkBoxPriceInformationAutoGenerate.Size = new System.Drawing.Size(350, 29);
            this.checkBoxPriceInformationAutoGenerate.TabIndex = 33;
            this.checkBoxPriceInformationAutoGenerate.Text = "Auto Generate Price Information";
            this.checkBoxPriceInformationAutoGenerate.UseVisualStyleBackColor = true;
            this.checkBoxPriceInformationAutoGenerate.Click += new System.EventHandler(this.checkBoxPriceInformationAutoGenerate_Click);
            // 
            // tabPageArticleInfo
            // 
            this.tabPageArticleInfo.Location = new System.Drawing.Point(8, 39);
            this.tabPageArticleInfo.Margin = new System.Windows.Forms.Padding(6);
            this.tabPageArticleInfo.Name = "tabPageArticleInfo";
            this.tabPageArticleInfo.Padding = new System.Windows.Forms.Padding(6);
            this.tabPageArticleInfo.Size = new System.Drawing.Size(1960, 995);
            this.tabPageArticleInfo.TabIndex = 1;
            this.tabPageArticleInfo.Text = "Article Information";
            this.tabPageArticleInfo.UseVisualStyleBackColor = true;
            // 
            // groupBoxCrossSellingArticle
            // 
            this.groupBoxCrossSellingArticle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxCrossSellingArticle.Location = new System.Drawing.Point(536, 158);
            this.groupBoxCrossSellingArticle.Margin = new System.Windows.Forms.Padding(6);
            this.groupBoxCrossSellingArticle.Name = "groupBoxCrossSellingArticle";
            this.groupBoxCrossSellingArticle.Padding = new System.Windows.Forms.Padding(6);
            this.groupBoxCrossSellingArticle.Size = new System.Drawing.Size(460, 781);
            this.groupBoxCrossSellingArticle.TabIndex = 6;
            this.groupBoxCrossSellingArticle.TabStop = false;
            // 
            // listBoxCrossSellingArticle
            // 
            this.listBoxCrossSellingArticle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxCrossSellingArticle.FormattingEnabled = true;
            this.listBoxCrossSellingArticle.Location = new System.Drawing.Point(12, 75);
            this.listBoxCrossSellingArticle.Margin = new System.Windows.Forms.Padding(6);
            this.listBoxCrossSellingArticle.Name = "listBoxCrossSellingArticle";
            this.listBoxCrossSellingArticle.Size = new System.Drawing.Size(432, 579);
            this.listBoxCrossSellingArticle.TabIndex = 29;
            // 
            // buttonAddCrossSellingArticle
            // 
            this.buttonAddCrossSellingArticle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAddCrossSellingArticle.Location = new System.Drawing.Point(136, 723);
            this.buttonAddCrossSellingArticle.Margin = new System.Windows.Forms.Padding(6);
            this.buttonAddCrossSellingArticle.Name = "buttonAddCrossSellingArticle";
            this.buttonAddCrossSellingArticle.Size = new System.Drawing.Size(150, 44);
            this.buttonAddCrossSellingArticle.TabIndex = 30;
            this.buttonAddCrossSellingArticle.Text = "Add...";
            this.buttonAddCrossSellingArticle.UseVisualStyleBackColor = true;
            this.buttonAddCrossSellingArticle.Click += new System.EventHandler(this.buttonAddCrossSellingArticle_Click);
            // 
            // buttonRemoveCrossSellingArticle
            // 
            this.buttonRemoveCrossSellingArticle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRemoveCrossSellingArticle.Location = new System.Drawing.Point(298, 723);
            this.buttonRemoveCrossSellingArticle.Margin = new System.Windows.Forms.Padding(6);
            this.buttonRemoveCrossSellingArticle.Name = "buttonRemoveCrossSellingArticle";
            this.buttonRemoveCrossSellingArticle.Size = new System.Drawing.Size(150, 44);
            this.buttonRemoveCrossSellingArticle.TabIndex = 31;
            this.buttonRemoveCrossSellingArticle.Text = "Remove";
            this.buttonRemoveCrossSellingArticle.UseVisualStyleBackColor = true;
            this.buttonRemoveCrossSellingArticle.Click += new System.EventHandler(this.buttonRemoveCrossSellingArticle_Click);
            // 
            // checkBoxCrossSellingArticleAutoGenerate
            // 
            this.checkBoxCrossSellingArticleAutoGenerate.AutoSize = true;
            this.checkBoxCrossSellingArticleAutoGenerate.Checked = true;
            this.checkBoxCrossSellingArticleAutoGenerate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxCrossSellingArticleAutoGenerate.Location = new System.Drawing.Point(14, 38);
            this.checkBoxCrossSellingArticleAutoGenerate.Margin = new System.Windows.Forms.Padding(6);
            this.checkBoxCrossSellingArticleAutoGenerate.Name = "checkBoxCrossSellingArticleAutoGenerate";
            this.checkBoxCrossSellingArticleAutoGenerate.Size = new System.Drawing.Size(393, 29);
            this.checkBoxCrossSellingArticleAutoGenerate.TabIndex = 33;
            this.checkBoxCrossSellingArticleAutoGenerate.Text = "Auto Generate Cross Selling Articles";
            this.checkBoxCrossSellingArticleAutoGenerate.UseVisualStyleBackColor = true;
            this.checkBoxCrossSellingArticleAutoGenerate.Click += new System.EventHandler(this.checkBoxCrossSellingArticleAutoGenerate_Click);
            // 
            // groupBoxAlternativeArticle
            // 
            this.groupBoxAlternativeArticle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxAlternativeArticle.Location = new System.Drawing.Point(1008, 158);
            this.groupBoxAlternativeArticle.Margin = new System.Windows.Forms.Padding(6);
            this.groupBoxAlternativeArticle.Name = "groupBoxAlternativeArticle";
            this.groupBoxAlternativeArticle.Padding = new System.Windows.Forms.Padding(6);
            this.groupBoxAlternativeArticle.Size = new System.Drawing.Size(460, 781);
            this.groupBoxAlternativeArticle.TabIndex = 7;
            this.groupBoxAlternativeArticle.TabStop = false;
            // 
            // listBoxAlternativeArticle
            // 
            this.listBoxAlternativeArticle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxAlternativeArticle.FormattingEnabled = true;
            this.listBoxAlternativeArticle.Location = new System.Drawing.Point(12, 75);
            this.listBoxAlternativeArticle.Margin = new System.Windows.Forms.Padding(6);
            this.listBoxAlternativeArticle.Name = "listBoxAlternativeArticle";
            this.listBoxAlternativeArticle.Size = new System.Drawing.Size(432, 579);
            this.listBoxAlternativeArticle.TabIndex = 32;
            // 
            // buttonAddAlternativeArticle
            // 
            this.buttonAddAlternativeArticle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAddAlternativeArticle.Location = new System.Drawing.Point(136, 723);
            this.buttonAddAlternativeArticle.Margin = new System.Windows.Forms.Padding(6);
            this.buttonAddAlternativeArticle.Name = "buttonAddAlternativeArticle";
            this.buttonAddAlternativeArticle.Size = new System.Drawing.Size(150, 44);
            this.buttonAddAlternativeArticle.TabIndex = 33;
            this.buttonAddAlternativeArticle.Text = "Add...";
            this.buttonAddAlternativeArticle.UseVisualStyleBackColor = true;
            this.buttonAddAlternativeArticle.Click += new System.EventHandler(this.buttonAddAlternativeArticle_Click);
            // 
            // buttonRemoveAlternativeArticle
            // 
            this.buttonRemoveAlternativeArticle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRemoveAlternativeArticle.Location = new System.Drawing.Point(298, 723);
            this.buttonRemoveAlternativeArticle.Margin = new System.Windows.Forms.Padding(6);
            this.buttonRemoveAlternativeArticle.Name = "buttonRemoveAlternativeArticle";
            this.buttonRemoveAlternativeArticle.Size = new System.Drawing.Size(150, 44);
            this.buttonRemoveAlternativeArticle.TabIndex = 34;
            this.buttonRemoveAlternativeArticle.Text = "Remove";
            this.buttonRemoveAlternativeArticle.UseVisualStyleBackColor = true;
            this.buttonRemoveAlternativeArticle.Click += new System.EventHandler(this.buttonRemoveAlternativeArticle_Click);
            // 
            // checkBoxAlternativeArticlesAutoGenerate
            // 
            this.checkBoxAlternativeArticlesAutoGenerate.AutoSize = true;
            this.checkBoxAlternativeArticlesAutoGenerate.Checked = true;
            this.checkBoxAlternativeArticlesAutoGenerate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxAlternativeArticlesAutoGenerate.Location = new System.Drawing.Point(14, 38);
            this.checkBoxAlternativeArticlesAutoGenerate.Margin = new System.Windows.Forms.Padding(6);
            this.checkBoxAlternativeArticlesAutoGenerate.Name = "checkBoxAlternativeArticlesAutoGenerate";
            this.checkBoxAlternativeArticlesAutoGenerate.Size = new System.Drawing.Size(379, 29);
            this.checkBoxAlternativeArticlesAutoGenerate.TabIndex = 35;
            this.checkBoxAlternativeArticlesAutoGenerate.Text = "Auto Generates Alternative Articles";
            this.checkBoxAlternativeArticlesAutoGenerate.UseVisualStyleBackColor = true;
            this.checkBoxAlternativeArticlesAutoGenerate.Click += new System.EventHandler(this.checkBoxAlternativeArticlesAutoGenerate_Click);
            // 
            // groupBoxAlternativePackSizeArticle
            // 
            this.groupBoxAlternativePackSizeArticle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxAlternativePackSizeArticle.Location = new System.Drawing.Point(1480, 158);
            this.groupBoxAlternativePackSizeArticle.Margin = new System.Windows.Forms.Padding(6);
            this.groupBoxAlternativePackSizeArticle.Name = "groupBoxAlternativePackSizeArticle";
            this.groupBoxAlternativePackSizeArticle.Padding = new System.Windows.Forms.Padding(6);
            this.groupBoxAlternativePackSizeArticle.Size = new System.Drawing.Size(460, 781);
            this.groupBoxAlternativePackSizeArticle.TabIndex = 8;
            this.groupBoxAlternativePackSizeArticle.TabStop = false;
            // 
            // listBoxAlternativePackSizeArticle
            // 
            this.listBoxAlternativePackSizeArticle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxAlternativePackSizeArticle.FormattingEnabled = true;
            this.listBoxAlternativePackSizeArticle.Location = new System.Drawing.Point(12, 75);
            this.listBoxAlternativePackSizeArticle.Margin = new System.Windows.Forms.Padding(6);
            this.listBoxAlternativePackSizeArticle.Name = "listBoxAlternativePackSizeArticle";
            this.listBoxAlternativePackSizeArticle.Size = new System.Drawing.Size(432, 579);
            this.listBoxAlternativePackSizeArticle.TabIndex = 32;
            // 
            // buttonAddAlternativePackSizeArticle
            // 
            this.buttonAddAlternativePackSizeArticle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAddAlternativePackSizeArticle.Location = new System.Drawing.Point(136, 723);
            this.buttonAddAlternativePackSizeArticle.Margin = new System.Windows.Forms.Padding(6);
            this.buttonAddAlternativePackSizeArticle.Name = "buttonAddAlternativePackSizeArticle";
            this.buttonAddAlternativePackSizeArticle.Size = new System.Drawing.Size(150, 44);
            this.buttonAddAlternativePackSizeArticle.TabIndex = 33;
            this.buttonAddAlternativePackSizeArticle.Text = "Add...";
            this.buttonAddAlternativePackSizeArticle.UseVisualStyleBackColor = true;
            this.buttonAddAlternativePackSizeArticle.Click += new System.EventHandler(this.buttonAddAlternativePackSizeArticle_Click);
            // 
            // buttonRemoveAlternativePackSizeArticle
            // 
            this.buttonRemoveAlternativePackSizeArticle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRemoveAlternativePackSizeArticle.Location = new System.Drawing.Point(298, 723);
            this.buttonRemoveAlternativePackSizeArticle.Margin = new System.Windows.Forms.Padding(6);
            this.buttonRemoveAlternativePackSizeArticle.Name = "buttonRemoveAlternativePackSizeArticle";
            this.buttonRemoveAlternativePackSizeArticle.Size = new System.Drawing.Size(150, 44);
            this.buttonRemoveAlternativePackSizeArticle.TabIndex = 34;
            this.buttonRemoveAlternativePackSizeArticle.Text = "Remove";
            this.buttonRemoveAlternativePackSizeArticle.UseVisualStyleBackColor = true;
            this.buttonRemoveAlternativePackSizeArticle.Click += new System.EventHandler(this.buttonRemoveAlternativePackSizeArticle_Click);
            // 
            // checkBoxAlternativePackSizeAutoGenerated
            // 
            this.checkBoxAlternativePackSizeAutoGenerated.AutoSize = true;
            this.checkBoxAlternativePackSizeAutoGenerated.Checked = true;
            this.checkBoxAlternativePackSizeAutoGenerated.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxAlternativePackSizeAutoGenerated.Location = new System.Drawing.Point(14, 38);
            this.checkBoxAlternativePackSizeAutoGenerated.Margin = new System.Windows.Forms.Padding(6);
            this.checkBoxAlternativePackSizeAutoGenerated.Name = "checkBoxAlternativePackSizeAutoGenerated";
            this.checkBoxAlternativePackSizeAutoGenerated.Size = new System.Drawing.Size(404, 29);
            this.checkBoxAlternativePackSizeAutoGenerated.TabIndex = 36;
            this.checkBoxAlternativePackSizeAutoGenerated.Text = "Auto Generates Alternative Pack Size";
            this.checkBoxAlternativePackSizeAutoGenerated.UseVisualStyleBackColor = true;
            this.checkBoxAlternativePackSizeAutoGenerated.Click += new System.EventHandler(this.checkBoxAlternativePackSizeAutoGenerated_Click);
            // 
            // groupBoxTag
            // 
            this.groupBoxTag.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxTag.Location = new System.Drawing.Point(8, 158);
            this.groupBoxTag.Margin = new System.Windows.Forms.Padding(6);
            this.groupBoxTag.Name = "groupBoxTag";
            this.groupBoxTag.Padding = new System.Windows.Forms.Padding(6);
            this.groupBoxTag.Size = new System.Drawing.Size(516, 781);
            this.groupBoxTag.TabIndex = 9;
            this.groupBoxTag.TabStop = false;
            // 
            // listBoxTag
            // 
            this.listBoxTag.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxTag.FormattingEnabled = true;
            this.listBoxTag.Location = new System.Drawing.Point(12, 75);
            this.listBoxTag.Margin = new System.Windows.Forms.Padding(6);
            this.listBoxTag.Name = "listBoxTag";
            this.listBoxTag.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxTag.Size = new System.Drawing.Size(488, 579);
            this.listBoxTag.TabIndex = 29;
            // 
            // buttonAddTag
            // 
            this.buttonAddTag.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAddTag.Location = new System.Drawing.Point(192, 723);
            this.buttonAddTag.Margin = new System.Windows.Forms.Padding(6);
            this.buttonAddTag.Name = "buttonAddTag";
            this.buttonAddTag.Size = new System.Drawing.Size(150, 44);
            this.buttonAddTag.TabIndex = 30;
            this.buttonAddTag.Text = "Add...";
            this.buttonAddTag.UseVisualStyleBackColor = true;
            this.buttonAddTag.Click += new System.EventHandler(this.buttonAddTag_Click);
            // 
            // buttonRemoveTag
            // 
            this.buttonRemoveTag.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRemoveTag.Location = new System.Drawing.Point(354, 723);
            this.buttonRemoveTag.Margin = new System.Windows.Forms.Padding(6);
            this.buttonRemoveTag.Name = "buttonRemoveTag";
            this.buttonRemoveTag.Size = new System.Drawing.Size(150, 44);
            this.buttonRemoveTag.TabIndex = 31;
            this.buttonRemoveTag.Text = "Remove";
            this.buttonRemoveTag.UseVisualStyleBackColor = true;
            this.buttonRemoveTag.Click += new System.EventHandler(this.buttonRemoveTag_Click);
            // 
            // checkBoxTagAutoGenerate
            // 
            this.checkBoxTagAutoGenerate.AutoSize = true;
            this.checkBoxTagAutoGenerate.Checked = true;
            this.checkBoxTagAutoGenerate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxTagAutoGenerate.Location = new System.Drawing.Point(14, 38);
            this.checkBoxTagAutoGenerate.Margin = new System.Windows.Forms.Padding(6);
            this.checkBoxTagAutoGenerate.Name = "checkBoxTagAutoGenerate";
            this.checkBoxTagAutoGenerate.Size = new System.Drawing.Size(237, 29);
            this.checkBoxTagAutoGenerate.TabIndex = 32;
            this.checkBoxTagAutoGenerate.Text = "Auto Generate Tags";
            this.checkBoxTagAutoGenerate.UseVisualStyleBackColor = true;
            this.checkBoxTagAutoGenerate.Click += new System.EventHandler(this.checkBoxTagAutoGenerate_Click);
            // 
            // groupBoxArticleInformation
            // 
            this.groupBoxArticleInformation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxArticleInformation.Location = new System.Drawing.Point(8, 8);
            this.groupBoxArticleInformation.Margin = new System.Windows.Forms.Padding(6);
            this.groupBoxArticleInformation.Name = "groupBoxArticleInformation";
            this.groupBoxArticleInformation.Padding = new System.Windows.Forms.Padding(6);
            this.groupBoxArticleInformation.Size = new System.Drawing.Size(1932, 138);
            this.groupBoxArticleInformation.TabIndex = 10;
            this.groupBoxArticleInformation.TabStop = false;
            // 
            // checkBoxArticleInformationAutoGenerate
            // 
            this.checkBoxArticleInformationAutoGenerate.AutoSize = true;
            this.checkBoxArticleInformationAutoGenerate.Checked = true;
            this.checkBoxArticleInformationAutoGenerate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxArticleInformationAutoGenerate.Location = new System.Drawing.Point(14, 38);
            this.checkBoxArticleInformationAutoGenerate.Margin = new System.Windows.Forms.Padding(6);
            this.checkBoxArticleInformationAutoGenerate.Name = "checkBoxArticleInformationAutoGenerate";
            this.checkBoxArticleInformationAutoGenerate.Size = new System.Drawing.Size(361, 29);
            this.checkBoxArticleInformationAutoGenerate.TabIndex = 33;
            this.checkBoxArticleInformationAutoGenerate.Text = "Auto Generate Article Information";
            this.checkBoxArticleInformationAutoGenerate.UseVisualStyleBackColor = true;
            this.checkBoxArticleInformationAutoGenerate.Click += new System.EventHandler(this.checkBoxArticleInformationAutoGenerate_Click);
            // 
            // textBoxArticleName
            // 
            this.textBoxArticleName.Location = new System.Drawing.Point(158, 83);
            this.textBoxArticleName.Margin = new System.Windows.Forms.Padding(6);
            this.textBoxArticleName.Name = "textBoxArticleName";
            this.textBoxArticleName.Size = new System.Drawing.Size(358, 31);
            this.textBoxArticleName.TabIndex = 34;
            // 
            // labelArticleName
            // 
            this.labelArticleName.AutoSize = true;
            this.labelArticleName.Location = new System.Drawing.Point(6, 88);
            this.labelArticleName.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelArticleName.Name = "labelArticleName";
            this.labelArticleName.Size = new System.Drawing.Size(140, 25);
            this.labelArticleName.TabIndex = 35;
            // 
            // labelDosageForm
            // 
            this.labelDosageForm.AutoSize = true;
            this.labelDosageForm.Location = new System.Drawing.Point(550, 88);
            this.labelDosageForm.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelDosageForm.Name = "labelDosageForm";
            this.labelDosageForm.Size = new System.Drawing.Size(147, 25);
            this.labelDosageForm.TabIndex = 36;
            // 
            // textBoxDosageForm
            // 
            this.textBoxDosageForm.Location = new System.Drawing.Point(708, 83);
            this.textBoxDosageForm.Margin = new System.Windows.Forms.Padding(6);
            this.textBoxDosageForm.Name = "textBoxDosageForm";
            this.textBoxDosageForm.Size = new System.Drawing.Size(292, 31);
            this.textBoxDosageForm.TabIndex = 37;
            // 
            // labelPackagingUnit
            // 
            this.labelPackagingUnit.AutoSize = true;
            this.labelPackagingUnit.Location = new System.Drawing.Point(1022, 88);
            this.labelPackagingUnit.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelPackagingUnit.Name = "labelPackagingUnit";
            this.labelPackagingUnit.Size = new System.Drawing.Size(163, 25);
            this.labelPackagingUnit.TabIndex = 38;
            // 
            // textBoxPackagingUnit
            // 
            this.textBoxPackagingUnit.Location = new System.Drawing.Point(1200, 83);
            this.textBoxPackagingUnit.Margin = new System.Windows.Forms.Padding(6);
            this.textBoxPackagingUnit.Name = "textBoxPackagingUnit";
            this.textBoxPackagingUnit.Size = new System.Drawing.Size(272, 31);
            this.textBoxPackagingUnit.TabIndex = 39;
            // 
            // labelMaxSubItemQuantity
            // 
            this.labelMaxSubItemQuantity.AutoSize = true;
            this.labelMaxSubItemQuantity.Location = new System.Drawing.Point(1494, 88);
            this.labelMaxSubItemQuantity.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelMaxSubItemQuantity.Name = "labelMaxSubItemQuantity";
            this.labelMaxSubItemQuantity.Size = new System.Drawing.Size(235, 25);
            this.labelMaxSubItemQuantity.TabIndex = 40;
            // 
            // numericUpDownMaxSubItemQuantity
            // 
            this.numericUpDownMaxSubItemQuantity.Location = new System.Drawing.Point(1740, 83);
            this.numericUpDownMaxSubItemQuantity.Margin = new System.Windows.Forms.Padding(6);
            this.numericUpDownMaxSubItemQuantity.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDownMaxSubItemQuantity.Name = "numericUpDownMaxSubItemQuantity";
            this.numericUpDownMaxSubItemQuantity.Size = new System.Drawing.Size(198, 31);
            this.numericUpDownMaxSubItemQuantity.TabIndex = 42;
            // 
            // tabPageLog
            // 
            this.tabPageLog.Location = new System.Drawing.Point(8, 39);
            this.tabPageLog.Margin = new System.Windows.Forms.Padding(6);
            this.tabPageLog.Name = "tabPageLog";
            this.tabPageLog.Padding = new System.Windows.Forms.Padding(6);
            this.tabPageLog.Size = new System.Drawing.Size(1960, 995);
            this.tabPageLog.TabIndex = 0;
            this.tabPageLog.Text = "Log";
            this.tabPageLog.UseVisualStyleBackColor = true;
            // 
            // listBoxDigitalShelfLog
            // 
            this.listBoxDigitalShelfLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxDigitalShelfLog.FormattingEnabled = true;
            this.listBoxDigitalShelfLog.Location = new System.Drawing.Point(12, 12);
            this.listBoxDigitalShelfLog.Margin = new System.Windows.Forms.Padding(6);
            this.listBoxDigitalShelfLog.Name = "listBoxDigitalShelfLog";
            this.listBoxDigitalShelfLog.Size = new System.Drawing.Size(1916, 804);
            this.listBoxDigitalShelfLog.TabIndex = 28;
            // 
            // buttonClearDigitalShelfLog
            // 
            this.buttonClearDigitalShelfLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClearDigitalShelfLog.Location = new System.Drawing.Point(1782, 896);
            this.buttonClearDigitalShelfLog.Margin = new System.Windows.Forms.Padding(6);
            this.buttonClearDigitalShelfLog.Name = "buttonClearDigitalShelfLog";
            this.buttonClearDigitalShelfLog.Size = new System.Drawing.Size(150, 44);
            this.buttonClearDigitalShelfLog.TabIndex = 29;
            this.buttonClearDigitalShelfLog.Text = "Clear";
            this.buttonClearDigitalShelfLog.UseVisualStyleBackColor = true;
            this.buttonClearDigitalShelfLog.Click += new System.EventHandler(this.buttonClearDigitalShelfLog_Click);
            // 
            // btnSendRawXml
            // 
            this.btnSendRawXml.Enabled = false;
            this.btnSendRawXml.Location = new System.Drawing.Point(1032, 569);
            this.btnSendRawXml.Margin = new System.Windows.Forms.Padding(6);
            this.btnSendRawXml.Name = "btnSendRawXml";
            this.btnSendRawXml.Size = new System.Drawing.Size(150, 44);
            this.btnSendRawXml.TabIndex = 1;
            this.btnSendRawXml.Text = "Send";
            this.btnSendRawXml.UseVisualStyleBackColor = true;
            this.btnSendRawXml.Click += new System.EventHandler(this.btnSendRawXml_Click);
            // 
            // btnClearRawXml
            // 
            this.btnClearRawXml.Location = new System.Drawing.Point(870, 569);
            this.btnClearRawXml.Margin = new System.Windows.Forms.Padding(6);
            this.btnClearRawXml.Name = "btnClearRawXml";
            this.btnClearRawXml.Size = new System.Drawing.Size(150, 44);
            this.btnClearRawXml.TabIndex = 2;
            this.btnClearRawXml.Text = "Clear";
            this.btnClearRawXml.UseVisualStyleBackColor = true;
            this.btnClearRawXml.Click += new System.EventHandler(this.btnClearRawXml_Click);
            // 
            // txtRawXml
            // 
            this.txtRawXml.AutoWordSelection = true;
            this.txtRawXml.Location = new System.Drawing.Point(16, 62);
            this.txtRawXml.Margin = new System.Windows.Forms.Padding(6);
            this.txtRawXml.Name = "txtRawXml";
            this.txtRawXml.Size = new System.Drawing.Size(1162, 492);
            this.txtRawXml.TabIndex = 3;
            this.txtRawXml.Text = "";
            this.txtRawXml.TextChanged += new System.EventHandler(this.txtRawXml_TextChanged);
            // 
            // btnReloadStockLocations
            // 
            this.btnReloadStockLocations.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReloadStockLocations.Enabled = false;
            this.btnReloadStockLocations.Location = new System.Drawing.Point(1770, 887);
            this.btnReloadStockLocations.Margin = new System.Windows.Forms.Padding(6);
            this.btnReloadStockLocations.Name = "btnReloadStockLocations";
            this.btnReloadStockLocations.Size = new System.Drawing.Size(150, 44);
            this.btnReloadStockLocations.TabIndex = 11;
            this.btnReloadStockLocations.Text = "Reload";
            this.btnReloadStockLocations.UseVisualStyleBackColor = true;
            this.btnReloadStockLocations.Click += new System.EventHandler(this.btnReloadStockLocations_Click);
            // 
            // dataGridStockLocations
            // 
            this.dataGridStockLocations.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridStockLocations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridStockLocations.Location = new System.Drawing.Point(12, 37);
            this.dataGridStockLocations.Margin = new System.Windows.Forms.Padding(6);
            this.dataGridStockLocations.Name = "dataGridStockLocations";
            this.dataGridStockLocations.RowHeadersWidth = 82;
            this.dataGridStockLocations.Size = new System.Drawing.Size(1908, 838);
            this.dataGridStockLocations.TabIndex = 10;
            this.dataGridStockLocations.SizeChanged += new System.EventHandler(this.dataGridStockLocations_SizeChanged);
            // 
            // btnReloadComponents
            // 
            this.btnReloadComponents.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReloadComponents.Enabled = false;
            this.btnReloadComponents.Location = new System.Drawing.Point(1770, 887);
            this.btnReloadComponents.Margin = new System.Windows.Forms.Padding(6);
            this.btnReloadComponents.Name = "btnReloadComponents";
            this.btnReloadComponents.Size = new System.Drawing.Size(150, 44);
            this.btnReloadComponents.TabIndex = 11;
            this.btnReloadComponents.Text = "Reload";
            this.btnReloadComponents.UseVisualStyleBackColor = true;
            this.btnReloadComponents.Click += new System.EventHandler(this.btnReloadComponents_Click);
            // 
            // dataGridComponents
            // 
            this.dataGridComponents.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridComponents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridComponents.Location = new System.Drawing.Point(12, 37);
            this.dataGridComponents.Margin = new System.Windows.Forms.Padding(6);
            this.dataGridComponents.Name = "dataGridComponents";
            this.dataGridComponents.RowHeadersWidth = 82;
            this.dataGridComponents.Size = new System.Drawing.Size(1908, 838);
            this.dataGridComponents.TabIndex = 10;
            this.dataGridComponents.SizeChanged += new System.EventHandler(this.dataGridComponents_SizeChanged);
            // 
            // dataGridArticleInfo
            // 
            this.dataGridArticleInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridArticleInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridArticleInfo.Location = new System.Drawing.Point(12, 37);
            this.dataGridArticleInfo.Margin = new System.Windows.Forms.Padding(6);
            this.dataGridArticleInfo.Name = "dataGridArticleInfo";
            this.dataGridArticleInfo.RowHeadersWidth = 82;
            this.dataGridArticleInfo.Size = new System.Drawing.Size(496, 763);
            this.dataGridArticleInfo.TabIndex = 18;
            this.dataGridArticleInfo.SelectionChanged += new System.EventHandler(this.dataGridArticleInfo_SelectionChanged);
            this.dataGridArticleInfo.SizeChanged += new System.EventHandler(this.dataGridArticleInfo_SizeChanged);
            // 
            // dataGridPackInfo
            // 
            this.dataGridPackInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridPackInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridPackInfo.Location = new System.Drawing.Point(14, 37);
            this.dataGridPackInfo.Margin = new System.Windows.Forms.Padding(6);
            this.dataGridPackInfo.Name = "dataGridPackInfo";
            this.dataGridPackInfo.RowHeadersWidth = 82;
            this.dataGridPackInfo.Size = new System.Drawing.Size(1376, 763);
            this.dataGridPackInfo.TabIndex = 20;
            this.dataGridPackInfo.SizeChanged += new System.EventHandler(this.dataGridPackInfo_SizeChanged);
            // 
            // lblTaskID
            // 
            this.lblTaskID.AutoSize = true;
            this.lblTaskID.Location = new System.Drawing.Point(12, 50);
            this.lblTaskID.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblTaskID.Name = "lblTaskID";
            this.lblTaskID.Size = new System.Drawing.Size(91, 25);
            this.lblTaskID.TabIndex = 10;
            // 
            // txtTaskID
            // 
            this.txtTaskID.Location = new System.Drawing.Point(120, 44);
            this.txtTaskID.Margin = new System.Windows.Forms.Padding(6);
            this.txtTaskID.Name = "txtTaskID";
            this.txtTaskID.Size = new System.Drawing.Size(196, 31);
            this.txtTaskID.TabIndex = 11;
            // 
            // lblTaskType
            // 
            this.lblTaskType.AutoSize = true;
            this.lblTaskType.Location = new System.Drawing.Point(372, 50);
            this.lblTaskType.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblTaskType.Name = "lblTaskType";
            this.lblTaskType.Size = new System.Drawing.Size(119, 25);
            this.lblTaskType.TabIndex = 12;
            // 
            // cmbTaskType
            // 
            this.cmbTaskType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTaskType.FormattingEnabled = true;
            this.cmbTaskType.Items.AddRange(new object[] {
            "Output",
            "StockDelivery"});
            this.cmbTaskType.Location = new System.Drawing.Point(506, 42);
            this.cmbTaskType.Margin = new System.Windows.Forms.Padding(6);
            this.cmbTaskType.Name = "cmbTaskType";
            this.cmbTaskType.Size = new System.Drawing.Size(238, 33);
            this.cmbTaskType.TabIndex = 13;
            // 
            // lblTaskStateDesc
            // 
            this.lblTaskStateDesc.AutoSize = true;
            this.lblTaskStateDesc.Location = new System.Drawing.Point(824, 50);
            this.lblTaskStateDesc.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblTaskStateDesc.Name = "lblTaskStateDesc";
            this.lblTaskStateDesc.Size = new System.Drawing.Size(132, 25);
            this.lblTaskStateDesc.TabIndex = 14;
            // 
            // lblTaskState
            // 
            this.lblTaskState.AutoSize = true;
            this.lblTaskState.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTaskState.Location = new System.Drawing.Point(970, 50);
            this.lblTaskState.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblTaskState.Name = "lblTaskState";
            this.lblTaskState.Size = new System.Drawing.Size(110, 26);
            this.lblTaskState.TabIndex = 15;
            // 
            // btnGetTaskInfo
            // 
            this.btnGetTaskInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGetTaskInfo.Enabled = false;
            this.btnGetTaskInfo.Location = new System.Drawing.Point(1770, 38);
            this.btnGetTaskInfo.Margin = new System.Windows.Forms.Padding(6);
            this.btnGetTaskInfo.Name = "btnGetTaskInfo";
            this.btnGetTaskInfo.Size = new System.Drawing.Size(150, 44);
            this.btnGetTaskInfo.TabIndex = 16;
            this.btnGetTaskInfo.Text = "Get Info";
            this.btnGetTaskInfo.UseVisualStyleBackColor = true;
            this.btnGetTaskInfo.Click += new System.EventHandler(this.btnGetTaskInfo_Click);
            // 
            // dataGridMasterArticles
            // 
            this.dataGridMasterArticles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridMasterArticles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridMasterArticles.Location = new System.Drawing.Point(12, 37);
            this.dataGridMasterArticles.Margin = new System.Windows.Forms.Padding(6);
            this.dataGridMasterArticles.Name = "dataGridMasterArticles";
            this.dataGridMasterArticles.RowHeadersWidth = 82;
            this.dataGridMasterArticles.Size = new System.Drawing.Size(1908, 840);
            this.dataGridMasterArticles.TabIndex = 10;
            this.dataGridMasterArticles.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridMasterArticles_CellEnter);
            this.dataGridMasterArticles.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridMasterArticles_RowEnter);
            this.dataGridMasterArticles.SelectionChanged += new System.EventHandler(this.dataGridMasterArticles_SelectionChanged);
            this.dataGridMasterArticles.Resize += new System.EventHandler(this.dataGridMasterArticles_SizeChanged);
            // 
            // dataGridOrderItems
            // 
            this.dataGridOrderItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridOrderItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridOrderItems.Location = new System.Drawing.Point(12, 35);
            this.dataGridOrderItems.Margin = new System.Windows.Forms.Padding(6);
            this.dataGridOrderItems.Name = "dataGridOrderItems";
            this.dataGridOrderItems.RowHeadersWidth = 82;
            this.dataGridOrderItems.Size = new System.Drawing.Size(492, 312);
            this.dataGridOrderItems.TabIndex = 17;
            this.dataGridOrderItems.SelectionChanged += new System.EventHandler(this.dataGridOrderItems_SelectionChanged);
            // 
            // dataGridItemLabels
            // 
            this.dataGridItemLabels.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridItemLabels.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridItemLabels.Location = new System.Drawing.Point(12, 37);
            this.dataGridItemLabels.Margin = new System.Windows.Forms.Padding(6);
            this.dataGridItemLabels.Name = "dataGridItemLabels";
            this.dataGridItemLabels.RowHeadersWidth = 82;
            this.dataGridItemLabels.Size = new System.Drawing.Size(1908, 194);
            this.dataGridItemLabels.TabIndex = 19;
            // 
            // dataGridDispensedPacks
            // 
            this.dataGridDispensedPacks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridDispensedPacks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridDispensedPacks.Location = new System.Drawing.Point(12, 37);
            this.dataGridDispensedPacks.Margin = new System.Windows.Forms.Padding(6);
            this.dataGridDispensedPacks.Name = "dataGridDispensedPacks";
            this.dataGridDispensedPacks.RowHeadersWidth = 82;
            this.dataGridDispensedPacks.Size = new System.Drawing.Size(1910, 281);
            this.dataGridDispensedPacks.TabIndex = 21;
            // 
            // dataGridOrders
            // 
            this.dataGridOrders.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridOrders.Location = new System.Drawing.Point(12, 37);
            this.dataGridOrders.Margin = new System.Windows.Forms.Padding(6);
            this.dataGridOrders.Name = "dataGridOrders";
            this.dataGridOrders.RowHeadersWidth = 82;
            this.dataGridOrders.Size = new System.Drawing.Size(878, 252);
            this.dataGridOrders.TabIndex = 10;
            this.dataGridOrders.SelectionChanged += new System.EventHandler(this.dataGridOrders_SelectionChanged);
            // 
            // btnNewOrder
            // 
            this.btnNewOrder.Enabled = false;
            this.btnNewOrder.Location = new System.Drawing.Point(14, 302);
            this.btnNewOrder.Margin = new System.Windows.Forms.Padding(6);
            this.btnNewOrder.Name = "btnNewOrder";
            this.btnNewOrder.Size = new System.Drawing.Size(150, 44);
            this.btnNewOrder.TabIndex = 11;
            this.btnNewOrder.Text = "&New ...";
            this.btnNewOrder.UseVisualStyleBackColor = true;
            this.btnNewOrder.Click += new System.EventHandler(this.btnNewOrder_Click);
            // 
            // btnSendOrder
            // 
            this.btnSendOrder.Enabled = false;
            this.btnSendOrder.Location = new System.Drawing.Point(338, 302);
            this.btnSendOrder.Margin = new System.Windows.Forms.Padding(6);
            this.btnSendOrder.Name = "btnSendOrder";
            this.btnSendOrder.Size = new System.Drawing.Size(150, 44);
            this.btnSendOrder.TabIndex = 13;
            this.btnSendOrder.Text = "&Send";
            this.btnSendOrder.UseVisualStyleBackColor = true;
            this.btnSendOrder.Click += new System.EventHandler(this.btnSendOrder_Click);
            // 
            // btnCancelOrder
            // 
            this.btnCancelOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelOrder.Enabled = false;
            this.btnCancelOrder.Location = new System.Drawing.Point(578, 300);
            this.btnCancelOrder.Margin = new System.Windows.Forms.Padding(6);
            this.btnCancelOrder.Name = "btnCancelOrder";
            this.btnCancelOrder.Size = new System.Drawing.Size(150, 44);
            this.btnCancelOrder.TabIndex = 14;
            this.btnCancelOrder.Text = "&Cancel";
            this.btnCancelOrder.UseVisualStyleBackColor = true;
            this.btnCancelOrder.Click += new System.EventHandler(this.btnCancelOrder_Click);
            // 
            // btnClearOrders
            // 
            this.btnClearOrders.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearOrders.Location = new System.Drawing.Point(740, 300);
            this.btnClearOrders.Margin = new System.Windows.Forms.Padding(6);
            this.btnClearOrders.Name = "btnClearOrders";
            this.btnClearOrders.Size = new System.Drawing.Size(150, 44);
            this.btnClearOrders.TabIndex = 15;
            this.btnClearOrders.Text = "Clear";
            this.btnClearOrders.UseVisualStyleBackColor = true;
            this.btnClearOrders.Click += new System.EventHandler(this.btnClearOrders_Click);
            // 
            // btnBulkOrder
            // 
            this.btnBulkOrder.Enabled = false;
            this.btnBulkOrder.Location = new System.Drawing.Point(176, 302);
            this.btnBulkOrder.Margin = new System.Windows.Forms.Padding(6);
            this.btnBulkOrder.Name = "btnBulkOrder";
            this.btnBulkOrder.Size = new System.Drawing.Size(150, 44);
            this.btnBulkOrder.TabIndex = 12;
            this.btnBulkOrder.Text = "&Bulk ...";
            this.btnBulkOrder.UseVisualStyleBackColor = true;
            this.btnBulkOrder.Click += new System.EventHandler(this.btnBulkOrder_Click);
            // 
            // dataGridOrderBoxes
            // 
            this.dataGridOrderBoxes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridOrderBoxes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridOrderBoxes.Location = new System.Drawing.Point(12, 35);
            this.dataGridOrderBoxes.Margin = new System.Windows.Forms.Padding(6);
            this.dataGridOrderBoxes.Name = "dataGridOrderBoxes";
            this.dataGridOrderBoxes.RowHeadersWidth = 82;
            this.dataGridOrderBoxes.Size = new System.Drawing.Size(466, 312);
            this.dataGridOrderBoxes.TabIndex = 17;
            this.dataGridOrderBoxes.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridOrderBoxes_DataError);
            // 
            // chkSetPickingIndicator
            // 
            this.chkSetPickingIndicator.AutoSize = true;
            this.chkSetPickingIndicator.Location = new System.Drawing.Point(320, 746);
            this.chkSetPickingIndicator.Margin = new System.Windows.Forms.Padding(6);
            this.chkSetPickingIndicator.Name = "chkSetPickingIndicator";
            this.chkSetPickingIndicator.Size = new System.Drawing.Size(240, 29);
            this.chkSetPickingIndicator.TabIndex = 38;
            this.chkSetPickingIndicator.Text = "Set Picking Indicator";
            this.chkSetPickingIndicator.UseVisualStyleBackColor = true;
            // 
            // lblInitInputID
            // 
            this.lblInitInputID.AutoSize = true;
            this.lblInitInputID.Location = new System.Drawing.Point(34, 52);
            this.lblInitInputID.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblInitInputID.Name = "lblInitInputID";
            this.lblInitInputID.Size = new System.Drawing.Size(240, 25);
            this.lblInitInputID.TabIndex = 10;
            // 
            // txtDeliveryNumber
            // 
            this.txtDeliveryNumber.Location = new System.Drawing.Point(320, 148);
            this.txtDeliveryNumber.Margin = new System.Windows.Forms.Padding(6);
            this.txtDeliveryNumber.Name = "txtDeliveryNumber";
            this.txtDeliveryNumber.Size = new System.Drawing.Size(450, 31);
            this.txtDeliveryNumber.TabIndex = 15;
            // 
            // numInitInputID
            // 
            this.numInitInputID.Location = new System.Drawing.Point(320, 48);
            this.numInitInputID.Margin = new System.Windows.Forms.Padding(6);
            this.numInitInputID.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.numInitInputID.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numInitInputID.Name = "numInitInputID";
            this.numInitInputID.Size = new System.Drawing.Size(456, 31);
            this.numInitInputID.TabIndex = 11;
            this.numInitInputID.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblDeliveryNumber
            // 
            this.lblDeliveryNumber.AutoSize = true;
            this.lblDeliveryNumber.Location = new System.Drawing.Point(34, 154);
            this.lblDeliveryNumber.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblDeliveryNumber.Name = "lblDeliveryNumber";
            this.lblDeliveryNumber.Size = new System.Drawing.Size(177, 25);
            this.lblDeliveryNumber.TabIndex = 14;
            // 
            // lblInputSource
            // 
            this.lblInputSource.AutoSize = true;
            this.lblInputSource.Location = new System.Drawing.Point(34, 200);
            this.lblInputSource.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblInputSource.Name = "lblInputSource";
            this.lblInputSource.Size = new System.Drawing.Size(139, 25);
            this.lblInputSource.TabIndex = 16;
            // 
            // numInputSource
            // 
            this.numInputSource.Location = new System.Drawing.Point(320, 196);
            this.numInputSource.Margin = new System.Windows.Forms.Padding(6);
            this.numInputSource.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.numInputSource.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numInputSource.Name = "numInputSource";
            this.numInputSource.Size = new System.Drawing.Size(456, 31);
            this.numInputSource.TabIndex = 17;
            this.numInputSource.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // txtPackScanCode
            // 
            this.txtPackScanCode.Location = new System.Drawing.Point(320, 296);
            this.txtPackScanCode.Margin = new System.Windows.Forms.Padding(6);
            this.txtPackScanCode.Name = "txtPackScanCode";
            this.txtPackScanCode.Size = new System.Drawing.Size(450, 31);
            this.txtPackScanCode.TabIndex = 21;
            // 
            // lblPackScanCode
            // 
            this.lblPackScanCode.AutoSize = true;
            this.lblPackScanCode.Location = new System.Drawing.Point(34, 302);
            this.lblPackScanCode.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblPackScanCode.Name = "lblPackScanCode";
            this.lblPackScanCode.Size = new System.Drawing.Size(178, 25);
            this.lblPackScanCode.TabIndex = 20;
            // 
            // txtPackBatchNumber
            // 
            this.txtPackBatchNumber.Location = new System.Drawing.Point(320, 346);
            this.txtPackBatchNumber.Margin = new System.Windows.Forms.Padding(6);
            this.txtPackBatchNumber.Name = "txtPackBatchNumber";
            this.txtPackBatchNumber.Size = new System.Drawing.Size(450, 31);
            this.txtPackBatchNumber.TabIndex = 23;
            // 
            // lblPackBatchNumber
            // 
            this.lblPackBatchNumber.AutoSize = true;
            this.lblPackBatchNumber.Location = new System.Drawing.Point(34, 352);
            this.lblPackBatchNumber.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblPackBatchNumber.Name = "lblPackBatchNumber";
            this.lblPackBatchNumber.Size = new System.Drawing.Size(208, 25);
            this.lblPackBatchNumber.TabIndex = 22;
            // 
            // txtPackExpiryDate
            // 
            this.txtPackExpiryDate.Location = new System.Drawing.Point(320, 396);
            this.txtPackExpiryDate.Margin = new System.Windows.Forms.Padding(6);
            this.txtPackExpiryDate.Name = "txtPackExpiryDate";
            this.txtPackExpiryDate.Size = new System.Drawing.Size(450, 31);
            this.txtPackExpiryDate.TabIndex = 25;
            // 
            // lblPackExpiryDate
            // 
            this.lblPackExpiryDate.AutoSize = true;
            this.lblPackExpiryDate.Location = new System.Drawing.Point(34, 402);
            this.lblPackExpiryDate.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblPackExpiryDate.Name = "lblPackExpiryDate";
            this.lblPackExpiryDate.Size = new System.Drawing.Size(183, 25);
            this.lblPackExpiryDate.TabIndex = 24;
            // 
            // lblPackSubItemQuantity
            // 
            this.lblPackSubItemQuantity.AutoSize = true;
            this.lblPackSubItemQuantity.Location = new System.Drawing.Point(34, 450);
            this.lblPackSubItemQuantity.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblPackSubItemQuantity.Name = "lblPackSubItemQuantity";
            this.lblPackSubItemQuantity.Size = new System.Drawing.Size(230, 25);
            this.lblPackSubItemQuantity.TabIndex = 26;
            // 
            // numPackSubItemQuantity
            // 
            this.numPackSubItemQuantity.Location = new System.Drawing.Point(320, 446);
            this.numPackSubItemQuantity.Margin = new System.Windows.Forms.Padding(6);
            this.numPackSubItemQuantity.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.numPackSubItemQuantity.Name = "numPackSubItemQuantity";
            this.numPackSubItemQuantity.Size = new System.Drawing.Size(456, 31);
            this.numPackSubItemQuantity.TabIndex = 27;
            // 
            // lblPackDepth
            // 
            this.lblPackDepth.AutoSize = true;
            this.lblPackDepth.Location = new System.Drawing.Point(34, 500);
            this.lblPackDepth.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblPackDepth.Name = "lblPackDepth";
            this.lblPackDepth.Size = new System.Drawing.Size(129, 25);
            this.lblPackDepth.TabIndex = 28;
            // 
            // numPackDepth
            // 
            this.numPackDepth.Location = new System.Drawing.Point(320, 496);
            this.numPackDepth.Margin = new System.Windows.Forms.Padding(6);
            this.numPackDepth.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.numPackDepth.Name = "numPackDepth";
            this.numPackDepth.Size = new System.Drawing.Size(456, 31);
            this.numPackDepth.TabIndex = 29;
            // 
            // lblPackWidth
            // 
            this.lblPackWidth.AutoSize = true;
            this.lblPackWidth.Location = new System.Drawing.Point(34, 550);
            this.lblPackWidth.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblPackWidth.Name = "lblPackWidth";
            this.lblPackWidth.Size = new System.Drawing.Size(127, 25);
            this.lblPackWidth.TabIndex = 30;
            // 
            // numPackWidth
            // 
            this.numPackWidth.Location = new System.Drawing.Point(320, 546);
            this.numPackWidth.Margin = new System.Windows.Forms.Padding(6);
            this.numPackWidth.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.numPackWidth.Name = "numPackWidth";
            this.numPackWidth.Size = new System.Drawing.Size(456, 31);
            this.numPackWidth.TabIndex = 31;
            // 
            // lblPackHeight
            // 
            this.lblPackHeight.AutoSize = true;
            this.lblPackHeight.Location = new System.Drawing.Point(34, 600);
            this.lblPackHeight.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblPackHeight.Name = "lblPackHeight";
            this.lblPackHeight.Size = new System.Drawing.Size(134, 25);
            this.lblPackHeight.TabIndex = 32;
            // 
            // numPackHeight
            // 
            this.numPackHeight.Location = new System.Drawing.Point(320, 596);
            this.numPackHeight.Margin = new System.Windows.Forms.Padding(6);
            this.numPackHeight.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.numPackHeight.Name = "numPackHeight";
            this.numPackHeight.Size = new System.Drawing.Size(456, 31);
            this.numPackHeight.TabIndex = 33;
            // 
            // lblPackShape
            // 
            this.lblPackShape.AutoSize = true;
            this.lblPackShape.Location = new System.Drawing.Point(34, 650);
            this.lblPackShape.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblPackShape.Name = "lblPackShape";
            this.lblPackShape.Size = new System.Drawing.Size(134, 25);
            this.lblPackShape.TabIndex = 34;
            // 
            // cmbPackShape
            // 
            this.cmbPackShape.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPackShape.FormattingEnabled = true;
            this.cmbPackShape.Items.AddRange(new object[] {
            "Cuboid",
            "Cylinder"});
            this.cmbPackShape.Location = new System.Drawing.Point(320, 644);
            this.cmbPackShape.Margin = new System.Windows.Forms.Padding(6);
            this.cmbPackShape.Name = "cmbPackShape";
            this.cmbPackShape.Size = new System.Drawing.Size(450, 33);
            this.cmbPackShape.TabIndex = 35;
            // 
            // btnSendInitInputRequest
            // 
            this.btnSendInitInputRequest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSendInitInputRequest.Enabled = false;
            this.btnSendInitInputRequest.Location = new System.Drawing.Point(624, 887);
            this.btnSendInitInputRequest.Margin = new System.Windows.Forms.Padding(6);
            this.btnSendInitInputRequest.Name = "btnSendInitInputRequest";
            this.btnSendInitInputRequest.Size = new System.Drawing.Size(150, 44);
            this.btnSendInitInputRequest.TabIndex = 39;
            this.btnSendInitInputRequest.Text = "Send";
            this.btnSendInitInputRequest.UseVisualStyleBackColor = true;
            this.btnSendInitInputRequest.Click += new System.EventHandler(this.btnSendInitInputRequest_Click);
            // 
            // lblInputPoint
            // 
            this.lblInputPoint.AutoSize = true;
            this.lblInputPoint.Location = new System.Drawing.Point(34, 250);
            this.lblInputPoint.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblInputPoint.Name = "lblInputPoint";
            this.lblInputPoint.Size = new System.Drawing.Size(120, 25);
            this.lblInputPoint.TabIndex = 18;
            // 
            // numInputPoint
            // 
            this.numInputPoint.Location = new System.Drawing.Point(320, 246);
            this.numInputPoint.Margin = new System.Windows.Forms.Padding(6);
            this.numInputPoint.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.numInputPoint.Name = "numInputPoint";
            this.numInputPoint.Size = new System.Drawing.Size(456, 31);
            this.numInputPoint.TabIndex = 19;
            // 
            // lblDestination
            // 
            this.lblDestination.AutoSize = true;
            this.lblDestination.Location = new System.Drawing.Point(34, 102);
            this.lblDestination.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblDestination.Name = "lblDestination";
            this.lblDestination.Size = new System.Drawing.Size(126, 25);
            this.lblDestination.TabIndex = 12;
            // 
            // numDestination
            // 
            this.numDestination.Location = new System.Drawing.Point(320, 98);
            this.numDestination.Margin = new System.Windows.Forms.Padding(6);
            this.numDestination.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.numDestination.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numDestination.Name = "numDestination";
            this.numDestination.Size = new System.Drawing.Size(456, 31);
            this.numDestination.TabIndex = 13;
            this.numDestination.Value = new decimal(new int[] {
            999,
            0,
            0,
            0});
            // 
            // txtPackStockLocation
            // 
            this.txtPackStockLocation.Location = new System.Drawing.Point(320, 696);
            this.txtPackStockLocation.Margin = new System.Windows.Forms.Padding(6);
            this.txtPackStockLocation.Name = "txtPackStockLocation";
            this.txtPackStockLocation.Size = new System.Drawing.Size(450, 31);
            this.txtPackStockLocation.TabIndex = 37;
            // 
            // lblStockLocation
            // 
            this.lblStockLocation.AutoSize = true;
            this.lblStockLocation.Location = new System.Drawing.Point(34, 702);
            this.lblStockLocation.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblStockLocation.Name = "lblStockLocation";
            this.lblStockLocation.Size = new System.Drawing.Size(160, 25);
            this.lblStockLocation.TabIndex = 36;
            // 
            // listInitInputLog
            // 
            this.listInitInputLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listInitInputLog.FormattingEnabled = true;
            this.listInitInputLog.Location = new System.Drawing.Point(14, 450);
            this.listInitInputLog.Margin = new System.Windows.Forms.Padding(6);
            this.listInitInputLog.Name = "listInitInputLog";
            this.listInitInputLog.Size = new System.Drawing.Size(1074, 354);
            this.listInitInputLog.TabIndex = 44;
            // 
            // btnClearInitInputLog
            // 
            this.btnClearInitInputLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearInitInputLog.Location = new System.Drawing.Point(942, 887);
            this.btnClearInitInputLog.Margin = new System.Windows.Forms.Padding(6);
            this.btnClearInitInputLog.Name = "btnClearInitInputLog";
            this.btnClearInitInputLog.Size = new System.Drawing.Size(150, 44);
            this.btnClearInitInputLog.TabIndex = 45;
            this.btnClearInitInputLog.Text = "Clear";
            this.btnClearInitInputLog.UseVisualStyleBackColor = true;
            this.btnClearInitInputLog.Click += new System.EventHandler(this.btnClearInitInputLog_Click);
            // 
            // txtConfiguration
            // 
            this.txtConfiguration.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtConfiguration.Location = new System.Drawing.Point(12, 90);
            this.txtConfiguration.Margin = new System.Windows.Forms.Padding(6);
            this.txtConfiguration.Multiline = true;
            this.txtConfiguration.Name = "txtConfiguration";
            this.txtConfiguration.ReadOnly = true;
            this.txtConfiguration.Size = new System.Drawing.Size(1074, 260);
            this.txtConfiguration.TabIndex = 42;
            // 
            // lblConfiguration
            // 
            this.lblConfiguration.AutoSize = true;
            this.lblConfiguration.Location = new System.Drawing.Point(6, 52);
            this.lblConfiguration.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblConfiguration.Name = "lblConfiguration";
            this.lblConfiguration.Size = new System.Drawing.Size(304, 25);
            this.lblConfiguration.TabIndex = 41;
            // 
            // btnGetConfig
            // 
            this.btnGetConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGetConfig.Location = new System.Drawing.Point(942, 363);
            this.btnGetConfig.Margin = new System.Windows.Forms.Padding(6);
            this.btnGetConfig.Name = "btnGetConfig";
            this.btnGetConfig.Size = new System.Drawing.Size(150, 44);
            this.btnGetConfig.TabIndex = 43;
            this.btnGetConfig.Text = "Get";
            this.btnGetConfig.UseVisualStyleBackColor = true;
            this.btnGetConfig.Click += new System.EventHandler(this.btnGetConfig_Click);
            // 
            // checkAllowDeliveryInput
            // 
            this.checkAllowDeliveryInput.AutoSize = true;
            this.checkAllowDeliveryInput.Checked = true;
            this.checkAllowDeliveryInput.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkAllowDeliveryInput.Location = new System.Drawing.Point(34, 56);
            this.checkAllowDeliveryInput.Margin = new System.Windows.Forms.Padding(6);
            this.checkAllowDeliveryInput.Name = "checkAllowDeliveryInput";
            this.checkAllowDeliveryInput.Size = new System.Drawing.Size(274, 29);
            this.checkAllowDeliveryInput.TabIndex = 10;
            this.checkAllowDeliveryInput.Text = "Allow NewDelivery Input";
            this.checkAllowDeliveryInput.UseVisualStyleBackColor = true;
            // 
            // checkEnforceBatchStockReturn
            // 
            this.checkEnforceBatchStockReturn.AutoSize = true;
            this.checkEnforceBatchStockReturn.Location = new System.Drawing.Point(34, 365);
            this.checkEnforceBatchStockReturn.Margin = new System.Windows.Forms.Padding(6);
            this.checkEnforceBatchStockReturn.Name = "checkEnforceBatchStockReturn";
            this.checkEnforceBatchStockReturn.Size = new System.Drawing.Size(415, 29);
            this.checkEnforceBatchStockReturn.TabIndex = 17;
            this.checkEnforceBatchStockReturn.Text = "Enforce BatchNumber for Stock Return";
            this.checkEnforceBatchStockReturn.UseVisualStyleBackColor = true;
            // 
            // checkEnforceBatchDelivery
            // 
            this.checkEnforceBatchDelivery.AutoSize = true;
            this.checkEnforceBatchDelivery.Location = new System.Drawing.Point(34, 410);
            this.checkEnforceBatchDelivery.Margin = new System.Windows.Forms.Padding(6);
            this.checkEnforceBatchDelivery.Name = "checkEnforceBatchDelivery";
            this.checkEnforceBatchDelivery.Size = new System.Drawing.Size(417, 29);
            this.checkEnforceBatchDelivery.TabIndex = 18;
            this.checkEnforceBatchDelivery.Text = "Enforce BatchNumber for New Delivery";
            this.checkEnforceBatchDelivery.UseVisualStyleBackColor = true;
            // 
            // checkEnforceExpiryDateStockReturn
            // 
            this.checkEnforceExpiryDateStockReturn.AutoSize = true;
            this.checkEnforceExpiryDateStockReturn.Location = new System.Drawing.Point(34, 277);
            this.checkEnforceExpiryDateStockReturn.Margin = new System.Windows.Forms.Padding(6);
            this.checkEnforceExpiryDateStockReturn.Name = "checkEnforceExpiryDateStockReturn";
            this.checkEnforceExpiryDateStockReturn.Size = new System.Drawing.Size(396, 29);
            this.checkEnforceExpiryDateStockReturn.TabIndex = 15;
            this.checkEnforceExpiryDateStockReturn.Text = "Enforce Expiry Date for Stock Return";
            this.checkEnforceExpiryDateStockReturn.UseVisualStyleBackColor = true;
            // 
            // checkEnforceExpiryDateDelivery
            // 
            this.checkEnforceExpiryDateDelivery.AutoSize = true;
            this.checkEnforceExpiryDateDelivery.Location = new System.Drawing.Point(34, 321);
            this.checkEnforceExpiryDateDelivery.Margin = new System.Windows.Forms.Padding(6);
            this.checkEnforceExpiryDateDelivery.Name = "checkEnforceExpiryDateDelivery";
            this.checkEnforceExpiryDateDelivery.Size = new System.Drawing.Size(398, 29);
            this.checkEnforceExpiryDateDelivery.TabIndex = 16;
            this.checkEnforceExpiryDateDelivery.Text = "Enforce Expiry Date for New Delivery";
            this.checkEnforceExpiryDateDelivery.UseVisualStyleBackColor = true;
            // 
            // checkAllowStockReturnInput
            // 
            this.checkAllowStockReturnInput.AutoSize = true;
            this.checkAllowStockReturnInput.Checked = true;
            this.checkAllowStockReturnInput.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkAllowStockReturnInput.Location = new System.Drawing.Point(34, 100);
            this.checkAllowStockReturnInput.Margin = new System.Windows.Forms.Padding(6);
            this.checkAllowStockReturnInput.Name = "checkAllowStockReturnInput";
            this.checkAllowStockReturnInput.Size = new System.Drawing.Size(278, 29);
            this.checkAllowStockReturnInput.TabIndex = 11;
            this.checkAllowStockReturnInput.Text = "Allow Stock Return Input";
            this.checkAllowStockReturnInput.UseVisualStyleBackColor = true;
            // 
            // checkOnlyFridgeInput
            // 
            this.checkOnlyFridgeInput.AutoSize = true;
            this.checkOnlyFridgeInput.Location = new System.Drawing.Point(34, 144);
            this.checkOnlyFridgeInput.Margin = new System.Windows.Forms.Padding(6);
            this.checkOnlyFridgeInput.Name = "checkOnlyFridgeInput";
            this.checkOnlyFridgeInput.Size = new System.Drawing.Size(296, 29);
            this.checkOnlyFridgeInput.TabIndex = 12;
            this.checkOnlyFridgeInput.Text = "Allow Input Only for Fridge";
            this.checkOnlyFridgeInput.UseVisualStyleBackColor = true;
            // 
            // checkEnforcePickingIndicator
            // 
            this.checkEnforcePickingIndicator.AutoSize = true;
            this.checkEnforcePickingIndicator.Location = new System.Drawing.Point(34, 233);
            this.checkEnforcePickingIndicator.Margin = new System.Windows.Forms.Padding(6);
            this.checkEnforcePickingIndicator.Name = "checkEnforcePickingIndicator";
            this.checkEnforcePickingIndicator.Size = new System.Drawing.Size(282, 29);
            this.checkEnforcePickingIndicator.TabIndex = 14;
            this.checkEnforcePickingIndicator.Text = "Enforce Picking Indicator";
            this.checkEnforcePickingIndicator.UseVisualStyleBackColor = true;
            // 
            // checkSetSubItemQuantity
            // 
            this.checkSetSubItemQuantity.AutoSize = true;
            this.checkSetSubItemQuantity.Location = new System.Drawing.Point(34, 627);
            this.checkSetSubItemQuantity.Margin = new System.Windows.Forms.Padding(6);
            this.checkSetSubItemQuantity.Name = "checkSetSubItemQuantity";
            this.checkSetSubItemQuantity.Size = new System.Drawing.Size(281, 29);
            this.checkSetSubItemQuantity.TabIndex = 21;
            this.checkSetSubItemQuantity.Text = "Set MaxSubItemQuantity";
            this.checkSetSubItemQuantity.UseVisualStyleBackColor = true;
            // 
            // checkEnforceLocationStockReturn
            // 
            this.checkEnforceLocationStockReturn.AutoSize = true;
            this.checkEnforceLocationStockReturn.Location = new System.Drawing.Point(34, 454);
            this.checkEnforceLocationStockReturn.Margin = new System.Windows.Forms.Padding(6);
            this.checkEnforceLocationStockReturn.Name = "checkEnforceLocationStockReturn";
            this.checkEnforceLocationStockReturn.Size = new System.Drawing.Size(421, 29);
            this.checkEnforceLocationStockReturn.TabIndex = 19;
            this.checkEnforceLocationStockReturn.Text = "Enforce StockLocation for Stock Return";
            this.checkEnforceLocationStockReturn.UseVisualStyleBackColor = true;
            // 
            // checkEnforceLocationNewDelivery
            // 
            this.checkEnforceLocationNewDelivery.AutoSize = true;
            this.checkEnforceLocationNewDelivery.Location = new System.Drawing.Point(34, 498);
            this.checkEnforceLocationNewDelivery.Margin = new System.Windows.Forms.Padding(6);
            this.checkEnforceLocationNewDelivery.Name = "checkEnforceLocationNewDelivery";
            this.checkEnforceLocationNewDelivery.Size = new System.Drawing.Size(423, 29);
            this.checkEnforceLocationNewDelivery.TabIndex = 20;
            this.checkEnforceLocationNewDelivery.Text = "Enforce StockLocation for New Delivery";
            this.checkEnforceLocationNewDelivery.UseVisualStyleBackColor = true;
            // 
            // numExpiryDateMonth
            // 
            this.numExpiryDateMonth.Location = new System.Drawing.Point(330, 852);
            this.numExpiryDateMonth.Margin = new System.Windows.Forms.Padding(6);
            this.numExpiryDateMonth.Name = "numExpiryDateMonth";
            this.numExpiryDateMonth.Size = new System.Drawing.Size(132, 31);
            this.numExpiryDateMonth.TabIndex = 25;
            this.numExpiryDateMonth.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            // 
            // lblDefExpiryDate
            // 
            this.lblDefExpiryDate.AutoSize = true;
            this.lblDefExpiryDate.Location = new System.Drawing.Point(28, 856);
            this.lblDefExpiryDate.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblDefExpiryDate.Name = "lblDefExpiryDate";
            this.lblDefExpiryDate.Size = new System.Drawing.Size(287, 25);
            this.lblDefExpiryDate.TabIndex = 24;
            // 
            // checkOverwriteStockLocation
            // 
            this.checkOverwriteStockLocation.AutoSize = true;
            this.checkOverwriteStockLocation.Location = new System.Drawing.Point(34, 715);
            this.checkOverwriteStockLocation.Margin = new System.Windows.Forms.Padding(6);
            this.checkOverwriteStockLocation.Name = "checkOverwriteStockLocation";
            this.checkOverwriteStockLocation.Size = new System.Drawing.Size(283, 29);
            this.checkOverwriteStockLocation.TabIndex = 22;
            this.checkOverwriteStockLocation.Text = "Overwrite Stock Location";
            this.checkOverwriteStockLocation.UseVisualStyleBackColor = true;
            this.checkOverwriteStockLocation.CheckedChanged += new System.EventHandler(this.checkOverwriteStockLocation_CheckedChanged);
            // 
            // txtOverwriteStockLocation
            // 
            this.txtOverwriteStockLocation.Enabled = false;
            this.txtOverwriteStockLocation.Location = new System.Drawing.Point(70, 762);
            this.txtOverwriteStockLocation.Margin = new System.Windows.Forms.Padding(6);
            this.txtOverwriteStockLocation.Name = "txtOverwriteStockLocation";
            this.txtOverwriteStockLocation.Size = new System.Drawing.Size(384, 31);
            this.txtOverwriteStockLocation.TabIndex = 23;
            // 
            // checkOnlyArticlesFromList
            // 
            this.checkOnlyArticlesFromList.AutoSize = true;
            this.checkOnlyArticlesFromList.Location = new System.Drawing.Point(34, 188);
            this.checkOnlyArticlesFromList.Margin = new System.Windows.Forms.Padding(6);
            this.checkOnlyArticlesFromList.Name = "checkOnlyArticlesFromList";
            this.checkOnlyArticlesFromList.Size = new System.Drawing.Size(393, 29);
            this.checkOnlyArticlesFromList.TabIndex = 13;
            this.checkOnlyArticlesFromList.Text = "Allow Only Articles From Articles.csv";
            this.checkOnlyArticlesFromList.UseVisualStyleBackColor = true;
            // 
            // checkBoxSetVirtualArticle
            // 
            this.checkBoxSetVirtualArticle.AutoSize = true;
            this.checkBoxSetVirtualArticle.Location = new System.Drawing.Point(34, 671);
            this.checkBoxSetVirtualArticle.Margin = new System.Windows.Forms.Padding(6);
            this.checkBoxSetVirtualArticle.Name = "checkBoxSetVirtualArticle";
            this.checkBoxSetVirtualArticle.Size = new System.Drawing.Size(209, 29);
            this.checkBoxSetVirtualArticle.TabIndex = 26;
            this.checkBoxSetVirtualArticle.Text = "Set Virtual Article";
            this.checkBoxSetVirtualArticle.UseVisualStyleBackColor = true;
            // 
            // checkEnforceSerialNumberStockReturn
            // 
            this.checkEnforceSerialNumberStockReturn.AutoSize = true;
            this.checkEnforceSerialNumberStockReturn.Location = new System.Drawing.Point(34, 540);
            this.checkEnforceSerialNumberStockReturn.Margin = new System.Windows.Forms.Padding(6);
            this.checkEnforceSerialNumberStockReturn.Name = "checkEnforceSerialNumberStockReturn";
            this.checkEnforceSerialNumberStockReturn.Size = new System.Drawing.Size(415, 29);
            this.checkEnforceSerialNumberStockReturn.TabIndex = 27;
            this.checkEnforceSerialNumberStockReturn.Text = "Enforce SerialNumber for Stock Return";
            this.checkEnforceSerialNumberStockReturn.UseVisualStyleBackColor = true;
            // 
            // checkEnforceSerialNumberNewDelivery
            // 
            this.checkEnforceSerialNumberNewDelivery.AutoSize = true;
            this.checkEnforceSerialNumberNewDelivery.Location = new System.Drawing.Point(34, 585);
            this.checkEnforceSerialNumberNewDelivery.Margin = new System.Windows.Forms.Padding(6);
            this.checkEnforceSerialNumberNewDelivery.Name = "checkEnforceSerialNumberNewDelivery";
            this.checkEnforceSerialNumberNewDelivery.Size = new System.Drawing.Size(417, 29);
            this.checkEnforceSerialNumberNewDelivery.TabIndex = 28;
            this.checkEnforceSerialNumberNewDelivery.Text = "Enforce SerialNumber for New Delivery";
            this.checkEnforceSerialNumberNewDelivery.UseVisualStyleBackColor = true;
            // 
            // listInputLog
            // 
            this.listInputLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listInputLog.FormattingEnabled = true;
            this.listInputLog.Location = new System.Drawing.Point(14, 38);
            this.listInputLog.Margin = new System.Windows.Forms.Padding(6);
            this.listInputLog.Name = "listInputLog";
            this.listInputLog.Size = new System.Drawing.Size(1374, 754);
            this.listInputLog.TabIndex = 27;
            // 
            // btnClearInputLog
            // 
            this.btnClearInputLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearInputLog.Location = new System.Drawing.Point(1242, 887);
            this.btnClearInputLog.Margin = new System.Windows.Forms.Padding(6);
            this.btnClearInputLog.Name = "btnClearInputLog";
            this.btnClearInputLog.Size = new System.Drawing.Size(150, 44);
            this.btnClearInputLog.TabIndex = 28;
            this.btnClearInputLog.Text = "Clear";
            this.btnClearInputLog.UseVisualStyleBackColor = true;
            this.btnClearInputLog.Click += new System.EventHandler(this.btnClearInputLog_Click);
            // 
            // dataGridPacks
            // 
            this.dataGridPacks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridPacks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridPacks.Location = new System.Drawing.Point(0, 0);
            this.dataGridPacks.Margin = new System.Windows.Forms.Padding(6);
            this.dataGridPacks.Name = "dataGridPacks";
            this.dataGridPacks.RowHeadersWidth = 82;
            this.dataGridPacks.Size = new System.Drawing.Size(1936, 473);
            this.dataGridPacks.TabIndex = 11;
            // 
            // dataGridArticles
            // 
            this.dataGridArticles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridArticles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridArticles.Location = new System.Drawing.Point(0, 0);
            this.dataGridArticles.Margin = new System.Windows.Forms.Padding(6);
            this.dataGridArticles.Name = "dataGridArticles";
            this.dataGridArticles.RowHeadersWidth = 82;
            this.dataGridArticles.Size = new System.Drawing.Size(1936, 406);
            this.dataGridArticles.TabIndex = 10;
            // 
            // openStockDeliveryFileDialog
            // 
            this.openStockDeliveryFileDialog.FileName = "sampleDeliveryMaster.csv";
            this.openStockDeliveryFileDialog.Filter = "Delivery Files|*.csv|All files|*.*";
            this.openStockDeliveryFileDialog.Title = "Select the Stock Delivery Import File";
            // 
            // FMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1992, 1273);
            this.Controls.Add(this.tabControlMain);
            this.Controls.Add(this.statusStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "FMain";
            this.Text = "IT-System Simulator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FMain_FormClosing);
            this.Load += new System.EventHandler(this.FMain_Load);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPort)).EndInit();
            this.groupConnection.ResumeLayout(false);
            this.groupConnection.PerformLayout();
            this.tabControlStorageSystem.ResumeLayout(false);
            this.tabStockDeliveries.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDeliveryItems)).EndInit();
            this.tabControlMain.ResumeLayout(false);
            this.tabPageStorageSystem.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDigitalShelfPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxSubItemQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridStockLocations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridComponents)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridArticleInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPackInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridMasterArticles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridOrderItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridItemLabels)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDispensedPacks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridOrders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridOrderBoxes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numInitInputID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numInputSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPackSubItemQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPackDepth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPackWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPackHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numInputPoint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDestination)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numExpiryDateMonth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPacks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridArticles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.NumericUpDown numPort;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.GroupBox groupConnection;
        private System.Windows.Forms.TabControl tabControlStorageSystem;
        private System.Windows.Forms.TabPage tabStockDeliveries;
        private System.Windows.Forms.Button btnSendStockDeliveries;
        private System.Windows.Forms.ToolStripStatusLabel lblStorageSystemStatus;     
        private System.Windows.Forms.DataGridView dataGridDeliveryItems;
        private System.Windows.Forms.CheckBox checkAutomaticStateObservation;
        private System.Windows.Forms.TextBox txtTenantId;
        private System.Windows.Forms.Label lblTenantId;
        private System.Windows.Forms.OpenFileDialog openArticleFileDialog;
        private System.Windows.Forms.Button btnDisconnect;
        private System.ComponentModel.BackgroundWorker bgInitInput;
        private System.ComponentModel.BackgroundWorker backgroundWorkerConnectDigitalShelf;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPageStorageSystem;
        private System.Windows.Forms.CheckBox checkAutoConnect;
        private System.ComponentModel.BackgroundWorker bgConnect;
        private System.ComponentModel.BackgroundWorker bgStock;
        private System.Windows.Forms.TextBox textBoxDigitalShelfAddress;
        private System.Windows.Forms.NumericUpDown numericUpDownDigitalShelfPort;
        private System.Windows.Forms.Button buttonDigitalShelfConnect;
        private System.Windows.Forms.Button buttonDigitalShelfDisconnect;
        private System.Windows.Forms.TabPage tabRawXmlDigitalShelf;
        private System.Windows.Forms.GroupBox groupRawXmlDigitalShelf;
        private System.Windows.Forms.RichTextBox txtRawXmlDigitalShelf;
        private System.Windows.Forms.Button btnSendRawXmlDigitalShelf;
        private System.Windows.Forms.Button btnClearRawXmlDigitalShelf;
        private System.Windows.Forms.TabPage tabPageShoppingCartRequested;
        private System.Windows.Forms.TabControl tabControlShoppingCart;
        private System.Windows.Forms.TabPage tabPageUpdate;
        private System.Windows.Forms.GroupBox groupBoxShoppingCartInfo;
        private System.Windows.Forms.Label labelShoppingCartInfoStatus;
        private System.Windows.Forms.Label labelShoppingCartInfoSalesPersonID;
        private System.Windows.Forms.Label labelShoppingCartInfoCustomerID;
        private System.Windows.Forms.Label labelShoppingCartInfoSalesPointID;
        private System.Windows.Forms.Label labelShoppingCartInfoViewPointID;
        private System.Windows.Forms.Label labelShoppingCartInfoID;
        private System.Windows.Forms.ComboBox comboBoxShoppingCartInfoStatus;
        private System.Windows.Forms.TextBox textBoxShoppingCartInfoViewPointID;
        private System.Windows.Forms.TextBox textBoxShoppingCartInfoSalesPointID;
        private System.Windows.Forms.TextBox textBoxShoppingCartInfoSalesPersonID;
        private System.Windows.Forms.TextBox textBoxShoppingCartInfoCustomerID;
        private System.Windows.Forms.TextBox textBoxShoppingCartInfoID;
        private System.Windows.Forms.GroupBox groupBoxShoppingCartUpdateHandling;
        private System.Windows.Forms.Label labelShoppingCartUpdateHandlingManuel;
        private System.Windows.Forms.Label labelShoppingCartUpdateHandlingAuto;
        private System.Windows.Forms.Button buttonShoppingCartUpdateAutoAccept;
        private System.Windows.Forms.Button buttonShoppingCartUpdateAutoReject;
        private System.Windows.Forms.TextBox textBoxShoppingCartUpdateHandlingDescription;
        private System.Windows.Forms.Label labelShoppingCartUpdateHandlingDescription;
        private System.Windows.Forms.RadioButton radioButtonShoppingCartUpdateAutoAccept;
        private System.Windows.Forms.RadioButton radioButtonShoppingCartUpdateAutoReject;
        private System.Windows.Forms.RadioButton radioButtonShoppingCartUpdateAutoManual;
        private System.Windows.Forms.GroupBox groupBoxShoppingCartItemsForUpdate;
        private System.Windows.Forms.ListView listViewShoppingCartItemsForUpdate;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.TabPage tabPageRequest;
        private System.Windows.Forms.GroupBox groupBoxShoppingCartRequest;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Label labelSalesPersonId;
        private System.Windows.Forms.Label labelCustomerId;
        private System.Windows.Forms.Label labelSalesPointId;
        private System.Windows.Forms.ComboBox comboBoxShoppingCartStatus;
        private System.Windows.Forms.Label labelViewPointId;
        private System.Windows.Forms.TextBox textBoxShoppingCartViewPointID;
        private System.Windows.Forms.RadioButton radioButtonShoppingCartAccept;
        private System.Windows.Forms.TextBox textBoxShoppingCartSalesPointID;
        private System.Windows.Forms.RadioButton radioButtonShoppingCartReject;
        private System.Windows.Forms.TextBox textBoxShoppingCartSalesPersonId;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBoxShoppingCartCustomerID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBoxShoppingCartItemsForRequest;
        private System.Windows.Forms.ListView listViewShoppingCartItemsForRequest;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.Button buttonAddShoppingCartItem;
        private System.Windows.Forms.Button buttonRemoveShoppingCartItem;
        private System.Windows.Forms.TabPage tabPagePriceInformation;
        private System.Windows.Forms.GroupBox groupBoxPriceInformation;
        private System.Windows.Forms.ListBox listBoxPriceInformation;
        private System.Windows.Forms.Button buttonAddPriceInformation;
        private System.Windows.Forms.Button buttonRemovePriceInformation;
        private System.Windows.Forms.CheckBox checkBoxPriceInformationAutoGenerate;
        private System.Windows.Forms.TabPage tabPageArticleInfo;
        private System.Windows.Forms.GroupBox groupBoxCrossSellingArticle;
        private System.Windows.Forms.ListBox listBoxCrossSellingArticle;
        private System.Windows.Forms.Button buttonAddCrossSellingArticle;
        private System.Windows.Forms.Button buttonRemoveCrossSellingArticle;
        private System.Windows.Forms.CheckBox checkBoxCrossSellingArticleAutoGenerate;
        private System.Windows.Forms.GroupBox groupBoxAlternativeArticle;
        private System.Windows.Forms.ListBox listBoxAlternativeArticle;
        private System.Windows.Forms.Button buttonAddAlternativeArticle;
        private System.Windows.Forms.Button buttonRemoveAlternativeArticle;
        private System.Windows.Forms.CheckBox checkBoxAlternativeArticlesAutoGenerate;
        private System.Windows.Forms.GroupBox groupBoxAlternativePackSizeArticle;
        private System.Windows.Forms.ListBox listBoxAlternativePackSizeArticle;
        private System.Windows.Forms.Button buttonAddAlternativePackSizeArticle;
        private System.Windows.Forms.Button buttonRemoveAlternativePackSizeArticle;
        private System.Windows.Forms.CheckBox checkBoxAlternativePackSizeAutoGenerated;
        private System.Windows.Forms.GroupBox groupBoxTag;
        private System.Windows.Forms.ListBox listBoxTag;
        private System.Windows.Forms.Button buttonAddTag;
        private System.Windows.Forms.Button buttonRemoveTag;
        private System.Windows.Forms.CheckBox checkBoxTagAutoGenerate;
        private System.Windows.Forms.GroupBox groupBoxArticleInformation;
        private System.Windows.Forms.CheckBox checkBoxArticleInformationAutoGenerate;
        private System.Windows.Forms.TextBox textBoxArticleName;
        private System.Windows.Forms.Label labelArticleName;
        private System.Windows.Forms.Label labelDosageForm;
        private System.Windows.Forms.TextBox textBoxDosageForm;
        private System.Windows.Forms.Label labelPackagingUnit;
        private System.Windows.Forms.TextBox textBoxPackagingUnit;
        private System.Windows.Forms.Label labelMaxSubItemQuantity;
        private System.Windows.Forms.NumericUpDown numericUpDownMaxSubItemQuantity;
        private System.Windows.Forms.TabPage tabPageLog;
        private System.Windows.Forms.ListBox listBoxDigitalShelfLog;
        private System.Windows.Forms.Button buttonClearDigitalShelfLog;
        private System.Windows.Forms.Button btnSendRawXml;
        private System.Windows.Forms.Button btnClearRawXml;
        private System.Windows.Forms.RichTextBox txtRawXml;
        private System.Windows.Forms.Button btnReloadStockLocations;
        private System.Windows.Forms.DataGridView dataGridStockLocations;
        private System.Windows.Forms.Button btnReloadComponents;
        private System.Windows.Forms.DataGridView dataGridComponents;
        private System.Windows.Forms.DataGridView dataGridArticleInfo;
        private System.Windows.Forms.DataGridView dataGridPackInfo;
        private System.Windows.Forms.Label lblTaskID;
        private System.Windows.Forms.TextBox txtTaskID;
        private System.Windows.Forms.Label lblTaskType;
        private System.Windows.Forms.ComboBox cmbTaskType;
        private System.Windows.Forms.Label lblTaskStateDesc;
        private System.Windows.Forms.Label lblTaskState;
        private System.Windows.Forms.Button btnGetTaskInfo;
        private System.Windows.Forms.DataGridView dataGridMasterArticles;
        private System.Windows.Forms.DataGridView dataGridOrderItems;
        private System.Windows.Forms.DataGridView dataGridItemLabels;
        private System.Windows.Forms.DataGridView dataGridDispensedPacks;
        private System.Windows.Forms.DataGridView dataGridOrders;
        private System.Windows.Forms.Button btnNewOrder;
        private System.Windows.Forms.Button btnSendOrder;
        private System.Windows.Forms.Button btnCancelOrder;
        private System.Windows.Forms.Button btnClearOrders;
        private System.Windows.Forms.Button btnBulkOrder;
        private System.Windows.Forms.DataGridView dataGridOrderBoxes;
        private System.Windows.Forms.CheckBox chkSetPickingIndicator;
        private System.Windows.Forms.Label lblInitInputID;
        private System.Windows.Forms.TextBox txtDeliveryNumber;
        private System.Windows.Forms.NumericUpDown numInitInputID;
        private System.Windows.Forms.Label lblDeliveryNumber;
        private System.Windows.Forms.Label lblInputSource;
        private System.Windows.Forms.NumericUpDown numInputSource;
        private System.Windows.Forms.TextBox txtPackScanCode;
        private System.Windows.Forms.Label lblPackScanCode;
        private System.Windows.Forms.TextBox txtPackBatchNumber;
        private System.Windows.Forms.Label lblPackBatchNumber;
        private System.Windows.Forms.TextBox txtPackExpiryDate;
        private System.Windows.Forms.Label lblPackExpiryDate;
        private System.Windows.Forms.Label lblPackSubItemQuantity;
        private System.Windows.Forms.NumericUpDown numPackSubItemQuantity;
        private System.Windows.Forms.Label lblPackDepth;
        private System.Windows.Forms.NumericUpDown numPackDepth;
        private System.Windows.Forms.Label lblPackWidth;
        private System.Windows.Forms.NumericUpDown numPackWidth;
        private System.Windows.Forms.Label lblPackHeight;
        private System.Windows.Forms.NumericUpDown numPackHeight;
        private System.Windows.Forms.Label lblPackShape;
        private System.Windows.Forms.ComboBox cmbPackShape;
        private System.Windows.Forms.Button btnSendInitInputRequest;
        private System.Windows.Forms.Label lblInputPoint;
        private System.Windows.Forms.NumericUpDown numInputPoint;
        private System.Windows.Forms.Label lblDestination;
        private System.Windows.Forms.NumericUpDown numDestination;
        private System.Windows.Forms.TextBox txtPackStockLocation;
        private System.Windows.Forms.Label lblStockLocation;
        private System.Windows.Forms.ListBox listInitInputLog;
        private System.Windows.Forms.Button btnClearInitInputLog;
        private System.Windows.Forms.TextBox txtConfiguration;
        private System.Windows.Forms.Label lblConfiguration;
        private System.Windows.Forms.Button btnGetConfig;
        private System.Windows.Forms.CheckBox checkAllowDeliveryInput;
        private System.Windows.Forms.CheckBox checkEnforceBatchStockReturn;
        private System.Windows.Forms.CheckBox checkEnforceBatchDelivery;
        private System.Windows.Forms.CheckBox checkEnforceExpiryDateStockReturn;
        private System.Windows.Forms.CheckBox checkEnforceExpiryDateDelivery;
        private System.Windows.Forms.CheckBox checkAllowStockReturnInput;
        private System.Windows.Forms.CheckBox checkOnlyFridgeInput;
        private System.Windows.Forms.CheckBox checkEnforcePickingIndicator;
        private System.Windows.Forms.CheckBox checkSetSubItemQuantity;
        private System.Windows.Forms.CheckBox checkEnforceLocationStockReturn;
        private System.Windows.Forms.CheckBox checkEnforceLocationNewDelivery;
        private System.Windows.Forms.NumericUpDown numExpiryDateMonth;
        private System.Windows.Forms.Label lblDefExpiryDate;
        private System.Windows.Forms.CheckBox checkOverwriteStockLocation;
        private System.Windows.Forms.TextBox txtOverwriteStockLocation;
        private System.Windows.Forms.CheckBox checkOnlyArticlesFromList;
        private System.Windows.Forms.CheckBox checkBoxSetVirtualArticle;
        private System.Windows.Forms.CheckBox checkEnforceSerialNumberStockReturn;
        private System.Windows.Forms.CheckBox checkEnforceSerialNumberNewDelivery;
        private System.Windows.Forms.ListBox listInputLog;
        private System.Windows.Forms.Button btnClearInputLog;
        private System.Windows.Forms.DataGridView dataGridPacks;
        private System.Windows.Forms.DataGridView dataGridArticles;
        private System.Windows.Forms.Button btnImportStockDeliveries;
        private System.Windows.Forms.OpenFileDialog openStockDeliveryFileDialog;
    }
}

