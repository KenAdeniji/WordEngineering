/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InformationInTransit.ProcessLogic
{
    public static partial class NamedArgumentsAndOptionalParameters
    {
        public static void Main(string[] argv)
        {
            OptionalParameters(1, 2, 3); // ordinary call of OptionalParameters
            OptionalParameters(1, 2); // omitting z – equivalent to OptionalParameters(1, 2, 7)
            OptionalParameters(1); // omitting both y and z – equivalent to OptionalParameters(1, 5, 7)

            OptionalParameters(1, z: 3); // passing z by name
            OptionalParameters(x: 1, z: 3); // passing both x and z by name
            OptionalParameters(z: 3, x: 1); // reversing the order of arguments
        }

        /// <summary>
        /// Optional parameters
        /// A parameter is declared optional simply by providing a default value for it:
        /// Here y and z are optional parameters and can be omitted in calls:
        /// </summary>
        public static void OptionalParameters(int x, int y = 5, int z = 7)
        {
            System.Console.WriteLine
            (
                "x = {0} | y = {1} | z = {2}",
                x,
                y,
                z
            );
        }
    }
}
*/
