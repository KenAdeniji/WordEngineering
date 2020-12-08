using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WordEngineering
{
    ///<remarks>
	///http://msdn.microsoft.com/en-us/library/ms178194.aspx
	///</remarks>
	public partial class CookiesPage : System.Web.UI.Page
    {
		public String FeedBack
		{
			get{ return feedBack.Text.Trim(); }
			set{ feedBack.Text = value; }
		}
		
		protected void Page_Load(object sender, EventArgs e)
        {
			Response.Cookies["userName"].Value = "patrick";
			Response.Cookies["userName"].Expires = DateTime.Now.AddDays(1);

			HttpCookie aCookie = new HttpCookie("lastVisit");
			aCookie.Value = DateTime.Now.ToString();
			aCookie.Expires = DateTime.Now.AddDays(1);
			Response.Cookies.Add(aCookie);

			Response.Cookies["userInfo"]["userName"] = "patrick";
			Response.Cookies["userInfo"]["lastVisit"] = DateTime.Now.ToString();
			Response.Cookies["userInfo"].Expires = DateTime.Now.AddDays(1);

			HttpCookie userInfoCookie = new HttpCookie("userInfo");
			userInfoCookie.Values["userName"] = "patrick";
			userInfoCookie.Values["lastVisit"] = DateTime.Now.ToString();
			userInfoCookie.Expires = DateTime.Now.AddDays(1);
			Response.Cookies.Add(userInfoCookie);
			
			HttpCookie appCookie = new HttpCookie("AppCookie");
			appCookie.Value = "written " + DateTime.Now.ToString();
			appCookie.Expires = DateTime.Now.AddDays(1);
			appCookie.Path = "/WordEngineering";
			Response.Cookies.Add(appCookie);
			
			Response.Cookies["domain"].Value = DateTime.Now.ToString();
			Response.Cookies["domain"].Expires = DateTime.Now.AddDays(1);
			Response.Cookies["domain"].Domain = "e-comfort.ephraimtech.com";
			
			string feedBackInfo = null;
			DateTime? lastVisit = null;
			string userName = null;
			
			if(Request.Cookies["userName"] != null)
			{
				userName = Server.HtmlEncode(Request.Cookies["userName"].Value);
			}
			
			lastVisit = DateTime.Parse(Request.Cookies["userInfo"]["lastVisit"]);

			FeedBack = String.Format
			(
				FeedBackFormat,
				userName,
				lastVisit
			);
		}
        
        public const string FeedBackFormat = 
			@"UserName: {0}<br/>LastVisit: {1}<br/>"; 
    }
}
