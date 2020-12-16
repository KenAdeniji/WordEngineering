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
   public static partial class PointerGoalKicker
   {
		public static void Main(String[] argv)
		{
			int[] arr = new int[] {1, 6, 3, 3, 9};

			for (int i = 0; i < arr.Length; i++)
			{ 
				Console.WriteLine(arr[i]);
			} 

			//using foreach: 
			foreach (int element in arr)
			{ 
				Console.WriteLine(element);
			}			

			//using unsafe access with pointers https://msdn.microsoft.com/en-ca/library/y31yhkeb.aspx
			unsafe 
			{
				int length = arr.Length;
				fixed (int* p = arr)
				{   
					int* pInt = p;
					while (length-- > 0)
					{ 
						Console.WriteLine(*pInt);
						pInt++;// move pointer to next element
					} 
				} 
			}
			
		}	
	}
}
