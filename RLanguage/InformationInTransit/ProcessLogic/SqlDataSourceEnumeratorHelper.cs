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
    #region SqlDataSourceEnumeratorHelper definition
    public partial class SqlDataSourceEnumeratorHelper
    {
        #region Methods
        public static void Main(string[] argv)
        {
            DataTable sqlServerInstances = SqlDataSourceEnumerator.Instance.GetDataSources();
            foreach(DataRow dataRow in sqlServerInstances.Rows)
            {
                System.Console.WriteLine
                (
                    "ServerName: {0} | InstanceName: {1} | IsClustered: {2} | Version: {3}",
                    dataRow["ServerName"],
                    dataRow["InstanceName"],
                    dataRow["IsClustered"],
                    dataRow["Version"]
                );
            }
        }

        public static List<String> RetrieveSqlServerInstances()
        {
            DataTable serverNames = SqlDataSourceEnumerator.Instance.GetDataSources();
            List<String> serverInstanceList = new List<String>();
            string serverInstanceName = null;

            foreach (DataRow row in serverNames.Rows)
            {
                if (row["InstanceName"] == System.DBNull.Value)
                {
                    serverInstanceName = (string)row["ServerName"];
                }
                else
                {
                    serverInstanceName = String.Format
                    (
                        @"{0}\{1}",
                        row["ServerName"],
                        row["InstanceName"]
                    );
                }
                serverInstanceList.Add(serverInstanceName);
            }

            return serverInstanceList;
        }
        #endregion
    }
    #endregion
}
