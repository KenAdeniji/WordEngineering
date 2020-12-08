<%@ WebService Language="C#" Class="ProgrammativeWebService" %>

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
///	2016-08-11	Created.	Programmative.asmx
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class ProgrammativeWebService : System.Web.Services.WebService
{
	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query(string scriptureReference)
    {
		string query = String.Format
		(
			ProgrammativeQueryFormat,
			scriptureReference
		);

		string combined = (String) DataCommand.DatabaseCommand
		(
			query,
			System.Data.CommandType.Text,
			DataCommand.ResultType.Scalar
		);
		
		return combined;
	}
	
	public const string ProgrammativeQueryFormat = "SELECT WordEngineering.dbo.udf_AlphabetSequenceIndexProgrammative('{0}') ";
}
