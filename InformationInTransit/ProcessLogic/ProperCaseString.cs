using System;
using System.Text.RegularExpressions;

namespace InformationInTransit.ProcessLogic
{
    /// <summary>
    /// http://codekeep.net/snippets/61157a19-ebb6-4262-bb3a-5e9bd749384e.aspx
    /// 2014-04-03 Jason Lindstrom
    /// </summary>
    class ProperCaseString
    {
        // CONFIGURATION:

        // The following words will always be in lower case (except in the start of the string)
        static string[] lowerCaseWords = { "of", "the", "and", "or", "an", "von" };

        // The following prefixes will cause their next character to be uppercased
        // Note: Keep the first character uppercase when defining these; all else must be in lowercase
        static string[] upperCasePrefixes = { "Mc", "O'" };

        // The following words will be always presented in the case they have here.
        static string[] fixedCaseWords = { "MGR", "III", "II", "A", "B", "CCR", "OFC", "MKT", "PLNG", "VP", "OP", "OPS", "GIS", "CA", "PC", "CS", "LNG", "SR", "COO", "IS", "CFO", "WR", "GO", "CSC", "RM", "CAO", "FIN" };



        /// <summary>
        /// Converts the given string into ProperCase.
        /// </summary>
        /// <param name="original">The original string, f.e. "THE EYE OF THE TIGER"</param>
        /// <returns>The string converted into ProperCase, f.e. "The Eye of the Tiger"</returns>
        public static string ProperCase(string original)
        {

            if (original == null || original.Length == 0) return "";

            // Run the original through the massage word-by-word
            string result =
              Regex.Replace(original.ToLower(), @"\b(\w+)\b", new MatchEvaluator(HandleSingleWord));

            // Always uppercase the first character
            return Char.ToUpper(result[0]) + (result.Length > 1 ? result.Substring(1) : "");
        }


        // This helper method properizes (sp?) the case of a single word (regex match)
        // NOTE: The input is in all lowercase as forced by the ProperCase method.
        private static string HandleSingleWord(Match m)
        {

            string word = m.Groups[1].Value;

            // Is this word defined as all-lowercase?
            foreach (string lcw in lowerCaseWords)
                if (word == lcw)
                    return word;

            // Is this word defined as a fixed-case word?
            foreach (string fcw in fixedCaseWords)
                if (String.Compare(word, fcw, true) == 0)
                    return fcw;

            // Ok, this is a normal word; uppercase the first letter
            if (word.Length == 1)
                return Char.ToUpper(word[0]).ToString();
            word = Char.ToUpper(word[0]) + word.Substring(1);

            // Check if this word starts with one of the uppercasing prefixes
            // Note: Only one of the uppercasing prefixes is applies
            foreach (string ucPrefix in upperCasePrefixes)
                if (word.StartsWith(ucPrefix) && word.Length > ucPrefix.Length)
                    return word.Substring(0, ucPrefix.Length) +
                            Char.ToUpper(word[ucPrefix.Length]) +
                            (word.Length > ucPrefix.Length + 1
                              ? word.Substring(ucPrefix.Length + 1)
                              : "");

            return word;
        }
    }
}
