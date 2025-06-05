/*
	2025-02-18T19:29:00...2025-02-18T20:04:00
*/
public class SingletonClass
{
	private static SingletonClass instance;
	
	private SingletonClass() {}
	
	private static SingletonClass getInstance()
	{
		if (instance == null)
		{
			instance = new SingletonClass();
		}
		return instance;
	}

	public static void main(String... args)
	{
		SingletonClass s1 = SingletonClass.getInstance();
		SingletonClass s2 = SingletonClass.getInstance();
		
		System.out.println("(s1 == s2): " + (s1 == s2));
	}
}	
