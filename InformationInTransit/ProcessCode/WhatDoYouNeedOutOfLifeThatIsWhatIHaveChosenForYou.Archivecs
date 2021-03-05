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
		2021-02-13 18:02:14.413	What do you need out of life; that is what I have chosen for you? 
		Called Eric mistakenly Eddie. Called Phoo mistakenly Pee. 
		2021-02-15T15:21:00	Created.
		Pauline Epistles, 2 Corinthians 11:2. 
		1089 - 1047 = 42. 1133 - 1047 = 86. 42 / 86 = 0.48837209302325581395348837209302. 
		He has to be on his own.
		28992 - 27932 = 1060. 29964 - 27932 = 2032. 1060 / 2032 = 0.52165354330708661417322834645669. 
		0.48837209302325581395348837209302 ... 0.52165354330708661417322834645669 = 0.03328145028383080021973997436367 Albertsons Lucky, Charter Square, Parking lot, North East shopping cart.
		2021-02-25T13:12:00 Updated.
		Pentateuch. Numbers 14:16.
		131 - 1 = 130. 187 - 1 = 186. 130 / 186 = 0.6989247311827956989247311827957.
		5852 - 1 = 5851. 4125 - 1 = 4124. 4124 / 5851 = 0.70483678003760041018629294137754.
		0.70483678003760041018629294137754 - 0.6989247311827956989247311827957 = 0.00591204885480471126156175858184 
	*/
    public static partial class WhatDoYouNeedOutOfLifeThatIsWhatIHaveChosenForYou
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

		public static void BuildBookGroupParts
		(
			ref	DataSet	resultSet,
				String	bibleBookGroup
		)
		{
			StringBuilder sbParseBibleBookGroup = BibleWordHelper.ParseBibleBookGroup(bibleBookGroup);
			
			DataTable minMaxTable = (DataTable) DataCommand.DatabaseCommand
			(
				String.Format
				(
					QueryFormatBibleBookGroups,
					QuerySource,
					sbParseBibleBookGroup
				),
				CommandType.Text,
				DataCommand.ResultType.DataTable
			);

			int chapterIDSequenceMinimum = (int) minMaxTable.Rows[0]["ChapterIDSequenceMinimum"];
			int chapterIDSequenceMaximum = (int) minMaxTable.Rows[0]["ChapterIDSequenceMaximum"];
			int chapterIDSequenceRange = chapterIDSequenceMaximum - chapterIDSequenceMinimum;

			int verseIDSequenceMinimum = (int) minMaxTable.Rows[0]["VerseIDSequenceMinimum"];
			int verseIDSequenceMaximum = (int) minMaxTable.Rows[0]["VerseIDSequenceMaximum"];
			int verseIDSequenceRange = verseIDSequenceMaximum - verseIDSequenceMinimum;
		
			foreach(DataTable dataTable in resultSet.Tables)
			{
				
				dataTable.Columns.Add("ChapterIDPercentage", typeof(double)); 
				dataTable.Columns.Add("VerseIDPercentage", typeof(double)); 
				dataTable.Columns.Add("ChapterVerseIDPercentage", typeof(double), "VerseIDPercentage - ChapterIDPercentage");
				
				foreach(DataRow dataRow in dataTable.Rows)
				{
					dataRow["ChapterIDPercentage"] = (double) 
					(
						100.0 * ((int)dataRow["ChapterIDSequence"] - chapterIDSequenceMinimum) / chapterIDSequenceRange
					);
					dataRow["VerseIDPercentage"] = (double) 
					(
						100.0 * ((int)dataRow["VerseIDSequence"] - verseIDSequenceMinimum) / verseIDSequenceRange
					);
				}
			}	
		}	
		
		public static DataSet Query
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
			
			String columnList = BuildColumnList(null, bibleVersion);

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
			
			BuildBookGroupParts
			(
				ref	resultSet,
					bibleBookGroup
			);
			
			return resultSet;
		}

		public const String DefaultColumnsPrefix = "ScriptureReference, ChapterIDSequence, VerseIDSequence";
		public const String DefaultScriptureReference = "Genesis - Revelation";
		
		public const String QuerySource	= "Bible..Scripture_View";
		public const String QueryFormat = @"
			SELECT {0}  
			FROM {1} WHERE {2} ORDER BY BookID, ChapterID, VerseID;
		";
		
		public const String QueryFormatBibleBookGroups = @"
			SELECT 
				MIN(ChapterIDSequence) AS ChapterIDSequenceMinimum,
				MAX(ChapterIDSequence) AS ChapterIDSequenceMaximum,
				MIN(VerseIDSequence) AS VerseIDSequenceMinimum,
				MAX(VerseIDSequence) AS VerseIDSequenceMaximum
			FROM {0} WHERE {1}
		";
    }
}
