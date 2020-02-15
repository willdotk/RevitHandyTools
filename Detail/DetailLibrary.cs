using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using Autodesk.Revit.DB;

namespace RevitHandyTools.Detail
{
    class DetailLibrary
    {
        const double InchToMm = 25.4;
        const double FootToMm = 304.8;

        public Autodesk.Revit.ApplicationServices.Application app = null;
        public Document doc = null;
        
        public DetailLibrary(Document document, Autodesk.Revit.ApplicationServices.Application application)
        {
            app = application;
            doc = document;
        }

        public static double ConvertFeetToMm(double length)
        {
            return length * FootToMm;
        }

    }
}
