using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace InformationInTransit.ProcessLogic
{
    class UsingHelper
    {
        static void Main()
        {
            using (TextWriter w = File.CreateText("test.txt"))
            {
                w.WriteLine("Line one");
                w.WriteLine("Line two");
                w.WriteLine("Line three");
            }
        }
    }
}
