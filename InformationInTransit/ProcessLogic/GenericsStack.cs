using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InformationInTransit.ProcessLogic
{
    /// <summary>
    /// An open generic type is a generic type for which none of its parameter types are specified. For example Stack<T> and Dictionary<K,V> are open generic types.
    /// A closed generic type is a generic type for which all the type parameters are specified. For example, Stack<int>, Dictionary<int,string> and Stack<Stack<int>> are closed generic types.
    /// The visibility of a generic type is the intersection of the generic type with the visibility of the parameter types. If the visibility of all the C, T1, T2 and T3 types is set to public, then the visibility of C<T1,T2,T3> is also public; but if the visibility of only one of these types is private, then the visibility of C<T1,T2,T3> is private.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class GenericsStack<T>
    {
        private T[] m_ItemsArray;
        private int m_Index = 0;
        public const int MAX_SIZE = 100;
        public GenericsStack() { m_ItemsArray = new T[MAX_SIZE]; }
        public T Pop()
        {
            if (m_Index == 0)
                throw new System.InvalidOperationException(
                   "Can't pop an empty stack.");
            return m_ItemsArray[--m_Index];
        }
        public void Push(T item)
        {
            if (m_Index == MAX_SIZE)
                throw new System.StackOverflowException(
                   "Can't push an item on a full stack.");
            m_ItemsArray[m_Index++] = item;
        }
    }
    
    public class TestGenericsStack
    {
        public static void Main(string[] argv)
        {
            GenericsStack<int> stack = new GenericsStack<int>();
            stack.Push(1234);
            int number = stack.Pop(); // Don't need any awkward cast.
            stack.Push(5678);
            //string sNumber = stack.Pop();  // Compilation Error:
            // Cannot implicitly convert type 'int' to 'string'.
        }
    }
}
