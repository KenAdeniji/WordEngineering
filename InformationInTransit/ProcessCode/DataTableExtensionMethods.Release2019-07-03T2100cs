using System.Data;
using System.Text;

namespace InformationInTransit.ProcessCode
{
	/*
		2019-07-03T21:00:00	https://stackoverflow.com/questions/4959722/c-sharp-datatable-to-csv
	*/	
	public static partial class DataTableExtensionMethods
	{
		public static string WriteToCsvFile(this DataTable dataTable, string filePath = null) 
		{
			StringBuilder fileContent = new StringBuilder();

			foreach (var col in dataTable.Columns) 
			{
				fileContent.Append(col.ToString() + ",");
			}

			fileContent.Replace(",", System.Environment.NewLine, fileContent.Length - 1, 1);

			foreach (DataRow dr in dataTable.Rows) 
			{
				foreach (var column in dr.ItemArray) 
				{
					fileContent.Append("\"" + column.ToString() + "\",");
				}

				fileContent.Replace(",", System.Environment.NewLine, fileContent.Length - 1, 1);
			}

			if (!string.IsNullOrEmpty(filePath))
			{	
				System.IO.File.WriteAllText(filePath, fileContent.ToString());
			}	
			
			return fileContent.ToString();
		}
	}
}
