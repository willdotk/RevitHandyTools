#region Namespaces
using System;
using System.IO;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Media.Imaging;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using RevitHandyTools.Detail;
using RevitHandyTools.Coordination;
using RevitHandyTools.SharedParameters;
#endregion

namespace RevitHandyTools
{
    class Main : IExternalApplication
    {
        public Result OnStartup(UIControlledApplication uIControlledApplication)
        {

            CoordinationMain coordinationMain  = new CoordinationMain(uIControlledApplication);
            DetailMain detailMain = new DetailMain(uIControlledApplication);
            SharedParametersMain sharedParametersMain = new SharedParametersMain(uIControlledApplication);

            return Result.Succeeded;
        }

        public Result OnShutdown(UIControlledApplication a)
        {
            return Result.Succeeded;
        }
    }
}
