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
			DataTable resultTable;
			int[] contactIDs = contactID.Split(ScriptureReferenceHelper.SubsetSeparator).Select(s => int.TryParse(s, out int n) ? n : 0).ToArray();
			String[] scriptureReferences = scriptureReference.Split
			(
				ScriptureReferenceHelper.SubsetSeparator,
				StringSplitOptions.RemoveEmptyEntries 
			);
			string queryStatement = String.Format
			(
				ContactQueryFormat,
				dated,
				string.Join(",", contactIDs.Select(x => x.ToString()).ToArray())
			);
			resultTable = (DataTable) DataCommand.DatabaseCommand
			(
				queryStatement,
				CommandType.Text,
				DataCommand.ResultType.DataTable
			);
			resultSet.Tables.Add(resultTable);
			return resultSet;
		}
		
        public const string ContactQueryFormat = 
			@"SELECT ContactID, Dated, DATEDIFF(day, Dated, '{0}') AS FromUntil
			FROM 	WordEngineering..Contact
			WHERE	ContactID IN ({1})
			ORDER BY ContactID, Dated
		";
	}
}
