#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
#endregion

namespace InformationInTransit.ProcessLogic
{
    #region ProjectEuler definition
    public static partial class ProjectEuler
    {
        #region Methods
        /// <summary>
        /// Project Euler problem 6
        /// Euler Problem six asks you to find the difference between the sum of squares and the square of the sum for the natural numbers 1 through 100.
        /// I took the easy route, and made a brute force implementation in C#. There are a couple new bits of LINQ syntax here. This query creates two different anonymous types. One for the number / square pair, the second is the aggregate answer for the sum and the sum of squares.
        /// The important points are that this is done in a single iteration. It's pulling each value in from the initial sequence and doing all the calculations in one iteration of the sequence:
        /// </summary>
        /// <see cref="http://srtsolutions.com/blogs/billwagner/archive/2008/04/11/project-euler-problem-6.aspx"/>
        public static int Problem6()
        {
            var aggregate = (from number in Enumerable.Range(1, 100)
                             select new { number, square = number * number }).
                Aggregate(new { Sum = 0, SumOfSquares = 0 },
                (sums, val) => new
                {
                    Sum = sums.Sum + val.number,
                    SumOfSquares = sums.SumOfSquares + val.square
                });

            int SquareOfSums = aggregate.Sum * aggregate.Sum;
            int answer = SquareOfSums - aggregate.SumOfSquares;
            System.Console.WriteLine
            (
                "{0} - {1} = {2}",
                SquareOfSums,
                aggregate.SumOfSquares,
                SquareOfSums - aggregate.SumOfSquares
            );
            return answer;
        }
        #endregion
    }
    #endregion
}
