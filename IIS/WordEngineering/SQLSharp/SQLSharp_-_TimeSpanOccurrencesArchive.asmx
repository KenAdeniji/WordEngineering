<%@ WebService Language="C#" Class="SQLSharpTimeSpanOccurrencesWebService" %>

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
///	2020-04-22T16:00:00	Created.	sqlsharp.com
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class SQLSharpTimeSpanOccurrencesWebService : System.Web.Services.WebService
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
			String.Format
			(
				QueryFormat,
				bibleVersion
			),
			CommandType.Text,
			DataCommand.ResultType.DataSet
		);
		
		string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);
		return json;
    }
	
	public const string QueryFormat = 
	@"
;with cte
as
(
	SELECT 

			  tbBS.KingJamesVersion
			, SQLSharp.SQL#.RegEx_CaptureGroup4K
	(
		cast(tbBS.{0} as varchar(4000)),	--ExpressionToValidate
		'(hour|day|week|month|year|season)', --RegularExpression
		1,	--CaptureGroup
		NULL,
		1,
		-1,
		--'IgnoreCase'
		''
	) as [captureGroup]

	from  Bible.dbo.Scripture tbBS
)
select 
		  cte.captureGroup AS TimeSpan
		, Count(*) AS Occurrences
from cte
where cte.captureGroup is not null
group by 
		cte.captureGroup
	";
}
