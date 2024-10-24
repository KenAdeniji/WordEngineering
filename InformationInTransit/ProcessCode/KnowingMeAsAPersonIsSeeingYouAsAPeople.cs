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
using System.Collections.ObjectModel;
using System.Collections.Specialized;

using System.Data.SqlClient;
using System.Text;
using System.Text.RegularExpressions;

using System.Globalization;
using System.Threading;

using InformationInTransit.DataAccess;
using InformationInTransit.ProcessLogic;

namespace InformationInTransit.ProcessCode
{
	///<summary>
	///	2018-03-21 	Created.	First and last letters.
	///</summary>
	public partial class KnowingMeAsAPersonIsSeeingYouAsAPeople
	{
		public static void Main(String[] argv)
		{
			String[] scriptureReferenceSubset = null;
			DataSet result = new DataSet();
		}
		
		public static void Query
		(
				string		bibleVersion,
			ref DataSet 	result,			
				string 		scriptureReference,
			ref String[] 	scriptureReferenceSubset
		)
		{
			ScriptureReferenceHelper.Process
            (
                scriptureReference,
                ref scriptureReferenceSubset,
                ref result,
                BibleQueryFormat,
                "KingJamesVersion"
            );
			result.RemoveColumn("VerseText");
		}
		
		public const string BibleQueryFormat = @"SELECT ScriptureReference " +
												", VerseText " +
												", LEFT(VerseText, 1) AS FirstLetter" +
												", LEFT(Right(VerseText, 2), 1) AS LastLetter" +												
												"FROM Bible..Scripture_View WHERE {0} ORDER BY bookId, chapterId, verseId;";
	}
}
