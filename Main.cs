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
            RibbonPanel panel = ribbonPanel(a);

            // System.Reflection.Assembly
            string thisAssemblyPath = Assembly.GetExecutingAssembly().Location;

            //SplitButtonData buttondata = new SplitButtonData("Shared Parameter", "Shared Parameter Test");
            //SplitButton button = panel.AddItem(buttondata) as SplitButton;

            PushButton pushbutton = panel.AddItem(new PushButtonData("AddSharedParameterBtnData", "Load to project", thisAssemblyPath, "RevitHandyTools.SharedParameters.LoadToProjectCommand")) as PushButton;

            var tooltipimage = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(thisAssemblyPath), "add_img_320x320.png");
            var iconimage = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(thisAssemblyPath), "add_img_32x32.png");

            // Reference PresentationCore for BitmapImage
            pushbutton.ToolTip = "This adds multiple shared parameters to multiple categories within a project";
            BitmapImage toolTipImage = new BitmapImage(new Uri(tooltipimage));
            pushbutton.ToolTipImage = toolTipImage;
            pushbutton.LargeImage = new BitmapImage(new Uri(tooltipimage));

            return Result.Succeeded;
        }

        public RibbonPanel ribbonPanel(UIControlledApplication a)
        {
            RibbonPanel ribbonPanel = null;
            string tapName = "Archipy";
            string panelAnnotationName = "Shared Parameters";
            try
            {
                a.CreateRibbonTab(tapName);
            }
            catch { }
            try
            {
                RibbonPanel panel = a.CreateRibbonPanel(tapName, panelAnnotationName);
            }
            catch { }

            List<RibbonPanel> panels = a.GetRibbonPanels(tapName);
            foreach (RibbonPanel p in panels)
            {
                if (p.Name == panelAnnotationName)
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
