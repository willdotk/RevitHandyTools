#region Namespaces
using System;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
#endregion

namespace RevitHandyTools.Detail
{
    [Transaction(TransactionMode.Manual)]
    class TotalLineLengthCommand : IExternalCommand
    {
        const double InchToMm = 25.4;
        const double FootToMm = 12 * InchToMm;

        public static double MmToFeet(double length)
        {
            return length * FootToMm;
        }

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
                Selection sel = uidoc.Selection;

                int count = 0;
                double totallength = 0;

                foreach (ElementId elId in sel.GetElementIds())
                {
                    // get the selected element by id
                    Element el = doc.GetElement(elId);
                    // get line length by BuiltInParameter
                    Parameter param = el.get_Parameter(BuiltInParameter.CURVE_ELEM_LENGTH);
                    // convert length unit to millimeters
                    double linelength = MmToFeet(param.AsDouble());
                    // add up total length
                    totallength = totallength + linelength;
                    // count the number of lines calculating
                    count++;
                }

                string lengthtotwodecimal = String.Format("{0:#.##}", totallength);
                string outcome = String.Format("The number of Lines: {0} \nTotal length: {1}mm ", count, lengthtotwodecimal);

                TaskDialog.Show("Total length", outcome);

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
