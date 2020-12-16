using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

using System.Text;

/*
	2018-08-15	https://goalkicker.com/CSharpBook/CSharpNotesForProfessionals.pdf
*/
namespace InformationInTransit.GoalKicker
{
   public static partial class ArrayGoalKicker
   {
		public static void Main(String[] argv)
		{
			bool[] booleanArray = Enumerable.Repeat(true, 10).ToArray();
			
			int[] arr1 = { 3, 5, 7 };
			int[] arr2 = { 3, 5, 7 };
			bool result = arr1.SequenceEqual(arr2);
			Console.WriteLine("Arrays equal? {0}", result);
			
			int[] sequence = Enumerable.Range(1, 100).ToArray();
			
			int[] squares = Enumerable.Range(2, 10).Select(x => x * x).ToArray();
			
			IEnumerable<int> enumerableIntegers = arr1; //Allowed because arrays implement IEnumerable<T> 
			List<int> listOfIntegers = new List<int>();
			listOfIntegers.AddRange(arr1); //You can pass in a reference to an array to populate a List.
		}	
	}
}
