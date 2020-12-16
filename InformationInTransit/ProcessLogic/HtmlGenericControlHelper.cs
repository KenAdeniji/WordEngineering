using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace WordEngineering
{
	public static partial class HtmlGenericControlHelper
	{
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
