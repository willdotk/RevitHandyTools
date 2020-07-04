using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitHandyTools
{
    public class AvailabilityThreeDimension : IExternalCommandAvailability
    {
        public bool IsCommandAvailable(UIApplication applicationData, CategorySet selectedCategories)
        {
            UIApplication uiapp = applicationData;
            UIDocument uidoc = uiapp.ActiveUIDocument;

            if (uidoc.ActiveView.ViewType.ToString() == "ThreeD")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
