<%@ WebService Language="C#" Class="BibleBookWebService" %>
using System;
using System.Data;
using System.Numerics;
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

///<summary>
///	2016-02-04	Created.	BibleBookWebService.asmx
///	2016-02-27	ATrialOfOurEnd	http://stackoverflow.com/questions/19709755/display-an-account-as-subheader-in-select-statement
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class BibleBookWebService : System.Web.Services.WebService
{
    [WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string Hello()
    {
        return "Hello World!";
    }
	
	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query()
    {
		DataTable dataTable = (DataTable)DataCommand.DatabaseCommand
		(
			"SELECT * FROM Bible..BibleBook ORDER BY BookId" ,
			CommandType.Text,
			DataCommand.ResultType.DataTable
		);
		
		string json = JsonConvert.SerializeObject(dataTable, Formatting.Indented);
		return json;
	}

	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Select()
    {
		DataSet dataSet = (DataSet)DataCommand.DatabaseCommand
		(
			"SELECT * FROM Bible..BibleBook ORDER BY BookId" ,
			CommandType.Text,
			DataCommand.ResultType.DataSet
		);
		
		string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);
		return json;
	}

	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String ATrialOfOurEnd()
    {
		DataTable dataTable = (DataTable)DataCommand.DatabaseCommand
		(
			"SELECT * FROM WordEngineering..ATrialOfOurEnd_View ORDER BY BookID, ChapterID, VerseID" ,
			CommandType.Text,
			DataCommand.ResultType.DataTable
		);
		
		string json = JsonConvert.SerializeObject(dataTable, Formatting.Indented);
		return json;
	}
}

	