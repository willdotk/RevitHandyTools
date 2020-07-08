using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

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

            // Load to project
            PushButtonData loadToProjectPushButtonData = new PushButtonData("LoadToProject", "Load to project", thisAssemblyPath, "RevitHandyTools.SharedParameters.LoadToProjectCommand");
            loadToProjectPushButtonData.LargeImage = RibbonPanelSetting.GetEmbeddedImage("RevitHandyTools.Resources.add_img_32x32.png");
            loadToProjectPushButtonData.ToolTip = String.Format(
                "{0}{1}", "Add multiple shared parameters to multiple categories within a project.\n", "This feature is only available in a project for project template");
            loadToProjectPushButtonData.AvailabilityClassName = "RevitHandyTools.AvailableInProjectDocument";

            // Load to family
            PushButtonData loadToFamilyPushButtonData = new PushButtonData("LoadToFamily", "Load to family", thisAssemblyPath, "RevitHandyTools.SharedParameters.LoadToFamilyCommand");
            loadToFamilyPushButtonData.LargeImage = RibbonPanelSetting.GetEmbeddedImage("RevitHandyTools.Resources.add_img_32x32.png");
            loadToFamilyPushButtonData.ToolTip = String.Format(
                "{0}{1}", "Add multiple shared parameters to multiple categories within a family.\n", "This feature is only available in a family");
            loadToFamilyPushButtonData.AvailabilityClassName = "RevitHandyTools.AvailableInFamilyDocument";

            // Add buttons
            loadOptionButton.AddPushButton(loadToProjectPushButtonData);
            loadOptionButton.AddSeparator();
            loadOptionButton.AddPushButton(loadToFamilyPushButtonData);

        }
    }
}
