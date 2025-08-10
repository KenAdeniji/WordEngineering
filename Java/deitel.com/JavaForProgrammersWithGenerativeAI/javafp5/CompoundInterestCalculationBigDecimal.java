//2025-08-08T20:35:00 http://www.google.com/books/edition/Java_for_Programmers/MqpJEQAAQBAJ?hl=en&gbpv=1
//2025-08-08T21:03:00 http://javamoney.github.io
import java.util.Scanner;

import java.math.BigDecimal;
import java.math.RoundingMode;

public class CompoundInterestCalculationBigDecimal
{
	/**
		Compound-interest calculation with BigDecimal objects.
	*/
	public static void main
	(
		String[] args
	)
	{
		Scanner input = new Scanner(System.in);

		System.out.print("Enter the original principal amount invested: ");
		BigDecimal principal = input.nextBigDecimal();

		System.out.print("Enter the annual interest rate: ");
		BigDecimal annualInterestRate = input.nextBigDecimal();
		
		System.out.print("Enter the number of years: ");
		int years = input.nextInt();

		System.out.printf("%s%17s   %s%n", "Year", "Rounded Amount", "Precise Stored Amount");

		BigDecimal amount;

		for(int year = 1; year <= years; ++year)
		{
			amount = principal.multiply(BigDecimal.ONE.add(annualInterestRate).pow(year));
			System.out.printf
			(
				"%4d%17s   %s%n",
				year,
				amount.setScale(2, RoundingMode.HALF_EVEN),
				amount
			);
		}	
	}
}
	
	