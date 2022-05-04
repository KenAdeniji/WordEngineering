using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

using System.DirectoryServices;

/*
	2022-05-03	https://www.codemag.com/article/1312041/Using-Active-Directory-in-.NET
Using Active Directory in .NET

By Paul D. Sheriff
Published in: CODE Magazine: 2013 - November/December
Last updated: January 3, 2022	
*/
namespace InformationInTransit.ProcessCode
{
	public static partial class LightweightDirectoryAccessProtocolLDAPHelper
	{
		public static void Main(string[] argv)
		{
			System.Console.WriteLine( DomainName );
			Query("User");
			Query("Group");
		}
		
		public static string GetCurrentDomainPath()
		{
			DirectoryEntry de = new DirectoryEntry("LDAP://RootDSE");
			return "LDAP://" + de.Properties["defaultNamingContext"][0].ToString();
		}

		public static List<String> Query(String selectOption)
		{
			SearchResultCollection results;
			DirectorySearcher ds = null;
			DirectoryEntry de = new
			DirectoryEntry(GetCurrentDomainPath());
			
			ds = new DirectorySearcher(de);
			
			switch (selectOption)
			{
				case "Group":
					ds.Filter = "(&(objectCategory=Group))";
					break;
				case "User":
					ds.Filter = "(&(objectCategory=User)(objectClass=person))";
					break;
			}
			
			results = ds.FindAll();
			
			List<String> resultSet = new List<String>();
			
			foreach (SearchResult sr in results)
			{
				// Using the index zero (0) is required!
				resultSet.Add(sr.Properties["name"][0].ToString());
			}
			
			return(resultSet);
		}
		
		static LightweightDirectoryAccessProtocolLDAPHelper()
		{
			DomainName = GetCurrentDomainPath();
		}
		
		public static readonly String DomainName;
    }
}
