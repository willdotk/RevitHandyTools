#region Namespaces
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Media.Imaging;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
#endregion

namespace RevitHandyTools
{
    class Main : IExternalApplication
    {
        public Result OnStartup(UIControlledApplication a)
        {

            string sharedParametersPanelName = "Shared Parameters";
            string detailPanelName = "Detail";
            string coordinationPanelName = "Coordination";

            RibbonPanel sharedParametersPanel = ribbonPanel(a, sharedParametersPanelName);
            RibbonPanel detailPanel = ribbonPanel(a, detailPanelName);
            RibbonPanel coordinationPanel = ribbonPanel(a, coordinationPanelName);

            // System.Reflection.Assembly
            string thisAssemblyPath = Assembly.GetExecutingAssembly().Location;

            //SplitButtonData buttondata = new SplitButtonData("Shared Parameter", "Shared Parameter Test");
            //SplitButton button = sharedParametersPanel.AddItem(buttondata) as SplitButton;

            PushButton sharedParameterAddToProjectButton = sharedParametersPanel.AddItem(new PushButtonData("LoadToProject", "Load to project", thisAssemblyPath, "RevitHandyTools.SharedParameters.LoadToProjectCommand")) as PushButton;
            PushButton sharedParameterAddToFamilyButton = sharedParametersPanel.AddItem(new PushButtonData("LoadToFamily", "Load to family", thisAssemblyPath, "RevitHandyTools.SharedParameters.LoadToFamilyCommand")) as PushButton;
            
            PushButton totalLineLengthPushbutton = detailPanel.AddItem(new PushButtonData("TotalLineLength", "Total Length", thisAssemblyPath, "RevitHandyTools.Detail.TotalLineLengthCommand")) as PushButton;

            PushButton transmitModelPushbutton = coordinationPanel.AddItem(new PushButtonData("TransmitModel", "Model Transmit", thisAssemblyPath, "RevitHandyTools.Coordination.TransmitModelCommand")) as PushButton;

            // Reference PresentationCore for BitmapImage
            sharedParameterAddToProjectButton.ToolTip = "This adds multiple shared parameters to multiple categories within a project";
            sharedParameterAddToFamilyButton.ToolTip = "This adds multiple shared parameters to a family";
            //BitmapImage toolTipImage = new BitmapImage(new Uri(System.IO.Path.Combine(System.IO.Path.GetDirectoryName(thisAssemblyPath), "add_img_320x320.png")));
            //sharedParameterAddToProjectButton.ToolTipImage = toolTipImage;
            BitmapImage SPA_toolTipLargeImage = new BitmapImage(new Uri(System.IO.Path.Combine(System.IO.Path.GetDirectoryName(thisAssemblyPath), "add_img_32x32.png")));
            sharedParameterAddToProjectButton.LargeImage = SPA_toolTipLargeImage;
            sharedParameterAddToFamilyButton.LargeImage = SPA_toolTipLargeImage;

            totalLineLengthPushbutton.ToolTip = "This adds up all the selected detail lines length.";
            BitmapImage TLL_toolTipLargeImage = new BitmapImage(new Uri(System.IO.Path.Combine(System.IO.Path.GetDirectoryName(thisAssemblyPath), "measurement_img_32x32.png")));
            totalLineLengthPushbutton.LargeImage = TLL_toolTipLargeImage;

            transmitModelPushbutton.ToolTip = "This clean up the current project for transmit.";
            BitmapImage TRM_toolTipLargeImage = new BitmapImage(new Uri(System.IO.Path.Combine(System.IO.Path.GetDirectoryName(thisAssemblyPath), "packing_img_32x32.png")));
            transmitModelPushbutton.LargeImage = TRM_toolTipLargeImage;

            return Result.Succeeded;
        }

        public RibbonPanel ribbonPanel(UIControlledApplication a, string panelName)
        {
            RibbonPanel ribbonPanel = null;
            string tapName = "RHT";
            List<string> panelList = new List<string>() { "Coordination", "Detail", "Shared Parameters" };
            //string panelAnnotationName = "Shared Parameters";
            try
            {
                a.CreateRibbonTab(tapName);
            }
            catch { }
            try
            {
                foreach(string p_name in panelList)
                {
                    //RibbonPanel panel = a.CreateRibbonPanel(tapName, panelAnnotationName);
                    RibbonPanel panel = a.CreateRibbonPanel(tapName, p_name);
                }
            }
            catch { }

            List<RibbonPanel> panels = a.GetRibbonPanels(tapName);
            foreach (RibbonPanel p in panels)
            {
                if (p.Name == panelName)
                {
                    ribbonPanel = p;
                }
            }
            return ribbonPanel;
        }

        public Result OnShutdown(UIControlledApplication a)
        {
            return Result.Succeeded;
        }
    }
}
