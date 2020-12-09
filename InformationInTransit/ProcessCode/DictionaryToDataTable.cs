using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel;

namespace InformationInTransit.ProcessCode
{
	///	2018-03-17	Created.	http://dotnetspecialsupport.blogspot.com/2012/02/convert-dictionary-to-datatable-in-c.html
	public partial class DictionaryToDataTable
    {
        public static DataTable ConvertTo<T>(Dictionary<string, T> list, string dataTableName)
        {
            DataTable table = CreateTable1<T>(dataTableName);
            Type entityType = typeof(T);
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(entityType);

            foreach (KeyValuePair<string, T> item in list)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    if (prop.PropertyType.Name != "Dictionary`2")
                    {
                        if (prop.PropertyType.FullName == "System.String")
                            if (prop.GetValue(item.Value) == null)
                                row[prop.Name] = prop.GetValue(item.Value);
                            else
                                row[prop.Name] = prop.GetValue(item.Value).ToString().Replace("'", "''");
                        else
                            row[prop.Name] = prop.GetValue(item.Value);
                    }
                table.Rows.Add(row);
            }
            return table;
        }

        public static DataTable CreateTable1<T>(string dataTableName)
        {
            Type entityType = typeof(T);
            DataTable table = new DataTable(dataTableName);
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(entityType);
            foreach (PropertyDescriptor prop in properties)
            {
                table.Columns.Add(prop.Name, prop.PropertyType);
            }
            return table;
        }
    }
}
