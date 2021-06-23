<%@ WebService Language="C#" Class="MoKanNiOFileNaNiWebService" %>
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Web.Script.Services;
using System.Xml;

using Newtonsoft.Json;

using JayMuntzCom;

using InformationInTransit.DataAccess;
using InformationInTransit.ProcessCode;

/*
		2021-06-22	Added the Holiday column to the result set,
					and replaced the SQL in statement with union.
*/
///<summary>
///	2021-06-20T18:50:00 Created.	https://www.codeproject.com/Articles/11666/Dynamic-Holiday-Date-Calculator
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class MoKanNiOFileNaNiWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String HolidayNames
	(
	)
    {
		MoKanNiOFileNaNi moKanNiOFileNaNi = new MoKanNiOFileNaNi();
		List<String> holidayNames = moKanNiOFileNaNi.ExtractHolidayNames
		(
			moKanNiOFileNaNi.FilenameConfigurationXml
		);
		string json = JsonConvert.SerializeObject(holidayNames, Newtonsoft.Json.Formatting.Indented);
		return json;
    }
	
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String ProcessHolidayNames
	(
		String holidayNames,
		int	fromYear,
		int untilYear
	)
    {
		MoKanNiOFileNaNi moKanNiOFileNaNi = new MoKanNiOFileNaNi();
		List<HolidayCalculator.Holiday> holidays = moKanNiOFileNaNi.ProcessHolidayNames
		(
			moKanNiOFileNaNi.FilenameConfigurationXml,
			holidayNames.Split(','),
			fromYear,
			untilYear
		);

		StringBuilder sb = new StringBuilder();
		foreach(HolidayCalculator.Holiday holiday in holidays)
		{
			if ( sb.Length > 0 )
			{
				sb.Append(" UNION ");
			}
			sb.AppendFormat
			(
				SQLStatement,
				holiday.Name.Replace("'", "''"),
				holiday.Date.ToShortDateString()
			);
		}

		if ( sb.Length > 0 )
		{
			sb.Append(" ORDER BY Dated ");
		}

		DataTable dataTable = (DataTable) DataCommand.DatabaseCommand
		(
			sb.ToString(),
			CommandType.Text,
			DataCommand.ResultType.DataTable
		);
		
		string json = JsonConvert.SerializeObject(dataTable, Newtonsoft.Json.Formatting.Indented);
		return json;
    }
	
	public const string SQLStatement = 
	@"
		SELECT	Dated, '{0}' AS Holiday, HisWordID, Word, Commentary, Uri, ScriptureReference, Filename, EnglishTranslation
		FROM WordEngineering..HisWord
		WHERE '{1}' = CONVERT(Date, Dated)
	";	
}

