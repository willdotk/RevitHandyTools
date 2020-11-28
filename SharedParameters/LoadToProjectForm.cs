using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Autodesk.Revit.DB;

namespace RevitHandyTools.SharedParameters
{
    public partial class LoadToProjectForm : System.Windows.Forms.Form
    {
        public DefinitionFile definitionfile = null;

        public Autodesk.Revit.ApplicationServices.Application app = null;
        public Document doc = null;

        public object selectedGroup = null;
        public object definitionGroup = null;

        public LoadToProjectForm(Document document, Autodesk.Revit.ApplicationServices.Application application)
        {
            InitializeComponent();

            app = application;
            doc = document;

            definitionfile = app.OpenSharedParameterFile();

            List<string> definitionGroupList = new SharedParametersLibrary(doc,app).GetDefinitionGroupList();
            Dictionary<string, BuiltInParameterGroup> builtInParameterGroupDictionary = new SharedParametersLibrary(doc,app).BuiltInParameterGroupDictionary(doc);
            SortedList<string, Category> paramCategoryList = new SharedParametersLibrary(doc,app).ParameterCategoryList(doc);

            GroupSelectComboBox.Items.AddRange(definitionGroupList.ToArray());
            ParameterList.Items.Add("Please select a group.");
            GroupParameterUnderComboBox.Items.AddRange(builtInParameterGroupDictionary.Keys.ToArray());
            CategoryCheckList.Items.AddRange(paramCategoryList.Keys.ToList().ToArray());
            InstanceCheck.Checked = true;
        }

        public void AddParametersToProject(Document doc, Autodesk.Revit.ApplicationServices.Application app)
        {
            Dictionary<string, BuiltInParameterGroup> builtInParameterGroupDictionary = new SharedParametersLibrary(doc,app).BuiltInParameterGroupDictionary(doc);
            SortedList<string, Category> parameterCategoryList = new SharedParametersLibrary(doc,app).ParameterCategoryList(doc);
            
            selectedGroup = GroupParameterUnderComboBox.SelectedItem;
            string selectedGroupName = selectedGroup.ToString();

            definitionGroup = GroupSelectComboBox.SelectedItem;
            string definitionGroupName = definitionGroup.ToString();

            BuiltInParameterGroup builtInParameterGroup = builtInParameterGroupDictionary[selectedGroupName];

            SortedList<string, ExternalDefinition> sharedParameterList = new SharedParametersLibrary(doc, app).GetSharedParameterList(definitionGroupName);

            CategorySet categoryset = app.Create.NewCategorySet();
            foreach (string category in CategoryCheckList.CheckedItems)
            {
                categoryset.Insert(parameterCategoryList[category]);
            }

            // existing shared parameter list
            List<string> collectorList = new List<string>();
            List<string> existingParameterList = new List<string>();
            List<string> nonExistingParameterList = new List<string>();
            FilteredElementCollector parameterCollector = new FilteredElementCollector(doc);
            parameterCollector.OfClass(typeof(SharedParameterElement));

            foreach (var e in parameterCollector)
            {
                collectorList.Add(e.Name.ToString());
            }

            foreach(string parameter in ParameterList.SelectedItems)
            {
                if (collectorList.Contains(parameter))
                {
                    existingParameterList.Add(parameter);
                }
                else
                {
                    nonExistingParameterList.Add(parameter);
                }
            }

            using (Transaction tx = new Transaction(doc))
            {
                tx.Start("Add Selected Shared Parameters");

                foreach (string selectedParameter in nonExistingParameterList)
                {
                    if ((sharedParameterList.ContainsKey(selectedParameter)) && (TypeCheck.Checked))
                    {
                        ExternalDefinition externalDefinition = 
                            new SharedParametersLibrary(doc, app).ExternalDefinitionExtractor(selectedParameter,sharedParameterList);
                        TypeBinding newBinding = app.Create.NewTypeBinding(categoryset);
                        doc.ParameterBindings.Insert(externalDefinition, newBinding, builtInParameterGroup);
                    }
                    else if ((sharedParameterList.ContainsKey(selectedParameter)) && (InstanceCheck.Checked))
                    {
                        ExternalDefinition externalDefinition = 
                            new SharedParametersLibrary(doc, app).ExternalDefinitionExtractor(selectedParameter, sharedParameterList);
                        InstanceBinding newBinding = app.Create.NewInstanceBinding(categoryset);
                        doc.ParameterBindings.Insert(externalDefinition, newBinding, builtInParameterGroup);
                    }
                    else
                    {
                    }
                }
                foreach (string selectedParameter in existingParameterList)
                {
                    if ((sharedParameterList.ContainsKey(selectedParameter)) && (TypeCheck.Checked))
                    {
                        ExternalDefinition externalDefinition =
                            new SharedParametersLibrary(doc, app).ExternalDefinitionExtractor(selectedParameter, sharedParameterList);
                        TypeBinding newBinding = app.Create.NewTypeBinding(categoryset);
                        doc.ParameterBindings.ReInsert(externalDefinition, newBinding, builtInParameterGroup);
                    }
                    else if ((sharedParameterList.ContainsKey(selectedParameter)) && (InstanceCheck.Checked))
                    {
                        ExternalDefinition externalDefinition =
                            new SharedParametersLibrary(doc, app).ExternalDefinitionExtractor(selectedParameter, sharedParameterList);
                        InstanceBinding newBinding = app.Create.NewInstanceBinding(categoryset);
                        doc.ParameterBindings.ReInsert(externalDefinition, newBinding, builtInParameterGroup);
                    }
                    else
                    {
                    }
                }
                tx.Commit();
            }
        }

        private void GroupSelectComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            definitionGroup = GroupSelectComboBox.SelectedItem;
            string definitionGroupName = definitionGroup.ToString();

            SortedList<string, ExternalDefinition> sharedParameterList = new SharedParametersLibrary(doc, app).GetSharedParameterList(definitionGroupName);

            ParameterList.Items.Clear();
            foreach(KeyValuePair<string, ExternalDefinition> parameterKeyValue in sharedParameterList)
            {
                ParameterList.Items.Add(parameterKeyValue.Key);
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            // This solves issue that transaction does not start through button click event
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TypeCheck_CheckedChanged(object sender, EventArgs e)
        {
            InstanceCheck.Checked = !TypeCheck.Checked;
        }

        private void InstanceCheck_CheckedChanged(object sender, EventArgs e)
        {
            TypeCheck.Checked = !InstanceCheck.Checked;
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
