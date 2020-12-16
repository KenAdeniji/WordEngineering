<%@ WebService Language="C#" Class="NumberSignWebService" %>

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
using System.Web.Script.Serialization;

using Newtonsoft.Json;

using InformationInTransit.DataAccess;
using InformationInTransit.ProcessLogic;
using InformationInTransit.UserInterface;

///<summary>
///	2015-12-11	Created.	TalentBonding();
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class NumberSignWebService : System.Web.Services.WebService
{
    [WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string Hello()
    {
        return "Hello World!";
    }
	
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String TalentBonding
	(
		String	scriptureReference
	)
    {
		DataSet result = null;
		String[] scriptureReferenceSubset = null;

		Dictionary<int, NumberSignHelper.NumberSignScriptureReference> numberSignScriptureReferences =
			NumberSignHelper.TalentBonding
			(
					scriptureReference,
				ref scriptureReferenceSubset,
				ref result
			);		
		
		string json = JsonConvert.SerializeObject(numberSignScriptureReferences, Formatting.Indented);
		return json;
    }
}
