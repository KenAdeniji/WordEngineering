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

public partial class MeetMyEndThrough : System.Web.UI.Page
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

	protected void MeetMyEndThroughGridView_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable dataTable = (DataTable)ViewState["meetMyEndThroughGridView"];
        if (dataTable != null)
        {
            meetMyEndThroughGridView.DataSource = dataTable;
            meetMyEndThroughGridView.Sort(e);
        }
    }

 	protected void Submit_Click(object sender, EventArgs e)
    {
		List<SqlParameter> sqlParameterCollection = new List<SqlParameter>();

		sqlParameterCollection.Add(new SqlParameter("@bibleWord", word.Text.Trim()));
		sqlParameterCollection.Add(new SqlParameter("@firstOccurrence", firstOccurrence.Text.Trim()));
		sqlParameterCollection.Add(new SqlParameter("@lastOccurrence", lastOccurrence.Text.Trim()));
		sqlParameterCollection.Add(new SqlParameter("@frequencyOfOccurrenceFrom", FrequencyOfOccurrenceFrom));
		sqlParameterCollection.Add(new SqlParameter("@frequencyOfOccurrenceUntil", FrequencyOfOccurrenceUntil));
		
		int number = 0;
		bool isNumeric = Int32.TryParse(numberFrom.Text, out number);
		if (isNumeric)
		{
			sqlParameterCollection.Add(new SqlParameter("@numberFrom", number));
		}

		number = 0;
		isNumeric = Int32.TryParse(numberUntil.Text, out number);
		if (isNumeric)
		{
			sqlParameterCollection.Add(new SqlParameter("@numberUntil", number));
		}

		int meetMyEndThroughID = 0;
		isNumeric = Int32.TryParse(meetMyEndThroughIDFrom.Text, out meetMyEndThroughID);
		if (isNumeric)
		{
			sqlParameterCollection.Add(new SqlParameter("@meetMyEndThroughIDFrom", meetMyEndThroughID));
		}

		meetMyEndThroughID = 0;
		isNumeric = Int32.TryParse(meetMyEndThroughIDUntil.Text, out meetMyEndThroughID);
		if (isNumeric)
		{
			sqlParameterCollection.Add(new SqlParameter("@meetMyEndThroughIDUntil", meetMyEndThroughID));
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
			"Bible..usp_MeetMyEndThroughSelect",
			CommandType.StoredProcedure,
			Repository.ResultSet.DataTable,
			sqlParameterCollection
		);
		
		ViewState["meetMyEndThroughGridView"] = dataTable;
		meetMyEndThroughGridView.DataSource = dataTable;
		meetMyEndThroughGridView.DataBind();
    }
}
