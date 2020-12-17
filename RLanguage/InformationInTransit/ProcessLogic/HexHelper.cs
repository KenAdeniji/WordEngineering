#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Globalization;
#endregion

namespace InformationInTransit.ProcessLogic
{
    #region HexHelper definition
    public static partial class HexHelper
    {
        public static void Main(string[] argv)
        {
            System.Console.WriteLine(ToBase10("FF"));
            System.Console.WriteLine(ToHex(255));
        }

        public static long ToBase10(string hex)
        {
            return long.Parse(hex, NumberStyles.AllowHexSpecifier);
        }

        /// <summary>
        /// Lower case, x.
        /// 2 character zero padding, X2.
        /// </summary>
        public static string ToHex(long number)
        {
            string hex = number.ToString("X", CultureInfo.InvariantCulture);
            return hex;
        }
    }
    #endregion
}
