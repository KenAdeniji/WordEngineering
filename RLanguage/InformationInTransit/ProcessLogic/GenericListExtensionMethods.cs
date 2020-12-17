using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InformationInTransit.ProcessLogic
{
    public static partial class GenericListExtensionMethods
    {
        public static void Main(string[] argv)
        {
            List<string> stackList = new List<string>();
            foreach (string arg in argv)
            {
                stackList.StackPush(arg);
            }
            string currentElement;
            while (true)
            {
                try
                {
                    currentElement = stackList.StackPop();
                    System.Console.WriteLine(currentElement);
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                    break;
                }
            }
        }

        public static T StackPop<T>(this List<T> TheList)
        {
            if (TheList.Count == 0)
                throw new Exception("Nothing to pop.");

            int LastPos = TheList.Count - 1;
            T Result = TheList[LastPos];
            TheList.RemoveAt(LastPos);

            return Result;
        }

        public static void StackPush<T>(this List<T> TheList, T Value)
        {
            TheList.Add(Value);
        }
    }
}
