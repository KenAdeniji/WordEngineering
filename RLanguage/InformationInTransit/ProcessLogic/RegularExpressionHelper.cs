#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Text.RegularExpressions;
#endregion

namespace InformationInTransit.ProcessLogic
{
    #region RegularExpressionHelper
    public static partial class RegularExpressionHelper
    {
        public static readonly string[] Numbers = 
        {
            "123-456-7890", 
            "444-234-22450", 
            "690-203-6578", 
            "146-893-232",
            "146-839-2322",
            "4007-295-1111", 
            "407-295-1111", 
            "407-2-5555", 
        };

        public static readonly string[] Sentences = 
        {
            "cow over the moon",
            "Betsy the Cow",
            "cowering in the corner",
            "no match here"
        };

        #region Methods
        public static void Main(string[] argv)
        {
            System.Console.WriteLine(RemoveDuplicateWhiteSpace("Hello  World, Hope everything  is all right.   "));
            MatchSentences();
            MatchNumbers();
        }

        /*
         * ALTER TABLE Customers ADD CONSTRAINT PostalCodeCheck 
         *    CHECK (dbo.IsValidPostalCode(PostalCode, Country) <> 0)
        */
        public static bool IsValidPostalCode(string PostalCode, string Country)
        {
            string patternUSA, patternCanada;

            //United States formats -12345, 123456789, 12345 6789, 12345-6789
            patternUSA = @"^\d{5}((([ \-]{0,1})\d{4}){0,1})$";

            //Canadian formats -A1B2C3, A1B 2C3, A1B-2C3
            patternCanada = @"^[a-zA-Z]\d[a-zA-Z]([ \-]{0,1})\d[a-zA-Z]\d$";

            switch (Country.ToUpper())
            {
                case "USA": return Regex.IsMatch(PostalCode, patternUSA);
                case "CANADA": return Regex.IsMatch(PostalCode, patternCanada);
                default: return true;
            }
        }

        public static string RemoveDuplicateWhiteSpace(string input)
        {   
            return Regex.Replace(input, @"[\s]+", " ", RegexOptions.Singleline | RegexOptions.IgnoreCase);
        }

        public static void MatchSentences()
        {
            string sPattern = "cow";

            foreach (string s in Sentences)
            {
                System.Console.Write("{0,24}", s);

                if (System.Text.RegularExpressions.Regex.IsMatch(s, sPattern, System.Text.RegularExpressions.RegexOptions.IgnoreCase))
                {
                    System.Console.WriteLine("  (match for '{0}' found)", sPattern);
                }
                else
                {
                    System.Console.WriteLine();
                }
            }
        }

        public static void MatchNumbers()
        {
            string sPattern = "^\\d{3}-\\d{3}-\\d{4}$";

            foreach (string s in Numbers)
            {
                System.Console.Write("{0,14}", s);

                if (System.Text.RegularExpressions.Regex.IsMatch(s, sPattern))
                {
                    System.Console.WriteLine(" - valid");
                }
                else
                {
                    System.Console.WriteLine(" - invalid");
                }
            }
        }
        #endregion
    }
    #endregion
}
