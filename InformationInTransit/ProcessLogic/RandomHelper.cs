using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InformationInTransit.ProcessLogic
{
    public static partial class RandomHelper
    {
        public static void Main(string[] argv)
        {
            for (int index = 0; index < 5; ++index)
            {
                string randomString = GenerateRandomString(5);
                System.Console.WriteLine(randomString);
            }
			
			Colors.Randomize();
            for (int index = 0, count = Colors.Length; index < count; ++index)
            {
                System.Console.WriteLine(Colors[index]);
            }
        }

        /// <summary>
        /// 2014-06-05 dotnetpickles.com/2013/03/how-to-create-generate-random-string.html
        /// 2014-06-05 http://stackoverflow.com/questions/1785744/how-do-i-seed-a-random-class-to-avoid-getting-duplicate-random-values
        /// </summary>
        public static string GenerateRandomString(int length)
        {
            //It will generate string with combination of small,capital letters and numbers
            char[] charArr = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz".ToCharArray();
            string randomString = string.Empty;
            Random random;
            for (int i = 0; i < length; i++)
            {
                random = new Random(Guid.NewGuid().GetHashCode());
                //Don't Allow Repeatation of Characters
                int x = random.Next(1, charArr.Length);
                if (!randomString.Contains(charArr.GetValue(x).ToString()))
                    randomString += charArr.GetValue(x);
                else
                    i--;
            }
            return randomString;
        }
		
		public static void Randomize<T>(this T[] items)
		{
			// For each spot in the array, pick
			// a random item to swap into that spot.
			for (int i = 0; i < items.Length - 1; i++)
			{
				int j = Rand.Next(i, items.Length);
				T temp = items[i];
				items[i] = items[j];
				items[j] = temp;
			}
		}

		public static void Randomize<T>(this List<T> items)
		{
			// Convert into an array.
			T[] item_array = items.ToArray();

			// Randomize.
			item_array.Randomize();

			// Copy the items back into the list.
			items.Clear();
			items.AddRange(item_array);
		}
		
		public static Random Rand = new Random();
		public static string[] Colors = {
			"Red",
			"White",
			"Blue"
		};
    }
}
