﻿using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Text.RegularExpressions;

using InformationInTransit.DataAccess;
using InformationInTransit.ProcessLogic;

namespace InformationInTransit.ProcessLogic
{
	/*
		2021-01-10T12:00:00 ...	2021-01-10T13:34:00 Created.
	*/
	public static partial class CouldYouRecoverTheTerritory
	{
		public static StringBuilder Query
        (
            string logic,
            string question
        )
		{
			string[] keywords = new string[1];
			if (logic == "phrase")
			{
				keywords = new String[] { question };
			}
			else
			{
				keywords = Split(question);
			}	
			
			StringBuilder sqlStatement = new StringBuilder();
			StringBuilder sqlWhereClause = new StringBuilder();
			
			for(int index = 0, count = keywords.Length; index < count; ++index)
			{
				keywords[index] = keywords[index].Trim();
				if (index > 0)
				{
					sqlWhereClause.Append(' ' + logic + ' ');
				}
				sqlWhereClause.AppendFormat(WhereFormat, keywords[index]);
			}
			
			if (sqlWhereClause.Length > 0)
			{
				sqlWhereClause.Insert(0, " WHERE ");
			}
	
			sqlStatement.AppendFormat(QueryFormat, sqlWhereClause);
	
			return sqlStatement;
		}

		public static string[] Split
        (
			string sentence
        )
		{
			string[] words = sentence.Split(SplitSeparator, StringSplitOptions.RemoveEmptyEntries);
			return words;
		}
		
		public static readonly char[] SplitSeparator = new Char [] {' ', ',', '.', ':', ';', '(', ')', '?', '!'};
		
		public const string QueryFormat = @"
			SELECT  RememberID, DatedFrom, DatedUntil, Filename, Commentary, ScriptureReference, ContactId, URI, HisWordID, FromUntilFirst, FromUntil, ToFro, YearMonthWeekDay
			FROM 	Remember_View
			{0}
			ORDER BY RememberID DESC
		";
		public const string WhereFormat = " FromUntil LIKE '%{0}%' ";
	}
}
