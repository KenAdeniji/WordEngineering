using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InformationInTransit.ProcessLogic
{
	public static partial class IListHelper
	{
		public static void Main(string[] argv)
		{
		}
		
		public static void Randomize<t>(this IList<t> target)
        {
            Random RndNumberGenerator = new Random();
            SortedList<int, t> newList = new SortedList<int, t>();
            foreach (t item in target)
            {
                newList.Add(RndNumberGenerator.Next(), item);
            }
            target.Clear();
            for (int i = 0; i < newList.Count; i++)
            {
                target.Add(newList.Values[i]);
            }
        }
	}
}

