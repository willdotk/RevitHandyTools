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
            PushButton transmitModelPushbutton = coordinationPanel.AddItem(new PushButtonData("TransmitModel", "Model Transmit", thisAssemblyPath, "RevitHandyTools.Coordination.TransmitModelCommand")) as PushButton;
            transmitModelPushbutton.ToolTip = "To clean up the current project for model transmit.";
            transmitModelPushbutton.LargeImage = RibbonPanelSetting.GetEmbeddedImage("RevitHandyTools.Resources.packing_img_32x32.png");
        }
    }
}
