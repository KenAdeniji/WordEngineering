using System;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Collections.Generic;

namespace WordEngineering
{
    public static partial class ParallelTutorial
    {
        public static void Main(string[] argv)
        {
            Parallel.For(0, 100, (i) =>
            {
                var watch = Stopwatch.StartNew();
                DoWork();
                watch.Stop();
                Console.WriteLine("{0} took {1} milliseconds", i, watch.ElapsedMilliseconds);
            }
            );

            List<int> list = new List<int>();

            // populate list

            Parallel.ForEach(list, (item) =>
            {
                // parallel work here
            }
            );

            Parallel.Invoke(A, B, C, D, E);
        }

        public static void A() {}

        public static void B() {}

        public static void C() {}

        public static void D() {}

        public static void E() {}

        private static void DoWork()
        {
            for (int i = 3; i < 30000; i++)
            {
                if (IsPrime(i))
                    ;
            }
        }

        private static bool IsPrime(int i)
        {
            for (int j = 2; j <= (i / 2); j++)
            {
                if ((i % j) == 0)
                    return false;
            }
            return true;
        }


    }
}
