using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing.Printing;

namespace InformationInTransit.ProcessLogic
{
    public static partial class PrintHelper
    {
        public static void Main(string[] argv)
        {
            InstalledPrinters();
        }

        public static void InstalledPrinters()
        {
            foreach (string printer in PrinterSettings.InstalledPrinters)
            {
                System.Console.WriteLine(printer);
            }
        }
    }
}
