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
using System.Collections.ObjectModel;
using System.Collections.Specialized;

using System.Data.SqlClient;

using InformationInTransit.DataAccess;
using InformationInTransit.ProcessCode;
using InformationInTransit.ProcessLogic;

namespace InformationInTransit.ProcessCode
{
	/*
		2023-07-30T12:34:00 Created.
		Se o le lo Linq with RegEx?
		Can you use Linq with RegEx?
		Shower: 1st sprinkling
		2023-07-30T12:52:00	http://stackoverflow.com/questions/848415/dynamic-where-clause-in-linq/848435#848435
		2023-07-30T13:07:00 
			google.com
			c# dynamic linq query where clause "datatable" regex match site:microsoft.com
			About 59 results (0.21 seconds)
		2023-07-30T13:16:00 http://stackoverflow.com/questions/31006230/dynamically-build-a-condition-on-a-datatable-using-a-dictionary	
Dictionary<string, string> dicConditions = new Dictionary<string, string>();
dicConditions.Add("FirstName", "John");
dicConditions.Add("LastName", "Smith");
dicConditions.Add("IsCustomer", "Yes");

DataTable dt = dtContacts
    .AsEnumerable()
    .Where(c => 
        dicConditions.All(kv => c.Field<string>(kv.Key) == kv.Value)
    ).CopyToDataTable();

using StringKvp = System.Collections.Generic.KeyValuePair<string, string>;
using DataRowPredicate = System.Func<System.Data.DataRow, bool>;
...

var pred = dicConditions.Aggregate<StringKvp, DataRowPredicate>(r => true,
    (net, curr) => r => net(r) && r.Field<string>(curr.Key) == curr.Value);

var dt = dtContacts.AsEnumerable().Where(pred).CopyToDataTable();

	2023-07-30T13:35:00	http://stackoverflow.com/questions/4141208/convert-a-delimted-string-to-a-dictionarystring-string-in-c-sharp
	
	2023-07-30T13:44:00 Code complete? Debug.
	*/
	public class SeOLeLoLinqWithRegEx
	{
		public static DataTable Query
		(
			String whereClause
		)
		{
			var dictConditions = whereClause
				.Split(new[] {';'}, StringSplitOptions.RemoveEmptyEntries)
				.Select(part => part.Split('='))
				.ToDictionary(split => split[0], split => split[1]);
			   
			DataTable selectTable = (DataTable) DataCommand.DatabaseCommand
			(
				QueryStatement,
				CommandType.Text,
				DataCommand.ResultType.DataTable
			);
			
			DataTable linqTable = selectTable
				.AsEnumerable()
				.Where
					(
						c => 
						dictConditions.All(kv => c.Field<string>(kv.Key) == kv.Value)
					)
				.CopyToDataTable();
			
			return linqTable;
		}

        public const string QueryStatement = 
		@"
			SELECT 	*
			FROM 	WordEngineering..HisWord				
			ORDER BY HisWordID DESC
		";
	}
}
