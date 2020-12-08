<%@ WebService Language="C#" Class="HomeAbroadWebService" %>

using System;
using System.Data;
using System.Numerics;
using System.Web;
using System.Collections;
using System.Collections.Generic;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Web.Script.Services;

using System.Data;
using System.Data.SqlClient;

using Newtonsoft.Json;

using InformationInTransit.DataAccess;
using InformationInTransit.UserInterface;

/*
	2013-06-25	Created.
*/
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class HomeAbroadWebService : System.Web.Services.WebService
{
    [WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string Hello()
    {
        return "Hello World!";
    }

    [WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public String AbroadInsert
	(
		string 		commentary,
		string 		scriptureReference,
		string 		word
	)
    {
		List<SqlParameter> sqlParameterCollection = new List<SqlParameter>();

		SqlParameter abroadId = new SqlParameter("@abroadId", SqlDbType.Int);
		abroadId.Value = DBNull.Value;
		abroadId.Direction = ParameterDirection.Output;
		abroadId.IsNullable = true;
		sqlParameterCollection.Add(abroadId);

		SqlParameter dateCreated = new SqlParameter("@dateCreated", SqlDbType.DateTime);
		dateCreated.Value = DBNull.Value;
		dateCreated.Direction = ParameterDirection.Output;
		dateCreated.IsNullable = true;
		sqlParameterCollection.Add(dateCreated);
		
		sqlParameterCollection.Add(new SqlParameter("@commentary", commentary));
		sqlParameterCollection.Add(new SqlParameter("@scriptureReference", scriptureReference));
		sqlParameterCollection.Add(new SqlParameter("@word", word));
		
		Repository.DatabaseCommand
		(
			"HomeAbroad.dbo.uspAbroadInsert",
			CommandType.StoredProcedure,
			Repository.ResultSet.NonQuery,
			sqlParameterCollection
		);
		
		HomeAbroad homeAbroad = new HomeAbroad
		{
			AbroadId = Convert.ToInt64(abroadId.Value),
			DateCreated = Convert.ToDateTime(dateCreated.Value)
		};
		
		string json = JsonConvert.SerializeObject(homeAbroad);

		return json;
    }
	
    [WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public String AbroadRetrieve
	(
		Int64	abroadId
	)
    {
		List<SqlParameter> sqlParameterCollection = new List<SqlParameter>();

		sqlParameterCollection.Add(new SqlParameter("@abroadId", abroadId));
		
		DataSet dataSet = (DataSet) Repository.DatabaseCommand
		(
			"HomeAbroad.dbo.uspAbroadRetrieve",
			CommandType.StoredProcedure,
			Repository.ResultSet.DataSet,
			sqlParameterCollection
		);
		
		string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);

		return json;
    }
	
    [WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public String AbroadSelect
	(
		Int64		abroadIdFrom,
		Int64		abroadIdUntil,
		DateTime	dateCreatedFrom,
		DateTime	dateCreatedUntil,
		DateTime	dateUpdatedFrom,
		DateTime	dateUpdatedUntil,
		string 		commentary,
		string 		scriptureReference,
		string 		word
	)
    {
		List<SqlParameter> sqlParameterCollection = new List<SqlParameter>();

		if (abroadIdFrom != null && abroadIdFrom != LowestNumber)
		{
			sqlParameterCollection.Add(new SqlParameter("@abroadIdFrom", abroadIdFrom));
		}	
		
		if (abroadIdUntil != null && abroadIdUntil != HighestNumber)
		{
			sqlParameterCollection.Add(new SqlParameter("@abroadIdUntil", abroadIdUntil));
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
		
		sqlParameterCollection.Add(new SqlParameter("@commentary", commentary));
		sqlParameterCollection.Add(new SqlParameter("@scriptureReference", scriptureReference));
		sqlParameterCollection.Add(new SqlParameter("@word", word));
		
		DataSet dataSet = (DataSet) Repository.DatabaseCommand
		(
			"HomeAbroad.dbo.uspAbroadSelect",
			CommandType.StoredProcedure,
			Repository.ResultSet.DataSet,
			sqlParameterCollection
		);
		
		string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);

		return json;
    }

    [WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public String AbroadUpdate
	(
		Int64	abroadId,
		string 	commentary,
		string 	scriptureReference,
		string 	word
	)
    {
		List<SqlParameter> sqlParameterCollection = new List<SqlParameter>();

		SqlParameter dateUpdated = new SqlParameter("@dateUpdated", SqlDbType.DateTime);
		dateUpdated.Value = DBNull.Value;
		dateUpdated.Direction = ParameterDirection.Output;
		dateUpdated.IsNullable = true;
		sqlParameterCollection.Add(dateUpdated);
		
		sqlParameterCollection.Add(new SqlParameter("@abroadId", abroadId));
		sqlParameterCollection.Add(new SqlParameter("@commentary", commentary));
		sqlParameterCollection.Add(new SqlParameter("@scriptureReference", scriptureReference));
		sqlParameterCollection.Add(new SqlParameter("@word", word));
		
		Repository.DatabaseCommand
		(
			"HomeAbroad.dbo.uspAbroadUpdate",
			CommandType.StoredProcedure,
			Repository.ResultSet.NonQuery,
			sqlParameterCollection
		);
		
		HomeAbroad homeAbroad = new HomeAbroad
		{
			DateUpdated = Convert.ToDateTime(dateUpdated.Value)
		};
		
		string json = JsonConvert.SerializeObject(homeAbroad);

		return json;
    }
	
	public class HomeAbroad
	{
		public Int64	AbroadId 			{ get; set; }
		public DateTime	DateCreated			{ get; set; }
		public DateTime	DateUpdated			{ get; set; }
		public String	Commentary			{ get; set; }
		public String	ScriptureReference	{ get; set; }
		public String	Word				{ get; set; }
	}
	
	public static readonly DateTime LowestDate = new DateTime(1753, 1, 1);
	public static readonly DateTime HighestDate = new DateTime(9999, 1, 1);

	public const int LowestNumber = -2147483648;
	public const int HighestNumber = 2147483647;
}
