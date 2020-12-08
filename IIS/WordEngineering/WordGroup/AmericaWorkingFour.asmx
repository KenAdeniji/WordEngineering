<%@ WebService Language="C#" Class="AmericaWorkingFourWebService" %>

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

using System.Reflection;

using Newtonsoft.Json;

using InformationInTransit.DataAccess;
using InformationInTransit.ProcessCode;

///<summary>
/// 2020-02-19	Created.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class AmericaWorkingFourWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query
	(
		String	tableName
	)
    {
		DataTable result = AmericaWorkingFour.RetrieveTableSchema
		(
			tableName
		);
		string json = JsonConvert.SerializeObject(result, Formatting.Indented);
		return json;
    }

   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Alter
	(
		String	alterTableStatement
	)
    {
        String result = (String) DataCommand.DatabaseCommand
        (
            alterTableStatement,
            "Data Source=(local);Initial Catalog=AmericaWorkingFour;Integrated Security=True;Asynchronous Processing=true;",
            CommandType.Text,
            DataCommand.ResultType.NonQuery
        );
		string json = JsonConvert.SerializeObject(result, Formatting.Indented);
		return json;
    }
}
