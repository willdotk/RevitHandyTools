using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;

namespace RevitHandyTools.Detail
{
    class DetailMain
    {
        public DetailMain(UIControlledApplication uIControlledApplication)
        {
            string thisAssemblyPath = Assembly.GetExecutingAssembly().Location;

            RibbonPanel detailPanel = RibbonPanelSetting.ribbonPanel(uIControlledApplication, "Detail");

            // TotalLineLength
            // Icon made by Good Ware from www.flaticon.com
            PushButton totalLineLengthPushbutton = detailPanel.AddItem(new PushButtonData("TotalLineLength", "Total Length", thisAssemblyPath, "RevitHandyTools.Detail.TotalLineLengthCommand")) as PushButton;
            totalLineLengthPushbutton.ToolTip = "To add up total length of selected detail lines.";
            totalLineLengthPushbutton.LargeImage = RibbonPanelSetting.GetEmbeddedImage("RevitHandyTools.Resources.measurement_img_32x32.png");

        }

    }
}
