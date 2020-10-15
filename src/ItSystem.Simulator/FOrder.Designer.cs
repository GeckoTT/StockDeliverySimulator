namespace CareFusion.ITSystemSimulator
{
    partial class FOrder
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
            this.lblOrderNumber = new System.Windows.Forms.Label();
            this.cmbPriority = new System.Windows.Forms.ComboBox();
            this.lblPriority = new System.Windows.Forms.Label();
            this.numDestination = new System.Windows.Forms.NumericUpDown();
            this.lblDestination = new System.Windows.Forms.Label();
            this.txtBoxNumber = new System.Windows.Forms.TextBox();
            this.lblBoxNumber = new System.Windows.Forms.Label();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.lblNumItemDesc = new System.Windows.Forms.Label();
            this.lblNumItems = new System.Windows.Forms.Label();
            this.numPoint = new System.Windows.Forms.NumericUpDown();
            this.lblPoint = new System.Windows.Forms.Label();
            this.txtOrderNumber = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numDestination)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPoint)).BeginInit();
            this.SuspendLayout();
            // 
            // lblOrderNumber
            // 
            this.lblOrderNumber.AutoSize = true;
            this.lblOrderNumber.Location = new System.Drawing.Point(12, 14);
            this.lblOrderNumber.Name = "lblOrderNumber";
            this.lblOrderNumber.Size = new System.Drawing.Size(76, 13);
            this.lblOrderNumber.TabIndex = 0;
            this.lblOrderNumber.Text = "Order Number:";
            // 
            // cmbPriority
            // 
            this.cmbPriority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPriority.FormattingEnabled = true;
            this.cmbPriority.Items.AddRange(new object[] {
            "Low",
            "Normal",
            "High"});
            this.cmbPriority.Location = new System.Drawing.Point(103, 38);
            this.cmbPriority.Name = "cmbPriority";
            this.cmbPriority.Size = new System.Drawing.Size(95, 21);
            this.cmbPriority.TabIndex = 3;
            this.cmbPriority.SelectedIndexChanged += new System.EventHandler(this.cmbPriority_SelectedIndexChanged);
            // 
            // lblPriority
            // 
            this.lblPriority.AutoSize = true;
            this.lblPriority.Location = new System.Drawing.Point(12, 41);
            this.lblPriority.Name = "lblPriority";
            this.lblPriority.Size = new System.Drawing.Size(41, 13);
            this.lblPriority.TabIndex = 2;
            this.lblPriority.Text = "Priority:";
            // 
            // numDestination
            // 
            this.numDestination.Location = new System.Drawing.Point(322, 12);
            this.numDestination.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numDestination.Name = "numDestination";
            this.numDestination.Size = new System.Drawing.Size(95, 20);
            this.numDestination.TabIndex = 5;
            this.numDestination.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numDestination.ValueChanged += new System.EventHandler(this.numDestination_ValueChanged);
            // 
            // lblDestination
            // 
            this.lblDestination.AutoSize = true;
            this.lblDestination.Location = new System.Drawing.Point(231, 14);
            this.lblDestination.Name = "lblDestination";
            this.lblDestination.Size = new System.Drawing.Size(63, 13);
            this.lblDestination.TabIndex = 4;
            this.lblDestination.Text = "Destination:";
            // 
            // txtBoxNumber
            // 
            this.txtBoxNumber.Location = new System.Drawing.Point(322, 64);
            this.txtBoxNumber.Name = "txtBoxNumber";
            this.txtBoxNumber.Size = new System.Drawing.Size(95, 20);
            this.txtBoxNumber.TabIndex = 9;
            this.txtBoxNumber.TextChanged += new System.EventHandler(this.txtBoxNumber_TextChanged);
            // 
            // lblBoxNumber
            // 
            this.lblBoxNumber.AutoSize = true;
            this.lblBoxNumber.Location = new System.Drawing.Point(231, 67);
            this.lblBoxNumber.Name = "lblBoxNumber";
            this.lblBoxNumber.Size = new System.Drawing.Size(68, 13);
            this.lblBoxNumber.TabIndex = 8;
            this.lblBoxNumber.Text = "Box Number:";
            // 
            // btnAddItem
            // 
            this.btnAddItem.Location = new System.Drawing.Point(15, 107);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(75, 23);
            this.btnAddItem.TabIndex = 10;
            this.btnAddItem.Text = "&Add Item ...";
            this.btnAddItem.UseVisualStyleBackColor = true;
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(342, 107);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(261, 107);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 11;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lblNumItemDesc
            // 
            this.lblNumItemDesc.AutoSize = true;
            this.lblNumItemDesc.Location = new System.Drawing.Point(12, 67);
            this.lblNumItemDesc.Name = "lblNumItemDesc";
            this.lblNumItemDesc.Size = new System.Drawing.Size(61, 13);
            this.lblNumItemDesc.TabIndex = 11;
            this.lblNumItemDesc.Text = "Item Count:";
            // 
            // lblNumItems
            // 
            this.lblNumItems.AutoSize = true;
            this.lblNumItems.Location = new System.Drawing.Point(100, 67);
            this.lblNumItems.Name = "lblNumItems";
            this.lblNumItems.Size = new System.Drawing.Size(13, 13);
            this.lblNumItems.TabIndex = 12;
            this.lblNumItems.Text = "0";
            // 
            // numPoint
            // 
            this.numPoint.Location = new System.Drawing.Point(322, 38);
            this.numPoint.Name = "numPoint";
            this.numPoint.Size = new System.Drawing.Size(95, 20);
            this.numPoint.TabIndex = 7;
            this.numPoint.ValueChanged += new System.EventHandler(this.numPoint_ValueChanged);
            // 
            // lblPoint
            // 
            this.lblPoint.AutoSize = true;
            this.lblPoint.Location = new System.Drawing.Point(231, 40);
            this.lblPoint.Name = "lblPoint";
            this.lblPoint.Size = new System.Drawing.Size(34, 13);
            this.lblPoint.TabIndex = 6;
            this.lblPoint.Text = "Point:";
            // 
            // txtOrderNumber
            // 
            this.txtOrderNumber.Location = new System.Drawing.Point(103, 6);
            this.txtOrderNumber.Name = "txtOrderNumber";
            this.txtOrderNumber.Size = new System.Drawing.Size(95, 20);
            this.txtOrderNumber.TabIndex = 1;
            this.txtOrderNumber.Text = "100";
            this.txtOrderNumber.TextChanged += new System.EventHandler(this.txtOrderNumber_TextChanged);
            // 
            // FOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 142);
            this.Controls.Add(this.txtOrderNumber);
            this.Controls.Add(this.numPoint);
            this.Controls.Add(this.lblPoint);
            this.Controls.Add(this.lblNumItems);
            this.Controls.Add(this.lblNumItemDesc);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnAddItem);
            this.Controls.Add(this.txtBoxNumber);
            this.Controls.Add(this.lblBoxNumber);
            this.Controls.Add(this.numDestination);
            this.Controls.Add(this.lblDestination);
            this.Controls.Add(this.cmbPriority);
            this.Controls.Add(this.lblPriority);
            this.Controls.Add(this.lblOrderNumber);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "New Order";
            this.Load += new System.EventHandler(this.FOrder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numDestination)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPoint)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblOrderNumber;
        private System.Windows.Forms.ComboBox cmbPriority;
        private System.Windows.Forms.Label lblPriority;
        private System.Windows.Forms.NumericUpDown numDestination;
        private System.Windows.Forms.Label lblDestination;
        private System.Windows.Forms.TextBox txtBoxNumber;
        private System.Windows.Forms.Label lblBoxNumber;
        private System.Windows.Forms.Button btnAddItem;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label lblNumItemDesc;
        private System.Windows.Forms.Label lblNumItems;
        private System.Windows.Forms.NumericUpDown numPoint;
        private System.Windows.Forms.Label lblPoint;
        private System.Windows.Forms.TextBox txtOrderNumber;
    }
}