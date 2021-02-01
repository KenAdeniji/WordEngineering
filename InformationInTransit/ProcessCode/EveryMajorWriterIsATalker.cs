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
		2021-01-31	Created.	https://stackoverflow.com/questions/43502193/find-longest-word-in-string-with-sql
	*/
	/*
		public const String QueryFormat = //SELECT {0} FROM {1} WHERE {2} ORDER BY BookID, ChapterID, VerseID;
		@"
Select A.{0}
      ,Result = B.RetVal
 From  {1} A
 Cross Apply (
                Select Top 1 with ties *
                 From  (
                        Select RetSeq = Row_Number() over (Order By (Select null))
                              ,RetVal = LTrim(RTrim(B.i.value('(./text())[1]', 'varchar(max)')))
                        From  
						(Select x = Cast('<x>' + replace((Select replace(A.{3},' ','§§Split§§') as [*] For XML Path('')),'§§Split§§','</x><x>')+'</x>' as xml).query('.')) as A 
                        Cross Apply x.nodes('x') AS B(i)
                       ) B1
                 Order by Dense_Rank() over (Order by Len(RetVal) Desc)
             ) B
 WHERE {2} ORDER BY BookID, ChapterID, VerseID;			 
	*/	
    public static partial class EveryMajorWriterIsATalker
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
					sqlWhereClause,
					bibleVersion
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

		public const String DefaultColumnsPrefix = "ScriptureReference";
		public const String DefaultScriptureReference = "Genesis - Revelation";
		
		public const String QuerySource	= "Bible..Scripture_View";

		public const String QueryFormat = //SELECT {0} FROM {1} WHERE {2} ORDER BY BookID, ChapterID, VerseID;
		@"
			;WITH CTE
			(
				VerseIDSequence,
				Word,
				WordLength
			)
			AS
			(
				SELECT 
					VerseIDSequence,
					tblV.value,
					LEN(tblV.value)
				FROM {1}
				CROSS APPLY STRING_SPLIT({1}.{3}, ' ') AS tblV  
				WHERE {2}
			)	
		
			SELECT 	{0}, 
					Word,
					WordLength
			FROM CTE JOIN {1} ON CTE.VerseIDSequence = {1}.VerseIDSequence
			WHERE 
			    cte.wordLength =
                (
                    select max(cteInner.wordLength)
                    from   cte cteInner
                    where  cte.VerseIDSequence = cteInner.VerseIDSequence
                )
			ORDER BY {1}.VerseIDSequence	
		";
    }
}
