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
	2014-01-29 http://english.stackexchange.com/questions/132423/word-or-phrase-for-the-beginning-or-end-of-an-event-or-period-of-time 
	Terminus (plural termini, if you want to be stuffy) is the Latin word for either end of a 1-dimensional extent, and specifically of motion along that dimension. If one uses a Time Is Linear Motion metaphor theme, and considers the timeline of an event, one can talk about the beginning as the terminus a quo 'the terminus from which', and the ending as the terminus ad quem 'the terminus toward which'. These are all established words and phrases in English. –  John Lawler Oct 21 '13 at 17:04 
	2014-09-04 from = from.Date; to = to.Date;
*/

/*
	2018-08-14	https://forums.asp.net/t/1289294.aspx?TimeSpan+Years+and+Months
*/
namespace InformationInTransit.ProcessLogic 
{
	public partial class TimeSpanYearMonthDay
	{
		public static void Main(string[] argv)
		{
			if (argv.Count() == 2)
			{	
				System.Console.WriteLine
				(
					new TimeSpanYearMonthDay
					(
						Convert.ToDateTime(argv[0]),
						Convert.ToDateTime(argv[1])
					)
				);
			}
		}
		
        /// <summary>
        /// defining Number of days in month; index 0=> january and 11=> December
        /// february contain either 28 or 29 days, that's why here value is -1
        /// which wil be calculate later.
        /// </summary>
        private int[] monthDay = new int[12] { 31, -1, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

        /// <summary>
        /// contain from date
        /// </summary>
        private DateTime fromDate;

        /// <summary>
        /// contain To Date
        /// </summary>
        private DateTime toDate;

        /// <summary>
        /// this three variable for output representation..
        /// </summary>
        private int year;
        private int month;
        private int day;

		public TimeSpanYearMonthDay(DateTime d1, DateTime d2)
		{
			int increment;
			
			if (d1 > d2)
			{
				this.fromDate = d2;
				this.toDate = d1;
			}
			else
			{
				this.fromDate = d1;
				this.toDate = d2;
			}

			///
			/// Day Calculation
			/// 
			increment = 0;

			if (this.fromDate.Day > this.toDate.Day)
			{
				increment = this.monthDay[this.fromDate.Month - 1];

			}
			/// if it is february month
			/// if it's to day is less then from day
			if (increment == -1)
			{
				if (DateTime.IsLeapYear(this.fromDate.Year))
				{
					// leap year february contain 29 days
					increment = 29;
				}
				else
				{
					increment = 28;
				}
			}
			if (increment != 0)
			{
				day = (this.toDate.Day + increment) - this.fromDate.Day;
				increment = 1;
			}
			else
			{
				day = this.toDate.Day - this.fromDate.Day;
			}

			///
			///month calculation
			///
			if ((this.fromDate.Month + increment) > this.toDate.Month)
			{
				this.month = (this.toDate.Month + 12) - (this.fromDate.Month + increment);
				increment = 1;
			}
			else
			{
				this.month = (this.toDate.Month) - (this.fromDate.Month + increment);
				increment = 0;
			}

			///
			/// year calculation
			///
			this.year = this.toDate.Year - (this.fromDate.Year + increment);
		}
	
		public override string ToString()
		{
			//return base.ToString();
			return this.year + " Year(s), " + this.month + " month(s), " + this.day + " day(s)";
		}

		public int Years
		{
			get
			{
				return this.year;
			}
		}

		public int Months
		{
			get
			{
				return this.month;
			}
		}

		public int Days
		{
			get
			{
				return this.day;
			}
		}
	}	
}
