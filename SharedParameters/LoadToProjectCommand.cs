﻿#region Namespaces
using System;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System.Windows.Forms;
using RevitHandyTools;
#endregion

namespace RevitHandyTools.SharedParameters
{
    [Transaction(TransactionMode.Manual)]
    class LoadToProjectCommand : IExternalCommand
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

            CustomForms.WarningForm loadWarningForm = new CustomForms.WarningForm();
            loadWarningForm.WarningLabel = "This will overwrite any parameters with the same names.";
            loadWarningForm.ShowDialog();

            if (loadWarningForm.DialogResult == DialogResult.Yes)
            {
                try
                {
                    LoadToProjectForm addingForm = new LoadToProjectForm(doc, app);
                    addingForm.ShowDialog();

                    if (addingForm.DialogResult == System.Windows.Forms.DialogResult.OK)
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

            else
            {
                return Result.Succeeded;
            }


        }
    }
}
