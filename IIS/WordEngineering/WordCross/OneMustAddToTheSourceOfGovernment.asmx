<%@ WebService Language="C#" Class="OneMustAddToTheSourceOfGovernmentWebService" %>

using System;
using System.Data;
using System.Numerics;
using System.Web;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Web.Script.Services;

using Newtonsoft.Json;

using System.Data;
using System.Data.Odbc;
using System.Data.SqlClient;

using Newtonsoft.Json;

using InformationInTransit.DataAccess;
using InformationInTransit.ProcessCode;
using InformationInTransit.UserInterface;

///<summary>
///	2022-06-15T22:57:00 Created.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class OneMustAddToTheSourceOfGovernmentWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query
	(
		string	bibleVersion,
		string	bibleWord,
		string	scriptureReference
	)
    {
		String[] 	scriptureReferenceSubset = null;
		DataSet 	result = new DataSet();

		DataTable workTable = OneMustAddToTheSourceOfGovernmentHelper.Extract
		(
				scriptureReference,
			ref	scriptureReferenceSubset,
			ref result,
				bibleWord,
				bibleVersion
		);
		
		string json = JsonConvert.SerializeObject(workTable, Formatting.Indented);
		return json;
    }
}
