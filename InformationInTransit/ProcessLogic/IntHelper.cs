using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InformationInTransit.ProcessLogic
{
    public static partial class IntHelper
    {
        public static void Main(string[] argv)
        {
        }

        public static Dictionary<int, string> Fill(int first, int last)
        {
            Dictionary<int, string> fill = new Dictionary<int, string>();
            for (int index = first; index <= last; ++index)
            {
                fill.Add(index, index.ToString());
            }
            return fill;
        }

        public static bool IsPrime(this int number)
        {
            for (int i = (2); i < number; i++)
            {
                if (number < 2) return false;

                if ((number % i) == 0)
                {
                    return false;
                }
            }
            return true;
        }

        public static bool IsPrimeAlternative(this int number)
        {
            if ((number % 2) == 0)
            {
                return number == 2;
            }
            int sqrt = (int)Math.Sqrt(number);
            for (int t = 3; t <= sqrt; t = t + 2)
            {
                if (number % t == 0)
                {
                    return false;
                }
            }
            return true;
        }

        /// <example>
        /// var numbers = 1.To(10);
        /// </example>
        public static IEnumerable<int> To(this int first, int last)
        {
            return Enumerable.Range(first, last - first + 1);
        }
    }
}
