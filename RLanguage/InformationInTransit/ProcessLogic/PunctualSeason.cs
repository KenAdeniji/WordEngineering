#region Using directives
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
#endregion

namespace InformationInTransit.ProcessLogic
{
    #region PunctualSeason definition
    /// <summary>
    /// 20070803 String interning.
    /// </summary>
    public partial class PunctualSeason
    {
        #region Methods
        /// <summary>
        /// 20070804
        /// </summary>
        public static string IndexFingerE(string kowe)
        {
            char currentChar;
            int accumulatingTotal = 0;
            Regex regex;
            StringBuilder indexFingerE = new StringBuilder();
            kowe = kowe.ToLower();

            for (int index = 0; index < kowe.Length; ++index)
            {
                currentChar = kowe[index];
                if (!char.IsLetter(currentChar))
                {
                    continue;
                }
                regex = new Regex(String.Format("{0}", currentChar));
                MatchCollection matchCollection = regex.Matches(kowe);

                accumulatingTotal += (currentChar - 'a' + 1) * matchCollection.Count;

                indexFingerE.AppendFormat
                (
                    "{0} ",
                    accumulatingTotal
                );
                kowe = kowe.Replace(currentChar, ' ');
            }

            return (indexFingerE.ToString().TrimEnd());
        }

        public static void Main(string[] argv)
        {
            System.Console.WriteLine(IndexFingerE(string.Join("", argv)));
        }
        #endregion
    }
    #endregion
}