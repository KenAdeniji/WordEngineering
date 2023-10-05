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

using System.Text;
namespace WordEngineering
{
	public partial class DateAdd : System.Web.UI.Page
	{
		protected void Submit_Click(object sender, EventArgs e)
		{
			DateTime from;
			Int64 count;
			DateTime to;
			DateTime.TryParse(datedFrom.Text, out from);
			Int64.TryParse(number.Text, out count);

			to = from.AddDays(count);
			datedTo.Text = to.ToString("s");
		}
	}
}
