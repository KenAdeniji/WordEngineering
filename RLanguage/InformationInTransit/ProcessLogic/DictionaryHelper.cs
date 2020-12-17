using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InformationInTransit.ProcessLogic
{
    class DictionaryHelper
    {
        public static void Main(string[] argv)
        {
            Dump();
        }

        public static void Dump()
        {
            string name;
            foreach (char key in DictionaryNames.Keys)
            {
                name = DictionaryNames[key];
                DictionaryNames.TryGetValue(key, out name);
                System.Console.WriteLine("{0, -10} {1, -10}", key, name); //Fixed length.
            }
        }

        public static Dictionary<char, string> DictionaryNames = new Dictionary<char, string> { 
            {'A', "Andrew"},
            {'B', "Barry"},
            {'C', "Carl"}
        };
    }
}
