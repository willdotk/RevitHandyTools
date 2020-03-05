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
                ICollection<ElementId> viewTemplateIdCollection = new List<ElementId>();

                #region
                // Go to 3D view and delete all views except 3D view
                /*
                RevitCommandId threeDViewcommandId = RevitCommandId.LookupPostableCommandId(PostableCommand.Default3DView);
                
                if (commandData.Application.CanPostCommand(threeDViewcommandId))
                {
                    commandData.Application.PostCommand(threeDViewcommandId);
                }
                */
                #endregion

                #region
                // To delete all view templates

                FilteredElementCollector viewCollector = new FilteredElementCollector(doc);
                viewCollector.OfClass(typeof(View));

                foreach (View v in viewCollector)
                {
                    if (v.ViewType.ToString() != "ProjectBrowser" && v.ViewType.ToString() != "SystemBrowser" && v.Name != "{3D}")
                    {
                        viewTemplateIdCollection.Add(v.Id);
                    }
                }
                #endregion

                #region
                // To delete all project parameters
                BindingMap bindingMap = doc.ParameterBindings;

                FilteredElementCollector parameterElementCollector = new FilteredElementCollector(doc);
                parameterElementCollector.OfClass(typeof(ParameterElement));

                foreach (ParameterElement parameterElement in parameterElementCollector)
                {
                    if (bindingMap.Contains(parameterElement.GetDefinition()))
                    {
                        viewTemplateIdCollection.Add(parameterElement.Id);
                    }
                }
                #endregion

                #region
                // To purge a project
 
                string s_commandToDisable = "ID_PURGE_UNUSED";
                RevitCommandId s_commandId = RevitCommandId.LookupCommandId(s_commandToDisable);


                uiapp.PostCommand(s_commandId);

                #endregion

                
                using (Transaction tx = new Transaction(doc))
                {
                    tx.Start("Cleaning up a project for transmit");
                    doc.Delete(viewTemplateIdCollection);
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
