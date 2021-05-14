<%@ WebService Language="C#" Class="MiraculousPowerWebService" %>

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

using System.Linq;	

using Newtonsoft.Json;

using InformationInTransit.DataAccess;
using InformationInTransit.ProcessLogic;

///<summary>
///	2021-05-14T11:48:00 Created.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class MiraculousPowerWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query
	(
		String	bibleVersion
	)
    {
		DataSet dataSet = (DataSet) DataCommand.DatabaseCommand
		(
			String.Format(SQLStatement, bibleVersion),
			CommandType.Text,
			DataCommand.ResultType.DataSet
		);

		string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);
		return json;
    }
	
	public const string SQLStatement = 
	@"
		SELECT 	'Create' AS Act, 'Genesis 1:27, Genesis 5:2' AS ScriptureReference, (SELECT COUNT(*) FROM Bible..Scripture_View WHERE {0} LIKE '%Male%') AS Male, (SELECT COUNT(*) FROM Bible..Scripture_View WHERE {0} LIKE '%Female%') AS Female; 
		SELECT 	'Birth' AS Act, 'Genesis 4:25' AS ScriptureReference, (SELECT COUNT(*) FROM Bible..Scripture_View WHERE {0} LIKE '%Son%') AS Son, (SELECT COUNT(*) FROM Bible..Scripture_View WHERE {0} LIKE '%Daughter%') AS Daughter;
		SELECT 	'Reign' AS Act, 'Genesis 36:31' AS ScriptureReference, (SELECT COUNT(*) FROM Bible..Scripture_View WHERE {0} LIKE '%King%') AS King, (SELECT COUNT(*) FROM Bible..Scripture_View WHERE {0} LIKE '%Queen%') AS Queen;
	";	
}
