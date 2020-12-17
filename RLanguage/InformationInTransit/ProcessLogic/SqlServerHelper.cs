#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.Sql;
#endregion

namespace InformationInTransit.ProcessLogic
{
    #region SqlServerHelper definition
    public static partial class SqlServerHelper
    {
        #region Methods
        public static void Main(string[] argv)
        {
            RetrieveDataSources();
        }

        public static DataTable RetrieveDataSources()
        {
            DataTable sqlServers = SqlDataSourceEnumerator.Instance.GetDataSources();
            Write(sqlServers);
            return sqlServers;
        }

        public static void Write(DataTable dataTable)
        {
            foreach (DataRow dataRow in dataTable.Rows)
            {
                foreach (DataColumn dataColumn in dataTable.Columns)
                {
                    System.Console.WriteLine
                    (
                        "{0} = {1}",
                        dataColumn.ColumnName,
                        dataRow[dataColumn]
                    );
                }
            }
        }
        #endregion
    }
    #endregion
}
