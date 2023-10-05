<%@ WebService Language="C#" Class="JumpOverTheThirteenthWebService" %>

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
using InformationInTransit.UserInterface;

///<summary>
///	2018-10-22 Created.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class JumpOverTheThirteenthWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query(float ratio)
    {
		String result = (String) DataCommand.DatabaseCommand
		(
			String.Format(SelectQuery, ratio),
			System.Data.CommandType.Text,
			DataCommand.ResultType.Scalar
		);
		return result;
    }
	
	public const String SelectQuery = @"
	SELECT 
	(SELECT TOP 1 ScriptureReference FROM Bible..Scripture_View WHERE VerseIDSequence >= 31102 * {0} ORDER BY VerseIDSequence) + ', ' +
	(SELECT TOP 1 BookTitle + ' ' + CONVERT(VARCHAR, ChapterID) FROM Bible..Scripture_View WHERE ChapterIDSequence >= 1189 * {0}  ORDER BY ChapterIDSequence) + ', ' +
	(SELECT TOP 1 BookTitle + ' ' + CONVERT(VARCHAR, ChapterID) FROM Bible..Scripture_View WHERE 31102 - VerseIDSequence >= 31102 * {0}  ORDER BY ChapterIDSequence DESC) + ', ' +
	(SELECT TOP 1 ScriptureReference FROM Bible..Scripture_View WHERE 31102 - VerseIDSequence >= 31102 * {0} ORDER BY VerseIDSequence DESC) 
	AS ScriptureReference
";	
}
