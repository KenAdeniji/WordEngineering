<%@ WebService Language="C#" Class="IfHeMeetYouWhereTheTroubleIsAtWebService" %>

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
/// 2020-01-22	Created.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class IfHeMeetYouWhereTheTroubleIsAtWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query
	(
	)
    {
		DataTable resultSet = (DataTable) DataCommand.DatabaseCommand
		(
			"WordEngineering..usp_IfHeMeetYouWhereTheTroubleIsAt",
			CommandType.StoredProcedure,
			DataCommand.ResultType.DataTable
		);
		
		string json = JsonConvert.SerializeObject(resultSet, Formatting.Indented);
		return json;
	}

	public const string SQLSelectStatement =
@"
DECLARE @rscript NVARCHAR(MAX);
  SET @rscript = N'
    OutputDataSet <- InputDataSet;
    OutputDataSet[,5] <- InputDataSet$FirstPopulation + InputDataSet$SecondPopulation;
	OutputDataSet[,6] <- -InputDataSet$FirstPopulation + InputDataSet$SecondPopulation;
	OutputDataSet[,7] <- round((InputDataSet$FirstPopulation + InputDataSet$SecondPopulation) / 2);
	';
  DECLARE @sqlscript NVARCHAR(MAX);
  SET @sqlscript = N'
    SELECT CensusID, Tribe, FirstPopulation, SecondPopulation, 0 AS CombinedPopulation, 0 AS DifferencePopulation,  0 AS MeanPopulation
    FROM WordEngineering..Census
    ORDER BY CensusID ASC;';
  EXEC sp_execute_external_script
    @language = N'R',
    @script = @rscript,
    @input_data_1 = @sqlscript;  
";	
}
