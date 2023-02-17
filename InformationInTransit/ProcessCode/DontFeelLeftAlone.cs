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
using InformationInTransit.ProcessCode;
using InformationInTransit.ProcessLogic;

namespace InformationInTransit.ProcessCode
{
	///<summary>
	///	2023-02-14T18:11:00 Created.
	///	2023-02-14T18:11:00	Remember automation? Let the user restrict by the Dated, ContactID, ScriptureReference? They have to do new work.
	/// 2023-02-14T18:45:00	http://stackoverflow.com/questions/2959161/convert-string-to-int-array-using-linq
	///</summary>
	public class DontFeelLeftAlone
	{
		public static DataSet Query
		(
			String		contactID,
			DateTime	dated,
			String		scriptureReference
		)
		{
			DataSet resultSet = new DataSet();
			int[] contactIDs = contactID.Split(ScriptureReferenceHelper.SubsetSeparator).Select(s => int.TryParse(s, out int n) ? n : 0).ToArray();
			String[] scriptureReferences = scriptureReference.Split
			(
				ScriptureReferenceHelper.SubsetSeparator,
				StringSplitOptions.RemoveEmptyEntries 
			);
			StringBuilder sbScriptureReferenceChapters = new StringBuilder();
			StringBuilder sbScriptureReferenceVerses = new StringBuilder();
			if (!String.IsNullOrEmpty(scriptureReference))
			{	
				String scriptureReferenceCurrent = "";
				for
				(
					int scriptureReferenceIndex = 0, scriptureReferenceLength = scriptureReferences.Length;
					scriptureReferenceIndex < scriptureReferenceLength;
					scriptureReferenceIndex++
				)	
				{
					scriptureReferenceCurrent = scriptureReferences[scriptureReferenceIndex].Trim();
					if (scriptureReferenceCurrent.IndexOf(':') > -1)
					{
						if (sbScriptureReferenceVerses.Length == 0)
						{
							sbScriptureReferenceVerses.Append(" OR ScriptureReference IN ( ");
						}
						else
						{
							sbScriptureReferenceVerses.Append(", ");
						}
						sbScriptureReferenceVerses.AppendFormat
						(
							"'{0}'",
							scriptureReferenceCurrent
						);
					}
					else
					{
						if (sbScriptureReferenceChapters.Length == 0)
						{
							sbScriptureReferenceChapters.Append(" OR (");
						}
						else
						{
							sbScriptureReferenceChapters.Append(" OR ");
						}
						sbScriptureReferenceChapters.AppendFormat
						(
							"ScriptureReference LIKE '%{0}%'",
							scriptureReferenceCurrent
						);
					}
				}	
				if (sbScriptureReferenceVerses.Length > 0)
				{
					sbScriptureReferenceVerses.Append(" ) ");
				}		
				if (sbScriptureReferenceChapters.Length > 0)
				{
					sbScriptureReferenceChapters.Append(" ) ");
				}		
			}	
			string queryStatement = String.Format
			(
				QueryFormat,
				dated,
				string.Join(",", contactIDs.Select(x => x.ToString()).ToArray()),
				sbScriptureReferenceVerses.ToString(),
				sbScriptureReferenceChapters.ToString()
			);
			resultSet = (DataSet) DataCommand.DatabaseCommand
			(
				queryStatement,
				CommandType.Text,
				DataCommand.ResultType.DataSet
			);
			return resultSet;
		}
		
        public const string QueryFormat = 
		@"
			SELECT ContactID, CONVERT(varchar, Dated, 23) AS Dated, DATEDIFF(day, Dated, '{0}') AS FromUntil, FirstName, OtherName, LastName, Company
			FROM 	WordEngineering..Contact
			WHERE	ContactID IN ({1})
			ORDER BY ContactID, Dated
			;
			SELECT ContactID, CONVERT(varchar, Dated, 23) AS Dated, DATEDIFF(day, Dated, '{0}') AS FromUntil, EmailAddress AS URI
			FROM 	WordEngineering..ContactEmail
			WHERE	ContactID IN ({1})
			ORDER BY ContactID, Dated
			;
			SELECT ContactID, CONVERT(varchar, Dated, 23) AS Dated, DATEDIFF(day, Dated, '{0}') AS FromUntil, InternetAddress AS URI
			FROM 	WordEngineering..ContactURI
			WHERE	ContactID IN ({1})
			ORDER BY ContactID, Dated
			;
			SELECT ContactID, CONVERT(varchar, Dated, 23) AS Dated, DATEDIFF(day, Dated, '{0}') AS FromUntil, AddressLine1, City, State, ZipCode, Country
			FROM 	WordEngineering..StreetAddress
			WHERE	ContactID IN ({1})
			ORDER BY ContactID, Dated
			;
		SELECT CONVERT(varchar, DATEADD(Day, -Number, '{0}'), 23) AS Dated, Number AS FromUntil, ScriptureReference
			FROM 	WordEngineering..NumberSign
			WHERE	1 <> 1 {2} {3}
			ORDER BY Dated, Number
			;
		";
	}
}
