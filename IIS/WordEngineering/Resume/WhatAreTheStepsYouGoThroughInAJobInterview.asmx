<%@ WebService Language="C#" Class="WhatAreTheStepsYouGoThroughInAJobInterviewWebService" %>

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
///	2019-12-25	Created.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class WhatAreTheStepsYouGoThroughInAJobInterviewWebService : System.Web.Services.WebService
{
	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query(String query)	
    {
		DataTable dataTable = (DataTable) DataCommand.DatabaseCommand
		(
			String.Format
			(
				SelectStatement,
				query
			),
			CommandType.Text,
			DataCommand.ResultType.DataTable
		);
		string json = JsonConvert.SerializeObject(dataTable, Formatting.Indented);
		return json;
	}
	
	public const string SelectStatement = "SELECT * FROM WordEngineering..WhatAreTheStepsYouGoThroughInAJobInterview WHERE Organization LIKE '%{0}%' OR FirstnameInitiator LIKE '%{0}%' OR LastnameInitiator LIKE '%{0}%' OR FirstnameRecipient LIKE '%{0}%' OR LastnameRecipient LIKE '%{0}%' OR Steps LIKE '%{0}%' OR Commentary LIKE '%{0}%' OR Uri LIKE '%{0}%' OR Email LIKE '%{0}%' OR Address LIKE '%{0}%' OR Telephone LIKE '%{0}%' ORDER BY Dated DESC";
}
