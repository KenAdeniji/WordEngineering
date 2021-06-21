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

using InformationInTransit.DataAccess;
using InformationInTransit.ProcessCode;

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
		List<DateTime> holidays = moKanNiOFileNaNi.ProcessHolidayNames
		(
			moKanNiOFileNaNi.FilenameConfigurationXml,
			holidayNames.Split(','),
			fromYear,
			untilYear
		);

		StringBuilder sb = new StringBuilder();
		foreach(DateTime dated in holidays)
		{
			if ( sb.Length > 0 )
			{
				sb.Append(',');
			}
			sb.AppendFormat
			(
				"'{0}'",
				dated.ToShortDateString()
			);
		}

		String sqlStatement = String.Format(SQLStatement, sb.ToString());

		DataTable dataTable = (DataTable) DataCommand.DatabaseCommand
		(
			sqlStatement,
			CommandType.Text,
			DataCommand.ResultType.DataTable
		);
		
		string json = JsonConvert.SerializeObject(dataTable, Newtonsoft.Json.Formatting.Indented);
		return json;
    }
	
	public const string SQLStatement = 
	@"
		SELECT	HisWordID, Dated, Word, Commentary, Uri, ScriptureReference, Filename, EnglishTranslation
		FROM WordEngineering..HisWord
		WHERE CONVERT(Date, Dated) IN ({0})
		ORDER BY Dated
	";	
}

