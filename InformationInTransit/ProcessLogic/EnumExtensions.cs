using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InformationInTransit.ProcessLogic
{
    public static partial class EnumExtensions
    {
        [Flags]
        public enum ErrorTypes : int
        {
            None = 0,
            MissingPassword = 1,
            MissingUsername = 2,
            PasswordIncorrect = 4
        }

        public static T Append<T>(this System.Enum type, T value)
        {
            return (T)(object)(((int)(object)type | (int)(object)value));
        }

        public static T Remove<T>(this System.Enum type, T value)
        {
            return (T)(object)(((int)(object)type & ~(int)(object)value));
        }

        public static bool Has<T>(this System.Enum type, T value)
        {
            return (((int)(object)type & (int)(object)value) == (int)(object)value);
        }

        public static void Main(string[] argv)
        {
            ErrorTypes error = ErrorTypes.None;
            error = error.Append(ErrorTypes.MissingUsername);
            error = error.Append(ErrorTypes.MissingPassword);
            error = error.Remove(ErrorTypes.MissingUsername);

            if (error.Has(ErrorTypes.MissingUsername)) {

            }
        }
    }
}
