using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace InformationInTransit.ProcessLogic
{
    public static partial class LinqQueryExpressionLambdaExpression
    {
        public static void Main(string[] argv)
        {
            IEnumerable<string> names = QueryExpression();
            IEnumerable<string> methodSyntax = QueryExpressionMethodSyntax();
            IEnumerable<int> lambdaExpression = LambdaExpression();
            int aggregateNumbers = AggregateNumbers();
            string aggregateNames = AggregateNames();
            string aggregateNamesUsingStringBuilder = AggregateNamesUsingStringBuilder();
            string aggregateNamesUsingExtensionMethod = AggregateNamesUsingExtensionMethod();
            PeopleGroup();
        }

        public static void PrintEnumerable<E>(IEnumerable<E> set)
        {
            foreach (E current in set)
            {
                System.Console.WriteLine(current);
            }
        }

        public static IEnumerable<string> QueryExpression()
        {
            IEnumerable<string> expr = from s in Names
                                       where s.Length == 5
                                       orderby s
                                       select s.ToUpper();
            PrintEnumerable(expr);
            return expr;
        }

        public static IEnumerable<string> QueryExpressionMethodSyntax()
        {
            IEnumerable<string> expr = Names
                                        .Where(s => s.Length == 5)
                                        .OrderBy(s => s)
                                        .Select(s => s.ToUpper());
            PrintEnumerable(expr);
            return expr;
        }

        public static IEnumerable<int> LambdaExpression()
        {
            IEnumerable<int> numbers = Numbers.Where(n => n > 5);
            PrintEnumerable(numbers);
            return numbers;
        }

        public static string AggregateNames()
        {
            string aggregateNames = Names.Aggregate((a, i) => a += i);
            System.Console.WriteLine(aggregateNames);
            return aggregateNames;
        }

        public static string AggregateNamesUsingExtensionMethod()
        {
            string aggregateNames = Names.StringConcatenate();
            System.Console.WriteLine(aggregateNames);
            return aggregateNames;
        }

        public static string AggregateNamesUsingStringBuilder()
        {
            string aggregateNames = Names.Aggregate(
                                        new StringBuilder(),
                                        (sb, i) => sb.Append(i),
                                        sb => sb.ToString()
                                    );
            System.Console.WriteLine(aggregateNames);
            return aggregateNames;
        }

        public static int AggregateNumbers()
        {
            int aggregateNumbers = Numbers.Aggregate((a, i) => a += i);
            System.Console.WriteLine(aggregateNumbers);
            return aggregateNumbers;
        }

        public static void PeopleGroup()
        {
            var peopleGroup = People.GroupBy(s => s.Age);
            foreach (var group in peopleGroup)
            {
                System.Console.WriteLine("Group Age: {0}", group.Key);
                foreach (var person in group)
                {
                    System.Console.WriteLine("Name: {0}", person.Name);
                }
            }
        }

        public static string StringConcatenate(this IEnumerable<string> source)
        {
            return source.Aggregate(
                new StringBuilder(),
                (s, i) => s.Append(i),
                s => s.ToString());
        }

        public static readonly string[] Names = { "Burke", "Connor", "Frank",
                   "Everett", "Albert", "George",
                   "Harris", "David" };

        public static readonly int[] Numbers = new[] { 3, 8, 4, 6, 1, 7, 9, 2, 4, 8 };

        public static readonly Collection<Person> People = new Collection<Person>{
            new Person { Name = "Bob", Age = 3 },
            new Person { Name = "Bill", Age = 3 },
            new Person { Name = "Mary", Age = 4 },
            new Person { Name = "June", Age = 3 },
            new Person { Name = "Nancy", Age = 4 },
            new Person { Name = "Shelly", Age = 4 },
            new Person { Name = "Cheryl", Age = 3 },
            new Person { Name = "Joe", Age = 3 }
        };

        public class Person 
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }
    }
}
