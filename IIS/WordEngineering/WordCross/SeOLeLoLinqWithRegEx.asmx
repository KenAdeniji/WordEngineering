<%@ WebService Language="C#" Class="SeOLeLoLinqWithRegExWebService" %>

using System;
using System.Data;
using System.Numerics;
using System.Web;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Web.Script.Services;

using System.Data;
using System.Data.Odbc;
using System.Data.SqlClient;

using Newtonsoft.Json;

using InformationInTransit.ProcessCode;

///<summary>
///	2023-07-30T13:44:00 ... 2023-07-30T13:54:00 Created.
///	Se o le lo Linq with RegEx?
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class SeOLeLoLinqWithRegExWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query
	(
		String whereClause
	)
    {
		DataTable resultTable = SeOLeLoLinqWithRegEx.Query
		(
			whereClause
		);	
		
		string json = JsonConvert.SerializeObject(resultTable, Formatting.Indented);
		return json;
    }
}

