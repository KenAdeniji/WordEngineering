using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InformationInTransit.ProcessLogic
{
	///<summary>
	///		2015-06-28	Created.	http://intellitect.com/wp-content/uploads/2013/02/Sample-Chapter-Chapter-3-Operators-and-Control-Flow-.pdf
	///</summary>
    public static partial class OperatorHelper
    {
        public static void Main(string[] argv)
        {
			UsingThePlusOperatorWithTheCharDataType();
			DeterminingTheCharacterDifferenceBetweenTwoChar();
        }

		public static void UsingThePlusOperatorWithTheCharDataType()
        {
            int n = '3' + '4';
			char c = (char)n;
			System.Console.WriteLine(c);
        }
		
		public static void DeterminingTheCharacterDifferenceBetweenTwoChar()
		{
			int distance = 'f' - 'c';
			System.Console.WriteLine(distance);
		}
    }
}
