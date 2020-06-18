using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using RevitHandyTools.SharedParameters;

namespace RevitHandyTools.Coordination
{
    [Transaction(TransactionMode.Manual)]
    class TodoCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Autodesk.Revit.ApplicationServices.Application app = uiapp.Application;
            Document doc = uidoc.Document;

            // To add shared parameter
            //Dictionary<ExternalDefinition, Dictionary<string, string>> sharedParamDict = new SharedParametersLibrary(doc, app).GetSharedParamDict();
            //CategorySet categoryset = app.Create.NewCategorySet();
            //Category category = Category.GetCategory(doc, BuiltInCategory.OST_Walls);
            //categoryset.Insert(category);

            Selection selWall = uiapp.ActiveUIDocument.Selection;


            FilteredElementCollector wallCollector = new FilteredElementCollector(doc);
            wallCollector.OfClass(typeof(WallType));

            foreach (var el in wallCollector)
            {

                //TaskDialog.Show("Test", el.Name.ToString());

                if (el.Name == "Wall_190BW")
                {
                    
                    //string parameterValue = el.GetParameters("Location").ToString();
                    
                    //TaskDialog.Show("Parameter value", parameterValue);

                    TaskDialog debugDialog = new TaskDialog("Debug Dialog");
                    debugDialog.MainContent = el.GetParameters("Location").GetType().ToString();
                    debugDialog.Show();
                }

                //IList<Parameter> parameterText = el.GetParameters("RHT_Todos_Text");
                //foreach (var i in el.Parameters)
                //{
                //    TaskDialog.Show("Done", i.);
                //}


                //Parameter parameter = el.LookupParameter("RHT_Todos");
                //Parameter parameterText = el.LookupParameter("RHT_Todos_Text");
                //TaskDialog.Show("Parameter", parameterText.Definition.ToString());
                //TaskDialog.Show("Parameter", parameterText.AsValueString());
                //using (Transaction tx = new Transaction(doc))
                //{
                //    tx.Start("Todo");
                //    parameterText.SetValueString("Test string from RHT");
                //    tx.Commit();
                //}
                //TaskDialog.Show("Parameter", parameterText.AsValueString());
            }

            return Result.Succeeded;            
        }

    }
}
