#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Diagnostics;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Threading;
#endregion

/*
	2020-02-23	Created.	https://docs.microsoft.com/en-us/dotnet/csharp/how-to/compare-strings
*/
namespace InformationInTransit.ProcessCode
{
    #region StringHelper definition
    public static partial class LogicHelper
    {
        #region Methods
		public static String[] ValueSeparator(string logic, string columnValue)
		{
			bool isPhrase = logic.Equals("Phrase", StringComparison.OrdinalIgnoreCase);
			String[] columnValues = null;
			if (!isPhrase)
			{	
				columnValues = columnValue.Split(SplitSeparator, StringSplitOptions.RemoveEmptyEntries);
			}
			else
			{
				columnValues = new String [] { columnValue };
			}		
			return columnValues;
		}
        #endregion
		
		public static readonly char[] SplitSeparator = new Char [] {' ', ',', '.', ':', ';', '(', ')', '?', '!'};
    }
    #endregion
}
