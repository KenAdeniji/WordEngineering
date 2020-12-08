using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using InformationInTransit.ProcessLogic;

public partial class WebServiceRequester_Delicious : System.Web.UI.Page
{
    public const string DeliciousAnchor = "<a href={0} target=_blank>{1}</a><br/>";
    protected override void OnLoad(EventArgs e)
    {
        string password = ConfigurationManager.AppSettings["Password"];
        string userName = ConfigurationManager.AppSettings["UserName"];
        Collection<DeliciousHelper.Post> posts = DeliciousHelper.Bookmark(userName, password);
        string deliciousAnchor = "";
        foreach (DeliciousHelper.Post post in posts)
        {
            deliciousAnchor = String.Format(DeliciousAnchor, post.Href, post.Description);
            Response.Write(deliciousAnchor);
        }
    }
}
