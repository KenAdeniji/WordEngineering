using Microsoft.SqlServer.Server;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

using System.ComponentModel;
using System.Reflection;

/*
2015-01-07	Created.	LightEmittingDiodeLEDSQLCLR.cs
2015-01-08	Consider using enum. Work-in-progress.
*/
namespace InformationInTransit.ProcessLogic
{
	public static partial class LightEmittingDiodeLEDSQLCLR
	{
		public static void Main (string[] argv)
		{
			foreach(string current in argv)
			{
				SqlString result = Query(current);
				System.Console.WriteLine(result);

				//SqlString pointer = QueryPointer(current);
				//System.Console.WriteLine(pointer);
				
				//SqlString outcome = QueryEnum(current);
				//System.Console.WriteLine(outcome);
			}	
		}
		
		[SqlFunction(DataAccess = DataAccessKind.Read)]
		public static SqlString Query(string present)
		{
			StringBuilder sb = new StringBuilder();
			try
			{
				foreach (char single in present)
				{
					int currentInteger = Convert.ToInt32(single) - 48; //ASCII code.
					string currentIndex = Led[currentInteger];
					sb.Append(currentIndex + " ");
				}
			}
			catch(Exception ex)
			{
				System.Console.WriteLine(ex.Message);
			}	
			return sb.ToString().Trim();
		}
		
		/*
		[SqlFunction(DataAccess = DataAccessKind.Read)]
		public static SqlString QueryEnum(string present)
		{
			StringBuilder sb = new StringBuilder();
			try
			{
				foreach (char single in present)
				{
					int currentInteger = Convert.ToInt32(single) - 48; //ASCII code.
					string currentIndex = Led[currentInteger];
				}
			}
			catch(Exception ex)
			{
				System.Console.WriteLine(ex.Message);
			}	
			return sb.ToString().Trim();
		}
		*/
		
		/*
		[SqlFunction(DataAccess = DataAccessKind.Read)]
		public static SqlString QueryPointer(string present)
		{
			StringBuilder sb = new StringBuilder();
			try
			{
				foreach (char single in present)
				{
					int currentInteger = Convert.ToInt32(single) - 48; //ASCII code.
					string currentIndex = Pointer[currentInteger];
				}
			}
			catch(Exception ex)
			{
				System.Console.WriteLine(ex.Message);
			}	
			return sb.ToString().Trim();
		}
		*/

		public static string[] Led = new String[] {
			"North, North West, North East, South West, South East, South.", //0
			"North West, South West.", //1
			"North, North East, South West, South.", //2
			"North, North East, South East, South.", //3
			"NorthWest, North East, Center, South East.", //4
			"North, North West, Center, South East, South.", //5
			"North, North West, Center, South West, South East, South.", //6
			"North, North East, South East.", //7
			"North, North West, North East, Center, South West, South East, South.", //8
			"North, North West, North East, Center, South East, South." //9
		};

/*
		public static string[] Pointer = new String[] {
			(Direction.North | Direction.NorthWest).ToString(),
			//"North, North West, North East, South West, South East, South.", //0
			"North West, South West.", //1
			"North, North East, South West, South.", //2
			"North, North East, South East, South.", //3
			"NorthWest, North East, Center, South East.", //4
			"North, North West, Center, South East, South.", //5
			"North, North West, Center, South West, South East, South.", //6
			"North, North East, South East.", //7
			"North, North West, North East, Center, South West, South East, South.", //8
			"North, North West, North East, Center, South East, South." //9
		};
*/		
        public enum Direction
        {
            North = 0,
            NorthWest = 1,
            NorthEast = 2,
            Center = 3,
            SouthWest = 4,
            SouthEast = 5,
            South = 6
        };
		
		/*
        [FlagsAttribute]
        public enum EnumFlag
        {
            [Description("North")]
            North = 0,
            [Description("North West")]
            NorthWest = 1 << 0,
            [Description("North East")]
            NorthEast = 1 << 1,
            [Description("Center")]
            Center = 1 << 2,
            [Description("South West")]
            SouthWest = 1 << 3,
            [Description("South East")]
            SouthEast = 1 << 4,
            [Description("South")]
            South = 1 << 5
        };
		
		public const EnumFlag Zero = 	EnumFlag.North | EnumFlag.NorthWest | EnumFlag.NorthEast |
									EnumFlag.SouthWest | EnumFlag.SouthEast | EnumFlag.South;
		public const EnumFlag One = EnumFlag.NorthWest | EnumFlag.SouthWest;

        [FlagsAttribute]
        public enum EnumFlag
        {
            [Description("North")]
            North = 0,
            [Description("North West")]
            NorthWest = 1 << 0,
            [Description("North East")]
            NorthEast = 1 << 1,
            [Description("Center")]
            Center = 1 << 2,
            [Description("South West")]
            SouthWest = 1 << 3,
            [Description("South East")]
            SouthEast = 1 << 4,
            [Description("South")]
            South = 1 << 5
        };
		
		public const EnumFlag Zero = 	EnumFlag.North | EnumFlag.NorthWest | EnumFlag.NorthEast |
									EnumFlag.SouthWest | EnumFlag.SouthEast | EnumFlag.South;
		public const EnumFlag One = EnumFlag.NorthWest | EnumFlag.SouthWest;
		*/
	}
}
