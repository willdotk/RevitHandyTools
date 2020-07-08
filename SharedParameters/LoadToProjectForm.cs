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

        public LoadToProjectForm(Document document, Autodesk.Revit.ApplicationServices.Application application)
        {
            InitializeComponent();

            app = application;
            doc = document;

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
            SortedList<string, Category> parameterCategoryList = new SharedParametersLibrary(doc,app).ParameterCategoryList(doc);

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

            foreach (KeyValuePair<string, Category> k in parameterCategoryList)
            {
                foreach (string category in CategoryCheckList.CheckedItems)
                {
                    if (category == k.Key)
                    {
                        categoryset.Insert(k.Value);
                    }
                }

            }



            // =========================================
            foreach (string selectedParameter in ParameterList.SelectedItems)
            {
                foreach (var dictPair in sharedParamDict)
                {
                    foreach (var innerPair in dictPair.Value)
                    {
                        if (innerPair.Key == selectedParameter)
                        {
                            
                        }
                    }

                }
            }



            // =========================================



            //using (Transaction tx = new Transaction(doc))
            //{
            //    tx.Start("Add Selected Shared Parameters");

            //    foreach (string selectedParameter in ParameterList.SelectedItems)
            //    {
            //        foreach (var dictPair in sharedParamDict)
            //        {
            //            foreach (var innerPair in dictPair.Value)
            //            {
            //                if (innerPair.Key == selectedParameter)
            //                {
            //                    if (TypeCheck.Checked)
            //                    {
            //                        TypeBinding newBinding = app.Create.NewTypeBinding(categoryset);
            //                        doc.ParameterBindings.Insert(dictPair.Key, newBinding, parameterGroupUnder);
            //                    }
            //                    else
            //                    {
            //                        InstanceBinding newBinding = app.Create.NewInstanceBinding(categoryset);
            //                        doc.ParameterBindings.Insert(dictPair.Key, newBinding, parameterGroupUnder);

            //                    }
            //                }
            //            }

            //        }
            //    }
            //    tx.Commit();
            //}
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
