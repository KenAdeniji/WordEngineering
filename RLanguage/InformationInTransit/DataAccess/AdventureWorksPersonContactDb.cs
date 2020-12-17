#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;
#endregion

namespace InformationInTransit.DataAccess
{
    #region AdventureWorksPersonContactDb
    public static partial class AdventureWorksPersonContactDb
    {
        #region Methods
        public static IDataReader Select()
        {
            IDataReader dataReader = (IDataReader)DataCommand.DatabaseCommand
            (
                "SELECT * FROM AdventureWorks.Person.Contact ORDER BY ContactID",
                CommandType.Text,
                DataCommand.ResultType.DataReader
            );
            return dataReader;
        }
        #endregion
    }
    #endregion
}
