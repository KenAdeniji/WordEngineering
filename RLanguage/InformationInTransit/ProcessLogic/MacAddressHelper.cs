using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Management;
using System.Net.NetworkInformation;

namespace InformationInTransit.ProcessLogic
{
    public static partial class MacAddressHelper
    {
        public static void Main(string[] argv)
        {
            ShowNetworkInterfaces();
        }

        public static void ShowNetworkInterfaces()
        {
            IPGlobalProperties computerProperties = IPGlobalProperties.GetIPGlobalProperties();
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            Console.WriteLine("Interface information for {0}.{1}     ",
                    computerProperties.HostName, computerProperties.DomainName);
            if (nics == null || nics.Length < 1)
            {
                Console.WriteLine("  No network interfaces found.");
                return;
            }

            Console.WriteLine("  Number of interfaces .................... : {0}", nics.Length);
            foreach (NetworkInterface adapter in nics)
            {
                IPInterfaceProperties properties = adapter.GetIPProperties(); //  .GetIPInterfaceProperties();
                Console.WriteLine();
                Console.WriteLine(adapter.Description);
                Console.WriteLine(String.Empty.PadLeft(adapter.Description.Length, '='));
                Console.WriteLine("  Interface type .......................... : {0}", adapter.NetworkInterfaceType);
                Console.Write("  Physical address ........................ : ");
                PhysicalAddress address = adapter.GetPhysicalAddress();
                byte[] bytes = address.GetAddressBytes();
                for (int i = 0; i < bytes.Length; i++)
                {
                    // Display the physical address in hexadecimal.
                    Console.Write("{0}", bytes[i].ToString("X2"));
                    // Insert a hyphen after each byte, unless we are at the end of the 
                    // address.
                    if (i != bytes.Length - 1)
                    {
                        Console.Write("-");
                    }
                }
                Console.WriteLine();
            }
        }

        public static string IsValidMAC(string macAddress)
        {
            if (macAddress.StartsWith("/spa")) macAddress = macAddress.Substring(4);
            macAddress = macAddress.Replace(":", "");
            string result = "";
            Regex rx = new Regex("([0-9a-fA-F][0-9a-fA-F]-){5}([0-9a-fA-F][0-9a-fA-F])", RegexOptions.IgnoreCase);
            Match m = rx.Match(macAddress);
            result = m.Groups[0].Value;
            if (result.Length == 17)
            {
                return result;
            }
            else
            {
                rx = new Regex("([0-9a-fA-F][0-9a-fA-F]){5}([0-9a-fA-F][0-9a-fA-F])", RegexOptions.IgnoreCase);
                Match m2 = rx.Match(macAddress);
                result = m2.Groups[0].Value;
                if (result.Length == 12)
                {
                    return result;
                }
                return result;
            }
        }
    }
}
