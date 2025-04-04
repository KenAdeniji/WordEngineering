using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;

using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

using System.Linq;

using InformationInTransit.ProcessCode;

/*
	2017-02-26	http://stackoverflow.com/questions/1568593/how-to-use-indexof-method-of-listobject
*/
namespace InformationInTransit.ProcessLogic
{
	public static partial class DataTableHelper
	{
		public static void Main(string[] argv)
		{
			ToDataTableStub();
		}

		///<summary>
		///	2018-02-04	https://social.msdn.microsoft.com/Forums/vstudio/en-US/1407a809-9551-4646-b74d-3dee3535249c/how-to-compare-two-datatables-in-c?forum=csharpgeneral
		///</summary>
		public static DataTable CompareTwoDataTable(DataTable dt1, DataTable dt2)
		{ 
			dt1.Merge(dt2);
			DataTable d3 = dt2.GetChanges();
			return d3;
		}
		
		///<summary>
		///	2019-08-16	https://stackoverflow.com/questions/8188866/convert-dataset-element-to-string-array-in-c-sharp
		///</summary>
		public static object[] ConvertDataTableToArray
		(	
			this 	DataTable 	dataTable,
			string	columnName
		)
		{
			object[] dataColumnValue = new object[dataTable.Rows.Count];   
			int index = 0;
			foreach(DataRow dataRow in dataTable.Rows)
			{
				dataColumnValue[index] = (object) dataRow[columnName];
				++index;
			}
			return dataColumnValue;
		}
		
        /// <summary>
        /// 2017-02-26	Added. 
        /// </summary>
        public static StringCollection DataTableColumnSplitStringCollection
		(	
			this 	DataTable 	table,
			string	columnName
		)
        {
            String				adjust = "";
			StringCollection	uniqueWords = new StringCollection();
			bool				wordExist = false;
			
			foreach (DataRow row in table.Rows)
            {
				string		columnValue = (String) row[columnName];
				string[]	columnValues = columnValue.Split
				(
					SplitSeparator,
					StringSplitOptions.RemoveEmptyEntries 
				);
				foreach (String word in columnValues)
				{
					adjust = word.Trim();
					if (adjust == String.Empty)
					{
						continue;
					}
					adjust = char.ToUpper(adjust[0]) + adjust.Substring(1);
					wordExist = uniqueWords.Contains(adjust);
					if (wordExist == false)
					{
						uniqueWords.Add(adjust);
					}		
				}
            }
			
			return uniqueWords;
        }

        public static List<ExactUnique> DataTableColumnSplitList
		(	
			this 	DataTable 	table,
			string	columnName
		)
        {
            String					adjust = "";
			List<ExactUnique>		exactUniques = new List<ExactUnique>();
			long					wordIndex = -1;
			ExactUnique				exactUnique;
			
			foreach (DataRow row in table.Rows)
            {
				string		columnValue = (String) row[columnName];
				string[]	columnValues = columnValue.Split
				(
					SplitSeparator,
					StringSplitOptions.RemoveEmptyEntries 
				);
				foreach (String word in columnValues)
				{
					adjust = word.Trim();
					if (adjust == String.Empty)
					{
						continue;
					}
					adjust = char.ToUpper(adjust[0]) + adjust.Substring(1);

					wordIndex = exactUniques.FindIndex(r => r.BibleWord.Equals(adjust));
					
					/*
			        wordIndex = exactUniques.FindIndex(delegate(ExactUnique exactUniqueBibleWord) 
                       { return exactUniqueBibleWord.BibleWord.Equals(adjust); } );
					*/
					
					if (wordIndex < 0)
					{
						exactUnique = new ExactUnique
						{
							BibleWord = adjust,
						};	
						exactUniques.Add
						(
							exactUnique
						);
					}		
				}
            }
			
			return exactUniques;
        }
		
        /// <summary>
        /// 2014-04-03 http://dotnet.dzone.com/news/dumping-datatable-debug-window
        /// </summary>
        /// <param name="table"></param>
        public static void DumpDataTable(this DataTable table)
        {
            foreach (DataRow row in table.Rows)
            {
                foreach (DataColumn col in table.Columns)
                {
                    System.Console.Write(col.ColumnName);
                    System.Console.Write("=");
                    System.Console.WriteLine(row[col.ColumnName]);
                }
            }
        }

        /// <summary>
		/// 2018-02-04	DidTheDutchWonHelper.cs
        /// 2018-02-04 	DataTable 	dataTableResultFirst 	= DataTableHelper.GetDataTableFromArray(onlyInFirstSet.ToArray());
        /// </summary>
		public static DataTable GetDataTableFromArray(object[] array, string columnName = "Column1")
		{
			DataTable dataTable = new DataTable();
			DataColumn dataColumn = new DataColumn(columnName);
			dataTable.Columns.Add(dataColumn);
			foreach(object population in array)
			{
				dataTable.BeginLoadData();
				dataTable.LoadDataRow(new object[] {population}, true);//Pass array object to LoadDataRow method
				dataTable.EndLoadData();
			}	
			return dataTable;
		}
		
        /// <summary>
		/// 2014-02-11
		/// Convert generic List/Enumerable to DataTable?
		/// http://stackoverflow.com/questions/564366/convert-generic-list-enumerable-to-datatable
		/// </summary> 
		public static DataTable ToDataTable<T>(this IList<T> data)
		{
			PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
			DataTable table = new DataTable();
			foreach (PropertyDescriptor prop in properties)
				table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
			foreach (T item in data)
			{
				DataRow row = table.NewRow();
				foreach (PropertyDescriptor prop in properties)
					 row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
				table.Rows.Add(row);
			}
			return table;
		}

        /// <summary>
		/// 2019-12-17
		/// Convert generic List/Enumerable to DataTable?
		/// http://stackoverflow.com/questions/564366/convert-generic-list-enumerable-to-datatable
		/// </summary> 
/*
		public static DataTable DictionaryToDataTable<T>(this IDictionary<K, V> data)
		{
			PropertyDescriptorCollection propertiesK = TypeDescriptor.GetProperties(typeof(K));
			PropertyDescriptorCollection propertiesV = TypeDescriptor.GetProperties(typeof(V));
			
			DataTable table = new DataTable();
			foreach (PropertyDescriptor prop in propertiesK)
				table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
			foreach (PropertyDescriptor prop in propertiesV)
				table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
				
			foreach(KeyValuePair<K, V> item in data)
			{
				DataRow row = table.NewRow();
				foreach (PropertyDescriptor prop in propertiesK)
					 row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
				foreach (PropertyDescriptor prop in propertiesV)
					 row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
				table.Rows.Add(row);
			}
			return table;
		}
*/
		public static DataTable ToDataTableObsolete(Dictionary<String, InformationInTransit.ProcessCode.YourPartOfTheHistory.Participation> data)
		{
			DataTable table = new DataTable();
			table.Columns.Add("BibleWord");
			table.Columns.Add("FirstOccurrenceScriptureReference");
			table.Columns.Add("LastOccurrenceScriptureReference");
			table.Columns.Add("FrequencyOfOccurrence", System.Type.GetType("System.Int32"));
			foreach(KeyValuePair<string, InformationInTransit.ProcessCode.YourPartOfTheHistory.Participation> kvp in data)
			{
				DataRow row = table.NewRow();
				row["BibleWord"] = kvp.Key;
				row["FirstOccurrenceScriptureReference"] = kvp.Value.FirstOccurrenceScriptureReference;
				row["LastOccurrenceScriptureReference"] = kvp.Value.LastOccurrenceScriptureReference;
				row["FrequencyOfOccurrence"] = kvp.Value.FrequencyOfOccurrence;
				table.Rows.Add(row);
			}
			return table;
		}

		public static void ToDataTableStub()
		{
			DataTable courses = Courses.ToDataTable();
			
			foreach(DataRow dataRow in courses.Rows)
			{
				System.Console.WriteLine
				(
					dataRow["Code"]
				);
			}
		}

/*
		public static DataTable ToDataTable<T>(this IQueryable items)
		{
			Type type = typeof(T);

			var props = TypeDescriptor.GetProperties(type)
									  .Cast<PropertyDescriptor>()
									  .Where(propertyInfo => propertyInfo.PropertyType.Namespace.Equals("System"))
									  .Where(propertyInfo => propertyInfo.IsReadOnly == false)
									  .ToArray();

			var table = new DataTable();

			foreach (var propertyInfo in props)
			{
				table.Columns.Add(propertyInfo.Name, Nullable.GetUnderlyingType(propertyInfo.PropertyType) ?? propertyInfo.PropertyType);
			}

			foreach (var item in items)
			{
				table.Rows.Add(props.Select(property => property.GetValue(item)).ToArray());
			}

			return table;
		}		
*/
		
		public partial class ExactUnique
		{
			public string BibleWord { get; set; }
		}
		
		public static readonly List<SampleGenericCourse> Courses = new List<SampleGenericCourse>
        {
            new SampleGenericCourse{ Code = "ALG 101", Title = "Algebra 101" },
			new SampleGenericCourse{ Code = "COM 101", Title = "Communication 101" },
        };

		public partial class SampleGenericCourse
		{
			public string Code { get; set; }
			public string Title { get; set; }
			public int? CreditHours { get; set; }
		}
		
		public static readonly char[] SplitSeparator = new Char [] {' ', ',', '.', ':', ';', '(', ')', '?', '!'};
	}	
}
