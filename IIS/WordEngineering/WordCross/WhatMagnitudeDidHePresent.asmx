<%@ WebService Language="C#" Class="WhatMagnitudeDidHePresentWebService" %>

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
using InformationInTransit.ProcessCode;
using InformationInTransit.ProcessLogic;
using InformationInTransit.UserInterface;

///<summary>
///	2021-12-03T15:55:00 	Created.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class WhatMagnitudeDidHePresentWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query
	(
		String	firstScriptureReference,
		String	secondScriptureReference,
		String	thirdScriptureReference		
	)
    {
		String	sqlStatement = String.Format
		(
			SQLSelectFormat,
			firstScriptureReference,
			secondScriptureReference,
			thirdScriptureReference
		);
		
        DataTable resultTable = (DataTable) DataCommand.DatabaseCommand
		(
			sqlStatement,
			System.Data.CommandType.Text,
			DataCommand.ResultType.DataTable
		);
		
		string json = JsonConvert.SerializeObject(resultTable, Formatting.Indented);
		return json;
    }

	public const String SQLSelectFormat = 
		" SELECT VerseIDSequence " +
		" FROM Bible..Scripture_View " +
		" WHERE ScriptureReference IN ('{0}', '{1}', '{2}') " +
		" ORDER BY VerseIDSequence "
		;
}
