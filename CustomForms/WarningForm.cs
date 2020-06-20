using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RevitHandyTools.CustomForms
{
    public partial class WarningForm : Form
    {
        public WarningForm()
        {
            InitializeComponent();
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void LoadYes_Click(object sender, EventArgs e)
        {
            
        }

        public string WarningLabel
        {
            get
            {
                return this.WarningLabel1.Text;
            }
            set
            {
                this.WarningLabel1.Text = value;
            }
        }
    }
}
