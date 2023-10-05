<%@ WebService Language="C#" Class="WhenDoesGodStepIntoTheAffairsOfMenWebService" %>

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

using System.Text;

using System.Linq;	

using Newtonsoft.Json;

using InformationInTransit.DataAccess;
using InformationInTransit.ProcessLogic;

///<summary>
///	2021-05-06T11:13:00 Created.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class WhenDoesGodStepIntoTheAffairsOfMenWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query
	(
		String	bibleVersion,
		String	scriptureReference
	)
    {
		string[] scriptureReferences = scriptureReference.Split
		(
			ScriptureReferenceHelper.SubsetSeparator,
			StringSplitOptions.RemoveEmptyEntries
		)
		.Select(x => x.Trim()).ToArray();
		;		
	
		string SQLStatement = String.Format
		(
			SQLStatementFormat,
			bibleVersion,
			scriptureReferences[0],
			scriptureReferences[1],
			scriptureReferences[2]
		);
		
		DataTable dataTable = (DataTable) DataCommand.DatabaseCommand
		(
			SQLStatement,
			CommandType.Text,
			DataCommand.ResultType.DataTable
		);

		string json = JsonConvert.SerializeObject(dataTable, Formatting.Indented);
		return json;
    }
	
	public const string SQLStatementFormat = 
	@"
		SELECT 	ScriptureReference,
				{0},
				VerseIDSequence
		FROM Bible..Scripture_View 
		WHERE ScriptureReference IN
		(
			'{1}',
			'{2}',
			'{3}'
		)
		ORDER BY VerseIDSequence
	";	
}
