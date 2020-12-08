<%@ WebService Language="C#" Class="WhenReadingThisIsMyUsualPassageWebService" %>

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
using InformationInTransit.UserInterface;

/*
	2018-02-27	Created.	https://msdn.microsoft.com/en-us/library/w3te6wfz%28v=vs.110%29.aspx?f=255&MSPPError=-2147217396
*/
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class WhenReadingThisIsMyUsualPassageWebService : System.Web.Services.WebService
{
    [WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string Hello()
    {
        return "Hello World!";
    }
	
    [WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void Insert
	(
		DateTime	dated,
		String		email,
		String		uri,
		String		scriptureReference,
		String		title,
		String		commentary,
		String		keyword
	)
    {
		String	sqlStatement = String.Format
		(
			SelectStatement,
			dated,
			email,
			uri,
			scriptureReference,
			title,
			HttpContext.Current.Server.HtmlEncode(commentary),
			keyword
		);	
		DataCommand.DatabaseCommand
		(
			sqlStatement,
			CommandType.Text,
			DataCommand.ResultType.NonQuery
		);
    }
	
	public const String SelectStatement = 
		@"IF EXISTS (SELECT * FROM UsualPassage..Passage WHERE Dated ='{0}' AND email = '{1}') " + 
		" BEGIN " +
		" UPDATE UsualPassage..Passage " +
		" SET URI = '{2}', ScriptureReference = '{3}', Title = '{4}', Commentary = '{5}', Keyword = '{6}' " +
		" WHERE Dated ='{0}' AND email = '{1}' " + 
		" END " +
		" ELSE " +
		" BEGIN " +
		" INSERT INTO UsualPassage..Passage " +
		" (Dated, email, URI, ScriptureReference, Title, Commentary, Keyword) " +
		" VALUES ( '{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}' )" +
		" END ";
}
