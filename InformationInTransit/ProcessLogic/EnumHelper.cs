#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.ComponentModel;
using System.Reflection;
#endregion

namespace InformationInTransit.ProcessLogic
{
	/*
		2017-04-21	https://msdn.microsoft.com/en-us/library/system.enum.getunderlyingtype(v=vs.110).aspx
	*/
    #region definition EnumHelper
    public static partial class EnumHelper
    {
        #region Methods
        public static void Main(string[] argv)
        {
            /*
            System.Console.WriteLine("Zero: {0} | {1}", Flag.None, ToDescription(Flag.None));
            System.Console.WriteLine("One: {0} | {1}", Flag.One, ToDescription(Flag.One));
            System.Console.WriteLine("Two: {0} | {1}", Flag.Two, ToDescription(Flag.Two));
            System.Console.WriteLine("Four: {0} | {1}", Flag.Four, ToDescription(Flag.Four));
            System.Console.WriteLine("Eight: {0} | {1}", Flag.Eight, ToDescription(Flag.Eight));
            */
            Parser();
            System.Console.WriteLine(EnumFlag.One.Value());
            List<EnumFlag> enumFlag = ConvertEnumToList<EnumFlag>();
            ObjectDumper.Write(enumFlag);
            EnumFlag Seven = EnumFlag.Four | EnumFlag.Two | EnumFlag.One;
            System.Console.WriteLine(Seven);
            System.Console.WriteLine(ConvertStringToEnum("One, Two, Four"));
            EnumFlag None = EnumFlag.None | EnumFlag.Eight;
            bool hasFlag = None.HasFlag(EnumFlag.Four);
            System.Console.WriteLine
            (
                "Value: {0} | Flag: {1} | HasFlag: {2}",
                None,
                EnumFlag.None,
                hasFlag
            );
			EnumInfoStub();
			EnumFlag e = (EnumFlag)4;
			System.Console.WriteLine(e);
        }

        /// <code>
        /// List<EnumFlag> enumFlag = ConvertEnumToList<EnumFlag>();
        /// </code>
        public static List<T> ConvertEnumToList<T>()
        {
            Type enumType = typeof (T);

            // Check to make sure the type is an Enum since
            // you can’t "where" an enum.
            if (!enumType.IsEnum)
            {
                // TODO: Clean this up; return a more explicit error.
                throw new ArgumentException
                (
                    @"T must have a base type of System.Enum."
                );
            }

            // Return a list from a casted array.
            return
                new List<T>(Enum.GetValues(typeof (T)) as IEnumerable<T>);
        }

        /// <code>
        /// EnumFlag Seven = EnumFlag.Four | EnumFlag.Two | EnumFlag.One;
        /// System.Console.WriteLine(Seven);
        /// System.Console.WriteLine(ConvertStringToEnum("One, Two, Four"));
        /// </code>
        public static EnumFlag ConvertStringToEnum(string enumValue)
        {
            EnumFlag enumFlag = (EnumFlag)Enum.Parse(typeof(EnumFlag),
                                enumValue);
            return enumFlag;
        }

        // helper method that tells you if an enum value is defined for it's enumeration
        public static bool IsDefined(this Enum value)
        {
            return Enum.IsDefined(value.GetType(), value);
        }

		public static void EnumInfoDisplay(Enum enumValue)
		{
			Type enumType = enumValue.GetType();
			Type underlyingType = Enum.GetUnderlyingType(enumType);
			Console.WriteLine
			(
				"{0,-10} {1, 18}   {2,15}",
				enumValue, enumType.Name, underlyingType.Name
			);   
		}

		public static void EnumInfoStub()
		{
			Enum[] enumValues = { ConsoleColor.Red, DayOfWeek.Monday, 
								MidpointRounding.ToEven, PlatformID.Win32NT, 
								DateTimeKind.Utc, StringComparison.Ordinal };
			Console.WriteLine
			(
				"{0,-10} {1, 18}   {2,15}\n", 
				"Member", "Enumeration", "Underlying Type"
			);
			foreach (var enumValue in enumValues)
			{	
				EnumInfoDisplay(enumValue);
			}	
		}
		
		///<example>
		///MyEnum tester = MyEnum.FlagA | MyEnum.FlagB;
 		///if(tester.IsSet(MyEnum.FlagA))
		///</example>
		///<remarks>
		///http://extensionmethod.net/csharp/enum/isset
		///</remarks>
		public static bool IsSet(this Enum input, Enum matchTo)
		{
			return (Convert.ToUInt32(input) & Convert.ToUInt32(matchTo)) != 0;
		}
		
        public static string ToDescription(this Enum en) //ext method
        {
            Type type = en.GetType();
            MemberInfo[] memInfo = type.GetMember(en.ToString());
            if (memInfo != null && memInfo.Length > 0)
            {
                object[] attrs = memInfo[0].GetCustomAttributes(
                typeof(DescriptionAttribute),
                false);

                if (attrs != null && attrs.Length > 0)
                    return ((DescriptionAttribute)attrs[0]).Description;
            }
            return en.ToString();
        }

        public static void Parser()
        {
            string[] enumFlagNames = Enum.GetNames(typeof(EnumFlag));
            int[] enumFlagValues = (int[])Enum.GetValues(typeof(EnumFlag));

            for (int index = 0; index < enumFlagNames.Length; ++index)
            {
                System.Console.WriteLine
                (
                    "Name: {0} | Value: {1} | Description: {2}",
                    enumFlagNames[index],
                    enumFlagValues[index],
                    ToDescription((EnumFlag) enumFlagValues[index])
                );
            }
        }
                
        /// <summary>
        /// System.Console.WriteLine(EnumFlag.One.Value());
        /// </summary>
        public static string Value( this EnumFlag enumerator )
        {
            int v = (int) enumerator;
            return "MQ000" + v.ToString();
        }
        #endregion

        /// <summary>
        /// EnumFlag enumFlag = EnumFlag.None;
        /// bool hasFlag = enumFlag.HasFlag(EnumFlag.None);
        /// System.Console.WriteLine(hasFlag);
        /// EnumFlag None = EnumFlag.None | EnumFlag.Eight;
        /// bool hasFlag = None.HasFlag(EnumFlag.Four);
        /// System.Console.WriteLine
        /// (
        ///     "Value: {0} | Flag: {1} | HasFlag: {2}",
        ///     None,
        ///     EnumFlag.None,
        ///     hasFlag
        /// );
        /// </summary>
        [FlagsAttribute]
        public enum EnumFlag
        {
            [Description("0")]
            None = 0,
            [Description("1")]
            One = 1 << 0,
            [Description("2")]
            Two = 1 << 1,
            [Description("4")]
            Four = 1 << 2,
            [Description("8")]
            Eight = 1 << 3
        }
    }
    #endregion
}
