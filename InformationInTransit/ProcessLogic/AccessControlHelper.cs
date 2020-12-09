using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;
using System.Security.AccessControl;


namespace InformationInTransit.ProcessLogic
{
    public static partial class AccessControlHelper
    {
        public static AuthorizationRuleCollection AccessControlList(string filename)
        {
            FileSecurity fileSecurity = File.GetAccessControl(filename);
            AuthorizationRuleCollection accessControlList =
                fileSecurity.GetAccessRules
                (
                    true,
                    true,
                    typeof(System.Security.Principal.NTAccount)
                );
            return accessControlList;
        }

        public static String AccessControlList
        (
            AuthorizationRuleCollection accessControlList,
            string filename,
            string recordSeparator,
            string columnSeparator
        )
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat
            (
                "Filename: {0}{1}",
                filename,
                recordSeparator
            );
            foreach (FileSystemAccessRule fileSystemAccessRule in accessControlList)
            {
                sb.AppendFormat
                (
                    AccessControlListFormat,
                    columnSeparator,
                    recordSeparator,
                    fileSystemAccessRule.IdentityReference.Value,
                    fileSystemAccessRule.AccessControlType,
                    fileSystemAccessRule.FileSystemRights,
                    fileSystemAccessRule.IsInherited
                );
            }
            return sb.ToString();
        }

        public const String AccessControlListFormat = "Account: {2}{0}Type: {3}{0}Rights: {4}{0}Inherited: {5}{0}{1}";
    }
}
