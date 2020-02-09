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
        public Object SelectedGroup = null;

        public Autodesk.Revit.ApplicationServices.Application app = null;
        public Document doc = null;

        public LoadToProjectForm(Document dOcument, Autodesk.Revit.ApplicationServices.Application aPplication)
        {
            InitializeComponent();

            app = aPplication;
            doc = dOcument;

            definitionfile = app.OpenSharedParameterFile();

            List<string> groupListDict = new SharedParametersLibrary(doc,app).GetGroupListFromDict();
            Dictionary<string, BuiltInParameterGroup> paramGroupUnderDict = new SharedParametersLibrary(doc,app).ParameterGroupUnderDict(doc);
            SortedList<string, Category> paramCategoryList = new SharedParametersLibrary(doc,app).ParameterCategoryList(doc);

            GroupSelectComboBox.Items.AddRange(groupListDict.ToArray());
            ParameterList.Items.Add("Please select a group.");
            GroupParameterUnderComboBox.Items.AddRange(paramGroupUnderDict.Keys.ToArray());
            CategoryCheckList.Items.AddRange(paramCategoryList.Keys.ToList().ToArray());
            InstanceCheck.Checked = true;
        }

        public void AddParametersToProject(Document doc, Autodesk.Revit.ApplicationServices.Application app)
        {
            Dictionary<string, BuiltInParameterGroup> paramGroupUnderDict = new SharedParametersLibrary(doc,app).ParameterGroupUnderDict(doc);
            Dictionary<ExternalDefinition, Dictionary<string, string>> sharedParamDict = new SharedParametersLibrary(doc,app).GetSharedParamDict();
            SortedList<string, Category> paramCategoryList = new SharedParametersLibrary(doc,app).ParameterCategoryList(doc);

            CategorySet categoryset = app.Create.NewCategorySet();

            BuiltInParameterGroup parameterGroupUnder = new BuiltInParameterGroup();
            string selectedGroup = GroupParameterUnderComboBox.SelectedItem.ToString();

            foreach (KeyValuePair<string, BuiltInParameterGroup> k in paramGroupUnderDict)
            {
                if (k.Key == selectedGroup)
                {
                    parameterGroupUnder = k.Value;
                }
            }

            //List<string> lst = new List<string>() { "Existing shared parameters cannot be added - " };

            using (Transaction tx = new Transaction(doc))
            {
                tx.Start("Add Selected Shared Parameters");

                foreach (string selectedParameter in ParameterList.SelectedItems)
                {
                    foreach (var dictPair in sharedParamDict)
                    {

                        foreach (var innerPair in dictPair.Value)
                        {
                            if (innerPair.Key.Contains(selectedParameter))
                            {
                                foreach (KeyValuePair<string, Category> k in paramCategoryList)
                                {

                                    foreach (string catString in CategoryCheckList.CheckedItems)
                                    {
                                        if (catString == k.Key)
                                        {
                                            categoryset.Insert(k.Value);

                                            if (TypeCheck.Checked)
                                            {
                                                TypeBinding newBinding = app.Create.NewTypeBinding(categoryset);
                                                doc.ParameterBindings.Insert(dictPair.Key, newBinding, parameterGroupUnder);
                                            }
                                            else
                                            {
                                                InstanceBinding newBinding = app.Create.NewInstanceBinding(categoryset);
                                                doc.ParameterBindings.Insert(dictPair.Key, newBinding, parameterGroupUnder);
                                            }
                                        }
                                    }

                                }
                            }
                        }

                    }
                }
                tx.Commit();
            }
            //TaskDialog.Show("T", String.Join(", ", lst.Distinct().ToArray()));
        }

        private void GroupSelectComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Dictionary<ExternalDefinition, Dictionary<string, string>> sharedParamDict = new SharedParametersLibrary(doc,app).GetSharedParamDict();

            ParameterList.Items.Clear();
            SelectedGroup = GroupSelectComboBox.SelectedItem;
            string selGroup = SelectedGroup.ToString();

            foreach (var dictPair in sharedParamDict)
            {
                foreach (var innerPair in dictPair.Value)
                {
                    if (innerPair.Value == selGroup)
                    {
                        ParameterList.Items.Add(innerPair.Key);
                    }
                }
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
    }
}
