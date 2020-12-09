#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
#endregion

namespace InformationInTransit.ProcessLogic
{
    #region EmptyHelper definition
    public static partial class EmptyHelper
    {
        #region Methods
        public static bool IsEmpty<T>(this T value) where T : struct
        {
            return value.Equals(default(T));
        }

        public static bool IsNotEmpty<T>(this T value) where T : struct
        {
            return (value.IsEmpty() == false);
        }
        #endregion
    }
    #endregion
}
