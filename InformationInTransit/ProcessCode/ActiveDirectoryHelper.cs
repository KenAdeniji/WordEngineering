using System;
using System.DirectoryServices;

namespace InformationInTransit.ProcessCode
{
	//http://www.codemag.com/Article/1312041/Using-Active-Directory-in-.NET
	public static partial class ActiveDirectoryHelper
	{
		public static void Main(string[] argv)
		{
			GetAllUsers();
		}

		public static string GetCurrentDomainPath()
		{
			DirectoryEntry de = new DirectoryEntry("LDAP://RootDSE");
			return "LDAP://" + de.Properties["defaultNamingContext"][0].ToString();
		}

		public static void GetAllUsers()
		{
			SearchResultCollection results;
			DirectorySearcher ds = null;
			DirectoryEntry de = new DirectoryEntry(GetCurrentDomainPath());
			
			ds = new DirectorySearcher(de);
			ds.Filter = "(&(objectCategory=User)(objectClass=person))";
			
			results = ds.FindAll();
			
			foreach (SearchResult sr in results)
			{
				// Using the index zero (0) is required!
				System.Console.WriteLine(sr.Properties["name"][0].ToString());
			}
		}
	}	
}
