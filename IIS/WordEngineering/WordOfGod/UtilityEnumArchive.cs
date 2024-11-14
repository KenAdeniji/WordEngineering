using System;
using System.Collections;
using System.ComponentModel;
using System.Reflection;
using System.Text;

namespace WordEngineering
{
 ///<summary>UtilityEnum</summary>
 ///<remarks>
 ///Subject: Re: How to get the items count of an enum   11/14/2005 12:24 AM PST 
 ///By:    Truong Hong Thi  In:    microsoft.public.dotnet.languages.csharp 
 ///Use either Enum.GetNames or Enum.GetValues method.
 ///Example:
 ///int count = Enum.GetValues(typeof(enAllow)).Length;
 ///</remarks> 
 public static class UtilityEnum
 {
  /// <summary>ConnectStates</summary>
  public enum ConnectStates : uint
  {
    [Description("LAN")]
    LAN = 0x0002,
    [Description("Modem")]
    Modem = 0x0001,
    [Description("Proxy")]
    Proxy = 0x0004,
    [Description("Offline")]
    Offline = 0x0020,
    [Description("Configured")]
    Configured = 0x0040,
    [Description("RasInstalled")]
    RasInstalled = 0x0010
  };

  /// <summary>The entry point for the application.</summary>
  /// <param name="argv">A list of command line arguments</param>
  public static void Main(string[] argv)
  {
   EnumNameValue();
   System.Console.WriteLine(EnumToString(typeof(ConnectStates), (uint)(ConnectStates.Offline | ConnectStates.RasInstalled)));
  }

  public static void EnumNameValue()
  {
   String[] connectStatesName;
   int[] connectStatesValue;
   System.Console.WriteLine("Count: {0}", Enum.GetValues(typeof(ConnectStates)).Length);
   connectStatesName = Enum.GetNames(typeof(ConnectStates));
   connectStatesValue = (int[]) Enum.GetValues(typeof(ConnectStates));
   for ( int index = 0; index < connectStatesName.Length; ++index )
   {
    System.Console.WriteLine("{0}: {1}", connectStatesName[index], connectStatesValue[index]);
   }
  }

  /// <summary>
  /// http://www.microsoft.com/mspress/books/sampchap/6436.aspx Microsoft® Visual Basic .NET Programmer's Cookbook Matthew MacDonald
  /// http://blogs.msdn.com/abhinaba/archive/2005/10/20/483000.aspx I know the answer (it's 42) Abhinaba's blog on C#, Team System, and all other things. 42
  /// </summary>
  public static string EnumToString(Type enumType, uint enumFlag)
  {
      uint enumValue;
      string[] enumName;
      string enumDescription;
      StringBuilder sb = new StringBuilder();
      System.Console.WriteLine("enumFlag: {0}", enumFlag);
      enumName = Enum.GetNames(enumType);
      for (int i = 0; i <= enumName.GetUpperBound(0); i++)
      {
          enumDescription = EnumDescription((Enum)Enum.Parse(enumType, enumName[i]));
          enumValue = (uint)(Enum.Parse(enumType, enumName[i]));
          if ((enumValue & enumFlag) == enumValue) { sb.Append(enumDescription + ' '); }
      }
      return (sb.ToString());
  }

  public static string EnumDescription(Enum value)
  {
      FieldInfo fi = value.GetType().GetField(value.ToString());
      DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes
                                          (typeof(DescriptionAttribute), false);
      return (attributes.Length > 0) ? attributes[0].Description : value.ToString();
  } 

 }
}