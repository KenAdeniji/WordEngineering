using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Configuration;

namespace Lab_Assignment_8_WpfApplicationAuthors
{
    public static partial class DatabaseHelper
    {
        static DatabaseHelper()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["Pubs"].ConnectionString;
            if (String.IsNullOrEmpty(ConnectionString))
            {
                ConnectionString = ConnectionStringDefault;
            }
        }

        public static string ConnectionString = null;
        public const string ConnectionStringDefault = "Data Source=(local); Initial Catalog=Pubs; Integrated Security=True;";
    }
}
