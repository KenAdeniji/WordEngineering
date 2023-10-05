using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using InformationInTransit.ProcessLogic;

namespace WordEngineering.Network
{
    public partial class WhoIsDomain : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                whoIsServer.Text = "whois.internic.net";
                whoIsPort.Text = "43";
				whoIsDomain.Text = "Oracle.com";
				Retrieve();
            }
        }

        protected void QuerySubmit_Click(object sender, System.EventArgs e)
        {
			Retrieve();
        }
		
        ///<remarks>
		/// 2015-06-14	http://stackoverflow.com/questions/8262489/replaceenvironment-newline-br-is-not-working-as-expected-when-displaying
		///</remarks>
		protected void Retrieve()
        {
			string info =	WhoIsHelper.WhoIs
                            (
                                whoIsServer.Text,
                                Convert.ToInt32(whoIsPort.Text),
                                whoIsDomain.Text
                            );
			info = info.Replace("\n", "<br>");
			feedback.Text = info;					
        }
	}
}
