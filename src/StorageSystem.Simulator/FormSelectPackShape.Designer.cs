namespace StorageSystemSimulator
{
    partial class FormSelectPackShape
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
            this.radioButtonCuboid = new System.Windows.Forms.RadioButton();
            this.radioButtonCylinder = new System.Windows.Forms.RadioButton();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // radioButtonCuboid
            // 
            this.radioButtonCuboid.AutoSize = true;
            this.radioButtonCuboid.Location = new System.Drawing.Point(12, 12);
            this.radioButtonCuboid.Name = "radioButtonCuboid";
            this.radioButtonCuboid.Size = new System.Drawing.Size(73, 21);
            this.radioButtonCuboid.TabIndex = 0;
            this.radioButtonCuboid.TabStop = true;
            this.radioButtonCuboid.Text = "Cuboid";
            this.radioButtonCuboid.UseVisualStyleBackColor = true;
            // 
            // radioButtonCylinder
            // 
            this.radioButtonCylinder.AutoSize = true;
            this.radioButtonCylinder.Location = new System.Drawing.Point(12, 39);
            this.radioButtonCylinder.Name = "radioButtonCylinder";
            this.radioButtonCylinder.Size = new System.Drawing.Size(80, 21);
            this.radioButtonCylinder.TabIndex = 1;
            this.radioButtonCylinder.TabStop = true;
            this.radioButtonCylinder.Text = "Cylinder";
            this.radioButtonCylinder.UseVisualStyleBackColor = true;
            // 
            // buttonOk
            // 
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.Location = new System.Drawing.Point(12, 66);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 12;
            this.buttonOk.Text = "Ok";
            this.buttonOk.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(93, 66);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 11;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // FormSelectPackShape
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(187, 103);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.radioButtonCylinder);
            this.Controls.Add(this.radioButtonCuboid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSelectPackShape";
            this.Text = "FormSelectPackShape";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radioButtonCuboid;
        private System.Windows.Forms.RadioButton radioButtonCylinder;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
    }
}