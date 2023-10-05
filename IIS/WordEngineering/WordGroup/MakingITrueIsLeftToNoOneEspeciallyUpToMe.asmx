<%@ WebService Language="C#" Class="MakingITrueIsLeftToNoOneEspeciallyUpToMeWebService" %>

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

using Newtonsoft.Json;

using InformationInTransit.DataAccess;
using InformationInTransit.ProcessLogic;
using InformationInTransit.UserInterface;

///<summary>
///	2020-09-09 	Created.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class MakingITrueIsLeftToNoOneEspeciallyUpToMeWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query(String bibleVersion)
    {
		StringBuilder sb = new StringBuilder();
		
		for
		(
			int rowIndex = 0,
			rowCount = JaggedArray.Length;
			rowIndex < rowCount;
			++rowIndex
		)
		{
			if (sb.Length > 0)
			{
				sb.Append(" UNION ");
			}
			sb.AppendFormat
			(
				SelectQueryFormat,
				bibleVersion,
				JaggedArray[rowIndex][0],
				JaggedArray[rowIndex][1],
				JaggedArray[rowIndex][2]
			);
		}
		
		DataTable result = (DataTable) DataCommand.DatabaseCommand
		(
			sb.ToString(),
			System.Data.CommandType.Text,
			DataCommand.ResultType.DataTable
		);
		
		string json = JsonConvert.SerializeObject(result, Formatting.Indented);
		return json;
    }
	
	public const string SelectQueryFormat = @"
		SELECT
			'{1}' AS PastTense,		
			(
				SELECT 
					COUNT(*) 
				FROM Bible..Scripture
				WHERE 
					{0} LIKE '%{1}%'
			) AS PastTenseCount,
			'{2}' AS PresentTense,
			(
				SELECT 
					COUNT(*) 
				FROM Bible..Scripture
				WHERE 
					{0} LIKE '%{2}%'
			) AS PresentTenseCount,
			'{3}' AS PresentProgressiveTense,
			(
				SELECT 
					COUNT(*) 
				FROM Bible..Scripture
				WHERE 
					{0} LIKE '%{3}%'
			) AS PresentProgressiveTenseCount
	";
	
	String[][] JaggedArray =
	{ 
		new String[] { "Know", "Knowing", "Knew" },
		new String[] { "Say", "Saying", "Said" },
		new String[] { "See", "Seeing", "Saw" },		
		new String[] { "Write", "Writing", "Wrote" }
	};	
}
