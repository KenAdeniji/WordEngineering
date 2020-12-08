<%@ WebService Language="C#" Class="FirstAtLastWebService" %>

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

///<summary>
///	2018-03-19	Created.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class FirstAtLastWebService : System.Web.Services.WebService
{
	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query
	(
		String	bibleVersion,
		String	scriptureReference
	)	
    {
		DataSet		resultSet 					=	null;
		String[]	scriptureReferenceSubset 	= 	null;
	
		FirstAtLast.Query
		(
				bibleVersion,
			ref resultSet,			
				scriptureReference,
			ref scriptureReferenceSubset
		);

		string json = JsonConvert.SerializeObject(resultSet, Formatting.Indented);
		return json;
	}
}
