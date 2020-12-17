using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InformationInTransit.ProcessLogic
{
    class SimpleGenericMethod
    {
       public static void Main( string[] args )
      {
         // create arrays of int, double and char
         int[] intArray = { 1, 2, 3, 4, 5, 6 };
         double[] doubleArray = { 1.1, 2.2, 3.3, 4.4, 5.5, 6.6, 7.7 };
         char[] charArray = { 'H', 'E', 'L', 'L', 'O' };
   
         Console.WriteLine( "Array intArray contains:" );
         PrintArray( intArray ); // pass an int array argument
         Console.WriteLine( "Array doubleArray contains:" );
         PrintArray( doubleArray ); // pass a double array argument
         Console.WriteLine( "Array charArray contains:" );
         PrintArray( charArray ); // pass a char array argument
      } // end Main
   
      // output array of all types
      static void PrintArray<E>( E[] inputArray )
      {
         foreach ( E element in inputArray )
            Console.Write( element + " " );
   
         Console.WriteLine( "\n" );
      } // end method PrintArray 
    }
}
