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
        public SharedParameterForm(List<string> lst1, List<string> lst2)
        {
            InitializeComponent();
            comboBox1.Items.AddRange(lst1.ToArray());
            //checkedListBox1.Items.AddRange(lst2.ToArray());

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (Object item in checkedListBox1.CheckedItems)
            {
                listBox1.Items.Add(item);
            }
        }
    }
}
