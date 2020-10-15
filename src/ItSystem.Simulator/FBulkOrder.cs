using CareFusion.Lib.StorageSystem;
using CareFusion.Lib.StorageSystem.Output;
using CareFusion.Lib.StorageSystem.Stock;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CareFusion.ITSystemSimulator
{
    /// <summary>
    /// Form to create a new set of bulk Output Orders.
    /// </summary>
    public partial class FBulkOrder : Form
    {
        #region Members

        /// <summary>
        /// List of currently active articles and their packs.
        /// </summary>
        private Dictionary<string, List<IPack>> _articlePacks;

        /// <summary>
        /// Storage system instance to use.
        /// </summary>
        private IStorageSystem _storageSystem;

        /// <summary>
        /// List of generated orders.
        /// </summary>
        private List<IOutputProcess> _orders = new List<IOutputProcess>();

        #endregion

        #region Properties

        /// <summary>
        /// Gets the newly created output orders.
        /// </summary>
        public IOutputProcess[] Orders
        {
            get { return _orders.ToArray(); }
        }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="FBulkOrder" /> class.
        /// </summary>
        /// <param name="storageSystem">The storage system instance to use.</param>
        /// <param name="articlePackCounts">The article pack counts to use.</param>
        public FBulkOrder(IStorageSystem storageSystem, Dictionary<string, List<IPack>> articlePacks)
        {
            if (storageSystem == null)
            {
                throw new ArgumentException("Invalid storageSystem specified.");
            }
            
            InitializeComponent();
            _storageSystem = storageSystem;
            _articlePacks = articlePacks;
        }

        /// <summary>
        /// Handles the Load event of the FBulkOrder control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void FBulkOrder_Load(object sender, EventArgs e)
        {
            cmbPriority.SelectedIndex = 1;
        }

        /// <summary>
        /// Handles the Click event of the btnOK control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (chkAllMachines.Checked)
            {
                GenerateAllMachineOrders();
            }
            else
            {
                GenerateRegularOrders();
            }
            
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        /// <summary>
        /// Generates the orders on a regular base.
        /// </summary>
        private void GenerateRegularOrders()
        {
            OutputProcessPriority priority = OutputProcessPriority.Normal;

            switch (cmbPriority.SelectedIndex)
            {
                case 0: priority = OutputProcessPriority.Low; break;
                case 1: priority = OutputProcessPriority.Normal; break;
                case 2: priority = OutputProcessPriority.High; break;
            }

            var articleList = new List<string>(_articlePacks.Keys);
            var boxNumberList = new List<string>();
            var boxNumberIndex = 0;

            if (string.IsNullOrWhiteSpace(txtBoxNumbers.Text) == false)
                boxNumberList.AddRange(txtBoxNumbers.Text.Trim().Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries));

            foreach (var article in articleList.ToArray())
            {
                if (article.Length > 20)
                {
                    _articlePacks.Remove(article);
                    articleList.Remove(article);
                }
            }

            if (string.IsNullOrEmpty(txtMachineLocation.Text) == false)
            {
                foreach (var article in articleList.ToArray())
                {
                    foreach (var pack in _articlePacks[article].ToArray())
                    {
                        if (pack.MachineLocation != txtMachineLocation.Text)
                            _articlePacks[article].Remove(pack);
                    }

                    if (_articlePacks[article].Count == 0)
                    {
                        _articlePacks.Remove(article);
                        articleList.Remove(article);
                    }
                }
            }

            for (int i = 0; i < numOrderCount.Value; ++i)
            {
                int orderNumber = Convert.ToInt32(numStartOrderNumber.Value) + i;
                string boxNumber = null;

                if (boxNumberList.Count > 0)
                {
                    boxNumber = boxNumberList[boxNumberIndex++].Trim();

                    if (boxNumberIndex >= boxNumberList.Count)
                        boxNumberIndex = 0;

                }
                else if (string.IsNullOrEmpty(txtStartBoxNumber.Text) == false)
                {
                    int startBoxNumber = 0;

                    if (int.TryParse(txtStartBoxNumber.Text, out startBoxNumber))
                        boxNumber = (startBoxNumber + i).ToString();
                    else
                        boxNumber = txtStartBoxNumber.Text + i.ToString();
                }

                var order = _storageSystem.CreateOutputProcess(orderNumber,
                                                               Convert.ToInt32(numDestination.Value),
                                                               0,
                                                               priority,
                                                               boxNumber);

                int remainingPacks = Convert.ToInt32(numPackCount.Value);

                while (remainingPacks > 0)
                {
                    foreach (var article in articleList.ToArray())
                    {
                        int requestedPacks = Math.Min(remainingPacks, _articlePacks[article].Count);

                        if (string.IsNullOrEmpty(txtMachineLocation.Text) == false)
                            order.AddCriteria(article, (uint)requestedPacks, null, null, null, 0, 0, null, txtMachineLocation.Text);
                        else
                            order.AddCriteria(article, (uint)requestedPacks);

                        _articlePacks[article].RemoveRange(0, requestedPacks);
                        remainingPacks -= requestedPacks;

                        if (_articlePacks[article].Count == 0)
                        {
                            _articlePacks.Remove(article);
                            articleList.Remove(article);
                        }

                        if (remainingPacks == 0)
                        {
                            break;
                        }
                    }

                    if (_articlePacks.Count == 0)
                    {
                        break;
                    }
                }

                _orders.Add(order);
            }
        }

        /// <summary>
        /// Generates the orders in a way that all machines are used if possible.
        /// </summary>
        private void GenerateAllMachineOrders()
        {
            OutputProcessPriority priority = OutputProcessPriority.Normal;

            switch (cmbPriority.SelectedIndex)
            {
                case 0: priority = OutputProcessPriority.Low; break;
                case 1: priority = OutputProcessPriority.Normal; break;
                case 2: priority = OutputProcessPriority.High; break;
            }

            var articleList = new List<string>(_articlePacks.Keys);
            var boxNumberList = new List<string>();
            var boxNumberIndex = 0;

            if (string.IsNullOrWhiteSpace(txtBoxNumbers.Text) == false)
                boxNumberList.AddRange(txtBoxNumbers.Text.Trim().Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries));

            foreach (var article in articleList.ToArray())
            {
                if (article.Length > 20)
                {
                    _articlePacks.Remove(article);
                    articleList.Remove(article);
                }
            }

            var machineList = new List<string>();

            foreach (var article in articleList.ToArray())
            {
                foreach (var pack in _articlePacks[article].ToArray())
                {
                    if (machineList.Contains(pack.MachineLocation) == false)
                        machineList.Add(pack.MachineLocation);
                }
            }

            for (int i = 0; i < numOrderCount.Value; ++i)
            {
                int orderNumber = Convert.ToInt32(numStartOrderNumber.Value) + i;
                string boxNumber = null;

                if (boxNumberList.Count > 0)
                {
                    boxNumber = boxNumberList[boxNumberIndex++].Trim();

                    if (boxNumberIndex >= boxNumberList.Count)
                        boxNumberIndex = 0;

                }
                else if (string.IsNullOrEmpty(txtStartBoxNumber.Text) == false)
                {
                    int startBoxNumber = 0;

                    if (int.TryParse(txtStartBoxNumber.Text, out startBoxNumber))
                        boxNumber = (startBoxNumber + i).ToString();
                    else
                        boxNumber = txtStartBoxNumber.Text + i.ToString();
                }

                var order = _storageSystem.CreateOutputProcess(orderNumber,
                                                               Convert.ToInt32(numDestination.Value),
                                                               0,
                                                               priority,
                                                               boxNumber);

                int remainingPacks = Convert.ToInt32(numPackCount.Value);

                while (remainingPacks > 0)
                {
                    foreach (var machine in machineList)
                    {
                        var packAdded = false;

                        foreach (var article in articleList.ToArray())
                        {
                            foreach (var pack in _articlePacks[article])
                            {
                                if (pack.MachineLocation == machine)
                                {
                                    order.AddCriteria(article, 1, null, null, null, 0, 0, null, machine);
                                    _articlePacks[article].Remove(pack);
                                    remainingPacks -= 1;
                                    packAdded = true;
                                    break;
                                }
                            }

                            if (_articlePacks[article].Count == 0)
                            {
                                _articlePacks.Remove(article);
                                articleList.Remove(article);
                            }

                            if (remainingPacks == 0)
                                break;

                            if (packAdded)
                                break;                            
                        }

                        if (_articlePacks.Count == 0)
                        {
                            break;
                        }
                    }

                    if (_articlePacks.Count == 0)
                    {
                        break;
                    }
                }

                _orders.Add(order);
            }
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
    }
}
