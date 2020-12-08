<%@ WebService Language="C#" Class="YourGirlSheIsInTrueTips" %>

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

using Newtonsoft.Json;

using InformationInTransit.DataAccess;

///<summary>
/// 2017-04-30	Created.	Your girl, she is in, true tips. YourGirlSheIsInTrueTips.asmx
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class YourGirlSheIsInTrueTips : System.Web.Services.WebService
{
    [WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string Hello()
    {
        return "Hello World!";
    }

	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query(decimal percent)
    {
		string sqlStatement = String.Format(SelectFormat, percent);
		string scriptureReference = (String) DataCommand.DatabaseCommand
		(
			sqlStatement,
			System.Data.CommandType.Text,
			DataCommand.ResultType.Scalar
		);
		
		string json = String.Format
		(
			JsonFormat,
			scriptureReference
		);

		return json;
	}
	
	public const string JsonFormat = "{{\"scriptureReference\": \"{0}\"}}";
	public const string SelectFormat = "SELECT TOP 1 ScriptureReference FROM Bible..Scripture_View WHERE VerseIdSequencePercent >= {0}";
}
