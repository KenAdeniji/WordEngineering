#region Using directives
using System;
using System.Collections.Generic;
using System.Text;

using InformationInTransit.DataAccess;
#endregion

namespace InformationInTransit.ProcessLogic
{
    #region UserNameId definition
    public static partial class UserNameId
    {
        #region Methods
        public static Guid QueryUserId(string userName)
        {
            return UserNameIdDb.QueryUserId(userName);
        }
        #endregion
    }
    #endregion
}