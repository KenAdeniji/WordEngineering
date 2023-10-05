<%@ WebService Language="C#" Class="RatingRankWebService" %>

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
using InformationInTransit.UserInterface;

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class RatingRankWebService : System.Web.Services.WebService
{
    [WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string Hello()
    {
        return "Hello World!";
    }
	
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String DenominationSelect()
    {
		DataSet dataSet = (DataSet) DataCommand.DatabaseCommand
		(
			"RatingRank.dbo.uspDenominationSelect",
			CommandType.StoredProcedure,
			DataCommand.ResultType.DataSet
		);
		
		string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);

		return json;
    }

    [WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public String RatingRankMaintenance
	(
		Int64	organizationId,
		string	organizationName,
		Int64	denominationId
	)
    {
		DateTime dateCreated = LowestDate;
		DateTime dateUpdated = LowestDate;
		
		Collection<SqlParameter> sqlParameterCollection = new Collection<SqlParameter>();
		
		SqlParameter sqlParameterOrganizationId = new SqlParameter("@organizationId", SqlDbType.BigInt);
		
		if (organizationId < 1)
		{
			sqlParameterOrganizationId.Value = DBNull.Value;
		}
		else
		{
			sqlParameterOrganizationId.Value = organizationId;
		}
		
		sqlParameterOrganizationId.Direction = ParameterDirection.InputOutput;
		sqlParameterOrganizationId.IsNullable = true;
		sqlParameterCollection.Add(sqlParameterOrganizationId);
		
		SqlParameter sqlParameterDateCreated = new SqlParameter("@dateCreated", SqlDbType.DateTime);
		sqlParameterDateCreated.Value = DBNull.Value;
		sqlParameterDateCreated.Direction = ParameterDirection.Output;
		sqlParameterDateCreated.IsNullable = true;
		sqlParameterCollection.Add(sqlParameterDateCreated);

		SqlParameter sqlParameterDateUpdated = new SqlParameter("@dateUpdated", SqlDbType.DateTime);
		sqlParameterDateUpdated.Value = DBNull.Value;
		sqlParameterDateUpdated.Direction = ParameterDirection.Output;
		sqlParameterDateUpdated.IsNullable = true;
		sqlParameterCollection.Add(sqlParameterDateUpdated);

		sqlParameterCollection.Add(new SqlParameter("@organizationName", organizationName));
		sqlParameterCollection.Add(new SqlParameter("@denominationId", denominationId));
		
		DataCommand.DatabaseCommand
		(
			"RatingRank.dbo.uspRatingRankMaintenance",
			CommandType.StoredProcedure,
			DataCommand.ResultType.NonQuery,
			sqlParameterCollection
		);
		
		if (sqlParameterOrganizationId.Value != DBNull.Value)
		{
			organizationId = Convert.ToInt64(sqlParameterOrganizationId.Value);
		}
		
		if (sqlParameterDateCreated.Value != DBNull.Value)
		{
			dateCreated = Convert.ToDateTime(sqlParameterDateCreated.Value);
		}

		if (sqlParameterDateUpdated.Value != DBNull.Value)
		{
			dateUpdated = Convert.ToDateTime(sqlParameterDateUpdated.Value);
		}
		
		RatingRank ratingRank = new RatingRank
		{
			OrganizationId = organizationId,
			DateCreated = dateCreated,
			DateUpdated = dateUpdated,
		};
		
		string json = JsonConvert.SerializeObject(ratingRank);

		return json;
    }

	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public String RatingRankRetrieve
	(
		Int64	organizationId
	)
    {
		Collection<SqlParameter> sqlParameterCollection = new Collection<SqlParameter>();

		sqlParameterCollection.Add(new SqlParameter("@organizationId", organizationId));
		
		DataSet dataSet = (DataSet) DataCommand.DatabaseCommand
		(
			"RatingRank.dbo.uspRatingRankRetrieve",
			CommandType.StoredProcedure,
			DataCommand.ResultType.DataSet,
			sqlParameterCollection
		);
		
		string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);

		return json;
    }

    [WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public String RatingRankSelect
	(
		Int64		organizationIdFrom,
		Int64		organizationIdUntil,
		DateTime	dateCreatedFrom,
		DateTime	dateCreatedUntil,
		DateTime	dateUpdatedFrom,
		DateTime	dateUpdatedUntil,
		string 		organizationName,
		string 		religion,
		string 		denomination
	)
    {
		Collection<SqlParameter> sqlParameterCollection = new Collection<SqlParameter>();

		if (organizationIdFrom != null && organizationIdFrom != LowestNumber)
		{
			sqlParameterCollection.Add(new SqlParameter("@organizationIdFrom", organizationIdFrom));
		}	
		
		if (organizationIdUntil != null && organizationIdUntil != HighestNumber)
		{
			sqlParameterCollection.Add(new SqlParameter("@organizationIdUntil", organizationIdUntil));
		}
		
		if (dateCreatedFrom != null && dateCreatedFrom != LowestDate)
		{
			sqlParameterCollection.Add(new SqlParameter("@dateCreatedFrom", dateCreatedFrom));
		}
		
		if (dateCreatedUntil != null && dateCreatedUntil != HighestDate)
		{
			sqlParameterCollection.Add(new SqlParameter("@dateCreatedUntil", dateCreatedUntil));
		}

		if (dateUpdatedFrom != null && dateUpdatedFrom != LowestDate)
		{
			sqlParameterCollection.Add(new SqlParameter("@dateUpdatedFrom", dateUpdatedFrom));
		}
		
		if (dateUpdatedUntil != null && dateUpdatedUntil != HighestDate)
		{
			sqlParameterCollection.Add(new SqlParameter("@dateUpdatedUntil", dateUpdatedUntil));
		}
		
		sqlParameterCollection.Add(new SqlParameter("@organizationName", organizationName));
		sqlParameterCollection.Add(new SqlParameter("@religion", religion));
		sqlParameterCollection.Add(new SqlParameter("@denomination", denomination));
		
		DataSet dataSet = (DataSet) DataCommand.DatabaseCommand
		(
			"RatingRank.dbo.uspRatingRankSelect",
			CommandType.StoredProcedure,
			DataCommand.ResultType.DataSet,
			sqlParameterCollection
		);
		
		string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);

		return json;
    }
	
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String ReligionSelect()
    {
		DataSet dataSet = (DataSet) DataCommand.DatabaseCommand
		(
			"RatingRank.dbo.uspReligionSelect",
			CommandType.StoredProcedure,
			DataCommand.ResultType.DataSet
		);
		
		string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);

		return json;
    }

	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String SelfMadeSelect()
    {
		DataSet dataSet = (DataSet) DataCommand.DatabaseCommand
		(
			"RatingRank.dbo.uspSelfMadeSelect",
			CommandType.StoredProcedure,
			DataCommand.ResultType.DataSet
		);
		
		string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);

		return json;
    }

	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String TrueOriginSelect()
    {
		DataSet dataSet = (DataSet) DataCommand.DatabaseCommand
		(
			"RatingRank.dbo.uspTrueOriginSelect",
			CommandType.StoredProcedure,
			DataCommand.ResultType.DataSet
		);
		
		string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);

		return json;
    }
	
	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String WeGiveYouGraceForSharingInOurNeed()
    {
		DataTable dataTable = (DataTable) DataCommand.DatabaseCommand
		(
			"SELECT Minor, ScriptureReference FROM WordEngineering..ActToGod WHERE Major = 'We give You grace for sharing in our need.'",
			CommandType.Text,
			DataCommand.ResultType.DataTable
		);
		
		string json = JsonConvert.SerializeObject(dataTable, Formatting.Indented);

		return json;
    }
	
	public class RatingRank
	{
		public Int64	OrganizationId		{ get; set; }
		public DateTime	DateCreated			{ get; set; }
		public DateTime	DateUpdated			{ get; set; }
		public String	OrganizationName	{ get; set; }
		public String	Religion			{ get; set; }
		public String	Denomination		{ get; set; }
	}
	
	public static readonly DateTime LowestDate = new DateTime(1753, 1, 1);
	public static readonly DateTime HighestDate = new DateTime(9999, 1, 1);

	public const int LowestNumber = -2147483648;
	public const int HighestNumber = 2147483647;
}
