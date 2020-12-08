<%@ WebService Language="C#" Class="IntelligenceWhichProphecyStatesWeAreLivingInTheLastStateOfTheSeasonWebService" %>

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
using InformationInTransit.ProcessCode;

///<summary>
///	2019-02-10	Created.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class IntelligenceWhichProphecyStatesWeAreLivingInTheLastStateOfTheSeasonWebService : System.Web.Services.WebService
{
	
	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query(string bibleVersion, int bookID)
    {
		DataSet dataSet = (DataSet)DataCommand.DatabaseCommand
		(
			String.Format(SelectFormat, bibleVersion, bookID),
			CommandType.Text,
			DataCommand.ResultType.DataSet
        );
		string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);
		return json;
	}
	
	public const string SelectFormat = 
	@"	SELECT
			{0} AS VerseText,
			ScriptureReference,
			RANK() OVER(ORDER BY VerseIDSequence ASC) AS rnk
		FROM	
			Bible..Scripture
		WHERE
			BookID = {1}
		ORDER BY 
			VerseIDSequence	
		";
}
