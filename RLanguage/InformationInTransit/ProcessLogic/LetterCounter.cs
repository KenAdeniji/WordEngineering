using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InformationInTransit.ProcessLogic
{
    public static partial class LetterCounter
    {
        public static void Main(string[] argv)
        {
            AlphabetCounter(String.Join(" ", argv));
        }

        public static Dictionary<char, int> AlphabetCounter(string sentence)
        {
            Dictionary<char, int> letterCount = new Dictionary<char, int>();
            sentence = sentence.ToUpper();
            foreach (char currentLetter in sentence)
            {
                if (!char.IsLetter(currentLetter))
                {
                    continue;
                }
                if (letterCount.ContainsKey(currentLetter) == false)
                {
                    letterCount[currentLetter] = 1;
                }
                else
                {
                    ++letterCount[currentLetter];
                }
            }

            foreach (KeyValuePair<char, int> keyValuePair in letterCount)
            {
                Console.WriteLine
                (
                    "Key = {0}, Value = {1}",
                    keyValuePair.Key,
                    keyValuePair.Value
                );
            }

            return letterCount;
        }
    }
}
