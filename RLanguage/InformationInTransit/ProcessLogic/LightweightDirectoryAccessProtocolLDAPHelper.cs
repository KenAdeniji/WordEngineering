using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

using System.DirectoryServices;

namespace InformationInTransit.ProcessLogic
{
    public static partial class LightweightDirectoryAccessProtocolLDAPHelper
    {
        public static void Main()
        {
            Search("Computer");
        }

		///<param name="filter">
		///*, Computer, User 
		///</param>
		///<remarks>
		///http://www.dotnetspider.com/resources/25638-Code-find-out-all-users-given-Domain.aspx
		///</remarks>
		public static Collection<DirectoryEntry> Search(String filter)
        {
			DirectoryEntry directoryEntry = new DirectoryEntry( LightweightDirectoryAccessProtocolLDAPPath );
			DirectorySearcher directorySearcher = new DirectorySearcher( directoryEntry );

            if (filter == null)
			{
				filter = "*";
			}	
			
			string filterString = String.Format
			(
				FilterStringFormat,
				filter
			);

			directorySearcher.Filter = filterString;

            DirectoryEntry entry = null;
			Collection<DirectoryEntry> entries = new Collection<DirectoryEntry>();
			
			foreach (SearchResult searchResult in directorySearcher.FindAll())
            {
                entry = searchResult.GetDirectoryEntry();
				entries.Add(entry);
                System.Console.WriteLine(entry.Name);
            }
			return entries;
        }
		
		static LightweightDirectoryAccessProtocolLDAPHelper()
		{
			LogonServer = System.Environment.GetEnvironmentVariable("logonserver").Substring(2);
			LightweightDirectoryAccessProtocolLDAPPath = String.Format
			(
				LightweightDirectoryAccessProtocolLDAPFormat,
				LogonServer
			);		
		}
		
		public const String DefaultObjectClass = "*";
		public const string FilterStringFormat = "(objectClass={0})";
		public static readonly String LogonServer;
		public const string LightweightDirectoryAccessProtocolLDAPFormat = @"LDAP://{0}";
		public static readonly string LightweightDirectoryAccessProtocolLDAPPath;
    }
}
