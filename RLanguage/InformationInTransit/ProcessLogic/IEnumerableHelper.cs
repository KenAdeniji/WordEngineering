#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
#endregion

namespace InformationInTransit.ProcessLogic
{
    #region IEnumerableHelper definition
    public static partial class IEnumerableHelper
    {
        #region Methods
        public static void Main(string[] argv)
        {
            foreach (char currentCharacter in Letters())
            {
                System.Console.WriteLine(currentCharacter);
            }
            foreach (char value in EchoUntil("0123456789.ABC"))
            {
                System.Console.WriteLine(value);
            }
        }

        public static IEnumerable<char> EchoUntil(IEnumerable<char> inputSequence)
        {
            foreach (char value in inputSequence)
            {
                if (value != '.')
                {
                    yield return value;
                }
                else
                {
                    yield break;
                }
            }
        }

        public static IEnumerable<char> Letters()
        {
            char currentCharacter = 'a';
            do
            {
                yield return currentCharacter;
            } while (currentCharacter++ < 'z');
        }
        #endregion
    }
    #endregion
}

