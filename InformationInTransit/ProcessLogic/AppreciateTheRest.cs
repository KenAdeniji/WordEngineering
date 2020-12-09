using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;

using InformationInTransit.DataAccess;

namespace InformationInTransit.ProcessLogic
{
    /// <summary>
    ///     2015-09-29  Appreciate the Rest.
	///		Support for, added. Specify the stored procedure name;
	///			either usp_AppreciateTheRest
	///
    /// </summary>
    public static partial class AppreciateTheRest
    {
        public static DataSet Query(string storedProcedure)
        {
            DataSet resultSet = (DataSet)DataCommand.DatabaseCommand
                                (
                                    "WordEngineering.." + storedProcedure,
                                    System.Data.CommandType.StoredProcedure,
                                    DataCommand.ResultType.DataSet
                                );
            return resultSet;
        }
    }
}
