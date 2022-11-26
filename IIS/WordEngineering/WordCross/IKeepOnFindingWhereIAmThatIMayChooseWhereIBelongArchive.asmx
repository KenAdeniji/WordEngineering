<%@ WebService Language="C#" Class="IKeepOnFindingWhereIAmThatIMayChooseWhereIBelongWebService" %>

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
using InformationInTransit.ProcessCode;
using InformationInTransit.UserInterface;

///<summary>
///	2022-11-25T15:35:00 Created.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class IKeepOnFindingWhereIAmThatIMayChooseWhereIBelongWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query(String scriptureReference, string bibleVersion)
    {
		String[] scriptureReferenceSubset = null;
		string result = IKeepOnFindingWhereIAmThatIMayChooseWhereIBelong.Query
		(
				scriptureReference,
				bibleVersion
		);
		return result;
    }
}
