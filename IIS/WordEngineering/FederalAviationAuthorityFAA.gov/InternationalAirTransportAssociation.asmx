<%@ WebService Language="C#" Class="InternationalAirTransportAssociation" %>

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
public class InternationalAirTransportAssociation : System.Web.Services.WebService
{
    [WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string Hello()
    {
        return "Hello World!";
    }

    [WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public String IATAAirportCodeSelect
	(
		string 	airportName,
		string 	airportCode
	)
    {
		Collection<SqlParameter> sqlParameterCollection = new Collection<SqlParameter>();

		sqlParameterCollection.Add(new SqlParameter("@airportName", airportName));
		sqlParameterCollection.Add(new SqlParameter("@airportCode", airportCode));
		
		DataSet dataSet = (DataSet) DataCommand.DatabaseCommand
		(
			String.Format
			(
				@"
					SELECT * 
					FROM AManDevelopedInAll.dbo.IATA_Airport_Code 
					WHERE Airport LIKE '%{0}%' OR Code LIKE '%{1}%'
					ORDER BY Airport
				",
				airportName,
				airportCode
			),	
			CommandType.StoredProcedure,
			DataCommand.ResultType.DataSet
		);
		
		string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);

		return json;
    }
}
