<%@ WebService Language="C#" Class="WhenNothingUpToDateIsFurtherMoreWebService" %>

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
///	2018-11-06 Created.
///	Erica, Atinuke. How could you continue in the relationship, when you are not working and making money?
/// Bill Gates. You felt, he was saying to you; rather than put this information; can you generate in the back-end?
/// Windows Explorer. Microsoft Internet Explorer (IE). I confirm the task? This is my appearance.
/// 2018-11-07 When one participate; entire the other.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class WhenNothingUpToDateIsFurtherMoreWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query
	(
		string first,
		string lastOrBeside,
		string upToDate
	)
    {
		String selectQuery = null;
		
		switch(upToDate)
		{
			case "First and Last":
				selectQuery = String.Format(SelectFirstAndLast, first, lastOrBeside);
				break;
			case "Beside":
				selectQuery = String.Format(SelectBeside, first + lastOrBeside);
				break;
		}
		
		DataSet result = (DataSet) DataCommand.DatabaseCommand
		(
			selectQuery,
			System.Data.CommandType.Text,
			DataCommand.ResultType.DataSet
		);
		
		string json = JsonConvert.SerializeObject(result, Formatting.Indented);
		return json;
    }
	
	public const String SelectFirstAndLast = "SELECT * FROM Bible..Exact WHERE LEFT(BibleWord, 1) = '{0}' AND RIGHT(BibleWord, 1) = '{1}' ORDER BY ExactID ASC";
	public const String SelectBeside = "SELECT * FROM Bible..Exact WHERE BibleWord LIKE '%{0}%' ORDER BY ExactID ASC";	
}
