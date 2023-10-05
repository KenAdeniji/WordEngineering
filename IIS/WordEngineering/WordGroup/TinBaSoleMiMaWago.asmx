<%@ WebService Language="C#" Class="TinBaSoleMiMaWagoWebService" %>

using System;
using System.Web;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Web.Script.Services;

using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Globalization;
using System.Text;

using Newtonsoft.Json;

using InformationInTransit.DataAccess;
using InformationInTransit.ProcessCode;
using InformationInTransit.ProcessLogic;
using InformationInTransit.UserInterface;

///<summary>
/// 2020-11-05	Created.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class TinBaSoleMiMaWagoWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Minor
	(
	)
    {
        DataSet resultSet = (DataSet) DataCommand.DatabaseCommand
		(
			MinorSelect,
			System.Data.CommandType.Text,
			DataCommand.ResultType.DataSet
		);
		
		string json = JsonConvert.SerializeObject(resultSet, Formatting.Indented);
		return json;
    }

   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query
	(
		String	sqlSelect,
		String	bibleVersion
	)
    {
        DataSet resultSet = (DataSet) DataCommand.DatabaseCommand
		(
			String.Format(sqlSelect, bibleVersion),
			System.Data.CommandType.Text,
			DataCommand.ResultType.DataSet
		);
		
		string json = JsonConvert.SerializeObject(resultSet, Formatting.Indented);
		return json;
    }
	
	public const String MinorSelect = @"
		SELECT Minor, Commentary
		FROM WordEngineering..ActToGod
		WHERE Major = 'Tin ba sole, mi ma wago.'
		ORDER BY Minor
	";
}
