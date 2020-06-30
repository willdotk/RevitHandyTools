#region Namespaces
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Windows.Forms;
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
            Autodesk.Revit.ApplicationServices.Application app = uiapp.Application;
            Document doc = uidoc.Document;

            ICollection<ElementId> viewIdCollection = new List<ElementId>();

            #region
            void SetCollectionToRemove()
            {
                try
                {
                    #region
                    // To add all views to collection
                    FilteredElementCollector viewCollector = new FilteredElementCollector(doc);
                    viewCollector.OfClass(typeof(Autodesk.Revit.DB.View));

                    foreach (Autodesk.Revit.DB.View v in viewCollector)
                    {
                        if (v.ViewType.ToString() != "ProjectBrowser" && v.ViewType.ToString() != "SystemBrowser" && v.Name != "{3D}")
                        {
                            viewIdCollection.Add(v.Id);
                        }
                    }
                    #endregion

                    #region
                    // To add all project parameters to collection
                    BindingMap bindingMap = doc.ParameterBindings;

                    FilteredElementCollector parameterElementCollector = new FilteredElementCollector(doc);
                    parameterElementCollector.OfClass(typeof(ParameterElement));

                    foreach (ParameterElement parameterElement in parameterElementCollector)
                    {
                        if (bindingMap.Contains(parameterElement.GetDefinition()))
                        {
                            viewIdCollection.Add(parameterElement.Id);
                        }
                    }
                    #endregion

                    PurgeUnused();
                    TaskDialog.Show("Revit Handy Tools - Model Transmit", "The project will be prepared for model transmit");
                }
                catch (Exception e)
                {
                    TaskDialog.Show("Error", e.ToString());

                }
            }
            #endregion

            void PurgeUnused()
            {
                // To purge a project
                RevitCommandId commandId = RevitCommandId.LookupCommandId("ID_PURGE_UNUSED");
                uiapp.PostCommand(commandId);
            }

            CustomForms.WarningForm warningTransmit = new CustomForms.WarningForm();
            warningTransmit.WarningLabel = String.Format("{0}{1}", "This will remove critical settings of the project.\n",
                "Please make sure you run this extension in a coordiantion model.");
            warningTransmit.ShowDialog();

            if (warningTransmit.DialogResult == DialogResult.Yes && uidoc.ActiveView.Name.StartsWith("{3D"))
            {
                SetCollectionToRemove();
            }
            else if (warningTransmit.DialogResult == DialogResult.Yes && !uidoc.ActiveView.Name.StartsWith("{3D"))
            {
                TaskDialog.Show("Revit Handy Tools - Model Transmit", String.Format("{0}{1}", "Please run this extension in 3D view.\n", "You will be moved to 3D view."));
                #region
                RevitCommandId threeDViewcommandId = RevitCommandId.LookupPostableCommandId(PostableCommand.Default3DView);

                if (commandData.Application.CanPostCommand(threeDViewcommandId))
                {
                    commandData.Application.PostCommand(threeDViewcommandId);
                }
                #endregion
                //SetCollectionToRemove();
            }
            else
            {
                return Result.Succeeded;
            }

            using (Transaction tx = new Transaction(doc))
            {
                tx.Start("Cleaning up a project for model transmit");
                
                doc.Delete(viewIdCollection);

                tx.Commit();
            }

            return Result.Succeeded;
        }
    }
}
