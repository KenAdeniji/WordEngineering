#region Using directives
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
#endregion

namespace InformationInTransit.ProcessLogic
{
    #region SocketHelper definition
    public static partial class SocketHelper
    {
        #region Methods
        public static void Main(string[] argv)
        {
            System.Console.WriteLine(HostName());
            System.Console.WriteLine(AddressList("hotmail.com"));
        }

        public static string AddressList(string hostName)
        {
            StringBuilder sb = new StringBuilder();
            if (String.IsNullOrEmpty(hostName))
            {
                hostName = "hotmail.com";
            }
            try
            {
                IPHostEntry ipHostEntry = Dns.GetHostEntry(hostName);
                IPAddress[] ipHostAddressList = ipHostEntry.AddressList;
                
                foreach (IPAddress ipAddress in ipHostAddressList)
                {
                    sb.Append(ipAddress);
                }
            }
            catch (SocketException ex)
            {
                Console.WriteLine(ex);
            }
            return sb.ToString();
        }

        public static string HostName()
        {
            return Dns.GetHostName();
        }
        #endregion
    }
    #endregion
}
