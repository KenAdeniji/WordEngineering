using System;
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
		2016-05-24	What is your quest of interest? Common goals. 
					Some women and males were chatting; the women are to the East.
		2016-05-25	WhatIsYourQuestOfInterestCommonGoalsHelper.cs created.
	*/
	public static partial class WhatIsYourQuestOfInterestCommonGoalsHelper
	{
		public static void Main(string[] argv)
		{
			DataSet resultSet = CommonGoals(1, 3, "bookID", BibleVersionDefault);
		}

		public static DataSet	CommonGoals
		(
			int		from,
			int		until,
			String	choice,
			String	bibleVersion
		)
		{
			DataSet dataSet = null;
			StringBuilder sqlWhereClause = new StringBuilder(" WHERE ");

			if (until < from)
			{
				until = from;
			}

			string[]	choices	= choice.Split(',');
			
			for(int choiceIndex = 0; choiceIndex < choices.Length; ++choiceIndex)
			{
				if (choiceIndex > 0)
				{
					sqlWhereClause.Append(" OR ");
				}
				
				sqlWhereClause.AppendFormat
				(
					WhereQueryFormat,
					choices[choiceIndex],
					from,
					until
				);
			}
			
			String sqlStatement = String.Format
            (
			    BibleQueryFormat,
				bibleVersion,
                sqlWhereClause
            );
			
            dataSet = (DataSet)DataCommand.DatabaseCommand
            (
                sqlStatement,
                CommandType.Text,
                DataCommand.ResultType.DataSet
            );

			//System.Console.WriteLine(sqlStatement);
			//dataSet.Tables[0].DumpDataTable();
			return dataSet;
		}
		
		public static readonly string[] Books = {"Genesis","Exodus","Leviticus","Numbers","Deuteronomy","Joshua","Judges","Ruth","1 Samuel","2 Samuel","1 Kings","2 Kings","1 Chronicles","2 Chronicles","Ezra","Nehemiah","Esther","Job","Psalms","Proverbs","Ecclesiastes","Song of Solomon","Isaiah","Jeremiah","Lamentations","Ezekiel","Daniel","Hosea","Joel","Amos","Obadiah","Jonah","Micah","Nahum","Habakkuk","Zephaniah","Haggai","Zechariah","Malachi","Matthew","Mark","Luke","John","Acts","Romans","1 Corinthians","2 Corinthians","Galatians","Ephesians","Philippians","Colossians","1 Thessalonians","2 Thessalonians","1 Timothy","2 Timothy","Titus","Philemon","Hebrews","James","1 Peter","2 Peter","1 John","2 John","3 John","Jude","Revelation"};
		public static readonly int MaxBookId = Books.Count() + 1;

		public const string BibleQueryFormat = "SELECT bookId, chapterId, verseId, verseText = {0}, verseIdSequence FROM Bible..Scripture {1} ORDER BY bookId, chapterId, verseId;";
        public const string BibleVersionDefault = "KingJamesVersion";
        public const string WhereQueryFormat = " {0} BETWEEN {1} AND {2} ";
	}
}
