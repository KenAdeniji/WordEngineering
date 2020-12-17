#region Using directives
using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Web;
using System.Web.UI;
#endregion

namespace InformationInTransit.DataAccess
{
    #region PreferredEmailDb definition
    public static partial class PreferredEmailDb
    {
        #region Methods
        public static DataTable DatabaseQuery()
        {
            object obj = null;
            DataTable preferredEmail = null;
            Page executingPage = HttpContext.Current.Handler as Page;

            if (executingPage != null)
                obj = executingPage.Cache["PreferredEmail"];

            if (obj == null)
            {
                obj = Repository.DatabaseCommand
                (
                    "SELECT * FROM PreferredEmail ORDER BY PreferredEmailId",
                    CommandType.Text,
                    Repository.ResultSet.DataTable
                );
                if (executingPage != null && obj != null)
                    executingPage.Cache["PreferredEmail"] = obj;
            }

            preferredEmail = (DataTable) obj;
            return preferredEmail;
        }
        #endregion
    }
    #endregion
}