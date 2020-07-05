using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitHandyTools
{
    public class AvailableInThreeDView : IExternalCommandAvailability
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
    public class AvailableInFamilyDocument : IExternalCommandAvailability
    {
        public bool IsCommandAvailable(UIApplication applicationData, CategorySet selectedCategories)
        {
            UIApplication uiapp = applicationData;
            UIDocument uidoc = uiapp.ActiveUIDocument;

            if (uidoc.Document.IsFamilyDocument)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    public class AvailableInProjectDocument : IExternalCommandAvailability
    {
        public bool IsCommandAvailable(UIApplication applicationData, CategorySet selectedCategories)
        {
            UIApplication uiapp = applicationData;
            UIDocument uidoc = uiapp.ActiveUIDocument;

            if (uidoc.Document.IsFamilyDocument)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
