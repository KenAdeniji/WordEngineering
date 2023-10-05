using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using InformationInTransit.ProcessLogic;

namespace WordEngineering.Network
{
	///<remarks>
	/// 2015-09-01	http://www.codeproject.com/Articles/105805/Web-Server-Information-using-NET
	///</remarks>
    public partial class ResponseHeaders : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
				uri.Text = "http://www.microsoft.com";
				Inspect();
            }
        }

        protected void QuerySubmit_Click(object sender, System.EventArgs e)
        {
			Inspect();
        }
		
		protected void Inspect()
        {
			string info =	"";
			
			WebClient wc = new WebClient();
			wc.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)"); 
			wc.OpenRead(uri.Text); 
			
			StringBuilder sb = new StringBuilder();
			sb = new StringBuilder();
			for (int i = 0; i < wc.ResponseHeaders.Count; i++)
			{
				 sb.Append("[" + wc.ResponseHeaders.AllKeys[i] + "] = " 
				 + wc.ResponseHeaders[i] + Environment.NewLine);
			}
			feedback.Text = sb.ToString();	
        }
	}
}
