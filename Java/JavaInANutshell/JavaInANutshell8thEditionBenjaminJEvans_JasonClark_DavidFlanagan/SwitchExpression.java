public class SwitchExpression
{
	public static void main(String[] args) 
	{
		string input = "Y";
		boolean yesOrNo = switch(input) {
			case "y" -> true;
			case "Y" -> true;
			case "N" -> false;
			case "n" -> false;
			default -> throw new IllegalArgumentException("Y or N");
		}
		System.out.println(String.format("%s %b" , "input", yesOrNo)); 
	}
}
