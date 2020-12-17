using System;
using System.Data;
using System.Data.SqlClient;
using InformationInTransit.DataAccess;

namespace InformationInTransit.ProcessLogic
{
	public class HelloLinqDataTable
	{
		public static void Main(string[] argv)
		{
			PubsTitles();
		}
		
		public static void PubsTitles()
		{
			DataTable dataTable = (DataTable) DataCommand.DatabaseCommand
			(
				"SELECT * FROM Pubs..Titles",
				CommandType.Text,
				DataCommand.ResultType.DataTable
			);
			
            /*
			var filteredBooks =
				from book in dataTable.AsEnumerable()
				where book.Field<String>("Title").StartsWith("L")
				select new {
					Title = book.Field<String>("Title"),
					Price = book.Field<Decimal?>("Price")
				};
				
			ObjectDumper.Write(filteredBooks);	
            */ 
		}
	}
}