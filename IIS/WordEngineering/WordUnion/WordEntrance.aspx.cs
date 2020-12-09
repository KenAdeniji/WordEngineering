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

public partial class WordEntrance : System.Web.UI.Page
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

	protected void WordEntranceGridView_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable dataTable = (DataTable)ViewState["wordEntranceGridView"];
        if (dataTable != null)
        {
            wordEntranceGridView.DataSource = dataTable;
            wordEntranceGridView.Sort(e);
        }
    }

 	protected void Submit_Click(object sender, EventArgs e)
    {
		List<SqlParameter> sqlParameterCollection = new List<SqlParameter>();

		sqlParameterCollection.Add(new SqlParameter("@word", word.Text.Trim()));

		DateTime dated = DateTime.Now;

		bool isDateTime = DateTime.TryParse(firstOccurrenceFrom.Text, out dated);
		if (isDateTime)
		{
			sqlParameterCollection.Add(new SqlParameter("@firstOccurrenceFrom", dated));
		}

		isDateTime = DateTime.TryParse(firstOccurrenceUntil.Text, out dated);
		if (isDateTime)
		{
			sqlParameterCollection.Add(new SqlParameter("@firstOccurrenceUntil", dated));
		}

		isDateTime = DateTime.TryParse(lastOccurrenceFrom.Text, out dated);
		if (isDateTime)
		{
			sqlParameterCollection.Add(new SqlParameter("@lastOccurrenceFrom", dated));
		}

		isDateTime = DateTime.TryParse(lastOccurrenceUntil.Text, out dated);
		if (isDateTime)
		{
			sqlParameterCollection.Add(new SqlParameter("@lastOccurrenceUntil", dated));
		}

		sqlParameterCollection.Add(new SqlParameter("@frequencyOfOccurrenceFrom", FrequencyOfOccurrenceFrom));
		sqlParameterCollection.Add(new SqlParameter("@frequencyOfOccurrenceUntil", FrequencyOfOccurrenceUntil));
		
		int sequenceOrderId = 0;
		bool isNumeric = Int32.TryParse(sequenceOrderIdFrom.Text, out sequenceOrderId);
		if (isNumeric)
		{
			sqlParameterCollection.Add(new SqlParameter("@sequenceOrderIdFrom", sequenceOrderId));
		}

		sequenceOrderId = 0;
		isNumeric = Int32.TryParse(sequenceOrderIdUntil.Text, out sequenceOrderId);
		if (isNumeric)
		{
			sqlParameterCollection.Add(new SqlParameter("@sequenceOrderIdUntil", sequenceOrderId));
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
			"Generative..usp_WordEntranceSelect",
			CommandType.StoredProcedure,
			Repository.ResultSet.DataTable,
			sqlParameterCollection
		);
		
		ViewState["wordEntranceGridView"] = dataTable;
		wordEntranceGridView.DataSource = dataTable;
		wordEntranceGridView.DataBind();
    }
}
