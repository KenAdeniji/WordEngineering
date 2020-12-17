#region Using directives
using System;
#endregion

namespace InformationInTransit.ProcessLogic
{
    public static partial class TimeZoneInfoHelper
    {
		public static void Main(string[] argv)
		{
			Display();
		}
		
		/// <remarks> 
		/// 	http://blog.csharphelper.com/2013/11/03/list-timezones-in-c.aspx
		/// </remarks>
		public static void Display()
		{
			foreach (TimeZoneInfo info in TimeZoneInfo.GetSystemTimeZones())
			{
				System.Console.WriteLine(info);
			}
		}
    }
}
