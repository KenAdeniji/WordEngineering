<%@ WebService Language="C#" Class="CouldYouRecoverTheTerritoryWebService" %>

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

using Newtonsoft.Json;

using InformationInTransit.DataAccess;
using InformationInTransit.ProcessCode;
using InformationInTransit.ProcessLogic;
using InformationInTransit.UserInterface;

///<summary>
///		2021-01-10T12:00:00 ...	2021-01-10T13:34:00 Created.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class CouldYouRecoverTheTerritoryWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query
	(
        string logic,
        string question
	)
    {
		StringBuilder sb = CouldYouRecoverTheTerritory.Query
		(
			logic,
			question
		);
		
		DataTable resultSet = (DataTable) DataCommand.DatabaseCommand
		(
			sb.ToString(),
			CommandType.Text,
			DataCommand.ResultType.DataTable
		);
		
		string json = JsonConvert.SerializeObject(resultSet, Formatting.Indented);
		return json;
    }
}
