<%@ WebService Language="C#" Class="DoWeChooseToBeKnownAsWhoWebService" %>

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
///	2022-06-25T15:54:00 Created.
///	2022-06-25T15:48:00 Jeremiah 52:1, Jeremiah 40:4
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class DoWeChooseToBeKnownAsWhoWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query
	(
		string	scriptureReference,
		string	bibleVersion,
		string	bibleWord
	)
    {
		String[] 	scriptureReferenceSubset = null;
		DataSet 	result = new DataSet();

		DataTable workTable = DoWeChooseToBeKnownAsWhoHelper.Extract
		(
				scriptureReference,
			ref	scriptureReferenceSubset,
			ref result,
				bibleVersion,
				bibleWord
		);
		
		string json = JsonConvert.SerializeObject(workTable, Formatting.Indented);
		return json;
    }
}
