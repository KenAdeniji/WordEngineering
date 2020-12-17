using System;
using System.Text;

public static partial class PercentageOfTwelve
{
	public static readonly string[] NumbersInWords = { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine" };
	public const int Max = 12;
	public static void Main(string[] argv)
	{
		try
		{
			StringBuilder sb = new StringBuilder();
			for (int index = 0; index <= Max; ++index)
			{
				decimal currentValue = (decimal) (index * 100) / Max;
				//System.Console.WriteLine(currentValue);
				String currentString = currentValue.ToString();
				int length = currentString.Length;
				String currentWord = "";
				int currentInteger = -1;
				for (int counter = 0; counter < length; ++counter)
				{
					currentWord = "";
					currentInteger = -1;
					if (currentString[counter] >= '0' && currentString[counter] <= '9')
					{
						currentInteger = currentString[counter] - '0';
						currentWord = NumbersInWords[currentInteger];
					}
					else if (currentString[counter] == '.')
					{
						currentWord = "Point";
					}
					sb.Append(currentWord);
					sb.Append(" ");
				}
				sb.Append(" Percent.");
			}	
			String wordUpperCase = sb.ToString().Trim().ToUpper();
			//System.Console.WriteLine(wordUpperCase);
			
			int wordLength = wordUpperCase.Length;
			int alphabetIndex = 0;
			for (int index = 0; index < wordLength; ++index)
			{
				if (Char.IsLetter(wordUpperCase[index]))
				{
					alphabetIndex += wordUpperCase[index] - 'A' + 1;
				}
			}
			System.Console.WriteLine("Alphabet Index: {0}", alphabetIndex);
		}
		catch (Exception ex)
		{
			System.Console.WriteLine("Exception: {0}", ex.Message);
		}
	}
}