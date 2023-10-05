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

/*
	2014-09-08 Created. http://msdn.microsoft.com/en-us/library/ms142497.aspx
	2014-09-09 Changed from FreeText to Contains where clause. Use gridview instead of table. CSS.
*/
public partial class FreeTextSearchPage : System.Web.UI.Page
{
	protected string AndOrPhrase
	{
		get { return andOrPhrase.Value.Trim(); }
		set { andOrPhrase.Value = value; }
	}
	
	protected string Question
	{
		get { return question.Text.Trim(); }
		set { question.Text = value; }
	}
	
    protected void Submit_Click(object sender, EventArgs e)
    {
		String[] keywords = null;

		StringBuilder searchCondition = PrepareSearchCondition(out keywords);
		
		DataSet result = ProcessSearchCondition(searchCondition);
		resultSet.DataSource = result;
		resultSet.DataBind();
	}
	
	protected StringBuilder PrepareSearchCondition(out string[] keywords)
    {
		if (AndOrPhrase == "phrase")
		{
			keywords = new String[] { Question };
		}
		else
		{
			keywords = Question.Split(' ');
		}	
		StringBuilder searchCondition = new StringBuilder();
		
		for(int index = 0, count = keywords.Length; index < count; ++index)
		{
			keywords[index] = keywords[index].Trim();
			if (index > 0)
			{
				searchCondition.Append(' ' + AndOrPhrase + ' ');
			}
			searchCondition.AppendFormat(WordQueryFormat, keywords[index]);
		}
		return searchCondition;
	}

	public static DataSet ProcessSearchCondition(StringBuilder searchCondition)
	{
		List<SqlParameter> sqlParameterCollection = new List<SqlParameter>();
		sqlParameterCollection.Add(new SqlParameter("@searchCondition", searchCondition.ToString()));

		DataSet dataSet = (DataSet) Repository.DatabaseCommand
		(
			"Bible..usp_FreeTextSearch",
			CommandType.StoredProcedure,
			Repository.ResultSet.DataSet,
			sqlParameterCollection
		);
		return dataSet;
	}
	
	public const string WordQueryFormat = "''{0}''";
}
