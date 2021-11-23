<%@ WebService Language="C#" Class="WhereDidHeSearchForSufficiencyOfUseWebService" %>

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
///	2021-11-22T12:15:00 	Created.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class WhereDidHeSearchForSufficiencyOfUseWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query
	(
		int	alphabetSequenceIndex,
		String	bibleVersion
	)
    {
		String	sqlStatement = String.Format
		(
			SQLSelectFormat,
			alphabetSequenceIndex,
			bibleVersion
		);
		
        DataSet resultSet = (DataSet) DataCommand.DatabaseCommand
		(
			sqlStatement,
			System.Data.CommandType.Text,
			DataCommand.ResultType.DataSet
		);
		
		string json = JsonConvert.SerializeObject(resultSet, Formatting.Indented);
		return json;
    }

	public const String SQLSelectFormat = 
		" SELECT ScriptureReference, {1} AS SacredText " +
		" FROM Bible..Scripture_View " +
		" WHERE WordEngineering.dbo.udf_AlphabetSequenceIndex({1}) = {0} " +
		" ORDER BY VerseIDSequence; " +
		" SELECT * " +
		" FROM Bible..Exact " +
		" WHERE AlphabetSequenceIndex = {0} " +
		" ORDER BY ExactID; " +
		" SELECT HisWordID, Dated, Word, Commentary " +
		" FROM WordEngineering..HisWord_View " +
		" WHERE AlphabetSequenceIndex = {0} " +
		" ORDER BY Dated DESC; " +
		" SELECT RememberID, DatedFrom, DatedUntil, Commentary " +
		" FROM WordEngineering..Remember_View " +
		" WHERE FromUntil = {0} " +
		" ORDER BY RememberID DESC; "
		;
}
