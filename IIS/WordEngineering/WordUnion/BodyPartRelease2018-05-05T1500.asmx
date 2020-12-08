<%@ WebService Language="C#" Class="BodyPartWebService" %>

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
///	2018-05-05 Created.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class BodyPartWebService : System.Web.Services.WebService
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

		string json = JsonConvert.SerializeObject(resultSet, Formatting.Indented);
		return json;
    }
	
	public const string SQLStatement =
@"
DECLARE @bodyParts TABLE 
( 
      [seq] int not null identity(1,1)
	, Part	VARCHAR(15)
	, Tally	INT
)

declare @sumTotal bigint


INSERT INTO @bodyParts
SELECT				'Ears'		, 2 
UNION ALL SELECT	'Eyes'		, 2 
UNION ALL SELECT	'Nostrils'	, 2 
UNION ALL SELECT	'Teeth'		, 32 
UNION ALL SELECT	'Ribs'		, 24 
UNION ALL SELECT	'Fingers'	, 10 
UNION ALL SELECT	'Toes'		, 10 


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
	     tblBP.Part	

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
