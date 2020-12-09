import java.io.*;
public class IterateArgument {
	public static void main(String args[]) {
		for	( String arg : args ) {
			System.out.print( arg );
			System.out.print(",");
		}			
	}   
}
