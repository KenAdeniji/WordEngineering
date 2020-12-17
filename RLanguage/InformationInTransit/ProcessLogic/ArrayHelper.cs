using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace InformationInTransit.ProcessLogic
{
	public static partial class ArrayHelper
	{
		public static void Main(string[] argv)
		{
			int[] a = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
			a.Shuffle();
			foreach(int i in a)
			{
				System.Console.WriteLine(i);
			}	
		}
		
		///<remarks>
		///http://extensionmethod.net/csharp/array/shuffle
		///</remarks>
		///<example>
		///int[] a = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
		///a.Shuffle();
		///<example>
		public static T[] Shuffle<T>(this T[] list)
		{
			var r = new Random((int)DateTime.Now.Ticks);
			for (int i = list.Length - 1; i > 0; i--)
			{
				int j = r.Next(0, i - 1);
				var e = list[i];
				list[i] = list[j];
				list[j] = e;
			}
			return list;
		}
	}
}
