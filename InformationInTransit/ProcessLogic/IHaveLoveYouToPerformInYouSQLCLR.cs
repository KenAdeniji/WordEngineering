using Microsoft.SqlServer.Server;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

/*
2014-09-02 IHaveLoveYouToPerformInYouSQLCLR.cs I have love you, to perform in you. At the door of the bathroom, prepare to shower.
2014-09-03 IsLaborDay Labor Day in the United States is a holiday celebrated on the first Monday in September. en.wikipedia.org/wiki/Labor_Day
2014-09-03 http://geekswithblogs.net/wpeck/archive/2011/12/27/us-holiday-list-in-c.aspx
2014-09-03 http://en.wikipedia.org/wiki/Public_holidays_in_the_United_States
2014-09-04 http://blog.lab49.com/archives/206 Find the nth Specific Weekday in a Month
2014-09-04 DateTime.Date.
*/
namespace InformationInTransit.ProcessLogic
{
	public static partial class IHaveLoveYouToPerformInYou
	{
		public static void Main (string[] argv)
		{
			foreach(string current in argv)
			{
				DateTime dated = DateTime.Today;
				bool isDate = DateTime.TryParse(current, out dated);
				if (!isDate)
				{
					continue;
				}
				SqlString result = Query(dated);
				System.Console.WriteLine(result);
			}	
		}
		
		public static void Concatenate(ref StringBuilder sb, string day)
		{
			if(sb.Length > 0)
			{
				sb.Append(' ');
			}
			
			sb.Append(day);
		}
		
		[SqlFunction(DataAccess = DataAccessKind.Read)]
		public static SqlString Query(DateTime dated)
		{
			StringBuilder answer = new StringBuilder();
		
			dated = dated.Date;
			
			if (dated.Month == 1 && dated.Day == 1)
			{
				Concatenate(ref answer, "New Year Day.");
			}

			if (dated == MemorialDay(dated.Year))
			{
				Concatenate(ref answer, "Memorial Day.");
			}

			if (dated.Month == 7 && dated.Day == 4)
			{
				Concatenate(ref answer, "Independence Day.");
			}

			if (dated == FindTheNthSpecificWeekday(dated.Year, 9, 1, System.DayOfWeek.Monday))
			{
				Concatenate(ref answer, "Labor Day.");
			}
			
			if (dated == FindTheNthSpecificWeekday(dated.Year, 11, 4, System.DayOfWeek.Thursday))
			{
				Concatenate(ref answer, "Thanksgiving Day.");
			}
			
			if (dated.Month == 12 && dated.Day == 25)
			{
				Concatenate(ref answer, "Christmas Day.");
			}

			return answer.ToString();
		}

		public static DateTime FindTheNthSpecificWeekday(int year, int month,int nth, System.DayOfWeek day_of_the_week)
		{
			// validate month value
			if(month < 1 || month > 12)
			{
				throw new ArgumentOutOfRangeException("Invalid month value.");
			}

			// validate the nth value
			if(nth < 0 || nth > 5)
			{
				throw new ArgumentOutOfRangeException("Invalid nth value.");
			}

			// start from the first day of the month
			DateTime dt = new DateTime(year, month, 1);

			// loop until we find our first match day of the week
			while(dt.DayOfWeek != day_of_the_week)
			{
				dt = dt.AddDays(1);
			}

			if(dt.Month != month)
			{
				// we skip to the next month, we throw an exception
				throw new ArgumentOutOfRangeException
				(
					"The given month has less than " + nth.ToString() + " " + day_of_the_week.ToString() + "s"
				);
			}

			// Complete the gap to the nth week
			dt = dt.AddDays((nth - 1) * 7);

			return dt;
		}
		
		public static DateTime MemorialDay(int year)
		{
            DateTime memorialDay = new DateTime(year, 5, 31);
            DayOfWeek dayOfWeek = memorialDay.DayOfWeek;
            while (dayOfWeek != DayOfWeek.Monday)
            {
                memorialDay = memorialDay.AddDays(-1);
                dayOfWeek = memorialDay.DayOfWeek;
            }
			return memorialDay;
		}	
	}
}
