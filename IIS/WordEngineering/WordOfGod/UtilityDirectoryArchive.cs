using System;
using System.Collections;
using System.IO;
using System.Web;

namespace WordEngineering
{
 /// <summary>UtilityDirectory.</summary>
 public class UtilityDirectory
 {
  /// <summary>The argument index for the directory.</summary>
  public static int ArgumentIndexDirectory         = 0;

  /// <summary>The argument index for the file search pattern.</summary>
  public static int ArgumentIndexFileSearchPattern = 1;

  ///<summary>The entry point for the application.</summary>
  ///<param name="argv">Command-line arguments.</param>
  public static void Main
  (
   String[] argv
  )
  {
   int       argumentTotal          = argv.Length;
   String    filenameSearchPattern  = "*.*";
   String    directoryName          =  Directory.GetCurrentDirectory();

   ArrayList arrayListDirectoryName = null;
   ArrayList arrayListFileName      = null;
   
   if ( argumentTotal > ArgumentIndexDirectory )
   {
    directoryName = argv[ArgumentIndexDirectory];	
   }//if ( argumentTotal > ArgumentIndexDirectory )

   if ( argumentTotal > ArgumentIndexFileSearchPattern )
   {
    filenameSearchPattern = argv[ArgumentIndexFileSearchPattern];
   }//if ( argumentTotal > ArgumentIndexDirectory )

   Dir
   (
    ref directoryName,
    ref filenameSearchPattern,
    ref arrayListDirectoryName,
    ref arrayListFileName
   );//Dir
   
  }//public static void Main()
  
  /// <summary>Process all files in the directory passed in, and recurse on any directories that are found to process the files they contain.</summary>
  public static void Dir
  (
   ref  String    fileSearchPattern,
   ref  String    directoryNameRoot,
   ref  String    fileNamePattern,
   ref  ArrayList arrayListDirectoryName,
   ref  ArrayList arrayListFileName
  ) 
  {
   directoryNameRoot  =  Path.GetDirectoryName( fileSearchPattern );
   fileNamePattern    =  Path.GetFileName( fileSearchPattern );
   Dir
   (
    ref directoryNameRoot,
    ref fileNamePattern,
    ref arrayListDirectoryName,
    ref arrayListFileName
   ); 
  }//public static void Dir()
    
  /// <summary>Process all files in the directory passed in, and recurse on all the directories.</summary>
  public static void Dir
  (
   ref String    directoryNameRoot,
   ref String    fileNamePattern,
   ref ArrayList arrayListDirectoryName,
   ref ArrayList arrayListFileName
  ) 
  {
   int      directoryIndex = 0;
   String[] filename       = null;
   String[] directoryname  = null;
   
   arrayListDirectoryName  = new ArrayList();
   arrayListFileName       = new ArrayList();

   while ( true )
   {
    directoryname = Directory.GetDirectories( directoryNameRoot );
    foreach( String directorynameCurrent in directoryname )
    {
     arrayListDirectoryName.Add( directorynameCurrent );  	
    }//foreach( String directorynameCurrent in directoryname )
    filename = Directory.GetFiles( directoryNameRoot, fileNamePattern );
    foreach( String filenameCurrent in filename )
    {
     arrayListFileName.Add( filenameCurrent );  	
    }//foreach( String filenameCurrent in filename )
    if ( directoryIndex < arrayListDirectoryName.Count )
    {
     directoryNameRoot = (String) arrayListDirectoryName[directoryIndex];
     ++directoryIndex;
    }//if ( directoryIndex < arrayListDirectoryName.Count )
    else
    {
     break;
    }//if ( directoryIndex >= arrayListDirectoryName.Count ) 
   }//while ( true )
  }//public static void Dir	

  /// <summary>Process all files in the directory passed in, and recurse on all the directories.</summary>
  public static void Dir
  (
       String    directoryNameRoot,
       String    fileNamePattern,
   ref ArrayList arrayListFileName
  ) 
  {
   int       directoryIndex = 0;
   String[]  filename       = null;
   String[]  directoryname  = null;
   ArrayList arrayListDirectoryName  =  null;  
   arrayListDirectoryName  = new ArrayList();
   arrayListFileName       = new ArrayList();

   while ( true )
   {
    directoryname = Directory.GetDirectories( directoryNameRoot );
    foreach( String directorynameCurrent in directoryname )
    {
     arrayListDirectoryName.Add( directorynameCurrent );  	
    }//foreach( String directorynameCurrent in directoryname )
    filename = Directory.GetFiles( directoryNameRoot, fileNamePattern );
    foreach( String filenameCurrent in filename )
    {
     arrayListFileName.Add( filenameCurrent );  	
    }//foreach( String filenameCurrent in filename )
    if ( directoryIndex < arrayListDirectoryName.Count )
    {
     directoryNameRoot = (String) arrayListDirectoryName[directoryIndex];
     ++directoryIndex;
    }//if ( directoryIndex < arrayListDirectoryName.Count )
    else
    {
     break;
    }//if ( directoryIndex >= arrayListDirectoryName.Count ) 
   }//while ( true )
  }//public static void Dir	
  
  ///<summary>The web server full path for a given filename.</summary>
  ///<param name="filename">The filename.</param>
  public static void WebServerFullPath
  (
   ref String filename
  ) 
  {
   String       directoryName         =  null;
   String       webServerVirtualPath  =  null;	  
   HttpContext  httpContext           =  null;

   httpContext = HttpContext.Current; 
   
   if ( httpContext != null )
   {
    webServerVirtualPath  = httpContext.Server.MapPath( null );
    directoryName         = Path.GetDirectoryName ( filename );
    if ( directoryName == null || directoryName == String.Empty )
    {
     filename = webServerVirtualPath + Path.DirectorySeparatorChar + filename;
    }//if ( directoryName == null || directoryName == String.Empty )    	
   }//if ( httpContext != null ) 
  }//public static String WebServerFullPath()

  ///<summary>CreateDirectory.</summary>
  public static void CreateDirectory
  (
   ref String directoryName,
   ref String exceptionMessage
  ) 
  {
  
   try
   {
    if ( Directory.Exists( directoryName ) == false )
    {
      Directory.CreateDirectory( directoryName );    	
    }    	
   }//try
   catch ( Exception exception )
   {
    exceptionMessage = "Exception: " + exception.Message;
   }//catch ( Exception exception ) 
  }//public static void CreateDirectory()

 }//public class UtilityDirectory.
}//namespace WordEngineering. 
