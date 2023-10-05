<%@ WebService Language="C#" Class="YourPartOfTheHistoryWebService" %>

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

using System.Linq;

using Newtonsoft.Json;

using InformationInTransit.ProcessCode;
using InformationInTransit.ProcessLogic;

///<summary>
///	2019-12-17			Created.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class YourPartOfTheHistoryWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query
	(
        String scriptureReference,
        String bibleVersion
	)
    {
		String[] scriptureReferenceSubset;
		DataSet dataSet = null;
		Dictionary<string, InformationInTransit.ProcessLogic.YourPartOfTheHistory.Participation> 
			result = YourPartOfTheHistory.Query
		(
                scriptureReference,
            //ref scriptureReferenceSubset,
            ref dataSet,
            //    ScriptureReferenceHelper.ExactQueryFormat,
                bibleVersion
		);	
		
		DataTable dataTable = InformationInTransit.ProcessCode.YourPartOfTheHistory.ToDataTable(result);
		string json = JsonConvert.SerializeObject(dataTable, Formatting.Indented);
		return json;
    }
}	
