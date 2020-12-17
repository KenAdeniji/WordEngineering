using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;

using InformationInTransit.ProcessLogic;
using InformationInTransit.DataAccess;	

namespace InformationInTransit.ProcessCode
{
	/*
		2020-11-21	Created.	
	*/
    public static partial class SheWalkedTowardInFourDays
    {
		public static DataSet Query
		(
				String			bibleGroup,		
				String			bibleWord,
				String			bibleVersion,
				String			limitChosen,
				String			logic,
				String			scriptureReference,
				bool			wholeWords,
			out StringBuilder 	sqlJoin
		)
		{
			if (bibleVersion == "")
			{
				bibleVersion = ScriptureReferenceHelper.BibleVersionDefault;
			}	
			String[] bibleVersions = bibleVersion.Split(',');
			if (scriptureReference == "")
			{
				scriptureReference = DefaultScriptureReference;
			}	
			String[] 	scriptureReferenceSubset = scriptureReference.Split
			(
				ScriptureReferenceHelper.SubsetSeparator
			);
			List<ScriptureReferenceHelper.ScriptureReferenceSubset> 
				scriptureReferenceSubsets = ScriptureReferenceHelper.Parse
			(
				scriptureReferenceSubset
			);
			List<String>	sqlWhereClauses	= new List<String>();
			DataSet resultSet = new DataSet();
			ScriptureReferenceHelper.BuildSql
			(
					scriptureReferenceSubsets,
				ref	sqlWhereClauses
			);
			
			StringBuilder parseLimit = BibleWordHelper.ParseLimit(limitChosen);

			String[] keywords = new String[] { bibleWord };

			String limitSQL = "";
			String logicSQL = "";
			for 
			(
				int indexWhereClause = 0, countWhereClause = sqlWhereClauses.Count;
				indexWhereClause < countWhereClause;
				++indexWhereClause
			)	
			{
				if (sqlWhereClauses[indexWhereClause] != "")
				{
					limitSQL = parseLimit.ToString();
					if (limitSQL != "")
					{
						limitSQL = " AND ( " + limitSQL + " ) ";
					}
					
					logicSQL = BibleWordHelper.PrepareSqlStatement
					(
						logic,
						bibleWord,
						wholeWords,
						out keywords,
						bibleVersions
					).ToString();	

					if (logicSQL != "")
					{
						logicSQL = " AND ( " + logicSQL + " ) ";
					};
			
					sqlWhereClauses[indexWhereClause] += limitSQL + logicSQL;
				}	
			}
			
			StringBuilder sqlWhereJoin = new StringBuilder();
			
			foreach(String sqlWhereClause in sqlWhereClauses)
			{
				if (sqlWhereJoin.Length > 0)
				{
					sqlWhereJoin.Append(" OR ");
				}	
				sqlWhereJoin.Append(sqlWhereClause);
			}
			
			sqlJoin = new StringBuilder();
			
			sqlJoin.AppendFormat
			(
				QueryFormat,
				bibleGroup + ", COUNT(*) AS GroupCount ",
				QuerySource,
				" ( " + sqlWhereJoin.ToString() + " ) ",
				bibleGroup,
				bibleGroup
			);
			
			//return resultSet;
			
			resultSet = (DataSet) DataCommand.DatabaseCommand
			(
				sqlJoin.ToString(),
				CommandType.Text,
				DataCommand.ResultType.DataSet
			);
			
			return resultSet;
		}

		public const String DefaultScriptureReference = "Genesis - Revelation";
		
		public const String QuerySource	= "Bible..Scripture_View";
		public const String QueryFormat = "SELECT {0} FROM {1} WHERE {2} GROUP BY {3} ORDER BY {4};";
    }
}
