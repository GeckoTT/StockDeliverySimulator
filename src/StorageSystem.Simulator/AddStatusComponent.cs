using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CareFusion.Mosaic.Interfaces.Messages.Status;

namespace StorageSystemSimulator
{
    public partial class AddStatusComponent : Form
    {
        public AddStatusComponent()
        {
            InitializeComponent();
            this.comboBoxType.SelectedIndex = 0;
        }
        

        public StatusComponent GetStatusComponent()
        {
            StatusComponent statusComponent = new StatusComponent();

            statusComponent.Type = (string)comboBoxType.SelectedItem;
            statusComponent.Description = textBoxDescription.Text;
            statusComponent.State = radioButtonReady.Checked ? StatusType.Ready : StatusType.NotReady;
            statusComponent.StateDescription = textBoxStateText.Text;

            return statusComponent;

        }

        private void comboBoxType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
