using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InformationInTransit.ProcessLogic
{
    public static partial class EulerProjectHelper
    {
        public static void Main(string[] argv)
        {
            System.Console.WriteLine( Problem1() );
        }

        /// <summary>
        /// Add all the natural numbers below one thousand that are multiples of 3 or 5.
        /// </summary>
        public static int Problem1()
        {
            int sum = Enumerable.Range(1, 999)
                        .Where(x => x % 3 == 0 || x % 5 == 0)
                        .Sum();
            return sum;
        }
    }
}
