<%@ WebService Language="C#" Class="BodyPartsWebService" %>

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
using InformationInTransit.ProcessLogic;
using InformationInTransit.UserInterface;

///<summary>
///	2018-05-05 	Created.	
///	2018-05-05	http://en.wikipedia.org/wiki/Rib
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class BodyPartsWebService : System.Web.Services.WebService
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
	)
    {
		DataSet resultSet = (DataSet) DataCommand.DatabaseCommand
		(
			SQLStatement,
			System.Data.CommandType.Text,
			DataCommand.ResultType.DataSet
		);

		SQLStatementLog.Append
		(
			ref	resultSet,
				SQLStatement
		);
		
		string json = JsonConvert.SerializeObject(resultSet, Formatting.Indented);
		return json;
    }
	
	public const string SQLStatement =
@"
DECLARE @bodyParts TABLE 
( 
      [seq] int not null identity(1,1)
	, BibleWord	VARCHAR(15)
	, Tally	INT
)

declare @sumTotal bigint


INSERT INTO @bodyParts
SELECT			'Ear'		, 2 
UNION ALL SELECT	'Eye'		, 2 
UNION ALL SELECT	'Nostril'	, 2 
UNION ALL SELECT	'Teeth'		, 32 
UNION ALL SELECT	'Rib'		, 7 --2018-05-05	http://en.wikipedia.org/wiki/Rib
UNION ALL SELECT	'Finger'	, 10 
UNION ALL SELECT	'Toe'		, 10 


set @sumTotal =
				(
					select sum(Tally)
					from   @bodyParts
				)


; with cteTotal
(
	[Tally]
)
as
(
	select sum(Tally)
	from   @bodyParts
)

SELECT
	     tblBP.BibleWord

	  ,  tblBP.Tally

      ,  RunningTotal
	  
	      = isNull
				(
					SUM(tblBP.Tally) 
					over
					(
						ORDER BY 
							tblBP.[seq]
					)  
					, 0
				)


	  ,  Percentage
			= cast
				(
					tblBP.Tally * 100.00
						/ NULLIF
							(
								--cteT.Tally
								@sumTotal
								, 0
							)

					as decimal(10, 2)
				)

from @bodyParts tblBP

--cross apply cteTotal cteT

order by
     tblBP.[seq]
	
";	
}
