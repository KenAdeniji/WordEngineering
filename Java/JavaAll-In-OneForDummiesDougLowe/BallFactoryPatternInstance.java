/*
	2025-02-19T15:30:00
*/
public class BallFactoryPatternInstance
{
	enum BallType 
	{
		AmericanFootball,
		Soccer,
	};
	
	private static Ball getBallInstance(BallType ballType)
	{
		switch(ballType)
		{
			case BallType.Soccer: return new SoccerBall();
			default: return null;
		}
	}

	public static void main(String... args)
	{
		Ball soccerBall = BallFactoryPatternInstance.getBallInstance
		(	
			BallType.Soccer
		);
		System.out.println("soccerBall.getClass(): " + soccerBall.getClass());
	}
}	
