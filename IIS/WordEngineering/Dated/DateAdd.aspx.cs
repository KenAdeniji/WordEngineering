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

/*
	2026-11-25 Changed the label. From ... Dated.
	2026-11-25T06:03:00	
		I understand that there is an ongoing basketball game. I cannot determine if the game is home or away. I heard and I repeated, but I do not recall the name of the away team, and I associated the team name with a team of older players. When I returned to the site from the south 2026-11-25T07:03:00 during an intermission I could see a player lying, resting, on the ground, floor, vertically. I do not know if this is sighting is physical, real life, or the image is electronically on the screen and virtual.
		2 Corinthians 12:2, Genesis 31:41
*/
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
