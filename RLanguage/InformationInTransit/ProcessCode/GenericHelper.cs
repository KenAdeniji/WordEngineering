#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
#endregion

namespace InformationInTransit.ProcessCode
{
    #region GenericHelper definition
    public static partial class GenericHelper
    {
        #region Methods
        public static void Main(string[] argv)
        {
            DisplayBaseClass<Int32>();
        }

		/*
			2018-11-01	DisplayBaseClass<Int32>();
		*/
		static void DisplayBaseClass<T>()
		{
			// BaseType is a method used in reflection,
			// which will be examined in 
			Console.WriteLine
			(
				"Base class of {0} is: {1}.",
				typeof(T),
				typeof(T).BaseType
			);
		}		
        #endregion
    }
    #endregion
}
