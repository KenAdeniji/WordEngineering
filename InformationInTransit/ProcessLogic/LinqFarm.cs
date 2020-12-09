#region Using directive
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
#endregion

namespace InformationInTransit.ProcessLogic
{
	#region LinqFarm definition
	public partial class LinqFarm
	{
		#region Methods
		public static void Main(string[] argv)
		{
            Count();
            /*
			Distinct();
            Except();
            Intersect();
            IntersectCollection();
            int add = LambdaAdd(6, 5);
            Square();
            Union();
            */ 
		}

        /// <summary>
        /// 20080727
        /// </summary>
        public static void Count()
        {
            var list = Enumerable.Range(1, 25);
            Console.WriteLine
            (
                "Total Count: {0}, Count the even numbers: {1}",
                list.Count(),
                list.Count(n => n % 2 == 0)
            );
        }
      
        ///<summary>
        /// 20080721 The Distinct operator will find all the unique items in a list.
        /// The Distinct method displays the numbers 1, 2, 3.
        ///</summary>
        /// <see>
        /// http://blogs.msdn.com/charlie/archive/2008/07/12/the-linq-set-operators.aspx
        /// </see>
        public static void Distinct() 
        {
            var listA = new List<int> { 1, 2, 3, 3, 2, 1 };
            var listB = listA.Distinct();

            foreach (var item in listB)
            {
                Console.WriteLine(item);
            }
        }

        ///<summary>
        /// 20080721 The Except operator shows all the items in one list minus the items in a second list.
        /// The Except method prints out the numbers 1, 2, 5, and 6
        ///</summary>
        /// <see>
        /// http://blogs.msdn.com/charlie/archive/2008/07/12/the-linq-set-operators.aspx
        /// </see>
        public static void Except() 
        {
            var listA = Enumerable.Range(1, 6);
            var listB = new List<int> { 3, 4 };

            var listC = listA.Except(listB);

            foreach (var item in listC)
            {
                Console.WriteLine(item);
            }
        }

        ///<summary>
        /// 20080721 The Intersect operator is for only common representation between the two unions.
        /// The ShowIntersect method displays the numbers 3 and 4
        ///</summary>
        /// <see>
        /// http://blogs.msdn.com/charlie/archive/2008/07/12/the-linq-set-operators.aspx
        /// </see>
        public static void Intersect()
        {
            var listA = Enumerable.Range(1, 4);
            var listB = new List<int> { 3, 4, 5, 6 };

            var listC = listA.Intersect(listB);

            foreach (var item in listC)
            {
                System.Console.WriteLine(item);
            }
        }

        ///<summary>
        /// 20080722
        ///</summary>
        /// <see>
        /// blogs.msdn.com/charlie/archive/2008/07/12/the-linq-set-operators.aspx
        /// </see>
        public static void IntersectCollection()
        {
            ///Get the methods defined by List<int>.
            ///The where clause limits to non-inherited methods.
            ///The group limits to one record for each overloaded method.
            var queryList = from m in typeof(List<int>).GetMethods()
                            where m.DeclaringType == typeof(List<int>)
                            group m by m.Name into g
                            select g.Key;
            var queryArray = from m in typeof(ArrayList).GetMethods()
                             where m.DeclaringType == typeof(ArrayList)
                             group m by m.Name into g
                             select g.Key;
            //Intersect: What the two lists have in common?
            var listIntersect = queryList.Intersect(queryArray);
            Console.WriteLine("Count: {0}", listIntersect.Count());
            foreach (var item in listIntersect) 
            { 
                System.Console.WriteLine(item); 
            }
            //Except: The items that the generic lists supports that are not part of the old style collection
            var listDifference = queryList.Except(listIntersect);
            foreach (var item in listDifference)
            {
                System.Console.WriteLine(item);
            }
        }
               
        ///<summary>
        /// 20080720
        ///</summary>
        /// <see>
        /// http://blogs.msdn.com/charlie/archive/2008/06/28/lambdas.aspx
        /// </see>
        public static int LambdaAdd(int a, int b)
		{
		    //This lambda expression returns one value, and does not pass any non-local variable.
            //Func<int>, The delegate signature, first the return type, and next the parameters the delegate will take.
            //lamdaAdd, The delegate name.
            //(), The variables, the delegate will take.
            //=>, Lambda operator, goes to.
            //(a+b) The delegate method.
            Func<int> lambdaAdd = () => (a+b);
			int add = lambdaAdd();
            System.Console.WriteLine(add);
			return add;
		}

        public static IEnumerable<int> Square()
        {
            IEnumerable<int> squares = Enumerable.Range(1, 10).Select(x => x * x);

            foreach (int num in squares)
            {
                System.Console.WriteLine(num);
            }
            return squares;
        }

        ///<summary>
        /// 20080721 The Show Union method displays the number 1, 2, 3, 4, 5 and 6.
        /// Join two collections together, only retaining the unique members.
        ///</summary>
        /// <see>
        /// http://blogs.msdn.com/charlie/archive/2008/07/12/the-linq-set-operators.aspx
        /// </see>
        public static void Union()
        {
            var listA = Enumerable.Range(1, 3);
            var listB = new List<int> { 3, 4, 5, 6 };

            var listC = listA.Union(listB);

            foreach (var item in listC)
            {
                System.Console.WriteLine(item);
            }
        } 
		#endregion	
	}
	#endregion
}

