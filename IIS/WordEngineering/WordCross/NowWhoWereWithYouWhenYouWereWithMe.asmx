<%@ WebService Language="C#" Class="NowWhoWereWithYouWhenYouWereWithMeWebService" %>

using System;
using System.Data;
using System.Web;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Web.Script.Services;

using System.Data.SqlClient;
using System.Text;	

using InformationInTransit.DataAccess;
using InformationInTransit.ProcessCode;
using InformationInTransit.ProcessLogic;
using InformationInTransit.UserInterface;

using Newtonsoft.Json;

///<summary>
///	2024-01-31T20:33:09 Robert Rouse. Minister of Data. viz.bible
///	2024-02-02T12:15:00 Created.
///	HisWord table. 159455	2024-02-03 11:10:39.553	He chose to do it...base on activity.	11:35 Headache. 11:59 Urine. 12:10 Urine. 12:32 NowWhoWereWithYouWhenYouWereWithMe.html word input now...king. 13:07 Urine. 2024-02-02...2024-02-03T14:12:00 microsoft windows operating system, mozilla firefox browser NowWhoWereWithYouWhenYouWereWithMe.html word=king no response error, freeze, wait error. 13:49 Pegasus Center, 34245 Fremont Boulevard, State Farm, Christina Zeng agent. 13:49 Urine Wienerschnitzel 99 Ranch Market (Ofe ke?) (A mo pe ko da be). 14:19 Thirst (We are proving difficult) (A mo pe ko da be).	NULL	NULL	NULL	NULL	NULL	NULL	NULL
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class NowWhoWereWithYouWhenYouWereWithMeWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public string Query
	(
		string	word,
		bool	wholeWords
	)
    {
		String tableOrViewName;
		DataTable tableOrViewSchema;
		StringBuilder whereClause;
		StringBuilder queryStatement = new StringBuilder();

		System.Collections.Generic.Dictionary<string, string> tables =
			NowWhoWereWithYouWhenYouWereWithMe.Tables
		(
			String.Format
			(
				DatabaseConnectionStringFormat,
				DatabaseName
			)	
		);
		
		foreach(KeyValuePair<string, string> entry in tables)
		{
			tableOrViewName = String.Format
			(
				"{0}.{1}.{2}",
				DatabaseName,
				entry.Value,
				entry.Key.ToString()
			);	

			tableOrViewSchema = NowWhoWereWithYouWhenYouWereWithMe.TableSchema
			(
				String.Format
				(
					DatabaseConnectionStringFormat,
					DatabaseName
				),	
				tableOrViewName
			);

			whereClause = NowWhoWereWithYouWhenYouWereWithMe.WhereClause
			(
				tableOrViewSchema,
				word,
				wholeWords
			);
		
			queryStatement.Append
			(
				String.Format
				(
					QueryFormat,
					tableOrViewName,
					whereClause
				)
			);
		}
		
		DataSet resultSet = (DataSet) DataCommand.DatabaseCommand
		(
			queryStatement.ToString(),
			CommandType.Text,
			DataCommand.ResultType.DataSet
		);
		
		string json = JsonConvert.SerializeObject(resultSet, Formatting.Indented);
		return json;
    }
	
	const String DatabaseName = "RobertRouseVizBible";
	const String DatabaseConnectionStringFormat = "Data Source=(local);Database={0};Integrated Security=true;";
	const String QueryFormat = " SELECT * FROM {0} {1}; ";
}
