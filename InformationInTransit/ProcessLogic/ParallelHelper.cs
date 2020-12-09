using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Threading.Tasks;
using System.Threading;

namespace InformationInTransit.ProcessLogic
{
    public static partial class ParallelHelper
    {
        public static void Main(string[] argv)
        {
            For();
            ForAll();
            ForEach();
        }

        public static void For()
        {
            int N = 10;
            Parallel.For(0, N, (i, loopState) =>
            {
                Console.WriteLine(i);
                if (i == 5)
                {
                    loopState.Break();
                }
            });
        }

        public static void ForAll()
        {
            var source = Enumerable.Range(100, 20000);

            // Result sequence might be out of order.
            System.Linq.ParallelQuery<int> parallelQuery =  from num in source.AsParallel()
                                                            where num % 10 == 0
                                                            select num;

            // Process result sequence in parallel
            parallelQuery.ForAll((e) => ForAllParallelQuery(e));
        }

        public static void ForAllParallelQuery(int parallelQuery)
        {
            System.Console.WriteLine(parallelQuery);
        }

        public static void ForEach()
        {
            //  Method signature: Parallel.ForEach(IEnumerable<TSource> source, Action<TSource> body)
            Parallel.ForEach
            (
                MonthNames,
                currentMonth =>
                {
                    // Peek behind the scenes to see how work is parallelized.
                    // But be aware: Thread contention for the Console slows down parallel loops!!!
                    Console.WriteLine
                    (
                        "Processing {0} on thread {1}",
                        currentMonth,
                        Thread.CurrentThread.ManagedThreadId
                    );
                } //close lambda expression
            ); //close method invocation
        }

        public static readonly String[] AbbreviatedDayNames = DateTimeFormatInfo.CurrentInfo.AbbreviatedDayNames;
        public static readonly String[] AbbreviatedMonthNames = DateTimeFormatInfo.CurrentInfo.AbbreviatedMonthNames;

        public static readonly String[] DayNames = DateTimeFormatInfo.CurrentInfo.DayNames;
        public static readonly String[] MonthNames = DateTimeFormatInfo.CurrentInfo.MonthNames;
    }
}
