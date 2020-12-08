<%@ WebService Language="C#" Class="AsWeSaidOmoSchoolYinNaTryOhunNaMakeEffort" %>

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

///<summary>
///	2019-02-26	Created.	numverify.com
///	2019-02-27	https://stackoverflow.com/questions/19041814/getting-all-the-children-of-a-parent-using-mssql-query
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class AsWeSaidOmoSchoolYinNaTryOhunNaMakeEffort : System.Web.Services.WebService
{
	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query(string word)
    {
		DataSet dataSet = (DataSet)DataCommand.DatabaseCommand
		(
			String.Format(SelectStatement, word),
			CommandType.Text,
			DataCommand.ResultType.DataSet
		);
		string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);
		return json;
	}
	
	public const string SelectStatement = @"SELECT p.AsWeSaidOmoSchoolYinNaTryOhunNaMakeEffortID, p.FullName, p.ScriptureReference, p.FatherID, p.MotherID,
		(SELECT project.FullName FROM WordEngineering..AsWeSaidOmoSchoolYinNaTryOhunNaMakeEffort AS project WHERE p.FatherID = project.AsWeSaidOmoSchoolYinNaTryOhunNaMakeEffortID ) AS FullNameFather,
		(SELECT project.FullName FROM WordEngineering..AsWeSaidOmoSchoolYinNaTryOhunNaMakeEffort AS project WHERE p.MotherID = project.AsWeSaidOmoSchoolYinNaTryOhunNaMakeEffortID ) AS FullNameMother
		FROM WordEngineering..AsWeSaidOmoSchoolYinNaTryOhunNaMakeEffort AS c
		INNER JOIN WordEngineering..AsWeSaidOmoSchoolYinNaTryOhunNaMakeEffort p ON c.FatherID = p.FatherID
		WHERE c.FullName LIKE '%{0}%'
	";
}
