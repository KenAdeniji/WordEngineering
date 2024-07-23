//http://developers.redhat.com/e-books/java-nutshell-guide
public class SwitchExpression
{
	public static void main(String[] args) 
	{
		for (String arg: args)
		{	
			boolean yesOrNo = switch(arg) {
				case "y" -> true;
				case "Y" -> true;
				case "N" -> false;
				case "n" -> false;
				default -> throw new IllegalArgumentException("Y or N");
			};
			System.out.println
			(
				String.format
				(
					"%s %b",
					arg,
					yesOrNo
				)
			); 
		}	
	}
}
