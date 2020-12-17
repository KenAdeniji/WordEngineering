using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Win32;

namespace InformationInTransit.ProcessLogic
{
    public static partial class RegistryHelper
    {
        public static void Main(string[] argv)
        {
			RegisteredOwner();
        }

		public static string RegisteredOwner()
		{
			string owner = null;
			OperatingSystem operatingSystem = System.Environment.OSVersion;
			
			if (operatingSystem.Platform == PlatformID.Win32Windows)
			{
				// Windows 98?
			}
			else if (operatingSystem.Platform == PlatformID.Win32NT)
			{
				// Windows NT.
				RegistryKey registryKey = Registry.LocalMachine;
				registryKey = registryKey.OpenSubKey(@"SOFTWARE\Microsoft\WindowsNT\CurrentVersion");
				owner = registryKey.GetValue("RegisteredOwner").ToString();
				System.Console.WriteLine("OS Registered Owner: {0}", owner);
			}
			return owner;
		}
		
		/// <summary>
        /// HKEY_LOCAL_MACHINE\SYSTEM\WPA\SigningHash-*...*\SigningHashData 
        /// </summary>
        /// <example>
		///	byte[] windowsProductActivationSignature = WindowsProductActivationSignature();
        ///    foreach (byte windowsProductActivationSignatureByte in windowsProductActivationSignature)
        ///    {
        ///        System.Console.WriteLine(windowsProductActivationSignatureByte);
        ///    }
		/// </example>
        public static byte[] WindowsProductActivationSignature()
        {
            byte[] windowsProductActivationSignature = null;
            using
            (
                RegistryKey registryKey = Registry.LocalMachine.OpenSubKey
                (
                    @"SYSTEM\WPA",
                    false
                )
            )
            {
                foreach(string subKeyName in registryKey.GetSubKeyNames())
                {
                    if (subKeyName.IndexOf("SigningHash") == 0)
                    {
                        using
                        (
                            RegistryKey registrySubKey = registryKey.OpenSubKey(subKeyName)
                        )
                        {
                            windowsProductActivationSignature = (byte[])registrySubKey.GetValue("SigningHashData");
                        }
                    }
                }
            }
            return windowsProductActivationSignature;
        }
    }
}
