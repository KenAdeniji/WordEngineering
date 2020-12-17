#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Text.RegularExpressions;
#endregion

namespace InformationInTransit.ProcessLogic
{
    #region EmailAddressHelper definition
    public static partial class EmailAddressHelper
    {
        #region Methods
        public static void Main(string[] argv)
        {
			foreach(String args in argv)
			{
				System.Console.WriteLine
				(
					"Address: {0} | IsValid: {1}",
					args,
					IsValidEmail(args)
				);
			}	
        }

		/*
			2017-06-03 http://extensionmethod.net/2101/csharp/mail/isvalidemail

			foreach(String args in argv)
			{
				System.Console.WriteLine
				(
					"Address: {0} | IsValid: {1}",
					args,
					IsValidEmail(args)
				);
			}	
		*/
		public static bool IsValidEmail(this string email)
		{
		   try
		   {
			   var addr = new System.Net.Mail.MailAddress(email);
			   return true;
		   }
		   catch
		   {
			   return false;
		   }
		}
	
        public static bool IsValidEmailAddress(this string s)
        {
            Regex regex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
            return regex.IsMatch(s);
        }
        #endregion
    }
    #endregion
}
