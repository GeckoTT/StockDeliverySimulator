namespace CareFusion.ITSystemSimulator
{
    partial class FBulkOrder
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.txtStartBoxNumber = new System.Windows.Forms.TextBox();
            this.lblBoxNumber = new System.Windows.Forms.Label();
            this.numDestination = new System.Windows.Forms.NumericUpDown();
            this.lblDestination = new System.Windows.Forms.Label();
            this.cmbPriority = new System.Windows.Forms.ComboBox();
            this.lblPriority = new System.Windows.Forms.Label();
            this.numStartOrderNumber = new System.Windows.Forms.NumericUpDown();
            this.lblOrderNumber = new System.Windows.Forms.Label();
            this.numOrderCount = new System.Windows.Forms.NumericUpDown();
            this.lblOrderCount = new System.Windows.Forms.Label();
            this.numPackCount = new System.Windows.Forms.NumericUpDown();
            this.lblPackCount = new System.Windows.Forms.Label();
            this.txtMachineLocation = new System.Windows.Forms.TextBox();
            this.lblMachineLocation = new System.Windows.Forms.Label();
            this.lblBoxNumbers = new System.Windows.Forms.Label();
            this.txtBoxNumbers = new System.Windows.Forms.TextBox();
            this.chkAllMachines = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numDestination)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStartOrderNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOrderCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPackCount)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(340, 208);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 23;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(259, 208);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 22;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtStartBoxNumber
            // 
            this.txtStartBoxNumber.Location = new System.Drawing.Point(119, 121);
            this.txtStartBoxNumber.Name = "txtStartBoxNumber";
            this.txtStartBoxNumber.Size = new System.Drawing.Size(95, 20);
            this.txtStartBoxNumber.TabIndex = 9;
            // 
            // lblBoxNumber
            // 
            this.lblBoxNumber.AutoSize = true;
            this.lblBoxNumber.Location = new System.Drawing.Point(12, 124);
            this.lblBoxNumber.Name = "lblBoxNumber";
            this.lblBoxNumber.Size = new System.Drawing.Size(93, 13);
            this.lblBoxNumber.TabIndex = 8;
            this.lblBoxNumber.Text = "Start Box Number:";
            // 
            // numDestination
            // 
            this.numDestination.Location = new System.Drawing.Point(119, 65);
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
            // 
            // lblDestination
            // 
            this.lblDestination.AutoSize = true;
            this.lblDestination.Location = new System.Drawing.Point(12, 67);
            this.lblDestination.Name = "lblDestination";
            this.lblDestination.Size = new System.Drawing.Size(63, 13);
            this.lblDestination.TabIndex = 4;
            this.lblDestination.Text = "Destination:";
            // 
            // cmbPriority
            // 
            this.cmbPriority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPriority.FormattingEnabled = true;
            this.cmbPriority.Items.AddRange(new object[] {
            "Low",
            "Normal",
            "High"});
            this.cmbPriority.Location = new System.Drawing.Point(119, 38);
            this.cmbPriority.Name = "cmbPriority";
            this.cmbPriority.Size = new System.Drawing.Size(95, 21);
            this.cmbPriority.TabIndex = 3;
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
            // numStartOrderNumber
            // 
            this.numStartOrderNumber.Location = new System.Drawing.Point(119, 12);
            this.numStartOrderNumber.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.numStartOrderNumber.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numStartOrderNumber.Name = "numStartOrderNumber";
            this.numStartOrderNumber.Size = new System.Drawing.Size(95, 20);
            this.numStartOrderNumber.TabIndex = 1;
            this.numStartOrderNumber.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // lblOrderNumber
            // 
            this.lblOrderNumber.AutoSize = true;
            this.lblOrderNumber.Location = new System.Drawing.Point(12, 14);
            this.lblOrderNumber.Name = "lblOrderNumber";
            this.lblOrderNumber.Size = new System.Drawing.Size(101, 13);
            this.lblOrderNumber.TabIndex = 0;
            this.lblOrderNumber.Text = "Start Order Number:";
            // 
            // numOrderCount
            // 
            this.numOrderCount.Location = new System.Drawing.Point(119, 149);
            this.numOrderCount.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.numOrderCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numOrderCount.Name = "numOrderCount";
            this.numOrderCount.Size = new System.Drawing.Size(95, 20);
            this.numOrderCount.TabIndex = 11;
            this.numOrderCount.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // lblOrderCount
            // 
            this.lblOrderCount.AutoSize = true;
            this.lblOrderCount.Location = new System.Drawing.Point(12, 151);
            this.lblOrderCount.Name = "lblOrderCount";
            this.lblOrderCount.Size = new System.Drawing.Size(67, 13);
            this.lblOrderCount.TabIndex = 10;
            this.lblOrderCount.Text = "Order Count:";
            // 
            // numPackCount
            // 
            this.numPackCount.Location = new System.Drawing.Point(119, 175);
            this.numPackCount.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.numPackCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numPackCount.Name = "numPackCount";
            this.numPackCount.Size = new System.Drawing.Size(95, 20);
            this.numPackCount.TabIndex = 13;
            this.numPackCount.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // lblPackCount
            // 
            this.lblPackCount.AutoSize = true;
            this.lblPackCount.Location = new System.Drawing.Point(12, 177);
            this.lblPackCount.Name = "lblPackCount";
            this.lblPackCount.Size = new System.Drawing.Size(66, 13);
            this.lblPackCount.TabIndex = 12;
            this.lblPackCount.Text = "Pack Count:";
            // 
            // txtMachineLocation
            // 
            this.txtMachineLocation.Location = new System.Drawing.Point(119, 91);
            this.txtMachineLocation.Name = "txtMachineLocation";
            this.txtMachineLocation.Size = new System.Drawing.Size(95, 20);
            this.txtMachineLocation.TabIndex = 7;
            // 
            // lblMachineLocation
            // 
            this.lblMachineLocation.AutoSize = true;
            this.lblMachineLocation.Location = new System.Drawing.Point(12, 94);
            this.lblMachineLocation.Name = "lblMachineLocation";
            this.lblMachineLocation.Size = new System.Drawing.Size(95, 13);
            this.lblMachineLocation.TabIndex = 6;
            this.lblMachineLocation.Text = "Machine Location:";
            // 
            // lblBoxNumbers
            // 
            this.lblBoxNumbers.AutoSize = true;
            this.lblBoxNumbers.Location = new System.Drawing.Point(232, 14);
            this.lblBoxNumbers.Name = "lblBoxNumbers";
            this.lblBoxNumbers.Size = new System.Drawing.Size(73, 13);
            this.lblBoxNumbers.TabIndex = 24;
            this.lblBoxNumbers.Text = "Box Numbers:";
            // 
            // txtBoxNumbers
            // 
            this.txtBoxNumbers.Location = new System.Drawing.Point(235, 31);
            this.txtBoxNumbers.Multiline = true;
            this.txtBoxNumbers.Name = "txtBoxNumbers";
            this.txtBoxNumbers.Size = new System.Drawing.Size(180, 164);
            this.txtBoxNumbers.TabIndex = 25;
            // 
            // chkAllMachines
            // 
            this.chkAllMachines.AutoSize = true;
            this.chkAllMachines.Location = new System.Drawing.Point(119, 201);
            this.chkAllMachines.Name = "chkAllMachines";
            this.chkAllMachines.Size = new System.Drawing.Size(107, 17);
            this.chkAllMachines.TabIndex = 26;
            this.chkAllMachines.Text = "Use all Machines";
            this.chkAllMachines.UseVisualStyleBackColor = true;
            // 
            // FBulkOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 239);
            this.Controls.Add(this.chkAllMachines);
            this.Controls.Add(this.txtBoxNumbers);
            this.Controls.Add(this.lblBoxNumbers);
            this.Controls.Add(this.txtMachineLocation);
            this.Controls.Add(this.lblMachineLocation);
            this.Controls.Add(this.numPackCount);
            this.Controls.Add(this.lblPackCount);
            this.Controls.Add(this.numOrderCount);
            this.Controls.Add(this.lblOrderCount);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtStartBoxNumber);
            this.Controls.Add(this.lblBoxNumber);
            this.Controls.Add(this.numDestination);
            this.Controls.Add(this.lblDestination);
            this.Controls.Add(this.cmbPriority);
            this.Controls.Add(this.lblPriority);
            this.Controls.Add(this.numStartOrderNumber);
            this.Controls.Add(this.lblOrderNumber);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FBulkOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "New Bulk Orders";
            this.Load += new System.EventHandler(this.FBulkOrder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numDestination)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStartOrderNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOrderCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPackCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TextBox txtStartBoxNumber;
        private System.Windows.Forms.Label lblBoxNumber;
        private System.Windows.Forms.NumericUpDown numDestination;
        private System.Windows.Forms.Label lblDestination;
        private System.Windows.Forms.ComboBox cmbPriority;
        private System.Windows.Forms.Label lblPriority;
        private System.Windows.Forms.NumericUpDown numStartOrderNumber;
        private System.Windows.Forms.Label lblOrderNumber;
        private System.Windows.Forms.NumericUpDown numOrderCount;
        private System.Windows.Forms.Label lblOrderCount;
        private System.Windows.Forms.NumericUpDown numPackCount;
        private System.Windows.Forms.Label lblPackCount;
        private System.Windows.Forms.TextBox txtMachineLocation;
        private System.Windows.Forms.Label lblMachineLocation;
        private System.Windows.Forms.Label lblBoxNumbers;
        private System.Windows.Forms.TextBox txtBoxNumbers;
        private System.Windows.Forms.CheckBox chkAllMachines;
    }
}