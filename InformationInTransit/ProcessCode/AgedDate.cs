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
		2023-10-20T13:33:00 AgedDate.cs created.
		2023-10-20T13:33:00	http://learn.microsoft.com/en-us/dotnet/api/microsoft.visualbasic.dateandtime.datediff?view=net-7.0
		2023-10-20T14:09:00	http://learn.microsoft.com/en-us/dotnet/api/microsoft.visualbasic.dateandtime.dateadd?view=net-7.0
		2023-10-20T14:30:00...2023-10-20T15:07:00 Debug
			String.Format
				(
					"EXEC WordEngineering..usp_ContactMaintenanceQuery @query = '{0}'",
					word
				),	
		2023-10-20T15:05:00...2023-10-20T17:12:00 AgedDate calculated column, computed column? Expression?
		2023-10-20T17:12:00...2023-10-20T18:08:00 AgedDate calculated column, calculate.
		2023-10-20T18:08:00 Teeth.
		2023-10-20T19:11:00 Code complete.
	*/
	public class AgedDate
	{
		public static DataTable Query
		(
			string	word,
			string	unitOfDifference,
			int		valueOfDifference
		)
		{
			unitOfDifference = unitOfDifference.ToLower();
			DataTable dataTable = (DataTable) DataCommand.DatabaseCommand
			(
				String.Format
				(
					"EXEC WordEngineering..usp_ContactMaintenanceQuery @query = '{0}'",
					word
				),
				CommandType.Text,
				DataCommand.ResultType.DataTable
			);

			// Create the calculated, column.
			DataColumn agedDateColumn = new DataColumn();
			agedDateColumn.DataType = System.Type.GetType("System.DateTime");
			agedDateColumn.ColumnName = "AgedDate";
/*			
			agedDateColumn.Expression = "Microsoft.VisualBasic.DateAndTime.DateAdd" +
										'(' +
										'"' + unitOfDifference + "\", " +
										valueOfDifference + ',' +
										"'1975-04-04')";
										//"Dated)";
*/										
//			agedDateColumn.Expression = "Microsoft.VisualBasic.DateAndTime.DateAdd(\"Year\", 13, Dated)";

			dataTable.Columns.Add(agedDateColumn);
			foreach( DataRow dataRow in dataTable.Rows )
			{
				switch (unitOfDifference)
				{
					case "day":
						dataRow["AgedDate"] = ((DateTime)(dataRow["Dated"])).AddDays(valueOfDifference);
						break;
					case "week":
						dataRow["AgedDate"] = ((DateTime)(dataRow["Dated"])).AddDays(valueOfDifference * 7.0);
						break;
					case "biblical month":
						dataRow["AgedDate"] = ((DateTime)(dataRow["Dated"])).AddDays(valueOfDifference * 30.0);
						break;
					case "gregorian month":
						dataRow["AgedDate"] = ((DateTime)(dataRow["Dated"])).AddMonths(valueOfDifference);
						break;
					case "biblical year":
						dataRow["AgedDate"] = ((DateTime)(dataRow["Dated"])).AddDays(valueOfDifference * 360.0);
						break;
					case "gregorian year":
						dataRow["AgedDate"] = ((DateTime)(dataRow["Dated"])).AddYears(valueOfDifference);
						break;
				}	
			}
			
			return dataTable;
		}	
	}
}
