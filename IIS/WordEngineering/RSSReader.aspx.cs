#region Using directives
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
#endregion

#region RSSReader definition
public partial class RSSReader : System.Web.UI.Page
{
    #region Methods
    protected override void OnInit(EventArgs e)
    {
        XDocument feedXML = XDocument.Load(Server.MapPath("~/App_Data/RSSFeed.xml"));

        var feeds = from feed in feedXML.Descendants("Feed")
                    where feed.Attribute("status") == null || feed.Attribute("status").Value != "disabled"
                    select new
                    {
                        Name = feed.Element("Name").Value,
                        Url = feed.Element("Url").Value
                    };

        FeedList.DataSource = feeds;
        FeedList.DataBind();
    }

    protected void ReadBtn_Click(object sender, EventArgs e)
    {
        XNamespace slashNamespace = "http://purl.org/rss/1.0/modules/slash/";

        XDocument rssFeed = XDocument.Load(FeedList.SelectedValue);

        var posts = from item in rssFeed.Descendants("item")
                    select new
                    {
                        Title = item.Element("title").Value,
                        Published = DateTime.Parse(item.Element("pubDate").Value),
                        NumComments = Convert.ToInt32(item.Element(slashNamespace + "comments").Value),
                        Url = item.Element("link").Value,
                        Tags = (from category in item.Elements("category")
                                orderby category.Value
                                select category.Value).ToList()
                    };

        ListView1.DataSource = posts;
        ListView1.DataBind();
    }
    #endregion
}
#endregion
