#region Namespaces
using System;
using System.Collections.Generic;
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

            ICollection<ElementId> viewTemplateIdCollection = new List<ElementId>();

            #region
            void ClaningProject()
            {
                try
                {
                    #region
                    // To delete all view templates

                    FilteredElementCollector viewCollector = new FilteredElementCollector(doc);
                    viewCollector.OfClass(typeof(Autodesk.Revit.DB.View));

                    foreach (Autodesk.Revit.DB.View v in viewCollector)
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
                
                    TaskDialog.Show("Revit", "The current project is now ready for transmit");
                }
                catch (Exception e)
                {
                    TaskDialog.Show("Error", e.ToString());

                }
            }
            #endregion

            DialogResult dialogresult = MessageBox.Show("This will remove critical settings of the project." +
                " Please make sure you run this extension in a coordiantion model." + " Do you want to preceed?",
                "Cleaning Project for Model Transmit" , MessageBoxButtons.YesNo);

            if (dialogresult == DialogResult.Yes && uidoc.ActiveView.Name.StartsWith("{3D"))
            {
                ClaningProject();

            }
            else if(dialogresult == DialogResult.Yes && !uidoc.ActiveView.Name.StartsWith("{3D"))
            {
                TaskDialog.Show("Reivt", "You will move to 3D view now. Please run this extension after moving to 3D view.");
                #region
                RevitCommandId threeDViewcommandId = RevitCommandId.LookupPostableCommandId(PostableCommand.Default3DView);

                if (commandData.Application.CanPostCommand(threeDViewcommandId))
                {
                    commandData.Application.PostCommand(threeDViewcommandId);
                }
                #endregion
                //ClaningProject();
            }
            else
            {

            }

            using (Transaction tx = new Transaction(doc))
            {
                tx.Start("Cleaning up a project for transmit");
                doc.Delete(viewTemplateIdCollection);
                tx.Commit();
            }

            return Result.Succeeded;
        }
    }
}
