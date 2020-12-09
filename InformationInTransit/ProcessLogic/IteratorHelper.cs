using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InformationInTransit.ProcessLogic
{
    public static partial class IteratorHelper
    {
        public static void Main(string[] argv)
        {
            int low = System.Convert.ToInt32(argv[0]);
            int high = System.Convert.ToInt32(argv[1]);
            foreach(int odd in AllTheOdds(low, high))
            {
                System.Console.WriteLine(odd);
            }
        }

        public static IEnumerable<int> AllTheOdds(int low, int high)
        {
            for (var n = low; n <= high; n++)
            {
                if ( n % 2 == 1)
                {
                    yield return n;
                }
            }
        }
    }
}
