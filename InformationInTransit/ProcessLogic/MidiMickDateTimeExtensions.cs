using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InformationInTransit.ProcessLogic
{
    /// <summary>
    ///     2016-02-19 Simple DateTime to Julian Day and UnixTime Values
    ///     From <see cref="!:http://www.codeproject.com/Tips/1059193/Simple-DateTime-to-Julian-Day-and-UnixTime-Values">Simple DateTime to Julian Day and UnixTime Values</see> MSDN-Link.
    ///     AHref <a href="http://www.codeproject.com/Tips/1059193/Simple-DateTime-to-Julian-Day-and-UnixTime-Values">Simple DateTime to Julian Day and UnixTime Values</a>.
    ///     see-href <see href="http://www.codeproject.com/Tips/1059193/Simple-DateTime-to-Julian-Day-and-UnixTime-Values">Simple DateTime to Julian Day and UnixTime Values</see>.
    /// </summary>
    public static partial class MidiMickDateTimeExtensions
    {
        public static double ToMidiMickJulianDay(this DateTime dt)
        {
            return dt.ToOADate() + 2415018.5;
        }
        private static DateTime unixBase = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public static double ToMidiMickUnixTime(this DateTime dt)
        {
            return dt.Subtract(unixBase).TotalSeconds;
        }

        public static DateTime FromMidiMickJulianDay(double julianDay)
        {
            return DateTime.FromOADate(julianDay - 2415018.5D);
        }

        public static DateTime FromMidiMickUnixTime(double unixTime)
        {
            return unixBase.AddSeconds(unixTime);
        }
    }
}
