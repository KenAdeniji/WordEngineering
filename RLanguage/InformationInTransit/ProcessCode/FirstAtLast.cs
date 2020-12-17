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
	///	2018-03-19 	Created.
	///	2018-03-19	https://stackoverflow.com/questions/707610/extract-the-first-word-of-a-string-in-a-sql-server-query
	///	2018-03-20	https://www.sqlservercentral.com/Forums/Topic1230006-391-1.aspx
	///	2018-03-20	http://www.sqlteam.com/forums/topic.asp?TOPIC_ID=35252
	///</summary>
	public partial class FirstAtLast
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
                bibleVersion
            );
			result.RemoveColumn("KingJamesVersion");
		}
		
		public const string BibleQueryFormat = @"SELECT ScriptureReference " +
												", KingJamesVersion, FirstWord = Case patIndex ('%[ /-,,,;.]%', LTrim ( KingJamesVersion )) " +
												"  When 0 Then LTrim ( KingJamesVersion ) " +
												"   Else substring (LTrim ( KingJamesVersion ), 1, patIndex ('%[ /-,,,;.]%', LTrim (KingJamesVersion)) - 1)" +
												"  End " +
												", LastWord = LEFT " +
												" ( " +
												"	right( KingJamesVersion, charindex(' ',reverse( KingJamesVersion ))-1), " +
												"	LEN(right( KingJamesVersion, charindex(' ', reverse( KingJamesVersion ))-1)) - 1 " +
												" ) " +
												"FROM Bible..Scripture_View WHERE {0} ORDER BY bookId, chapterId, verseId;";
	}
}
