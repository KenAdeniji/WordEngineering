#region Using directives
using System;
using System.Runtime.InteropServices;
#endregion

namespace InformationInTransit.ProcessLogic
{
    #region ServerInformationActiveXSignatures definition
    public interface ServerInformationActiveXSignatures
    {
        string Hostname();
        DateTime Timestamp { get; }
    }
    #endregion

    #region ServerInformationActiveX definition
    [ClassInterface(ClassInterfaceType.AutoDual)]
    public partial class ServerInformationActiveX : ServerInformationActiveXSignatures
    {
        #region Methods
        public string Hostname()
        {
            return Environment.MachineName;
        }

        public DateTime Timestamp
        {
            get
            {
                return DateTime.Now;
            }
        }
        #endregion
    }
    #endregion
}
