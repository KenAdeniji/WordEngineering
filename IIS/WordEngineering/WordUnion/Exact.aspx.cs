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

public partial class Exact : System.Web.UI.Page
{
	protected Int32? FrequencyOfOccurrenceFrom
	{
		get
		{
			Int32 temp = -1;
			bool isNumber = Int32.TryParse( frequencyOfOccurrenceFrom.Text, out temp);
			if (isNumber)
			{
				return temp;
			}
			else
			{
				return null;
			}	
		}	
	}

	protected Int32? FrequencyOfOccurrenceUntil
	{
		get
		{
			Int32 temp = -1;
			bool isNumber = Int32.TryParse( frequencyOfOccurrenceUntil.Text, out temp);
			if (isNumber)
			{
				return temp;
			}
			else
			{
				return null;
			}	
		}	
	}

	protected void ExactGridView_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable dataTable = (DataTable)ViewState["exactGridView"];
        if (dataTable != null)
        {
            exactGridView.DataSource = dataTable;
            exactGridView.Sort(e);
        }
    }

 	protected void Submit_Click(object sender, EventArgs e)
    {
		List<SqlParameter> sqlParameterCollection = new List<SqlParameter>();

		sqlParameterCollection.Add(new SqlParameter("@bibleWord", word.Text.Trim()));
		sqlParameterCollection.Add(new SqlParameter("@firstOccurrenceScriptureReference", firstOccurrenceScriptureReference.Text.Trim()));
		sqlParameterCollection.Add(new SqlParameter("@lastOccurrenceScriptureReference", lastOccurrenceScriptureReference.Text.Trim()));
		sqlParameterCollection.Add(new SqlParameter("@frequencyOfOccurrenceFrom", FrequencyOfOccurrenceFrom));
		sqlParameterCollection.Add(new SqlParameter("@frequencyOfOccurrenceUntil", FrequencyOfOccurrenceUntil));
		
		int exactID = 0;
		bool isNumeric = Int32.TryParse(exactIDFrom.Text, out exactID);
		if (isNumeric)
		{
			sqlParameterCollection.Add(new SqlParameter("@exactIDFrom", exactID));
		}

		exactID = 0;
		isNumeric = Int32.TryParse(exactIDUntil.Text, out exactID);
		if (isNumeric)
		{
			sqlParameterCollection.Add(new SqlParameter("@exactIDUntil", exactID));
		}

		int alphabetSequenceIndex = 0;
		isNumeric = Int32.TryParse(alphabetSequenceIndexFrom.Text, out alphabetSequenceIndex);
		if (isNumeric)
		{
			sqlParameterCollection.Add(new SqlParameter("@alphabetSequenceIndexFrom", alphabetSequenceIndex));
		}

		alphabetSequenceIndex = 0;
		isNumeric = Int32.TryParse(alphabetSequenceIndexUntil.Text, out alphabetSequenceIndex);
		if (isNumeric)
		{
			sqlParameterCollection.Add(new SqlParameter("@alphabetSequenceIndexUntil", alphabetSequenceIndex));
		}
		
		DataTable dataTable = (DataTable) Repository.DatabaseCommand
		(
			"Bible..usp_ExactSelect",
			CommandType.StoredProcedure,
			Repository.ResultSet.DataTable,
			sqlParameterCollection
		);
		
		ViewState["exactGridView"] = dataTable;
		exactGridView.DataSource = dataTable;
		exactGridView.DataBind();
    }
}
