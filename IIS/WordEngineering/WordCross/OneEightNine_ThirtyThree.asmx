<%@ WebService Language="C#" Class="OneEightNine_ThirtyThreeWebService" %>

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
using System.Text;

using Newtonsoft.Json;

using InformationInTransit.DataAccess;

///<summary>
///	2024-04-19T12:33:00	Created.	
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class OneEightNine_ThirtyThreeWebService : System.Web.Services.WebService
{
	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public string Query
	(
		int chapterID,
		int verseID
	)
    {
		String queryStatement = String.Format
		(
			QueryFormat,
			chapterID,
			verseID
		);	

		string scriptureReference = (String) DataCommand.DatabaseCommand
		(
			queryStatement,
			System.Data.CommandType.Text,
			DataCommand.ResultType.Scalar
		);
		
		return scriptureReference;
	}	

	public const string QueryFormat = @"
		SELECT WordEngineering.dbo.udf_OneEightNine_ThirtyThree
		(
			{0},
			{1}
		)
	";
}


