<%@ WebService Language="C#" Class="AProvenOfMan" %>

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
using InformationInTransit.ProcessLogic;

///<summary>
///	2017-01-12	Created.	AProvenOfMan.asmx
///	2017-01-12	http://stackoverflow.com/questions/923295/how-can-i-truncate-a-datetime-in-sql-server
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class AProvenOfMan : System.Web.Services.WebService
{
    [WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string Hello()
    {
        return "Hello World!";
    }
	
	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query(DateTime dated)
    {
		DataSet dataSet = (DataSet)DataCommand.DatabaseCommand
		(
			String.Format(SQLFormat, dated),
			CommandType.Text,
			DataCommand.ResultType.DataSet
		);		
		string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);
		return json;
	}

	public const string SQLFormat =
		"SELECT * FROM WordEngineering..HisWord WHERE cast(dated As Date) = '{0}' ORDER BY Dated"; 
	
}
