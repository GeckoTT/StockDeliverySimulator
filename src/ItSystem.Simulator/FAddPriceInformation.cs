using CareFusion.Lib.StorageSystem.Sales;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CareFusion.ITSystemSimulator
{
    public partial class FAddPriceInformation : Form
    {
        public FAddPriceInformation()
        {
            InitializeComponent();
            comboBoxPriceCategory.Items.Add(PriceCategory.RRP);
            comboBoxPriceCategory.Items.Add(PriceCategory.Offer);
            comboBoxPriceCategory.Items.Add(PriceCategory.Other);
            comboBoxPriceCategory.SelectedIndex = 0;
        }
        public PriceCategory PriceCategory
        {
            get { return (PriceCategory)comboBoxPriceCategory.SelectedItem; }
        }

        public string Price
        {
            get { return textBoxPrice.Text; }
        }

        public int Quantity
        {
            get { return (int)numericUpDownQuantity.Value; }
        }

        public string BasePrice
        {
            get { return textBoxBasePrice.Text; }
        }

        public string BasePriceUnit
        {
            get { return textBoxBasePriceUnit.Text; }
        }

        public string VAT
        {
            get { return textBoxVAT.Text; }
        }

        public string Description
        {
            get { return textBoxDescription.Text; }
        }
    }
}
