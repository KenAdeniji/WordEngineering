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

using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;

public partial class WebServiceRequester_Twitter : System.Web.UI.Page
{
    protected override void OnLoad(EventArgs e)
    {
        if (!Page.IsPostBack) 
        {
            Page.Form.DefaultFocus = userName.ClientID;
            Page.Form.DefaultButton = search.UniqueID;
        }
    }
 
    protected void Search_Click(object sender, EventArgs e)
    {
        TwitterClient client = new TwitterClient();
        try
        {
            Tweets tweets = client.GetTweets(userName.Text);
            resultSet.DataSource = tweets;
            resultSet.DataBind();
            exceptionMessage.Text = null;
        }
        catch (Exception ex)
        {
            resultSet.DataSource = null;
            resultSet.DataBind();
            exceptionMessage.Text = ex.Message;
        }
    }
}

[ServiceContract]
interface ITwitter
{
    [OperationContract]
    [WebInvoke(
      UriTemplate = "/statuses/user_timeline.xml?screen_name={username}",
      Method = "GET")]
    Tweets GetTweets(string username);
}

[DataContract(Name = "status", Namespace = "")]
public class Tweet
{
    [DataMember(Name = "id")]
    public string Id { get; set; }

    [DataMember(Name = "text")]
    public string Text { get; set; }

    [DataMember(Name = "created_at")]
    public string Date { get; set; }

    [DataMember(Name = "user")]
    public User User { get; set; }
}

[CollectionDataContract(Name = "statuses", Namespace = "")]
public class Tweets : List<Tweet>
{

}

[DataContract(Name = "user", Namespace = "")]
public class User
{
    [DataMember(Name = "name")]
    public string Name { get; set; }

    [DataMember(Name = "screen_name")]
    public string ScreenName { get; set; }
}

class TwitterClient : ClientBase<ITwitter>, ITwitter
{
    public Tweets GetTweets(string username)
    {
        return this.Channel.GetTweets(username);
    }
}
