﻿using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

using Microsoft.SqlServer.Server;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Text;

/*
	2018-10-25	From 2008-06-29 Until 2018-10-25.
*/
namespace InformationInTransit.ProcessCode
{
	public static partial class DateDifferenceHelper
	{
		public static void Main(string[] argv)
		{
			if (argv.Count() == 2)
			{	
				System.Console.WriteLine
				(
					ElapsedTime
					(
						Convert.ToDateTime(argv[0]),
						Convert.ToDateTime(argv[1])
					)
				);
			}
		}
		
		public static string ElapsedTime(DateTime from_date, DateTime to_date) 
		{
		int years;
		int months;
		int days;
		int hours;
		int minutes;
		int seconds;
		int milliseconds;

		//------------------
		// Handle the years.
		//------------------
		years = to_date.Year - from_date.Year;

		//------------------------
		// See if we went too far.
		//------------------------
		DateTime test_date = from_date.AddMonths(12 * years);

		if (test_date > to_date)
		{
			years--;
			test_date = from_date.AddMonths(12 * years);
		}

		//--------------------------------
		// Add months until we go too far.
		//--------------------------------
		months = 0;

		while (test_date <= to_date)
		{
			months++;
			test_date = from_date.AddMonths(12 * years + months);
		}

		months--;

		//------------------------------------------------------------------
		// Subtract to see how many more days, hours, minutes, etc. we need.
		//------------------------------------------------------------------
		from_date = from_date.AddMonths(12 * years + months);
		TimeSpan remainder = to_date - from_date;
		days = remainder.Days;
		hours = remainder.Hours;
		minutes = remainder.Minutes;
		seconds = remainder.Seconds;
		milliseconds = remainder.Milliseconds;

		return 
			(years > 0 ? years.ToString() + " years " : "") +
			(months > 0 ? months.ToString() + " months " : "") +
			(days > 0 ? days.ToString() + " days " : "") +
			(hours > 0 ? hours.ToString() + " hours " : "") +
			(minutes > 0 ? minutes.ToString() + " minutes " : "");
		}

		public static StringBuilder Days(TimeSpan dateDifference)
		{
			StringBuilder sb = new StringBuilder();

			if (dateDifference.Days > 0)
			{
				sb.AppendFormat
				(
					"{0} day{1}",
					dateDifference.Days,
					dateDifference.Days == 1 ? "" : "s"
				);
			}
			return sb;
		}

		public static StringBuilder DaysInYearsMerge
		(
			int years,
			int months,
			int weeks,
			int days
		)	
		{
			StringBuilder sb = new StringBuilder();
			List<DaysInYears>	daysInYears = new List<DaysInYears>();
			daysInYears.Add( new DaysInYears{ Metric = "year", Value = years } );
			daysInYears.Add( new DaysInYears{ Metric = "month", Value = months } );
			daysInYears.Add( new DaysInYears{ Metric = "week", Value = weeks } );
			daysInYears.Add( new DaysInYears{ Metric = "day", Value = days } );
			
			for (int index = 0, count = daysInYears.Count; index < count; ++index)
			{
				if (daysInYears[index].Value == 0) { continue; }
				sb.AppendFormat
				(
					"{0}{1} {2}{3}", 
					sb.Length == 0 ? "" : ", ",
					daysInYears[index].Value,
					daysInYears[index].Metric,
					daysInYears[index].Value == 1 ? "" : "s"
				);			
			}
			
			return sb;
		}
		
		public static StringBuilder BiblicalCalendar(TimeSpan dateDifference)
		{
			int years = (int) (dateDifference.Days / 360);
			int months = (int) ((dateDifference.Days % 360) / 30);
			int days = (int) ((dateDifference.Days % 360) % 30);

			StringBuilder sb = new StringBuilder();

			if (years > 0)
			{
				sb.AppendFormat
				(
					"{0} biblical year{1}", 
					years,
					years == 1 ? "" : "s"
				);
			}

			if (months > 0)
			{
				sb.AppendFormat
				(
					"{0}{1} biblical month{2}", 
					sb.Length == 0 ? "" : ", ",
					months,
					months == 1 ? "" : "s"
				);
			}

			if (days > 0)
			{
				sb.AppendFormat
				(
					"{0}{1} day{2}", 
					sb.Length == 0 ? "" : ", ",
					days,
					days == 1 ? "" : "s"
				);
			}
			
			return sb;
		}
		
		public static StringBuilder GregorianCalendar(DateTime dateFrom, DateTime dateTo)
		{
			DateTime dateCurrent = dateFrom;
			int yearDifference = 0;
			int monthDifference = 0;
			int daysWeeks = 0;
			int weeks = 0;
			int days = 0;
			yearDifference = System.Data.Linq.SqlClient.SqlMethods.DateDiffYear
			(
				dateCurrent, dateTo
			);
			if (yearDifference > 0)
			{
				dateCurrent = dateCurrent.AddYears( yearDifference );
			}	
			monthDifference = System.Data.Linq.SqlClient.SqlMethods.DateDiffMonth
			(
				dateCurrent, dateTo
			);
			if (monthDifference > 0)
			{
				dateCurrent = dateCurrent.AddMonths( monthDifference );
			}	
			daysWeeks = System.Data.Linq.SqlClient.SqlMethods.DateDiffDay
			(
				dateCurrent, dateTo
			);
			weeks = (int) (daysWeeks / 7);	
			days = (daysWeeks % 7);	

			return DaysInYearsMerge
			(
				yearDifference,
				monthDifference,
				weeks,
				days
			);	
		}
		
		public static StringBuilder YearMonthWeekDay(DateTime dateFrom, DateTime dateTo)
		{
			DateTime 			dateCurrent = dateFrom;
			int					days = 0;
			int					weeks = 0;
			int					months = 0;
			int					years = 0;
			
			int					weekDays = 0;
			
			while ( dateCurrent < dateTo )
			{
				int daysOffset = 365;
				if (DateTime.IsLeapYear(dateCurrent.Year))
				{
					daysOffset = 366;
				}
				if ( dateCurrent.AddDays( daysOffset ) > dateTo )
				{
					break;
				}
				dateCurrent = dateCurrent.AddDays( daysOffset );
				++years;
			}
			
			while ( dateCurrent < dateTo )
			{
				int currentMonth = dateCurrent.Month;
				int daysOffset = DaysInMonth[currentMonth - 1];
				if (DateTime.IsLeapYear(dateCurrent.Year) && currentMonth == 2)
				{
					daysOffset = 29;
				}
				if ( dateCurrent.AddDays( daysOffset ) > dateTo )
				{
					break;
				}
				dateCurrent = dateCurrent.AddDays( daysOffset );
				++months;
			}

			weekDays = (dateTo.Subtract(dateCurrent)).Days;
		
			weeks = (int) (weekDays / 7);

			days = weekDays % 7;
			
			return DaysInYearsMerge
			(
				years,
				months,
				weeks,
				days
			);	
		}
		//											  1	  2	  3	  4	  5	  6	  7,  8,  9  10, 11, 12	
		public static readonly int[] DaysInMonth = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
		
		public class DaysInYears
		{
			public string 	Metric 	{ get; set; }
			public int 		Value	{ get; set; }
		}
	}	
}
