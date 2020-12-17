using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;
using InformationInTransit.ProcessLogic;

namespace InformationInTransit.DataAccess
{
    public static partial class DatabaseSchemaDb
    {
        public static void Main(string[] argv)
        {
            string connectionString = "Data Source=(local);Database=AdventureWorks;" +
                "Integrated Security=true;";
            string databaseName = "Uri";
            RetrieveTables(connectionString, databaseName);
        }

        public static List<SysColumns> RetrieveColumns
        (
            string connectionString,
            string databaseName,
            long objectId
        )
        {
            string sqlStatement = String.Format
            (
                SysColumnsFormat,
                databaseName,
                objectId
            );

            IDataReader dataReader = (IDataReader)DataCommand.DatabaseCommand
            (
                sqlStatement,
                connectionString,
                CommandType.Text,
                DataCommand.ResultType.DataReader
            );

            List<SysColumns> sysColumnsList = new List<SysColumns>();

            SysColumns sysColumns = new SysColumns();

            int columnId = -1;
            string columnName;
            
            while (dataReader.Read() != false)
            {
                columnId = (Int16)dataReader["ColId"];
                columnName = (string)dataReader["Name"];
                sysColumns = new SysColumns()
                {
                    ColumnId = columnId,
                    Name = columnName,
                    ObjectId = objectId
                };

                sysColumnsList.Add(sysColumns);
            }
            return sysColumnsList;
        }

        public static List<SysDatabases> RetrieveDatabases
        (
            string connectionString,
            bool? isSystem
        )
        {
            string sqlStatement = "SELECT name, database_Id FROM sys.databases ";

            if (isSystem == null)
            {
                sqlStatement += " ORDER BY Name";
            }
            else if (isSystem == true)
            {
                sqlStatement += " WHERE (name IN ('Master', 'tempdb', 'msdb', 'Model')) ORDER BY Name";
            }
            else
            {
                sqlStatement += " WHERE (name NOT IN ('Master', 'tempdb', 'msdb', 'Model'))  ORDER BY Name";
            }

            IDataReader dataReader = (IDataReader)DataCommand.DatabaseCommand
            (
                sqlStatement,
                connectionString,
                CommandType.Text,
                DataCommand.ResultType.DataReader
            );

            List<SysDatabases> sysDatabasesList = new List<SysDatabases>();

            int databaseId;
            string databaseName;
            SysDatabases sysDatabases = new SysDatabases();

            while (dataReader.Read() != false)
            {
                databaseId = (int)dataReader["Database_Id"];
                databaseName = (string)dataReader["Name"];
                sysDatabases = new SysDatabases()
                {
                    Name = databaseName,
                    DatabaseId = databaseId
                };

                sysDatabasesList.Add(sysDatabases);
            }
            return sysDatabasesList;
        }

        public static List<SysObjects> RetrieveObjects
        (
            string connectionString,
            string databaseName,
            DatabaseSchema.DatabaseObjectType databaseObjectType
        )
        {
            List<SysObjects> sysObjectsList = new List<SysObjects>();

            string sqlStatement = "SELECT Name, Object_Id FROM " + databaseName + 
                ".sys.objects WHERE ";

            switch (databaseObjectType)
            {
                case DatabaseSchema.DatabaseObjectType.SystemTable:
                    sqlStatement += " type = 'S' ";
                    break;

                case DatabaseSchema.DatabaseObjectType.UserTable:
                    sqlStatement += " type = 'U' ";
                    break;
            }

            sqlStatement += " ORDER BY Name";

            IDataReader dataReader = (IDataReader)DataCommand.DatabaseCommand
            (
                sqlStatement,
                connectionString,
                CommandType.Text,
                DataCommand.ResultType.DataReader
            );

            int objectId;
            string objectName;
            SysObjects sysObjects = new SysObjects();

            while (dataReader.Read() != false)
            {
                objectId = (int)dataReader["Object_Id"];
                objectName = (string)dataReader["Name"];
                sysObjects = new SysObjects()
                {
                    Name = objectName,
                    ObjectId = objectId
                };

                sysObjectsList.Add(sysObjects);
            }

            return sysObjectsList;
        }

        public static List<SysObjects> RetrieveTables
        (
            string connectionString,
            string databaseName
        )
        {
            List<SysObjects> sysObjectsList = new List<SysObjects>();
            using (SqlConnection connection =  new SqlConnection(connectionString))
            {
                connection.Open();

                // Specify the restrictions.
                string[] restrictions = new string[4];
                restrictions[0] = databaseName;
                DataTable table = connection.GetSchema
                (
                    "Tables",
                    restrictions
                );

                int objectId;
                string tableName;
                SysObjects sysObjects = new SysObjects();

                foreach (System.Data.DataRow row in table.Rows)
                {
                    foreach (System.Data.DataColumn col in table.Columns)
                    {
                        Console.WriteLine("{0} = {1}", col.ColumnName, row[col]);
                    }
                }

                foreach (DataRow dataRow in table.Rows)
                {
                    objectId = (int)dataRow["Object_Id"];
                    tableName = (string)dataRow["Name"];
                    sysObjects = new SysObjects()
                    {
                        Name = tableName,
                        ObjectId = objectId
                    };

                    sysObjectsList.Add(sysObjects);
                }
            }
            return sysObjectsList;
        }

        public const string SysColumnsFormat = "SELECT name, colid FROM {0}.sys.syscolumns WHERE id = {1}  ORDER BY colid";
    }
}
