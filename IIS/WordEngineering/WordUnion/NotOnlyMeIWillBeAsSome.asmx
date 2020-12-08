<%@ WebService Language="C#" Class="NotOnlyMeIWillBeAsSomeWebService" %>

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
///	2015-09-19 Created.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class NotOnlyMeIWillBeAsSomeWebService : System.Web.Services.WebService
{
	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String NotOnlyMeIWillBeAsSomeSelect()
    {
		DataSet notOnlyMeIWillBeAsSomeDataSet = NotOnlyMeIWillBeAsSome.NotOnlyMeIWillBeAsSomeSelect();
		string json = JsonConvert.SerializeObject(notOnlyMeIWillBeAsSomeDataSet, Formatting.Indented);
		return json;
	}
	
	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query
	(
		String 	question,
		int		frequencyOfOccurrenceLimit
	)
    {
		string[] argv = new string[] {
 			String.Format("/frequencyOfOccurrenceLimit:{0}", frequencyOfOccurrenceLimit),
			question
		};
		
		DataSet result = null;		
		string[] scriptureReferenceSubset = null;
		
		DataSet notOnlyMeIWillBeAsSomeArgumentsDataSet = NotOnlyMeIWillBeAsSome.Process(argv, ref scriptureReferenceSubset, ref result);

		string json = JsonConvert.SerializeObject(notOnlyMeIWillBeAsSomeArgumentsDataSet, Formatting.Indented);
		return json;
	}
}
