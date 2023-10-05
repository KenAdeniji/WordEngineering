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
using System.Data.SqlClient;
using System.Text;

using InformationInTransit.DataAccess;
using InformationInTransit.ProcessLogic;

public partial class GnuVersionOfTheCollaborativeInternationalDictionaryOfEnglishPage : System.Web.UI.Page
{
	protected string Question
	{
		get { return question.Text.Trim(); }
		set { question.Text = value; }
	}
	
	protected string Commentary
	{
		get { return commentary.Text.Trim(); }
		set { commentary.Text = value; }
	}

	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack)
		{
			string question = Request.QueryString["Question"];
			if (String.IsNullOrEmpty(question)) { return; }
			FindWord(question);
		}	
	}
	
    protected void Submit_Click(object sender, EventArgs e)
    {
		FindWord(Question);
	}
	
	public static StringBuilder BuildResult
	(
		DataTable dataTable
	)
	{
		StringBuilder sb = new StringBuilder();
		int subsetIndex = 0;
		string def = null;
		foreach(DataRow dataRow in dataTable.Rows)
		{
			def = (string) dataRow["def"];
			sb.Append(def + "<br />");
		}
		return sb;
	}

	public StringBuilder BuildResultSoundex
	(
		DataTable dataTable
	)
	{
		StringBuilder sb = new StringBuilder();
		string hw = null;
		string uri = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
		string uriQueryString = null;

		foreach(DataRow dataRow in dataTable.Rows)
		{
			hw = (string) dataRow["hw"];
			uriQueryString = String.Format(LinkSoundexFormat, uri, hw);
			sb.Append(uriQueryString + "<br />");
		}
		return sb;
	}

    protected void FindWord(string hw)
    {
		DataTable dataTable = ProcessSqlStatement(hw);
		StringBuilder sb = null;
		
		if (dataTable != null && dataTable.Rows.Count > 0)
		{
			sb = BuildResult(dataTable);
			Commentary = sb.ToString();
			return;
		}
		dataTable = ProcessSqlStatementSoundex();
		sb = BuildResultSoundex(dataTable);
		Commentary = sb.ToString();
	}
	
	public DataTable ProcessSqlStatement(string hw)
	{
		string sql = String.Format( DictionaryQueryFormat, hw );
		DataTable dataTable = null;
		dataTable = (DataTable)Repository.DatabaseCommand
		(
			sql,
			CommandType.Text,
			Repository.ResultSet.DataTable
		);
		return dataTable;
	}
	
	public DataTable ProcessSqlStatementSoundex()
	{
		string sql = String.Format( DictionaryQuerySoundexFormat, Question );
		Commentary = sql;
		DataTable dataTable = null;
		dataTable = (DataTable)Repository.DatabaseCommand
		(
			sql,
			CommandType.Text,
			Repository.ResultSet.DataTable
		);
		return dataTable;
	}

	public const string DictionaryQueryFormat = "SELECT * FROM Dictionary..GnuVersionOfTheCollaborativeInternationalDictionaryOfEnglish WHERE hw = '{0}'";
	//public const string DictionaryQuerySoundexFormat = "SELECT DISTINCT TOP 10 DIFFERENCE(hw, '{0}') AS Defeat, hw FROM Dictionary..GnuVersionOfTheCollaborativeInternationalDictionaryOfEnglish ORDER BY 1 DESC";
	public const string DictionaryQuerySoundexFormat = "SELECT DISTINCT TOP 200 hw FROM Dictionary..GnuVersionOfTheCollaborativeInternationalDictionaryOfEnglish WHERE SOUNDEX(hw) = SOUNDEX('{0}')";
	public const string LinkSoundexFormat = "<a href={0}?Question={1}>{1}</a>";  
}
