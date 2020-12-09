using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.NetworkInformation;
using System.Diagnostics;

namespace InformationInTransit.ProcessLogic
{
    public static partial class PingHelper
    {
        public static void Main(string[] argv)
        {
            PingStub();
        }

        public static void PingStub()
        {
            List<String> domainNames = new List<string>
            {
                "Bing.com",
                "Google.com"
            };

            foreach (string domainName in domainNames)
            {
                Ping pinger = new Ping();
                UserToken token = new UserToken() { Destination = domainName, InitiatedTime = DateTime.Now };
                pinger.PingCompleted += new PingCompletedEventHandler(PingCompleted);
                pinger.SendAsync(domainName, token);
            }
        }

        private static void PingCompleted(object sender, PingCompletedEventArgs e)
        {
            UserToken token = (UserToken)e.UserState;
            //Debug.Assert(true, string.Format("Reply from {0} with the status {1}", token.Destination, e.Reply.Status));
            System.Console.WriteLine
            (
                "Reply from {0} with the status {1}",
                token.Destination,
                e.Reply.Status
            );
        }
     }

    public class UserToken
    {
        public string Destination { get; set; }
        public DateTime InitiatedTime { get; set; }
    }
}
