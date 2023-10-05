<%@ WebService Language="C#" Class="AsIMadeManWebService" %>
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
///	2016-09-14	Created.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class AsIMadeManWebService : System.Web.Services.WebService
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
		DateTime	datedInput,
		String		calendarType,
		int			direction,		
		int?		timeSpanYear 	=	null,
		int?		timeSpanMonth	=	null,
		int?		timeSpanWeek	=	null,
		int?		timeSpanDay		=	null
	)
    {
		DateTime	datedOutput	=	datedInput;
		int			days		=	0;
		int			dayWeek		=	0;
		int			daysSpan 	=	0;
		int			months		=	0;
		int			years		=	0;
		
		Collection<SqlParameter> sqlParameterCollection = new Collection<SqlParameter>();
		
		if (timeSpanDay.HasValue) { daysSpan += (int) timeSpanDay; }
		if (timeSpanWeek.HasValue) { daysSpan += (int) timeSpanWeek * 7; }
		
		if (timeSpanMonth.HasValue) { months = (int) timeSpanMonth; }
		if (timeSpanYear.HasValue) { years = (int) timeSpanYear; }

		switch(calendarType)
		{
			case "Biblical":
				daysSpan += months * 30;
				daysSpan += years * 360;

				datedOutput = datedOutput.AddDays(daysSpan * direction);
				break;
				
			case "Gregorian":
				datedOutput = datedOutput.AddDays(daysSpan * direction);
				
				datedOutput = datedOutput.AddMonths(months * direction);
				datedOutput = datedOutput.AddYears(years * direction);
				break;
		}	

		TimeSpan difference = datedOutput - datedInput; 
		days = difference.Days;
		
		sqlParameterCollection.Add(new SqlParameter("@datedInput", datedInput));
		sqlParameterCollection.Add(new SqlParameter("@datedOutput", datedOutput));
		sqlParameterCollection.Add(new SqlParameter("@days", days));
		
		if (timeSpanYear.HasValue)
		{
			sqlParameterCollection.Add(new SqlParameter("@year", timeSpanYear));
		}
		
		if (timeSpanMonth.HasValue)
		{
			sqlParameterCollection.Add(new SqlParameter("@month", timeSpanMonth));
		}
		
		if (timeSpanWeek.HasValue)
		{
			dayWeek += (int) timeSpanWeek * 7;
		}
		
		if (timeSpanDay.HasValue)
		{
			dayWeek += (int) timeSpanDay;
		}

		if (timeSpanWeek.HasValue || timeSpanDay.HasValue)
		{
			sqlParameterCollection.Add(new SqlParameter("@day", dayWeek));
		}
		
		DataSet dataSet = (DataSet) DataCommand.DatabaseCommand
		(
			"WordEngineering..usp_AsIMadeMan",
			CommandType.StoredProcedure,
			DataCommand.ResultType.DataSet,
			sqlParameterCollection
		);
		
		string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);

/*
		json = String.Format
		(
			"Date: {0}", 
			dated
		);
*/
		return json;
	}
}
