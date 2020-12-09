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

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

using System.Data.SqlClient;

using System.Text;
using System.Text.RegularExpressions;

using System.Globalization;
using System.Threading;

namespace InformationInTransit.ProcessLogic
{
	///<summary>
	///	2018-02-09 Created.	https://www.codeproject.com/Articles/10287/Get-the-time-in-Israel-including-DST
	///</summary>
	public static class IsraelHelper
	{
		public static void Main(String[] argv)
		{
			System.Console.WriteLine
			(
				"Israel Time: {0}",
				RetrieveIsraelTime()
			);
		}

		// supply a default
		public static DateTime RetrieveIsraelTime() {
			return (RetrieveIsraelTime(DateTime.UtcNow));
		}

		// input: UTC DateTime object
		public static DateTime RetrieveIsraelTime(DateTime d) {
			d = d.AddHours(2);           // Israel is at GMT+2

			// April 2nd, 2:00 AM
			DateTime DSTStart = new DateTime(d.Year, 4, 2, 2, 0 ,0);  
			while (DSTStart.DayOfWeek != DayOfWeek.Friday)
				DSTStart = DSTStart.AddDays(-1);

			CultureInfo jewishCulture = CultureInfo.CreateSpecificCulture("he-IL");
			System.Globalization.HebrewCalendar cal = 
				  new System.Globalization.HebrewCalendar();
			jewishCulture.DateTimeFormat.Calendar = cal;
			// Yom HaKipurim, at the start of the next Jewish year, 2:00 AM
			DateTime DSTFinish =
				 new DateTime(cal.GetYear(DSTStart)+1, 1, 10, 2, 0 ,0, cal);
			while (DSTFinish.DayOfWeek != DayOfWeek.Sunday)
				DSTFinish= DSTFinish.AddDays(-1);

			if (d>DSTStart && d<DSTFinish)
				d = d.AddHours(1);

			return (d);
		}		
	}
}
