#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
#endregion

namespace InformationInTransit.ProcessLogic
{
    #region Palindrome definition
    public static partial class Palindrome
    {
        public static void Main(string[] argv)
        {
            foreach (string s in argv)
            {
                System.Console.WriteLine(IsPalindrome(s));
            }
        }

        /// <summary>
        /// bool palindrome = IsPalindrome("Eve");
        /// bool palindrome = IsPalindrome("Abba");
        /// bool palindrome = IsPalindrome("Anna");
        /// </summary>
        public static bool IsPalindrome(this string word)
        {
            char left;
            char right;
            int compare;
            int length;
            int halfLength;
            bool valid = true;

            length = word.Length - 1;
            halfLength = length / 2;
            for (int i = 0; i <= halfLength; i++)
            {
                left = word[i];
                right = word[length - i];
                compare = Char.ToLowerInvariant(left).CompareTo(Char.ToLowerInvariant(right));
                if (compare != 0)
                {
                    valid = false;
                }
            }
            return valid;
        }
    }
    #endregion
}
