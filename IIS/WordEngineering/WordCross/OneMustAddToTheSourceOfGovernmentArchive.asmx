<%@ WebService Language="C#" Class="OneMustAddToTheSourceOfGovernmentWebService" %>

using System;
using System.Data;
using System.Numerics;
using System.Web;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Web.Script.Services;

using Newtonsoft.Json;

using System.Data;
using System.Data.Odbc;
using System.Data.SqlClient;

using Newtonsoft.Json;

using InformationInTransit.DataAccess;
using InformationInTransit.ProcessCode;
using InformationInTransit.UserInterface;

///<summary>
///	2022-06-15T22:57:00 Created.
///	2022-06-16T17:41:00	http://stackoverflow.com/questions/4135317/make-first-letter-of-a-string-upper-case-with-maximum-performance
///	2022-06-17T09:05:00 StringBuilder 	sbExpression = new StringBuilder(" 1 = 1 ");
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class OneMustAddToTheSourceOfGovernmentWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query
	(
		string	scriptureReference,
		string	bibleVersion,
		string	bibleWord,
		string	firstOccurrenceScriptureReference,
		string	lastOccurrenceScriptureReference,
		int		frequencyOfOccurrenceFrom,
		int		frequencyOfOccurrenceUntil,
		int		wordIDFrom,
		int		wordIDUntil
	)
    {
		String[] 	scriptureReferenceSubset = null;
		DataSet 	result = new DataSet();

		DataTable workTable = OneMustAddToTheSourceOfGovernmentHelper.Extract
		(
				scriptureReference,
			ref	scriptureReferenceSubset,
			ref result,
				bibleVersion,
				bibleWord
		);
		
		StringBuilder 	sbExpression = new StringBuilder(" 1 = 1 ");
		
		/*
		String			currentCondition;
		String			variableName;
		String			variableValue;
		
		foreach( String condition in StringConditions )
		{
			if ( !String.IsNullOrEmpty( condition ) )
			{
				if ( sbExpression.Length > 0 )
				{
					sbExpression.Append( " AND " );
				}	

				variableName = condition[0].ToString().ToUpper() + condition.Substring(1);
				variableValue = condition;
				
				currentCondition = StringTemplate
					.Replace("{variableName}", variableName)
					.Replace("{variableValue}", variableValue);
					
				currentCondition = string.Format
				(
					"{0} LIKE '%{1}%'",
					variableName,
					variableValue
				);
				
				currentCondition = variableName + " LIKE '%" + variableValue + "%'";
				sbExpression.Append( currentCondition );
			}
		}
		return sbExpression.ToString();
		*/ 
		
		if ( !String.IsNullOrEmpty( bibleWord ) )
		{
			sbExpression.Append( " AND BibleWord LIKE '%" + bibleWord + "%'" );
		}

		if ( !String.IsNullOrEmpty( firstOccurrenceScriptureReference ) )
		{
			sbExpression.Append( " AND FirstOccurrenceScriptureReference LIKE '%" + firstOccurrenceScriptureReference + "%'" );
		}

		if ( !String.IsNullOrEmpty( lastOccurrenceScriptureReference ) )
		{
			sbExpression.Append( " AND LastOccurrenceScriptureReference LIKE '%" + lastOccurrenceScriptureReference + "%'" );
		}

		if ( frequencyOfOccurrenceFrom >= 1 )
		{
			sbExpression.Append( " AND FrequencyOfOccurrence >= " + Convert.ToString( frequencyOfOccurrenceFrom ) );
		}

		if ( frequencyOfOccurrenceUntil >= 1 )
		{
			sbExpression.Append( " AND FrequencyOfOccurrence <= " + Convert.ToString( frequencyOfOccurrenceUntil ) );
		}
	
		if ( wordIDFrom >= 1 )
		{
			sbExpression.Append( " AND WordID >= " + Convert.ToString( wordIDFrom ) );
		}

		if ( wordIDUntil >= 1 )
		{
			sbExpression.Append( " AND WordID <= " + Convert.ToString( wordIDUntil ) );
		}

		DataRow[] dr = workTable.Select(sbExpression.ToString());
		DataTable dt1 = dr.CopyToDataTable();
		
		string json = JsonConvert.SerializeObject(dt1, Formatting.Indented);
		return json;
    }
	
	public static readonly String[] StringConditions = new String[] 
	{ 
		"bibleWord",
		"firstOccurrenceScriptureReference",
		"lastOccurrenceScriptureReference"
	};
	
	String StringTemplate = "{variableName} LIKE '%{variableValue}%'";
}
	
