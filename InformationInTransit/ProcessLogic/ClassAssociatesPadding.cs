using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;
using System.Data.SqlClient;

namespace InformationInTransit.ProcessLogic
{
    public static partial class ClassAssociatesPadding
    {
        public const string DatabaseConnectionString = "Data Source=localhost;Integrated Security=SSPI;Initial Catalog=WordEngineering;";
        public const string DirectoryName = @"D:\TheWord";
        public const string FileNamePattern = @"*.xml";
        public const string SqlStatement = @"IF EXISTS (SELECT * FROM ClassAssociates WHERE SequenceOrderId = @SequenceOrderId) " +
            " BEGIN UPDATE ClassAssociates SET TheWordId = @TheWordId, Dated = @Dated, Commentary = @Commentary, ContactId = @ContactId WHERE SequenceOrderId = @SequenceOrderId END " +
            " ELSE BEGIN INSERT INTO ClassAssociates(TheWordId, SequenceOrderId, Dated, Commentary, ContactId) VALUES(@TheWordId, @SequenceOrderId, @Dated, @Commentary, @ContactId) END ";

        public static void Main(string[] argv)
        {
            string directoryName = DirectoryName;
            string fileNamePattern = FileNamePattern;
            if (argv.Length >= 1)
            {
                directoryName = argv[0];
            }
            if (argv.Length >= 2)
            {
                fileNamePattern = argv[1];
            }
            Padding(directoryName, fileNamePattern);
        }

        public static void Padding(string directoryName, string fileNamePattern)
        {
            string commentary = null;
            int? contactId = null;
            DateTime dated = DateTime.Now;
            int sequenceOrderId = 0;
            int theWordId = 0;
            string[] filenames = Directory.GetFiles(directoryName, fileNamePattern);
            DataSet dataSet = new DataSet();
            DataTable dataTable = new DataTable();
            SqlCommand sqlCommand;
            SqlParameter sqlParameter;

            SqlConnection sqlConnection = new SqlConnection(DatabaseConnectionString);
            sqlConnection.Open();

            sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = "SET IDENTITY_INSERT WordEngineering..ClassAssociates ON";
            sqlCommand.ExecuteNonQuery();

            foreach (string filename in filenames)
            {
                if (filename.IndexOf("Archive") > -1) { continue; }
                if (filename.IndexOf("AlphabetSequence") > -1) { continue; }

                try
                {
                    dataSet.ReadXml(filename);
                    dataTable = dataSet.Tables["ClassAssociates"];
                    if (dataTable == null) { continue; }
                    theWordId = System.Convert.ToInt32(dataSet.Tables["TheWord"].Rows[0]["SequenceOrderId"]);
                    foreach (DataRow dataRow in dataTable.Rows)
                    {
                        sequenceOrderId = System.Convert.ToInt32(dataRow["SequenceOrderId"]);
                        commentary = (string)dataRow["Commentary"];

                        if (!dataTable.Columns.Contains("ContactId") || dataRow["ContactId"] == System.DBNull.Value || (string)dataRow["ContactId"] == "")
                        {
                            contactId = null;
                        }
                        else
                        {
                            contactId = System.Convert.ToInt32(dataRow["ContactId"]);
                        }

                        if (!dataTable.Columns.Contains("Dated") || dataRow["Dated"] == System.DBNull.Value)
                        {
                            dated = System.Convert.ToDateTime(dataSet.Tables["TheWord"].Rows[0]["Dated"]);
                        }
                        else
                        {
                            dated = System.Convert.ToDateTime(dataRow["Dated"]);
                        }

                        System.Console.WriteLine
                        (
                            "ThewordId: {0} | sequenceOrderId: {1} | commentary: {2} | dated: {3} | contactId: {4}",
                            theWordId,
                            sequenceOrderId,
                            commentary,
                            dated,
                            contactId
                        );

                        sqlCommand = new SqlCommand();
                        sqlCommand.Connection = sqlConnection;
                        sqlCommand.CommandText = SqlStatement;

                        // Add the input parameter and set its properties.

                        sqlParameter = new SqlParameter();
                        sqlParameter.ParameterName = "@SequenceOrderId";
                        sqlParameter.SqlDbType = SqlDbType.Int;
                        sqlParameter.Direction = ParameterDirection.Input;
                        sqlParameter.Value = sequenceOrderId;
                        sqlCommand.Parameters.Add(sqlParameter);

                        sqlParameter = new SqlParameter();
                        sqlParameter.ParameterName = "@TheWordId";
                        sqlParameter.SqlDbType = SqlDbType.Int;
                        sqlParameter.Direction = ParameterDirection.Input;
                        sqlParameter.Value = theWordId;
                        sqlCommand.Parameters.Add(sqlParameter);

                        sqlParameter = new SqlParameter();
                        sqlParameter.ParameterName = "@Dated";
                        sqlParameter.SqlDbType = SqlDbType.DateTime;
                        sqlParameter.Direction = ParameterDirection.Input;
                        sqlParameter.Value = dated;
                        sqlCommand.Parameters.Add(sqlParameter);

                        sqlParameter = new SqlParameter();
                        sqlParameter.ParameterName = "@Commentary";
                        sqlParameter.SqlDbType = SqlDbType.NVarChar;
                        sqlParameter.Direction = ParameterDirection.Input;
                        sqlParameter.Value = commentary;
                        sqlCommand.Parameters.Add(sqlParameter);

                        sqlParameter = new SqlParameter();
                        sqlParameter.ParameterName = "@ContactId";
                        sqlParameter.SqlDbType = SqlDbType.Int;
                        sqlParameter.Direction = ParameterDirection.Input;
                        sqlParameter.Value = contactId;
                        sqlCommand.Parameters.Add(sqlParameter);

                        //sqlCommand.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                    System.Console.WriteLine
                    (
                        "Filename: {0} | theWordId: {1} | sequenceOrderId: {2} | commentary: {3} | dated: {4} | contactId: {5}",
                        filename,
                        theWordId,
                        sequenceOrderId,
                        commentary,
                        dated,
                        contactId
                    );
                }
            }
        }
    }
}
