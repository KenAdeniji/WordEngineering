<%@ WebService Language="C#" Class="WhereAreIWebService" %>

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
using System.Text;

using Microsoft.SqlServer.Server;
using Microsoft.SqlServer.Management.Sdk.Sfc;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;

using System.Linq;

using Newtonsoft.Json;

using InformationInTransit.DataAccess;
using InformationInTransit.ProcessCode;
using InformationInTransit.UserInterface;

///<summary>
///	2018-09-10 Created.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class WhereAreIWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query
	(
		String	contributor
	)
    {
		DataSet dataSet = (DataSet) DataCommand.DatabaseCommand
		(
			String.Format
			(
				"Select URI FROM WordEngineering..WhereAreI WHERE Contributor LIKE '%{0}%' ORDER BY URI ASC",
				contributor
			),
			CommandType.Text,
			DataCommand.ResultType.DataSet
		);

		string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);
		return json;
    }
}
