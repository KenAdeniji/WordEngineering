using System; 
using System.Data; 
using System.Data.Sql; 
using System.Data.SqlServer; 
using System.Data.SqlTypes; 

using System.IO; 

public partial class UtilityDiskIO
{ 
 [SqlProcedure] 
 public static void DirectoryCreate(String NewDirFullPath) 
 { 
  try 
  { 
   if (Directory.Exists(NewDirFullPath))
   {   
    SqlContext.GetPipe().Send
    (
     String.Format
     (
      "Directory '{0}' already exists.", 
      NewDirFullPath
     )
    )
   };//if (Directory.Exists(NewDirFullPath)) 
   else 
   { 
    Directory.CreateDirectory
    (
     NewDirFullPath
    ); 
    SqlContext.GetPipe().Send
    (
     String.Format
     (
      "Directory '{0}' created.", 
      NewDirFullPath
     )
    ); 
   }//if (Directory.Exists(NewDirFullPath)) 
  }//try 
  catch (Exception exception) 
  { 
   SqlContext.GetPipe().Send
   (
    String.Format
    (
     "Error while creating '{0}'. {1}", 
     NewDirFullPath, 
     exp.ToString()
    )
   ); 
  }//catch (Exception exception)  
 }//public static void DirectoryCreate(String NewDirFullPath)  
};//public partial class UtilityDiskIO
