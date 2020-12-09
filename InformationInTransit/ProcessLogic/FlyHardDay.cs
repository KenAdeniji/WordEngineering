using System;
using System.Text;

namespace InformationInTransit.ProcessLogic
{
	/// <summary>
	/// 2009-01-16T07:30:00
    ///	I need you to fly, hard day.
	/// University of Technology, Sydney (UTS) computer science section, is it in a separate building?
	/// </summary>
    public static partial class FlyHardDay
	{
		public static void Main(string[] argv)
		{
			Fly(argv);
		}

		public static String Fly(string[] argv)
		{
            char currentCharacter = ' ';
            int currentSequence = 0;
            int difference = 0;
			int divider = 0;
			argv[0] = argv[0].ToUpper();
			bool tryParse = Int32.TryParse(argv[1], out divider);
			StringBuilder sb = new StringBuilder();
			for(int currentIndex = 0; currentIndex < argv[0].Length; ++currentIndex)
			{
                currentCharacter = argv[0][currentIndex];
                if (!char.IsLetter(currentCharacter))
                {
                    continue;
                }
				currentSequence += currentCharacter - 'A' + 1;
                if (currentSequence == divider)
				{
                    sb.Append(currentCharacter);
                    currentSequence = 0;
				}
                else if (currentSequence > divider)
                {
                    difference = currentSequence - divider;
                    sb.Append((char)(currentCharacter - difference));
                    currentSequence = difference;
                }
                else if (currentIndex + 1 == argv[0].Length)
                {
                    sb.Append(currentCharacter);
                }
			}
            System.Console.WriteLine(sb);
            return (sb.ToString());
		}
	}
}
