using System;

class Celsius
{
    public Celsius(float temp)
    {
        degrees = temp;
    }
    public static explicit operator Fahrenheit(Celsius c)
    {
        return new Fahrenheit((9.0f / 5.0f) * c.degrees + 32);
    }
    public float Degrees
    {
        get { return degrees; }
    }
    private float degrees;
}

class Fahrenheit
{
    public Fahrenheit(float temp)
    {
        degrees = temp;
    }
    // Must be defined inside a class called Farenheit:
    public static explicit operator Celsius(Fahrenheit f)
    {
        return new Celsius((5.0f / 9.0f) * (f.degrees - 32));
    }
    public float Degrees
    {
        get { return degrees; }
    }
    private float degrees;
}

class TemperatureConversion
{
    static void Main()
    {
        Fahrenheit f = new Fahrenheit(100.0f);
        Console.Write("{0} fahrenheit", f.Degrees);
        Celsius c = (Celsius)f;

        Console.Write(" = {0} celsius", c.Degrees);
        Fahrenheit f2 = (Fahrenheit)c;
        Console.WriteLine(" = {0} fahrenheit", f2.Degrees);
    }
}
