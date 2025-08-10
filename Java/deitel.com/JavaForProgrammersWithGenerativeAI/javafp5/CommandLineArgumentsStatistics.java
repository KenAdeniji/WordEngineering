//2025-08-09T15:59:00 http://www.google.com/books/edition/Java_for_Programmers/MqpJEQAAQBAJ?hl=en&gbpv=1
import java.util.Arrays;
import java.util.DoubleSummaryStatistics;
public class CommandLineArgumentsStatistics
{
	/**
		Command-Line Arguments statistics.
	*/
	public static void main
	(
		String[] args
	)
	{
		double[] valueOfArguments = new double[args.length];	
		for(int i = 0; i < args.length; i++)
		{
			valueOfArguments[i] = Double.parseDouble(args[i]);
		}		
		DoubleSummaryStatistics stat = Arrays.stream(valueOfArguments).summaryStatistics();
		System.out.printf("Average: %f%n", stat.getAverage());
		System.out.printf("Count: %d%n", stat.getCount());
		System.out.printf("Maximum: %f%n", stat.getMax());
		System.out.printf("Maximum: %f%n", stat.getMin());
		System.out.printf("Sum: %f%n", stat.getSum());
	}	
}
