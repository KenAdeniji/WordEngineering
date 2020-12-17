#region Using directives
using System;
using System.Collections.ObjectModel;
using System.DirectoryServices;
using System.Collections.Generic;

using System.DirectoryServices.AccountManagement;
using System.DirectoryServices.ActiveDirectory;
#endregion

namespace InformationInTransit.ProcessLogic
{
    #region ActiveDirectoryHelper definition
	/*
		2018-02-09	https://www.codeproject.com/Articles/489348/Active-Directory-Users-and-Computers
	*/
    public static partial class ActiveDirectoryHelper
    {
        #region Methods
        public static void Main(string[] argv)
        {
            //ComputerList();
            LastLogon(null, null);
			System.Console.WriteLine("DomainName: {0}", DomainName);
			FindAllComputers();
        }

        public static Collection<String> ComputerList()
        {
            Collection<string> computers = new Collection<string>();
            string domainName = System.Environment.UserDomainName;
            DirectoryEntry directoryEntry = new DirectoryEntry("LDAP://" + domainName);
            DirectorySearcher directorySearcher = new DirectorySearcher(directoryEntry);
            directorySearcher.Filter = ("(objectClass=computer)");
            string computerName;
            foreach(SearchResult searchResult in directorySearcher.FindAll())
            {
                computerName = searchResult.GetDirectoryEntry().Name.Substring(3);
                System.Console.WriteLine(computerName);
                computers.Add(computerName);
            }
            return computers;
        }

		public static List<Computer> FindAllComputers()
		{
			PrincipalContext principalContext = new PrincipalContext(ContextType.Domain, DomainName);
			ComputerPrincipal computerPrincipal = new ComputerPrincipal(principalContext);
			PrincipalSearcher principalSearcher = new PrincipalSearcher(computerPrincipal);

			Computer computer = null;
			List<Computer> computers = new List<Computer>();

			foreach (ComputerPrincipal computerPrincipalCurrent in principalSearcher.FindAll())
			{
				computer = new Computer
				{
					SamAccountName = computerPrincipalCurrent.SamAccountName,
					DisplayName = computerPrincipalCurrent.DisplayName,
					Name = computerPrincipalCurrent.Name,
					Description = computerPrincipalCurrent.Description,
					Enabled = computerPrincipalCurrent.Enabled,
					LastLogon = computerPrincipalCurrent.LastLogon
				};
				computers.Add(computer);
				//System.Console.WriteLine(computer);
			}
			
			return computers;
		}	
		
		public static List<User> FindAllUsers()
		{
			PrincipalContext principalContext = new PrincipalContext(ContextType.Domain, DomainName);
			UserPrincipal userPrincipal = new UserPrincipal(principalContext);
			PrincipalSearcher principalSearcher = new PrincipalSearcher(userPrincipal);

			User user = null;
			List<User> users = new List<User>();

			foreach (UserPrincipal userPrincipalCurrent in principalSearcher.FindAll())
			{
				user = new User
				{
					SamAccountName = userPrincipalCurrent.SamAccountName,
					DisplayName = userPrincipalCurrent.DisplayName,
					Name = userPrincipalCurrent.Name,
					GivenName = userPrincipalCurrent.GivenName,
					Surname = userPrincipalCurrent.Surname,
					Description = userPrincipalCurrent.Description,
					Enabled = userPrincipalCurrent.Enabled,
					LastLogon = userPrincipalCurrent.LastLogon
				};
				users.Add(user);
				//System.Console.WriteLine(user);
			}
			
			return users;
		}	
		
        public static void LastLogon(string username, string domain)
        {
            if (username == null)
            {
                username = System.Environment.UserName;
            }            
            if (domain == null)
            {
                domain = System.Environment.UserDomainName;
            }
            DirectoryContext context = new DirectoryContext
            (
              DirectoryContextType.Domain,
              domain
            );

            DateTime latestLogon = DateTime.MinValue;
            string servername = null;

            DomainControllerCollection dcc = DomainController.FindAll(context);

            foreach (DomainController dc in dcc)
            {
                DirectorySearcher ds;

                using (dc)
                using (ds = dc.GetDirectorySearcher())
                {
                    ds.Filter = String.Format(
                      "(sAMAccountName={0})",
                      username
                      );
                    ds.PropertiesToLoad.Add("lastLogon");
                    ds.SizeLimit = 1;

                    SearchResult sr = ds.FindOne();

                    if (sr != null)
                    {
                        DateTime lastLogon = DateTime.MinValue;
                        if (sr.Properties.Contains("lastLogon"))
                        {
                            lastLogon = DateTime.FromFileTime
                            (
                              (long)sr.Properties["lastLogon"][0]
                            );
                        }

                        if (DateTime.Compare(lastLogon, latestLogon) > 0)
                        {
                            latestLogon = lastLogon;
                            servername = dc.Name;
                        }
                    }
                }
            }

            Console.WriteLine
            (
              "Last Logon: {0} at {1}",
              servername,
              latestLogon.ToString()
            );
        }

        public static void ListAllTheUsersInAGroup
        (
            string machineName,
            string groupName
        )
        {
            if (String.IsNullOrEmpty(machineName))
            {
                machineName = System.Environment.MachineName;
            }
            if (String.IsNullOrEmpty(groupName))
            {
                groupName = "Administrators";
            }

            string path = String.Format
            (
                @"WinNT://{0}/{1}",
                machineName,
                groupName
            );
            DirectoryEntry directoryEntryGroup = new DirectoryEntry(path);
            object groupMembers = directoryEntryGroup.Invoke("Members", null);
            /*
            foreach(object groupMember in (IEnumerable) groupMembers)
            {
                DirectoryEntry directoryEntryMember = new DirectoryEntry(groupMember);
                System.Console.WriteLine(directoryEntryMember.Name);
            }
            */ 
        }
        #endregion

		static ActiveDirectoryHelper()
		{
			DomainName = System.Net.NetworkInformation.IPGlobalProperties.GetIPGlobalProperties().DomainName;
		}	
		
		public static readonly String DomainName;
		
		public class User
		{
			public String SamAccountName { get; set; }
			public String DisplayName { get; set; }
			public String Name { get; set; }
			public String GivenName { get; set; }
			public String Surname { get; set; }
			public String Description { get; set; }
			public Boolean? Enabled { get; set; }
			public DateTime? LastLogon { get; set; }
			
			public override string ToString() 
			{
				return String.Format
				(
					"SamAccountName: {0} | DisplayName: {1} | Name: {2} | GivenName: {3} | Surname: {4} | Description: {5} | Enabled: {6} | LastLogon: {7}",
					SamAccountName,
					DisplayName,
					Name,
					GivenName,
					Surname,
					Description,
					Enabled,
					LastLogon
				);	
			}
		}	

		public class Computer
		{
			public String SamAccountName { get; set; }
			public String DisplayName { get; set; }
			public String Name { get; set; }
			public String Description { get; set; }
			public Boolean? Enabled { get; set; }
			public DateTime? LastLogon { get; set; }
			
			public override string ToString() 
			{
				return String.Format
				(
					"SamAccountName: {0} | DisplayName: {1} | Name: {2} | Description: {3} | Enabled: {4} | LastLogon: {5}",
					SamAccountName,
					DisplayName,
					Name,
					Description,
					Enabled,
					LastLogon
				);	
			}
		}	
    }
    #endregion
}

