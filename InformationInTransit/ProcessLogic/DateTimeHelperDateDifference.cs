using System;
using System.Data;
using System.Data.SqlClient;

using System.Collections;

namespace InformationInTransit.ProcessLogic
{
	public static partial class DateTimeHelperDateDifference
	{
		public static void Main(string[] argv)
		{
			// Gets the total days from 01/01/2000.
			DateTime from = new DateTime(2000, 01, 01);
			DateTime until = DateTime.Now;	
			Int64 days = from.DateDiff("day", until);
			// Gets the total hours from 01/01/2000.
			Int64 hours = from.DateDiff("hour", until);
			System.Console.WriteLine
			(
				"From: {0} | Until: {1} | Days: {2} | Hours: {3}",
				from,
				until,
				days,
				hours
			);
		}
		
		/// <summary>
		/// DateDiff in SQL style.
		/// Datepart implemented:
		///     "year" (abbr. "yy", "yyyy"),
		///     "quarter" (abbr. "qq", "q"),
		///     "month" (abbr. "mm", "m"),
		///     "day" (abbr. "dd", "d"),
		///     "week" (abbr. "wk", "ww"),
		///     "hour" (abbr. "hh"),
		///     "minute" (abbr. "mi", "n"),
		///     "second" (abbr. "ss", "s"),
		///     "millisecond" (abbr. "ms").
		/// </summary>
		/// <param name="DatePart"></param>
		/// <param name="EndDate"></param>
		/// <returns></returns>
		/// <example>
		/// Gets the total days from 01/01/2000.
		/// DateTime dt = new DateTime(2000, 01, 01);
		/// Int64 days = dt.DateDiff("day", DateTime.Now);
		/// Gets the total hours from 01/01/2000.
		/// Int64 hours = dt.DateDiff("hour", DateTime.Now);
		/// </example>
		/// <remarks>
		/// http://extensionmethod.net/csharp/datetime/datediff
		/// </remarks>
		public static Int64 DateDiff(this DateTime StartDate, String DatePart, DateTime EndDate)
		{
			Int64 DateDiffVal = 0;
			System.Globalization.Calendar cal = System.Threading.Thread.CurrentThread.CurrentCulture.Calendar;
			TimeSpan ts = new TimeSpan(EndDate.Ticks - StartDate.Ticks);
			switch (DatePart.ToLower().Trim())
			{
				#region year
				case "year":
				case "yy":
				case "yyyy":
					DateDiffVal = (Int64)(cal.GetYear(EndDate) - cal.GetYear(StartDate));
					break;
				#endregion
		 
				#region quarter
				case "quarter":
				case "qq":
				case "q":
					DateDiffVal = (Int64)((((cal.GetYear(EndDate)
										- cal.GetYear(StartDate)) * 4)
										+ ((cal.GetMonth(EndDate) - 1) / 3))
										- ((cal.GetMonth(StartDate) - 1) / 3));
					break;
				#endregion
		 
				#region month
				case "month":
				case "mm":
				case "m":
					DateDiffVal = (Int64)(((cal.GetYear(EndDate)
										- cal.GetYear(StartDate)) * 12
										+ cal.GetMonth(EndDate))
										- cal.GetMonth(StartDate));
					break;
				#endregion
		 
				#region day
				case "day":
				case "d":
				case "dd":
					DateDiffVal = (Int64)ts.TotalDays;
					break;
				#endregion
		 
				#region week
				case "week":
				case "wk":
				case "ww":
					DateDiffVal = (Int64)(ts.TotalDays / 7);
					break;
				#endregion
		 
				#region hour
				case "hour":
				case "hh":
					DateDiffVal = (Int64)ts.TotalHours;
					break;
				#endregion
		 
				#region minute
				case "minute":
				case "mi":
				case "n":
					DateDiffVal = (Int64)ts.TotalMinutes;
					break;
				#endregion
		 
				#region second
				case "second":
				case "ss":
				case "s":
					DateDiffVal = (Int64)ts.TotalSeconds;
					break;
				#endregion
		 
				#region millisecond
				case "millisecond":
				case "ms":
					DateDiffVal = (Int64)ts.TotalMilliseconds;
					break;
				#endregion
		 
				default:
					throw new Exception(String.Format("DatePart \"{0}\" is unknown", DatePart));
			}
			return DateDiffVal;
		}
	}	
}
