using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

/*
	2017-11-01	Created.
*/
namespace InformationInTransit.ProcessLogic 
{
	public static partial class DateAddHelper
	{
		public static void Main(string[] argv)
		{
			DateTime from;
			Int64 count;
			DateTime to;
			DateTime.TryParse(argv[0], out from);
			Int64.TryParse(argv[1], out count);

			to = from.AddDays(count);
			System.Console.WriteLine("{0:s}", to);
		}
	}
}
