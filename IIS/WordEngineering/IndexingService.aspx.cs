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

#region IndexingService definition
/// <summary>
/// To administer the Indexing Service use compmgmt.msc.
/// </summary>
public partial class IndexingService : System.Web.UI.Page
{
    #region Methods
    protected override void OnLoad(EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (!String.IsNullOrEmpty(Request.QueryString["q"]))
            {
                Q = Request.QueryString["q"];
                Search();
            }
        }
    }

    public void Search_Click(object sender, System.EventArgs e)
    {
        Search();
    }

    public void Search()
    {
        // Catalog Name
        string strCatalog = "TheWord";
        string strQuery;

        strQuery = "Select DocTitle,Filename,Size,PATH,URL from Scope()  where FREETEXT('" + Q + "')";
        // q.Text is the word that you type in the text box to query by using Indexing Service.

        string connstring = "Provider=MSIDXS.1;Integrated Security .='';Data Source=" + strCatalog;

        System.Data.OleDb.OleDbConnection conn = new System.Data.OleDb.OleDbConnection(connstring);
        conn.Open();

        System.Data.OleDb.OleDbDataAdapter cmd = new System.Data.OleDb.OleDbDataAdapter(strQuery, conn);

        System.Data.DataSet dataSet = new System.Data.DataSet();

        cmd.Fill(dataSet, "SearchResults");

        resultSet.DataSource = dataSet;
        resultSet.DataBind();
    }
    #endregion

    #region Properties
    protected string Q
    {
        get { return q.Text.Trim(); }
        set { q.Text = value.Trim(); }
    }
    #endregion
}
#endregion