//2025-08-08T19:09:00 http://www.google.com/books/edition/Java_for_Programmers/MqpJEQAAQBAJ?hl=en&gbpv=1
import java.util.Scanner;
public class Comparison
{
	/**
		Compare numbers using if statements, equality operators, relational operators.
	*/
	public static void main
	(
		String[] args
	)
	{
		Scanner input = new Scanner(System.in);
		
		System.out.print("Enter the 1st number: ");
		float firstNumber = input.nextFloat();
		
		System.out.print("Enter the 2nd number: ");
		float secondNumber = input.nextFloat();
		
		if (firstNumber == secondNumber)
		{
			System.out.printf("%f == %f%n", firstNumber, secondNumber);
		}
		
		if (firstNumber != secondNumber)
		{
			System.out.printf("%f != %f%n", firstNumber, secondNumber);
		}
	}
}
	
	