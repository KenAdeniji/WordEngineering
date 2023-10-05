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

using InformationInTransit.ProcessLogic;
#endregion

public partial class TechnoratiAPI : System.Web.UI.Page
{
    protected override void OnLoad(EventArgs e)
    {
        if (!Page.IsPostBack) 
        {
            technoratiQuery.DataSource = TechnoratiApi.AvailableAPIQueries();
            technoratiQuery.DataBind(); 
        }
    }

    protected void QuerySubmit_Click(Object sender, EventArgs e)
    {
        string apiKey = ConfigurationManager.AppSettings["TechnoratiAPIKey"];
        TechnoratiApi technoratiApi = new TechnoratiApi
        {
            Key = apiKey,
            Keyword = keyword.Text,
            Operation = (TechnoratiApi.APIQuery) Enum.Parse
                (
                    typeof(TechnoratiApi.APIQuery), technoratiQuery.SelectedValue, true
                ),
            Url = url.Text,
            Username = username.Text
        };
        
        //requestUri.Text = technoratiApi.RequestUri;
        resultSet.Text = TechnoratiApi.RequestData(technoratiApi);
    }
}
