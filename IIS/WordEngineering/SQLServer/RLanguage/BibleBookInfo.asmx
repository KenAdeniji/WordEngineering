<%@ WebService Language="C#" Class="BibleBookInfoWebService" %>

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

///<summary>
///	2018-06-03	Created.
///	2018-06-03	https://www.red-gate.com/simple-talk/sql/bi/sql-server-r-services-basics/
///	2018-06-03	GRANT EXECUTE ANY EXTERNAL SCRIPT  TO [domain\loginid]
///	2018-06-04	https://www.sqlservercentral.com/Forums/613626/Count-number-of-distinct-rows-with-two-fields-as-primary-key
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class BibleBookInfoWebService : System.Web.Services.WebService
{
	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query()	
    {
		DataSet dataSet = (DataSet) DataCommand.DatabaseCommand
		(
			"WordEngineering..usp_BibleBookInfo",
			CommandType.StoredProcedure,
			DataCommand.ResultType.DataSet
		);
		string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);
		return json;
	}
}
