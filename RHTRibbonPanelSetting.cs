using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace RevitHandyTools
{
    class RHTRibbonPanelSetting
    {        
        public static RibbonPanel ribbonPanel(UIControlledApplication uIControlledApplication, string panelName)
        {
            RibbonPanel ribbonPanel = null;
            string tapName = "RevitHandyTools";
            List<string> panelList = new List<string>() { "Coordination", "Detail", "Shared Parameters" };
            //string panelAnnotationName = "Shared Parameters";
            try
            {
                uIControlledApplication.CreateRibbonTab(tapName);
            }
            catch { }
            try
            {
                foreach (string p_name in panelList)
                {
                    //RibbonPanel panel = a.CreateRibbonPanel(tapName, panelAnnotationName);
                    RibbonPanel panel = uIControlledApplication.CreateRibbonPanel(tapName, p_name);
                }
            }
            catch { }

            List<RibbonPanel> panels = uIControlledApplication.GetRibbonPanels(tapName);
            foreach (RibbonPanel p in panels)
            {
                if (p.Name == panelName)
                {
                    ribbonPanel = p;
                }
            }
            return ribbonPanel;
        }

        public static BitmapSource GetEmbeddedImage(string name)
        {
            try
            {
                Assembly assembly = Assembly.GetExecutingAssembly();
                Stream stream = assembly.GetManifestResourceStream(name);
                return BitmapFrame.Create(stream);
            }
            catch
            {
                return null;
            }
        }
    }
}
