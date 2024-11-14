namespace WordEngineering
{
 ///<summary>UtilityEnvironment</summary>
 ///<remarks>
 /// VB2TheMax.com/ShowContent.aspx?ID=f953b704-5b8b-4df8-97ec-5e30516c4a3e
 ///</remarks>
 public class UtilityEnvironment
 {
  /// <summary>The entry point for the application.</summary>
  /// <param name="argv">A list of arguments</param>
  public static void Main( string[] argv )
  {
   Stub();
  }//public static void Main( string[] argv )

  ///<summary>Stub</summary>
  public static void Stub()
  {
   System.Console.WriteLine(".Net Framework Runtime Directory: {0}", NetFrameworkRuntimeDirectory() );
   System.Console.WriteLine(".Net Framework Runtime Version: {0}", NetFrameworkRuntimeVersion() );
   System.Console.WriteLine(".Net Framework Runtime System Configuration File: {0}", NetFrameworkRuntimeSystemConfigurationFile() );
  }//public static void Stub()
  
  ///<summary>NetFrameworkRuntimeDirectory</summary>
  public static string NetFrameworkRuntimeDirectory()
  {
   return( System.Runtime.InteropServices.RuntimeEnvironment.GetRuntimeDirectory() );
  }

  ///<summary>NetFrameworkRuntimeVersion</summary>
  public static string NetFrameworkRuntimeVersion()
  {
   return( System.Runtime.InteropServices.RuntimeEnvironment.GetSystemVersion() );
  }

  ///<summary>NetFrameworkRuntimeSystemConfigurationFile</summary>
  public static string NetFrameworkRuntimeSystemConfigurationFile()
  {
   return( System.Runtime.InteropServices.RuntimeEnvironment.SystemConfigurationFile );
  }

 }//public class UtilityEnvironment
}//namespace WordEngineering