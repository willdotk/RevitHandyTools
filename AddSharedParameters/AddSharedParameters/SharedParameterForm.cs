using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;


namespace AddSharedParameters
{
    public partial class SharedParameterForm : System.Windows.Forms.Form
    {
        private UIApplication uiapp = null;
        private Autodesk.Revit.ApplicationServices.Application app = null;
        private DefinitionFile definitionfile = null;
        private Object SelectedGroup = null;
        
        public SharedParameterForm(ExternalCommandData commandData)
        {
            InitializeComponent();

            uiapp = commandData.Application;
            app = uiapp.Application;
            definitionfile = app.OpenSharedParameterFile();

            GroupSelectComboBox.Items.AddRange(GetSharedParamDict().Values.Distinct().ToList().ToArray());
            //ParameterList.Items.AddRange(GetSharedParamDict().Keys.ToList().ToArray());

        }

        private Dictionary<string, string> GetSharedParamDict()
        {
            Dictionary<string, string> paramDict = new Dictionary<string, string>();

            foreach (DefinitionGroup definitionGroup in definitionfile.Groups)
            {
                string deGroupName = definitionGroup.Name.ToString();
                foreach (Definition definition in definitionGroup.Definitions)
                {
                    string deParamName = definition.Name.ToString();
                    if (!paramDict.ContainsKey(deParamName))
                    {
                        paramDict.Add(deParamName, deGroupName);
                    }
                }
            }
            return paramDict;
        }


        private void ParameterList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void AddButton_Click(object sender, EventArgs e)
        {
            
        }

        private void GroupSelectComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ParameterList.Items.Clear();
            SelectedGroup = GroupSelectComboBox.SelectedItem;
            string selGroup = SelectedGroup.ToString();
            List<string> selParamList = new List<string>();

            foreach (KeyValuePair<string, string> v in GetSharedParamDict())
            {
                if (v.Value == selGroup)
                {
                    ParameterList.Items.Add(v.Key);
                }
            }
        }
    }
}
