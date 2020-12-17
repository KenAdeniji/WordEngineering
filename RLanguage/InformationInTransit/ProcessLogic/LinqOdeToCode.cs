#region Using directives
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
#endregion

namespace InformationInTransit.ProcessLogic
{
    #region LinqOdeToCode
    public static partial class LinqOdeToCode
    {
        #region Methods
        public static void Main(String[] argv)
        {
            UseWhereExtensionMethod();
            LambdaExpression();
            LambdaExpressionStatementBlock();
            InvokingLambda();
            ExpressionTree();
            QueryExpressions();
            AnonymousType();
        }

        public static void AnonymousType()
        {
            var processList =
                from process in Process.GetProcesses()
                orderby 
                    process.Threads.Count descending,
                    process.ProcessName ascending
                select new
                {
                    Name = process.ProcessName,
                    ThreadCount = process.Threads.Count
                };
            ObjectDumper.Write(processList);
        }

        public static void ExpressionTree()
        {
            Expression<Func<int, int>> squareExpression =
                            x => x * x;
            Expression<Func<int, int, int>> multExpression =
                                        (x, y) => x * y;
            Expression<Action<int>> printExpression =
                                        x => Console.WriteLine(x);

            Func<int, int> square = squareExpression.Compile();

            int a = 3;
            int aSquared = square(a);

            Console.WriteLine(aSquared); // prints 9
        }

        public static void InvokingLambda()
        {
            Func<int, int> square = x => x * x;
            Func<int, int, int> multiply = (x, y) => x * y;
            Action<int> print = x => Console.WriteLine(x);

            print(square(multiply(3, 5)));
        }

        public static void LambdaExpression()
        {
            IEnumerable<string> filteredList =
                Cities.Where(s => s.StartsWith("L"));
            ObjectDumper.Write(filteredList);
        }

        public static void LambdaExpressionStatementBlock()
        {
            IEnumerable<string> filteredList =
                Cities.Where
                (
                    s =>
                    {
                        string temp = s.ToLower();
                        return temp.StartsWith("L", true, CultureInfo.InvariantCulture);
                    }
                );
            ObjectDumper.Write(filteredList);
        }

        public static void QueryExpressions()
        {
            IEnumerable<string> filteredCities =
            from city in Cities
            where city.StartsWith("L") && city.Length < 15
            orderby city
            select city;            
            ObjectDumper.Write(filteredCities);
        }

        public static void UseWhereExtensionMethod()
        {
            IEnumerable<string> filteredList =
                Cities.Where(delegate(string s) { return s.StartsWith("L"); });

            // filteredList will include only London and Los Angeles
            ObjectDumper.Write(filteredList);
        }
        #endregion

        #region Statics
        public static readonly string[] Cities =
        {
            "Boston",
            "Los Angeles",
            "Seattle",
            "London",
            "Hyderabad"
        };
        #endregion
    }
    #endregion
}
