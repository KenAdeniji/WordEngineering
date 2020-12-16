using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Configuration;

using System.Data.SqlClient;
using System.Data;

namespace Lab_Assignment_8_WpfApplicationAuthors
{
    public class DatabasePubsTableAuthors
    {
        public static DataTable FillAuthors()
        {
            SqlConnection sqlConnection = new SqlConnection(DatabaseHelper.ConnectionString);
            sqlConnection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(QueryString, sqlConnection);

            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }

        public static string DeleteAuthor(String authorID)
        {
            SqlConnection sqlConnection = new SqlConnection(DatabaseHelper.ConnectionString);
            sqlConnection.Open();
            string exceptionMessage = null;
            try
            {
                SqlCommand nonqueryCommand = sqlConnection.CreateCommand();
                nonqueryCommand.CommandText = DeleteSql;
                nonqueryCommand.Parameters.AddWithValue("@AuthorID", authorID);

                nonqueryCommand.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                exceptionMessage = ex.Message;
            }
            catch (Exception ex)
            {
                exceptionMessage = ex.Message;
            }
            return exceptionMessage;
        }

        public static string InsertAuthor(DatabasePubsTableAuthors author)
        {
            SqlConnection sqlConnection = new SqlConnection(DatabaseHelper.ConnectionString);
            sqlConnection.Open();
            string exceptionMessage = null;
            try
            {
                SqlCommand nonqueryCommand = sqlConnection.CreateCommand();
                nonqueryCommand.CommandText = InsertSql;
                nonqueryCommand.Parameters.AddWithValue("@AuthorID", author.AuthorID);
                nonqueryCommand.Parameters.AddWithValue("@LastName", author.LastName);
                nonqueryCommand.Parameters.AddWithValue("@FirstName", author.FirstName);
                nonqueryCommand.Parameters.AddWithValue("@Address", author.Address);
                nonqueryCommand.Parameters.AddWithValue("@City", author.City);
                nonqueryCommand.Parameters.AddWithValue("@State", author.State);
                nonqueryCommand.Parameters.AddWithValue("@Zip", author.Zip);
                nonqueryCommand.Parameters.AddWithValue("@Phone", author.Phone);
                nonqueryCommand.Parameters.AddWithValue("@Contract", author.Contract);

                nonqueryCommand.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                exceptionMessage = ex.Message;
            }
            catch (Exception ex)
            {
                exceptionMessage = ex.Message;
            }
            return exceptionMessage;
        }

        public static bool RecordOf
        (
            out int currentRecord,
            out int recordCount,
            string au_id,
            DataTable dataTable
        )
        {
            currentRecord = 0;
            recordCount = dataTable.Rows.Count;
            string au_idCurrent = null;
            bool recordFound = false;
            for (currentRecord = 0; currentRecord < recordCount; ++currentRecord)
            {
                au_idCurrent = (string)dataTable.Rows[currentRecord]["au_id"];
                int compareTo = au_idCurrent.CompareTo(au_id);
                if (compareTo == 0)
                {
                    recordFound = true;
                    break;
                }
                else if (compareTo == 1) //Assumes table is sorted by au_id in ascending order.
                {
                    break;
                }
            }
            return recordFound;
        }

        public static string UpdateAuthor(DatabasePubsTableAuthors author)
        {
            SqlConnection sqlConnection = new SqlConnection(DatabaseHelper.ConnectionString);
            sqlConnection.Open();
            string exceptionMessage = null;
            try
            {
                SqlCommand nonqueryCommand = sqlConnection.CreateCommand();
                nonqueryCommand.CommandText = UpdateSql;
                nonqueryCommand.Parameters.AddWithValue("@AuthorID", author.AuthorID);
                nonqueryCommand.Parameters.AddWithValue("@LastName", author.LastName);
                nonqueryCommand.Parameters.AddWithValue("@FirstName", author.FirstName);
                nonqueryCommand.Parameters.AddWithValue("@Address", author.Address);
                nonqueryCommand.Parameters.AddWithValue("@City", author.City);
                nonqueryCommand.Parameters.AddWithValue("@State", author.State);
                nonqueryCommand.Parameters.AddWithValue("@Zip", author.Zip);
                nonqueryCommand.Parameters.AddWithValue("@Phone", author.Phone);
                nonqueryCommand.Parameters.AddWithValue("@Contract", author.Contract);

                nonqueryCommand.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                exceptionMessage = ex.Message;
            }
            catch (Exception ex)
            {
                exceptionMessage = ex.Message;
            }
            return exceptionMessage;
        }

        public string AuthorID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Phone { get; set; }
        public bool? Contract { get; set; }

        public const string DeleteSql = "DELETE FROM dbo.Authors WHERE Au_id = @authorId";
        public const string InsertSql = "INSERT INTO dbo.Authors (Au_id, au_lname, au_fname, address, city, state, zip, phone, contract) VALUES (@AuthorID, @LastName, @FirstName, @Address, @City, @State, @Zip, @Phone, @Contract)";
        public const string UpdateSql = "UPDATE dbo.Authors SET au_lname = @LastName, au_fname = @FirstName, address = @Address, city = @City, state = @State, zip = @Zip, phone = @Phone, contract = @Contract WHERE au_id = @AuthorID";
        public const string QueryString = "SELECT * FROM dbo.Authors ORDER BY au_id";
    }
}
