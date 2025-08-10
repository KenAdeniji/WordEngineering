//2025-08-08T18:47:00 http://www.google.com/books/edition/Java_for_Programmers/MqpJEQAAQBAJ?hl=en&gbpv=1
import java.util.Scanner;
public class AddingIntegers
{
	/**
		Addition program that input 2 numbers, and then displays their sum.
	*/
	public static void main
	(
		String[] args
	)
	{
		Scanner input = new Scanner(System.in);
		
		System.out.print("Enter the 1st number: ");
		int firstNumber = input.nextInt();

		System.out.print("Enter the 2nd number: ");
		int secondNumber = input.nextInt();
		
		int numbersSum = firstNumber + secondNumber;
		
		System.out.printf
		(
			"Sum of %d + %d is = %d%n",
			firstNumber,
			secondNumber,
			numbersSum
		);
	}
}
	
	