namespace StorageSystemSimulator
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.buttonClearSavedState = new System.Windows.Forms.Button();
            this.buttonSaveSimulatorState = new System.Windows.Forms.Button();
            this.groupBox15 = new System.Windows.Forms.GroupBox();
            this.dataGridViewStockLocationList = new System.Windows.Forms.DataGridView();
            this.ColumnStockLocationId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStockLocationDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox14 = new System.Windows.Forms.GroupBox();
            this.dataGridViewTenantList = new System.Windows.Forms.DataGridView();
            this.ColumnTenantID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTenantDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBoxUseExternalIdAsSerialNumber = new System.Windows.Forms.CheckBox();
            this.numericUpDownSubscriberID = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownKeepAliveTimeout = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.numericUpDownKeepAliveInterval = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBoxEnableKeepAlive = new System.Windows.Forms.CheckBox();
            this.numericUpDownHandShakeTimeOut = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDownPort = new System.Windows.Forms.NumericUpDown();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listViewConnections = new System.Windows.Forms.ListView();
            this.columnHeaderEndpoint = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderHandshake = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderSubscriberID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderTenant = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.buttonRemoveComponent = new System.Windows.Forms.Button();
            this.buttonAddComponent = new System.Windows.Forms.Button();
            this.listViewStatusComponent = new System.Windows.Forms.ListView();
            this.columnHeaderType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderState = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderStateText = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.textBoxStatusText = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.NotReady = new System.Windows.Forms.RadioButton();
            this.radioButtonReady = new System.Windows.Forms.RadioButton();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.groupBox13 = new System.Windows.Forms.GroupBox();
            this.checkBoxAcceptFridge = new System.Windows.Forms.CheckBox();
            this.buttonInputMessageNotLoad = new System.Windows.Forms.Button();
            this.buttonInputMessageLoad = new System.Windows.Forms.Button();
            this.checkBoxInputMessageAuto = new System.Windows.Forms.CheckBox();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.listViewScannedPackInformation = new System.Windows.Forms.ListView();
            this.columnHeaderIndex = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderDosageForm = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderPackagingUnit = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderMaxSubItemQuantity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderBatchNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderExpiryDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderExternalID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderSubItemQuantity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderStockLocation = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderIsInFridge = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderHandingInput = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderHandlingText = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.checkBoxIsDeliveryInput = new System.Windows.Forms.CheckBox();
            this.labelSelectInputLocation = new System.Windows.Forms.Label();
            this.comboBoxInputSelectLocation = new System.Windows.Forms.ComboBox();
            this.labelSelectInputTenant = new System.Windows.Forms.Label();
            this.comboBoxInputSelectTenant = new System.Windows.Forms.ComboBox();
            this.checkBoxSetPickingIndicator = new System.Windows.Forms.CheckBox();
            this.buttonScanPack = new System.Windows.Forms.Button();
            this.dataGridViewInputRequestPackList = new System.Windows.Forms.DataGridView();
            this.ColumnDeliveryNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnScanCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnBatchNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnExpiryDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnHidenExpiryDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnExternalID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSubItemQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnShape = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSelectShape = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnMachineLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.groupBox17 = new System.Windows.Forms.GroupBox();
            this.radioButtonInitiateInputReject = new System.Windows.Forms.RadioButton();
            this.radioButtonInitiateInputAccept = new System.Windows.Forms.RadioButton();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.groupBox35 = new System.Windows.Forms.GroupBox();
            this.dateTimePickerMasterDataExpiryDate = new System.Windows.Forms.DateTimePicker();
            this.numericUpDownMasterDataMachineLocation = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.numericUpDownSubItemQuantity = new System.Windows.Forms.NumericUpDown();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.textBoxMasterDataExternalID = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.textBoxMasterDataBatchNumber = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.labelSelectMasterDataLocation = new System.Windows.Forms.Label();
            this.comboBoxMasterDataSelectLocation = new System.Windows.Forms.ComboBox();
            this.labelSelectMasterDataTenant = new System.Windows.Forms.Label();
            this.comboBoxMasterDataSelectTenant = new System.Windows.Forms.ComboBox();
            this.groupBox20 = new System.Windows.Forms.GroupBox();
            this.dataGridViewMasterArticle = new System.Windows.Forms.DataGridView();
            this.dataGridViewMasterArticleLoadPack = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox19 = new System.Windows.Forms.GroupBox();
            this.textBoxMasterArticleText = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.radioButtonMasterArticleReject = new System.Windows.Forms.RadioButton();
            this.radioButtonMasterArticleAccept = new System.Windows.Forms.RadioButton();
            this.tabPage11 = new System.Windows.Forms.TabPage();
            this.groupBox22 = new System.Windows.Forms.GroupBox();
            this.dataGridViewStockDeliveryDetail = new System.Windows.Forms.DataGridView();
            this.ColumnStockDeliveryLoadPack = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnStockDeliveryPackCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStockDeliveryProcessedQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStockDeliveryBatchNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStockDeliveryExternalID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStockDeliveryExpiryDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewStockDeliveryMaster = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStockDeliveryMasterState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStockDeliveryMasterComplete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.groupBox23 = new System.Windows.Forms.GroupBox();
            this.textBoxStockDeliveryText = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.radioButtonStockDeliveryReject = new System.Windows.Forms.RadioButton();
            this.radioButtonStockDeliveryAccept = new System.Windows.Forms.RadioButton();
            this.tabPage9 = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.groupBox18 = new System.Windows.Forms.GroupBox();
            this.listViewArticleInfoRequested = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox21 = new System.Windows.Forms.GroupBox();
            this.dataGridViewArticleInfoArticleList = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn32 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn33 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn34 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn35 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn36 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labelArticleInfoSelectTenant = new System.Windows.Forms.Label();
            this.comboBoxArticleInfoSelectTenant = new System.Windows.Forms.ComboBox();
            this.buttonSendArticleInfoRequest = new System.Windows.Forms.Button();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.groupBox25 = new System.Windows.Forms.GroupBox();
            this.splitContainerStock = new System.Windows.Forms.SplitContainer();
            this.dataGridViewProductStock = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumnStockListCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumnStockListName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumnStockListDosageForm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumnStockListPackagingUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumnStockListMaxSubItemQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumnStockListPackCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSendStockInfoMessage = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewPackStock = new System.Windows.Forms.DataGridView();
            this.ColumnStockOutputPack = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnStockDeletePack = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewTextBoxColumn18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn20 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn21 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn22 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn23 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn24 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn25 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStockStockLocationID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStockMachineLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStockTenantID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.buttonClearStock = new System.Windows.Forms.Button();
            this.buttonLoadStock = new System.Windows.Forms.Button();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.groupBox29 = new System.Windows.Forms.GroupBox();
            this.groupBox32 = new System.Windows.Forms.GroupBox();
            this.dataGridViewOutputDispensedPack = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn26 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn27 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn28 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn29 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn30 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn31 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox31 = new System.Windows.Forms.GroupBox();
            this.dataGridViewOutputOrderItems = new System.Windows.Forms.DataGridView();
            this.ColumnOutputItemIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnOutputItemArticleCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnOutputItemBatch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnOutputItemExternalID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnOutputItemExpiryDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnOutputItemPackID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnOutputItemRequestedQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnOutputItemRequestedSubItemQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox30 = new System.Windows.Forms.GroupBox();
            this.dataGridViewOutputOrderList = new System.Windows.Forms.DataGridView();
            this.ColumnOutputOrderID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnOutputOrderPriority = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnColumnOutputNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnOutputOrderPoint = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnOutputOrderBox = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnOutputOrderState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnOutputOrderTentantID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox28 = new System.Windows.Forms.GroupBox();
            this.checkBoxOutputGenerateBoxID = new System.Windows.Forms.CheckBox();
            this.checkBoxOutputAutoReply = new System.Windows.Forms.CheckBox();
            this.groupBox27 = new System.Windows.Forms.GroupBox();
            this.radioButtonStockOutputUpdateStock = new System.Windows.Forms.RadioButton();
            this.radioButtonStockOutputFrozenStock = new System.Windows.Forms.RadioButton();
            this.radioButtonStockOutputAlwaysIncomplete = new System.Windows.Forms.RadioButton();
            this.radioButtonStockOutputAlwaysComplete = new System.Windows.Forms.RadioButton();
            this.tabPage12 = new System.Windows.Forms.TabPage();
            this.splitContainerLog = new System.Windows.Forms.SplitContainer();
            this.listViewWwks2Log = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.richTextBoxDetailLog = new System.Windows.Forms.RichTextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupRawXml = new System.Windows.Forms.GroupBox();
            this.btnClearRawXml = new System.Windows.Forms.Button();
            this.btnSendRawXml = new System.Windows.Forms.Button();
            this.txtRawXml = new System.Windows.Forms.RichTextBox();
            this.openFileDialogLoadStock = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox15.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStockLocationList)).BeginInit();
            this.groupBox14.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTenantList)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSubscriberID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownKeepAliveTimeout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownKeepAliveInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHandShakeTimeOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPort)).BeginInit();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.groupBox13.SuspendLayout();
            this.groupBox12.SuspendLayout();
            this.groupBox10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInputRequestPackList)).BeginInit();
            this.tabPage5.SuspendLayout();
            this.groupBox17.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.groupBox35.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMasterDataMachineLocation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSubItemQuantity)).BeginInit();
            this.groupBox20.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMasterArticle)).BeginInit();
            this.groupBox19.SuspendLayout();
            this.tabPage11.SuspendLayout();
            this.groupBox22.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStockDeliveryDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStockDeliveryMaster)).BeginInit();
            this.groupBox23.SuspendLayout();
            this.tabPage9.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox18.SuspendLayout();
            this.groupBox21.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewArticleInfoArticleList)).BeginInit();
            this.tabPage7.SuspendLayout();
            this.groupBox25.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerStock)).BeginInit();
            this.splitContainerStock.Panel1.SuspendLayout();
            this.splitContainerStock.Panel2.SuspendLayout();
            this.splitContainerStock.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProductStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPackStock)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.tabPage8.SuspendLayout();
            this.groupBox29.SuspendLayout();
            this.groupBox32.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOutputDispensedPack)).BeginInit();
            this.groupBox31.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOutputOrderItems)).BeginInit();
            this.groupBox30.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOutputOrderList)).BeginInit();
            this.groupBox28.SuspendLayout();
            this.groupBox27.SuspendLayout();
            this.tabPage12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerLog)).BeginInit();
            this.splitContainerLog.Panel1.SuspendLayout();
            this.splitContainerLog.Panel2.SuspendLayout();
            this.splitContainerLog.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupRawXml.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.groupBox3);
            this.splitContainer.Panel1.Controls.Add(this.groupBox15);
            this.splitContainer.Panel1.Controls.Add(this.groupBox14);
            this.splitContainer.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer.Panel1MinSize = 250;
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.tabControl);
            this.splitContainer.Panel2MinSize = 200;
            this.splitContainer.Size = new System.Drawing.Size(1856, 1167);
            this.splitContainer.SplitterDistance = 250;
            this.splitContainer.SplitterWidth = 6;
            this.splitContainer.TabIndex = 5;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.buttonClearSavedState);
            this.groupBox3.Controls.Add(this.buttonSaveSimulatorState);
            this.groupBox3.Location = new System.Drawing.Point(4, 902);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Size = new System.Drawing.Size(242, 140);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Simulator State";
            // 
            // buttonClearSavedState
            // 
            this.buttonClearSavedState.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClearSavedState.Location = new System.Drawing.Point(10, 83);
            this.buttonClearSavedState.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonClearSavedState.Name = "buttonClearSavedState";
            this.buttonClearSavedState.Size = new System.Drawing.Size(218, 44);
            this.buttonClearSavedState.TabIndex = 1;
            this.buttonClearSavedState.Text = "Clear Saved State";
            this.buttonClearSavedState.UseVisualStyleBackColor = true;
            this.buttonClearSavedState.Click += new System.EventHandler(this.buttonClearSavedState_Click);
            // 
            // buttonSaveSimulatorState
            // 
            this.buttonSaveSimulatorState.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSaveSimulatorState.Location = new System.Drawing.Point(10, 33);
            this.buttonSaveSimulatorState.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonSaveSimulatorState.Name = "buttonSaveSimulatorState";
            this.buttonSaveSimulatorState.Size = new System.Drawing.Size(218, 44);
            this.buttonSaveSimulatorState.TabIndex = 0;
            this.buttonSaveSimulatorState.Text = "Save";
            this.buttonSaveSimulatorState.UseVisualStyleBackColor = true;
            this.buttonSaveSimulatorState.Click += new System.EventHandler(this.buttonSaveSimulatorState_Click);
            // 
            // groupBox15
            // 
            this.groupBox15.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox15.Controls.Add(this.dataGridViewStockLocationList);
            this.groupBox15.Location = new System.Drawing.Point(4, 660);
            this.groupBox15.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox15.Name = "groupBox15";
            this.groupBox15.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox15.Size = new System.Drawing.Size(242, 235);
            this.groupBox15.TabIndex = 3;
            this.groupBox15.TabStop = false;
            this.groupBox15.Text = "Stock Locations";
            // 
            // dataGridViewStockLocationList
            // 
            this.dataGridViewStockLocationList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewStockLocationList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewStockLocationList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnStockLocationId,
            this.ColumnStockLocationDescription});
            this.dataGridViewStockLocationList.Location = new System.Drawing.Point(8, 33);
            this.dataGridViewStockLocationList.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridViewStockLocationList.Name = "dataGridViewStockLocationList";
            this.dataGridViewStockLocationList.RowHeadersWidth = 20;
            this.dataGridViewStockLocationList.RowTemplate.Height = 24;
            this.dataGridViewStockLocationList.Size = new System.Drawing.Size(224, 192);
            this.dataGridViewStockLocationList.TabIndex = 1;
            // 
            // ColumnStockLocationId
            // 
            this.ColumnStockLocationId.DataPropertyName = "ID";
            this.ColumnStockLocationId.HeaderText = "ID";
            this.ColumnStockLocationId.MinimumWidth = 10;
            this.ColumnStockLocationId.Name = "ColumnStockLocationId";
            this.ColumnStockLocationId.Width = 30;
            // 
            // ColumnStockLocationDescription
            // 
            this.ColumnStockLocationDescription.DataPropertyName = "Description";
            this.ColumnStockLocationDescription.HeaderText = "Description";
            this.ColumnStockLocationDescription.MinimumWidth = 10;
            this.ColumnStockLocationDescription.Name = "ColumnStockLocationDescription";
            this.ColumnStockLocationDescription.Width = 90;
            // 
            // groupBox14
            // 
            this.groupBox14.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox14.Controls.Add(this.dataGridViewTenantList);
            this.groupBox14.Location = new System.Drawing.Point(4, 417);
            this.groupBox14.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox14.Name = "groupBox14";
            this.groupBox14.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox14.Size = new System.Drawing.Size(242, 235);
            this.groupBox14.TabIndex = 2;
            this.groupBox14.TabStop = false;
            this.groupBox14.Text = "Tenants";
            // 
            // dataGridViewTenantList
            // 
            this.dataGridViewTenantList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewTenantList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTenantList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnTenantID,
            this.ColumnTenantDescription});
            this.dataGridViewTenantList.Location = new System.Drawing.Point(8, 33);
            this.dataGridViewTenantList.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridViewTenantList.Name = "dataGridViewTenantList";
            this.dataGridViewTenantList.RowHeadersWidth = 20;
            this.dataGridViewTenantList.RowTemplate.Height = 24;
            this.dataGridViewTenantList.Size = new System.Drawing.Size(226, 192);
            this.dataGridViewTenantList.TabIndex = 0;
            // 
            // ColumnTenantID
            // 
            this.ColumnTenantID.DataPropertyName = "ID";
            this.ColumnTenantID.HeaderText = "ID";
            this.ColumnTenantID.MinimumWidth = 10;
            this.ColumnTenantID.Name = "ColumnTenantID";
            this.ColumnTenantID.Width = 30;
            // 
            // ColumnTenantDescription
            // 
            this.ColumnTenantDescription.DataPropertyName = "Description";
            this.ColumnTenantDescription.HeaderText = "Description";
            this.ColumnTenantDescription.MinimumWidth = 10;
            this.ColumnTenantDescription.Name = "ColumnTenantDescription";
            this.ColumnTenantDescription.Width = 90;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.checkBoxUseExternalIdAsSerialNumber);
            this.groupBox1.Controls.Add(this.numericUpDownSubscriberID);
            this.groupBox1.Controls.Add(this.numericUpDownKeepAliveTimeout);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.numericUpDownKeepAliveInterval);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.checkBoxEnableKeepAlive);
            this.groupBox1.Controls.Add(this.numericUpDownHandShakeTimeOut);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.buttonConnect);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.numericUpDownPort);
            this.groupBox1.Location = new System.Drawing.Point(4, 4);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(242, 406);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Connection";
            // 
            // checkBoxUseExternalIdAsSerialNumber
            // 
            this.checkBoxUseExternalIdAsSerialNumber.AutoSize = true;
            this.checkBoxUseExternalIdAsSerialNumber.Location = new System.Drawing.Point(16, 302);
            this.checkBoxUseExternalIdAsSerialNumber.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxUseExternalIdAsSerialNumber.Name = "checkBoxUseExternalIdAsSerialNumber";
            this.checkBoxUseExternalIdAsSerialNumber.Size = new System.Drawing.Size(351, 29);
            this.checkBoxUseExternalIdAsSerialNumber.TabIndex = 12;
            this.checkBoxUseExternalIdAsSerialNumber.Text = "Use ExternalId As SerialNumber";
            this.checkBoxUseExternalIdAsSerialNumber.UseVisualStyleBackColor = true;
            this.checkBoxUseExternalIdAsSerialNumber.CheckedChanged += new System.EventHandler(this.checkBoxUseExternalIdAsSerialNumber_CheckedChanged);
            // 
            // numericUpDownSubscriberID
            // 
            this.numericUpDownSubscriberID.Location = new System.Drawing.Point(240, 77);
            this.numericUpDownSubscriberID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.numericUpDownSubscriberID.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDownSubscriberID.Name = "numericUpDownSubscriberID";
            this.numericUpDownSubscriberID.Size = new System.Drawing.Size(124, 31);
            this.numericUpDownSubscriberID.TabIndex = 1;
            this.numericUpDownSubscriberID.Value = new decimal(new int[] {
            999,
            0,
            0,
            0});
            // 
            // numericUpDownKeepAliveTimeout
            // 
            this.numericUpDownKeepAliveTimeout.Location = new System.Drawing.Point(240, 256);
            this.numericUpDownKeepAliveTimeout.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.numericUpDownKeepAliveTimeout.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDownKeepAliveTimeout.Name = "numericUpDownKeepAliveTimeout";
            this.numericUpDownKeepAliveTimeout.Size = new System.Drawing.Size(124, 31);
            this.numericUpDownKeepAliveTimeout.TabIndex = 5;
            this.numericUpDownKeepAliveTimeout.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownKeepAliveTimeout.ValueChanged += new System.EventHandler(this.numericUpDownKeepAliveTimeout_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 260);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(204, 25);
            this.label5.TabIndex = 11;
            this.label5.Text = "Keep Alive Timeout:";
            // 
            // numericUpDownKeepAliveInterval
            // 
            this.numericUpDownKeepAliveInterval.Location = new System.Drawing.Point(240, 210);
            this.numericUpDownKeepAliveInterval.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.numericUpDownKeepAliveInterval.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDownKeepAliveInterval.Name = "numericUpDownKeepAliveInterval";
            this.numericUpDownKeepAliveInterval.Size = new System.Drawing.Size(124, 31);
            this.numericUpDownKeepAliveInterval.TabIndex = 4;
            this.numericUpDownKeepAliveInterval.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownKeepAliveInterval.ValueChanged += new System.EventHandler(this.numericUpDownKeepAliveInterval_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 213);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(197, 25);
            this.label4.TabIndex = 9;
            this.label4.Text = "Keep Alive Interval:";
            // 
            // checkBoxEnableKeepAlive
            // 
            this.checkBoxEnableKeepAlive.AutoSize = true;
            this.checkBoxEnableKeepAlive.Location = new System.Drawing.Point(16, 169);
            this.checkBoxEnableKeepAlive.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxEnableKeepAlive.Name = "checkBoxEnableKeepAlive";
            this.checkBoxEnableKeepAlive.Size = new System.Drawing.Size(220, 29);
            this.checkBoxEnableKeepAlive.TabIndex = 3;
            this.checkBoxEnableKeepAlive.Text = "Enable Keep Alive";
            this.checkBoxEnableKeepAlive.UseVisualStyleBackColor = true;
            this.checkBoxEnableKeepAlive.CheckedChanged += new System.EventHandler(this.checkBoxEnableKeepAlive_CheckedChanged);
            // 
            // numericUpDownHandShakeTimeOut
            // 
            this.numericUpDownHandShakeTimeOut.Location = new System.Drawing.Point(240, 123);
            this.numericUpDownHandShakeTimeOut.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.numericUpDownHandShakeTimeOut.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDownHandShakeTimeOut.Name = "numericUpDownHandShakeTimeOut";
            this.numericUpDownHandShakeTimeOut.Size = new System.Drawing.Size(124, 31);
            this.numericUpDownHandShakeTimeOut.TabIndex = 2;
            this.numericUpDownHandShakeTimeOut.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 127);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(210, 25);
            this.label2.TabIndex = 6;
            this.label2.Text = "Handshake Timeout:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 77);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(141, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "SubscriberID:";
            // 
            // buttonConnect
            // 
            this.buttonConnect.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonConnect.Location = new System.Drawing.Point(16, 350);
            this.buttonConnect.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.buttonConnect.Size = new System.Drawing.Size(214, 42);
            this.buttonConnect.TabIndex = 6;
            this.buttonConnect.Text = "Listen";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 35);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Port:";
            // 
            // numericUpDownPort
            // 
            this.numericUpDownPort.Location = new System.Drawing.Point(240, 31);
            this.numericUpDownPort.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.numericUpDownPort.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDownPort.Name = "numericUpDownPort";
            this.numericUpDownPort.Size = new System.Drawing.Size(124, 31);
            this.numericUpDownPort.TabIndex = 0;
            this.numericUpDownPort.Value = new decimal(new int[] {
            6050,
            0,
            0,
            0});
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage3);
            this.tabControl.Controls.Add(this.tabPage4);
            this.tabControl.Controls.Add(this.tabPage5);
            this.tabControl.Controls.Add(this.tabPage6);
            this.tabControl.Controls.Add(this.tabPage11);
            this.tabControl.Controls.Add(this.tabPage9);
            this.tabControl.Controls.Add(this.tabPage7);
            this.tabControl.Controls.Add(this.tabPage8);
            this.tabControl.Controls.Add(this.tabPage12);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Location = new System.Drawing.Point(4, 4);
            this.tabControl.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1598, 1158);
            this.tabControl.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Location = new System.Drawing.Point(8, 39);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage1.Size = new System.Drawing.Size(1582, 1111);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Initialization";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.listViewConnections);
            this.groupBox2.Location = new System.Drawing.Point(4, 4);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(1562, 1100);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Connections";
            // 
            // listViewConnections
            // 
            this.listViewConnections.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewConnections.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderEndpoint,
            this.columnHeaderHandshake,
            this.columnHeaderSubscriberID,
            this.columnHeaderTenant});
            this.listViewConnections.HideSelection = false;
            this.listViewConnections.Location = new System.Drawing.Point(8, 33);
            this.listViewConnections.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listViewConnections.MultiSelect = false;
            this.listViewConnections.Name = "listViewConnections";
            this.listViewConnections.Size = new System.Drawing.Size(1542, 1054);
            this.listViewConnections.TabIndex = 0;
            this.listViewConnections.UseCompatibleStateImageBehavior = false;
            this.listViewConnections.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderEndpoint
            // 
            this.columnHeaderEndpoint.Text = "End Point";
            this.columnHeaderEndpoint.Width = 150;
            // 
            // columnHeaderHandshake
            // 
            this.columnHeaderHandshake.Text = "Handshake";
            this.columnHeaderHandshake.Width = 100;
            // 
            // columnHeaderSubscriberID
            // 
            this.columnHeaderSubscriberID.Text = "SubscriberID";
            this.columnHeaderSubscriberID.Width = 100;
            // 
            // columnHeaderTenant
            // 
            this.columnHeaderTenant.Text = "Tenant";
            this.columnHeaderTenant.Width = 100;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupBox6);
            this.tabPage3.Location = new System.Drawing.Point(8, 39);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1332, 1111);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "System Status";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox6.Controls.Add(this.groupBox7);
            this.groupBox6.Controls.Add(this.textBoxStatusText);
            this.groupBox6.Controls.Add(this.label6);
            this.groupBox6.Controls.Add(this.NotReady);
            this.groupBox6.Controls.Add(this.radioButtonReady);
            this.groupBox6.Location = new System.Drawing.Point(4, 4);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox6.Size = new System.Drawing.Size(1312, 1100);
            this.groupBox6.TabIndex = 5;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Auto reply";
            // 
            // groupBox7
            // 
            this.groupBox7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox7.Controls.Add(this.buttonRemoveComponent);
            this.groupBox7.Controls.Add(this.buttonAddComponent);
            this.groupBox7.Controls.Add(this.listViewStatusComponent);
            this.groupBox7.Location = new System.Drawing.Point(8, 119);
            this.groupBox7.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox7.Size = new System.Drawing.Size(1294, 967);
            this.groupBox7.TabIndex = 6;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Components";
            // 
            // buttonRemoveComponent
            // 
            this.buttonRemoveComponent.Location = new System.Drawing.Point(130, 33);
            this.buttonRemoveComponent.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonRemoveComponent.Name = "buttonRemoveComponent";
            this.buttonRemoveComponent.Size = new System.Drawing.Size(112, 37);
            this.buttonRemoveComponent.TabIndex = 1;
            this.buttonRemoveComponent.Text = "Remove";
            this.buttonRemoveComponent.UseVisualStyleBackColor = true;
            this.buttonRemoveComponent.Click += new System.EventHandler(this.buttonRemoveComponent_Click);
            // 
            // buttonAddComponent
            // 
            this.buttonAddComponent.Location = new System.Drawing.Point(8, 33);
            this.buttonAddComponent.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonAddComponent.Name = "buttonAddComponent";
            this.buttonAddComponent.Size = new System.Drawing.Size(112, 37);
            this.buttonAddComponent.TabIndex = 0;
            this.buttonAddComponent.Text = "Add...";
            this.buttonAddComponent.UseVisualStyleBackColor = true;
            this.buttonAddComponent.Click += new System.EventHandler(this.buttonAddComponent_Click);
            // 
            // listViewStatusComponent
            // 
            this.listViewStatusComponent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewStatusComponent.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderType,
            this.columnHeaderDescription,
            this.columnHeaderState,
            this.columnHeaderStateText});
            this.listViewStatusComponent.HideSelection = false;
            this.listViewStatusComponent.Location = new System.Drawing.Point(8, 79);
            this.listViewStatusComponent.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listViewStatusComponent.Name = "listViewStatusComponent";
            this.listViewStatusComponent.Size = new System.Drawing.Size(1274, 877);
            this.listViewStatusComponent.TabIndex = 2;
            this.listViewStatusComponent.UseCompatibleStateImageBehavior = false;
            this.listViewStatusComponent.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderType
            // 
            this.columnHeaderType.Text = "Type";
            this.columnHeaderType.Width = 150;
            // 
            // columnHeaderDescription
            // 
            this.columnHeaderDescription.Text = "Description";
            this.columnHeaderDescription.Width = 150;
            // 
            // columnHeaderState
            // 
            this.columnHeaderState.Text = "State";
            this.columnHeaderState.Width = 80;
            // 
            // columnHeaderStateText
            // 
            this.columnHeaderStateText.Text = "State Text";
            this.columnHeaderStateText.Width = 150;
            // 
            // textBoxStatusText
            // 
            this.textBoxStatusText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxStatusText.Location = new System.Drawing.Point(124, 75);
            this.textBoxStatusText.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxStatusText.Name = "textBoxStatusText";
            this.textBoxStatusText.Size = new System.Drawing.Size(1178, 31);
            this.textBoxStatusText.TabIndex = 3;
            this.textBoxStatusText.TextChanged += new System.EventHandler(this.radioButtonReady_CheckedChanged);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(0, 79);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(116, 25);
            this.label6.TabIndex = 2;
            this.label6.Text = "State Text:";
            // 
            // NotReady
            // 
            this.NotReady.AutoSize = true;
            this.NotReady.Location = new System.Drawing.Point(128, 33);
            this.NotReady.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.NotReady.Name = "NotReady";
            this.NotReady.Size = new System.Drawing.Size(144, 29);
            this.NotReady.TabIndex = 1;
            this.NotReady.Text = "Not Ready";
            this.NotReady.UseVisualStyleBackColor = true;
            this.NotReady.CheckedChanged += new System.EventHandler(this.radioButtonReady_CheckedChanged);
            // 
            // radioButtonReady
            // 
            this.radioButtonReady.AutoSize = true;
            this.radioButtonReady.Checked = true;
            this.radioButtonReady.Location = new System.Drawing.Point(8, 33);
            this.radioButtonReady.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioButtonReady.Name = "radioButtonReady";
            this.radioButtonReady.Size = new System.Drawing.Size(105, 29);
            this.radioButtonReady.TabIndex = 0;
            this.radioButtonReady.TabStop = true;
            this.radioButtonReady.Text = "Ready";
            this.radioButtonReady.UseVisualStyleBackColor = true;
            this.radioButtonReady.CheckedChanged += new System.EventHandler(this.radioButtonReady_CheckedChanged);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.groupBox9);
            this.tabPage4.Location = new System.Drawing.Point(8, 39);
            this.tabPage4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(1332, 1111);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Stock Input";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // groupBox9
            // 
            this.groupBox9.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox9.Controls.Add(this.groupBox11);
            this.groupBox9.Controls.Add(this.groupBox10);
            this.groupBox9.Location = new System.Drawing.Point(4, 4);
            this.groupBox9.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox9.Size = new System.Drawing.Size(1312, 1096);
            this.groupBox9.TabIndex = 6;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Manual Input";
            // 
            // groupBox11
            // 
            this.groupBox11.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox11.Controls.Add(this.groupBox13);
            this.groupBox11.Controls.Add(this.groupBox12);
            this.groupBox11.Location = new System.Drawing.Point(8, 404);
            this.groupBox11.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox11.Size = new System.Drawing.Size(1294, 683);
            this.groupBox11.TabIndex = 1;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Input Response";
            // 
            // groupBox13
            // 
            this.groupBox13.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox13.Controls.Add(this.checkBoxAcceptFridge);
            this.groupBox13.Controls.Add(this.buttonInputMessageNotLoad);
            this.groupBox13.Controls.Add(this.buttonInputMessageLoad);
            this.groupBox13.Controls.Add(this.checkBoxInputMessageAuto);
            this.groupBox13.Location = new System.Drawing.Point(18, 506);
            this.groupBox13.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox13.Size = new System.Drawing.Size(1268, 167);
            this.groupBox13.TabIndex = 3;
            this.groupBox13.TabStop = false;
            this.groupBox13.Text = "Input Message";
            // 
            // checkBoxAcceptFridge
            // 
            this.checkBoxAcceptFridge.AutoSize = true;
            this.checkBoxAcceptFridge.Checked = true;
            this.checkBoxAcceptFridge.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxAcceptFridge.Location = new System.Drawing.Point(8, 75);
            this.checkBoxAcceptFridge.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxAcceptFridge.Name = "checkBoxAcceptFridge";
            this.checkBoxAcceptFridge.Size = new System.Drawing.Size(223, 29);
            this.checkBoxAcceptFridge.TabIndex = 4;
            this.checkBoxAcceptFridge.Text = "Accept Fridge Item";
            this.checkBoxAcceptFridge.UseVisualStyleBackColor = true;
            this.checkBoxAcceptFridge.CheckedChanged += new System.EventHandler(this.checkBoxAcceptFridge_CheckedChanged);
            // 
            // buttonInputMessageNotLoad
            // 
            this.buttonInputMessageNotLoad.Enabled = false;
            this.buttonInputMessageNotLoad.Location = new System.Drawing.Point(206, 117);
            this.buttonInputMessageNotLoad.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonInputMessageNotLoad.Name = "buttonInputMessageNotLoad";
            this.buttonInputMessageNotLoad.Size = new System.Drawing.Size(188, 37);
            this.buttonInputMessageNotLoad.TabIndex = 3;
            this.buttonInputMessageNotLoad.Text = "Don\'t Load Pack";
            this.buttonInputMessageNotLoad.UseVisualStyleBackColor = true;
            this.buttonInputMessageNotLoad.Click += new System.EventHandler(this.buttonInputMessageNotLoad_Click);
            // 
            // buttonInputMessageLoad
            // 
            this.buttonInputMessageLoad.Enabled = false;
            this.buttonInputMessageLoad.Location = new System.Drawing.Point(8, 117);
            this.buttonInputMessageLoad.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonInputMessageLoad.Name = "buttonInputMessageLoad";
            this.buttonInputMessageLoad.Size = new System.Drawing.Size(188, 37);
            this.buttonInputMessageLoad.TabIndex = 2;
            this.buttonInputMessageLoad.Text = "Load Pack";
            this.buttonInputMessageLoad.UseVisualStyleBackColor = true;
            this.buttonInputMessageLoad.Click += new System.EventHandler(this.buttonInputMessageLoad_Click);
            // 
            // checkBoxInputMessageAuto
            // 
            this.checkBoxInputMessageAuto.AutoSize = true;
            this.checkBoxInputMessageAuto.Checked = true;
            this.checkBoxInputMessageAuto.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxInputMessageAuto.Location = new System.Drawing.Point(8, 33);
            this.checkBoxInputMessageAuto.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxInputMessageAuto.Name = "checkBoxInputMessageAuto";
            this.checkBoxInputMessageAuto.Size = new System.Drawing.Size(149, 29);
            this.checkBoxInputMessageAuto.TabIndex = 1;
            this.checkBoxInputMessageAuto.Text = "Auto Reply";
            this.checkBoxInputMessageAuto.UseVisualStyleBackColor = true;
            this.checkBoxInputMessageAuto.CheckedChanged += new System.EventHandler(this.checkBoxInputMessageAuto_CheckedChanged);
            // 
            // groupBox12
            // 
            this.groupBox12.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox12.Controls.Add(this.listViewScannedPackInformation);
            this.groupBox12.Location = new System.Drawing.Point(8, 33);
            this.groupBox12.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox12.Size = new System.Drawing.Size(1276, 463);
            this.groupBox12.TabIndex = 2;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "Last Pack(s) Scanned";
            // 
            // listViewScannedPackInformation
            // 
            this.listViewScannedPackInformation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewScannedPackInformation.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderIndex,
            this.columnHeaderID,
            this.columnHeaderName,
            this.columnHeaderDosageForm,
            this.columnHeaderPackagingUnit,
            this.columnHeaderMaxSubItemQuantity,
            this.columnHeaderBatchNumber,
            this.columnHeaderExpiryDate,
            this.columnHeaderExternalID,
            this.columnHeaderSubItemQuantity,
            this.columnHeaderStockLocation,
            this.columnHeaderIsInFridge,
            this.columnHeaderHandingInput,
            this.columnHeaderHandlingText});
            this.listViewScannedPackInformation.HideSelection = false;
            this.listViewScannedPackInformation.Location = new System.Drawing.Point(8, 33);
            this.listViewScannedPackInformation.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listViewScannedPackInformation.Name = "listViewScannedPackInformation";
            this.listViewScannedPackInformation.Size = new System.Drawing.Size(1256, 419);
            this.listViewScannedPackInformation.TabIndex = 0;
            this.listViewScannedPackInformation.UseCompatibleStateImageBehavior = false;
            this.listViewScannedPackInformation.View = System.Windows.Forms.View.Details;
            this.listViewScannedPackInformation.SizeChanged += new System.EventHandler(this.listViewScannedPackInformation_SizeChanged);
            // 
            // columnHeaderIndex
            // 
            this.columnHeaderIndex.Text = "Index";
            this.columnHeaderIndex.Width = 30;
            // 
            // columnHeaderID
            // 
            this.columnHeaderID.Text = "ID";
            this.columnHeaderID.Width = 100;
            // 
            // columnHeaderName
            // 
            this.columnHeaderName.Text = "Name";
            this.columnHeaderName.Width = 100;
            // 
            // columnHeaderDosageForm
            // 
            this.columnHeaderDosageForm.Text = "Dosage Form";
            // 
            // columnHeaderPackagingUnit
            // 
            this.columnHeaderPackagingUnit.Text = "Packaging Unit";
            // 
            // columnHeaderMaxSubItemQuantity
            // 
            this.columnHeaderMaxSubItemQuantity.Text = "MaxSubItemQuantity";
            // 
            // columnHeaderBatchNumber
            // 
            this.columnHeaderBatchNumber.Text = "Batch Number";
            // 
            // columnHeaderExpiryDate
            // 
            this.columnHeaderExpiryDate.Text = "Expiry Date";
            // 
            // columnHeaderExternalID
            // 
            this.columnHeaderExternalID.Text = "External ID";
            // 
            // columnHeaderSubItemQuantity
            // 
            this.columnHeaderSubItemQuantity.Text = "SubItemQuantity";
            // 
            // columnHeaderStockLocation
            // 
            this.columnHeaderStockLocation.Text = "StockLocation";
            // 
            // columnHeaderIsInFridge
            // 
            this.columnHeaderIsInFridge.Text = "IsInFridge";
            // 
            // columnHeaderHandingInput
            // 
            this.columnHeaderHandingInput.Text = "Handing Input";
            this.columnHeaderHandingInput.Width = 100;
            // 
            // columnHeaderHandlingText
            // 
            this.columnHeaderHandlingText.Text = "Handling Text";
            this.columnHeaderHandlingText.Width = 100;
            // 
            // groupBox10
            // 
            this.groupBox10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox10.Controls.Add(this.checkBoxIsDeliveryInput);
            this.groupBox10.Controls.Add(this.labelSelectInputLocation);
            this.groupBox10.Controls.Add(this.comboBoxInputSelectLocation);
            this.groupBox10.Controls.Add(this.labelSelectInputTenant);
            this.groupBox10.Controls.Add(this.comboBoxInputSelectTenant);
            this.groupBox10.Controls.Add(this.checkBoxSetPickingIndicator);
            this.groupBox10.Controls.Add(this.buttonScanPack);
            this.groupBox10.Controls.Add(this.dataGridViewInputRequestPackList);
            this.groupBox10.Location = new System.Drawing.Point(8, 33);
            this.groupBox10.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox10.Size = new System.Drawing.Size(1294, 362);
            this.groupBox10.TabIndex = 0;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Input Request";
            // 
            // checkBoxIsDeliveryInput
            // 
            this.checkBoxIsDeliveryInput.AutoSize = true;
            this.checkBoxIsDeliveryInput.Location = new System.Drawing.Point(256, 38);
            this.checkBoxIsDeliveryInput.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxIsDeliveryInput.Name = "checkBoxIsDeliveryInput";
            this.checkBoxIsDeliveryInput.Size = new System.Drawing.Size(197, 29);
            this.checkBoxIsDeliveryInput.TabIndex = 1;
            this.checkBoxIsDeliveryInput.Text = "Is Delivery Input";
            this.checkBoxIsDeliveryInput.UseVisualStyleBackColor = true;
            // 
            // labelSelectInputLocation
            // 
            this.labelSelectInputLocation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelSelectInputLocation.AutoSize = true;
            this.labelSelectInputLocation.Location = new System.Drawing.Point(932, 85);
            this.labelSelectInputLocation.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSelectInputLocation.Name = "labelSelectInputLocation";
            this.labelSelectInputLocation.Size = new System.Drawing.Size(166, 25);
            this.labelSelectInputLocation.TabIndex = 6;
            this.labelSelectInputLocation.Text = "Select Location:";
            // 
            // comboBoxInputSelectLocation
            // 
            this.comboBoxInputSelectLocation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxInputSelectLocation.DisplayMember = "DisplayText";
            this.comboBoxInputSelectLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxInputSelectLocation.FormattingEnabled = true;
            this.comboBoxInputSelectLocation.Location = new System.Drawing.Point(1104, 79);
            this.comboBoxInputSelectLocation.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBoxInputSelectLocation.Name = "comboBoxInputSelectLocation";
            this.comboBoxInputSelectLocation.Size = new System.Drawing.Size(180, 33);
            this.comboBoxInputSelectLocation.TabIndex = 3;
            this.comboBoxInputSelectLocation.ValueMember = "DisplayText";
            // 
            // labelSelectInputTenant
            // 
            this.labelSelectInputTenant.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelSelectInputTenant.AutoSize = true;
            this.labelSelectInputTenant.Location = new System.Drawing.Point(932, 38);
            this.labelSelectInputTenant.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSelectInputTenant.Name = "labelSelectInputTenant";
            this.labelSelectInputTenant.Size = new System.Drawing.Size(151, 25);
            this.labelSelectInputTenant.TabIndex = 4;
            this.labelSelectInputTenant.Text = "Select Tenant:";
            // 
            // comboBoxInputSelectTenant
            // 
            this.comboBoxInputSelectTenant.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxInputSelectTenant.DisplayMember = "DisplayText";
            this.comboBoxInputSelectTenant.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxInputSelectTenant.FormattingEnabled = true;
            this.comboBoxInputSelectTenant.Location = new System.Drawing.Point(1104, 33);
            this.comboBoxInputSelectTenant.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBoxInputSelectTenant.Name = "comboBoxInputSelectTenant";
            this.comboBoxInputSelectTenant.Size = new System.Drawing.Size(180, 33);
            this.comboBoxInputSelectTenant.TabIndex = 2;
            this.comboBoxInputSelectTenant.ValueMember = "DisplayText";
            // 
            // checkBoxSetPickingIndicator
            // 
            this.checkBoxSetPickingIndicator.AutoSize = true;
            this.checkBoxSetPickingIndicator.Location = new System.Drawing.Point(8, 38);
            this.checkBoxSetPickingIndicator.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxSetPickingIndicator.Name = "checkBoxSetPickingIndicator";
            this.checkBoxSetPickingIndicator.Size = new System.Drawing.Size(240, 29);
            this.checkBoxSetPickingIndicator.TabIndex = 0;
            this.checkBoxSetPickingIndicator.Text = "Set Picking Indicator";
            this.checkBoxSetPickingIndicator.UseVisualStyleBackColor = true;
            // 
            // buttonScanPack
            // 
            this.buttonScanPack.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonScanPack.Location = new System.Drawing.Point(8, 81);
            this.buttonScanPack.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonScanPack.Name = "buttonScanPack";
            this.buttonScanPack.Size = new System.Drawing.Size(150, 37);
            this.buttonScanPack.TabIndex = 4;
            this.buttonScanPack.Text = "Scan Pack";
            this.buttonScanPack.UseVisualStyleBackColor = true;
            this.buttonScanPack.Click += new System.EventHandler(this.buttonScanPack_Click);
            // 
            // dataGridViewInputRequestPackList
            // 
            this.dataGridViewInputRequestPackList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewInputRequestPackList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewInputRequestPackList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnDeliveryNumber,
            this.ColumnScanCode,
            this.ColumnBatchNumber,
            this.ColumnExpiryDate,
            this.ColumnHidenExpiryDate,
            this.ColumnExternalID,
            this.ColumnSubItemQuantity,
            this.ColumnShape,
            this.ColumnSelectShape,
            this.ColumnMachineLocation});
            this.dataGridViewInputRequestPackList.Location = new System.Drawing.Point(8, 127);
            this.dataGridViewInputRequestPackList.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridViewInputRequestPackList.Name = "dataGridViewInputRequestPackList";
            this.dataGridViewInputRequestPackList.RowHeadersWidth = 20;
            this.dataGridViewInputRequestPackList.RowTemplate.Height = 24;
            this.dataGridViewInputRequestPackList.Size = new System.Drawing.Size(1276, 227);
            this.dataGridViewInputRequestPackList.TabIndex = 5;
            this.dataGridViewInputRequestPackList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewInputRequestPackList_CellContentClick);
            this.dataGridViewInputRequestPackList.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewInputRequestPackList_CellValidated);
            this.dataGridViewInputRequestPackList.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.dataGridViewInputRequestPackList_DefaultValuesNeeded);
            // 
            // ColumnDeliveryNumber
            // 
            this.ColumnDeliveryNumber.DataPropertyName = "DeliveryNumber";
            this.ColumnDeliveryNumber.HeaderText = "DeliveryNumber";
            this.ColumnDeliveryNumber.MinimumWidth = 10;
            this.ColumnDeliveryNumber.Name = "ColumnDeliveryNumber";
            this.ColumnDeliveryNumber.Width = 200;
            // 
            // ColumnScanCode
            // 
            this.ColumnScanCode.DataPropertyName = "ScanCode";
            this.ColumnScanCode.HeaderText = "ScanCode";
            this.ColumnScanCode.MinimumWidth = 10;
            this.ColumnScanCode.Name = "ColumnScanCode";
            this.ColumnScanCode.Width = 200;
            // 
            // ColumnBatchNumber
            // 
            this.ColumnBatchNumber.DataPropertyName = "BatchNumber";
            this.ColumnBatchNumber.HeaderText = "Batch Number";
            this.ColumnBatchNumber.MinimumWidth = 10;
            this.ColumnBatchNumber.Name = "ColumnBatchNumber";
            this.ColumnBatchNumber.Width = 200;
            // 
            // ColumnExpiryDate
            // 
            this.ColumnExpiryDate.HeaderText = "Expiry Date";
            this.ColumnExpiryDate.MinimumWidth = 10;
            this.ColumnExpiryDate.Name = "ColumnExpiryDate";
            this.ColumnExpiryDate.Width = 200;
            // 
            // ColumnHidenExpiryDate
            // 
            this.ColumnHidenExpiryDate.DataPropertyName = "ExpiryDate";
            this.ColumnHidenExpiryDate.HeaderText = "HidenExpiryDate";
            this.ColumnHidenExpiryDate.MinimumWidth = 10;
            this.ColumnHidenExpiryDate.Name = "ColumnHidenExpiryDate";
            this.ColumnHidenExpiryDate.Visible = false;
            this.ColumnHidenExpiryDate.Width = 200;
            // 
            // ColumnExternalID
            // 
            this.ColumnExternalID.DataPropertyName = "ExternalID";
            this.ColumnExternalID.HeaderText = "ExternalID";
            this.ColumnExternalID.MinimumWidth = 10;
            this.ColumnExternalID.Name = "ColumnExternalID";
            this.ColumnExternalID.Width = 200;
            // 
            // ColumnSubItemQuantity
            // 
            this.ColumnSubItemQuantity.DataPropertyName = "SubItemQuantity";
            this.ColumnSubItemQuantity.HeaderText = "SubItemQuantity";
            this.ColumnSubItemQuantity.MinimumWidth = 10;
            this.ColumnSubItemQuantity.Name = "ColumnSubItemQuantity";
            this.ColumnSubItemQuantity.Width = 200;
            // 
            // ColumnShape
            // 
            this.ColumnShape.DataPropertyName = "Shape";
            this.ColumnShape.HeaderText = "Shape";
            this.ColumnShape.MinimumWidth = 10;
            this.ColumnShape.Name = "ColumnShape";
            this.ColumnShape.ReadOnly = true;
            this.ColumnShape.Width = 200;
            // 
            // ColumnSelectShape
            // 
            this.ColumnSelectShape.HeaderText = "SelectShape";
            this.ColumnSelectShape.MinimumWidth = 10;
            this.ColumnSelectShape.Name = "ColumnSelectShape";
            this.ColumnSelectShape.Text = "...";
            this.ColumnSelectShape.Width = 20;
            // 
            // ColumnMachineLocation
            // 
            this.ColumnMachineLocation.DataPropertyName = "MachineLocation";
            this.ColumnMachineLocation.HeaderText = "MachineLocation";
            this.ColumnMachineLocation.MinimumWidth = 10;
            this.ColumnMachineLocation.Name = "ColumnMachineLocation";
            this.ColumnMachineLocation.Width = 200;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.groupBox17);
            this.tabPage5.Location = new System.Drawing.Point(8, 39);
            this.tabPage5.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(1332, 1111);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Stock Input Initiation";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // groupBox17
            // 
            this.groupBox17.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox17.Controls.Add(this.radioButtonInitiateInputReject);
            this.groupBox17.Controls.Add(this.radioButtonInitiateInputAccept);
            this.groupBox17.Location = new System.Drawing.Point(4, 4);
            this.groupBox17.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox17.Name = "groupBox17";
            this.groupBox17.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox17.Size = new System.Drawing.Size(1312, 1096);
            this.groupBox17.TabIndex = 7;
            this.groupBox17.TabStop = false;
            this.groupBox17.Text = "Auto reply";
            // 
            // radioButtonInitiateInputReject
            // 
            this.radioButtonInitiateInputReject.AutoSize = true;
            this.radioButtonInitiateInputReject.Location = new System.Drawing.Point(8, 75);
            this.radioButtonInitiateInputReject.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioButtonInitiateInputReject.Name = "radioButtonInitiateInputReject";
            this.radioButtonInitiateInputReject.Size = new System.Drawing.Size(104, 29);
            this.radioButtonInitiateInputReject.TabIndex = 1;
            this.radioButtonInitiateInputReject.Text = "Reject";
            this.radioButtonInitiateInputReject.UseVisualStyleBackColor = true;
            // 
            // radioButtonInitiateInputAccept
            // 
            this.radioButtonInitiateInputAccept.AutoSize = true;
            this.radioButtonInitiateInputAccept.Checked = true;
            this.radioButtonInitiateInputAccept.Location = new System.Drawing.Point(8, 33);
            this.radioButtonInitiateInputAccept.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioButtonInitiateInputAccept.Name = "radioButtonInitiateInputAccept";
            this.radioButtonInitiateInputAccept.Size = new System.Drawing.Size(109, 29);
            this.radioButtonInitiateInputAccept.TabIndex = 0;
            this.radioButtonInitiateInputAccept.TabStop = true;
            this.radioButtonInitiateInputAccept.Text = "Accept";
            this.radioButtonInitiateInputAccept.UseVisualStyleBackColor = true;
            this.radioButtonInitiateInputAccept.CheckedChanged += new System.EventHandler(this.radioButtonInitiateInputAccept_CheckedChanged);
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.groupBox35);
            this.tabPage6.Controls.Add(this.groupBox20);
            this.tabPage6.Controls.Add(this.groupBox19);
            this.tabPage6.Location = new System.Drawing.Point(8, 39);
            this.tabPage6.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(1332, 1111);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "Master Data";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // groupBox35
            // 
            this.groupBox35.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox35.Controls.Add(this.dateTimePickerMasterDataExpiryDate);
            this.groupBox35.Controls.Add(this.numericUpDownMasterDataMachineLocation);
            this.groupBox35.Controls.Add(this.label10);
            this.groupBox35.Controls.Add(this.numericUpDownSubItemQuantity);
            this.groupBox35.Controls.Add(this.label15);
            this.groupBox35.Controls.Add(this.label14);
            this.groupBox35.Controls.Add(this.textBoxMasterDataExternalID);
            this.groupBox35.Controls.Add(this.label13);
            this.groupBox35.Controls.Add(this.textBoxMasterDataBatchNumber);
            this.groupBox35.Controls.Add(this.label12);
            this.groupBox35.Controls.Add(this.labelSelectMasterDataLocation);
            this.groupBox35.Controls.Add(this.comboBoxMasterDataSelectLocation);
            this.groupBox35.Controls.Add(this.labelSelectMasterDataTenant);
            this.groupBox35.Controls.Add(this.comboBoxMasterDataSelectTenant);
            this.groupBox35.Location = new System.Drawing.Point(4, 140);
            this.groupBox35.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox35.Name = "groupBox35";
            this.groupBox35.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox35.Size = new System.Drawing.Size(1312, 185);
            this.groupBox35.TabIndex = 10;
            this.groupBox35.TabStop = false;
            this.groupBox35.Text = "Default values for Input.";
            // 
            // dateTimePickerMasterDataExpiryDate
            // 
            this.dateTimePickerMasterDataExpiryDate.Location = new System.Drawing.Point(172, 121);
            this.dateTimePickerMasterDataExpiryDate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dateTimePickerMasterDataExpiryDate.Name = "dateTimePickerMasterDataExpiryDate";
            this.dateTimePickerMasterDataExpiryDate.Size = new System.Drawing.Size(298, 31);
            this.dateTimePickerMasterDataExpiryDate.TabIndex = 21;
            // 
            // numericUpDownMasterDataMachineLocation
            // 
            this.numericUpDownMasterDataMachineLocation.Location = new System.Drawing.Point(584, 79);
            this.numericUpDownMasterDataMachineLocation.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.numericUpDownMasterDataMachineLocation.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDownMasterDataMachineLocation.Name = "numericUpDownMasterDataMachineLocation";
            this.numericUpDownMasterDataMachineLocation.Size = new System.Drawing.Size(150, 31);
            this.numericUpDownMasterDataMachineLocation.TabIndex = 20;
            this.numericUpDownMasterDataMachineLocation.Value = new decimal(new int[] {
            999,
            0,
            0,
            0});
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(390, 79);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(188, 25);
            this.label10.TabIndex = 19;
            this.label10.Text = "Machine Location:";
            // 
            // numericUpDownSubItemQuantity
            // 
            this.numericUpDownSubItemQuantity.Location = new System.Drawing.Point(584, 35);
            this.numericUpDownSubItemQuantity.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.numericUpDownSubItemQuantity.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDownSubItemQuantity.Name = "numericUpDownSubItemQuantity";
            this.numericUpDownSubItemQuantity.Size = new System.Drawing.Size(150, 31);
            this.numericUpDownSubItemQuantity.TabIndex = 18;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(390, 37);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(188, 25);
            this.label15.TabIndex = 17;
            this.label15.Text = "Sub Item Quantity:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(8, 125);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(129, 25);
            this.label14.TabIndex = 15;
            this.label14.Text = "Expiry Date:";
            // 
            // textBoxMasterDataExternalID
            // 
            this.textBoxMasterDataExternalID.Location = new System.Drawing.Point(172, 77);
            this.textBoxMasterDataExternalID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxMasterDataExternalID.Name = "textBoxMasterDataExternalID";
            this.textBoxMasterDataExternalID.Size = new System.Drawing.Size(148, 31);
            this.textBoxMasterDataExternalID.TabIndex = 14;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(8, 81);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(123, 25);
            this.label13.TabIndex = 13;
            this.label13.Text = "External ID:";
            // 
            // textBoxMasterDataBatchNumber
            // 
            this.textBoxMasterDataBatchNumber.Location = new System.Drawing.Point(172, 33);
            this.textBoxMasterDataBatchNumber.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxMasterDataBatchNumber.Name = "textBoxMasterDataBatchNumber";
            this.textBoxMasterDataBatchNumber.Size = new System.Drawing.Size(148, 31);
            this.textBoxMasterDataBatchNumber.TabIndex = 12;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(8, 38);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(154, 25);
            this.label12.TabIndex = 11;
            this.label12.Text = "Batch Number:";
            // 
            // labelSelectMasterDataLocation
            // 
            this.labelSelectMasterDataLocation.AutoSize = true;
            this.labelSelectMasterDataLocation.Location = new System.Drawing.Point(788, 83);
            this.labelSelectMasterDataLocation.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSelectMasterDataLocation.Name = "labelSelectMasterDataLocation";
            this.labelSelectMasterDataLocation.Size = new System.Drawing.Size(166, 25);
            this.labelSelectMasterDataLocation.TabIndex = 10;
            this.labelSelectMasterDataLocation.Text = "Select Location:";
            // 
            // comboBoxMasterDataSelectLocation
            // 
            this.comboBoxMasterDataSelectLocation.DisplayMember = "DisplayText";
            this.comboBoxMasterDataSelectLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMasterDataSelectLocation.FormattingEnabled = true;
            this.comboBoxMasterDataSelectLocation.Location = new System.Drawing.Point(962, 79);
            this.comboBoxMasterDataSelectLocation.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBoxMasterDataSelectLocation.Name = "comboBoxMasterDataSelectLocation";
            this.comboBoxMasterDataSelectLocation.Size = new System.Drawing.Size(180, 33);
            this.comboBoxMasterDataSelectLocation.TabIndex = 8;
            this.comboBoxMasterDataSelectLocation.ValueMember = "DisplayText";
            // 
            // labelSelectMasterDataTenant
            // 
            this.labelSelectMasterDataTenant.AutoSize = true;
            this.labelSelectMasterDataTenant.Location = new System.Drawing.Point(788, 37);
            this.labelSelectMasterDataTenant.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSelectMasterDataTenant.Name = "labelSelectMasterDataTenant";
            this.labelSelectMasterDataTenant.Size = new System.Drawing.Size(151, 25);
            this.labelSelectMasterDataTenant.TabIndex = 9;
            this.labelSelectMasterDataTenant.Text = "Select Tenant:";
            // 
            // comboBoxMasterDataSelectTenant
            // 
            this.comboBoxMasterDataSelectTenant.DisplayMember = "DisplayText";
            this.comboBoxMasterDataSelectTenant.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMasterDataSelectTenant.FormattingEnabled = true;
            this.comboBoxMasterDataSelectTenant.Location = new System.Drawing.Point(962, 31);
            this.comboBoxMasterDataSelectTenant.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBoxMasterDataSelectTenant.Name = "comboBoxMasterDataSelectTenant";
            this.comboBoxMasterDataSelectTenant.Size = new System.Drawing.Size(180, 33);
            this.comboBoxMasterDataSelectTenant.TabIndex = 7;
            this.comboBoxMasterDataSelectTenant.ValueMember = "DisplayText";
            // 
            // groupBox20
            // 
            this.groupBox20.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox20.Controls.Add(this.dataGridViewMasterArticle);
            this.groupBox20.Location = new System.Drawing.Point(4, 335);
            this.groupBox20.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox20.Name = "groupBox20";
            this.groupBox20.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox20.Size = new System.Drawing.Size(1312, 765);
            this.groupBox20.TabIndex = 9;
            this.groupBox20.TabStop = false;
            this.groupBox20.Text = "Master Article List";
            // 
            // dataGridViewMasterArticle
            // 
            this.dataGridViewMasterArticle.AllowUserToAddRows = false;
            this.dataGridViewMasterArticle.AllowUserToDeleteRows = false;
            this.dataGridViewMasterArticle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewMasterArticle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMasterArticle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewMasterArticleLoadPack,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8});
            this.dataGridViewMasterArticle.Location = new System.Drawing.Point(16, 33);
            this.dataGridViewMasterArticle.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridViewMasterArticle.Name = "dataGridViewMasterArticle";
            this.dataGridViewMasterArticle.ReadOnly = true;
            this.dataGridViewMasterArticle.RowHeadersWidth = 20;
            this.dataGridViewMasterArticle.RowTemplate.Height = 24;
            this.dataGridViewMasterArticle.Size = new System.Drawing.Size(1286, 723);
            this.dataGridViewMasterArticle.TabIndex = 1;
            this.dataGridViewMasterArticle.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewMasterArticle_CellContentClick);
            // 
            // dataGridViewMasterArticleLoadPack
            // 
            this.dataGridViewMasterArticleLoadPack.FillWeight = 25F;
            this.dataGridViewMasterArticleLoadPack.HeaderText = "Load Pack";
            this.dataGridViewMasterArticleLoadPack.MinimumWidth = 45;
            this.dataGridViewMasterArticleLoadPack.Name = "dataGridViewMasterArticleLoadPack";
            this.dataGridViewMasterArticleLoadPack.ReadOnly = true;
            this.dataGridViewMasterArticleLoadPack.Width = 200;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Code";
            this.dataGridViewTextBoxColumn1.HeaderText = "Code";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 10;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 200;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn2.FillWeight = 200F;
            this.dataGridViewTextBoxColumn2.HeaderText = "Name";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 10;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 200;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "DosageForm";
            this.dataGridViewTextBoxColumn3.HeaderText = "Dosage Form";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 10;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 200;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "PackagingUnit";
            this.dataGridViewTextBoxColumn4.HeaderText = "Packaging Unit";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 10;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 200;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "MaxSubItemQuantity";
            this.dataGridViewTextBoxColumn5.HeaderText = "MaxSubItemQuantity";
            this.dataGridViewTextBoxColumn5.MinimumWidth = 10;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 200;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "MachineLocation";
            this.dataGridViewTextBoxColumn6.HeaderText = "MachineLocation";
            this.dataGridViewTextBoxColumn6.MinimumWidth = 10;
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 200;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "StockLocationID";
            this.dataGridViewTextBoxColumn7.HeaderText = "StockLocationID";
            this.dataGridViewTextBoxColumn7.MinimumWidth = 10;
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 200;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "TenantID";
            this.dataGridViewTextBoxColumn8.HeaderText = "TenantID";
            this.dataGridViewTextBoxColumn8.MinimumWidth = 10;
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Width = 200;
            // 
            // groupBox19
            // 
            this.groupBox19.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox19.Controls.Add(this.textBoxMasterArticleText);
            this.groupBox19.Controls.Add(this.label8);
            this.groupBox19.Controls.Add(this.radioButtonMasterArticleReject);
            this.groupBox19.Controls.Add(this.radioButtonMasterArticleAccept);
            this.groupBox19.Location = new System.Drawing.Point(4, 4);
            this.groupBox19.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox19.Name = "groupBox19";
            this.groupBox19.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox19.Size = new System.Drawing.Size(1312, 127);
            this.groupBox19.TabIndex = 8;
            this.groupBox19.TabStop = false;
            this.groupBox19.Text = "Auto reply";
            // 
            // textBoxMasterArticleText
            // 
            this.textBoxMasterArticleText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxMasterArticleText.Location = new System.Drawing.Point(132, 75);
            this.textBoxMasterArticleText.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxMasterArticleText.Name = "textBoxMasterArticleText";
            this.textBoxMasterArticleText.Size = new System.Drawing.Size(1168, 31);
            this.textBoxMasterArticleText.TabIndex = 2;
            this.textBoxMasterArticleText.TextChanged += new System.EventHandler(this.radioButtonMasterArticleAccept_CheckedChanged);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 79);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(127, 25);
            this.label8.TabIndex = 4;
            this.label8.Text = "Result Text:";
            // 
            // radioButtonMasterArticleReject
            // 
            this.radioButtonMasterArticleReject.AutoSize = true;
            this.radioButtonMasterArticleReject.Location = new System.Drawing.Point(188, 33);
            this.radioButtonMasterArticleReject.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioButtonMasterArticleReject.Name = "radioButtonMasterArticleReject";
            this.radioButtonMasterArticleReject.Size = new System.Drawing.Size(104, 29);
            this.radioButtonMasterArticleReject.TabIndex = 1;
            this.radioButtonMasterArticleReject.Text = "Reject";
            this.radioButtonMasterArticleReject.UseVisualStyleBackColor = true;
            this.radioButtonMasterArticleReject.CheckedChanged += new System.EventHandler(this.radioButtonMasterArticleAccept_CheckedChanged);
            // 
            // radioButtonMasterArticleAccept
            // 
            this.radioButtonMasterArticleAccept.AutoSize = true;
            this.radioButtonMasterArticleAccept.Checked = true;
            this.radioButtonMasterArticleAccept.Location = new System.Drawing.Point(8, 33);
            this.radioButtonMasterArticleAccept.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioButtonMasterArticleAccept.Name = "radioButtonMasterArticleAccept";
            this.radioButtonMasterArticleAccept.Size = new System.Drawing.Size(109, 29);
            this.radioButtonMasterArticleAccept.TabIndex = 0;
            this.radioButtonMasterArticleAccept.TabStop = true;
            this.radioButtonMasterArticleAccept.Text = "Accept";
            this.radioButtonMasterArticleAccept.UseVisualStyleBackColor = true;
            this.radioButtonMasterArticleAccept.CheckedChanged += new System.EventHandler(this.radioButtonMasterArticleAccept_CheckedChanged);
            // 
            // tabPage11
            // 
            this.tabPage11.Controls.Add(this.groupBox22);
            this.tabPage11.Controls.Add(this.groupBox23);
            this.tabPage11.Location = new System.Drawing.Point(8, 39);
            this.tabPage11.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage11.Name = "tabPage11";
            this.tabPage11.Size = new System.Drawing.Size(1582, 1111);
            this.tabPage11.TabIndex = 10;
            this.tabPage11.Text = "Stock Delivery";
            this.tabPage11.UseVisualStyleBackColor = true;
            // 
            // groupBox22
            // 
            this.groupBox22.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox22.Controls.Add(this.dataGridViewStockDeliveryDetail);
            this.groupBox22.Controls.Add(this.dataGridViewStockDeliveryMaster);
            this.groupBox22.Location = new System.Drawing.Point(4, 140);
            this.groupBox22.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox22.Name = "groupBox22";
            this.groupBox22.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox22.Size = new System.Drawing.Size(1562, 960);
            this.groupBox22.TabIndex = 11;
            this.groupBox22.TabStop = false;
            this.groupBox22.Text = "Stock Delivery List";
            // 
            // dataGridViewStockDeliveryDetail
            // 
            this.dataGridViewStockDeliveryDetail.AllowUserToAddRows = false;
            this.dataGridViewStockDeliveryDetail.AllowUserToDeleteRows = false;
            this.dataGridViewStockDeliveryDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewStockDeliveryDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewStockDeliveryDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnStockDeliveryLoadPack,
            this.ColumnStockDeliveryPackCount,
            this.ColumnStockDeliveryProcessedQuantity,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn11,
            this.dataGridViewTextBoxColumn12,
            this.dataGridViewTextBoxColumn13,
            this.dataGridViewTextBoxColumn14,
            this.ColumnStockDeliveryBatchNumber,
            this.ColumnStockDeliveryExternalID,
            this.ColumnStockDeliveryExpiryDate,
            this.dataGridViewTextBoxColumn15,
            this.dataGridViewTextBoxColumn16,
            this.dataGridViewTextBoxColumn17});
            this.dataGridViewStockDeliveryDetail.Location = new System.Drawing.Point(8, 210);
            this.dataGridViewStockDeliveryDetail.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridViewStockDeliveryDetail.Name = "dataGridViewStockDeliveryDetail";
            this.dataGridViewStockDeliveryDetail.ReadOnly = true;
            this.dataGridViewStockDeliveryDetail.RowHeadersWidth = 20;
            this.dataGridViewStockDeliveryDetail.RowTemplate.Height = 24;
            this.dataGridViewStockDeliveryDetail.Size = new System.Drawing.Size(1544, 740);
            this.dataGridViewStockDeliveryDetail.TabIndex = 2;
            this.dataGridViewStockDeliveryDetail.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewStockDeliveryDetail_CellContentClick);
            // 
            // ColumnStockDeliveryLoadPack
            // 
            this.ColumnStockDeliveryLoadPack.FillWeight = 25F;
            this.ColumnStockDeliveryLoadPack.HeaderText = "Load Pack";
            this.ColumnStockDeliveryLoadPack.MinimumWidth = 45;
            this.ColumnStockDeliveryLoadPack.Name = "ColumnStockDeliveryLoadPack";
            this.ColumnStockDeliveryLoadPack.ReadOnly = true;
            this.ColumnStockDeliveryLoadPack.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnStockDeliveryLoadPack.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnStockDeliveryLoadPack.Width = 200;
            // 
            // ColumnStockDeliveryPackCount
            // 
            this.ColumnStockDeliveryPackCount.DataPropertyName = "RequestedQuantity";
            this.ColumnStockDeliveryPackCount.HeaderText = "RequestedQuantity";
            this.ColumnStockDeliveryPackCount.MinimumWidth = 10;
            this.ColumnStockDeliveryPackCount.Name = "ColumnStockDeliveryPackCount";
            this.ColumnStockDeliveryPackCount.ReadOnly = true;
            this.ColumnStockDeliveryPackCount.Width = 200;
            // 
            // ColumnStockDeliveryProcessedQuantity
            // 
            this.ColumnStockDeliveryProcessedQuantity.DataPropertyName = "ProcessedQuantity";
            this.ColumnStockDeliveryProcessedQuantity.HeaderText = "ProcessedQuantity";
            this.ColumnStockDeliveryProcessedQuantity.MinimumWidth = 10;
            this.ColumnStockDeliveryProcessedQuantity.Name = "ColumnStockDeliveryProcessedQuantity";
            this.ColumnStockDeliveryProcessedQuantity.ReadOnly = true;
            this.ColumnStockDeliveryProcessedQuantity.Width = 200;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "ArticleCode";
            this.dataGridViewTextBoxColumn10.HeaderText = "ArticleCode";
            this.dataGridViewTextBoxColumn10.MinimumWidth = 10;
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            this.dataGridViewTextBoxColumn10.Width = 200;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn11.FillWeight = 200F;
            this.dataGridViewTextBoxColumn11.HeaderText = "Name";
            this.dataGridViewTextBoxColumn11.MinimumWidth = 10;
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            this.dataGridViewTextBoxColumn11.Width = 200;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "DosageForm";
            this.dataGridViewTextBoxColumn12.HeaderText = "Dosage Form";
            this.dataGridViewTextBoxColumn12.MinimumWidth = 10;
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            this.dataGridViewTextBoxColumn12.Width = 200;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "PackagingUnit";
            this.dataGridViewTextBoxColumn13.HeaderText = "Packaging Unit";
            this.dataGridViewTextBoxColumn13.MinimumWidth = 10;
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.ReadOnly = true;
            this.dataGridViewTextBoxColumn13.Width = 200;
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.DataPropertyName = "MaxSubItemQuantity";
            this.dataGridViewTextBoxColumn14.HeaderText = "MaxSubItemQuantity";
            this.dataGridViewTextBoxColumn14.MinimumWidth = 10;
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.ReadOnly = true;
            this.dataGridViewTextBoxColumn14.Width = 200;
            // 
            // ColumnStockDeliveryBatchNumber
            // 
            this.ColumnStockDeliveryBatchNumber.DataPropertyName = "BatchNumber";
            this.ColumnStockDeliveryBatchNumber.HeaderText = "Batch Number";
            this.ColumnStockDeliveryBatchNumber.MinimumWidth = 10;
            this.ColumnStockDeliveryBatchNumber.Name = "ColumnStockDeliveryBatchNumber";
            this.ColumnStockDeliveryBatchNumber.ReadOnly = true;
            this.ColumnStockDeliveryBatchNumber.Width = 200;
            // 
            // ColumnStockDeliveryExternalID
            // 
            this.ColumnStockDeliveryExternalID.DataPropertyName = "ExternalID";
            this.ColumnStockDeliveryExternalID.HeaderText = "ExternalID";
            this.ColumnStockDeliveryExternalID.MinimumWidth = 10;
            this.ColumnStockDeliveryExternalID.Name = "ColumnStockDeliveryExternalID";
            this.ColumnStockDeliveryExternalID.ReadOnly = true;
            this.ColumnStockDeliveryExternalID.Width = 200;
            // 
            // ColumnStockDeliveryExpiryDate
            // 
            this.ColumnStockDeliveryExpiryDate.DataPropertyName = "ExpiryDate";
            this.ColumnStockDeliveryExpiryDate.HeaderText = "ExpiryDate";
            this.ColumnStockDeliveryExpiryDate.MinimumWidth = 10;
            this.ColumnStockDeliveryExpiryDate.Name = "ColumnStockDeliveryExpiryDate";
            this.ColumnStockDeliveryExpiryDate.ReadOnly = true;
            this.ColumnStockDeliveryExpiryDate.Width = 200;
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.DataPropertyName = "MachineLocation";
            this.dataGridViewTextBoxColumn15.HeaderText = "MachineLocation";
            this.dataGridViewTextBoxColumn15.MinimumWidth = 10;
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            this.dataGridViewTextBoxColumn15.ReadOnly = true;
            this.dataGridViewTextBoxColumn15.Width = 200;
            // 
            // dataGridViewTextBoxColumn16
            // 
            this.dataGridViewTextBoxColumn16.DataPropertyName = "StockLocationID";
            this.dataGridViewTextBoxColumn16.HeaderText = "StockLocationID";
            this.dataGridViewTextBoxColumn16.MinimumWidth = 10;
            this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            this.dataGridViewTextBoxColumn16.ReadOnly = true;
            this.dataGridViewTextBoxColumn16.Width = 200;
            // 
            // dataGridViewTextBoxColumn17
            // 
            this.dataGridViewTextBoxColumn17.DataPropertyName = "TenantID";
            this.dataGridViewTextBoxColumn17.HeaderText = "TenantID";
            this.dataGridViewTextBoxColumn17.MinimumWidth = 10;
            this.dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
            this.dataGridViewTextBoxColumn17.ReadOnly = true;
            this.dataGridViewTextBoxColumn17.Width = 200;
            // 
            // dataGridViewStockDeliveryMaster
            // 
            this.dataGridViewStockDeliveryMaster.AllowUserToAddRows = false;
            this.dataGridViewStockDeliveryMaster.AllowUserToDeleteRows = false;
            this.dataGridViewStockDeliveryMaster.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewStockDeliveryMaster.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewStockDeliveryMaster.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn9,
            this.ColumnStockDeliveryMasterState,
            this.ColumnStockDeliveryMasterComplete});
            this.dataGridViewStockDeliveryMaster.Location = new System.Drawing.Point(8, 33);
            this.dataGridViewStockDeliveryMaster.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridViewStockDeliveryMaster.Name = "dataGridViewStockDeliveryMaster";
            this.dataGridViewStockDeliveryMaster.ReadOnly = true;
            this.dataGridViewStockDeliveryMaster.RowHeadersWidth = 20;
            this.dataGridViewStockDeliveryMaster.RowTemplate.Height = 24;
            this.dataGridViewStockDeliveryMaster.Size = new System.Drawing.Size(1544, 167);
            this.dataGridViewStockDeliveryMaster.TabIndex = 1;
            this.dataGridViewStockDeliveryMaster.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewStockDeliveryMaster_CellContentClick);
            this.dataGridViewStockDeliveryMaster.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewStockDeliveryMaster_RowEnter);
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "DeliveryNumber";
            this.dataGridViewTextBoxColumn9.HeaderText = "DeliveryNumber";
            this.dataGridViewTextBoxColumn9.MinimumWidth = 10;
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Width = 125;
            // 
            // ColumnStockDeliveryMasterState
            // 
            this.ColumnStockDeliveryMasterState.DataPropertyName = "State";
            this.ColumnStockDeliveryMasterState.HeaderText = "State";
            this.ColumnStockDeliveryMasterState.MinimumWidth = 10;
            this.ColumnStockDeliveryMasterState.Name = "ColumnStockDeliveryMasterState";
            this.ColumnStockDeliveryMasterState.ReadOnly = true;
            this.ColumnStockDeliveryMasterState.Width = 200;
            // 
            // ColumnStockDeliveryMasterComplete
            // 
            this.ColumnStockDeliveryMasterComplete.HeaderText = "Complete";
            this.ColumnStockDeliveryMasterComplete.MinimumWidth = 10;
            this.ColumnStockDeliveryMasterComplete.Name = "ColumnStockDeliveryMasterComplete";
            this.ColumnStockDeliveryMasterComplete.ReadOnly = true;
            this.ColumnStockDeliveryMasterComplete.Width = 200;
            // 
            // groupBox23
            // 
            this.groupBox23.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox23.Controls.Add(this.textBoxStockDeliveryText);
            this.groupBox23.Controls.Add(this.label9);
            this.groupBox23.Controls.Add(this.radioButtonStockDeliveryReject);
            this.groupBox23.Controls.Add(this.radioButtonStockDeliveryAccept);
            this.groupBox23.Location = new System.Drawing.Point(4, 4);
            this.groupBox23.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox23.Name = "groupBox23";
            this.groupBox23.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox23.Size = new System.Drawing.Size(1562, 127);
            this.groupBox23.TabIndex = 10;
            this.groupBox23.TabStop = false;
            this.groupBox23.Text = "Auto reply";
            // 
            // textBoxStockDeliveryText
            // 
            this.textBoxStockDeliveryText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxStockDeliveryText.Location = new System.Drawing.Point(132, 75);
            this.textBoxStockDeliveryText.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxStockDeliveryText.Name = "textBoxStockDeliveryText";
            this.textBoxStockDeliveryText.Size = new System.Drawing.Size(1418, 31);
            this.textBoxStockDeliveryText.TabIndex = 5;
            this.textBoxStockDeliveryText.TextChanged += new System.EventHandler(this.radioButtonStockDeliveryAccept_CheckedChanged);
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 79);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(127, 25);
            this.label9.TabIndex = 4;
            this.label9.Text = "Result Text:";
            // 
            // radioButtonStockDeliveryReject
            // 
            this.radioButtonStockDeliveryReject.AutoSize = true;
            this.radioButtonStockDeliveryReject.Location = new System.Drawing.Point(188, 33);
            this.radioButtonStockDeliveryReject.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioButtonStockDeliveryReject.Name = "radioButtonStockDeliveryReject";
            this.radioButtonStockDeliveryReject.Size = new System.Drawing.Size(104, 29);
            this.radioButtonStockDeliveryReject.TabIndex = 1;
            this.radioButtonStockDeliveryReject.Text = "Reject";
            this.radioButtonStockDeliveryReject.UseVisualStyleBackColor = true;
            this.radioButtonStockDeliveryReject.CheckedChanged += new System.EventHandler(this.radioButtonStockDeliveryAccept_CheckedChanged);
            // 
            // radioButtonStockDeliveryAccept
            // 
            this.radioButtonStockDeliveryAccept.AutoSize = true;
            this.radioButtonStockDeliveryAccept.Checked = true;
            this.radioButtonStockDeliveryAccept.Location = new System.Drawing.Point(8, 33);
            this.radioButtonStockDeliveryAccept.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioButtonStockDeliveryAccept.Name = "radioButtonStockDeliveryAccept";
            this.radioButtonStockDeliveryAccept.Size = new System.Drawing.Size(109, 29);
            this.radioButtonStockDeliveryAccept.TabIndex = 0;
            this.radioButtonStockDeliveryAccept.TabStop = true;
            this.radioButtonStockDeliveryAccept.Text = "Accept";
            this.radioButtonStockDeliveryAccept.UseVisualStyleBackColor = true;
            this.radioButtonStockDeliveryAccept.CheckedChanged += new System.EventHandler(this.radioButtonStockDeliveryAccept_CheckedChanged);
            // 
            // tabPage9
            // 
            this.tabPage9.Controls.Add(this.groupBox5);
            this.tabPage9.Location = new System.Drawing.Point(8, 39);
            this.tabPage9.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tabPage9.Name = "tabPage9";
            this.tabPage9.Size = new System.Drawing.Size(1332, 1111);
            this.tabPage9.TabIndex = 13;
            this.tabPage9.Text = "Article Info";
            this.tabPage9.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.groupBox8);
            this.groupBox5.Controls.Add(this.groupBox21);
            this.groupBox5.Location = new System.Drawing.Point(4, 4);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox5.Size = new System.Drawing.Size(1312, 1063);
            this.groupBox5.TabIndex = 7;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Article Info";
            // 
            // groupBox8
            // 
            this.groupBox8.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox8.Controls.Add(this.groupBox18);
            this.groupBox8.Location = new System.Drawing.Point(8, 333);
            this.groupBox8.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox8.Size = new System.Drawing.Size(1294, 721);
            this.groupBox8.TabIndex = 1;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Article Info Response";
            // 
            // groupBox18
            // 
            this.groupBox18.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox18.Controls.Add(this.listViewArticleInfoRequested);
            this.groupBox18.Location = new System.Drawing.Point(8, 33);
            this.groupBox18.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox18.Name = "groupBox18";
            this.groupBox18.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox18.Size = new System.Drawing.Size(1276, 681);
            this.groupBox18.TabIndex = 2;
            this.groupBox18.TabStop = false;
            this.groupBox18.Text = "Last Article(s) Requested";
            // 
            // listViewArticleInfoRequested
            // 
            this.listViewArticleInfoRequested.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewArticleInfoRequested.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader11});
            this.listViewArticleInfoRequested.HideSelection = false;
            this.listViewArticleInfoRequested.Location = new System.Drawing.Point(8, 33);
            this.listViewArticleInfoRequested.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listViewArticleInfoRequested.Name = "listViewArticleInfoRequested";
            this.listViewArticleInfoRequested.Size = new System.Drawing.Size(1256, 637);
            this.listViewArticleInfoRequested.TabIndex = 0;
            this.listViewArticleInfoRequested.UseCompatibleStateImageBehavior = false;
            this.listViewArticleInfoRequested.View = System.Windows.Forms.View.Details;
            this.listViewArticleInfoRequested.SizeChanged += new System.EventHandler(this.listViewArticleInfoRequested_SizeChanged);
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "ID";
            this.columnHeader5.Width = 100;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Name";
            this.columnHeader6.Width = 100;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Dosage Form";
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Packaging Unit";
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "MaxSubItemQuantity";
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "SerialNumberSinceExpiryDate";
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Product Code";
            // 
            // groupBox21
            // 
            this.groupBox21.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox21.Controls.Add(this.dataGridViewArticleInfoArticleList);
            this.groupBox21.Controls.Add(this.labelArticleInfoSelectTenant);
            this.groupBox21.Controls.Add(this.comboBoxArticleInfoSelectTenant);
            this.groupBox21.Controls.Add(this.buttonSendArticleInfoRequest);
            this.groupBox21.Location = new System.Drawing.Point(8, 33);
            this.groupBox21.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox21.Name = "groupBox21";
            this.groupBox21.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox21.Size = new System.Drawing.Size(1294, 292);
            this.groupBox21.TabIndex = 0;
            this.groupBox21.TabStop = false;
            this.groupBox21.Text = "Article Info Request";
            // 
            // dataGridViewArticleInfoArticleList
            // 
            this.dataGridViewArticleInfoArticleList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewArticleInfoArticleList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewArticleInfoArticleList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn32,
            this.dataGridViewTextBoxColumn33,
            this.dataGridViewTextBoxColumn34,
            this.dataGridViewTextBoxColumn35,
            this.dataGridViewTextBoxColumn36});
            this.dataGridViewArticleInfoArticleList.Location = new System.Drawing.Point(8, 88);
            this.dataGridViewArticleInfoArticleList.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridViewArticleInfoArticleList.Name = "dataGridViewArticleInfoArticleList";
            this.dataGridViewArticleInfoArticleList.RowHeadersWidth = 20;
            this.dataGridViewArticleInfoArticleList.RowTemplate.Height = 24;
            this.dataGridViewArticleInfoArticleList.Size = new System.Drawing.Size(1278, 196);
            this.dataGridViewArticleInfoArticleList.TabIndex = 23;
            // 
            // dataGridViewTextBoxColumn32
            // 
            this.dataGridViewTextBoxColumn32.DataPropertyName = "ID";
            this.dataGridViewTextBoxColumn32.HeaderText = "ID";
            this.dataGridViewTextBoxColumn32.MinimumWidth = 10;
            this.dataGridViewTextBoxColumn32.Name = "dataGridViewTextBoxColumn32";
            this.dataGridViewTextBoxColumn32.Width = 200;
            // 
            // dataGridViewTextBoxColumn33
            // 
            this.dataGridViewTextBoxColumn33.DataPropertyName = "Depth";
            this.dataGridViewTextBoxColumn33.HeaderText = "Depth";
            this.dataGridViewTextBoxColumn33.MinimumWidth = 10;
            this.dataGridViewTextBoxColumn33.Name = "dataGridViewTextBoxColumn33";
            this.dataGridViewTextBoxColumn33.Width = 200;
            // 
            // dataGridViewTextBoxColumn34
            // 
            this.dataGridViewTextBoxColumn34.DataPropertyName = "Width";
            this.dataGridViewTextBoxColumn34.HeaderText = "Width";
            this.dataGridViewTextBoxColumn34.MinimumWidth = 10;
            this.dataGridViewTextBoxColumn34.Name = "dataGridViewTextBoxColumn34";
            this.dataGridViewTextBoxColumn34.Width = 200;
            // 
            // dataGridViewTextBoxColumn35
            // 
            this.dataGridViewTextBoxColumn35.DataPropertyName = "Height";
            this.dataGridViewTextBoxColumn35.HeaderText = "Height";
            this.dataGridViewTextBoxColumn35.MinimumWidth = 10;
            this.dataGridViewTextBoxColumn35.Name = "dataGridViewTextBoxColumn35";
            this.dataGridViewTextBoxColumn35.Width = 200;
            // 
            // dataGridViewTextBoxColumn36
            // 
            this.dataGridViewTextBoxColumn36.DataPropertyName = "Weight";
            this.dataGridViewTextBoxColumn36.HeaderText = "Weight";
            this.dataGridViewTextBoxColumn36.MinimumWidth = 10;
            this.dataGridViewTextBoxColumn36.Name = "dataGridViewTextBoxColumn36";
            this.dataGridViewTextBoxColumn36.Width = 200;
            // 
            // labelArticleInfoSelectTenant
            // 
            this.labelArticleInfoSelectTenant.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelArticleInfoSelectTenant.AutoSize = true;
            this.labelArticleInfoSelectTenant.Location = new System.Drawing.Point(930, 38);
            this.labelArticleInfoSelectTenant.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelArticleInfoSelectTenant.Name = "labelArticleInfoSelectTenant";
            this.labelArticleInfoSelectTenant.Size = new System.Drawing.Size(151, 25);
            this.labelArticleInfoSelectTenant.TabIndex = 6;
            this.labelArticleInfoSelectTenant.Text = "Select Tenant:";
            // 
            // comboBoxArticleInfoSelectTenant
            // 
            this.comboBoxArticleInfoSelectTenant.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxArticleInfoSelectTenant.DisplayMember = "DisplayText";
            this.comboBoxArticleInfoSelectTenant.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxArticleInfoSelectTenant.FormattingEnabled = true;
            this.comboBoxArticleInfoSelectTenant.Location = new System.Drawing.Point(1102, 33);
            this.comboBoxArticleInfoSelectTenant.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBoxArticleInfoSelectTenant.Name = "comboBoxArticleInfoSelectTenant";
            this.comboBoxArticleInfoSelectTenant.Size = new System.Drawing.Size(180, 33);
            this.comboBoxArticleInfoSelectTenant.TabIndex = 5;
            this.comboBoxArticleInfoSelectTenant.ValueMember = "DisplayText";
            // 
            // buttonSendArticleInfoRequest
            // 
            this.buttonSendArticleInfoRequest.Location = new System.Drawing.Point(8, 31);
            this.buttonSendArticleInfoRequest.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonSendArticleInfoRequest.Name = "buttonSendArticleInfoRequest";
            this.buttonSendArticleInfoRequest.Size = new System.Drawing.Size(150, 38);
            this.buttonSendArticleInfoRequest.TabIndex = 4;
            this.buttonSendArticleInfoRequest.Text = "Send Article Info Request";
            this.buttonSendArticleInfoRequest.UseVisualStyleBackColor = true;
            this.buttonSendArticleInfoRequest.Click += new System.EventHandler(this.buttonSendArticleInfoRequest_Click);
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.groupBox25);
            this.tabPage7.Location = new System.Drawing.Point(8, 39);
            this.tabPage7.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Size = new System.Drawing.Size(1332, 1111);
            this.tabPage7.TabIndex = 6;
            this.tabPage7.Text = "Inventory checking";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // groupBox25
            // 
            this.groupBox25.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox25.Controls.Add(this.splitContainerStock);
            this.groupBox25.Controls.Add(this.groupBox4);
            this.groupBox25.Location = new System.Drawing.Point(4, 4);
            this.groupBox25.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox25.Name = "groupBox25";
            this.groupBox25.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox25.Size = new System.Drawing.Size(1312, 1096);
            this.groupBox25.TabIndex = 12;
            this.groupBox25.TabStop = false;
            this.groupBox25.Text = "Stock Level";
            // 
            // splitContainerStock
            // 
            this.splitContainerStock.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainerStock.Location = new System.Drawing.Point(8, 127);
            this.splitContainerStock.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.splitContainerStock.Name = "splitContainerStock";
            this.splitContainerStock.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerStock.Panel1
            // 
            this.splitContainerStock.Panel1.Controls.Add(this.dataGridViewProductStock);
            // 
            // splitContainerStock.Panel2
            // 
            this.splitContainerStock.Panel2.Controls.Add(this.dataGridViewPackStock);
            this.splitContainerStock.Size = new System.Drawing.Size(1294, 960);
            this.splitContainerStock.SplitterDistance = 332;
            this.splitContainerStock.SplitterWidth = 6;
            this.splitContainerStock.TabIndex = 4;
            // 
            // dataGridViewProductStock
            // 
            this.dataGridViewProductStock.AllowUserToAddRows = false;
            this.dataGridViewProductStock.AllowUserToDeleteRows = false;
            this.dataGridViewProductStock.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewProductStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProductStock.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumnStockListCode,
            this.dataGridViewTextBoxColumnStockListName,
            this.dataGridViewTextBoxColumnStockListDosageForm,
            this.dataGridViewTextBoxColumnStockListPackagingUnit,
            this.dataGridViewTextBoxColumnStockListMaxSubItemQuantity,
            this.dataGridViewTextBoxColumnStockListPackCount,
            this.ColumnSendStockInfoMessage});
            this.dataGridViewProductStock.Location = new System.Drawing.Point(4, 4);
            this.dataGridViewProductStock.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridViewProductStock.Name = "dataGridViewProductStock";
            this.dataGridViewProductStock.ReadOnly = true;
            this.dataGridViewProductStock.RowHeadersWidth = 20;
            this.dataGridViewProductStock.RowTemplate.Height = 24;
            this.dataGridViewProductStock.Size = new System.Drawing.Size(1284, 324);
            this.dataGridViewProductStock.TabIndex = 2;
            this.dataGridViewProductStock.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewProductStock_CellContentClick);
            this.dataGridViewProductStock.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewProductStock_RowEnter);
            this.dataGridViewProductStock.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dataGridViewProductStock_RowsAdded);
            // 
            // dataGridViewTextBoxColumnStockListCode
            // 
            this.dataGridViewTextBoxColumnStockListCode.DataPropertyName = "Code";
            this.dataGridViewTextBoxColumnStockListCode.HeaderText = "Code";
            this.dataGridViewTextBoxColumnStockListCode.MinimumWidth = 10;
            this.dataGridViewTextBoxColumnStockListCode.Name = "dataGridViewTextBoxColumnStockListCode";
            this.dataGridViewTextBoxColumnStockListCode.ReadOnly = true;
            this.dataGridViewTextBoxColumnStockListCode.Width = 125;
            // 
            // dataGridViewTextBoxColumnStockListName
            // 
            this.dataGridViewTextBoxColumnStockListName.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumnStockListName.FillWeight = 300F;
            this.dataGridViewTextBoxColumnStockListName.HeaderText = "Name";
            this.dataGridViewTextBoxColumnStockListName.MinimumWidth = 10;
            this.dataGridViewTextBoxColumnStockListName.Name = "dataGridViewTextBoxColumnStockListName";
            this.dataGridViewTextBoxColumnStockListName.ReadOnly = true;
            this.dataGridViewTextBoxColumnStockListName.Width = 200;
            // 
            // dataGridViewTextBoxColumnStockListDosageForm
            // 
            this.dataGridViewTextBoxColumnStockListDosageForm.DataPropertyName = "DosageForm";
            this.dataGridViewTextBoxColumnStockListDosageForm.HeaderText = "DosageForm";
            this.dataGridViewTextBoxColumnStockListDosageForm.MinimumWidth = 10;
            this.dataGridViewTextBoxColumnStockListDosageForm.Name = "dataGridViewTextBoxColumnStockListDosageForm";
            this.dataGridViewTextBoxColumnStockListDosageForm.ReadOnly = true;
            this.dataGridViewTextBoxColumnStockListDosageForm.Width = 80;
            // 
            // dataGridViewTextBoxColumnStockListPackagingUnit
            // 
            this.dataGridViewTextBoxColumnStockListPackagingUnit.DataPropertyName = "PackagingUnit";
            this.dataGridViewTextBoxColumnStockListPackagingUnit.HeaderText = "PackagingUnit";
            this.dataGridViewTextBoxColumnStockListPackagingUnit.MinimumWidth = 10;
            this.dataGridViewTextBoxColumnStockListPackagingUnit.Name = "dataGridViewTextBoxColumnStockListPackagingUnit";
            this.dataGridViewTextBoxColumnStockListPackagingUnit.ReadOnly = true;
            this.dataGridViewTextBoxColumnStockListPackagingUnit.Width = 80;
            // 
            // dataGridViewTextBoxColumnStockListMaxSubItemQuantity
            // 
            this.dataGridViewTextBoxColumnStockListMaxSubItemQuantity.DataPropertyName = "MaxSubItemQuantity";
            this.dataGridViewTextBoxColumnStockListMaxSubItemQuantity.HeaderText = "MaxSubItemQuantity";
            this.dataGridViewTextBoxColumnStockListMaxSubItemQuantity.MinimumWidth = 10;
            this.dataGridViewTextBoxColumnStockListMaxSubItemQuantity.Name = "dataGridViewTextBoxColumnStockListMaxSubItemQuantity";
            this.dataGridViewTextBoxColumnStockListMaxSubItemQuantity.ReadOnly = true;
            this.dataGridViewTextBoxColumnStockListMaxSubItemQuantity.Width = 200;
            // 
            // dataGridViewTextBoxColumnStockListPackCount
            // 
            this.dataGridViewTextBoxColumnStockListPackCount.HeaderText = "PackCount";
            this.dataGridViewTextBoxColumnStockListPackCount.MinimumWidth = 10;
            this.dataGridViewTextBoxColumnStockListPackCount.Name = "dataGridViewTextBoxColumnStockListPackCount";
            this.dataGridViewTextBoxColumnStockListPackCount.ReadOnly = true;
            this.dataGridViewTextBoxColumnStockListPackCount.Width = 60;
            // 
            // ColumnSendStockInfoMessage
            // 
            this.ColumnSendStockInfoMessage.HeaderText = "Send StockInfoMessage";
            this.ColumnSendStockInfoMessage.MinimumWidth = 10;
            this.ColumnSendStockInfoMessage.Name = "ColumnSendStockInfoMessage";
            this.ColumnSendStockInfoMessage.ReadOnly = true;
            this.ColumnSendStockInfoMessage.Width = 200;
            // 
            // dataGridViewPackStock
            // 
            this.dataGridViewPackStock.AllowUserToAddRows = false;
            this.dataGridViewPackStock.AllowUserToDeleteRows = false;
            this.dataGridViewPackStock.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewPackStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPackStock.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnStockOutputPack,
            this.ColumnStockDeletePack,
            this.dataGridViewTextBoxColumn18,
            this.dataGridViewTextBoxColumn19,
            this.dataGridViewTextBoxColumn20,
            this.dataGridViewTextBoxColumn21,
            this.dataGridViewTextBoxColumn22,
            this.dataGridViewTextBoxColumn23,
            this.dataGridViewTextBoxColumn24,
            this.dataGridViewTextBoxColumn25,
            this.ColumnStockStockLocationID,
            this.ColumnStockMachineLocation,
            this.ColumnStockTenantID});
            this.dataGridViewPackStock.Location = new System.Drawing.Point(4, 4);
            this.dataGridViewPackStock.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridViewPackStock.Name = "dataGridViewPackStock";
            this.dataGridViewPackStock.ReadOnly = true;
            this.dataGridViewPackStock.RowHeadersWidth = 20;
            this.dataGridViewPackStock.RowTemplate.Height = 24;
            this.dataGridViewPackStock.Size = new System.Drawing.Size(1284, 638);
            this.dataGridViewPackStock.TabIndex = 3;
            this.dataGridViewPackStock.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewPackStock_CellContentClick);
            // 
            // ColumnStockOutputPack
            // 
            this.ColumnStockOutputPack.FillWeight = 5F;
            this.ColumnStockOutputPack.HeaderText = "Output pack";
            this.ColumnStockOutputPack.MinimumWidth = 50;
            this.ColumnStockOutputPack.Name = "ColumnStockOutputPack";
            this.ColumnStockOutputPack.ReadOnly = true;
            this.ColumnStockOutputPack.Width = 50;
            // 
            // ColumnStockDeletePack
            // 
            this.ColumnStockDeletePack.FillWeight = 5F;
            this.ColumnStockDeletePack.HeaderText = "Delete Pack";
            this.ColumnStockDeletePack.MinimumWidth = 50;
            this.ColumnStockDeletePack.Name = "ColumnStockDeletePack";
            this.ColumnStockDeletePack.ReadOnly = true;
            this.ColumnStockDeletePack.Width = 50;
            // 
            // dataGridViewTextBoxColumn18
            // 
            this.dataGridViewTextBoxColumn18.DataPropertyName = "ID";
            this.dataGridViewTextBoxColumn18.HeaderText = "ID";
            this.dataGridViewTextBoxColumn18.MinimumWidth = 10;
            this.dataGridViewTextBoxColumn18.Name = "dataGridViewTextBoxColumn18";
            this.dataGridViewTextBoxColumn18.ReadOnly = true;
            this.dataGridViewTextBoxColumn18.Width = 200;
            // 
            // dataGridViewTextBoxColumn19
            // 
            this.dataGridViewTextBoxColumn19.DataPropertyName = "BatchNumber";
            this.dataGridViewTextBoxColumn19.HeaderText = "BatchNumber";
            this.dataGridViewTextBoxColumn19.MinimumWidth = 10;
            this.dataGridViewTextBoxColumn19.Name = "dataGridViewTextBoxColumn19";
            this.dataGridViewTextBoxColumn19.ReadOnly = true;
            this.dataGridViewTextBoxColumn19.Width = 200;
            // 
            // dataGridViewTextBoxColumn20
            // 
            this.dataGridViewTextBoxColumn20.DataPropertyName = "ExternalID";
            this.dataGridViewTextBoxColumn20.HeaderText = "ExternalID";
            this.dataGridViewTextBoxColumn20.MinimumWidth = 10;
            this.dataGridViewTextBoxColumn20.Name = "dataGridViewTextBoxColumn20";
            this.dataGridViewTextBoxColumn20.ReadOnly = true;
            this.dataGridViewTextBoxColumn20.Width = 200;
            // 
            // dataGridViewTextBoxColumn21
            // 
            this.dataGridViewTextBoxColumn21.DataPropertyName = "ExpiryDate";
            this.dataGridViewTextBoxColumn21.HeaderText = "ExpiryDate";
            this.dataGridViewTextBoxColumn21.MinimumWidth = 10;
            this.dataGridViewTextBoxColumn21.Name = "dataGridViewTextBoxColumn21";
            this.dataGridViewTextBoxColumn21.ReadOnly = true;
            this.dataGridViewTextBoxColumn21.Width = 200;
            // 
            // dataGridViewTextBoxColumn22
            // 
            this.dataGridViewTextBoxColumn22.DataPropertyName = "SubItemQuantity";
            this.dataGridViewTextBoxColumn22.HeaderText = "SubItemQuantity";
            this.dataGridViewTextBoxColumn22.MinimumWidth = 10;
            this.dataGridViewTextBoxColumn22.Name = "dataGridViewTextBoxColumn22";
            this.dataGridViewTextBoxColumn22.ReadOnly = true;
            this.dataGridViewTextBoxColumn22.Width = 200;
            // 
            // dataGridViewTextBoxColumn23
            // 
            this.dataGridViewTextBoxColumn23.DataPropertyName = "Depth";
            this.dataGridViewTextBoxColumn23.HeaderText = "Depth";
            this.dataGridViewTextBoxColumn23.MinimumWidth = 10;
            this.dataGridViewTextBoxColumn23.Name = "dataGridViewTextBoxColumn23";
            this.dataGridViewTextBoxColumn23.ReadOnly = true;
            this.dataGridViewTextBoxColumn23.Width = 200;
            // 
            // dataGridViewTextBoxColumn24
            // 
            this.dataGridViewTextBoxColumn24.DataPropertyName = "Height";
            this.dataGridViewTextBoxColumn24.HeaderText = "Height";
            this.dataGridViewTextBoxColumn24.MinimumWidth = 10;
            this.dataGridViewTextBoxColumn24.Name = "dataGridViewTextBoxColumn24";
            this.dataGridViewTextBoxColumn24.ReadOnly = true;
            this.dataGridViewTextBoxColumn24.Width = 200;
            // 
            // dataGridViewTextBoxColumn25
            // 
            this.dataGridViewTextBoxColumn25.DataPropertyName = "Width";
            this.dataGridViewTextBoxColumn25.HeaderText = "Width";
            this.dataGridViewTextBoxColumn25.MinimumWidth = 10;
            this.dataGridViewTextBoxColumn25.Name = "dataGridViewTextBoxColumn25";
            this.dataGridViewTextBoxColumn25.ReadOnly = true;
            this.dataGridViewTextBoxColumn25.Width = 200;
            // 
            // ColumnStockStockLocationID
            // 
            this.ColumnStockStockLocationID.DataPropertyName = "StockLocationID";
            this.ColumnStockStockLocationID.HeaderText = "StockLocationID";
            this.ColumnStockStockLocationID.MinimumWidth = 10;
            this.ColumnStockStockLocationID.Name = "ColumnStockStockLocationID";
            this.ColumnStockStockLocationID.ReadOnly = true;
            this.ColumnStockStockLocationID.Width = 200;
            // 
            // ColumnStockMachineLocation
            // 
            this.ColumnStockMachineLocation.DataPropertyName = "MachineLocation";
            this.ColumnStockMachineLocation.HeaderText = "MachineLocation";
            this.ColumnStockMachineLocation.MinimumWidth = 10;
            this.ColumnStockMachineLocation.Name = "ColumnStockMachineLocation";
            this.ColumnStockMachineLocation.ReadOnly = true;
            this.ColumnStockMachineLocation.Width = 200;
            // 
            // ColumnStockTenantID
            // 
            this.ColumnStockTenantID.DataPropertyName = "TenantID";
            this.ColumnStockTenantID.HeaderText = "TenantID";
            this.ColumnStockTenantID.MinimumWidth = 10;
            this.ColumnStockTenantID.Name = "ColumnStockTenantID";
            this.ColumnStockTenantID.ReadOnly = true;
            this.ColumnStockTenantID.Width = 200;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.buttonClearStock);
            this.groupBox4.Controls.Add(this.buttonLoadStock);
            this.groupBox4.Location = new System.Drawing.Point(8, 33);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox4.Size = new System.Drawing.Size(1294, 85);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Stock Management";
            // 
            // buttonClearStock
            // 
            this.buttonClearStock.Location = new System.Drawing.Point(198, 33);
            this.buttonClearStock.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonClearStock.Name = "buttonClearStock";
            this.buttonClearStock.Size = new System.Drawing.Size(180, 37);
            this.buttonClearStock.TabIndex = 1;
            this.buttonClearStock.Text = "Clear Stock";
            this.buttonClearStock.UseVisualStyleBackColor = true;
            this.buttonClearStock.Click += new System.EventHandler(this.buttonClearStock_Click);
            // 
            // buttonLoadStock
            // 
            this.buttonLoadStock.Location = new System.Drawing.Point(8, 33);
            this.buttonLoadStock.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonLoadStock.Name = "buttonLoadStock";
            this.buttonLoadStock.Size = new System.Drawing.Size(180, 37);
            this.buttonLoadStock.TabIndex = 0;
            this.buttonLoadStock.Text = "Load Stock...";
            this.buttonLoadStock.UseVisualStyleBackColor = true;
            this.buttonLoadStock.Click += new System.EventHandler(this.buttonLoadStock_Click);
            // 
            // tabPage8
            // 
            this.tabPage8.Controls.Add(this.groupBox29);
            this.tabPage8.Controls.Add(this.groupBox28);
            this.tabPage8.Controls.Add(this.groupBox27);
            this.tabPage8.Location = new System.Drawing.Point(8, 39);
            this.tabPage8.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Size = new System.Drawing.Size(1332, 1111);
            this.tabPage8.TabIndex = 7;
            this.tabPage8.Text = "Stock Output";
            this.tabPage8.UseVisualStyleBackColor = true;
            // 
            // groupBox29
            // 
            this.groupBox29.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox29.Controls.Add(this.groupBox32);
            this.groupBox29.Controls.Add(this.groupBox31);
            this.groupBox29.Controls.Add(this.groupBox30);
            this.groupBox29.Location = new System.Drawing.Point(4, 140);
            this.groupBox29.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox29.Name = "groupBox29";
            this.groupBox29.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox29.Size = new System.Drawing.Size(1312, 960);
            this.groupBox29.TabIndex = 13;
            this.groupBox29.TabStop = false;
            this.groupBox29.Text = "Output requested";
            // 
            // groupBox32
            // 
            this.groupBox32.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox32.Controls.Add(this.dataGridViewOutputDispensedPack);
            this.groupBox32.Location = new System.Drawing.Point(8, 521);
            this.groupBox32.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox32.Name = "groupBox32";
            this.groupBox32.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox32.Size = new System.Drawing.Size(1294, 423);
            this.groupBox32.TabIndex = 7;
            this.groupBox32.TabStop = false;
            this.groupBox32.Text = "Dispensed Packs";
            // 
            // dataGridViewOutputDispensedPack
            // 
            this.dataGridViewOutputDispensedPack.AllowUserToAddRows = false;
            this.dataGridViewOutputDispensedPack.AllowUserToDeleteRows = false;
            this.dataGridViewOutputDispensedPack.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewOutputDispensedPack.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOutputDispensedPack.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn26,
            this.dataGridViewTextBoxColumn27,
            this.dataGridViewTextBoxColumn28,
            this.dataGridViewTextBoxColumn29,
            this.dataGridViewTextBoxColumn30,
            this.dataGridViewTextBoxColumn31});
            this.dataGridViewOutputDispensedPack.Location = new System.Drawing.Point(10, 33);
            this.dataGridViewOutputDispensedPack.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridViewOutputDispensedPack.Name = "dataGridViewOutputDispensedPack";
            this.dataGridViewOutputDispensedPack.ReadOnly = true;
            this.dataGridViewOutputDispensedPack.RowHeadersWidth = 20;
            this.dataGridViewOutputDispensedPack.RowTemplate.Height = 24;
            this.dataGridViewOutputDispensedPack.Size = new System.Drawing.Size(1272, 377);
            this.dataGridViewOutputDispensedPack.TabIndex = 3;
            // 
            // dataGridViewTextBoxColumn26
            // 
            this.dataGridViewTextBoxColumn26.DataPropertyName = "ID";
            this.dataGridViewTextBoxColumn26.HeaderText = "Index";
            this.dataGridViewTextBoxColumn26.MinimumWidth = 10;
            this.dataGridViewTextBoxColumn26.Name = "dataGridViewTextBoxColumn26";
            this.dataGridViewTextBoxColumn26.ReadOnly = true;
            this.dataGridViewTextBoxColumn26.Width = 90;
            // 
            // dataGridViewTextBoxColumn27
            // 
            this.dataGridViewTextBoxColumn27.DataPropertyName = "ArticleCode";
            this.dataGridViewTextBoxColumn27.HeaderText = "Article";
            this.dataGridViewTextBoxColumn27.MinimumWidth = 10;
            this.dataGridViewTextBoxColumn27.Name = "dataGridViewTextBoxColumn27";
            this.dataGridViewTextBoxColumn27.ReadOnly = true;
            this.dataGridViewTextBoxColumn27.Width = 90;
            // 
            // dataGridViewTextBoxColumn28
            // 
            this.dataGridViewTextBoxColumn28.DataPropertyName = "BatchNumber";
            this.dataGridViewTextBoxColumn28.HeaderText = "Batch";
            this.dataGridViewTextBoxColumn28.MinimumWidth = 10;
            this.dataGridViewTextBoxColumn28.Name = "dataGridViewTextBoxColumn28";
            this.dataGridViewTextBoxColumn28.ReadOnly = true;
            this.dataGridViewTextBoxColumn28.Width = 90;
            // 
            // dataGridViewTextBoxColumn29
            // 
            this.dataGridViewTextBoxColumn29.DataPropertyName = "ExternalID";
            this.dataGridViewTextBoxColumn29.HeaderText = "ExternalID";
            this.dataGridViewTextBoxColumn29.MinimumWidth = 10;
            this.dataGridViewTextBoxColumn29.Name = "dataGridViewTextBoxColumn29";
            this.dataGridViewTextBoxColumn29.ReadOnly = true;
            this.dataGridViewTextBoxColumn29.Width = 90;
            // 
            // dataGridViewTextBoxColumn30
            // 
            this.dataGridViewTextBoxColumn30.DataPropertyName = "ExpiryDate";
            this.dataGridViewTextBoxColumn30.HeaderText = "ExpiryDate";
            this.dataGridViewTextBoxColumn30.MinimumWidth = 10;
            this.dataGridViewTextBoxColumn30.Name = "dataGridViewTextBoxColumn30";
            this.dataGridViewTextBoxColumn30.ReadOnly = true;
            this.dataGridViewTextBoxColumn30.Width = 90;
            // 
            // dataGridViewTextBoxColumn31
            // 
            this.dataGridViewTextBoxColumn31.DataPropertyName = "PackID";
            this.dataGridViewTextBoxColumn31.HeaderText = "PackID";
            this.dataGridViewTextBoxColumn31.MinimumWidth = 10;
            this.dataGridViewTextBoxColumn31.Name = "dataGridViewTextBoxColumn31";
            this.dataGridViewTextBoxColumn31.ReadOnly = true;
            this.dataGridViewTextBoxColumn31.Width = 90;
            // 
            // groupBox31
            // 
            this.groupBox31.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox31.Controls.Add(this.dataGridViewOutputOrderItems);
            this.groupBox31.Location = new System.Drawing.Point(12, 262);
            this.groupBox31.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox31.Name = "groupBox31";
            this.groupBox31.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox31.Size = new System.Drawing.Size(1292, 250);
            this.groupBox31.TabIndex = 6;
            this.groupBox31.TabStop = false;
            this.groupBox31.Text = "Order Items";
            // 
            // dataGridViewOutputOrderItems
            // 
            this.dataGridViewOutputOrderItems.AllowUserToAddRows = false;
            this.dataGridViewOutputOrderItems.AllowUserToDeleteRows = false;
            this.dataGridViewOutputOrderItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewOutputOrderItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOutputOrderItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnOutputItemIndex,
            this.ColumnOutputItemArticleCode,
            this.ColumnOutputItemBatch,
            this.ColumnOutputItemExternalID,
            this.ColumnOutputItemExpiryDate,
            this.ColumnOutputItemPackID,
            this.ColumnOutputItemRequestedQuantity,
            this.ColumnOutputItemRequestedSubItemQuantity});
            this.dataGridViewOutputOrderItems.Location = new System.Drawing.Point(8, 33);
            this.dataGridViewOutputOrderItems.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridViewOutputOrderItems.Name = "dataGridViewOutputOrderItems";
            this.dataGridViewOutputOrderItems.ReadOnly = true;
            this.dataGridViewOutputOrderItems.RowHeadersWidth = 20;
            this.dataGridViewOutputOrderItems.RowTemplate.Height = 24;
            this.dataGridViewOutputOrderItems.Size = new System.Drawing.Size(1272, 208);
            this.dataGridViewOutputOrderItems.TabIndex = 2;
            this.dataGridViewOutputOrderItems.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewOutputOrderItems_RowEnter);
            // 
            // ColumnOutputItemIndex
            // 
            this.ColumnOutputItemIndex.DataPropertyName = "ID";
            this.ColumnOutputItemIndex.HeaderText = "Index";
            this.ColumnOutputItemIndex.MinimumWidth = 10;
            this.ColumnOutputItemIndex.Name = "ColumnOutputItemIndex";
            this.ColumnOutputItemIndex.ReadOnly = true;
            this.ColumnOutputItemIndex.Width = 90;
            // 
            // ColumnOutputItemArticleCode
            // 
            this.ColumnOutputItemArticleCode.DataPropertyName = "ArticleCode";
            this.ColumnOutputItemArticleCode.HeaderText = "Article";
            this.ColumnOutputItemArticleCode.MinimumWidth = 10;
            this.ColumnOutputItemArticleCode.Name = "ColumnOutputItemArticleCode";
            this.ColumnOutputItemArticleCode.ReadOnly = true;
            this.ColumnOutputItemArticleCode.Width = 90;
            // 
            // ColumnOutputItemBatch
            // 
            this.ColumnOutputItemBatch.DataPropertyName = "BatchNumber";
            this.ColumnOutputItemBatch.HeaderText = "Batch";
            this.ColumnOutputItemBatch.MinimumWidth = 10;
            this.ColumnOutputItemBatch.Name = "ColumnOutputItemBatch";
            this.ColumnOutputItemBatch.ReadOnly = true;
            this.ColumnOutputItemBatch.Width = 90;
            // 
            // ColumnOutputItemExternalID
            // 
            this.ColumnOutputItemExternalID.DataPropertyName = "ExternalID";
            this.ColumnOutputItemExternalID.HeaderText = "ExternalID";
            this.ColumnOutputItemExternalID.MinimumWidth = 10;
            this.ColumnOutputItemExternalID.Name = "ColumnOutputItemExternalID";
            this.ColumnOutputItemExternalID.ReadOnly = true;
            this.ColumnOutputItemExternalID.Width = 90;
            // 
            // ColumnOutputItemExpiryDate
            // 
            this.ColumnOutputItemExpiryDate.DataPropertyName = "ExpiryDate";
            this.ColumnOutputItemExpiryDate.HeaderText = "ExpiryDate";
            this.ColumnOutputItemExpiryDate.MinimumWidth = 10;
            this.ColumnOutputItemExpiryDate.Name = "ColumnOutputItemExpiryDate";
            this.ColumnOutputItemExpiryDate.ReadOnly = true;
            this.ColumnOutputItemExpiryDate.Width = 90;
            // 
            // ColumnOutputItemPackID
            // 
            this.ColumnOutputItemPackID.DataPropertyName = "PackID";
            this.ColumnOutputItemPackID.HeaderText = "PackID";
            this.ColumnOutputItemPackID.MinimumWidth = 10;
            this.ColumnOutputItemPackID.Name = "ColumnOutputItemPackID";
            this.ColumnOutputItemPackID.ReadOnly = true;
            this.ColumnOutputItemPackID.Width = 90;
            // 
            // ColumnOutputItemRequestedQuantity
            // 
            this.ColumnOutputItemRequestedQuantity.DataPropertyName = "RequestedQuantity";
            this.ColumnOutputItemRequestedQuantity.HeaderText = "RequestedQuantity";
            this.ColumnOutputItemRequestedQuantity.MinimumWidth = 10;
            this.ColumnOutputItemRequestedQuantity.Name = "ColumnOutputItemRequestedQuantity";
            this.ColumnOutputItemRequestedQuantity.ReadOnly = true;
            this.ColumnOutputItemRequestedQuantity.Width = 90;
            // 
            // ColumnOutputItemRequestedSubItemQuantity
            // 
            this.ColumnOutputItemRequestedSubItemQuantity.DataPropertyName = "RequestedSubItemQuantity";
            this.ColumnOutputItemRequestedSubItemQuantity.HeaderText = "RequestedSubItemQuantity";
            this.ColumnOutputItemRequestedSubItemQuantity.MinimumWidth = 10;
            this.ColumnOutputItemRequestedSubItemQuantity.Name = "ColumnOutputItemRequestedSubItemQuantity";
            this.ColumnOutputItemRequestedSubItemQuantity.ReadOnly = true;
            this.ColumnOutputItemRequestedSubItemQuantity.Width = 90;
            // 
            // groupBox30
            // 
            this.groupBox30.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox30.Controls.Add(this.dataGridViewOutputOrderList);
            this.groupBox30.Location = new System.Drawing.Point(8, 33);
            this.groupBox30.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox30.Name = "groupBox30";
            this.groupBox30.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox30.Size = new System.Drawing.Size(1294, 219);
            this.groupBox30.TabIndex = 5;
            this.groupBox30.TabStop = false;
            this.groupBox30.Text = "Orders";
            // 
            // dataGridViewOutputOrderList
            // 
            this.dataGridViewOutputOrderList.AllowUserToAddRows = false;
            this.dataGridViewOutputOrderList.AllowUserToDeleteRows = false;
            this.dataGridViewOutputOrderList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewOutputOrderList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOutputOrderList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnOutputOrderID,
            this.ColumnOutputOrderPriority,
            this.ColumnColumnOutputNumber,
            this.ColumnOutputOrderPoint,
            this.ColumnOutputOrderBox,
            this.ColumnOutputOrderState,
            this.ColumnOutputOrderTentantID});
            this.dataGridViewOutputOrderList.Location = new System.Drawing.Point(8, 33);
            this.dataGridViewOutputOrderList.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridViewOutputOrderList.Name = "dataGridViewOutputOrderList";
            this.dataGridViewOutputOrderList.ReadOnly = true;
            this.dataGridViewOutputOrderList.RowHeadersWidth = 20;
            this.dataGridViewOutputOrderList.RowTemplate.Height = 24;
            this.dataGridViewOutputOrderList.Size = new System.Drawing.Size(1276, 177);
            this.dataGridViewOutputOrderList.TabIndex = 2;
            this.dataGridViewOutputOrderList.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewOutputOrderList_RowEnter);
            // 
            // ColumnOutputOrderID
            // 
            this.ColumnOutputOrderID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnOutputOrderID.DataPropertyName = "ID";
            this.ColumnOutputOrderID.HeaderText = "ID";
            this.ColumnOutputOrderID.MinimumWidth = 10;
            this.ColumnOutputOrderID.Name = "ColumnOutputOrderID";
            this.ColumnOutputOrderID.ReadOnly = true;
            // 
            // ColumnOutputOrderPriority
            // 
            this.ColumnOutputOrderPriority.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnOutputOrderPriority.DataPropertyName = "Priority";
            this.ColumnOutputOrderPriority.HeaderText = "Priority";
            this.ColumnOutputOrderPriority.MinimumWidth = 10;
            this.ColumnOutputOrderPriority.Name = "ColumnOutputOrderPriority";
            this.ColumnOutputOrderPriority.ReadOnly = true;
            // 
            // ColumnColumnOutputNumber
            // 
            this.ColumnColumnOutputNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnColumnOutputNumber.DataPropertyName = "Output";
            this.ColumnColumnOutputNumber.HeaderText = "Output";
            this.ColumnColumnOutputNumber.MinimumWidth = 10;
            this.ColumnColumnOutputNumber.Name = "ColumnColumnOutputNumber";
            this.ColumnColumnOutputNumber.ReadOnly = true;
            // 
            // ColumnOutputOrderPoint
            // 
            this.ColumnOutputOrderPoint.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnOutputOrderPoint.DataPropertyName = "Point";
            this.ColumnOutputOrderPoint.HeaderText = "Point";
            this.ColumnOutputOrderPoint.MinimumWidth = 10;
            this.ColumnOutputOrderPoint.Name = "ColumnOutputOrderPoint";
            this.ColumnOutputOrderPoint.ReadOnly = true;
            // 
            // ColumnOutputOrderBox
            // 
            this.ColumnOutputOrderBox.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnOutputOrderBox.DataPropertyName = "Box";
            this.ColumnOutputOrderBox.HeaderText = "Box";
            this.ColumnOutputOrderBox.MinimumWidth = 10;
            this.ColumnOutputOrderBox.Name = "ColumnOutputOrderBox";
            this.ColumnOutputOrderBox.ReadOnly = true;
            // 
            // ColumnOutputOrderState
            // 
            this.ColumnOutputOrderState.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnOutputOrderState.DataPropertyName = "State";
            this.ColumnOutputOrderState.HeaderText = "State";
            this.ColumnOutputOrderState.MinimumWidth = 10;
            this.ColumnOutputOrderState.Name = "ColumnOutputOrderState";
            this.ColumnOutputOrderState.ReadOnly = true;
            // 
            // ColumnOutputOrderTentantID
            // 
            this.ColumnOutputOrderTentantID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnOutputOrderTentantID.DataPropertyName = "TenantID";
            this.ColumnOutputOrderTentantID.HeaderText = "Tenant ID";
            this.ColumnOutputOrderTentantID.MinimumWidth = 10;
            this.ColumnOutputOrderTentantID.Name = "ColumnOutputOrderTentantID";
            this.ColumnOutputOrderTentantID.ReadOnly = true;
            // 
            // groupBox28
            // 
            this.groupBox28.Controls.Add(this.checkBoxOutputGenerateBoxID);
            this.groupBox28.Controls.Add(this.checkBoxOutputAutoReply);
            this.groupBox28.Location = new System.Drawing.Point(4, 4);
            this.groupBox28.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox28.Name = "groupBox28";
            this.groupBox28.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox28.Size = new System.Drawing.Size(242, 127);
            this.groupBox28.TabIndex = 11;
            this.groupBox28.TabStop = false;
            this.groupBox28.Text = "Output Reply";
            // 
            // checkBoxOutputGenerateBoxID
            // 
            this.checkBoxOutputGenerateBoxID.AutoSize = true;
            this.checkBoxOutputGenerateBoxID.Location = new System.Drawing.Point(8, 75);
            this.checkBoxOutputGenerateBoxID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxOutputGenerateBoxID.Name = "checkBoxOutputGenerateBoxID";
            this.checkBoxOutputGenerateBoxID.Size = new System.Drawing.Size(199, 29);
            this.checkBoxOutputGenerateBoxID.TabIndex = 1;
            this.checkBoxOutputGenerateBoxID.Text = "Generate Box Id";
            this.checkBoxOutputGenerateBoxID.UseVisualStyleBackColor = true;
            this.checkBoxOutputGenerateBoxID.CheckedChanged += new System.EventHandler(this.checkBoxOutputGenerateBoxID_CheckedChanged);
            // 
            // checkBoxOutputAutoReply
            // 
            this.checkBoxOutputAutoReply.AutoSize = true;
            this.checkBoxOutputAutoReply.Checked = true;
            this.checkBoxOutputAutoReply.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxOutputAutoReply.Location = new System.Drawing.Point(8, 33);
            this.checkBoxOutputAutoReply.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxOutputAutoReply.Name = "checkBoxOutputAutoReply";
            this.checkBoxOutputAutoReply.Size = new System.Drawing.Size(150, 29);
            this.checkBoxOutputAutoReply.TabIndex = 0;
            this.checkBoxOutputAutoReply.Text = "Auto-Reply";
            this.checkBoxOutputAutoReply.UseVisualStyleBackColor = true;
            this.checkBoxOutputAutoReply.CheckedChanged += new System.EventHandler(this.checkBoxOutputAutoReply_CheckedChanged);
            // 
            // groupBox27
            // 
            this.groupBox27.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox27.Controls.Add(this.radioButtonStockOutputUpdateStock);
            this.groupBox27.Controls.Add(this.radioButtonStockOutputFrozenStock);
            this.groupBox27.Controls.Add(this.radioButtonStockOutputAlwaysIncomplete);
            this.groupBox27.Controls.Add(this.radioButtonStockOutputAlwaysComplete);
            this.groupBox27.Location = new System.Drawing.Point(256, 4);
            this.groupBox27.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox27.Name = "groupBox27";
            this.groupBox27.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox27.Size = new System.Drawing.Size(1060, 127);
            this.groupBox27.TabIndex = 12;
            this.groupBox27.TabStop = false;
            this.groupBox27.Text = "Output Result";
            // 
            // radioButtonStockOutputUpdateStock
            // 
            this.radioButtonStockOutputUpdateStock.AutoSize = true;
            this.radioButtonStockOutputUpdateStock.Location = new System.Drawing.Point(308, 75);
            this.radioButtonStockOutputUpdateStock.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioButtonStockOutputUpdateStock.Name = "radioButtonStockOutputUpdateStock";
            this.radioButtonStockOutputUpdateStock.Size = new System.Drawing.Size(377, 29);
            this.radioButtonStockOutputUpdateStock.TabIndex = 3;
            this.radioButtonStockOutputUpdateStock.Text = "According to Stock (updates stock)";
            this.radioButtonStockOutputUpdateStock.UseVisualStyleBackColor = true;
            this.radioButtonStockOutputUpdateStock.CheckedChanged += new System.EventHandler(this.radioButtonStockOutputAlwaysComplete_CheckedChanged);
            // 
            // radioButtonStockOutputFrozenStock
            // 
            this.radioButtonStockOutputFrozenStock.AutoSize = true;
            this.radioButtonStockOutputFrozenStock.Location = new System.Drawing.Point(308, 33);
            this.radioButtonStockOutputFrozenStock.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioButtonStockOutputFrozenStock.Name = "radioButtonStockOutputFrozenStock";
            this.radioButtonStockOutputFrozenStock.Size = new System.Drawing.Size(360, 29);
            this.radioButtonStockOutputFrozenStock.TabIndex = 2;
            this.radioButtonStockOutputFrozenStock.Text = "According to Stock (frozen stock)";
            this.radioButtonStockOutputFrozenStock.UseVisualStyleBackColor = true;
            this.radioButtonStockOutputFrozenStock.CheckedChanged += new System.EventHandler(this.radioButtonStockOutputAlwaysComplete_CheckedChanged);
            // 
            // radioButtonStockOutputAlwaysIncomplete
            // 
            this.radioButtonStockOutputAlwaysIncomplete.AutoSize = true;
            this.radioButtonStockOutputAlwaysIncomplete.Location = new System.Drawing.Point(8, 75);
            this.radioButtonStockOutputAlwaysIncomplete.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioButtonStockOutputAlwaysIncomplete.Name = "radioButtonStockOutputAlwaysIncomplete";
            this.radioButtonStockOutputAlwaysIncomplete.Size = new System.Drawing.Size(221, 29);
            this.radioButtonStockOutputAlwaysIncomplete.TabIndex = 1;
            this.radioButtonStockOutputAlwaysIncomplete.Text = "Always Incomplete";
            this.radioButtonStockOutputAlwaysIncomplete.UseVisualStyleBackColor = true;
            this.radioButtonStockOutputAlwaysIncomplete.CheckedChanged += new System.EventHandler(this.radioButtonStockOutputAlwaysComplete_CheckedChanged);
            // 
            // radioButtonStockOutputAlwaysComplete
            // 
            this.radioButtonStockOutputAlwaysComplete.AutoSize = true;
            this.radioButtonStockOutputAlwaysComplete.Checked = true;
            this.radioButtonStockOutputAlwaysComplete.Location = new System.Drawing.Point(8, 33);
            this.radioButtonStockOutputAlwaysComplete.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioButtonStockOutputAlwaysComplete.Name = "radioButtonStockOutputAlwaysComplete";
            this.radioButtonStockOutputAlwaysComplete.Size = new System.Drawing.Size(208, 29);
            this.radioButtonStockOutputAlwaysComplete.TabIndex = 0;
            this.radioButtonStockOutputAlwaysComplete.TabStop = true;
            this.radioButtonStockOutputAlwaysComplete.Text = "Always Complete";
            this.radioButtonStockOutputAlwaysComplete.UseVisualStyleBackColor = true;
            this.radioButtonStockOutputAlwaysComplete.CheckedChanged += new System.EventHandler(this.radioButtonStockOutputAlwaysComplete_CheckedChanged);
            // 
            // tabPage12
            // 
            this.tabPage12.Controls.Add(this.splitContainerLog);
            this.tabPage12.Location = new System.Drawing.Point(8, 39);
            this.tabPage12.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage12.Name = "tabPage12";
            this.tabPage12.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage12.Size = new System.Drawing.Size(1332, 1111);
            this.tabPage12.TabIndex = 11;
            this.tabPage12.Text = "Log";
            this.tabPage12.UseVisualStyleBackColor = true;
            // 
            // splitContainerLog
            // 
            this.splitContainerLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainerLog.Location = new System.Drawing.Point(8, 10);
            this.splitContainerLog.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.splitContainerLog.Name = "splitContainerLog";
            this.splitContainerLog.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerLog.Panel1
            // 
            this.splitContainerLog.Panel1.Controls.Add(this.listViewWwks2Log);
            // 
            // splitContainerLog.Panel2
            // 
            this.splitContainerLog.Panel2.Controls.Add(this.richTextBoxDetailLog);
            this.splitContainerLog.Size = new System.Drawing.Size(1252, 1062);
            this.splitContainerLog.SplitterDistance = 479;
            this.splitContainerLog.SplitterWidth = 6;
            this.splitContainerLog.TabIndex = 5;
            // 
            // listViewWwks2Log
            // 
            this.listViewWwks2Log.AllowColumnReorder = true;
            this.listViewWwks2Log.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader3,
            this.columnHeader2});
            this.listViewWwks2Log.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewWwks2Log.FullRowSelect = true;
            this.listViewWwks2Log.HideSelection = false;
            this.listViewWwks2Log.Location = new System.Drawing.Point(0, 0);
            this.listViewWwks2Log.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.listViewWwks2Log.Name = "listViewWwks2Log";
            this.listViewWwks2Log.Size = new System.Drawing.Size(1252, 479);
            this.listViewWwks2Log.TabIndex = 5;
            this.listViewWwks2Log.UseCompatibleStateImageBehavior = false;
            this.listViewWwks2Log.View = System.Windows.Forms.View.Details;
            this.listViewWwks2Log.SelectedIndexChanged += new System.EventHandler(this.listViewWwks2Log_SelectedIndexChanged);
            this.listViewWwks2Log.SizeChanged += new System.EventHandler(this.listViewWwks2Log_SizeChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Time";
            this.columnHeader1.Width = 120;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Direction";
            this.columnHeader3.Width = 70;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Message";
            this.columnHeader2.Width = 570;
            // 
            // richTextBoxDetailLog
            // 
            this.richTextBoxDetailLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxDetailLog.Location = new System.Drawing.Point(0, 0);
            this.richTextBoxDetailLog.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.richTextBoxDetailLog.Name = "richTextBoxDetailLog";
            this.richTextBoxDetailLog.ReadOnly = true;
            this.richTextBoxDetailLog.Size = new System.Drawing.Size(1252, 577);
            this.richTextBoxDetailLog.TabIndex = 5;
            this.richTextBoxDetailLog.Text = "";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupRawXml);
            this.tabPage2.Location = new System.Drawing.Point(8, 39);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(1332, 1111);
            this.tabPage2.TabIndex = 12;
            this.tabPage2.Text = "Raw XML";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupRawXml
            // 
            this.groupRawXml.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupRawXml.Controls.Add(this.btnClearRawXml);
            this.groupRawXml.Controls.Add(this.btnSendRawXml);
            this.groupRawXml.Controls.Add(this.txtRawXml);
            this.groupRawXml.Location = new System.Drawing.Point(4, 4);
            this.groupRawXml.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupRawXml.Name = "groupRawXml";
            this.groupRawXml.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupRawXml.Size = new System.Drawing.Size(1312, 1092);
            this.groupRawXml.TabIndex = 0;
            this.groupRawXml.TabStop = false;
            this.groupRawXml.Text = "Raw XML";
            // 
            // btnClearRawXml
            // 
            this.btnClearRawXml.Location = new System.Drawing.Point(630, 475);
            this.btnClearRawXml.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnClearRawXml.Name = "btnClearRawXml";
            this.btnClearRawXml.Size = new System.Drawing.Size(150, 44);
            this.btnClearRawXml.TabIndex = 2;
            this.btnClearRawXml.Text = "Clear";
            this.btnClearRawXml.UseVisualStyleBackColor = true;
            this.btnClearRawXml.Click += new System.EventHandler(this.btnClearRawXml_Click);
            // 
            // btnSendRawXml
            // 
            this.btnSendRawXml.Enabled = false;
            this.btnSendRawXml.Location = new System.Drawing.Point(792, 475);
            this.btnSendRawXml.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnSendRawXml.Name = "btnSendRawXml";
            this.btnSendRawXml.Size = new System.Drawing.Size(150, 44);
            this.btnSendRawXml.TabIndex = 1;
            this.btnSendRawXml.Text = "Send";
            this.btnSendRawXml.UseVisualStyleBackColor = true;
            this.btnSendRawXml.Click += new System.EventHandler(this.btnSendRawXml_Click);
            // 
            // txtRawXml
            // 
            this.txtRawXml.Location = new System.Drawing.Point(12, 52);
            this.txtRawXml.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txtRawXml.Name = "txtRawXml";
            this.txtRawXml.Size = new System.Drawing.Size(926, 408);
            this.txtRawXml.TabIndex = 0;
            this.txtRawXml.Text = "";
            this.txtRawXml.TextChanged += new System.EventHandler(this.txtRawXml_TextChanged);
            // 
            // openFileDialogLoadStock
            // 
            this.openFileDialogLoadStock.DefaultExt = "csv";
            this.openFileDialogLoadStock.Filter = "Rowa Stock Files|*.csv";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1856, 1167);
            this.Controls.Add(this.splitContainer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FormMain";
            this.Text = "Storage System Simulator";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox15.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStockLocationList)).EndInit();
            this.groupBox14.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTenantList)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSubscriberID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownKeepAliveTimeout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownKeepAliveInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHandShakeTimeOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPort)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            this.groupBox11.ResumeLayout(false);
            this.groupBox13.ResumeLayout(false);
            this.groupBox13.PerformLayout();
            this.groupBox12.ResumeLayout(false);
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInputRequestPackList)).EndInit();
            this.tabPage5.ResumeLayout(false);
            this.groupBox17.ResumeLayout(false);
            this.groupBox17.PerformLayout();
            this.tabPage6.ResumeLayout(false);
            this.groupBox35.ResumeLayout(false);
            this.groupBox35.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMasterDataMachineLocation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSubItemQuantity)).EndInit();
            this.groupBox20.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMasterArticle)).EndInit();
            this.groupBox19.ResumeLayout(false);
            this.groupBox19.PerformLayout();
            this.tabPage11.ResumeLayout(false);
            this.groupBox22.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStockDeliveryDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStockDeliveryMaster)).EndInit();
            this.groupBox23.ResumeLayout(false);
            this.groupBox23.PerformLayout();
            this.tabPage9.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox18.ResumeLayout(false);
            this.groupBox21.ResumeLayout(false);
            this.groupBox21.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewArticleInfoArticleList)).EndInit();
            this.tabPage7.ResumeLayout(false);
            this.groupBox25.ResumeLayout(false);
            this.splitContainerStock.Panel1.ResumeLayout(false);
            this.splitContainerStock.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerStock)).EndInit();
            this.splitContainerStock.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProductStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPackStock)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.tabPage8.ResumeLayout(false);
            this.groupBox29.ResumeLayout(false);
            this.groupBox32.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOutputDispensedPack)).EndInit();
            this.groupBox31.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOutputOrderItems)).EndInit();
            this.groupBox30.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOutputOrderList)).EndInit();
            this.groupBox28.ResumeLayout(false);
            this.groupBox28.PerformLayout();
            this.groupBox27.ResumeLayout(false);
            this.groupBox27.PerformLayout();
            this.tabPage12.ResumeLayout(false);
            this.splitContainerLog.Panel1.ResumeLayout(false);
            this.splitContainerLog.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerLog)).EndInit();
            this.splitContainerLog.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.groupRawXml.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.GroupBox groupBox14;
        private System.Windows.Forms.DataGridView dataGridViewTenantList;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTenantID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTenantDescription;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown numericUpDownSubscriberID;
        private System.Windows.Forms.NumericUpDown numericUpDownKeepAliveTimeout;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numericUpDownKeepAliveInterval;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBoxEnableKeepAlive;
        private System.Windows.Forms.NumericUpDown numericUpDownHandShakeTimeOut;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDownPort;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView listViewConnections;
        private System.Windows.Forms.ColumnHeader columnHeaderEndpoint;
        private System.Windows.Forms.ColumnHeader columnHeaderHandshake;
        private System.Windows.Forms.ColumnHeader columnHeaderSubscriberID;
        private System.Windows.Forms.ColumnHeader columnHeaderTenant;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Button buttonRemoveComponent;
        private System.Windows.Forms.Button buttonAddComponent;
        private System.Windows.Forms.ListView listViewStatusComponent;
        private System.Windows.Forms.ColumnHeader columnHeaderType;
        private System.Windows.Forms.ColumnHeader columnHeaderDescription;
        private System.Windows.Forms.ColumnHeader columnHeaderState;
        private System.Windows.Forms.ColumnHeader columnHeaderStateText;
        private System.Windows.Forms.TextBox textBoxStatusText;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton NotReady;
        private System.Windows.Forms.RadioButton radioButtonReady;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.GroupBox groupBox13;
        private System.Windows.Forms.CheckBox checkBoxAcceptFridge;
        private System.Windows.Forms.Button buttonInputMessageNotLoad;
        private System.Windows.Forms.Button buttonInputMessageLoad;
        private System.Windows.Forms.CheckBox checkBoxInputMessageAuto;
        private System.Windows.Forms.GroupBox groupBox12;
        private System.Windows.Forms.ListView listViewScannedPackInformation;
        private System.Windows.Forms.ColumnHeader columnHeaderIndex;
        private System.Windows.Forms.ColumnHeader columnHeaderID;
        private System.Windows.Forms.ColumnHeader columnHeaderName;
        private System.Windows.Forms.ColumnHeader columnHeaderDosageForm;
        private System.Windows.Forms.ColumnHeader columnHeaderPackagingUnit;
        private System.Windows.Forms.ColumnHeader columnHeaderMaxSubItemQuantity;
        private System.Windows.Forms.ColumnHeader columnHeaderBatchNumber;
        private System.Windows.Forms.ColumnHeader columnHeaderExpiryDate;
        private System.Windows.Forms.ColumnHeader columnHeaderExternalID;
        private System.Windows.Forms.ColumnHeader columnHeaderSubItemQuantity;
        private System.Windows.Forms.ColumnHeader columnHeaderStockLocation;
        private System.Windows.Forms.ColumnHeader columnHeaderIsInFridge;
        private System.Windows.Forms.ColumnHeader columnHeaderHandingInput;
        private System.Windows.Forms.ColumnHeader columnHeaderHandlingText;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.CheckBox checkBoxIsDeliveryInput;
        private System.Windows.Forms.Label labelSelectInputLocation;
        private System.Windows.Forms.ComboBox comboBoxInputSelectLocation;
        private System.Windows.Forms.Label labelSelectInputTenant;
        private System.Windows.Forms.ComboBox comboBoxInputSelectTenant;
        private System.Windows.Forms.CheckBox checkBoxSetPickingIndicator;
        private System.Windows.Forms.Button buttonScanPack;
        private System.Windows.Forms.DataGridView dataGridViewInputRequestPackList;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.GroupBox groupBox17;
        private System.Windows.Forms.RadioButton radioButtonInitiateInputReject;
        private System.Windows.Forms.RadioButton radioButtonInitiateInputAccept;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.GroupBox groupBox35;
        private System.Windows.Forms.DateTimePicker dateTimePickerMasterDataExpiryDate;
        private System.Windows.Forms.NumericUpDown numericUpDownMasterDataMachineLocation;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown numericUpDownSubItemQuantity;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textBoxMasterDataExternalID;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBoxMasterDataBatchNumber;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label labelSelectMasterDataLocation;
        private System.Windows.Forms.ComboBox comboBoxMasterDataSelectLocation;
        private System.Windows.Forms.Label labelSelectMasterDataTenant;
        private System.Windows.Forms.ComboBox comboBoxMasterDataSelectTenant;
        private System.Windows.Forms.GroupBox groupBox20;
        private System.Windows.Forms.DataGridView dataGridViewMasterArticle;
        private System.Windows.Forms.GroupBox groupBox19;
        private System.Windows.Forms.TextBox textBoxMasterArticleText;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RadioButton radioButtonMasterArticleReject;
        private System.Windows.Forms.RadioButton radioButtonMasterArticleAccept;
        private System.Windows.Forms.TabPage tabPage11;
        private System.Windows.Forms.GroupBox groupBox22;
        private System.Windows.Forms.DataGridView dataGridViewStockDeliveryDetail;
        private System.Windows.Forms.DataGridView dataGridViewStockDeliveryMaster;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStockDeliveryMasterState;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnStockDeliveryMasterComplete;
        private System.Windows.Forms.GroupBox groupBox23;
        private System.Windows.Forms.TextBox textBoxStockDeliveryText;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RadioButton radioButtonStockDeliveryReject;
        private System.Windows.Forms.RadioButton radioButtonStockDeliveryAccept;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.GroupBox groupBox25;
        private System.Windows.Forms.TabPage tabPage8;
        private System.Windows.Forms.GroupBox groupBox29;
        private System.Windows.Forms.GroupBox groupBox32;
        private System.Windows.Forms.DataGridView dataGridViewOutputDispensedPack;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn26;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn27;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn28;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn29;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn30;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn31;
        private System.Windows.Forms.GroupBox groupBox31;
        private System.Windows.Forms.DataGridView dataGridViewOutputOrderItems;
        private System.Windows.Forms.GroupBox groupBox30;
        private System.Windows.Forms.DataGridView dataGridViewOutputOrderList;
        private System.Windows.Forms.GroupBox groupBox28;
        private System.Windows.Forms.CheckBox checkBoxOutputGenerateBoxID;
        private System.Windows.Forms.CheckBox checkBoxOutputAutoReply;
        private System.Windows.Forms.GroupBox groupBox27;
        private System.Windows.Forms.RadioButton radioButtonStockOutputUpdateStock;
        private System.Windows.Forms.RadioButton radioButtonStockOutputFrozenStock;
        private System.Windows.Forms.RadioButton radioButtonStockOutputAlwaysIncomplete;
        private System.Windows.Forms.RadioButton radioButtonStockOutputAlwaysComplete;
        private System.Windows.Forms.TabPage tabPage12;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button buttonClearSavedState;
        private System.Windows.Forms.Button buttonSaveSimulatorState;
        private System.Windows.Forms.GroupBox groupBox15;
        private System.Windows.Forms.DataGridView dataGridViewStockLocationList;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStockLocationId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStockLocationDescription;
        private System.Windows.Forms.SplitContainer splitContainerLog;
        private System.Windows.Forms.ListView listViewWwks2Log;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.RichTextBox richTextBoxDetailLog;
        private System.Windows.Forms.SplitContainer splitContainerStock;
        private System.Windows.Forms.DataGridView dataGridViewProductStock;
        private System.Windows.Forms.DataGridView dataGridViewPackStock;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button buttonClearStock;
        private System.Windows.Forms.Button buttonLoadStock;
        private System.Windows.Forms.OpenFileDialog openFileDialogLoadStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnOutputOrderID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnOutputOrderPriority;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnColumnOutputNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnOutputOrderPoint;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnOutputOrderBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnOutputOrderState;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnOutputOrderTentantID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnOutputItemIndex;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnOutputItemArticleCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnOutputItemBatch;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnOutputItemExternalID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnOutputItemExpiryDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnOutputItemPackID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnOutputItemRequestedQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnOutputItemRequestedSubItemQuantity;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewMasterArticleLoadPack;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnStockDeliveryLoadPack;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStockDeliveryPackCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStockDeliveryProcessedQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStockDeliveryBatchNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStockDeliveryExternalID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStockDeliveryExpiryDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnStockOutputPack;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnStockDeletePack;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn18;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn19;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn20;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn21;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn22;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn23;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn24;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn25;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStockStockLocationID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStockMachineLocation;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStockTenantID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDeliveryNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnScanCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnBatchNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnExpiryDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnHidenExpiryDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnExternalID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSubItemQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnShape;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnSelectShape;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMachineLocation;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumnStockListCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumnStockListName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumnStockListDosageForm;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumnStockListPackagingUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumnStockListMaxSubItemQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumnStockListPackCount;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnSendStockInfoMessage;
        private System.Windows.Forms.CheckBox checkBoxUseExternalIdAsSerialNumber;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupRawXml;
        private System.Windows.Forms.RichTextBox txtRawXml;
        private System.Windows.Forms.Button btnSendRawXml;
        private System.Windows.Forms.Button btnClearRawXml;
        private System.Windows.Forms.TabPage tabPage9;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.GroupBox groupBox18;
        private System.Windows.Forms.ListView listViewArticleInfoRequested;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.GroupBox groupBox21;
        private System.Windows.Forms.Button buttonSendArticleInfoRequest;
        private System.Windows.Forms.Label labelArticleInfoSelectTenant;
        private System.Windows.Forms.ComboBox comboBoxArticleInfoSelectTenant;
        private System.Windows.Forms.DataGridView dataGridViewArticleInfoArticleList;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn32;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn33;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn34;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn35;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn36;
    }
}

