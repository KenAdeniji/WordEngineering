#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
#endregion

namespace InformationInTransit.ProcessLogic
{
    #region GenericSample definition
    public static class GenericSample
    {
        #region Methods
        public static void Main(string[] argv)
        {
            TestProcessItems();
            TestSwap();
        }

        static void ProcessItems<T>(IList<T> coll)
        {
            foreach (T item in coll)
            {
                System.Console.Write(item.ToString() + " ");
            }
            System.Console.WriteLine();
        }

        /*
			Swap<string>(ref b1, ref b2);
		*/
		static void Swap<T>(ref T lhs, ref T rhs)
        {
			Console.WriteLine("You sent the Swap() method a {0}", typeof(T));
            T temp;
            temp = lhs;
            lhs = rhs;
            rhs = temp;
        }

        static void TestProcessItems()
        {
            int[] arr = { 0, 1, 2, 3, 4 };
            List<int> list = new List<int>();

            for (int x = 5; x < 10; x++)
            {
                list.Add(x);
            }

            ProcessItems<int>(arr);
            ProcessItems<int>(list);
        }

        public static void TestSwap()
        {
            int a = 1;
            int b = 2;
            Swap<int>(ref a, ref b);
            Console.WriteLine(a + " " + b);
        }
        #endregion
    }
    #endregion
}
