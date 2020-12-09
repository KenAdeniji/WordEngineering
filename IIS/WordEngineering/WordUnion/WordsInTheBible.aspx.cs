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
public partial class WordsInTheBible : System.Web.UI.Page
{
	protected String Logic
	{
		get
		{
			string logicSelect = logic.Text.ToLower();
			if (logicSelect == "(all)")
			{
				logicSelect = null;
			}
			return logicSelect;
		}	
	}

	protected String ScriptureReference
	{
		get
		{
			return scriptureReference.Text;
		}	
	}

	protected String Words
	{
		get
		{
			return word.Text;
		}	
	}
	
	protected void GridViewWordsInTheBible_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable dataTable = (DataTable)ViewState["gridViewWordsInTheBible"];
        if (dataTable != null)
        {
            gridViewWordsInTheBible.DataSource = dataTable;
            gridViewWordsInTheBible.Sort(e);
        }
	}

	protected void Page_Load()
	{
		if (!IsPostBack)
		{
			logic.DataSource = LogicArray;
			logic.DataBind();
		}
	}
	
 	protected void Submit_Click(object sender, EventArgs e)
    {
		List<SqlParameter> sqlParameterCollection = new List<SqlParameter>();

		sqlParameterCollection.Add(new SqlParameter("@logic", Logic));
		sqlParameterCollection.Add(new SqlParameter("@word", Words));
		sqlParameterCollection.Add(new SqlParameter("@wordsInTheBibleScriptureReference", ScriptureReference));

		DataTable dataTable = (DataTable) Repository.DatabaseCommand
		(
			"WordEngineering..usp_WordsInTheBibleSelect",
			CommandType.StoredProcedure,
			Repository.ResultSet.DataTable,
			sqlParameterCollection
		);
		
		ViewState["gridViewWordsInTheBible"] = dataTable;
		gridViewWordsInTheBible.DataSource = dataTable;
		gridViewWordsInTheBible.DataBind();
    }
	
	public static readonly String[] LogicArray = {
		"(All)",
		"And",
		"Or",
		"Phrase"
	};
}
