#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Collections.ObjectModel;
using System.Globalization;
using System.Threading;
#endregion

namespace InformationInTransit.ProcessLogic
{
    #region DateTimeHelper definition
	/*
		2018-12-18	https://mikeinmadison.wordpress.com/2008/03/12/datetimeround/
	*/
    public static partial class DateTimeHelper
    {
        #region Methods
        public static void Main(string[] argv)
        {
            System.Console.WriteLine(ToFriendlyDateString(DateTime.Now));
			System.Console.WriteLine(RetrieveFriendlyRelativeTime(DateTime.Now));
            DateTime dateTime = new DateTime(1971, 09, 05);
            System.Console.WriteLine(dateTime.ToRelativeDate());
            System.Console.WriteLine(UnixTime());
            System.Console.WriteLine(EasterSundayOf(1985));
            System.Console.WriteLine(IsLeapYear(new DateTime(2010,1,1)));
			System.Console.WriteLine((new DateTime(2010,5,26)).AddWorkingDays(11));
            Dictionary<int, string> monthNames = MonthName();
            System.Console.WriteLine(DateTime.Now.ToDate());
            System.Console.WriteLine(DateTime.Now.ToTime());
            System.Console.WriteLine(DateTime.UtcNow);
            System.Console.WriteLine(DateTime.UtcNow.Kind);
            System.Console.WriteLine(DateTime.Now.WeekOfYear());
			long unixTime = 1428044400;
			System.Console.WriteLine(unixTime.FromUnixTime());
			System.Console.WriteLine(DateTime.Today.ToUnixTime());
        }

        /// <example>
        /// var newYearsEve2010 = new DateTime(2010, 12, 31);
        /// var firstWeekdayAfterNewYearsEve2010 = newYearsEve2010.AddWeekdays(1);
        /// </example>
        public static DateTime AddWeekdays(this DateTime date, int days)
        {
            var sign = days < 0 ? -1 : 1;
            var unsignedDays = Math.Abs(days);
            var weekdaysAdded = 0;
            while (weekdaysAdded < unsignedDays)
            {
                date = date.AddDays(sign);
                if (date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday)
                weekdaysAdded++;
            }
            return date;
        }

        ///<summary>
		///Adding Workdays to a Date
		///This example adds the days of the week and the weeks separately. You never iterate over the loop more then four times regardless of the number of days being added.
		///After adding the day of the week, simply add seven days for every five business days to calculate the final result. Note that the function works for both future and past dates:
		///</summary>
        ///<example>
        ///System.Console.WriteLine((new DateTime(2010,5,26)).AddWorkingDays(11));
        ///</example>
		public static DateTime AddWorkingDays(this DateTime dtFrom, int nDays)
		{
			int nDirection = 1;
			if (nDays < 0) { nDirection = -1; }
			int nWeekday = nDays % 5;
			while(nWeekday != 0)
			{
				dtFrom = dtFrom.AddDays(nDirection);
				if (dtFrom.DayOfWeek != DayOfWeek.Saturday
					&& dtFrom.DayOfWeek != DayOfWeek.Sunday)
				{
					nWeekday -= nDirection;
				}
			}
			int nDayweek = (nDays / 5) * 7;
			dtFrom = dtFrom.AddDays(nDayweek);
			return dtFrom;
		}

        ///<summary>
		/// 2003-12-10 Church Calendar: 1 Advent the prior Sunday 4 weeks before Christmas 2003-11-30T00:00:00.0000000-08:00 ... 2003-12-24T00:00:00.0000000-08:00. 2 Christmas season 12 days 2003-12-25T00:00:00.0000000-08:00 ... 2004-01-06T00:00:00.0000000-08:00. 3 Epiphany, Greek, short forth, make manifest, commences after the Christmas season and ends the day before Ash Wednesday, 2004-01-07T00:00:00.0000000-08:00 ... 2004-02-21T00:00:00.0000000-08:00. 4 Ash Wednesday, last Wednesday in February 2004-02-25T00:00:00.0000000-08:00. 5 Lent, 40 days before Easter Sunday 2004-03-09T00:00:00.0000000-08:00. 6 Easter Sunday 2004-04-18T00:00:00.0000000-08:00. 7 Pentecost, 50 days after Easter Sunday 2004-06-07T00:00:00.0000000-08:00.
		///</summary>
		public static DateTime EasterSundayOf(int YearToCheck)
        {
            int Y = YearToCheck;
            int a = Y % 19;
            int b = Y / 100;
            int c = Y % 100;
            int d = b / 4;
            int e = b % 4;
            int f = (b + 8) / 25;
            int g = (b - f + 1) / 3;
            int h = (19 * a + b - d - g + 15) % 30;
            int i = c / 4;
            int k = c % 4;
            int L = (32 + 2 * e + 2 * i - h - k) % 7;
            int m = (a + 11 * h + 22 * L) / 451;
            int Month = (h + L - 7 * m + 114) / 31;
            int Day = ((h + L - 7 * m + 114) % 31) + 1;

            DateTime dtEasterSunday = new DateTime(YearToCheck, Month, Day);

            return dtEasterSunday;
        }

		///<remarks>
		///http://extensionmethod.net/csharp/datetime/endoftheday
		///</remarks>
		///<example>
		///var endOfTheDay = DateTime.Now.EndOfTheDay();
		///</example>
		public static DateTime EndOfTheDay(this DateTime date)
		{
			return new DateTime(date.Year, date.Month, date.Day, 23, 59, 59, 999);
		}

        public static DateTime FirstDayOfMonth(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, 1);
        }
     
		///<summary>
		///http://stackoverflow.com/questions/2883576/how-do-you-convert-epoch-time-in-c
		///long unixTime = 1428044400;
		///System.Console.WriteLine(unixTime.FromUnixTime());
		///</summary>
		public static DateTime FromUnixTime(this long unixTime)
		{
			var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
			return epoch.AddSeconds(unixTime);
		}
		
		///<summary>
		///http://extensionmethod.net/csharp/datetime/isweekend
		///</summary>
		public static bool IsWeekend(this DateTime value)
		{
			return (value.DayOfWeek == DayOfWeek.Sunday || value.DayOfWeek == DayOfWeek.Saturday);
		}

		public static bool IsLeapYear(this DateTime value)
        {
            bool isLeapYear = value.Year % 4 == 0 && (value.Year % 100 != 0 || value.Year % 400 == 0);
            //return (System.DateTime.DaysInMonth(value.Year, 2) == 29);
            return System.DateTime.IsLeapYear(value.Year);
        }

        public static DateTime LastDayOfMonth(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, DateTime.DaysInMonth(date.Year, date.Month));
        }

        public static Dictionary<int,string> MonthName()
        {
            Dictionary<int, string> monthNames = new Dictionary<int, string>();

            for (int monthNumber = 1; monthNumber <= 12; ++monthNumber)
            {
                monthNames.Add
                (
                    monthNumber,
                    CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(monthNumber)
                );
            }
            return monthNames;
        }

        public static DateTime? Parse(string year, string month, string day)
        {
            DateTime? datetime = null;
            try
            {
                datetime = DateTime.Parse
                (
                    month + " " + day + " " + year
                );
            }
            catch (Exception ex)
            {
            } 
            return datetime;
        }

		public static string RetrieveFriendlyRelativeTime(DateTime dateTime)
        {
            if (DateTime.UtcNow.Ticks == dateTime.Ticks)
            {
                return "Right now!";
            }

            bool isFuture = (DateTime.UtcNow.Ticks < dateTime.Ticks);
            var ts = DateTime.UtcNow.Ticks < dateTime.Ticks ? new TimeSpan(dateTime.Ticks - DateTime.UtcNow.Ticks) : new TimeSpan(DateTime.UtcNow.Ticks - dateTime.Ticks);

            double delta = ts.TotalSeconds;

            if (delta < 1 * MINUTE)
            {
                return isFuture ? "in " + (ts.Seconds == 1 ? "one second" : ts.Seconds + " seconds") : ts.Seconds == 1 ? "one second ago" : ts.Seconds + " seconds ago";
            }
            if (delta < 2 * MINUTE)
            {
                return isFuture ? "in a minute" : "a minute ago";
            }
            if (delta < 45 * MINUTE)
            {
                return isFuture ? "in " + ts.Minutes + " minutes" : ts.Minutes + " minutes ago";
            }
            if (delta < 90 * MINUTE)
            {
                return isFuture ? "in an hour" : "an hour ago";
            }
            if (delta < 24 * HOUR)
            {
                return isFuture ? "in " + ts.Hours + " hours" : ts.Hours + " hours ago";
            }
            if (delta < 48 * HOUR)
            {
                return isFuture ? "tomorrow" : "yesterday";
            }
            if (delta < 30 * DAY)
            {
                return isFuture ? "in " + ts.Days + " days" : ts.Days + " days ago";
            }
            if (delta < 12 * MONTH)
            {
                int months = Convert.ToInt32(Math.Floor((double)ts.Days / 30));
                return isFuture ? "in " + (months <= 1 ? "one month" : months + " months") : months <= 1 ? "one month ago" : months + " months ago";
            }
            else
            {
                int years = Convert.ToInt32(Math.Floor((double)ts.Days / 365));
                return isFuture ? "in " + (years <= 1 ? "one year" : years + " years") : years <= 1 ? "one year ago" : years + " years ago";
            }
        }

		public static DateTime Round(this DateTime d, RoundTo rt)
        {
            DateTime dtRounded = new DateTime();

            switch (rt)
            {
                case RoundTo.Second:
                    dtRounded = new DateTime(d.Year, d.Month, d.Day, d.Hour, d.Minute, d.Second);
                    if (d.Millisecond >= 500) dtRounded = dtRounded.AddSeconds(1);
                    break;
                case RoundTo.Minute:
                    dtRounded = new DateTime(d.Year, d.Month, d.Day, d.Hour, d.Minute, 0);
                    if (d.Second >= 30) dtRounded = dtRounded.AddMinutes(1);
                    break;
                case RoundTo.Hour:
                    dtRounded = new DateTime(d.Year, d.Month, d.Day, d.Hour, 0, 0);
                    if (d.Minute >= 30) dtRounded = dtRounded.AddHours(1);
                    break;
                case RoundTo.Day:
                    dtRounded = new DateTime(d.Year, d.Month, d.Day, 0, 0, 0);
                    if (d.Hour >= 12) dtRounded = dtRounded.AddDays(1);
                    break;
            }

            return dtRounded;
        }

        public enum RoundTo
        {
            Second, Minute, Hour, Day
        }
    		
        public static DateTime SetTime(this DateTime date, int hour)
        {
            return date.SetTime(hour, 0, 0, 0);
        }
        public static DateTime SetTime(this DateTime date, int hour, int minute)
        {
            return date.SetTime(hour, minute, 0, 0);
        }
        public static DateTime SetTime(this DateTime date, int hour, int minute, int second)
        {
            return date.SetTime(hour, minute, second, 0);
        }
        public static DateTime SetTime(this DateTime date, int hour, int minute, int second, int millisecond)
        {
            return new DateTime(date.Year, date.Month, date.Day, hour, minute, second, millisecond);
        }

        public static string ToDate(this DateTime dateTime)
        {
            return dateTime.ToString("D");
        }

        ///<remarks>
		///	extensionmethod.net/csharp/datetime/tofriendlydatestring Feb 12, 2008
		///</remarks>
		public static string ToFriendlyDateString(this DateTime Date)
        {
            string FormattedDate = "";
            if (Date.Date == DateTime.Today)
            {
                FormattedDate = "Today";
            }
            else if (Date.Date == DateTime.Today.AddDays(-1))
            {
                FormattedDate = "Yesterday";
            }
            else if (Date.Date > DateTime.Today.AddDays(-6))
            {
                // *** Show the Day of the week
                FormattedDate = Date.ToString("dddd").ToString();
            }
            else
            {
                FormattedDate = Date.ToString("MMMM dd, yyyy");
            }

            //append the time portion to the output
            FormattedDate += " @ " + Date.ToString("t").ToLower();
            return FormattedDate;
        }

        /// <summary>
        /// Converts the specified DateTime to its relative date.
        /// </summary>
        /// <param name="dateTime">The DateTime to convert.</param>
        /// <returns>A string value based on the relative date
        /// of the datetime as compared to the current date.</returns>
        public static string ToRelativeDate(this DateTime dateTime)
        {
            var timeSpan = DateTime.Now - dateTime;
            // span is less than or equal to 60 seconds, measure in seconds.

            if (timeSpan <= TimeSpan.FromSeconds(60))
            {
              return timeSpan.Seconds + " seconds ago";
            }

            // span is less than or equal to 60 minutes, measure in minutes.
            if (timeSpan <= TimeSpan.FromMinutes(60))
            {
                return timeSpan.Minutes > 1
                    ? "about " + timeSpan.Minutes + " minutes ago"
                    : "about a minute ago";
            }

            // span is less than or equal to 24 hours, measure in hours.
            if (timeSpan <= TimeSpan.FromHours(24))
            {
                return timeSpan.Hours > 1
                    ? "about " + timeSpan.Hours + " hours ago"
                    : "about an hour ago";
            }

            // span is less than or equal to 30 days (1 month), measure in days.
            if (timeSpan <= TimeSpan.FromDays(30))
            {
                return timeSpan.Days > 1
                    ? "about " + timeSpan.Days + " days ago"
                    : "about a day ago";
            }

            // span is less than or equal to 365 days (1 year), measure in months.
            if (timeSpan <= TimeSpan.FromDays(365))
            {
                return timeSpan.Days > 30
                    ? "about " + timeSpan.Days / 30 + " months ago"
                    : "about a month ago";
            }

            // span is greater than 365 days (1 year), measure in years.
            return timeSpan.Days > 365
                ? "about " + timeSpan.Days / 365 + " years ago"
                : "about a year ago";
        }

        public static string ToRelativeDateString(this DateTime date)
        {
            return ToRelativeDateValue(date, DateTime.Now);
        }
        public static string ToRelativeDateStringUtc(this DateTime date)
        {
            return ToRelativeDateValue(date, DateTime.UtcNow);
        }
        private static string ToRelativeDateValue(DateTime date, DateTime comparedTo)
        {
            TimeSpan diff = comparedTo.Subtract(date);
            if (diff.TotalDays >= 365)
                return string.Concat("on ", date.ToString("MMMM d, yyyy"));
            if (diff.TotalDays >= 7)
                return string.Concat("on ", date.ToString("MMMM d"));
            else if (diff.TotalDays > 1)
                return string.Format("{0:N0} days ago", diff.TotalDays);
            else if (diff.TotalDays == 1)
                return "yesterday";
            else if (diff.TotalHours >= 2)
                return string.Format("{0:N0} hours ago", diff.TotalHours);
            else if (diff.TotalMinutes >= 60)
                return "more than an hour ago";
            else if (diff.TotalMinutes >= 5)
                return string.Format("{0:N0} minutes ago", diff.TotalMinutes);
            if (diff.TotalMinutes >= 1)
                return "a few minutes ago";
            else
                return "less than a minute ago";
        }

        public static string ToRFC822DateString(this DateTime date)
        {
            int offset = TimeZone.CurrentTimeZone.GetUtcOffset(DateTime.Now).Hours;
            string timeZone = "+" + offset.ToString().PadLeft(2, '0');
            if (offset < 0)
            {
                int i = offset * -1;
                timeZone = "-" + i.ToString().PadLeft(2, '0');
            }
            return date.ToString("ddd, dd MMM yyyy HH:mm:ss " + timeZone.PadRight(5, '0'), System.Globalization.CultureInfo.GetCultureInfo("en-US"));
        }

        public static string ToString(this DateTime? date)
        {
            return date.ToString(null, DateTimeFormatInfo.CurrentInfo);
        }
        public static string ToString(this DateTime? date, string format)
        {
            return date.ToString(format, DateTimeFormatInfo.CurrentInfo);
        }
        public static string ToString(this DateTime? date, IFormatProvider provider)
        {
            return date.ToString(null, provider);
        }
        public static string ToString(this DateTime? date, string format, IFormatProvider provider)
        {
            if (date.HasValue)
                return date.Value.ToString(format, provider);
            else
                return string.Empty;
        }

        public static string ToTime(this DateTime dateTime)
        {
            return dateTime.ToString("T");
        }

		///<summary>
		///	2015-04-03 Created.
		///	http://stackoverflow.com/questions/2883576/how-do-you-convert-epoch-time-in-c
		///</summary>
		public static long ToUnixTime(this DateTime date)
		{
			var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
			return Convert.ToInt64((date.ToUniversalTime() - epoch).TotalSeconds);
		}

        public static long UnixTime()
        {
            long unixTime = (long)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;
            return unixTime;
        }

        public static int WeekOfYear(this DateTime date, CultureInfo culture = null)
        {
            culture = culture ?? Thread.CurrentThread.CurrentCulture;

            var result = culture.Calendar.GetWeekOfYear
            (
                date,
                culture.DateTimeFormat.CalendarWeekRule,
                culture.DateTimeFormat.FirstDayOfWeek
            );
            return result;
        }
		private const int SECOND = 1;
        private const int MINUTE = 60 * SECOND;
        private const int HOUR = 60 * MINUTE;
        private const int DAY = 24 * HOUR;
        private const int MONTH = 30 * DAY;
#endregion
    }
#endregion
}
