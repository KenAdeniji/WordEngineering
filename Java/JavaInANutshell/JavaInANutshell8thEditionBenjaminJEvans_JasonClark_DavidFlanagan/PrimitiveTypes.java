//http://developers.redhat.com/e-books/java-nutshell-guide
public class PrimitiveTypes
{
	public static final float AvogadroNumber = 6.02e23f;
	
	public static void main(String[] args) 
	{
		boolean	booleanType = true;	//true or false
		System.out.println(String.format("%s %b" , "boolean", booleanType)); 
		
		char	charType = 'A';
		System.out.println(String.format("%s %c" , "char", charType)); 
		
		char	javaEscapeCharacterBackspace = '\b';
		char	javaEscapeCharacterHorizontalTab = '\t';
		char	javaEscapeCharacterNewline = '\n';
		char	javaEscapeCharacterFormfeed = '\f';
		char	javaEscapeCharacterCarriagereturn = '\r';
		char	javaEscapeCharacterDoublequote = '\"';
		char	javaEscapeCharacterSinglequote = '\'';
		
		byte	largestByte = 127;
		byte	smallestByte = (byte) (largestByte + 1);
		System.out.println(String.format("%s 0x%02X %d" , "largest byte", largestByte, largestByte)); 
		System.out.println(String.format("%s 0x%02X %d" , "smallest byte", smallestByte, smallestByte)); 
		
		System.out.println(String.format("%s %.2f" , "Avogadro's Number", AvogadroNumber)); 
	}
}
