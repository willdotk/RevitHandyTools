using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RevitHandyTools.SharedParameters
{
    class SharedParametersMain
    {
        public SharedParametersMain(UIControlledApplication uIControlledApplication)
        {
            string thisAssemblyPath = Assembly.GetExecutingAssembly().Location;

            RibbonPanel sharedParametersPanel = RibbonPanelSetting.ribbonPanel(uIControlledApplication, "Shared Parameters");

            PulldownButtonData loadParameterData = new PulldownButtonData("LoadParameters", "Load Parameters");
            RibbonItem loadParameterItem = sharedParametersPanel.AddItem(loadParameterData);
            PulldownButton loadOptionButton = loadParameterItem as PulldownButton;

            // Icon made by Smartline from www.flaticon.com
            loadOptionButton.ToolTip = "To add multiple shared parameters to multiple categories within a project or family.";
            loadOptionButton.LargeImage = RibbonPanelSetting.GetEmbeddedImage("RevitHandyTools.Resources.add_img_32x32.png");
            loadOptionButton.AddPushButton(new PushButtonData("LoadToProject", "Load to project", thisAssemblyPath, "RevitHandyTools.SharedParameters.LoadToProjectCommand"));
            loadOptionButton.AddPushButton(new PushButtonData("LoadToFamily", "Load to family", thisAssemblyPath, "RevitHandyTools.SharedParameters.LoadToFamilyCommand"));

        }
    }
}
