<%@ WebService Language="C#" Class="OneOfTheFamousWebsiteIKnowThrewUsByComfortAsYouGoTo" %>

using System;
using System.Web;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Web.Script.Services;

using System.Data;
using System.Text;

using Newtonsoft.Json;

using InformationInTransit.DataAccess;

///<summary>
/// 2017-06-08	Created.	One of the famous website, I know; threw us by comfort; as you go to ...
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class OneOfTheFamousWebsiteIKnowThrewUsByComfortAsYouGoTo : System.Web.Services.WebService
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
		int fromUntilDays,
		int contactID,	
		DateTime datedFromBegin,
		DateTime datedFromEnd,
		DateTime datedUntilBegin,
		DateTime datedUntilEnd,		
		int	biblicalCalendarYears,
		int	biblicalCalendarMonths,
		int	biblicalCalendarDays,
		int	gregorianCalendarYears,
		int	gregorianCalendarMonths,
		int	gregorianCalendarWeeks,
		int	gregorianCalendarDays		
	)
    {
		StringBuilder	sb	=	new StringBuilder();
		
		if (fromUntilDays > 0)
		{
   			sb.AppendFormat(FromUntilDaysWhereClauseQueryFormat, fromUntilDays);
		}

		if (contactID > 0)
		{
   			sb.AppendFormat(ContactIDWhereClauseQueryFormat, contactID);
		}
		
		if (datedFromBegin > DateTime.MinValue)
		{
			sb.AppendFormat(DatedFromBeginWhereClauseQueryFormat, datedFromBegin);
		}	

		if (datedFromEnd < DateTime.MaxValue)
		{
			sb.AppendFormat(DatedFromEndWhereClauseQueryFormat, datedFromEnd);
		}	

		if (datedUntilBegin > DateTime.MinValue)
		{
			sb.AppendFormat(DatedUntilBeginWhereClauseQueryFormat, datedUntilBegin);
		}	

		if (datedUntilEnd < DateTime.MaxValue)
		{
			sb.AppendFormat(DatedUntilEndWhereClauseQueryFormat, datedUntilEnd);
		}	
		
		if (biblicalCalendarYears > 0)
		{
   			sb.AppendFormat(BiblicalYearsWhereClauseQueryFormat, biblicalCalendarYears);
		}

		if (biblicalCalendarMonths > 0)
		{
   			sb.AppendFormat(BiblicalMonthsWhereClauseQueryFormat, biblicalCalendarMonths);
		}

		if (biblicalCalendarDays > 0)
		{
   			sb.AppendFormat(BiblicalDaysWhereClauseQueryFormat, biblicalCalendarDays);
		}
		
		if (gregorianCalendarYears > 0)
		{
   			sb.AppendFormat(GregorianYearsWhereClauseQueryFormat, gregorianCalendarYears);
		}

		if (gregorianCalendarMonths > 0)
		{
   			sb.AppendFormat(GregorianMonthsWhereClauseQueryFormat, gregorianCalendarMonths);
		}

		if (gregorianCalendarWeeks > 0)
		{
   			sb.AppendFormat(GregorianWeeksWhereClauseQueryFormat, gregorianCalendarWeeks);
		}

		if (gregorianCalendarDays > 0)
		{
   			sb.AppendFormat(GregorianDaysWhereClauseQueryFormat, gregorianCalendarDays);
		}
		
		string sqlStatement = String.Format(SelectFormat, sb.ToString());
		
		DataSet dataSet = (DataSet) DataCommand.DatabaseCommand
		(
			sqlStatement,
			System.Data.CommandType.Text,
			DataCommand.ResultType.DataSet
		);
		
		string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);
		return json;
	}
	
	public const string SelectFormat = "SELECT * FROM WordEngineering..Remember_View WHERE 1 = 1 {0} ORDER BY RememberID";
	
	public const string FromUntilDaysWhereClauseQueryFormat = " AND FromUntil = {0}";
	public const string ContactIDWhereClauseQueryFormat = " AND ContactID = {0}";

	public const string DatedFromBeginWhereClauseQueryFormat = " AND DatedFrom >= '{0}' ";
	public const string DatedFromEndWhereClauseQueryFormat = " AND DatedFrom <= '{0}' ";

	public const string DatedUntilBeginWhereClauseQueryFormat = " AND DatedUntil >= '{0}' ";
	public const string DatedUntilEndWhereClauseQueryFormat = " AND DatedUntil <= '{0}' ";
	
	public const string BiblicalYearsWhereClauseQueryFormat = " AND ToFro LIKE '%_{0} Biblical Year%' ";
	public const string BiblicalMonthsWhereClauseQueryFormat = " AND ToFro LIKE '%_{0} Biblical Month%' ";
	public const string BiblicalDaysWhereClauseQueryFormat = " AND ToFro LIKE '%_{0} Biblical Day%' ";

	public const string GregorianYearsWhereClauseQueryFormat = " AND YearMonthWeekDay LIKE '%_{0} Year%' ";
	public const string GregorianMonthsWhereClauseQueryFormat = " AND YearMonthWeekDay LIKE '%_{0} Month%' ";
	public const string GregorianWeeksWhereClauseQueryFormat = " AND YearMonthWeekDay LIKE '%_{0} Week%' ";	
	public const string GregorianDaysWhereClauseQueryFormat = " AND YearMonthWeekDay LIKE '%_{0} Day%' ";		
}
