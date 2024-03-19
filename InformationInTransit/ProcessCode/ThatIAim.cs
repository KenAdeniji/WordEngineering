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
	/*
		2023-10-02T10:22:00...2023-10-02T10:32:00
					filenameLike == "" ? "" : " AND Filename LIKE '%" + filenameLike + "%' ",
					commentaryLike == "" ? "" : " AND Commentary LIKE '%" + commentaryLike + "%' ",
					scriptureReferenceLike == "" ? "" : " AND ScriptureReference LIKE '%" + scriptureReferenceLike + "%' ",
					uriLike == "" ? "" : " AND URI LIKE '%" + uriLike + "%' ",
		2023-10-03T05:58:00 Duplicates only?
		2023-10-03T07:35:00	http://stackoverflow.com/questions/2949858/how-to-copy-only-the-columns-in-a-datatable-to-another-datatable
		2023-10-03T07:49:00	http://stackoverflow.com/questions/8844674/how-to-round-to-the-nearest-whole-number-in-c-sharp
		2023-10-03T08:16:00	http://stackoverflow.com/questions/12642049/how-to-add-new-datarow-into-datatable
		2023-10-03T07:35:00...2023-10-03T08:26:00 Duplicates only? Code complete.
		2023-10-03T08:33:00	Replace ZniOut with ZniOet.
		2023-10-03T08:45:00	http://stackoverflow.com/questions/12025012/simple-way-to-copy-or-clone-a-datarow
					 duplicatesOnlyDataTable.ImportRow(dataRowCurrent);
					 duplicatesOnlyDataTable.ImportRow(dataRowNext);
					 2021-08-17T15:15:00 Janel Garvin, linkedin.com/in/janel-garvin-0b650 Evans Data Corporation. Santa Cruz
		2023-10-03T07:35:00...2023-10-03T09:05:00 Duplicates only? Code complete. Debug complete.
		Ben Forta. Forta.com. Lead and Lag. NaturalOccurringSequence.
	*/
	///<summary>
	///	2023-10-01T14:18:00 That I aim.
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
			decimal zni,
			bool	duplicatesOnly
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
					filenameLike == "" ? "" : " AND Filename LIKE '%" + filenameLike + "%' ",
					commentaryLike == "" ? "" : " AND Commentary LIKE '%" + commentaryLike + "%' ",
					scriptureReferenceLike == "" ? "" : " AND ScriptureReference LIKE '%" + scriptureReferenceLike + "%' ",
					uriLike == "" ? "" : " AND URI LIKE '%" + uriLike + "%' ",
					contactIDsIn == "" ? "" : " AND ContactID IN (" + contactIDsIn + ") ",
					hisWordIDsIn == "" ? "" : " AND HisWordID IN (" + hisWordIDsIn + ") ",
					fromUntilFirst == false ? "" : " AND FromUntilFirst = 1 "
				),
				System.Data.CommandType.Text,
				DataCommand.ResultType.DataTable
			);
			
			if (duplicatesOnly == false)
			{	
				return dataTable;
			}
			
			DataTable duplicatesOnlyDataTable = dataTable.Clone();
			
			DataRow dataRowCurrent, dataRowNext;
			
			int zniOetCurrent, zniOetNext;
			
			for
			(
				int dataTableRowIndex = 0,
					dataTableRowCount = dataTable.Rows.Count
				;
				dataTableRowIndex < dataTableRowCount - 1;
				dataTableRowIndex++
			)
			{
				dataRowCurrent = dataTable.Rows[dataTableRowIndex];
				if (dataTableRowIndex == 0)
				{
					continue;
				}
				dataRowNext = dataTable.Rows[dataTableRowIndex + 1];
				zniOetCurrent = (int) ( Math.Round( (decimal) dataRowCurrent["ZniOet"], 0 ) );
				zniOetNext = (int) ( Math.Round( (decimal) dataRowNext["ZniOet"], 0 ) );
				if ((zniOetCurrent == zniOetNext) || (zniOetCurrent == 100 - zniOetNext))
				{
					 duplicatesOnlyDataTable.ImportRow(dataRowCurrent);
					 duplicatesOnlyDataTable.ImportRow(dataRowNext);
				}		
			}
			
			return duplicatesOnlyDataTable;
			
		}	
		
		public const string QueryStatement = @"
			SELECT *
			FROM WordEngineering..APass_View
			WHERE
				APassID BETWEEN {0} AND {1}
			AND	DatedFrom BETWEEN '{2}' AND '{3}'
			AND	DatedIntermission BETWEEN '{4}' AND '{5}'
			AND	DatedUntil BETWEEN '{6}' AND '{7}'
			{8}
			{9}
			{10}
			{11}
			{12}
			{13}
			{14}
			ORDER BY APassID DESC
		";
	}
}
