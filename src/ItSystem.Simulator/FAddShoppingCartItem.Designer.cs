namespace CareFusion.ITSystemSimulator
{
    partial class FAddShoppingCartItem
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
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.groupBoxShoppingCartItem = new System.Windows.Forms.GroupBox();
            this.labelPrice = new System.Windows.Forms.Label();
            this.labelPaidQuantity = new System.Windows.Forms.Label();
            this.labelOrderedQuantity = new System.Windows.Forms.Label();
            this.numericUpDownDispensedQuantity = new System.Windows.Forms.NumericUpDown();
            this.labelDispensedQuantity = new System.Windows.Forms.Label();
            this.textBoxCurrency = new System.Windows.Forms.TextBox();
            this.labelCurrency = new System.Windows.Forms.Label();
            this.labelArticleId = new System.Windows.Forms.Label();
            this.textBoxArticleId = new System.Windows.Forms.TextBox();
            this.numericUpDownOrderedQuantity = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownPaidQuantity = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownPrice = new System.Windows.Forms.NumericUpDown();
            this.groupBoxShoppingCartItem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDispensedQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOrderedQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPaidQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPrice)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.Location = new System.Drawing.Point(116, 195);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 7;
            this.buttonOk.Text = "Ok";
            this.buttonOk.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(197, 195);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 8;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // groupBoxShoppingCartItem
            // 
            this.groupBoxShoppingCartItem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxShoppingCartItem.Controls.Add(this.numericUpDownPrice);
            this.groupBoxShoppingCartItem.Controls.Add(this.numericUpDownPaidQuantity);
            this.groupBoxShoppingCartItem.Controls.Add(this.numericUpDownOrderedQuantity);
            this.groupBoxShoppingCartItem.Controls.Add(this.textBoxArticleId);
            this.groupBoxShoppingCartItem.Controls.Add(this.labelPrice);
            this.groupBoxShoppingCartItem.Controls.Add(this.labelPaidQuantity);
            this.groupBoxShoppingCartItem.Controls.Add(this.labelOrderedQuantity);
            this.groupBoxShoppingCartItem.Controls.Add(this.numericUpDownDispensedQuantity);
            this.groupBoxShoppingCartItem.Controls.Add(this.labelDispensedQuantity);
            this.groupBoxShoppingCartItem.Controls.Add(this.textBoxCurrency);
            this.groupBoxShoppingCartItem.Controls.Add(this.labelCurrency);
            this.groupBoxShoppingCartItem.Controls.Add(this.labelArticleId);
            this.groupBoxShoppingCartItem.Location = new System.Drawing.Point(12, 12);
            this.groupBoxShoppingCartItem.Name = "groupBoxShoppingCartItem";
            this.groupBoxShoppingCartItem.Size = new System.Drawing.Size(260, 177);
            this.groupBoxShoppingCartItem.TabIndex = 6;
            this.groupBoxShoppingCartItem.TabStop = false;
            this.groupBoxShoppingCartItem.Text = "Shopping cart item";
            // 
            // labelPrice
            // 
            this.labelPrice.AutoSize = true;
            this.labelPrice.Location = new System.Drawing.Point(6, 150);
            this.labelPrice.Name = "labelPrice";
            this.labelPrice.Size = new System.Drawing.Size(37, 13);
            this.labelPrice.TabIndex = 13;
            this.labelPrice.Text = "Price :";
            // 
            // labelPaidQuantity
            // 
            this.labelPaidQuantity.AutoSize = true;
            this.labelPaidQuantity.Location = new System.Drawing.Point(6, 124);
            this.labelPaidQuantity.Name = "labelPaidQuantity";
            this.labelPaidQuantity.Size = new System.Drawing.Size(76, 13);
            this.labelPaidQuantity.TabIndex = 9;
            this.labelPaidQuantity.Text = "Paid Quantity :";
            // 
            // labelOrderedQuantity
            // 
            this.labelOrderedQuantity.AutoSize = true;
            this.labelOrderedQuantity.Location = new System.Drawing.Point(6, 98);
            this.labelOrderedQuantity.Name = "labelOrderedQuantity";
            this.labelOrderedQuantity.Size = new System.Drawing.Size(93, 13);
            this.labelOrderedQuantity.TabIndex = 7;
            this.labelOrderedQuantity.Text = "Ordered Quantity :";
            // 
            // numericUpDownDispensedQuantity
            // 
            this.numericUpDownDispensedQuantity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDownDispensedQuantity.Location = new System.Drawing.Point(117, 69);
            this.numericUpDownDispensedQuantity.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.numericUpDownDispensedQuantity.Name = "numericUpDownDispensedQuantity";
            this.numericUpDownDispensedQuantity.Size = new System.Drawing.Size(137, 20);
            this.numericUpDownDispensedQuantity.TabIndex = 6;
            this.numericUpDownDispensedQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // labelDispensedQuantity
            // 
            this.labelDispensedQuantity.AutoSize = true;
            this.labelDispensedQuantity.Location = new System.Drawing.Point(6, 72);
            this.labelDispensedQuantity.Name = "labelDispensedQuantity";
            this.labelDispensedQuantity.Size = new System.Drawing.Size(105, 13);
            this.labelDispensedQuantity.TabIndex = 4;
            this.labelDispensedQuantity.Text = "Dispensed Quantity :";
            // 
            // textBoxCurrency
            // 
            this.textBoxCurrency.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxCurrency.Location = new System.Drawing.Point(66, 43);
            this.textBoxCurrency.Name = "textBoxCurrency";
            this.textBoxCurrency.Size = new System.Drawing.Size(188, 20);
            this.textBoxCurrency.TabIndex = 2;
            this.textBoxCurrency.Text = "EUR";
            // 
            // labelCurrency
            // 
            this.labelCurrency.AutoSize = true;
            this.labelCurrency.Location = new System.Drawing.Point(6, 46);
            this.labelCurrency.Name = "labelCurrency";
            this.labelCurrency.Size = new System.Drawing.Size(52, 13);
            this.labelCurrency.TabIndex = 1;
            this.labelCurrency.Text = "Currency:";
            // 
            // labelArticleId
            // 
            this.labelArticleId.AutoSize = true;
            this.labelArticleId.Location = new System.Drawing.Point(6, 20);
            this.labelArticleId.Name = "labelArticleId";
            this.labelArticleId.Size = new System.Drawing.Size(54, 13);
            this.labelArticleId.TabIndex = 0;
            this.labelArticleId.Text = "Article Id :";
            // 
            // textBoxArticleId
            // 
            this.textBoxArticleId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxArticleId.Location = new System.Drawing.Point(66, 17);
            this.textBoxArticleId.Name = "textBoxArticleId";
            this.textBoxArticleId.Size = new System.Drawing.Size(188, 20);
            this.textBoxArticleId.TabIndex = 16;
            this.textBoxArticleId.Text = "100";
            // 
            // numericUpDownOrderedQuantity
            // 
            this.numericUpDownOrderedQuantity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDownOrderedQuantity.Location = new System.Drawing.Point(105, 95);
            this.numericUpDownOrderedQuantity.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.numericUpDownOrderedQuantity.Name = "numericUpDownOrderedQuantity";
            this.numericUpDownOrderedQuantity.Size = new System.Drawing.Size(149, 20);
            this.numericUpDownOrderedQuantity.TabIndex = 17;
            this.numericUpDownOrderedQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericUpDownPaidQuantity
            // 
            this.numericUpDownPaidQuantity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDownPaidQuantity.Location = new System.Drawing.Point(88, 122);
            this.numericUpDownPaidQuantity.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.numericUpDownPaidQuantity.Name = "numericUpDownPaidQuantity";
            this.numericUpDownPaidQuantity.Size = new System.Drawing.Size(166, 20);
            this.numericUpDownPaidQuantity.TabIndex = 18;
            this.numericUpDownPaidQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericUpDownPrice
            // 
            this.numericUpDownPrice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDownPrice.Location = new System.Drawing.Point(49, 148);
            this.numericUpDownPrice.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.numericUpDownPrice.Name = "numericUpDownPrice";
            this.numericUpDownPrice.Size = new System.Drawing.Size(205, 20);
            this.numericUpDownPrice.TabIndex = 19;
            this.numericUpDownPrice.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // FAddShoppingCartItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 230);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.groupBoxShoppingCartItem);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "FAddShoppingCartItem";
            this.Text = "FAddShoppingCartItem";
            this.groupBoxShoppingCartItem.ResumeLayout(false);
            this.groupBoxShoppingCartItem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDispensedQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOrderedQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPaidQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPrice)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.GroupBox groupBoxShoppingCartItem;
        private System.Windows.Forms.Label labelPrice;
        private System.Windows.Forms.Label labelPaidQuantity;
        private System.Windows.Forms.Label labelOrderedQuantity;
        private System.Windows.Forms.NumericUpDown numericUpDownDispensedQuantity;
        private System.Windows.Forms.Label labelDispensedQuantity;
        private System.Windows.Forms.TextBox textBoxCurrency;
        private System.Windows.Forms.Label labelCurrency;
        private System.Windows.Forms.Label labelArticleId;
        private System.Windows.Forms.TextBox textBoxArticleId;
        private System.Windows.Forms.NumericUpDown numericUpDownOrderedQuantity;
        private System.Windows.Forms.NumericUpDown numericUpDownPaidQuantity;
        private System.Windows.Forms.NumericUpDown numericUpDownPrice;
    }
}