<%@ WebService Language="C#" Class="WhenDoWeDwarfOurPrivilegeWebService" %>

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
///	2020-05-30 Created.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class WhenDoWeDwarfOurPrivilegeWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query
	(
		String 	scriptureReference,
		string 	bibleVersion,
		String	biblePartition
	)	
    {
		String dynamicSql = String.Format
		(
			QueryFormat,
			"{0}", 
			bibleVersion, 
			biblePartition
		);

		String[] 	scriptureReferenceSubset = null;
		DataSet 	result = null;

		ScriptureReferenceHelper.Process
		(
			scriptureReference,
			ref scriptureReferenceSubset,
			ref result,
			dynamicSql,
			bibleVersion
		);
		
		string json = JsonConvert.SerializeObject(result, Formatting.Indented);
		return json;
    }
	
	public const string QueryFormat = 
	@"
		SELECT 
			STRING_AGG({1}, ';') WITHIN GROUP (ORDER BY verseIDSequence)
			FROM Bible..Scripture
			WHERE {0} 
			GROUP BY {2}
	";
}
