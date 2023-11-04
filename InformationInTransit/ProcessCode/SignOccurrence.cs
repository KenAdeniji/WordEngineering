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

using InformationInTransit.DataAccess;
using InformationInTransit.ProcessCode;
using InformationInTransit.ProcessLogic;

namespace InformationInTransit.ProcessCode
{
	/*
		2023-11-03T08:10:00 
			Mo tun fi se border.
			I made it border, again.
			07:02 Urine. I am at 99 Ranch Market and doing wordprocessing.
				I printed some copies of my work on paper, but I will have to find my pages.
				Out of the 3 1/2 floppy disks I sought for a document storage.
				I found out that Tony of Albertsons Lucky is being carried eastward into 99 Ranch Market and he is pronounced dead.
				Joyce Sherman drove us to the intersection of Paseo Padre Parkway and Siward Drive.
				08:38 When is my work done? Buki asked father figure on the 3rd occasion for 400 to repair his vehicle. 
				08:41 Dizzy sleepy. During the night dream I remembered that 2 male siblings and fighting. 	
				SELECT 
					ScriptureReference,
					KingJamesVersion
				FROM
					Bible..Scripture_View
				WHERE
						KingJamesVersion like '%third day%'
					OR	KingJamesVersion like '%third week%'
					OR	KingJamesVersion like '%third month%'
					OR	KingJamesVersion like '%third year%'
					OR	KingJamesVersion like '%third time%'
				ORDER BY
					VerseIDSequence ASC
			DayTime? 
			09:10 SignOccurrence? 
			Some of the destination... that have witness Jewish diaspora...do not want this experience, again. convert integer to ordinal, cardinal?
		2023-11-04T06:25:00 Created.
		2023-11-04T06:25:00 ... 2023-11-04T07:11:00 Code complete.
		2023-11-04T07:11:00 ... 2023-11-04T08:11:00 Code complete.		
	*/
	public partial class SignOccurrence
	{
		public static DataTable Query
		(
			string	bibleWord,
			string	bibleVersion
		)
		{
			StringBuilder sb = new StringBuilder();
			if (bibleWord == "")
			{
				foreach(string currentSignUnit in SignUnits)
				{
					if (sb.Length > 0)
					{
						sb.Append(" OR ");
					}
					sb.AppendFormat
					(	
						"{0} LIKE '%{1}%' ",
						bibleVersion,
						currentSignUnit
					);
				}	
			}
			else
			{
				long bibleNumber = Convert.ToInt64(bibleWord);
				string bibleNumberOrdinal = InformationInTransit.ProcessCode.NumberExtension.ConvertNumbertoWordsFirst
				(
					bibleNumber
				);
				string bibleNumberCardinal = InformationInTransit.ProcessCode.NumberExtension.ConvertNumbertoWords
				(
					bibleNumber
				);
				foreach(string currentSignUnit in SignUnits)
				{
					if (sb.Length > 0)
					{
						sb.Append(" OR ");
					}
					sb.AppendFormat
					(	
						"{0} LIKE '%{1} {2}%' ",
						bibleVersion,
						bibleNumberOrdinal,
						currentSignUnit
					);
					sb.Append(" OR ");
					sb.AppendFormat
					(	
						"{0} LIKE '%{1} {2}%' ",
						bibleVersion,
						bibleNumberCardinal,
						currentSignUnit
					);
				}	
			}				

			string sqlStatement = String.Format
			(
				SqlStatementFormat,
				bibleVersion,
				sb.ToString()
			);	

			DataTable dataTable = (DataTable) DataCommand.DatabaseCommand
			(
				sqlStatement,
				CommandType.Text,
				DataCommand.ResultType.DataTable
			);

			return dataTable;
		}	
		
		public const String SqlStatementFormat =
		@"
			SELECT 
				ScriptureReference,
				{0} VerseText
			FROM
				Bible..Scripture_View
			WHERE
				{1}
			ORDER BY
				VerseIDSequence ASC
		";
		
		public static readonly string[] SignUnits = { "time", "hour", "day", "week", "month", "year" }; 		
	}
}
