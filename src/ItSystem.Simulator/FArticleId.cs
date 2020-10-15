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
    public partial class FArticleId : Form
    {
        public FArticleId()
        {
            InitializeComponent();
        }

        public string ArticleId
        {
            get { return textBoxArticleId.Text; }
        }
    }
}
