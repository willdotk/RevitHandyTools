using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.ApplicationServices;


namespace AddSharedParameters
{
    public partial class SharedParameterForm : System.Windows.Forms.Form
    {
        public SharedParameterForm(List<string> lst1, List<string> lst2)
        {
            InitializeComponent();

            GroupSelection.Items.AddRange(lst1.ToArray());
            ParameterList.Items.AddRange(lst2.ToArray());


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void AddButton_Click(object sender, EventArgs e)
        {
            
        }
    }
}
