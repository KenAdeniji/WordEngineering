using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InformationInTransit.ProcessLogic
{
    public static partial class MathHelper
    {
        public static void Main(string[] argv)
        {
            System.Console.WriteLine(Factorial(6));
        }

        public static int Factorial(int i)
        {
            return ((i <= 1) ? 1 : (i * Factorial(i - 1)));
        }
    }
}
