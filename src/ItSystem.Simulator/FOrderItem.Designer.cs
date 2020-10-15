namespace CareFusion.ITSystemSimulator
{
    partial class FOrderItem
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
            this.lblArticleId = new System.Windows.Forms.Label();
            this.txtBatchNumber = new System.Windows.Forms.TextBox();
            this.lblBatchNumber = new System.Windows.Forms.Label();
            this.txtExternalID = new System.Windows.Forms.TextBox();
            this.lblExternalID = new System.Windows.Forms.Label();
            this.lblMinExpiryDate = new System.Windows.Forms.Label();
            this.dtExpiryDate = new System.Windows.Forms.DateTimePicker();
            this.checkExpiryDate = new System.Windows.Forms.CheckBox();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.numQuantity = new System.Windows.Forms.NumericUpDown();
            this.numSubItemQuantity = new System.Windows.Forms.NumericUpDown();
            this.lblSubItemQuantity = new System.Windows.Forms.Label();
            this.lblTemplateID = new System.Windows.Forms.Label();
            this.txtTemplateID = new System.Windows.Forms.TextBox();
            this.lblLabelContent = new System.Windows.Forms.Label();
            this.txtLabelContent = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtPackID = new System.Windows.Forms.TextBox();
            this.lblPackId = new System.Windows.Forms.Label();
            this.cmbArticleId = new System.Windows.Forms.ComboBox();
            this.txtMachineLocation = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtStockLocation = new System.Windows.Forms.TextBox();
            this.lblStockLocation = new System.Windows.Forms.Label();
            this.chkSingleBatch = new System.Windows.Forms.CheckBox();
            this.lblSingleBatch = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSubItemQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // lblArticleId
            // 
            this.lblArticleId.AutoSize = true;
            this.lblArticleId.Location = new System.Drawing.Point(13, 13);
            this.lblArticleId.Name = "lblArticleId";
            this.lblArticleId.Size = new System.Drawing.Size(53, 13);
            this.lblArticleId.TabIndex = 0;
            this.lblArticleId.Text = "Article ID:";
            // 
            // txtBatchNumber
            // 
            this.txtBatchNumber.Location = new System.Drawing.Point(127, 36);
            this.txtBatchNumber.Name = "txtBatchNumber";
            this.txtBatchNumber.Size = new System.Drawing.Size(134, 20);
            this.txtBatchNumber.TabIndex = 3;
            // 
            // lblBatchNumber
            // 
            this.lblBatchNumber.AutoSize = true;
            this.lblBatchNumber.Location = new System.Drawing.Point(13, 39);
            this.lblBatchNumber.Name = "lblBatchNumber";
            this.lblBatchNumber.Size = new System.Drawing.Size(78, 13);
            this.lblBatchNumber.TabIndex = 2;
            this.lblBatchNumber.Text = "Batch Number:";
            // 
            // txtExternalID
            // 
            this.txtExternalID.Location = new System.Drawing.Point(127, 62);
            this.txtExternalID.Name = "txtExternalID";
            this.txtExternalID.Size = new System.Drawing.Size(134, 20);
            this.txtExternalID.TabIndex = 5;
            // 
            // lblExternalID
            // 
            this.lblExternalID.AutoSize = true;
            this.lblExternalID.Location = new System.Drawing.Point(13, 65);
            this.lblExternalID.Name = "lblExternalID";
            this.lblExternalID.Size = new System.Drawing.Size(62, 13);
            this.lblExternalID.TabIndex = 4;
            this.lblExternalID.Text = "External ID:";
            // 
            // lblMinExpiryDate
            // 
            this.lblMinExpiryDate.AutoSize = true;
            this.lblMinExpiryDate.Location = new System.Drawing.Point(13, 117);
            this.lblMinExpiryDate.Name = "lblMinExpiryDate";
            this.lblMinExpiryDate.Size = new System.Drawing.Size(108, 13);
            this.lblMinExpiryDate.TabIndex = 8;
            this.lblMinExpiryDate.Text = "Minimum Expiry Date:";
            // 
            // dtExpiryDate
            // 
            this.dtExpiryDate.Enabled = false;
            this.dtExpiryDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtExpiryDate.Location = new System.Drawing.Point(148, 114);
            this.dtExpiryDate.Name = "dtExpiryDate";
            this.dtExpiryDate.Size = new System.Drawing.Size(113, 20);
            this.dtExpiryDate.TabIndex = 10;
            // 
            // checkExpiryDate
            // 
            this.checkExpiryDate.AutoSize = true;
            this.checkExpiryDate.Location = new System.Drawing.Point(127, 117);
            this.checkExpiryDate.Name = "checkExpiryDate";
            this.checkExpiryDate.Size = new System.Drawing.Size(15, 14);
            this.checkExpiryDate.TabIndex = 9;
            this.checkExpiryDate.UseVisualStyleBackColor = true;
            this.checkExpiryDate.CheckedChanged += new System.EventHandler(this.checkExpiryDate_CheckedChanged);
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(13, 146);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(49, 13);
            this.lblQuantity.TabIndex = 11;
            this.lblQuantity.Text = "Quantity:";
            // 
            // numQuantity
            // 
            this.numQuantity.Location = new System.Drawing.Point(127, 144);
            this.numQuantity.Name = "numQuantity";
            this.numQuantity.Size = new System.Drawing.Size(134, 20);
            this.numQuantity.TabIndex = 12;
            this.numQuantity.ValueChanged += new System.EventHandler(this.numQuantity_ValueChanged);
            // 
            // numSubItemQuantity
            // 
            this.numSubItemQuantity.Location = new System.Drawing.Point(127, 170);
            this.numSubItemQuantity.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numSubItemQuantity.Name = "numSubItemQuantity";
            this.numSubItemQuantity.Size = new System.Drawing.Size(134, 20);
            this.numSubItemQuantity.TabIndex = 14;
            this.numSubItemQuantity.ValueChanged += new System.EventHandler(this.numSubItemQuantity_ValueChanged);
            // 
            // lblSubItemQuantity
            // 
            this.lblSubItemQuantity.AutoSize = true;
            this.lblSubItemQuantity.Location = new System.Drawing.Point(13, 172);
            this.lblSubItemQuantity.Name = "lblSubItemQuantity";
            this.lblSubItemQuantity.Size = new System.Drawing.Size(91, 13);
            this.lblSubItemQuantity.TabIndex = 13;
            this.lblSubItemQuantity.Text = "SubItem Quantity:";
            // 
            // lblTemplateID
            // 
            this.lblTemplateID.AutoSize = true;
            this.lblTemplateID.Location = new System.Drawing.Point(283, 13);
            this.lblTemplateID.Name = "lblTemplateID";
            this.lblTemplateID.Size = new System.Drawing.Size(97, 13);
            this.lblTemplateID.TabIndex = 21;
            this.lblTemplateID.Text = "Label Template ID:";
            // 
            // txtTemplateID
            // 
            this.txtTemplateID.Location = new System.Drawing.Point(386, 10);
            this.txtTemplateID.Name = "txtTemplateID";
            this.txtTemplateID.Size = new System.Drawing.Size(100, 20);
            this.txtTemplateID.TabIndex = 22;
            // 
            // lblLabelContent
            // 
            this.lblLabelContent.AutoSize = true;
            this.lblLabelContent.Location = new System.Drawing.Point(283, 39);
            this.lblLabelContent.Name = "lblLabelContent";
            this.lblLabelContent.Size = new System.Drawing.Size(76, 13);
            this.lblLabelContent.TabIndex = 23;
            this.lblLabelContent.Text = "Label Content:";
            // 
            // txtLabelContent
            // 
            this.txtLabelContent.Location = new System.Drawing.Point(286, 57);
            this.txtLabelContent.Multiline = true;
            this.txtLabelContent.Name = "txtLabelContent";
            this.txtLabelContent.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLabelContent.Size = new System.Drawing.Size(200, 209);
            this.txtLabelContent.TabIndex = 24;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(330, 281);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 25;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(411, 281);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 26;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtPackID
            // 
            this.txtPackID.Location = new System.Drawing.Point(127, 88);
            this.txtPackID.Name = "txtPackID";
            this.txtPackID.Size = new System.Drawing.Size(134, 20);
            this.txtPackID.TabIndex = 7;
            // 
            // lblPackId
            // 
            this.lblPackId.AutoSize = true;
            this.lblPackId.Location = new System.Drawing.Point(13, 91);
            this.lblPackId.Name = "lblPackId";
            this.lblPackId.Size = new System.Drawing.Size(49, 13);
            this.lblPackId.TabIndex = 6;
            this.lblPackId.Text = "Pack ID:";
            // 
            // cmbArticleId
            // 
            this.cmbArticleId.FormattingEnabled = true;
            this.cmbArticleId.Location = new System.Drawing.Point(127, 10);
            this.cmbArticleId.Name = "cmbArticleId";
            this.cmbArticleId.Size = new System.Drawing.Size(134, 21);
            this.cmbArticleId.TabIndex = 1;
            // 
            // txtMachineLocation
            // 
            this.txtMachineLocation.Location = new System.Drawing.Point(127, 223);
            this.txtMachineLocation.Name = "txtMachineLocation";
            this.txtMachineLocation.Size = new System.Drawing.Size(134, 20);
            this.txtMachineLocation.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 226);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Machine Location:";
            // 
            // txtStockLocation
            // 
            this.txtStockLocation.Location = new System.Drawing.Point(127, 197);
            this.txtStockLocation.Name = "txtStockLocation";
            this.txtStockLocation.Size = new System.Drawing.Size(134, 20);
            this.txtStockLocation.TabIndex = 16;
            // 
            // lblStockLocation
            // 
            this.lblStockLocation.AutoSize = true;
            this.lblStockLocation.Location = new System.Drawing.Point(13, 200);
            this.lblStockLocation.Name = "lblStockLocation";
            this.lblStockLocation.Size = new System.Drawing.Size(82, 13);
            this.lblStockLocation.TabIndex = 15;
            this.lblStockLocation.Text = "Stock Location:";
            // 
            // chkSingleBatch
            // 
            this.chkSingleBatch.AutoSize = true;
            this.chkSingleBatch.Location = new System.Drawing.Point(127, 252);
            this.chkSingleBatch.Name = "chkSingleBatch";
            this.chkSingleBatch.Size = new System.Drawing.Size(65, 17);
            this.chkSingleBatch.TabIndex = 20;
            this.chkSingleBatch.Text = "Enabled";
            this.chkSingleBatch.UseVisualStyleBackColor = true;
            // 
            // lblSingleBatch
            // 
            this.lblSingleBatch.AutoSize = true;
            this.lblSingleBatch.Location = new System.Drawing.Point(13, 253);
            this.lblSingleBatch.Name = "lblSingleBatch";
            this.lblSingleBatch.Size = new System.Drawing.Size(110, 13);
            this.lblSingleBatch.TabIndex = 19;
            this.lblSingleBatch.Text = "Single Batch Number:";
            // 
            // FOrderItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 316);
            this.Controls.Add(this.chkSingleBatch);
            this.Controls.Add(this.lblSingleBatch);
            this.Controls.Add(this.txtMachineLocation);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtStockLocation);
            this.Controls.Add(this.lblStockLocation);
            this.Controls.Add(this.cmbArticleId);
            this.Controls.Add(this.txtPackID);
            this.Controls.Add(this.lblPackId);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtLabelContent);
            this.Controls.Add(this.lblLabelContent);
            this.Controls.Add(this.txtTemplateID);
            this.Controls.Add(this.lblTemplateID);
            this.Controls.Add(this.numSubItemQuantity);
            this.Controls.Add(this.lblSubItemQuantity);
            this.Controls.Add(this.numQuantity);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.checkExpiryDate);
            this.Controls.Add(this.dtExpiryDate);
            this.Controls.Add(this.lblMinExpiryDate);
            this.Controls.Add(this.txtExternalID);
            this.Controls.Add(this.lblExternalID);
            this.Controls.Add(this.txtBatchNumber);
            this.Controls.Add(this.lblBatchNumber);
            this.Controls.Add(this.lblArticleId);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FOrderItem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "New Order Item";
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSubItemQuantity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblArticleId;
        private System.Windows.Forms.TextBox txtBatchNumber;
        private System.Windows.Forms.Label lblBatchNumber;
        private System.Windows.Forms.TextBox txtExternalID;
        private System.Windows.Forms.Label lblExternalID;
        private System.Windows.Forms.Label lblMinExpiryDate;
        private System.Windows.Forms.DateTimePicker dtExpiryDate;
        private System.Windows.Forms.CheckBox checkExpiryDate;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.NumericUpDown numQuantity;
        private System.Windows.Forms.NumericUpDown numSubItemQuantity;
        private System.Windows.Forms.Label lblSubItemQuantity;
        private System.Windows.Forms.Label lblTemplateID;
        private System.Windows.Forms.TextBox txtTemplateID;
        private System.Windows.Forms.Label lblLabelContent;
        private System.Windows.Forms.TextBox txtLabelContent;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtPackID;
        private System.Windows.Forms.Label lblPackId;
        private System.Windows.Forms.ComboBox cmbArticleId;
        private System.Windows.Forms.TextBox txtMachineLocation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtStockLocation;
        private System.Windows.Forms.Label lblStockLocation;
        private System.Windows.Forms.CheckBox chkSingleBatch;
        private System.Windows.Forms.Label lblSingleBatch;
    }
}