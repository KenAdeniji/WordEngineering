using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

using System.Text;

/*
	2018-08-14	https://goalkicker.com/CSharpBook/CSharpNotesForProfessionals.pdf
*/
namespace InformationInTransit.GoalKicker
{
   public static partial class DateTimeExtensions
   {
		public static void Main(String argv)
		{
			// daysInFeb gets 28 because the year 1998 was not a leap year. 
			int daysInFeb = System.DateTime.DaysInMonth(1998, Feb); 
			Console.WriteLine(daysInFeb);
			
			// daysInFebLeap gets 29 because the year 1996 was a leap year. 
			int daysInFebLeap = System.DateTime.DaysInMonth(1996, Feb);
			Console.WriteLine(daysInFebLeap);		
		}	
		
		const int Feb = 2;
	}
}
