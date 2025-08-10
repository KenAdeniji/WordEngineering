//2025-08-08T20:35:00 http://www.google.com/books/edition/Java_for_Programmers/MqpJEQAAQBAJ?hl=en&gbpv=1
//2025-08-08T21:03:00 http://javamoney.github.io
import java.util.Scanner;
public class CompoundInterestCalculation
{
	/**
		Compound-interest calculation with for.
	*/
	public static void main
	(
		String[] args
	)
	{
		Scanner input = new Scanner(System.in);

		System.out.print("Enter the original principal amount invested: ");
		double principal = input.nextDouble();

		System.out.print("Enter the annual interest rate: ");
		double annualInterestRate = input.nextDouble();
		
		System.out.print("Enter the number of years: ");
		int years = input.nextInt();

		System.out.printf("%s%20s%n", "Year", "Amount on Deposit");

		double amount;

		for(int year = 1; year <= years; ++year)
		{
			amount = principal * Math.pow( 1.0 + annualInterestRate, year);
			System.out.printf("%4d%20.2f%n", year, amount);
		}	
	}
}
	
	