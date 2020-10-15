using CareFusion.Lib.StorageSystem;
using CareFusion.Lib.StorageSystem.Output;
using System;
using System.Windows.Forms;

namespace CareFusion.ITSystemSimulator
{
    /// <summary>
    /// Form to create a new Output Order.
    /// </summary>
    public partial class FOrder : Form
    {
        #region Members

        /// <summary>
        /// List of currently active articles.
        /// </summary>
        private string[] _articleList;

        /// <summary>
        /// Storage system instance to use.
        /// </summary>
        private IStorageSystem _storageSystem;

        /// <summary>
        /// Newly created output order.
        /// </summary>
        private IOutputProcess _order;

        /// <summary>
        /// Order number generator.
        /// </summary>
        private static int _orderNumberGenerator = 99;

        #endregion

        #region Properties

        /// <summary>
        /// Gets the newly created output order.
        /// </summary>
        public IOutputProcess Order
        {
            get { return _order;  }
        }

        #endregion


        /// <summary>
        /// Initializes a new instance of the <see cref="FOrder" /> class.
        /// </summary>
        /// <param name="storageSystem">The storage system instance to use.</param>
        /// <param name="articleList">The article list to use.</param>
        public FOrder(IStorageSystem storageSystem, string[] articleList)
        {
            if (storageSystem == null)
            {
                throw new ArgumentException("Invalid storageSystem specified.");
            }
            
            InitializeComponent();
            _storageSystem = storageSystem;
            _articleList = articleList;
            _orderNumberGenerator++;
            txtOrderNumber.Text = _orderNumberGenerator.ToString();
        }

        /// <summary>
        /// Handles the Load event of the FOrder control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void FOrder_Load(object sender, EventArgs e)
        {
            cmbPriority.SelectedIndex = 1;
        }

        /// <summary>
        /// Handles the Click event of the btnAddItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnAddItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (_order == null)
                {
                    _order = CreateNewOrder(false);
                }

                var addOrderItem = new FOrderItem(_order, _articleList);
                addOrderItem.ShowDialog(this);
                lblNumItems.Text = _order.Criteria.Length.ToString();
            }
            catch (Exception)
            {
            }    
        }

        /// <summary>
        /// Handles the TextChanged event of the txtOrderNumber control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void txtOrderNumber_TextChanged(object sender, EventArgs e)
        {
            btnOK.Enabled = (string.IsNullOrWhiteSpace(txtOrderNumber.Text) == false);

            if (btnOK.Enabled == false)
                return;

            try
            {
                _order = CreateNewOrder(true);
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the cmbPriority control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void cmbPriority_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                _order = CreateNewOrder(true);
            }
            catch (Exception)
            {
            }    
        }

        /// <summary>
        /// Handles the ValueChanged event of the numDestination control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void numDestination_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                _order = CreateNewOrder(true);
            }
            catch (Exception)
            {
            }    
        }

        /// <summary>
        /// Handles the ValueChanged event of the numPoint control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void numPoint_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                _order = CreateNewOrder(true);
            }
            catch (Exception)
            {
            }    
        }

        /// <summary>
        /// Handles the TextChanged event of the txtBoxNumber control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void txtBoxNumber_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _order = CreateNewOrder(true);
            }
            catch (Exception)
            {
            }    
        }

        /// <summary>
        /// Creates a new output order.
        /// </summary>
        /// <param name="copyExistingItems">if set to <c>true</c> items of a possible existing order.</param>
        /// <returns>Newly created order or null.</returns>
        private IOutputProcess CreateNewOrder(bool copyExistingItems)
        {
            OutputProcessPriority priority = OutputProcessPriority.Normal;

            switch (cmbPriority.SelectedIndex)
            {
                case 0: priority = OutputProcessPriority.Low; break;
                case 1: priority = OutputProcessPriority.Normal; break;
                case 2: priority = OutputProcessPriority.High; break;
            }

            var result = _storageSystem.CreateOutputProcess(txtOrderNumber.Text,
                                                            (int)numDestination.Value,
                                                            (int)numPoint.Value,
                                                            priority,
                                                            txtBoxNumber.Text);

            if ((copyExistingItems) && (_order != null))
            {
                foreach (var criteria in _order.Criteria)
                {
                    result.AddCriteria(criteria.ArticleId,
                                       criteria.Quantity,
                                       criteria.BatchNumber,
                                       criteria.ExternalId,
                                       criteria.MinimumExpiryDate,
                                       criteria.PackId,
                                       criteria.SubItemQuantity);
                }

                for (int i = 0; i < _order.Criteria.Length; ++i)
                {
                    foreach (var label in _order.Criteria[i].Labels)
                    {
                        result.Criteria[i].AddLabel(label.TemplateId, label.Content);
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Handles the Click event of the btnOK control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        /// <summary>
        /// Handles the Click event of the btnCancel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            _order = null;
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}
