<%@ WebService Language="C#" Class="MyCondemn" %>

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

using InformationInTransit.DataAccess;
using InformationInTransit.ProcessLogic;
using InformationInTransit.UserInterface;

///<summary>
///	2017-06-19 	Created.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class MyCondemn : System.Web.Services.WebService
{
    [WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string Hello()
    {
        return "Hello World!";
    }

   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query
	(
		int bookID,
		int	verseID
	)
    {
		String resultSet = (String) DataCommand.DatabaseCommand
		(
			String.Format
			(
				MyCondemnSelectFormat,
				bookID,
				verseID
			),
			CommandType.Text,
			DataCommand.ResultType.Scalar
		);

		string json = String.Format
		(
			MyCondemnJsonFormat,
			resultSet
		);	

		return json;
    }
	
	public const string MyCondemnSelectFormat = "EXECUTE WordEngineering..usp_MyCondemn @bookID = {0}, @verseID = {1}";
	public const string MyCondemnJsonFormat = "{{\"scriptureReference\": \"{0}\"}}";
}
