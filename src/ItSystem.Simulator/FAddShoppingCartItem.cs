using System.Windows.Forms;

namespace CareFusion.ITSystemSimulator
{
    public partial class FAddShoppingCartItem : Form
    {
        public FAddShoppingCartItem()
        {
            InitializeComponent();
        }

        public string ArticleId
        {
            get { return textBoxArticleId.Text; }
        }

        public string Currency
        {
            get { return textBoxCurrency.Text; }
        }

        public uint DispensedQuantity
        {
            get { return (uint)numericUpDownDispensedQuantity.Value; }
        }

        public uint OrderedQuantity
        {
            get { return (uint)numericUpDownOrderedQuantity.Value; }
        }
        
        public uint PaidQuantity
        {
            get { return (uint)numericUpDownPaidQuantity.Value; }
        }

        public uint Price
        {
            get { return (uint)numericUpDownPrice.Value; }
        }
    }
}
