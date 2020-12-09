#region Using directives
using System;
using System.Collections.Generic;
using System.Text;

using System.Data;

using InformationInTransit.DataAccess;
#endregion

namespace InformationInTransit.ProcessLogic
{
    #region PreferredEmail definition
    public static partial class PreferredEmail
    {
        #region Methods
        public static DataTable DatabaseQuery()
        {
            return PreferredEmailDb.DatabaseQuery();
        }
        #endregion
    }
    #endregion
}
