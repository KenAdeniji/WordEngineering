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
		2021-03-27T16:43:00 Created.
	*/
    public static partial class WhenGoodThingsHappen
    {
		public static String BuildColumnList
		(
			String 	columnsPrefix,
			String	columnsPostfix
		)
		{
			if (String.IsNullOrEmpty(columnsPrefix))
			{
				columnsPrefix = DefaultColumnsPrefix;
			}	
			if (String.IsNullOrEmpty(columnsPostfix))
			{
				columnsPostfix = ScriptureReferenceHelper.BibleVersionDefault;
			}
			return columnsPrefix + ", " + columnsPostfix;	
		}
		
		public static int Query
		(
				String			bibleBookGroup,
				String			bibleVersion,				
				String			bibleWord,
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
			int resultSet = -1;
			ScriptureReferenceHelper.BuildSql
			(
					scriptureReferenceSubsets,
				ref	sqlWhereClauses
			);
			
			StringBuilder sbParseBibleBookGroup = BibleWordHelper.ParseBibleBookGroup(bibleBookGroup);

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
					limitSQL = sbParseBibleBookGroup.ToString();
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
			
			sqlJoin = new StringBuilder();
			
			String columnList = BuildColumnList(null, bibleVersion);

			foreach(String sqlWhereClause in sqlWhereClauses)
			{
				sqlJoin.AppendFormat
				(
					QueryFormat,
					//columnList,
					QuerySource,
					sqlWhereClause,
					bibleVersion,
					bibleWord
				);
			}
			
			//return resultSet;
			
			resultSet = (int) DataCommand.DatabaseCommand
			(
				sqlJoin.ToString(),
				CommandType.Text,
				DataCommand.ResultType.Scalar
			);
			
			return resultSet;
		}

		public const String DefaultColumnsPrefix = "";
		public const String DefaultScriptureReference = "Genesis - Revelation";
		
		public const String QuerySource	= "Bible..Scripture_View";

		public const String QueryFormat = //SELECT {0} FROM {1} WHERE {2} ORDER BY BookID, ChapterID, VerseID;
		@"
			SELECT COUNT(*)	
			FROM {0} 
			WHERE {1} 
		";
    }
}
