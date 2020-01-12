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
        private UIApplication uiapp = null;
        private Autodesk.Revit.ApplicationServices.Application app = null;
        
        //public SharedParameterForm(List<string> lst1, List<string> lst2)
        public SharedParameterForm(ExternalCommandData commandData)
        {
            InitializeComponent();

            uiapp = commandData.Application;
            app = uiapp.Application;



            GroupSelection.Items.AddRange(GetGroupList().ToArray());
            //ParameterList.Items.AddRange(lst2.ToArray());
        }

        private List<string> GetGroupList()
        {
            DefinitionFile definitionfile = app.OpenSharedParameterFile();

            List<string> paramGroup = new List<string>();
            List<string> paramNames = new List<string>();

            foreach (DefinitionGroup definitionGroup in definitionfile.Groups)
            {
                paramGroup.Add(definitionGroup.Name.ToString());
                foreach (Definition definition in definitionGroup.Definitions)
                {
                    paramNames.Add(definition.Name.ToString());
                }
            }

            return paramGroup;
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
