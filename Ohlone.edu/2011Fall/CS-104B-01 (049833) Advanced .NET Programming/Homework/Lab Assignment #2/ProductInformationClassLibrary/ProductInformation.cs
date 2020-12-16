using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace ProductInformationClassLibrary
{
    public class ProductInformation
    {
        public static DataTable FillProducts()
        {
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();
            string queryString = "SELECT * FROM dbo.Products ORDER BY ProductName";
            SqlDataAdapter adapter = new SqlDataAdapter(queryString, sqlConnection);

            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            return dataTable;
        }

        public const string ConnectionString = "Data Source=(local); Initial Catalog=NorthWind; Integrated Security=True;"; 
    }
}
