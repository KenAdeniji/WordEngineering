using System;
using System.Web;
using System.IO;
using System.Web.UI.WebControls;

using DotNetOpenAuth.OpenId;
using DotNetOpenAuth.OpenId.RelyingParty;

/// <summary>
/// This is the default aspx.cs page for the sample Web Auth site.
/// It gets the application ID and user ID for display on the main
/// page.  
/// </summary>
public partial class GoogleOpenID : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		OpenIdRelyingParty rp = new OpenIdRelyingParty();
		var response = rp.GetResponse();
		if (response != null)
		{
			switch (response.Status)
			{
				case AuthenticationStatus.Authenticated:
					Session["GoogleIdentifier"] = response.ClaimedIdentifier.ToString();
					Response.Redirect("~/Default.aspx");
					break;
				case AuthenticationStatus.Canceled:
					Session["GoogleIdentifier"] = "Cancelled.";
					break;
				case AuthenticationStatus.Failed:
					Session["GoogleIdentifier"] = "Login Failed.";
					break;
			}
		}
	}

	protected void GoogleLogin_Click(object sender, CommandEventArgs e)
	{
		string discoveryUri = e.CommandArgument.ToString();
		OpenIdRelyingParty openid = new OpenIdRelyingParty();
		var URIbuilder = new UriBuilder(Request.Url) { Query = "" };
		var req = openid.CreateRequest(discoveryUri, URIbuilder.Uri, URIbuilder.Uri);
		req.RedirectToProvider();
	}
	
	protected void GoogleLogout_Click(object sender, EventArgs e)
	{
		Response.Redirect("http://accounts.google.com/logout");
	}
}
