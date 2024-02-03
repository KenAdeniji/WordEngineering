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
