//http://developers.redhat.com/e-books/java-nutshell-guide

/*
	2024-07-23T03:53:00 http://docs.oracle.com/javase/tutorial/essential/exceptions/tryResourceClose.html
	2024-07-23T05:05:00 http://stackoverflow.com/questions/1067344/is-it-possible-to-get-the-class-name-from-a-static-method
	2024-07-23T05:11:00 What do we reckon... as the same?
	2024-07-23T05:11:00 Can I have... associationship with God?
	2024-07-23T05:15:00 Left ear, in the west.
						What has He shown me... about this person?
	2024-07-23T05:19:00	Java... Internet... applet
						How I learnt... as the same?
	2024-07-23T05:21:00	I must create something new... of myself?
	2024-07-23T05:21:00	The partisanship of sharing?
	2024-07-23T05:22:00	What our moments... bring?
						Dizzy, sleepy.
	2024-07-23T05:24:00	What our period... chooses alike?
	2024-07-23T05:25:00	The difference... of a person?
	2024-07-23T05:26:00	Can I meet you... as choosing myself?
	2024-07-23T05:27:00	What time... fills?
	2024-07-23T05:31:00	The difference... of associating... ourself... alike?
	2024-07-23T05:32:00	What the machine... has done... on my part?
	2024-07-23T05:35:00	Who do I choose... as Myself?
	2024-07-23T05:37:00	What contributes... a nation?
	2024-07-23T05:39:00 Experiencing... someone else?
	2024-07-23T05:40:00	What our meeting... may bring?
	2024-07-23T05:41:00	What I have before... is how I met before?
	2024-07-23T05:48:00	The help... of bringing?
	2024-07-23T05:51:00	GitHub.com git commmit... git push.
						A fulfillment... of detail?
						.java ... .class?
						Post-dated: Democratic senators asks president Joe Biden to clarify his stance on Gaza?
						A fulfillment... of detail?
						PageRank keyword... body occurrences substantiated? Bibliography reference? Noted? Audience? Refereed.
*/
import java.io.*;

public class TryWithResources
{
	public static void main(String[] args) throws IOException
	{
		String className = new Object(){}.getClass().getEnclosingClass().getName();
		String classFileNameSource = className + ".java";
		System.out.println
		(
			String.format
			(
				"Java filename: %s\n First line: %s",
				classFileNameSource,
				readFirstLineFromFile(classFileNameSource)
			)
		); 
	}
	
	public static String readFirstLineFromFile(String path) throws IOException {
	    try (FileReader fr = new FileReader(path);
	         BufferedReader br = new BufferedReader(fr)) {
	        return br.readLine();
	    }
	}		
}
