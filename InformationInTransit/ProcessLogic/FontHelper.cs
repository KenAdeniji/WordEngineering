using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;
using System.Drawing.Text;

namespace InformationInTransit.ProcessLogic
{
    public static partial class FontHelper
    {
        public static void Main(string[] argv)
        {
            FontFamilies();
        }

        public static InstalledFontCollection FontFamilies()
        {
            InstalledFontCollection fonts = new InstalledFontCollection();
            foreach (FontFamily fontFamily in fonts.Families)
            {
                System.Console.WriteLine(fontFamily);
            }
            return fonts;
        }
    }
}
