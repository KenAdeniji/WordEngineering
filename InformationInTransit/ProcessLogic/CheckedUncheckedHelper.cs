using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InformationInTransit.ProcessLogic
{
    public static partial class CheckedUncheckedHelper
    {
        static void Main()
        {
            int i = int.MaxValue;
            checked
            {
                Console.WriteLine(i + 1);     // Exception
            }
            unchecked
            {
                Console.WriteLine(i + 1);     // Overflow
            }
        }
    }
}
