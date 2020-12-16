using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;
using System.Data;

namespace LabAssignment3ClassLibrary
{
    public class CustomersOrders
    {
        public static DataTable FillCustomers()
        {
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();
            string queryString = "SELECT * FROM dbo.Customers ORDER BY CompanyName";
            SqlDataAdapter adapter = new SqlDataAdapter(queryString, sqlConnection);

            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }

        public static DataTable FillCustomers(string customerId)
        {
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();
            string queryString = String.Format(CustomersQueryWhereCustomerID, customerId);
            SqlDataAdapter adapter = new SqlDataAdapter(queryString, sqlConnection);

            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }

        public static DataTable FillOrders(string customerId)
        {
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();
            string queryString = String.Format(OrdersQueryWhereCustomerID, customerId);
            SqlDataAdapter adapter = new SqlDataAdapter(queryString, sqlConnection);

            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }

        public const string ConnectionString = "Data Source=(local); Initial Catalog=NorthWind; Integrated Security=True;"; 
        public const string CustomersQueryWhereCustomerID = "SELECT * FROM dbo.Customers WHERE CustomerID = '{0}' ORDER BY CompanyName";
        public const string OrdersQueryWhereCustomerID = "SELECT * FROM dbo.Orders WHERE customerID = '{0}' ORDER BY OrderID";
    }
}
