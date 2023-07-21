/*
	Source: http://www.dummies.com/go/javaaiofd7e
	Learning Made Easy 7th Edition Java All-In-One for dummies A Wiley brand 8 books in one! Doug Lowe Wrote his first program on a computer with than 1K of memory
	Dated: 
		2023-07-21T03:35:00 ... 2023-07-21T05:32:00
		2023-07-21T03:49:00 CreateInstance()?
		2023-07-21T04:14:00 command-line arguments();
		2023-07-21T04:23:00 http://stackoverflow.com/questions/41678766/java-get-command-line-arguments-outside-of-main
		2023-07-21T04:23:00	http://stackoverflow.com/questions/5061367/how-to-get-the-command-line-arguments-from-another-class-with-java
		2023-07-21T04:34:00 convert string to enum value?
		2023-07-21T04:34:00 ... 2023-07-21T04:41:00 http://stackoverflow.com/questions/7056959/convert-string-to-equivalent-enum-value
		2023-07-21T04:53:00 ... 2023-07-21T05:01:00 http://stackoverflow.com/questions/43414165/how-to-iterate-over-string-array
*/

public class BallFactory
{
	public enum BallSubclass
	{
		Cricket,
		Football
	}
	
	public static void main(String[] args)
	{
		stub(args);
	}
	
	public static void stub(String[] args)
	{
		for (String currentBall : args) {
			Ball ball = BallFactory.determineBall
			(
				BallSubclass.valueOf(currentBall)
			);
			ball.mostValuablePlayer();
		}		
	}
	
	public static Ball determineBall
	(
		BallSubclass ballSubclass
	)
	{
		Ball ball = null;
		switch( ballSubclass )
		{
			case Cricket:
				ball = new Cricket();
				break;
			case Football:
				ball = new Football();
				break;
		}
		return ball;
	}	
}
