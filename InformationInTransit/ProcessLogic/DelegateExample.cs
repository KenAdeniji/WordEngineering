using System;
class DelegateExample
{
	public delegate bool ComparisonHandler(int first, int second);

	public static void BubbleSort
	(
		int[] items,
		ComparisonHandler comparisonMethod
	)
	{
		int i;
		int j;
		int temp;

		for (i = items.Length - 1; i >= 0; i--)
		{
			for (j = 1; j <= i; j++)
			{
				if (comparisonMethod(items[j - 1], items[j]))
				{
					temp = items[j - 1];
					items[j - 1] = items[j];
					items[j] = temp;
				}
			}
		}
	}

	public static bool GreaterThan(int first, int second)
	{
		return first > second;
	}

	public static bool AlphabeticalGreaterThan
	(
		int first,
		int second
	)
	{                                                               
		int comparison;                                             
		comparison = (first.ToString().CompareTo(second.ToString()));                                    
                                                                  
        return comparison > 0;                                      
	}                                                               

	static void Main(string[] args)
	{

		int i;
		int[] items = new int[5];

		for (i=0; i<items.Length; i++)
		{
			Console.Write("Enter an integer: ");
			items[i] = int.Parse(Console.ReadLine());
		}

        BubbleSort(items, AlphabeticalGreaterThan);                

		for (i = 0; i < items.Length; i++)
		{
			Console.WriteLine(items[i]);
		}
	}
}
