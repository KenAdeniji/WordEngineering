using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Threading;
using System.Web;

namespace InformationInTransit.ProcessLogic
{
    public static partial class Jobvite
    {
        public const string ConnectionString = "Data Source=(local);Initial Catalog=Jobvite;Persist Security Info=True;Integrated Security=SSPI;";
        public const int RetryMax = 3;
        public static readonly string SelectInventory = "SELECT Title, Publisher, Year, Rank, Name, Book.Isbn AS Isbn " + 
            " FROM Book JOIN Author ON Book.Isbn = Author.Isbn " +
            " ORDER BY Title, Rank";
        public const string Source = "Source.txt";
        public const int ThreadSleep = 300;

        public static void Main(string[] argv)
        {
            MagicNumber();
            ReadSourceText();
            //ShowBooks(null, ConnectionString);
        }

        ///<summary>
        ///Write a function in C# to find magic numbers.
        ///A magic number is a 6 digit number that is equal to the square of the sum of the 3 higest digits and the 3 lowest digits.
        ///Example:
        ///123456 is not a magic number because: (123+456)^2 = 335241 which is not 123456.
        ///998001 is a magic number because: (998+001)^2 = 998001 which is equal to the original number.
        ///Can you make an algorithm with less tha 1000 iterations?
        ///</summary>
        public static void MagicNumber()
        {
            long comparer;
            long squareOfTheSumOfThe3HighestDigitsAndTheLowestDigits;
            for (int threeHighestDigits = 1; threeHighestDigits < 999; ++threeHighestDigits)
            {
                for (int threeLowestDigits = 1; threeLowestDigits < 999; ++threeLowestDigits)
                {
                    squareOfTheSumOfThe3HighestDigitsAndTheLowestDigits = (threeHighestDigits + threeLowestDigits) *
                        (threeHighestDigits + threeLowestDigits);
                    comparer = threeHighestDigits * 1000 + threeLowestDigits;
                    if 
                    (
                        squareOfTheSumOfThe3HighestDigitsAndTheLowestDigits ==
                        comparer
                    )
                    {
                        System.Console.WriteLine
                        (
                            "{0}{1}",
                            threeHighestDigits.ToString("000"),
                            threeLowestDigits.ToString("000")
                        );
                    }
                }
            }
        }

        public static void ReadSourceText()
        {
            String line;
            for (int retryCount = 0; retryCount < RetryMax; ++retryCount)
            {
                try
                {
                    StreamReader reader = new StreamReader(Source);
                    line = reader.ReadLine();
                    reader.Close();
                    break;
                }
                catch (IOException)
                {
                    Thread.Sleep(ThreadSleep);
                }
            }
        }

        public static void ShowBooks(HttpResponse response, string connectionString)
        {
            IDataReader dataReader = null;
            SqlConnection sqlConnection = null;
            SqlCommand sqlCommand = null;

            try
            {
                sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                sqlCommand = new SqlCommand(SelectInventory, sqlConnection);
                sqlCommand.CommandType = CommandType.Text;
                dataReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);

                Int64? isbn = null;

                while (dataReader.Read() != false)
                {
                    if (isbn != (Int64)dataReader["ISBN"])
                    {
                        isbn = (Int64)dataReader["ISBN"];
                        response.Write(dataReader["Title"] + "<br/>");
                        response.Write(dataReader["Publisher"] + ", " + dataReader["Year"] + "<br/>");
                    }
                    response.Write(dataReader["Name"] + "<br/>");
                }
            }
            catch (SqlException ex)
            {
                response.Write(ex.Message);
            }
            catch (Exception ex)
            {
                response.Write(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
    }
}
