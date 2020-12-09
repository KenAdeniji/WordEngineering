using System;
using System.Data;
using System.Data.SqlClient;

using System.Collections;

namespace InformationInTransit.ProcessLogic
{
	public static class DataTableSelectDistinct
	{
		#region Select Distinct
		/// <summary>
		/// "SELECT DISTINCT" over a DataTable
		/// </summary>
		/// <param name="SourceTable">Input DataTable</param>
		/// <param name="FieldNames">Fields to select (distinct)</param>
		/// <returns></returns>
		/// <example>
		/// DataTable dt2 = dt.SelectDistinct("Column1, Column2");
		/// </example>
		/// <remarks>
		/// http://extensionmethod.net/csharp/datatable/selectdistinct
		/// </remarks>
		public static DataTable SelectDistinct(this DataTable SourceTable, String FieldName)
		{
			return SelectDistinct(SourceTable, FieldName, String.Empty);
		}
	 
		/// <summary>
		///"SELECT DISTINCT" over a DataTable
		/// </summary>
		/// <param name="SourceTable">Input DataTable</param>
		/// <param name="FieldNames">Fields to select (distinct)</param>
		/// <param name="Filter">Optional filter to be applied to the selection</param>
		/// <returns></returns>
		public static DataTable SelectDistinct(this DataTable SourceTable, String FieldNames, String Filter)
		{
			DataTable dt = new DataTable();
			String[] arrFieldNames = FieldNames.Replace(" ", "").Split(',');
			foreach (String s in arrFieldNames)
			{
				if (SourceTable.Columns.Contains(s))
					dt.Columns.Add(s, SourceTable.Columns[s].DataType);
				else
					throw new Exception(String.Format("The column {0} does not exist.", s));
			}
	 
			Object[] LastValues = null;
			foreach (DataRow dr in SourceTable.Select(Filter, FieldNames))
			{
				Object[] NewValues = GetRowFields(dr, arrFieldNames);
				if (LastValues == null || !(ObjectComparison(LastValues, NewValues)))
				{
					LastValues = NewValues;
					dt.Rows.Add(LastValues);
				}
			}
	 
			return dt;
		}
		#endregion
	 
		#region Private Methods
		private static Object[] GetRowFields(DataRow dr, String[] arrFieldNames)
		{
			if (arrFieldNames.Length == 1)
				return new Object[] { dr[arrFieldNames[0]] };
			else
			{
				ArrayList itemArray = new ArrayList();
				foreach (String field in arrFieldNames)
					itemArray.Add(dr[field]);
	 
				return itemArray.ToArray();
			}
		}
	 
		/// <summary>
		/// Compares two values to see if they are equal. Also compares DBNULL.Value.
		/// </summary>
		/// <param name="A">Object A</param>
		/// <param name="B">Object B</param>
		/// <returns></returns>
		private static Boolean ObjectComparison(Object a, Object b)
		{
			if (a == DBNull.Value && b == DBNull.Value) //  both are DBNull.Value
				return true;
			if (a == DBNull.Value || b == DBNull.Value) //  only one is DBNull.Value
				return false;
			return (a.Equals(b));  // value type standard comparison
		}
	 
		/// <summary>
		/// Compares two value arrays to see if they are equal. Also compares DBNULL.Value.
		/// </summary>
		/// <param name="A">Object Array A</param>
		/// <param name="B">Object Array B</param>
		/// <returns></returns>
		private static Boolean ObjectComparison(Object[] a, Object[] b)
		{
			Boolean retValue = true;
			Boolean singleCheck = false;
	 
			if (a.Length == b.Length)
				for (Int32 i = 0; i < a.Length; i++)
				{
					if (!(singleCheck = ObjectComparison(a[i], b[i])))
					{
						retValue = false;
						break;
					}
					retValue = retValue && singleCheck;
				}
	 
			return retValue;
		}
		#endregion
	}	
}

