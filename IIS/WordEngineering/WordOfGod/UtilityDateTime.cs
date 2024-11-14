using System;

namespace WordEngineering
{
    ///<summary>UtilityDateTime</summary>
    ///<remarks>Subject: How to set System Date in C# 8/9/2005 2:47 AM PST By: Willy Denoyette [MVP] In: microsoft.public.dotnet.languages.csharp</remarks>
    public class UtilityDateTime
    {
        /// <summary>GetSystemTime</summary>
        [System.Runtime.InteropServices.DllImport("kernel32", SetLastError = true)]
        public static extern bool GetSystemTime( out SYSTEMTIME  systemTime );
  
        /// <summary>SetSystemTime</summary>
        [System.Runtime.InteropServices.DllImport("kernel32", SetLastError = true)]
        public static extern bool SetSystemTime( ref SYSTEMTIME  systemTime );
  
        /// <summary>SYSTEMTIME</summary>
        public struct SYSTEMTIME 
        {
            internal short wYear;
            internal short wMonth;
            internal short wDayOfWeek;
            internal short wDay;
            internal short wHour;
            internal short wMinute;
            internal short wSecond;
            internal short wMilliseconds;
        }
		
		static readonly DateTime CurrentDate = DateTime.Now;

        /// <summary>The entry point for the application.</summary>
        /// <param name="argv">A list of command line arguments</param>
        public static void Main(string[] argv)
        {
			DateTime dateTime = CurrentDate;
			if (argv.Length > 0) {DateTime.TryParse(argv[0], out dateTime);}
			Stub(dateTime);
        }

        /// <summary>Stub()</summary>
        public static void Stub(DateTime dateTime)
        {
			IsDate(dateTime);
			LastDayOfTheNextWeek(dateTime);
			MilitaryTime(dateTime);
        }

        /// <summary>SetDateTime</summary>
        public static void SetDateTime()
        {
            SYSTEMTIME  systemTime;

            if ( GetSystemTime( out systemTime ) )
            {
                systemTime.wHour = 13; //Beware SYSTEMTIME is in UTC time format!!!!!
                if ( !SetSystemTime( ref systemTime ) )
                {
                    System.Console.WriteLine
                    ( 
                        "SetSystemTime failed: {0}", 
                        System.Runtime.InteropServices.Marshal.GetLastWin32Error() 
                    );
                }
            }
            else
            {
                System.Console.WriteLine
                ( 
                    "GetSystemTime failed: {0}", 
                    System.Runtime.InteropServices.Marshal.GetLastWin32Error() 
                );
            }
        }
  
        ///<summary>DateOfTheMonth()</summary>
        ///<remarks>Subject: How to get the last date of the month? 5/13/2005 6:26 PM PST By: William Stacey [MVP] In: microsoft.public.dotnet.languages.csharp</remarks>
        public static void DateOfTheMonth
        (
            ref DateTime  dateTime,
            out DateTime  dateTimeFirstDayOfThisMonth,
            out DateTime  dateTimeFirstDayOfNextMonth,
            out DateTime  dateTimeLastDayOfThisMonth
        )
        {
            dateTimeFirstDayOfThisMonth  =  dateTime.Subtract( TimeSpan.FromDays( dateTime.Day - 1 ) );
            dateTimeFirstDayOfNextMonth  =  dateTimeFirstDayOfThisMonth.AddMonths(1);
            dateTimeLastDayOfThisMonth   =  dateTimeFirstDayOfNextMonth.Subtract( TimeSpan.FromDays(1) );
            System.Console.WriteLine
            (
                "DateTime: {0} | First Day of the Month: {1} | First Day of the Next Month: {2} | Last Day of the Month: {3}",
                dateTime,
                dateTimeFirstDayOfThisMonth,
                dateTimeFirstDayOfNextMonth,
                dateTimeLastDayOfThisMonth
            ); 
        }

        ///<summary>
        /// http://blogs.crsw.com/mark/ Mark Wagner's .NET C# Cogitation
        /// System.Console.WriteLine(IsDate(new DateTime().ToString()));
        ///</summary>
        public static bool IsDate(object obj)
        {
            bool isDate;
			DateTime dateTime;
			isDate = DateTime.TryParse(obj.ToString(), out dateTime);
            System.Console.WriteLine("IsDate: {0}", isDate);
            return (isDate);
        }

		///<summary>
		/// How to find a last day of the next week (or in next two weeks) using 
		///	 VB.NET?
		/// for example:
		/// 01-Feb-2005    =     13-Feb-2005
		/// or
		/// 09-May-2005    =     22-May-2005
		/// Date.Now.AddDays(-Date.Now.DayOfWeek).AddDays(14)
		///</summary>
		public static DateTime LastDayOfTheNextWeek(DateTime startingDateTime)
		{
			DateTime dateTime = startingDateTime.AddDays( 14 - (int) (startingDateTime.DayOfWeek) );
			System.Console.WriteLine("Last day of next week is {0}", dateTime.ToShortDateString());
			return (dateTime);
		}

        ///<summary>LastDayOfMonth()</summary>
        public static DateTime LastDayOfMonth( DateTime presentDayOfTheMonth )
        {
            DateTime firstDayOfTheMonth  =  new DateTime( presentDayOfTheMonth.Year, presentDayOfTheMonth.Month, 1);
            DateTime lastDayOfTheMonth   =  firstDayOfTheMonth.AddMonths(1).AddDays(-1);
            return   ( lastDayOfTheMonth );
        }

        ///<summary>LastDayOfTheMonth()</summary>
        public static DateTime LastDayOfTheMonth( DateTime presentDayOfTheMonth )
        {
            int  month  =  presentDayOfTheMonth.Month;
            int  year   =  presentDayOfTheMonth.Year;
            DateTime lastDayOfTheMonth   =  new DateTime( year, month, DateTime.DaysInMonth( year, month ) );
            return   ( lastDayOfTheMonth );
        }
	 
		///<summary>
		/// Chris Reeder C# Get Military Time by  http://www.stupidprogrammer.com/CommentView,guid,abceb627-805b-4d26-9023-2cf82136c6cf.aspx
		///</summary>
		public static double MilitaryTime(DateTime dateTime)
		{
			double militaryTime = dateTime.TimeOfDay.TotalHours;
			System.Console.WriteLine("Military time: {0}", militaryTime);
			return (militaryTime);
		}
	}	
}	