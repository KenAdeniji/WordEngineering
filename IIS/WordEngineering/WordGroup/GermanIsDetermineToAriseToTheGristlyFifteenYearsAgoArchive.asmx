<%@ WebService Language="C#" Class="GermanIsDetermineToAriseToTheGristlyFifteenYearsAgoWebService" %>

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

using System.Text;

using Newtonsoft.Json;

using InformationInTransit.DataAccess;
using InformationInTransit.ProcessCode;
using InformationInTransit.ProcessLogic;
using InformationInTransit.UserInterface;

///<summary>
///	2020-09-11	German is determine, to arise to the gristly, fifteen years ago.
///	2020-09-11	BibleGroupSubstitute variable definition, and BibleGroupSubstituteReplace implementation.
///	2020-09-12 	Created.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class GermanIsDetermineToAriseToTheGristlyFifteenYearsAgoWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query
	(
		String 	scriptureReference,
		decimal	biblePercent
	)
    {
		String resultSet = GermanIsDetermineToAriseToTheGristlyFifteenYearsAgo.Query
		(
			scriptureReference,
			biblePercent
		);
		
		return resultSet;
	}
}
