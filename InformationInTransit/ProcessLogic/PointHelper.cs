using System;

namespace InformationInTransit.ProcessLogic
{
    public partial class PointHelper
    {
        public double x, y;

        public static void Main()
        {
            PointHelper a = new PointHelper();
            PointHelper b = new PointHelper(3, 4);
            double d = PointHelper.Distance(a, b);
            Console.WriteLine("Distance from {0} to {1} is {2}", a, b, d);
        }

        public PointHelper()
        {
            this.x = 0;
            this.y = 0;
        }
        public PointHelper(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
        public static double Distance(PointHelper a, PointHelper b)
        {
            double xdiff = a.x - b.x;
            double ydiff = a.y - b.y;
            return Math.Sqrt(xdiff * xdiff + ydiff * ydiff);
        }
        public override string ToString()
        {
            return string.Format("({0}, {1})", x, y);
        }
    }
}
