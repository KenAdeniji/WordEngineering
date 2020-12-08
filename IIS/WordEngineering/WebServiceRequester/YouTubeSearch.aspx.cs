#region Using directives
using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
#endregion

#region YouTubeSearch definition
public partial class YouTubeSearch : System.Web.UI.Page
{
    #region Methods
    protected void Search_Click(object sender, EventArgs e)
    {
        string developerID = ConfigurationManager.AppSettings["YouTubeDeveloperID"];
        string uri = "http://www.youtube.com/api2_rest?";
        uri += "method=youtube.videos.list_by_tag";
        uri += "&dev_id=" + developerID;
        uri += "&tag=" + tag.Text;
        uri += "&page=1&per_page=50";
        DataSet dataSet = new DataSet();
        dataSet.ReadXml(uri);
        gridViewVideo.DataSource = dataSet.Tables[2];
        gridViewVideo.DataBind();
    }
    #endregion
}
#endregion
