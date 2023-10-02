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
	///	2023-10-01T14:18:00 That I aim.
	///		
	///</summary>
	public partial class ThatIAim
	{
		public static DataTable Query
		(
			int aPassIDBegin,
			int	aPassIDEnd,
			DateTime	datedFromBegin,
			DateTime	datedFromEnd,
			DateTime	datedIntermissionBegin,
			DateTime	datedIntermissionEnd,
			DateTime	datedUntilBegin,
			DateTime	datedUntilEnd,
			string	filenameLike,
			string	commentaryLike,
			string	scriptureReferenceLike,
			string	uriLike,
			string	contactIDsIn,
			string	hisWordIDsIn,
			bool	fromUntilFirst,
			decimal zni
		)
		{
			DataTable dataTable = (DataTable) DataCommand.DatabaseCommand
			(
				String.Format
				(
					QueryStatement,
					aPassIDBegin,
					aPassIDEnd,
					datedFromBegin,
					datedFromEnd,
					datedIntermissionBegin,
					datedIntermissionEnd,
					datedUntilBegin,
					datedUntilEnd,
					filenameLike,
					commentaryLike,
					scriptureReferenceLike,
					uriLike,
					contactIDsIn == "" ? "" : " AND ContactID IN (" + contactIDsIn + ") ",
					hisWordIDsIn == "" ? "" : " AND HisWordID IN (" + hisWordIDsIn + ") "					
				),
				System.Data.CommandType.Text,
				DataCommand.ResultType.DataTable
			);
				
			return dataTable;
		}	
		
		public const string QueryStatement = @"
			SELECT *
			FROM WordEngineering..APass_View
			WHERE
				APassID BETWEEN {0} AND {1}
			AND	DatedFrom BETWEEN '{2}' AND '{3}'
			AND	DatedIntermission BETWEEN '{4}' AND '{5}'
			AND	DatedUntil BETWEEN '{6}' AND '{7}'
			AND	Filename LIKE '%{8}%'
			AND	Commentary LIKE '%{9}%'
			AND	ScriptureReference LIKE '%{10}%'
			AND	URI LIKE '%{11}%'
			{12}
			{13}			
			ORDER BY APassID DESC
		";
	}
}
