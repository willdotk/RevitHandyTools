using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;


namespace RevitHandyTools.SharedParameters
{
    public partial class LoadToFamilyForm : System.Windows.Forms.Form
    {
        public DefinitionFile definitionfile = null;

        public Autodesk.Revit.ApplicationServices.Application app = null;
        public Document doc = null;

        public object selectedGroup = null;
        public object definitionGroup = null;

        public LoadToFamilyForm(Document document, Autodesk.Revit.ApplicationServices.Application application)
        {
            InitializeComponent();

            app = application;
            doc = document;

            definitionfile = app.OpenSharedParameterFile();

            List<string> groupList = new SharedParametersLibrary(doc, app).GetDefinitionGroupList();
            Dictionary<string, BuiltInParameterGroup> builtInParameterGroupDictionary = new SharedParametersLibrary(doc, app).BuiltInParameterGroupDictionary(doc);

            GroupSelectComboBox.Items.AddRange(groupList.ToArray());
            ParameterList.Items.Add("Please select a group.");
            GroupParameterUnderComboBox.Items.AddRange(builtInParameterGroupDictionary.Keys.ToArray());
            InstanceCheck.Checked = true;
        }

        public void AddParametersToFamily(Document doc, Autodesk.Revit.ApplicationServices.Application app)
        {
            Dictionary<string, BuiltInParameterGroup> builtInParameterGroupDictionary = new SharedParametersLibrary(doc, app).BuiltInParameterGroupDictionary(doc);
            SortedList<string, Category> parameterCategoryList = new SharedParametersLibrary(doc, app).ParameterCategoryList(doc);

            selectedGroup = GroupParameterUnderComboBox.SelectedItem;
            string selectedGroupName = selectedGroup.ToString();

            definitionGroup = GroupSelectComboBox.SelectedItem;
            string definitionGroupName = definitionGroup.ToString();

            BuiltInParameterGroup builtInParameterGroup = builtInParameterGroupDictionary[selectedGroupName];

            SortedList<string, ExternalDefinition> sharedParameterList = new SharedParametersLibrary(doc, app).GetSharedParameterList(definitionGroupName);

            FamilyManager familyManager = doc.FamilyManager;

            using (Transaction tx = new Transaction(doc))
            {
                tx.Start("Add Selected Shared Parameters");

                foreach (string selectedParameter in ParameterList.SelectedItems)
                {
                    if ((sharedParameterList.ContainsKey(selectedParameter)) && (TypeCheck.Checked))
                    {
                        ExternalDefinition externalDefinition =
                            new SharedParametersLibrary(doc, app).ExternalDefinitionExtractor(selectedParameter, sharedParameterList);
                        familyManager.AddParameter(externalDefinition, builtInParameterGroup, false);
                    }
                    else if ((sharedParameterList.ContainsKey(selectedParameter)) && (InstanceCheck.Checked))
                    {
                        ExternalDefinition externalDefinition =
                            new SharedParametersLibrary(doc, app).ExternalDefinitionExtractor(selectedParameter, sharedParameterList);
                        familyManager.AddParameter(externalDefinition, builtInParameterGroup, true);
                    }
                    else
                    {
                    }
                }
                tx.Commit();
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            // This solves issue that transaction does not start through button click event
            DialogResult = DialogResult.OK;
            Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TypeCheck_CheckedChanged(object sender, EventArgs e)
        {
            InstanceCheck.Checked = !TypeCheck.Checked;
        }

        private void InstanceCheck_CheckedChanged(object sender, EventArgs e)
        {
            TypeCheck.Checked = !InstanceCheck.Checked;

        }

        private void GroupSelectComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            definitionGroup = GroupSelectComboBox.SelectedItem;
            string definitionGroupName = definitionGroup.ToString();

            SortedList<string, ExternalDefinition> sharedParameterList = new SharedParametersLibrary(doc, app).GetSharedParameterList(definitionGroupName);

            ParameterList.Items.Clear();
            foreach (KeyValuePair<string, ExternalDefinition> parameterKeyValue in sharedParameterList)
            {
                ParameterList.Items.Add(parameterKeyValue.Key);
            }
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
    }
}
