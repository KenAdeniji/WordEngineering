<%@ WebService Language="C#" Class="IsMakingRemainderOfTime" %>

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

///<summary>
/// 2017-04-18	http://www.apress.com/us/book/9781484213339
///	2017-04-19	Created.	Nothing beyond Me; is acceptable to Me. NothingBeyondMeIsAcceptableToMe.asmx
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class IsMakingRemainderOfTime : System.Web.Services.WebService
{
    [WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string Hello()
    {
        return "Hello World!";
    }
	
	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query
	(
		string bibleVersion,
		int	limit,
		int minimumLength
	)
    {
		string content = BibleStatisticsHelper.CombineVerseText(bibleVersion);
		AndrewTroelsenLinqStatisticsHelper.WordUsage wordUsage = AndrewTroelsenLinqStatisticsHelper.WordStatistics
		(
			content, limit, minimumLength
		);
		string json = JsonConvert.SerializeObject(wordUsage, Formatting.Indented);
		return json;
	}
}
