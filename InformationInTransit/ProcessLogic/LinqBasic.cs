using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InformationInTransit.ProcessLogic
{
    public static partial class LinqBasic
    {
        public static readonly string[] Places = { "Hong Kong", "Singapore", "Shanghai" };
        public static readonly int[] Numbers = { 1, 2, 3, 4, 5 };
        public static readonly int[] Alike = { 5, 6, 7, 8, 9 };

        public static void Main(string[] argv)
        {
            IEnumerable<String> filteredPlaces = LinqWhere();
            IEnumerable<String> filteredNames = LinqWhereLambdaExpression();
            IEnumerable<String> upperNames = LinqSelectLambdaExpression();
            LinqSelectAnonymousTypesLambdaExpression();
            IEnumerable<int> numbersTake = LinqTake();
            IEnumerable<int> numbersSkip = LinqSkip();
            IEnumerable<int> numbersReverse = LinqReverse();
            LinqElementOperators();
            LinqAggregateOperators();
            LinqQuantifiers();
            LinqSetOperators();
        }

        public static IEnumerable<String> LinqWhere()
        {
            IEnumerable<String> filteredPlaces = System.Linq.Enumerable.Where(Places, n => n.Length > 8);
            foreach (string place in filteredPlaces)
            {
                System.Console.WriteLine(place);
            }
            return filteredPlaces;
        }

        public static IEnumerable<String> LinqWhereLambdaExpression()
        {
            IEnumerable<String> filteredNames = Places.Where(n => n.Length >= 4);
            foreach (string name in filteredNames)
            {
                System.Console.WriteLine(name);
            }
            return filteredNames;
        }

        public static IEnumerable<String> LinqSelectLambdaExpression()
        {
            IEnumerable<String> upperNames = Places.Select(n => n.ToUpper());
            foreach (string name in upperNames)
            {
                System.Console.WriteLine(name);
            }
            return upperNames;
        }

        public static void LinqSelectAnonymousTypesLambdaExpression()
        {
            var anonymousTypes =    Places.Select
                                                    (
                                                            n => new
                                                            {
                                                                Name = n,
                                                                Length = n.Length
                                                            }
                                                    );
            foreach (var anonymousType in anonymousTypes)
            {
                System.Console.WriteLine(anonymousType);
            }

        }

        public static IEnumerable<int> LinqTake()
        {
            IEnumerable<int> numbers = Numbers.Take(2);
            foreach (int number in numbers)
            {
                System.Console.WriteLine(number);
            }
            return numbers;
        }

        public static IEnumerable<int> LinqSkip()
        {
            IEnumerable<int> numbers = Numbers.Skip(2);
            foreach (int number in numbers)
            {
                System.Console.WriteLine(number);
            }
            return numbers;
        }

        public static IEnumerable<int> LinqReverse()
        {
            IEnumerable<int> numbers = Numbers.Reverse();
            foreach (int number in numbers)
            {
                System.Console.WriteLine(number);
            }
            return numbers;
        }

        public static void LinqElementOperators()
        {
            int numbersFirst = Numbers.First();
            System.Console.WriteLine("First number: {0}", numbersFirst);

            int numbersLast = Numbers.Last();
            System.Console.WriteLine("Last number: {0}", numbersLast);

            int numbersElementAt = Numbers.ElementAt(3);
            System.Console.WriteLine("ElementAt(3): {0}", numbersElementAt);
        }

        public static void LinqAggregateOperators()
        {
            int numbersCount = Numbers.Count();
            System.Console.WriteLine("Count number: {0}", numbersCount);

            int numbersMin = Numbers.Min();
            System.Console.WriteLine("Minimum number: {0}", numbersMin);

            int numbersMax = Numbers.Max();
            System.Console.WriteLine("Maximum number: {0}", numbersMax);

            double numbersAverage = Numbers.Average();
            System.Console.WriteLine("Average number: {0}", numbersAverage);

            double numbersSum = Numbers.Sum();
            System.Console.WriteLine("Sum number: {0}", numbersSum);
        }

        public static void LinqQuantifiers()
        {
            bool hasNumberSeven = Numbers.Contains(7);
            System.Console.WriteLine("Contains number 7: {0}", hasNumberSeven);

            bool hasSomeElements = Numbers.Any();
            System.Console.WriteLine("Has content: {0}", hasSomeElements);

            bool hasOddNumbers = Numbers.Any(n => n % 2 == 1);
            System.Console.WriteLine("Has odd numbers: {0}", hasOddNumbers);

            bool hasAllOddNumbers = Numbers.All(n => n % 2 == 1);
            System.Console.WriteLine("Has all odd numbers: {0}", hasAllOddNumbers);
        }

        public static void LinqSetOperators()
        {
            IEnumerable<int> numbersConcat = Numbers.Concat(Alike);
            foreach (int number in numbersConcat)
            {
                System.Console.WriteLine(number);
            }

            IEnumerable<int> numbersUnion = Numbers.Union(Alike);
            foreach (int number in numbersUnion)
            {
                System.Console.WriteLine(number);
            }

            IEnumerable<int> numbersIntersect = Numbers.Intersect(Alike);
            foreach (int number in numbersIntersect)
            {
                System.Console.WriteLine(number);
            }

            IEnumerable<int> numbersExcept = Numbers.Except(Alike);
            foreach (int number in numbersExcept)
            {
                System.Console.WriteLine(number);
            }
        }
    }
}
