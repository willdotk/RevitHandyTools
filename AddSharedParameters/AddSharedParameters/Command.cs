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

            try
            {
                SharedParameterForm addingForm = new SharedParameterForm(doc, app);
                addingForm.ShowDialog();

                if(addingForm.DialogResult == System.Windows.Forms.DialogResult.OK)
                {
                    addingForm.AddParametersToProject(doc, app);
                }

                return Result.Succeeded;
            }
            catch (Exception e)
            {
                TaskDialog.Show("Error", e.ToString());
                return Result.Failed;
            }
            

        }
    }
}
