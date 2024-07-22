//http://developers.redhat.com/e-books/java-nutshell-guide
public class SwitchExpression
{
	public static void main(String[] args) 
	{
		boolean yesOrNo = switch(args[0]) {
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
				args[0],
				yesOrNo
			)
		); 
	}
}
