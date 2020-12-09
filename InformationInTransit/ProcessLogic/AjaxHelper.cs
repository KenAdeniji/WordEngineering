#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
#endregion

namespace InformationInTransit.ProcessLogic
{
    public static partial class AjaxHelper
    {
        public static void Main(string[] argv)
        {
        }

        /*
			2017-12-15	http://www.devx.com/tips/dot-net/check-if-a-httprequest-is-an-ajax-request-170117062005.html
		*/
		public static bool IsAjaxRequest()
        {
			//bool isAjaxRequest = request.Headers["X-Requested-With"] != null && request.Headers["X-Requested-With"] == "XMLHttpRequest";
			bool isAjaxRequest = HttpContext.Current.Request.Headers["X-Requested-With"] != null &&
				HttpContext.Current.Request.Headers["X-Requested-With"] == "XMLHttpRequest";
			return	isAjaxRequest;
        }
    }
}
