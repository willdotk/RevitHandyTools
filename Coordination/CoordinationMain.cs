using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RevitHandyTools.Coordination
{
    class CoordinationMain
    {
        public CoordinationMain(UIControlledApplication uIControlledApplication)
        {
            string thisAssemblyPath = Assembly.GetExecutingAssembly().Location;

            RibbonPanel coordinationPanel = RibbonPanelSetting.ribbonPanel(uIControlledApplication, "Coordination");

            // Icon made by Freepik from www.flaticon.com
            PushButtonData transmitModelPushbuttonData = new PushButtonData("TransmitModel", "Model Transmit", thisAssemblyPath, "RevitHandyTools.Coordination.TransmitModelCommand");
            transmitModelPushbuttonData.AvailabilityClassName = "RevitHandyTools.AvailableInThreeDView";

            PushButton transmitModelPushbutton = coordinationPanel.AddItem(transmitModelPushbuttonData) as PushButton;
            transmitModelPushbutton.ToolTip = String.Format(
                "{0}{1}","To clean up the current project for model transmit.\n","This feature is only available from 3D view");
            transmitModelPushbutton.LargeImage = RibbonPanelSetting.GetEmbeddedImage("RevitHandyTools.Resources.packing_img_32x32.png");
        }
    }
}
