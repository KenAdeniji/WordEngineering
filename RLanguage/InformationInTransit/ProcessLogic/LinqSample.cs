#region Using directives
using System;
using System.Linq;
using System.Collections.Generic;
#endregion

namespace InformationInTransit.ProcessLogic
{
    #region LinqSample definition
    public partial class LinqSample
    {
        #region Methods
        public static void Main(string[] argv)
        {
            string[] names = argv.Length > 0 ? argv : Names;
            NamesArray(names);
            MethodBasedQuery(names);
        }

        /*
        Func<string, bool>   filter  = s => s.Length == 5;
        Func<string, string> extract = s => s;
        Func<string, string> project = s => s.ToUpper();
        */

        /*
        Func<string, bool> filter = delegate(string s)
        {
            return s.Length == 5;
        };

        Func<string, string> extract = delegate(string s)
        {
            return s;
        };

        Func<string, string> project = delegate(string s)
        {
            return s.ToUpper();
        };
        */

        /*
        public static void LambdaExpressionsAndExpressionTrees(string[] argv)
        {
            IEnumerable<string> query = argv.Where(filter) 
                                 .OrderBy(extract)
                                 .Select(project);
        }
        */

        public static void MethodBasedQuery(string[] argv)
        {
            IEnumerable<string> query = argv
                            .Where(s => s.Length == 5) 
                            .OrderBy(s => s)
                            .Select(s => s.ToUpper());
            foreach (string item in query)
            {
                Console.WriteLine(item);
            }
        }

        public static void NamesArray(string[] argv)
        {
            IEnumerable<string> query = from s in argv
                                where s.Length == 5
                                orderby s
                                select s.ToUpper();

            foreach (string item in query)
            {
                Console.WriteLine(item);
            }
        }
        #endregion

        #region Constants
        public static readonly string[] Names =
        {
            "Burke",
            "Connor",
            "Frank", 
            "Everett",
            "Albert",
            "George", 
            "Harris",
            "David"
        };
        #endregion
    }
    #endregion
}

