#region Namespaces
using System;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
#endregion

namespace RevitHandyTools.SharedParameters
{
    [Transaction(TransactionMode.Manual)]
    class LoadToFamilyCommand : IExternalCommand
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
                LoadToFamilyForm addingForm = new LoadToFamilyForm(doc, app);
                addingForm.ShowDialog();

                if (addingForm.DialogResult == System.Windows.Forms.DialogResult.OK)
                {
                    addingForm.AddParametersToFamily(doc, app);
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
