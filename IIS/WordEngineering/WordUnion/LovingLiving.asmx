<%@ WebService Language="C#" Class="LovingLivingWebService" %>

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

using InformationInTransit.DataAccess;

///<summary>
///	2016-08-12	Created.	LovingLiving.asmx
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class LovingLivingWebService : System.Web.Services.WebService
{
    [WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string Hello()
    {
        return "Hello World!";
    }
	
	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query()
    {
		string random = (String) DataCommand.DatabaseCommand
		(
			"SELECT TOP 1 Word FROM WordEngineering.dbo.HisWord ORDER BY NewID()",
			System.Data.CommandType.Text,
			DataCommand.ResultType.Scalar
		);
		return random;
	}
}
