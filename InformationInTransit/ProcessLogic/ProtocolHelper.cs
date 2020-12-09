#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
#endregion

namespace InformationInTransit.ProcessLogic
{
    #region ProtocolHelper
    public static partial class ProtocolHelper
    {
        #region Methods
        public static string PrefixProtocol(string URI)
        {
            if (URI.IndexOf('@') > -1)
            {
                return ("mailto:" + URI);
            }
            else if (URI.IndexOf(':') < 0)
            {
                return ("http://" + URI);
            }
            else
            {
                return (URI);
            }
        }
        #endregion
    }
    #endregion
}
