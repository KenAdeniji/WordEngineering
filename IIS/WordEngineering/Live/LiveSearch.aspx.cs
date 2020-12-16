#region Using directives
using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using System.Globalization;
using com.msn.search.soap;
#endregion

#region LiveSearch definition
/// <summary>
/// Web reference: http://soap.search.msn.com/webservices.asmx?wsdl
/// </summary>
public partial class LiveSearch : System.Web.UI.Page
{
    #region Properties
    protected string LiveSearchAppId
    {
        get { return (string)ViewState["LiveSearchAppId"]; }
        set { ViewState["LiveSearchAppId"] = value; }
    }

    protected string Question
    {
        get { return question.Text.Trim(); }
    }

    protected int SearchResultsPagePage
    {
        get { return (int)ViewState["SearchResultsPagePage"]; }
        set { ViewState["SearchResultsPagePage"] = value; }
    }
    #endregion

    #region Methods
    protected SourceRequest DefineSourceRequest
    (
        SourceType sourceType,
        ResultFieldMask resultFieldMask,
        int count
    )
    {
        SourceRequest sourceRequest = new SourceRequest();
        sourceRequest.Source = SourceType.Web;
        sourceRequest.ResultFields = resultFieldMask;
        sourceRequest.Count = count;
        return sourceRequest;
    }

    protected override void OnLoad(EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LiveSearchAppId = ConfigurationManager.AppSettings["LiveSearchAppId"];
            SearchResultsPagePage = System.Convert.ToInt32
            (
                ConfigurationManager.AppSettings["SearchResultsPagePage"],
                CultureInfo.InvariantCulture
            );
        }
    }

    protected void Search_Click(Object sender, EventArgs e)
    {
        MSNSearchService searchService = new MSNSearchService();
        SearchRequest searchRequest = new SearchRequest();
        searchRequest.AppID = LiveSearchAppId;
        searchRequest.Query = Question;
        //searchRequest.Flags = SearchFlags.MarkQueryWords;
        searchRequest.CultureInfo = CultureInfo.CurrentUICulture.ToString();

        SourceRequest[] sourceRequests = new SourceRequest[2];
        searchRequest.Requests = sourceRequests;

        sourceRequests[0] = DefineSourceRequest
        (
            SourceType.Web,
            ResultFieldMask.All | ResultFieldMask.SearchTagsArray,
            SearchResultsPagePage
        );

        sourceRequests[1] = DefineSourceRequest
        (
            SourceType.Spelling,
            ResultFieldMask.Title,
            3
        );

        SearchResponse searchResponse = searchService.Search(searchRequest);

        results.DataSource = searchResponse.Responses[0].Results;
        suggestions.DataSource = searchResponse.Responses[1].Results;
        Page.DataBind();

    }
    #endregion
}
#endregion
