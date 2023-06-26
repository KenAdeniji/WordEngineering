/*
		2023-06-25T23:05:00 ... 2023-06-26T00:37:00 wiley.com/en-us/Professional+C%23+7+and+NET+Core+2+0-p-9781119449263 	Professional C# 7 and .NET Core 2.0 Christian Nagel ISBN: 978-1-119-44926-3 March 2018 1440 Pages 			2023-06-22
		2023-06-25T23:55:00 http://github.com/ProfessionalCSharp/ProfessionalCSharp7/blob/main/ObjectsAndTypes/ObjectsAndTypes/EnumSample/DaysOfWeek.cs		
*/
using System;

namespace ChristianNagel
{
	[Flags]
	public enum ChildrenOfJacob
	{
		Reuben = 0x1, //First son of Leah (Genesis 29:32)
		Simeon = 0x2, //Second son of Leah (Genesis 29:33)
		Levi = 0x4, //Third son of Leah (Genesis 29:34)
		Judah = 0x8, //Fourth son of Leah (Genesis 29:35)
		Dan = 0x10, //First son of Bilhah (Genesis 30:1-8)
		Naphtali = 0x20, //Second son of Bilhah (Genesis 30:1-8)
		Gad = 0x40, //First son of Zilpah (Genesis 30:9-13)
		Asher = 0x80, //Second son of Zilpah (Genesis 30:9-13)
		Issachar = 0x100, //Fifth son of Leah (Genesis 30:17-18)
		Zebulun = 0x200, //Sixth son of Leah (Genesis 30:19-30)
		Dinah = 0x400, //Seventh child of Leah, only named daughter (Genesis 30:21)
		Joseph = 0x800, //First child of Rachel (Genesis 30:22-25)
		Benjamin = 0x1000, //Second son of Rachel (Genesis 35:18)
		Manasseh = 0x2000, //First son of Joseph (Genesis 41:50-51, Genesis 46:20, Genesis 48)
		Ephraim = 0x4000, //Second son of Joseph (Genesis 41:50, Genesis 41:52, Genesis 46:20, Genesis 48)
		ChildrenOfLeah = Reuben | Simeon | Levi | Judah | Issachar | Zebulun | Dinah, //Son of Leah (Genesis 35:23)
		ChildrenOfBilhah = Dan | Naphtali, //Son of Bilhah (Genesis 30:1-8)
		ChildrenOfZilpah = Gad | Asher, //Son of Bilhah (Genesis 30:9-13)
		ChildrenOfRachel = Joseph | Benjamin, //Sons of Rachel (Genesis 35:24)
		ChildrenOfJoseph_And_AsenathTheDaughterOfPotipherahPriestOfOn = Manasseh | Ephraim, //Sons of Joseph and Asenath the daughter of Potipherah priest of On (Genesis 46:20, Genesis 48)
		AllChildren = ChildrenOfLeah | ChildrenOfBilhah | ChildrenOfZilpah | ChildrenOfRachel | ChildrenOfJoseph_And_AsenathTheDaughterOfPotipherahPriestOfOn
	}	
	
	public partial class ChildrenOfJacobHelper
	{
		public static void Main(String[] args)
		{
			ChildrenOfJacob childrenOfJacobArgument;
			bool argumentParsedSuccessfully;
			foreach(String arg in args)
			{
				argumentParsedSuccessfully = Enum.TryParse<ChildrenOfJacob>
				(
					arg,
					out childrenOfJacobArgument
				);
				if (argumentParsedSuccessfully)
				{
					System.Console.WriteLine(childrenOfJacobArgument);
				}	
			}	
			foreach(var childrenOfJacob in Enum.GetNames(typeof(ChildrenOfJacob)))
			{
				System.Console.WriteLine(childrenOfJacob);
			}
			foreach(var childrenOfJacob in Enum.GetValues(typeof(ChildrenOfJacob)))
			{
				System.Console.WriteLine(childrenOfJacob);
			}	
		}	
	}	
}	