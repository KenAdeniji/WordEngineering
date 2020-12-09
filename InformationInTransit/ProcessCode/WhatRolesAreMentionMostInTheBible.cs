using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

using System.Text;

using InformationInTransit.DataAccess;
using InformationInTransit.ProcessLogic;

/*
	2019-02-09	Created.
*/
namespace InformationInTransit.ProcessCode
{ 
	public static partial class WhatRolesAreMentionMostInTheBible
	{
		public static DataSet Query
		(
			string 	bibleVersion,
			string	word
		)
		{
			string[] words = word.Split
			(
				BibleWordHelper.SplitSeparator,
				StringSplitOptions.RemoveEmptyEntries
			);
			StringBuilder sqlStatement = new StringBuilder();
			foreach(String currentWord in words)
			{
				if (sqlStatement.Length > 0)
				{
					sqlStatement.Append(" UNION ");
				}
				sqlStatement.AppendFormat(SelectFormat, currentWord, bibleVersion);
			}
//return sqlStatement.ToString();			
			DataSet dataSet = (DataSet)DataCommand.DatabaseCommand
            (
                sqlStatement.ToString(),
                CommandType.Text,
                DataCommand.ResultType.DataSet
            );
			return dataSet;
		}
		
		public const string SelectFormat = 
			@"	SELECT
						'{0}'	AS	Word,
						COUNT(*) AS Counter,
						STUFF((
							SELECT ', ' + ScriptureReference FROM Bible..Scripture_View
							WHERE 
							{1} LIKE '%[^a-z]{0}[^a-z]%'
							FOR XML PATH(''), TYPE).value('.[1]', 'nvarchar(max)'), 1, 2, '')	AS	ScriptureReferences
				FROM	
						Bible..Scripture_View AS BibleBook
				WHERE
			{1} LIKE '%[^a-z]{0}[^a-z]%'
			";
    }
}
