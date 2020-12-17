#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Xml;
#endregion

namespace InformationInTransit.ProcessLogic
{
    #region ParallelLinqIntroduction definition
    class ParallelLinqIntroduction
    {
        #region Methods
        public static void Main(string[] argv)
        {
            SourceAsParallel();
            SourceWithDegreeOfParallelism();
            SourceAsOrdered();
        }

        public static void SourceAsParallel()
        {
			var source = Enumerable.Range(1, 10000);
            // Opt-in to PLINQ with AsParallel
            var evenNums = from num in source.AsParallel()
                           where num % 2 == 0
                           select num;
            foreach (int even in evenNums)
            {
                System.Console.WriteLine(even);
            }
        }

        public static void SourceWithDegreeOfParallelism()
        {
            var source = Enumerable.Range(1, 10000);
            // Opt-in to PLINQ with AsParallel
            var evenNums = from num in source.AsParallel().WithDegreeOfParallelism(2)
                           where num > 2500 && num < 7500
                           select num;
            foreach (int even in evenNums)
            {
                System.Console.WriteLine(even);
            }
        }

        public static void SourceAsOrdered()
        {
            var source = Enumerable.Range(1, 10000);
            // Opt-in to PLINQ with AsParallel
            var evenNums = from num in source.AsParallel().AsOrdered()
                           where num % 10 == 0
                           select num;
            foreach (int even in evenNums)
            {
                System.Console.Write(even);
            }
        }
        #endregion
    }
    #endregion
}
