using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InformationInTransit.ProcessLogic
{
    class TowersOfHanoi
    {
        public static void doHanoi(int n, string f, string t, string u)
        { 
            if (n <= 1) { System.Console.WriteLine(f + " --> " + t); } 
            else 
            { 
                doHanoi(n - 1, f, u, t);
                System.Console.WriteLine(f + " --> " + t);
                doHanoi(n - 1, u, t, f);
            } 
        }

        [STAThread]
        static void Main(string[] args)
        { 
            if (args.Length != 1)
            {
                System.Console.WriteLine("usage: TowersOfHanoi <number>");
                System.Environment.Exit(1);
            }
            int n = System.Convert.ToInt32(args[0]);
            if ((n < 1))
            {
                System.Console.WriteLine("usage: TowersOfHanoi <number>"); 
                System.Environment.Exit(1);
            }
            doHanoi(n, "1", "3", "2");
            System.Environment.Exit(0); 
        }
    }
}
