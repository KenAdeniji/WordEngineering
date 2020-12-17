using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

using System.ComponentModel;

namespace InformationInTransit.ProcessLogic
{
    public static partial class ListHelper
    {
        public static void Main(string[] argv)
        {
            System.Console.WriteLine("TrueForAll: {0}", TrueForAll());
        }

		//2017-06-05 http://extensionmethod.net/5478/csharp/datatable-c-list/list-to-datatable
		/*
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
		*/
	   
        public static bool TrueForAll()
        {
            bool trueForAll = Integers.TrueForAll(p => p > 0);
            return trueForAll;
        }

        public static List<int> Integers = new List<int> { 1, 2, 3 };
    }
}
