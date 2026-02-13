using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InformationInTransit.ProcessCode
{
	/*
		2026-02-12T12:29:00	Created.
			C# Programming in Easy Steps
			Master C# Fundamentals!
			McGrath, Mike, 1956-
			iescourses.com
		2026-02-12T22:38:00...2026-02-12T22:55:00	Coding.
		2026-02-12T22:59:00	Charles Darwin Day.
	*/
    public partial class CustomizationOfClass
    {
		public static void Main(String[] argv)
		{
			Pigeon pigeon = new Pigeon();
			Chicken chicken = new Chicken();
			Describe(pigeon);
			Describe(chicken);
		}	

		public static void Describe(Bird obj)
		{
			obj.Talk();
			obj.Fly();
		}	
    }
	
	public abstract class Bird
	{
		public abstract void Talk();
		public abstract void Fly();
	}	
	
	public sealed class Pigeon : Bird
	{
		public override void Talk() { System.Console.WriteLine("Pigeon talk."); }
		public override void Fly() { System.Console.WriteLine("Pigeon fly."); }
	}	

	public sealed class Chicken : Bird
	{
		public override void Talk() { System.Console.WriteLine("Chicken talk."); }
		public override void Fly() { System.Console.WriteLine("Chicken fly."); }
	}	
	
}
