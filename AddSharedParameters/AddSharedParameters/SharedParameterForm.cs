using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;


namespace AddSharedParameters
{
    public partial class SharedParameterForm : System.Windows.Forms.Form
    {
        private DefinitionFile definitionfile = null;
        private Object SelectedGroup = null;

        private Autodesk.Revit.ApplicationServices.Application app = null;
        private Document doc = null;

        public SharedParameterForm(Document dOcument, Autodesk.Revit.ApplicationServices.Application aPplication)
        {
            InitializeComponent();

            app = aPplication;
            doc = dOcument;

            definitionfile = app.OpenSharedParameterFile();

            GroupSelectComboBox.Items.AddRange(GetGroupListFromDict().ToArray());
            ParameterList.Items.Add("Please select a group.");
            GroupParameterUnderComboBox.Items.AddRange(ParameterGroupUnderDict(doc).Keys.ToArray());
            CategoryCheckList.Items.AddRange(ParameterCategoryList(doc).Keys.ToList().ToArray());
        }

        private Dictionary<ExternalDefinition, Dictionary<string, string>> GetSharedParamDict()
        {
            Dictionary<ExternalDefinition, Dictionary<string, string>> paramDict = new Dictionary<ExternalDefinition, Dictionary<string, string>>();

            foreach (DefinitionGroup definitionGroup in definitionfile.Groups)
            {
                string deGroupName = definitionGroup.Name;
                foreach (Definition definition in definitionGroup.Definitions)
                {
                    ExternalDefinition exDefinitionParamName = definition as ExternalDefinition;
                    string deParamName = definition.Name;
                    Dictionary<string, string> tempDict = new Dictionary<string, string>();
                    tempDict.Add(deParamName,deGroupName);

                    if (!paramDict.ContainsKey(exDefinitionParamName))
                    {
                        paramDict.Add(exDefinitionParamName, tempDict);
                    }
                }
            }
            return paramDict;
        }

        private List<string> GetGroupListFromDict()
        {
            List<string> lst = new List<string>();
            foreach (var dictPair in GetSharedParamDict())
            {
                foreach (var innerPair in dictPair.Value)
                {
                    if (!lst.Contains(innerPair.Value))
                    {
                        lst.Add(innerPair.Value);
                    }
                }
            }
            return lst;
        }

        private SortedList<string, Category> ParameterCategoryList(Document doc)
        {
            Categories categories = doc.Settings.Categories;
            
            SortedList<string, Category> categoryList = new SortedList<string, Category>();

            foreach(Category cat in categories)
            {
                if (cat.AllowsBoundParameters)
                {
                    categoryList.Add(cat.Name, cat);
                }
            }
            return categoryList;
        }

        public static string FirstCharToUpper(string inputString)
        {
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            string removePG = Regex.Replace(inputString, @"PG_", "");
            string lowerString = Regex.Replace(removePG, @"_", " ").ToLower();
            string groupString = textInfo.ToTitleCase(lowerString);
            return groupString;
        }

        private Dictionary<string, BuiltInParameterGroup> ParameterGroupUnderDict(Document doc)
        {
            Dictionary<string, BuiltInParameterGroup> validGroups = new Dictionary<string, BuiltInParameterGroup>();
            validGroups.Add(FirstCharToUpper(BuiltInParameterGroup.PG_ANALYSIS_RESULTS.ToString()), BuiltInParameterGroup.PG_ANALYSIS_RESULTS);
            validGroups.Add(FirstCharToUpper(BuiltInParameterGroup.PG_ANALYTICAL_ALIGNMENT.ToString()), BuiltInParameterGroup.PG_ANALYTICAL_ALIGNMENT);
            validGroups.Add(FirstCharToUpper(BuiltInParameterGroup.PG_ANALYTICAL_MODEL.ToString()), BuiltInParameterGroup.PG_ANALYTICAL_MODEL);
            validGroups.Add(FirstCharToUpper(BuiltInParameterGroup.PG_CONSTRAINTS.ToString()), BuiltInParameterGroup.PG_CONSTRAINTS);
            validGroups.Add(FirstCharToUpper(BuiltInParameterGroup.PG_CONSTRUCTION.ToString()), BuiltInParameterGroup.PG_CONSTRUCTION);
            validGroups.Add(FirstCharToUpper(BuiltInParameterGroup.PG_DATA.ToString()), BuiltInParameterGroup.PG_DATA);
            validGroups.Add(FirstCharToUpper(BuiltInParameterGroup.PG_GEOMETRY.ToString()), BuiltInParameterGroup.PG_GEOMETRY); // Dimensions
            validGroups.Add(FirstCharToUpper(BuiltInParameterGroup.PG_DIVISION_GEOMETRY.ToString()), BuiltInParameterGroup.PG_DIVISION_GEOMETRY);
            validGroups.Add(FirstCharToUpper(BuiltInParameterGroup.PG_AELECTRICAL.ToString()), BuiltInParameterGroup.PG_AELECTRICAL);
            validGroups.Add(FirstCharToUpper(BuiltInParameterGroup.PG_ELECTRICAL_CIRCUITING.ToString()), BuiltInParameterGroup.PG_ELECTRICAL_CIRCUITING);
            validGroups.Add(FirstCharToUpper(BuiltInParameterGroup.PG_ELECTRICAL_LIGHTING.ToString()), BuiltInParameterGroup.PG_ELECTRICAL_LIGHTING);
            validGroups.Add(FirstCharToUpper(BuiltInParameterGroup.PG_ELECTRICAL_LOADS.ToString()), BuiltInParameterGroup.PG_ELECTRICAL_LOADS);
            validGroups.Add(FirstCharToUpper(BuiltInParameterGroup.PG_ELECTRICAL.ToString()), BuiltInParameterGroup.PG_ELECTRICAL);
            validGroups.Add(FirstCharToUpper(BuiltInParameterGroup.PG_ENERGY_ANALYSIS.ToString()), BuiltInParameterGroup.PG_ENERGY_ANALYSIS);
            validGroups.Add(FirstCharToUpper(BuiltInParameterGroup.PG_FIRE_PROTECTION.ToString()), BuiltInParameterGroup.PG_FIRE_PROTECTION);
            validGroups.Add(FirstCharToUpper(BuiltInParameterGroup.PG_FORCES.ToString()), BuiltInParameterGroup.PG_FORCES);
            validGroups.Add(FirstCharToUpper(BuiltInParameterGroup.PG_GENERAL.ToString()), BuiltInParameterGroup.PG_GENERAL);
            validGroups.Add(FirstCharToUpper(BuiltInParameterGroup.PG_GRAPHICS.ToString()), BuiltInParameterGroup.PG_GRAPHICS);
            validGroups.Add(FirstCharToUpper(BuiltInParameterGroup.PG_GREEN_BUILDING.ToString()), BuiltInParameterGroup.PG_GREEN_BUILDING);
            validGroups.Add(FirstCharToUpper(BuiltInParameterGroup.PG_IDENTITY_DATA.ToString()), BuiltInParameterGroup.PG_IDENTITY_DATA);
            validGroups.Add(FirstCharToUpper(BuiltInParameterGroup.PG_IFC.ToString()), BuiltInParameterGroup.PG_IFC);
            validGroups.Add(FirstCharToUpper(BuiltInParameterGroup.PG_REBAR_SYSTEM_LAYERS.ToString()), BuiltInParameterGroup.PG_REBAR_SYSTEM_LAYERS);
            validGroups.Add(FirstCharToUpper(BuiltInParameterGroup.PG_MATERIALS.ToString()), BuiltInParameterGroup.PG_MATERIALS);
            validGroups.Add(FirstCharToUpper(BuiltInParameterGroup.PG_MECHANICAL.ToString()), BuiltInParameterGroup.PG_MECHANICAL);
            validGroups.Add(FirstCharToUpper(BuiltInParameterGroup.PG_MECHANICAL_AIRFLOW.ToString()), BuiltInParameterGroup.PG_MECHANICAL_AIRFLOW);
            validGroups.Add(FirstCharToUpper(BuiltInParameterGroup.PG_MECHANICAL_LOADS.ToString()), BuiltInParameterGroup.PG_MECHANICAL_LOADS);
            validGroups.Add(FirstCharToUpper(BuiltInParameterGroup.PG_ADSK_MODEL_PROPERTIES.ToString()), BuiltInParameterGroup.PG_ADSK_MODEL_PROPERTIES);
            validGroups.Add(FirstCharToUpper(BuiltInParameterGroup.PG_MOMENTS.ToString()), BuiltInParameterGroup.PG_MOMENTS);
            validGroups.Add(FirstCharToUpper(BuiltInParameterGroup.INVALID.ToString()), BuiltInParameterGroup.INVALID); // other
            validGroups.Add(FirstCharToUpper(BuiltInParameterGroup.PG_OVERALL_LEGEND.ToString()), BuiltInParameterGroup.PG_OVERALL_LEGEND);
            validGroups.Add(FirstCharToUpper(BuiltInParameterGroup.PG_PHASING.ToString()), BuiltInParameterGroup.PG_PHASING);
            validGroups.Add(FirstCharToUpper(BuiltInParameterGroup.PG_LIGHT_PHOTOMETRICS.ToString()), BuiltInParameterGroup.PG_LIGHT_PHOTOMETRICS);
            validGroups.Add(FirstCharToUpper(BuiltInParameterGroup.PG_PLUMBING.ToString()), BuiltInParameterGroup.PG_PLUMBING);
            validGroups.Add(FirstCharToUpper(BuiltInParameterGroup.PG_PRIMARY_END.ToString()), BuiltInParameterGroup.PG_PRIMARY_END);
            validGroups.Add(FirstCharToUpper(BuiltInParameterGroup.PG_REBAR_ARRAY.ToString()), BuiltInParameterGroup.PG_REBAR_ARRAY);
            validGroups.Add(FirstCharToUpper(BuiltInParameterGroup.PG_RELEASES_MEMBER_FORCES.ToString()), BuiltInParameterGroup.PG_RELEASES_MEMBER_FORCES);
            validGroups.Add(FirstCharToUpper(BuiltInParameterGroup.PG_SECONDARY_END.ToString()), BuiltInParameterGroup.PG_SECONDARY_END);
            validGroups.Add(FirstCharToUpper(BuiltInParameterGroup.PG_SEGMENTS_FITTINGS.ToString()), BuiltInParameterGroup.PG_SEGMENTS_FITTINGS);
            validGroups.Add(FirstCharToUpper(BuiltInParameterGroup.PG_SLAB_SHAPE_EDIT.ToString()), BuiltInParameterGroup.PG_SLAB_SHAPE_EDIT);
            validGroups.Add(FirstCharToUpper(BuiltInParameterGroup.PG_STRUCTURAL.ToString()), BuiltInParameterGroup.PG_STRUCTURAL);
            validGroups.Add(FirstCharToUpper(BuiltInParameterGroup.PG_STRUCTURAL_ANALYSIS.ToString()), BuiltInParameterGroup.PG_STRUCTURAL_ANALYSIS);
            validGroups.Add(FirstCharToUpper(BuiltInParameterGroup.PG_TEXT.ToString()), BuiltInParameterGroup.PG_TEXT);
            validGroups.Add(FirstCharToUpper(BuiltInParameterGroup.PG_TITLE.ToString()), BuiltInParameterGroup.PG_TITLE);
            validGroups.Add(FirstCharToUpper(BuiltInParameterGroup.PG_VISIBILITY.ToString()), BuiltInParameterGroup.PG_VISIBILITY);
            
            return validGroups;
        }

        private void ParameterList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void AddParametersToProject(Document doc, Autodesk.Revit.ApplicationServices.Application app)
        {

            CategorySet categoryset = app.Create.NewCategorySet();

            BuiltInParameterGroup parameterGroupUnder = new BuiltInParameterGroup();
            string selectedGroup = GroupParameterUnderComboBox.SelectedItem.ToString();

            foreach (KeyValuePair<string, BuiltInParameterGroup> k in ParameterGroupUnderDict(doc))
            {
                if (k.Key == selectedGroup)
                {
                    parameterGroupUnder = k.Value;
                }
            }

            foreach (string selectedParameter in ParameterList.SelectedItems)
            {
                foreach (var dictPair in GetSharedParamDict())
                {
                    foreach (var innerPair in dictPair.Value)
                    {
                        if (innerPair.Key.Contains(selectedParameter))
                        {
                            foreach (KeyValuePair<string, Category> k in ParameterCategoryList(doc))
                            {

                                foreach (string catString in CategoryCheckList.CheckedItems)
                                {
                                    if (catString == k.Key)
                                    {
                                        categoryset.Insert(k.Value);
                                        
                                        //parameter binding
                                        InstanceBinding newIB = app.Create.NewInstanceBinding(categoryset);
                                        
                                        using (Transaction tx = new Transaction(doc))
                                        {
                                            tx.Start("Add Selected Shared Parameters");

                                            //parameter group to text
                                            doc.ParameterBindings.Insert(dictPair.Key, newIB, parameterGroupUnder);

                                            tx.Commit();
                                        }
                                    }
                                }

                            }
                        }
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
        
        private void GroupSelectComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ParameterList.Items.Clear();
            SelectedGroup = GroupSelectComboBox.SelectedItem;
            string selGroup = SelectedGroup.ToString();

            foreach (var dictPair in GetSharedParamDict())
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
        
        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
