using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;


/*
	2024-07-06T16:03:00	http://en.wikipedia.org/wiki/Five_Ws
	2024-07-06T16:03:00	http://stackoverflow.com/questions/1738990/initializing-jagged-arrays
	double[] data = {new double[] {1, 4, 2}, new double[] {7, 4, 2,1, 0.66, 5.44}, new double[] {1.2345678521, 874347665423.12347234563233, 5e33, 66e234, 6785e34}};
	2024-07-06T16:03:00 ... 2024-07-06T16:53:00	Code.
	2024-07-06T16:53:00 ... 2024-07-06T17:17:00	JaggedArray2.
*/
namespace InformationInTransit.ProcessCode
{
    public partial class FiveWs
    {
		public static string QueryLike
		(
			String 	columnName,
			String	columnValue
		)
		{
			StringBuilder sb = new StringBuilder();
			for 
			(
				int index = 0, length = JaggedArray2.Length;
				index < length;
				++index
			)
			{
				if 
				( 
					String.Equals
					(
						columnValue,
						JaggedArray2[index][0],
						StringComparison.OrdinalIgnoreCase
					) 
					==
					false
				)
				{
					continue;
				}
				foreach(String currentValue in JaggedArray2[index])
				{
					if (sb.Length == 0)
					{
						sb.Append(" WHERE ");
					}
					else
					{
						sb.Append(" OR ");
					}
					sb.AppendFormat
					(
						" {0} LIKE '%{1}%' ",
						columnName,
						currentValue
					);
				}	
			}	
			return sb.ToString();
		}
		
		public static readonly String[][] JaggedArray2 = new String[][]
		{
			new String[] { "Who", "God", "Jesus", "Spirit", "Angel", "Man", "Woman", "Husband", "Wife", "Son", "Daughter", "King", "Queen", "Prophet", "Priest", "Pastor" }, 
			new String[] { "What" },
			new String[] { "When", "Beginning", "End", "Evening", "Morning", "Day", "Sabbath", "Week", "Month", "Year", "Hour", "Generation", "Season" },
			new String[] { "Where", "Heaven", "Earth", "Eden", "Land", "Sea", "Water", "Well", "Jerusalem", "Egypt", "Babylon", "Babel", "Jordan", "Asia", "Ethiopia" },
			new String[] { "Why" }			
		};	
	}
}
