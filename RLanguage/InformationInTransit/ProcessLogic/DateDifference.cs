using System;
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

using System.Text.RegularExpressions;

/*
	2017-01-25	Remove namespace for assembly
	2017-08-30	FromUntil() added. DateDiff?
EXEC sp_configure 'allow updates', 0
RECONFIGURE

sp_configure 'show advanced options', 1;
GO
RECONFIGURE WITH OVERRIDE;
GO

sp_configure 'clr enabled', 1;
GO
RECONFIGURE WITH OVERRIDE;
GO

DROP FUNCTION [dbo].[YearMonthWeekDay]
GO

DROP ASSEMBLY DateDifference
GO

CREATE ASSEMBLY DateDifference
FROM 'E:\WordEngineering\InformationInTransit\ProcessLogic\DateDifference.dll'
WITH PERMISSION_SET = SAFE
GO

CREATE FUNCTION [dbo].[FromUntil] (@datedFrom DateTime2, @datedUntil DateTime2)
RETURNS int
AS EXTERNAL NAME [DateDifference].[DateDifference].[FromUntil];
GO

SELECT dbo.Fromuntil('20 March 2003', '15 December 2011')
GO

CREATE FUNCTION [dbo].[YearMonthWeekDay] (@dateFrom DateTime2, @dateTo DateTime2)
RETURNS NVARCHAR(50)
AS EXTERNAL NAME [DateDifference].[DateDifference].[YearMonthWeekDay];
GO

SELECT dbo.YearMonthWeekDay('20 March 2003', '15 December 2011')
GO

CREATE FUNCTION [dbo].[YearMonthWeekDay] (@dateFrom DateTime2, @dateTo DateTime2)
RETURNS NVARCHAR(50)
AS EXTERNAL NAME [DateDifference].[DateDifference].[YearMonthWeekDay];
GO

SELECT dbo.YearMonthWeekDay('20 March 2003', '15 December 2011')
GO
*/
/*
csc.exe DateDifference.cs
csc.exe /target:library DateDifference.cs 

REM Loading and Running the "E:\WordEngineering\InformationInTransit\ProcessLogic\DateDifferenceSQLCLR.dll" Function in SQL Server
CREATE ASSEMBLY DateDifference from 'E:\WordEngineering\InformationInTransit\ProcessLogic\DateDifference.dll' WITH PERMISSION_SET = SAFE
GO

CREATE FUNCTION YearMonthWeekDay(@dateFrom DateTime, @dateTo DateTime)
RETURNS NVARCHAR(MAX)
AS EXTERNAL NAME DateDifference.[DateDifference].YearMonthWeekDay
GO

REM Test
SELECT dbo.DateDifference('2014-12-09', '2015-12-09')
GO

REM Removing the "YearMonthWeekDay" Function Sample
DROP Function  YearMonthWeekDay
GO

DROP assembly DateDifference
GO
*/
/*
	2015-12-09	YearMonthWeekDay.	Month and day, exact.
*/

/*
	2014-01-29 http://english.stackexchange.com/questions/132423/word-or-phrase-for-the-beginning-or-end-of-an-event-or-period-of-time 
	Terminus (plural termini, if you want to be stuffy) is the Latin word for either end of a 1-dimensional extent, and specifically of motion along that dimension. If one uses a Time Is Linear Motion metaphor theme, and considers the timeline of an event, one can talk about the beginning as the terminus a quo 'the terminus from which', and the ending as the terminus ad quem 'the terminus toward which'. These are all established words and phrases in English. –  John Lawler Oct 21 '13 at 17:04 
	2014-09-04 from = from.Date; to = to.Date;
*/
/*
	2017-01-23	Unless one is true; where is the found? http://stackoverflow.com/questions/13025744/need-regex-to-extract-only-alphabets-from-string
		UnlessOneIsTrueWhereIsTheFound(Convert.ToDateTime(argv[0]), argv[1]);
	2017-01-25	InformationInTransit.ProcessLogic namespace	
*/
/*
	2017-04-03	UnixEpoch()
*/
namespace InformationInTransit.ProcessLogic 
{
	public static partial class DateDifference
	{
		public static void Main(string[] argv)
		{
			if (argv.Count() == 2)
			{	
				Caption(argv[0], argv[1]);
			}
			else
			{	
				TheChildrenOfDonald(argv);
			}
		}
		
		[SqlFunction(IsDeterministic = true)]
		public static SqlString BiblicalCalendar(TimeSpan dateDifference)
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
			
			return sb.ToString();
		}

		/*
		[SqlFunction(IsDeterministic = true)]
		public static int CalculateElapsedDays(DateTime from, DateTime now) => (now - from).Days;
		*/
		
		[SqlFunction(IsDeterministic = true)]
		public static SqlString Caption(String datedFrom, String datedUntil)
		{
			DateTime fromDate = Convert.ToDateTime(datedFrom).Date;
			DateTime untilDate = Convert.ToDateTime(datedUntil).Date;
			
			TimeSpan duration = untilDate.Subtract(fromDate);

			string caption = String.Format
			(
				CaptionFormat,
				Days(duration),
				BiblicalCalendar(duration),
				YearMonthWeekDay(fromDate, untilDate) //,
				//UnixEpoch(fromDate, untilDate)
			);
			
			System.Console.WriteLine(caption);
			return caption;
		}
		
		[SqlFunction(IsDeterministic = true)]
		public static SqlString Days(TimeSpan dateDifference)
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
			return sb.ToString();
		}

		[SqlFunction(IsDeterministic = true)]
		public static int FromUntil(DateTime datedFrom, DateTime datedUntil)
		{
			DateTime fromDate = Convert.ToDateTime(datedFrom).Date;
			DateTime untilDate = Convert.ToDateTime(datedUntil).Date;
			
			TimeSpan duration = untilDate.Subtract(fromDate);
			
			return duration.Days;
		}
		
		/*
			2017-01-02 The Children of Donald.	https://en.wikipedia.org/wiki/Donald_Trump
			https://en.wikipedia.org/wiki/Donald_Trump_Jr.	December 31, 1977
			https://en.wikipedia.org/wiki/Ivanka_Trump	October 30, 1981
			https://en.wikipedia.org/wiki/Eric_Trump	January 6, 1984
			https://en.wikipedia.org/wiki/Tiffany_Trump	October 13, 1993
			DateDifference 1977-12-31 1981-10-30 1984-01-06 1993-10-13 2017-01-02
				47627 (132 biblical years, 3 biblical months, 17 days) (130 years, 4 months, 3 weeks, 3 days)
		*/
		[SqlFunction(IsDeterministic = true)]
		public static SqlString TheChildrenOfDonald(string[] argv)
		{
			DateTime fromDate;
			DateTime untilDate = Convert.ToDateTime(argv[argv.Count() - 1]).Date;
			TimeSpan duration;
			Int32 days = 0;
			Int32 interval = 0;
			
			for (int index = 0; index < argv.Count() - 1; ++index)
			{
				fromDate = Convert.ToDateTime(argv[index]).Date;
				duration = untilDate.Subtract(fromDate);
				days = duration.Days;
				interval += days;
			}
			
			fromDate = untilDate.AddDays(-interval);
			
			string caption = String.Format
			(
				CaptionFormat,
				interval,
				BiblicalCalendar(new TimeSpan(interval * 24, 0, 0)),
				YearMonthWeekDay(fromDate, untilDate)
			);
			
			System.Console.WriteLine(caption);
			
			return caption;
		}
		
		[SqlFunction(IsDeterministic = true)]
		public static DateTime UnlessOneIsTrueWhereIsTheFound(DateTime datetime, string offset)
		{
			StringBuilder sb = new StringBuilder();

			DateTime dated = datetime.Date;

			offset = offset.ToLower();
			offset = offset.Replace(" ", String.Empty);
			
			int sign = 1;
			
			if (offset[0] == '-')
			{
				sign = -1;
				offset = offset.Substring(1);	
			}	
			
			string[] calendarParts = offset.Split(Separators);
			string calendarPart = "";
			
			int currentMonth = -1;
			
			for (int index = calendarParts.Length - 1; index >= 0; --index)
			{
				calendarPart = calendarParts[index];
				
				Match match = Regex.Match(calendarPart, @"\d+");
				int number = Convert.ToInt32(match.Value) * sign;
				
				string unit = Regex.Replace(calendarPart, @"\d", "");
				
				if (unit[unit.Length - 1] == 's')
				{
					unit = unit.Substring(0, unit.Length - 1);
				}		
				
				if (String.Compare(unit, CalendarUnits[3], true) == 0) //Days
				{		
					dated = dated.AddDays(number);
				}
				else if (String.Compare(unit, CalendarUnits[2], true) == 0) //Weeks
				{		
					dated = dated.AddDays(number * 7);
				}
				else if (String.Compare(unit, CalendarUnits[1], true) == 0) //Months
				{		
					dated = dated.AddMonths(number);
				}
				else if (String.Compare(unit, CalendarUnits[0], true) == 0) //Years
				{		
					dated = dated.AddYears(number);
				}
				
				Console.WriteLine
				(
					"CalendarPart Unit: {0} | Number: {1} | Dated: {2}",
					unit,
					number,
					dated
				);
			}	
			return dated;
		}

		//2017-04-03
		/*
		[SqlFunction(IsDeterministic = true)]
		public static SqlString UnixEpoch(DateTime dateFrom, DateTime dateTo)
		{
			StringBuilder sb = new StringBuilder();

			DateTimeOffset dtoFrom = new DateTimeOffset(dateFrom);
			DateTimeOffset dtoTo = new DateTimeOffset(dateTo);
			
			return String.Format
			(
				"{0} ... {1}",
				dtoFrom.ToUnixTimeSeconds(),
				dtoTo.ToUnixTimeSeconds()
			);	
		}
		*/
		
		[SqlFunction(IsDeterministic = true)]
		public static SqlString YearMonthWeekDay(DateTime dateFrom, DateTime dateTo)
		{
			DateTime 			dateCurrent = dateFrom;
			int					days = 0;
			int					weeks = 0;
			int					months = 0;
			int					years = 0;
			
			int					weekDays = 0;
			
			List<DaysInYears>	daysInYears = new List<DaysInYears>();
			
			if ( dateCurrent < dateTo && dateCurrent.Day == dateTo.Day && dateCurrent.Month == dateTo.Month)
			{
				daysInYears.Add( new DaysInYears{ Metric = "year", Value = dateTo.Year - dateCurrent.Year } );
				goto CombineMetric;
			}
			
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
			
			CombineMetric:
			
			StringBuilder sb = new StringBuilder();
			
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
			
			return sb.ToString();
		}
		
		//public const string CaptionFormat = "{0} ({1}) ({2}) ({3})";
		public const string CaptionFormat = "{0} ({1}) ({2})";
		
		public static readonly string[] CalendarUnits = { "year", "month", "week", "day" };

		//											  1	  2	  3	  4	  5	  6	  7,  8,  9  10, 11, 12	
		public static readonly int[] DaysInMonth = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
		
		public static readonly char[] Separators = { ',', ';' };
		
		public class DaysInYears
		{
			public string Metric { get; set; }
			public int Value { get; set; }
		}
	}
}
