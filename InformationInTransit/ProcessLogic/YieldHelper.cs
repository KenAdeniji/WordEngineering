﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Collections;

namespace InformationInTransit.ProcessLogic
{
    public static partial class YieldHelper
    {
        public static IEnumerable Power(int number, int exponent)
        {
            int counter = 0;
            int result = 1;
            while (counter++ < exponent)
            {
                result = result * number;
                yield return result;
            }
        }

        static void Main()
        {
            // Display powers of 2 up to the exponent 8:
            foreach (int i in Power(2, 8))
            {
                Console.Write("{0} ", i);
            }
        }
    }
}
