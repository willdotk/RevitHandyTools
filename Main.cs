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

            PulldownButtonData loadParameterData = new PulldownButtonData("LoadParameters", "Load Parameters");
            RibbonItem loadParameterItem = sharedParametersPanel.AddItem(loadParameterData);
            PulldownButton loadOptionButton = loadParameterItem as PulldownButton;

            // Icon made by Smartline from www.flaticon.com
            loadOptionButton.ToolTip = "To add multiple shared parameters to multiple categories within a project or family.";
            loadOptionButton.LargeImage = GetEmbeddedImage("RevitHandyTools.Resources.add_img_32x32.png");
            loadOptionButton.AddPushButton(new PushButtonData("LoadToProject", "Load to project", thisAssemblyPath, "RevitHandyTools.SharedParameters.LoadToProjectCommand"));
            loadOptionButton.AddPushButton(new PushButtonData("LoadToFamily", "Load to family", thisAssemblyPath, "RevitHandyTools.SharedParameters.LoadToFamilyCommand"));

            // Icon made by Good Ware from www.flaticon.com
            PushButton totalLineLengthPushbutton = detailPanel.AddItem(new PushButtonData("TotalLineLength", "Total Length", thisAssemblyPath, "RevitHandyTools.Detail.TotalLineLengthCommand")) as PushButton;
            totalLineLengthPushbutton.ToolTip = "To add up total length of selected detail lines.";
            totalLineLengthPushbutton.LargeImage = GetEmbeddedImage("RevitHandyTools.Resources.measurement_img_32x32.png");

            // Icon made by Freepik from www.flaticon.com
            PushButton transmitModelPushbutton = coordinationPanel.AddItem(new PushButtonData("TransmitModel", "Model Transmit", thisAssemblyPath, "RevitHandyTools.Coordination.TransmitModelCommand")) as PushButton;
            transmitModelPushbutton.ToolTip = "To clean up the current project for model transmit.";
            transmitModelPushbutton.LargeImage = GetEmbeddedImage("RevitHandyTools.Resources.packing_img_32x32.png");

            return Result.Succeeded;
        }

        public RibbonPanel ribbonPanel(UIControlledApplication a, string panelName)
        {
            RibbonPanel ribbonPanel = null;
            string tapName = "RevitHandyTools";
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
 
        static BitmapSource GetEmbeddedImage(string name)
        {
            try
            {
                Assembly a = Assembly.GetExecutingAssembly();
                Stream s = a.GetManifestResourceStream(name);
                return BitmapFrame.Create(s);
            }
            catch
            {
                return null;
            }
        }

        public Result OnShutdown(UIControlledApplication a)
        {
            return Result.Succeeded;
        }
    }
}
