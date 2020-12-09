using System;
using System.Data;
using System.IO;
using System.Text;

namespace WordEngineering
{
	public static class CommaSeparatedValueHelper
	{
		public static void Main(string[] argv)
		{
			DataTable dataTable = ReadString();
			dataTable.ToCSV(",", true, @"Contact.csv");
		}
		
		///<see>
		///http://stackoverflow.com/questions/12368935/loading-a-datatable-with-a-xml-string
		///</see>
		public static DataTable ReadString()
		{
			string TestString = 
				@"<Contacts> 
					<Node>
						<ID>123</ID>
						<Name>ABC</Name>
					</Node>
					<Node>
						<ID>124</ID>
						<Name>DEF</Name>
					</Node>
				</Contacts>";
			StringReader StringStream = new StringReader(TestString);
			DataSet dataSet = new DataSet();
			dataSet.ReadXml(StringStream);
			DataTable dataTable = dataSet.Tables[0];
			return dataTable;
		}
		
		///<see>
		///http://extensionmethod.net/csharp/data/datatable-to-csv-export
		///</see>
		public static void ToCSV
		(
			this DataTable table,
			string delimiter,
			bool includeHeader,
			string csvFilename
		)
        {
            StringBuilder result = new StringBuilder();
            if (includeHeader)
            {
                foreach (DataColumn column in table.Columns)
                {
                    result.Append(column.ColumnName);
                    result.Append(delimiter);
                }
                result.Remove(--result.Length, 0);
                result.Append(Environment.NewLine);
            }
  
            foreach (DataRow row in table.Rows)
            {
                foreach (object item in row.ItemArray)
                {
                    if (item is System.DBNull)
					{
                        result.Append(delimiter);
					}
                    else
                    {
                        string itemAsString = item.ToString();
                        // Double up all embedded double quotes
                        itemAsString = itemAsString.Replace("\"", "\"\"");
  
                        // To keep things simple, always delimit with double-quotes
                        // so we don't have to determine in which cases they're necessary
                        // and which cases they're not.
                        itemAsString = "\"" + itemAsString + "\"";
                        result.Append(itemAsString + delimiter);
                     }
                }
  
                result.Remove(--result.Length, 0);
                result.Append(Environment.NewLine);
            }
            using (StreamWriter writer = new StreamWriter(csvFilename, true))
            {
                writer.Write(result.ToString());
            }
        }
	}
}
