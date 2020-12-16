using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace InformationInTransit.ProcessLogic
{
	public static partial class HtmlGenericControlHelper
	{
		///<remarks>
		///http://extensionmethod.net/csharp/page/addcss
		///</remarks>
		///<example>
		///public partial class Default : System.Web.UI.Page
		///{
		///	protected void Page_Load(object sender, EventArgs e)
		///	{
		///		this.AddCSS("cssFile.css");
		///	}
		///}
		///<example>
		public static void AddCSS(this Page page, string url)
		{
			HtmlLink link = new HtmlLink();
			link.Href = url;
			link.Attributes["rel"] = "stylesheet";
			link.Attributes["type"] = "text/css";
			page.Header.Controls.Add(link);
		}

		///<remarks>
		///http://extensionmethod.net/csharp/page/addjavascript
		///</remarks>
		///<example>
		///public partial class Default : System.Web.UI.Page
		///{
		///	protected void Page_Load(object sender, EventArgs e)
		///	{
		///		this.AddJavaScript("jsFile.js");
		///	}
		///}
		public static void AddJavaScript(this Page page, string url)
		{
			HtmlGenericControl js = new HtmlGenericControl("script");
			js.Attributes["type"] = "text/javascript";
			js.Attributes["src"] = url;
			page.Header.Controls.Add(js);
		}
	}
}
