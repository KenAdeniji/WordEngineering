<%@ WebService Language="C#" Class="BigIntegerWebService"%>

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

using InformationInTransit.ProcessCode;

///<summary>
///	2018-11-01 Created.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class BigIntegerWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query(string question)
    {
		var dictionary = BigIntegerHelper.Query(question);
		string json = JsonConvert.SerializeObject(dictionary, Formatting.Indented);
		return json;
    }
	
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Operation
	(
		string firstOperand,
		string secondOperand,
		char operation
	)
    {
		var result = BigIntegerDelegateOperation.Operation
		(
			firstOperand,
			secondOperand,
			operation
		);
		string json = JsonConvert.SerializeObject(result, Formatting.Indented);
		return json;
    }
}
