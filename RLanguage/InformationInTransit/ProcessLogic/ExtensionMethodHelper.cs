#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Collections.ObjectModel;
using System.Reflection;
#endregion

namespace InformationInTransit.ProcessLogic
{
    #region ExtensionMethodHelper definition
    public static partial class ExtensionMethodHelper
    {
        #region Methods
        public static void Main(string[] argv)
        {
            var i = new int[] { 5, 12, 44, -4 };
            Console.WriteLine(i.ToString(":"));
        }

        /// <example>
        /// Collection<AdventureWorksPersonContact> adventureWorksPersonContacts = AdventureWorksPersonContact.Select();
        /// var adventureWorksPersonContactsSortedByName = adventureWorksPersonContacts.OrderBy("LastName desc");
        /// ObjectDumper.Write(adventureWorksPersonContactsSortedByName);
        /// </example>
        public static IEnumerable<T> OrderBy<T>(this IEnumerable<T> list, string sortExpression)
        {
            sortExpression += "";
            string[] parts = sortExpression.Split(' ');
            bool descending = false;
            string property = "";

            if (parts.Length > 0 && parts[0] != "")
            {
                property = parts[0];

                if (parts.Length > 1)
                {
                    descending = parts[1].ToLower().Contains("esc");
                }

                PropertyInfo prop = typeof(T).GetProperty(property);

                if (prop == null)
                {
                    throw new Exception("No property '" + property + "' in + " + typeof(T).Name + "'");
                }

                if (descending)
                    return list.OrderByDescending(x => prop.GetValue(x, null));
                else
                    return list.OrderBy(x => prop.GetValue(x, null));
            }

            return list;
        }

        /// <example>
        /// var i = new int[] { 5, 12, 44, -4 };
        /// System.Console.WriteLine(i.ToString(":"));
        /// </example>
        public static string ToString<T>(this IEnumerable<T> list, string separator) 
        {
            StringBuilder sb = new StringBuilder();
            foreach (var obj in list) 
            {
                if (sb.Length > 0) 
                {
                    sb.Append(separator);
                }
                sb.Append(obj);
            }
            return sb.ToString();
        }
        #endregion
    }
    #endregion
}
