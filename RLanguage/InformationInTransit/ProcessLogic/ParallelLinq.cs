using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InformationInTransit.ProcessLogic
{
    public static partial class ParallelLinq
    {
        public static void Main(string[] argv)
        {
            AsParallel();
            AsParallelAsOrdered();
        }

        public static void AsParallel()
        {
            var source = Enumerable.Range(1, 10000);

            // Opt-in to PLINQ with AsParallel
            var evenNums = from num in source.AsParallel()
                           where num % 2 == 0
                           select num;

            foreach (int evenNum in evenNums)
            {
                System.Console.WriteLine(evenNum);
            }
        }

        public static void AsParallelAsOrdered()
        {
            var source = Enumerable.Range(1, 10000);

            // Opt-in to PLINQ with AsParallel
            var evenNums = from num in source.AsParallel().AsOrdered()
                           where num % 2 == 0
                           select num;

            foreach (int evenNum in evenNums)
            {
                System.Console.WriteLine(evenNum);
            }
        }

    }
}
