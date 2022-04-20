/*
	2022-04-07T16:00:00	Created.
		https://web.fscj.edu/Janson/COP1000/Java%20Language%20Companion.pdf
		javac CalculateRenumeration.java
		java CalculateRenumeration -classpath .;mssql-jdbc-10.2.0.jre17.jar;mssql-jdbc_auth-10.2.0.x64.dll
*/
import java.util.Scanner;

public class CalculateRenumeration
{
	public static void main(String[] args)
	{
		Scanner keyboard = new Scanner(System.in);
		String 	employeeName;
		double	hourlyPayRate;
		double	hoursWorked;
		
		System.out.print("Please enter the name of the employee: ");
		employeeName = keyboard.nextLine();
		
		System.out.print("Please enter the hourly pay rate: ");
		hourlyPayRate = keyboard.nextDouble();
		
		System.out.print("Please enter the hours worked: ");
		hoursWorked = keyboard.nextDouble();
		
		System.out.format
		(
			"The renumeration is: %.2f\n",
			hourlyPayRate * hoursWorked
		);
	}
}
