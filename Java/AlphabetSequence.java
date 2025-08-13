import java.io.*;
/**
	AlphabetSequence.
	2019-05-31 Created.
	2025-08-11T20:27:00...2025-08-11T20:42:00 Pure function.
	<iframe style="width: 100%; height: 480;" src="https://cscircles.cemc.uwaterloo.ca/java_visualize/iframe-embed.html?faking_cpp=false#data=%7B%22user_script%22%3A%22import%20java.io.*%3B%5Cn%2F**%5Cn%5CtAlphabetSequence.%5Cn%5Ct2019-05-31%20Created.%5Cn%5Ct2025-08-11T20%3A27%3A00...2025-08-11T20%3A42%3A00%20Pure%20function.%5Cn%5Cthttp%3A%2F%2Fcscircles.cemc.uwaterloo.ca%2Fjava_visualize%2Fiframe-embed.html%3Ffaking_cpp%3Dfalse%23data%3D%257B%2522user_script%2522%253A%2522import%2520java.io.*%253B%255Cn%252F**%255Cn%255CtAlphabetSequence.%255Cn%255Ct2019-05-31%2520Created.%255Cn%255Ct2025-08-11T20%253A27%253A00...2025-08-11T20%253A42%253A00%2520Pure%2520function.%255Cn*%252F%255Cnpublic%2520class%2520AlphabetSequence%2520%255Cn%257B%255Cn%255Ctpublic%2520static%2520void%2520main(String%2520args%255B%255D)%2520%255Cn%255Ct%257B%255Cn%255Ct%255Ctfor%255Ct(%2520String%2520arg%2520%253A%2520args%2520)%2520%255Cn%255Ct%255Ct%257B%255Cn%255Ct%255Ct%255CtSystem.out.format%255Cn%255Ct%255Ct%255Ct(%255Cn%255Ct%255Ct%255Ct%255Ct%255C%2522Word%253A%2520%2525s%2520AlphabetSequenceIndex%253A%2520%2525d%2525n%255C%2522%252C%255Cn%255Ct%255Ct%255Ct%255Ctarg%252C%255Cn%255Ct%255Ct%255Ct%255CtIndex(arg)%255Cn%255Ct%255Ct%255Ct)%253B%255Cn%255Ct%255Ct%257D%255Ct%255Ct%255Ct%255Cn%255Ct%257D%2520%2520%2520%255Cn%255Cn%255Ctpublic%2520static%2520long%2520Index(String%2520arg)%255Cn%255Ct%257B%255Cn%255Ct%255CtString%2520upperCase%2520%253D%2520arg.toUpperCase()%253B%255Cn%255Ct%255Ctlong%2520alphabetSequenceIndex%2520%253D%25200%253B%255Cn%255Ct%255Ctfor(char%2520character%2520%253A%2520upperCase.toCharArray())%2520%255Cn%255Ct%255Ct%257B%255Cn%255Ct%255Ct%255Ctif%2520(character%2520%253E%253D%2520'A'%2520%2526%2526%2520character%2520%253C%253D%2520'Z')%255Cn%255Ct%255Ct%255Ct%257B%255Cn%255Ct%255Ct%255Ct%255CtalphabetSequenceIndex%2520%252B%253D%2520(int)%2520character%2520-%252064%253B%255Cn%255Ct%255Ct%255Ct%257D%255Ct%255Ct%255Ct%255Cn%255Ct%255Ct%257D%255Cn%255Ct%255Ctreturn%2520alphabetSequenceIndex%253B%255Cn%255Ct%257D%2520%2520%2520%255Cn%257D%255Cn%2522%252C%2522options%2522%253A%257B%2522showStringsAsValues%2522%253Atrue%252C%2522showAllFields%2522%253Afalse%257D%252C%2522args%2522%253A%255B%2522Hello%2520World%2522%255D%252C%2522stdin%2522%253A%2522%2522%257D%26cumulative%3Dfalse%26heapPrimitives%3Dfalse%26drawParentPointers%3Dfalse%26textReferences%3Dfalse%26showOnlyOutputs%3Dfalse%26py%3D3%26curInstr%3D0%26resizeContainer%3Dtrue%26highlightLines%3Dtrue%26rightStdout%3Dtrue%5Cn*%2F%5Cnpublic%20class%20AlphabetSequence%20%5Cn%7B%5Cn%5Ctpublic%20static%20void%20main(String%20args%5B%5D)%20%5Cn%5Ct%7B%5Cn%5Ct%5Ctfor%5Ct(%20String%20arg%20%3A%20args%20)%20%5Cn%5Ct%5Ct%7B%5Cn%5Ct%5Ct%5CtSystem.out.format%5Cn%5Ct%5Ct%5Ct(%5Cn%5Ct%5Ct%5Ct%5Ct%5C%22Word%3A%20%25s%20AlphabetSequenceIndex%3A%20%25d%25n%5C%22%2C%5Cn%5Ct%5Ct%5Ct%5Ctarg%2C%5Cn%5Ct%5Ct%5Ct%5CtIndex(arg)%5Cn%5Ct%5Ct%5Ct)%3B%5Cn%5Ct%5Ct%7D%5Ct%5Ct%5Ct%5Cn%5Ct%7D%20%20%20%5Cn%5Cn%5Ctpublic%20static%20long%20Index(String%20arg)%5Cn%5Ct%7B%5Cn%5Ct%5CtString%20upperCase%20%3D%20arg.toUpperCase()%3B%5Cn%5Ct%5Ctlong%20alphabetSequenceIndex%20%3D%200%3B%5Cn%5Ct%5Ctfor(char%20character%20%3A%20upperCase.toCharArray())%20%5Cn%5Ct%5Ct%7B%5Cn%5Ct%5Ct%5Ctif%20(character%20%3E%3D%20'A'%20%26%26%20character%20%3C%3D%20'Z')%5Cn%5Ct%5Ct%5Ct%7B%5Cn%5Ct%5Ct%5Ct%5CtalphabetSequenceIndex%20%2B%3D%20(int)%20character%20-%2064%3B%5Cn%5Ct%5Ct%5Ct%7D%5Ct%5Ct%5Ct%5Cn%5Ct%5Ct%7D%5Cn%5Ct%5Ctreturn%20alphabetSequenceIndex%3B%5Cn%5Ct%7D%20%20%20%5Cn%7D%5Cn%22%2C%22options%22%3A%7B%22showStringsAsValues%22%3Atrue%2C%22showAllFields%22%3Afalse%7D%2C%22args%22%3A%5B%22Hello%20world%22%5D%2C%22stdin%22%3A%22%22%7D&cumulative=false&heapPrimitives=false&drawParentPointers=false&textReferences=false&showOnlyOutputs=false&py=3&curInstr=0&resizeContainer=true&highlightLines=true&rightStdout=true" frameborder="0" scrolling="no"></iframe>
*/
public class AlphabetSequence 
{
	public static void main(String args[]) 
	{
		for	( String arg : args ) 
		{
			System.out.format
			(
				"Word: %s AlphabetSequenceIndex: %d%n",
				arg,
				Index(arg)
			);
		}			
	}   

	public static long Index(String arg)
	{
		String upperCase = arg.toUpperCase();
		long alphabetSequenceIndex = 0;
		for(char character : upperCase.toCharArray()) 
		{
			if (character >= 'A' && character <= 'Z')
			{
				alphabetSequenceIndex += (int) character - 64;
			}			
		}
		return alphabetSequenceIndex;
	}   
}
