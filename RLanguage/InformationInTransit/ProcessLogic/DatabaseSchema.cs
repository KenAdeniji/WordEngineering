using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Collections.ObjectModel;
using System.Data;

using InformationInTransit.DataAccess;

namespace InformationInTransit.ProcessLogic
{
    public static partial class DatabaseSchema
    {
        public static List<SysColumns> RetrieveColumns
        (
            string connectionString,
            string databaseName,
            long objectId
        )
        {
            List<SysColumns> sysColumnsList = DatabaseSchemaDb.RetrieveColumns
            (
                connectionString,
                databaseName,
                objectId
            );
            return sysColumnsList;
        }

        public static List<SysDatabases> RetrieveDatabases
        (
            string connectionString,
            bool isSystem
        )
        {
            List<SysDatabases> sysDatabasesList = DatabaseSchemaDb.RetrieveDatabases
            (
                connectionString,
                isSystem
            );
            return sysDatabasesList;
        }

        public static List<SysObjects> RetrieveObjects
        (
            string connectionString,
            string databaseName,
            DatabaseObjectType databaseObjectType
        )
        {
            List<SysObjects> sysObjectsList = DatabaseSchemaDb.RetrieveObjects
            (
                connectionString,
                databaseName,
                databaseObjectType
            );
            return sysObjectsList;
        }

        public enum DatabaseObjectType
        {
            SystemTable,
            UserTable
        }
    }
}
