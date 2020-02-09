using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using Autodesk.Revit.DB;

namespace RevitHandyTools.SharedParameters
{
    class SharedParametersLibrary
    {
        public DefinitionFile definitionfile = null;
        public Autodesk.Revit.ApplicationServices.Application app = null;
        public Document doc = null;
        
        public SharedParametersLibrary(Document dOcument, Autodesk.Revit.ApplicationServices.Application aPplication)
        {
            app = aPplication;
            doc = dOcument;
            definitionfile = app.OpenSharedParameterFile();
        }

        public Dictionary<ExternalDefinition, Dictionary<string, string>> GetSharedParamDict()
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
                    tempDict.Add(deParamName, deGroupName);

                    if (!paramDict.ContainsKey(exDefinitionParamName))
                    {
                        paramDict.Add(exDefinitionParamName, tempDict);
                    }
                }
            }
            return paramDict;
        }

        public List<string> GetGroupListFromDict()
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

        public SortedList<string, Category> ParameterCategoryList(Document doc)
        {
            Categories categories = doc.Settings.Categories;

            SortedList<string, Category> categoryList = new SortedList<string, Category>();

            foreach (Category cat in categories)
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

        public Dictionary<string, BuiltInParameterGroup> ParameterGroupUnderDict(Document doc)
        {
            Dictionary<string, BuiltInParameterGroup> validGroups = new Dictionary<string, BuiltInParameterGroup>();
            validGroups.Add(FirstCharToUpper(BuiltInParameterGroup.PG_ANALYSIS_RESULTS.ToString()), BuiltInParameterGroup.PG_ANALYSIS_RESULTS);
            validGroups.Add(FirstCharToUpper(BuiltInParameterGroup.PG_ANALYTICAL_ALIGNMENT.ToString()), BuiltInParameterGroup.PG_ANALYTICAL_ALIGNMENT);
            validGroups.Add(FirstCharToUpper(BuiltInParameterGroup.PG_ANALYTICAL_MODEL.ToString()), BuiltInParameterGroup.PG_ANALYTICAL_MODEL);
            validGroups.Add(FirstCharToUpper(BuiltInParameterGroup.PG_CONSTRAINTS.ToString()), BuiltInParameterGroup.PG_CONSTRAINTS);
            validGroups.Add(FirstCharToUpper(BuiltInParameterGroup.PG_CONSTRUCTION.ToString()), BuiltInParameterGroup.PG_CONSTRUCTION);
            validGroups.Add(FirstCharToUpper(BuiltInParameterGroup.PG_DATA.ToString()), BuiltInParameterGroup.PG_DATA);
            validGroups.Add("Dimensions", BuiltInParameterGroup.PG_GEOMETRY); // Dimensions
            validGroups.Add(FirstCharToUpper(BuiltInParameterGroup.PG_DIVISION_GEOMETRY.ToString()), BuiltInParameterGroup.PG_DIVISION_GEOMETRY);
            validGroups.Add("Electrical", BuiltInParameterGroup.PG_AELECTRICAL);
            validGroups.Add(FirstCharToUpper(BuiltInParameterGroup.PG_ELECTRICAL_CIRCUITING.ToString()), BuiltInParameterGroup.PG_ELECTRICAL_CIRCUITING);
            validGroups.Add(FirstCharToUpper(BuiltInParameterGroup.PG_ELECTRICAL_LIGHTING.ToString()), BuiltInParameterGroup.PG_ELECTRICAL_LIGHTING);
            validGroups.Add(FirstCharToUpper(BuiltInParameterGroup.PG_ELECTRICAL_LOADS.ToString()), BuiltInParameterGroup.PG_ELECTRICAL_LOADS);
            validGroups.Add("Electrical Engineering", BuiltInParameterGroup.PG_ELECTRICAL);
            validGroups.Add(FirstCharToUpper(BuiltInParameterGroup.PG_ENERGY_ANALYSIS.ToString()), BuiltInParameterGroup.PG_ENERGY_ANALYSIS);
            validGroups.Add(FirstCharToUpper(BuiltInParameterGroup.PG_FIRE_PROTECTION.ToString()), BuiltInParameterGroup.PG_FIRE_PROTECTION);
            validGroups.Add(FirstCharToUpper(BuiltInParameterGroup.PG_FORCES.ToString()), BuiltInParameterGroup.PG_FORCES);
            validGroups.Add(FirstCharToUpper(BuiltInParameterGroup.PG_GENERAL.ToString()), BuiltInParameterGroup.PG_GENERAL);
            validGroups.Add(FirstCharToUpper(BuiltInParameterGroup.PG_GRAPHICS.ToString()), BuiltInParameterGroup.PG_GRAPHICS);
            validGroups.Add("Green Building Properties", BuiltInParameterGroup.PG_GREEN_BUILDING);
            validGroups.Add(FirstCharToUpper(BuiltInParameterGroup.PG_IDENTITY_DATA.ToString()), BuiltInParameterGroup.PG_IDENTITY_DATA);
            validGroups.Add("IFC Parameters", BuiltInParameterGroup.PG_IFC);
            validGroups.Add("Layers", BuiltInParameterGroup.PG_REBAR_SYSTEM_LAYERS);
            validGroups.Add("Materials and Finishes", BuiltInParameterGroup.PG_MATERIALS);
            validGroups.Add(FirstCharToUpper(BuiltInParameterGroup.PG_MECHANICAL.ToString()), BuiltInParameterGroup.PG_MECHANICAL);
            validGroups.Add("Mechanical - Flow", BuiltInParameterGroup.PG_MECHANICAL_AIRFLOW);
            validGroups.Add(FirstCharToUpper(BuiltInParameterGroup.PG_MECHANICAL_LOADS.ToString()), BuiltInParameterGroup.PG_MECHANICAL_LOADS);
            validGroups.Add("Model Properties", BuiltInParameterGroup.PG_ADSK_MODEL_PROPERTIES);
            validGroups.Add(FirstCharToUpper(BuiltInParameterGroup.PG_MOMENTS.ToString()), BuiltInParameterGroup.PG_MOMENTS);
            validGroups.Add("Other", BuiltInParameterGroup.INVALID); // other
            validGroups.Add(FirstCharToUpper(BuiltInParameterGroup.PG_OVERALL_LEGEND.ToString()), BuiltInParameterGroup.PG_OVERALL_LEGEND);
            validGroups.Add(FirstCharToUpper(BuiltInParameterGroup.PG_PHASING.ToString()), BuiltInParameterGroup.PG_PHASING);
            validGroups.Add("Photometrics", BuiltInParameterGroup.PG_LIGHT_PHOTOMETRICS);
            validGroups.Add(FirstCharToUpper(BuiltInParameterGroup.PG_PLUMBING.ToString()), BuiltInParameterGroup.PG_PLUMBING);
            validGroups.Add(FirstCharToUpper(BuiltInParameterGroup.PG_PRIMARY_END.ToString()), BuiltInParameterGroup.PG_PRIMARY_END);
            validGroups.Add("Rebar Set", BuiltInParameterGroup.PG_REBAR_ARRAY);
            validGroups.Add("Releases / Member Forces", BuiltInParameterGroup.PG_RELEASES_MEMBER_FORCES);
            validGroups.Add(FirstCharToUpper(BuiltInParameterGroup.PG_SECONDARY_END.ToString()), BuiltInParameterGroup.PG_SECONDARY_END);
            validGroups.Add("Segments and Fittings", BuiltInParameterGroup.PG_SEGMENTS_FITTINGS);
            validGroups.Add(FirstCharToUpper(BuiltInParameterGroup.PG_SLAB_SHAPE_EDIT.ToString()), BuiltInParameterGroup.PG_SLAB_SHAPE_EDIT);
            validGroups.Add(FirstCharToUpper(BuiltInParameterGroup.PG_STRUCTURAL.ToString()), BuiltInParameterGroup.PG_STRUCTURAL);
            validGroups.Add(FirstCharToUpper(BuiltInParameterGroup.PG_STRUCTURAL_ANALYSIS.ToString()), BuiltInParameterGroup.PG_STRUCTURAL_ANALYSIS);
            validGroups.Add(FirstCharToUpper(BuiltInParameterGroup.PG_TEXT.ToString()), BuiltInParameterGroup.PG_TEXT);
            validGroups.Add("Title Text", BuiltInParameterGroup.PG_TITLE);
            validGroups.Add(FirstCharToUpper(BuiltInParameterGroup.PG_VISIBILITY.ToString()), BuiltInParameterGroup.PG_VISIBILITY);

            return validGroups;
        }
    }
}
