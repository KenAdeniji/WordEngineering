using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.OleDb;

namespace InformationInTransit.DataAccess
{
    public static partial class AccessBible
    {
        public static void Main(string[] argv)
        {
            ReadData();
        }

        public static void ReadData()
        {
            OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.Jet.OleDb.4.0;Data Source=WordEngineering\IIS\WordEngineering\App_Data\KJV.mdb");
            OleDbCommand command = new OleDbCommand("SELECT * FROM Bible", connection); //BibleTable
            connection.Open();
            OleDbDataReader dataReader = command.ExecuteReader();

            while(dataReader.Read())
            {
                System.Console.WriteLine(dataReader["TextData"]);
            }

            dataReader.Close();
            connection.Close(); 
        }
    }
}
