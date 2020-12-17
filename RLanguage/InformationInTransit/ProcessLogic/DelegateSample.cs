using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InformationInTransit.ProcessLogic
{
    delegate void Func(string s);

    sealed class DelegateSample
    {
        public static void Main(string[] argv)
        {
            ForAll(argv, SayLine);
        }

        public static void SayLine(string arg)
        {
            System.Console.WriteLine(arg);
        }

        public static void ForAll(string[] argv, Func call)
        {
            if (call != null)
            {
                foreach (string arg in argv)
                {
                    call(arg);
                }
            }
        }
    }
}
