#region Namespaces
using System;
using System.Collections.Generic;
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

                ICollection<ElementId> idCollection = new List<ElementId>();

                FilteredElementCollector viewTemplateCollector = new FilteredElementCollector(doc);
                viewTemplateCollector.OfClass(typeof(View));

                foreach (View v in viewTemplateCollector)
                {
                    if (v.IsTemplate)
                    {
                        idCollection.Add(v.Id);
                    }
                }

                using (Transaction tx = new Transaction(doc))
                {
                    tx.Start("Cleaning up a project for transmit");
                    doc.Delete(idCollection);
                    tx.Commit();
                }




                TaskDialog.Show("Revit", "The current project is now ready for transmit");
                

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
