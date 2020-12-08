using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;

using InformationInTransit.DataAccess;
using InformationInTransit.UserInterface;

/*
2015-04-09 File created.
*/
public partial class WordsInParentheses : System.Web.UI.Page
{
	protected void GridViewWordsInParentheses_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable dataTable = (DataTable)ViewState["gridViewWordsInParentheses"];
        if (dataTable != null)
        {
            gridViewWordsInParentheses.DataSource = dataTable;
            gridViewWordsInParentheses.Sort(e);
        }
	}

 	protected void Page_Load()
    {
		DataTable dataTable = (DataTable) Repository.DatabaseCommand
		(
			"SELECT ScriptureReference, KingJamesVersion FROM Bible..Scripture_View WHERE KingJamesVersion LIKE '%(%' OR KingJamesVersion LIKE '%)%' ORDER BY bookId, chapterId, verseId",
			CommandType.Text,
			Repository.ResultSet.DataTable
		);
		
		ViewState["gridViewWordsInParentheses"] = dataTable;
		gridViewWordsInParentheses.DataSource = dataTable;
		gridViewWordsInParentheses.DataBind();
    }
}

