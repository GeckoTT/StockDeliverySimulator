using CareFusion.Lib.StorageSystem.Output;
using System;
using System.Windows.Forms;

namespace CareFusion.ITSystemSimulator
{
    /// <summary>
    /// Dialog to add new order items.
    /// </summary>
    public partial class FOrderItem : Form
    {
        #region Members

        /// <summary>
        /// Holds the output process reference to use.
        /// </summary>
        private IOutputProcess _outputProcess;

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="FOrderItem" /> class.
        /// </summary>
        /// <param name="outputProcess">The output process reference to use.</param>
        /// <param name="articleList">The article list to use.</param>
        public FOrderItem(IOutputProcess outputProcess, string[] articleList)
        {
            InitializeComponent();

            if (outputProcess == null)
            {
                throw new ArgumentException("Invalid outputProcess specified.");
            }

            _outputProcess = outputProcess;

            if (articleList != null)
            {
                for (int i = 0; i < articleList.Length; ++i)
                {
                    cmbArticleId.Items.Add(articleList[i]);
                }
            }
        }

        /// <summary>
        /// Handles the CheckedChanged event of the checkExpiryDate control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void checkExpiryDate_CheckedChanged(object sender, EventArgs e)
        {
            dtExpiryDate.Enabled = checkExpiryDate.Checked;
        }

        /// <summary>
        /// Handles the ValueChanged event of the numQuantity control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void numQuantity_ValueChanged(object sender, EventArgs e)
        {
            if (numQuantity.Value > 0)
            {
                numSubItemQuantity.Value = 0;
            }
        }

        /// <summary>
        /// Handles the ValueChanged event of the numSubItemQuantity control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void numSubItemQuantity_ValueChanged(object sender, EventArgs e)
        {
            if (numSubItemQuantity.Value > 0)
            {
                numQuantity.Value = 0;
            }
        }

        /// <summary>
        /// Handles the Click event of the btnOK control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (VerifyData() == false)
            {
                return;
            }

            DateTime? expiryDate = null;
            ulong packID = 0;

            if (checkExpiryDate.Checked)
            {
                expiryDate = dtExpiryDate.Value;
            }

            if (ulong.TryParse(txtPackID.Text, out packID) == false)
            {
                packID = 0;
            }

            _outputProcess.AddCriteria(cmbArticleId.Text,
                                       (uint)numQuantity.Value,
                                       txtBatchNumber.Text,
                                       txtExternalID.Text,
                                       expiryDate,
                                       packID,
                                       (uint)numSubItemQuantity.Value,
                                       string.IsNullOrEmpty(txtStockLocation.Text) ? null : txtStockLocation.Text,
                                       string.IsNullOrEmpty(txtMachineLocation.Text) ? null : txtMachineLocation.Text,
                                       chkSingleBatch.Checked);

            if (string.IsNullOrEmpty(txtTemplateID.Text) == false)
            {
                _outputProcess.Criteria[_outputProcess.Criteria.Length - 1].AddLabel(txtTemplateID.Text, txtLabelContent.Text);
            }
            
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        /// <summary>
        /// Handles the Click event of the btnCancel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        /// <summary>
        /// Verifies the validity of the current configuration.
        /// </summary>
        /// <returns><c>true</c> if data is valid; <c>false</c> otherwise.</returns>
        private bool VerifyData()
        {
            long packID = 0;

            if ((string.IsNullOrEmpty(cmbArticleId.Text)) &&
                (string.IsNullOrEmpty(txtBatchNumber.Text)) &&
                (string.IsNullOrEmpty(txtExternalID.Text)) &&
                (checkExpiryDate.Checked == false) &&
                (long.TryParse(txtPackID.Text, out packID) == false))
            {
                return false;
            }

            if ((numQuantity.Value == 0) &&
                (numSubItemQuantity.Value == 0))
            {
                return false;
            }

            if (string.IsNullOrEmpty(txtTemplateID.Text) !=
                string.IsNullOrEmpty(txtLabelContent.Text))
            {
                return false;
            }

            return true;
        }

    }
        
}
