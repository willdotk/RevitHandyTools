#region Namespaces
using System;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
#endregion

namespace RevitHandyTools.Coordination
{
    [Transaction(TransactionMode.Manual)]
    class TransmitModelCommand : IExternalCommand
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

                View currentView = uidoc.ActiveView;

                var viewtemplate = PostableCommand.ManageViewTemplates;
                var viewTempId = currentView.ViewTemplateId;

                FilteredElementCollector viewTemplateCollector = new FilteredElementCollector(doc);
                viewTemplateCollector.OfClass(typeof(View));
                
                foreach(View v in viewTemplateCollector)
                {
                    if (v.IsTemplate)
                    {
                        TaskDialog.Show("Test", v.Name);
                    }
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
