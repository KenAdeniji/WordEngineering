using	System;
using	System.Drawing;

/*
	Date Created:	2020-03-22	https://extensionmethod.net/csharp/point/distanceto
*/
namespace InformationInTransit.ProcessCode
{
	static class PointExtensionMethods
	{
		public static void Main(string[] argv)
		{
			Stub();	
		}

		public static void Stub()
		{
			Point point1 = new Point(0,0);
			Point point2 = new Point(5, 5);
			double distance = point1.DistanceTo(point2);
			
			System.Console.WriteLine
			(
				"point1 x: {0} y: {1} | point2 x: {2} y: {3} | distance: {4}",
				point1.X,
				point1.Y,
				point2.X,
				point2.Y,
				distance	
			);
		}
		
		public static double DistanceTo(this Point point, Point otherPoint)
		{
			int dx = point.X - otherPoint.X;
			int dy = point.Y - otherPoint.Y;
			return Math.Sqrt(Math.Pow(dx, 2) + Math.Pow(dy, 2));
		}
	}
}	