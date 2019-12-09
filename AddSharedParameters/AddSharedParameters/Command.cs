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
        public Result Execute(
          ExternalCommandData commandData,
          ref string message,
          ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Application app = uiapp.Application;
            Document doc = uidoc.Document;

            System.Text.StringBuilder fileinfo = new System.Text.StringBuilder();

            DefinitionFile definitionfile = app.OpenSharedParameterFile();

            fileinfo.AppendLine("File Name: " + definitionfile.Filename);

            foreach (DefinitionGroup definitionGroup in definitionfile.Groups)
            {
                fileinfo.AppendLine("Group Name: " + definitionGroup.Name);

                foreach (Definition definition in definitionGroup.Definitions)
                {
                    fileinfo.AppendLine("Parameter Name: " + definition.Name);
                }
            }

            TaskDialog.Show("Shared Parameter", fileinfo.ToString());

            return Result.Succeeded;
        }
    }
}
