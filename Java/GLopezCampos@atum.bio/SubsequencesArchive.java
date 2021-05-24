/** 
Genesis Lopez
Company	Atum
Work e-mail	GLopezCampos@atum.bio
Notes	2021-05-19T17:08:00 Thank you for applying to the Junior Software Engineer Internship at ATUM.
The first round of our interview process is to write a function in Java per the following:
Write a function in Java that takes as a parameter a string and returns a list of subsequences (from left to right) 
that start with "ATG" and end with either "TAA", "TAG" or "TGA". 
Example: Input: "GCATGCCGGTTACCTAAGGATGGGTTCAAAATAGCGG" 
Output: [ "ATGCCGGTTACCTAA", "ATGGGTTCAAAATAG" ] 
Please email me your answer within 4 business days of receiving this email. 
We will be in touch after review regarding the next steps.
Thank you again for applying to the internship. Genesis Lopez ATUM
2021-05-19T17:21:00 ... 2021-05-19T19:51:00 Prove-of-concept. 
*/

import java.util.*;
import java.util.Collections;

class Subsequences
{
	public static void main(String[] args)
	{
		System.out.println
		(
			subsequences(args[0])	
		);	
	}

	public static String subsequences(String input)
	{
		String startWithATGLiteral = "ATG";
		int startWithATGIndex = 0;
		
		String[] endWithLiterals = {"TAA", "TAG", "TGA"};
		int endWithLength = endWithLiterals.length;
		int endWithIndex = 0;
		int endWithIndexes = 0;
		int endBlock = 0;

		boolean endWithFound = false;	
		
		List<String> resultSet = new ArrayList<String>();
		
		String output;
	
		for (;;)
		{
			startWithATGIndex = input.indexOf(startWithATGLiteral, startWithATGIndex);
			if (startWithATGIndex == -1)
			{
				break;
			}	
			for 
			(
				endWithIndex = 0, 
				endWithFound = false
				;
				endWithIndex < endWithLength;
				++endWithIndex
			)
			{
				endWithIndexes = input.indexOf
				(
					endWithLiterals[endWithIndex],
					startWithATGIndex
				);
				if 
				(
					endWithIndexes > -1
				)
				{
					endWithFound = true;
					endBlock = endWithIndexes + ((endWithLiterals[endWithIndex]).length());
					break;
				}		
			}

			if (!endWithFound)
			{
				endBlock = input.length();
			}		

			resultSet.add
			(
				'"' + 
				input.substring
				(
					startWithATGIndex,
					endBlock
				)
				+ '"'
			);
	
			startWithATGIndex = endBlock;
		}
		
		output = "[" + String.join(", ", resultSet) + "]";
		
		return output;
	}
}
