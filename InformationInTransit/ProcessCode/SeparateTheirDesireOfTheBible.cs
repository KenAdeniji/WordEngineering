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
		2020-11-08	Created.	
	*/
    public partial class SeparateTheirDesireOfTheBible
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
		
		public static DataSet Query
		(
				String			bibleBookGroup,
				String			bibleVersion,				
				String			bibleWord,
				String			logic,
				String			scriptureReference,
				bool			wholeWords,
			out StringBuilder 	sqlJoin,
				String			defaultColumnsPrefix
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
			
			String columnList = BuildColumnList(defaultColumnsPrefix, bibleVersion);
			
			foreach(String sqlWhereClause in sqlWhereClauses)
			{
				sqlJoin.AppendFormat
				(
					QueryFormat,
					columnList,
					QuerySource,
					sqlWhereClause
				);
			}
			
			//return resultSet;
			
			resultSet = (DataSet) DataCommand.DatabaseCommand
			(
				sqlJoin.ToString(),
				CommandType.Text,
				DataCommand.ResultType.DataSet
			);
			
			return resultSet;
		}

		public virtual String RetrieveDefaultColumnsPrefix
		{
			get { return DefaultColumnsPrefix; }
		}
	
		public static String DefaultColumnsPrefix = "ScriptureReference";
		public const String DefaultScriptureReference = "Genesis - Revelation";
		
		public const String QuerySource	= "Bible..Scripture_View";
		public const String QueryFormat = "SELECT {0} FROM {1} WHERE {2} ORDER BY BookID, ChapterID, VerseID;";
    }
}
