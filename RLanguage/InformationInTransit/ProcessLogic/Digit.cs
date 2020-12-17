using System;

namespace InformationInTransit.ProcessLogic
{
    /// <summary>
    /// Operator overloading.
    /// </summary>
    public partial struct Digit
    {
        byte value;

        public Digit(int value) 
        {
            if (value < 0 || value > 9) throw new ArgumentException();
            this.value = (byte)value;
        }

        public static implicit operator byte(Digit d) 
        {
            return d.value;
        }

        public static explicit operator Digit(int value) 
        {
            return new Digit(value);
        }

        public static Digit operator+(Digit a, Digit b) 
        {
            return new Digit(a.value + b.value);
        }

        public static Digit operator-(Digit a, Digit b) 
        {
            return new Digit(a.value - b.value);
        }

        public static bool operator==(Digit a, Digit b) 
        {
            return a.value == b.value;
        }

        public static bool operator !=(Digit a, Digit b)
        {
            return a.value != b.value;
        }

        public override bool Equals(object value)
        {
            if (value == null) return false;
            if (GetType() == value.GetType()) return this == (Digit)value;
            return false;
        }

        public override int GetHashCode()
        {
            return value.GetHashCode();
        }

        public override string ToString()
        {
            return value.ToString();
        }

        public static void Main()
        {
            Digit a = (Digit)5;
            Digit b = (Digit)3;
            Digit plus = a + b;
            Digit minus = a - b;
            bool equals = (a == b);
            Console.WriteLine("{0} + {1} = {2}", a, b, plus);
            Console.WriteLine("{0} - {1} = {2}", a, b, minus);
            Console.WriteLine("{0} == {1} = {2}", a, b, equals);
        }
    }
}
