#region Namespaces
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
#endregion

namespace AddSharedParameters
{
    [Transaction(TransactionMode.Manual)]

    public class Command : IExternalCommand
    {
        public static void CreateProjectParameter()
        {

        }

        public Result Execute(
          ExternalCommandData commandData,
          ref string message,
          ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Application app = uiapp.Application;
            Document doc = uidoc.Document;

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


            FilteredElementCollector colWalls = new FilteredElementCollector(doc);
            colWalls.OfCategory(BuiltInCategory.OST_Walls);

            Autodesk.Revit.DB.Binding binding = app.Create.NewTypeBinding();

            SharedParameterForm addingForm = new SharedParameterForm(paramGroup, paramNames);
            addingForm.Show();
            

            return Result.Succeeded;
        }
    }
}
