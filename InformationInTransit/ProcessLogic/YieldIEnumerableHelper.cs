using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InformationInTransit.ProcessLogic
{
    static partial class YieldIEnumerableHelper
    {
        public static void Main() {
            foreach (int x in Range(-10,10)) {
                Console.WriteLine(x);
            }
        }

        public static IEnumerable<int> Range(int from, int to)
        {
            for (int i = from; i < to; i++)
            {
                yield return i;
            }
            yield break;
        }
    }
}
