using System;
using System.Web;
using System.Web.Security;
using System.Security.Principal;
using System.Runtime.InteropServices;
using System.Text;

namespace WordEngineering
{
 ///<summary>UtilityEncrypt</summary>
 public class UtilityEncrypt
 {
  /*[SuppressUnmanagedCodeSecurity]*/
  [DllImport("advapi32.dll", CharSet=CharSet.Auto, SetLastError=true)]
  private static extern bool EncryptFile(string lpFilename);

  /*[SuppressUnmanagedCodeSecurity]*/
  [DllImport("advapi32.dll", CharSet=CharSet.Auto, SetLastError=true)]
  private static extern bool DecryptFile(string lpFilename, int dwReserved);

  /*[SuppressUnmanagedCodeSecurity]*/
  [DllImport("advapi32.dll", CharSet=CharSet.Auto, SetLastError=true)]
  private static extern bool FileEncryptionStatus(string lpFilename, out int lpStatus);

  ///<summary>EncryptionStatus</summary>
  private enum EncryptionStatus
  {
   CanBeEncrypted = 0,
   IsEncrypted = 1,
   IsSystemFile = 2,
   IsRootDirectory = 3,
   IsSystemDirectory = 4,
   Unknown = 5,
   NotSupportedByFileSystem = 6,
   UserDisallowed = 7,
   IsReadOnly = 8,
   DirectoryDisallowed = 9
  }

  ///<summary>Encrypt</summary>
  public static bool Encrypt
  (
   ref String filename
  )
  {
   return EncryptFile( filename );
  }

  ///<summary>Decrypt</summary>
  public static bool Decrypt
  (
   ref String filename
  )
  {
   return DecryptFile( filename, 0 );
  }
   
  ///<summary>GetFileEncryptionStatus</summary>
  public static void GetFileEncryptionStatus
  (
   ref String filename,
   ref int    fileEncryptionStatus
  )
  {
   FileEncryptionStatus
   (
        filename,
    out fileEncryptionStatus
   );
  }//public static void GetFileEncryptionStatus

  ///<summary>The entry point for the application.</summary>
  ///<param name="argv">A list of command line arguments</param>
  public static void Main
  (
   String[] argv
  )
  {
   for(int argc = 0; argc < argv.Length; ++argc)
   {
    System.Console.WriteLine("{0} {1}", argv[argc], Encrypt(ref argv[argc]));
   }//for(int argc = 0; argc < argv.Length; ++argc)
  }//public static void Main()

 }//public class UtilityEncrypt 
}//namespace WordEngineering