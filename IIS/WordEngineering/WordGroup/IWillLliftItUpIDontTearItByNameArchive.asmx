<%@ WebService Language="C#" Class="IWillLliftItUpIDontTearItByNameWebService" %>

using System;
using System.Data;
using System.Web;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Web.Script.Services;

using System.Data;
using System.Data.SqlClient;

using Newtonsoft.Json;

using InformationInTransit.DataAccess;
using InformationInTransit.ProcessLogic;
using InformationInTransit.UserInterface;

///<summary>
///	2020-08-28 	Created.	https://stackoverflow.com/questions/54820970/ms-sql-count-the-occurrences-of-a-word-in-a-field
///	2020-08-28	https://docs.microsoft.com/en-us/dotnet/framework/data/adonet/dataset-datatable-dataview/adding-columns-to-a-datatable
///	2020-08-28	https://stackoverflow.com/questions/8935161/how-to-add-a-case-insensitive-option-to-array-indexof
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class IWillLliftItUpIDontTearItByNameWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query
	(
		string bibleWord
	)	
    {
		DataTable dataTable = (DataTable) DataCommand.DatabaseCommand
		(
			String.Format(QueryFormat, bibleWord),
			CommandType.Text,
			DataCommand.ResultType.DataTable
		);
		
		DataColumn indexColumn = dataTable.Columns.Add("Index", typeof(Int32));  
		indexColumn.AllowDBNull = true;

		DataColumn countColumn = dataTable.Columns.Add("Count", typeof(Int32));  
		
		int 		rowIndex = 0;
		int 		rowCount = dataTable.Rows.Count;
		DataRow		dataRow;
		string		commentary;
		string[] 	keywords;
		int			indexOf = -1;

		for
		(
			;
			rowIndex < rowCount;
			++rowIndex
		)
		{
			dataRow = dataTable.Rows[rowIndex];
			commentary = (String) dataRow["Commentary"];
			keywords = commentary.Split(new [] {", "}, StringSplitOptions.RemoveEmptyEntries);
			
			for(int index = 0, count = keywords.Length; index < count; ++index)
			{
				keywords[index] = keywords[index].Trim();
			}

			//indexOf = Array.IndexOf(keywords, bibleWord);
			indexOf = Array.FindIndex(keywords, t => t.Equals(bibleWord, StringComparison.InvariantCultureIgnoreCase));
			dataRow["Index"] = indexOf + 1;
			
			dataRow["Count"] = keywords.Length;
		}
		
		string json = JsonConvert.SerializeObject(dataTable, Formatting.Indented);
		return json;
    }
	
	public const string QueryFormat = 
	@"
		SELECT Minor, Actor, Commentary, ScriptureReference
		FROM WordEngineering..ActToGod
		WHERE 
			Major LIKE '%I will lift it up; I don''t tear it by name.%'
		And	Commentary LIKE '%{0}%'	
		ORDER BY Minor, Actor, Commentary, ScriptureReference
	";
}
