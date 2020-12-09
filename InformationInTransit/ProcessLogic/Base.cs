using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InformationInTransit.ProcessLogic
{
    public static partial class Base
    {
        const int HEXADECIMAL = 16;
        public static void Main(string[] argv)
        {
            const int HEXADECIMAL = 16;

            // Increment a number so that it is out of range of the Integer type.
            long number = (long)int.MaxValue + 1;
            // Convert the number to its hexadecimal string equivalent.
            string numericString = Convert.ToString(number, HEXADECIMAL);
            // Convert the number back to an integer.
            // We expect that this will throw an OverflowException, but it doesn't.
            try
            {
                int targetNumber = Convert.ToInt32(numericString, HEXADECIMAL);
                Console.WriteLine("0x{0} is equivalent to {1}.",
                      numericString, targetNumber);
            }
            catch (OverflowException)
            {
                Console.WriteLine("0x{0} is out of the range of the Int32 data type.", numericString);
            }
        }  
    }
}
