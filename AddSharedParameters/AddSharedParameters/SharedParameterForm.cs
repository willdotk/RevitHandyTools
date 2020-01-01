using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AddSharedParameters
{
    public partial class SharedParameterForm : Form
    {
        public SharedParameterForm()
        {
            InitializeComponent();
            string[] name = new string[] { "item test 1", "item test 2", "item test 3" };
            checkedListBox1.Items.AddRange(name);
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}
