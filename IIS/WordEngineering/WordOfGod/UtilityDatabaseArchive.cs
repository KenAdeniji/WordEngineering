/*
 csc /doc:UtilityDatabaseXmlDocumentation.xml /target:library /out:bin\UtilityDatabase.dll UtilityDatabase.cs
 REFERENCE
  C# Programmer's Reference XML Documentation Tutorial
   ms-help://MS.NETFrameworkSDKv1.1/csref/html/vcwlkxmldocumentationtutorial.htm
  C# Programmer's Reference #if 
   ms-help://MS.NETFrameworkSDKv1.1/csref/html/vclrfif.htm
  C# OleDbException.Errors Property
   ms-help://MS.NETFrameworkSDKv1.1/cpref/html/frlrfSystemDataOleDbOleDbExceptionClassErrorsTopic.htm
   
 PROVIDER
  Provider=MSDAORA; Data Source=ORACLE8i7; User ID=OLEDB; Password=OLEDB
  Provider=Microsoft.Jet.OLEDB.4.0; Data Source=WordEngineering.mdb;
  Provider=SQLOLEDB;Data Source=localhost;Initial Catalog=WordEngineering;Integrated Security=SSPI;
  Provider=SQLOLEDB;Data Source=MySQLServer;Integrated Security=SSPI;
  
 20030323 Connection Events
 20030718 Find: DirectorynameSeparator. Replace: DirectorySeparatorChar. Sweat, armpit, left.
 20030805 Include the foreign key column in the database updates where clause to reduce the potencial of updating duplicate sequenceOrderId across multiple theWordId.
 20030812 ScriptureReferenceURI() Retrieve the primary key column from the database schema and not from an external xml file.
*/

using System;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using System.Data.Sql;
using System.Data.SqlClient;
using System.IO;
using System.Reflection;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace WordEngineering
{
 /// <summary>Utility Database will manage database connections.</summary>
 /// <remarks>
 ///  The methods will include DatabaseConnectionInitialize(), DatabaseConnectionHouseKeeping().
 /// </remarks>
 public class UtilityDatabase
 {

   /// <summary>The XmlMarkupCharacters.</summary>
   public static char[] XmlMarkupCharacters = { '<', '>',   };

   /// <summary>The DelimiterCharSplit.</summary>
   public static char[] DelimiterCharSplit;

   /// <summary>The DelimiterCharSplitDatabaseOwnerObject.</summary>
   public static char[] DelimiterCharSplitDatabaseOwnerObject;

   /// <summary>The information schema database classification rank name.</summary>
   public static int DatabaseColumnOrdinalSequenceOrderId                    = 0;

   /// <summary>The pattern file xml.</summary>   
   public static int PatternFileXmlRankXPath                           = 0;
   
   /// <summary>The pattern file xml default.</summary>   
   public static int PatternFileXmlRankDefault                         = 1;

   /// <summary>DatabaseOwnerTableFormat.</summary>
   public static String DatabaseOwnerTableFormat                 = "{0}.{1}.{2}";

   /// <summary>The information schema table.</summary>
   public static String DatabaseUpdateTemplate                   = "IF EXISTS ( SELECT TOP 1 FROM {0} WHERE {1} BEGIN INSERT {2} SELECT @@IDENTITY END ELSE BEGIN UPDATE {3} END";

   /// <summary>The information schema table.</summary>
   public static String DatabaseTemplateUpdatePrimaryKey         = "{0} IF NOT EXISTS ( SELECT {1} FROM {2} WHERE {1} = {3} ) BEGIN INSERT {2} ({4}) VALUES ({5}) END ELSE BEGIN UPDATE {2} SET {6} WHERE {1} = {3} END; {7}";

   /// <summary>The database template insert.</summary>
   public static String DatabaseTemplateInsert                   = "INSERT {0}..{1} VALUES ({2})";

   /// <summary>The database template truncate.</summary>
   public static String DatabaseTemplateTruncate                 = "TRUNCATE TABLE {0}..{1}";

   /// <summary>The database template identity maximum.</summary>
   public static String DatabaseTemplateIdentityMaximum          = "IF EXISTS ( SELECT * FROM SYSOBJECTS FULL OUTER JOIN SYSCOLUMNS ON SYSOBJECTS.id = SYSCOLUMNS.id WHERE SYSOBJECTS.name = '{0}..{1}' AND SYSCOLUMNS.status & 0x80 = 0x80 ) SELECT MAX( IDENTITYCOL ) FROM {0}..{1}";

   /// <summary>The database template identity set.</summary>
   public static String DatabaseTemplateIdentitySet          = "IF EXISTS ( SELECT * FROM SYSOBJECTS FULL OUTER JOIN SYSCOLUMNS ON SYSOBJECTS.id = SYSCOLUMNS.id WHERE SYSOBJECTS.name = '{0}..{1}' AND SYSCOLUMNS.status & 0x80 = 0x80 ) DBCC CHECKIDENT( '{0}..{1}', RESEED, {2} )";
   
   /// <summary>The database template identity insert off.</summary>
   public static String DatabaseTemplateIdentityInsertOff        = "IF EXISTS ( SELECT * FROM SYSOBJECTS FULL OUTER JOIN SYSCOLUMNS ON SYSOBJECTS.id = SYSCOLUMNS.id WHERE SYSOBJECTS.name = '{0}..{1}' AND SYSCOLUMNS.status & 0x80 = 0x80 ) SET IDENTITY_INSERT {0}..{1} OFF";

   /// <summary>The database template identity insert on.</summary>
   public static String DatabaseTemplateIdentityInsertOn         = "IF EXISTS ( SELECT * FROM SYSOBJECTS FULL OUTER JOIN SYSCOLUMNS ON SYSOBJECTS.id = SYSCOLUMNS.id WHERE SYSOBJECTS.name = '{0}..{1}' AND SYSCOLUMNS.status & 0x80 = 0x80 ) SET IDENTITY_INSERT {0}..{1} ON";
  
   /// <summary>The SQL Update statement for the ScriptureReferenceURI.</summary>  
   public static String DatabaseTemplateSQLUpdateScriptureReferenceURI              = " UPDATE {0} SET {1} = {2}, {3} = '{4}' WHERE {5} = '{6}'";

   /// <summary>DefaultDatabase.</summary>
   public static String DefaultDatabase                           = "WordEngineering";                

   /// <summary>DefaultDatabase.</summary>
   public static String DefaultOwner                              = "";

   /// <summary>The DelimiterStringSplit.</summary>
   public static String DelimiterStringSplit                      = " ,";                

   /// <summary>The DelimiterStringSplitDatabaseOwnerObject.</summary>
   public static String DelimiterStringSplitDatabaseOwnerObject   = ".";

   /// <summary>The SQL Update statement for the ScriptureReferenceURI.</summary>  
   public static String DatabaseTemplateSQLUpdateScriptureReferenceURINull          = " UPDATE {0} SET {1} = {2}, {3} = null WHERE {4} = '{5}'";

   /// <summary>The SQL Update statement for the ScriptureReferenceURI.</summary>  
   public static String DatabaseTemplateSQLUpdateScriptureReferenceURISet           = " UPDATE {0} SET {1} WHERE {2} = '{3}'";

   /// <summary>The SQL Update statement for the ScriptureReferenceURI.</summary>  
   public static String DatabaseTemplateSQLSet                                      = " {0} = '{1}'";

   /// <summary>The information schema database classification rank name.</summary>
   public static int InformationSchemaClassificationDatabaseRankName      = 0;
   
   /// <summary>The information schema database classification rank condition.</summary>   
   public static int InformationSchemaClassificationDatabaseRankCondition = 1;   

   /// <summary>The information schema table classification rank name.</summary>
   public static int InformationSchemaClassificationTableRankName      = 0;
   
   /// <summary>The information schema table classification rank condition.</summary>   
   public static int InformationSchemaClassificationTableRankCondition = 1;   

   /// <summary>The information schema table parameter.</summary>
   public static String InformationSchemaTableParameterTableName       = "TableName";   

   /// <summary>The information schema column name.</summary>
   public static String InformationSchemaColumnColumnName = "COLUMN_NAME";

   /// <summary>The information schema column ordinal position.</summary>
   public static String InformationSchemaColumnOrdinalPosition = "ORDINAL_POSITION";

   /// <summary>The information schema column default.</summary>
   public static String InformationSchemaColumnColumnDefault = "COLUMN_DEFAULT";

   /// <summary>The information schema column is nullable.</summary>
   public static String InformationSchemaColumnIsNullable = "IS_NULLABLE";

   /// <summary>The information schema column data type.</summary>
   public static String InformationSchemaColumnDataType = "DATA_TYPE";

   /// <summary>The information schema column name database.</summary>
   public static String InformationSchemaColumnNameDatabase = "CATALOG_NAME";

   /// <summary>The information schema column name table.</summary>
   public static String InformationSchemaColumnNameTable    = "name";

   /// <summary>The information schema column character maximum length.</summary>
   public static String InformationSchemaColumnCharacterMaximumLength = "CHARACTER_MAXIMUM_LENGTH";

   /// <summary>The information schema column constraint type.</summary>
   public static String InformationSchemaColumnConstraintType = "CONSTRAINT_TYPE";

   /// <summary>The information schema column constraint type Primary Key.</summary>
   public static String InformationSchemaColumnConstraintcolumnNamePrimary = "PRIMARY KEY";

   /// <summary>The information schema column constraint type Unique.</summary>
   public static String InformationSchemaColumnConstraintUnique  = "UNIQUE";

   /// <summary>The information schema column query.</summary>
   public static String InformationSchemaColumnSQL               = "SELECT INFORMATION_SCHEMA.COLUMNS.COLUMN_NAME AS COLUMN_NAME, INFORMATION_SCHEMA.COLUMNS.ORDINAL_POSITION AS ORDINAL_POSITION, INFORMATION_SCHEMA.COLUMNS.COLUMN_DEFAULT AS  COLUMN_DEFAULT, INFORMATION_SCHEMA.COLUMNS.IS_NULLABLE AS IS_NULLABLE, INFORMATION_SCHEMA.COLUMNS.DATA_TYPE AS DATA_TYPE, INFORMATION_SCHEMA.COLUMNS.CHARACTER_MAXIMUM_LENGTH AS CHARACTER_MAXIMUM_LENGTH, INFORMATION_SCHEMA.TABLE_CONSTRAINTS.CONSTRAINT_TYPE AS CONSTRAINT_TYPE FROM INFORMATION_SCHEMA.COLUMNS FULL OUTER JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE ON INFORMATION_SCHEMA.COLUMNS.TABLE_NAME = INFORMATION_SCHEMA.KEY_COLUMN_USAGE.TABLE_NAME AND INFORMATION_SCHEMA.COLUMNS.COLUMN_NAME = INFORMATION_SCHEMA.KEY_COLUMN_USAGE.COLUMN_NAME FULL OUTER JOIN INFORMATION_SCHEMA.TABLE_CONSTRAINTS ON INFORMATION_SCHEMA.KEY_COLUMN_USAGE.TABLE_NAME = INFORMATION_SCHEMA.TABLE_CONSTRAINTS.TABLE_NAME AND INFORMATION_SCHEMA.KEY_COLUMN_USAGE.CONSTRAINT_NAME = INFORMATION_SCHEMA.TABLE_CONSTRAINTS.CONSTRAINT_NAME WHERE INFORMATION_SCHEMA.COLUMNS.TABLE_NAME = '{0}' ORDER BY INFORMATION_SCHEMA.COLUMNS.ORDINAL_POSITION";

   /// <summary>The information schema classification database.</summary>
   public static String[][] InformationSchemaClassificationDatabase  = 
   { 
    new String[] { null, ""  },
    new String[] { "Sample", "WHERE {0} IN ( 'Northwind', 'pubs' )" },
    new String[] { "System", "WHERE {0} IN ( 'master', 'model', 'msdb', 'tempdb' )" },
    new String[] { "User",   "WHERE {0} NOT IN ( 'master', 'model', 'msdb', 'Northwind', 'pubs', 'tempdb' )" }
   };

   /// <summary>The information schema classification table.</summary>
   public static String[][] InformationSchemaClassificationTable  = 
   { 
    new String[] { null, ""  },
    new String[] { "System", "WHERE xType = 'S'" },
    new String[] { "User",   "WHERE xType = 'U'" }
   };

   /// <summary>The information schema scripture reference.</summary>
   public static String[][] InformationSchemaScriptureReference = 
   { 
    new String[] { "SequenceOrderId",       "SequenceOrderId" },
    new String[] { "ScriptureReference",    "ScriptureReference" },
    new String[] { "ScriptureReferenceURI", "ScriptureReferenceURI" },
    new String[] { "Sign",                  "Sign" },
    new String[] { "UniqueId",              "UniqueId"  }
   };

   /// <summary>The information schema schemata classification database default.</summary>
   public static String InformationSchemaClassificationDatabaseDefault = "User";

   /// <summary>The information schema schemata classification table default.</summary>
   public static String InformationSchemaClassificationTableDefault = "User";
   
   /// <summary>The information schema primary key column(s) query.</summary>
   public static String InformationSchemacolumnNamePrimaryColumnSQL     = "SELECT COLUMN_NAME, ORDINAL_POSITION FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE JOIN INFORMATION_SCHEMA.TABLE_CONSTRAINTS ON INFORMATION_SCHEMA.KEY_COLUMN_USAGE.TABLE_NAME  = INFORMATION_SCHEMA.TABLE_CONSTRAINTS.TABLE_NAME AND INFORMATION_SCHEMA.KEY_COLUMN_USAGE.CONSTRAINT_NAME  = INFORMATION_SCHEMA.TABLE_CONSTRAINTS.CONSTRAINT_NAME WHERE INFORMATION_SCHEMA.TABLE_CONSTRAINTS.CONSTRAINT_TYPE = 'PRIMARY KEY' AND   INFORMATION_SCHEMA.KEY_COLUMN_USAGE.TABLE_NAME = '{0}' ORDER BY INFORMATION_SCHEMA.KEY_COLUMN_USAGE.ORDINAL_POSITION";

   /// <summary>The information schema database schemata.</summary>
   public static String InformationSchemaSQLDatabase             = "SELECT {0} FROM INFORMATION_SCHEMA.SCHEMATA {1} ORDER BY {0}";

   /// <summary>The information schema table.</summary>
   public static String InformationSchemaSQLTable                = "SELECT {0} FROM {1}..sysobjects {2} ORDER BY {0}";

   /// <summary>The information schema table.</summary>
   public static String InformationSchemaTable                   = "EXEC InformationSchemaTable @{0}='{1}'";

   /// <summary>The information schema Table.</summary>
   public static String InformationSchemaTableView               = "SELECT TABLE_CATALOG, TABLE_SCHEMA, TABLE_NAME FROM INFORMATION_SCHEMA.TABLES ORDER BY TABLE_NAME";

   /// <summary>NorikoYoshidaNameValue</summary>  
   public static String NorikoYoshidaNameValue                                      = "{0} {1} '{2}'";

   /// <summary>The SQL Pattern column value.</summary>  
   public static String   SQLNull                                                   = "null";

   /// <summary>The SQL Pattern column value.</summary>  
   public static String   SQLPatternColumnValue                                     = "'{0}'";

   /// <summary>The SQL Pattern set column.</summary>  
   public static String   SQLPatternSetColumn                                       = "{0}='{1}'";

   /// <summary>The SQL Pattern set column to Null.</summary>  
   public static String   SQLPatternSetColumnNull                                   = "{0}={1}";

   /// <summary>The SQL Pattern Identity Insert On.</summary>  
   public static String   SQLPatternIdentityInsertOff                               = " SET IDENTITY_INSERT {0} OFF ";

   /// <summary>The SQL Pattern Identity Insert On.</summary>   
   public static String   SQLPatternIdentityInsertOn                                = " SET IDENTITY_INSERT {0} ON ";

   /// <summary>The SQL Pattern Insert.</summary>  
   public static String   SQLPatternInsert                                          = " BEGIN INSERT {0} ( {1} ) VALUES ( {2} ) {3} END ";

   /// <summary>The SQL Pattern Insert Identity.</summary>  
   public static String   SQLPatternInsertIdentity                                  = " BEGIN {0} INSERT {1} ( {2} ) VALUES ( {3} ) {4} END ";

   /// <summary>The SQL Pattern Select.</summary>  
   public static String   SQLPatternSelect                                          = " IF NOT EXISTS ( SELECT TOP 1 {0} FROM {1} WHERE {0} = '{2}' ) ";

   /// <summary>The SQL Pattern Select Identity.</summary>  
   public static String   SQLPatternSelectIdentity                                  = " SELECT @@IDENTITY ";

   /// <summary>The SQL Pattern Select Identity for Table.</summary>  
   public static String   SQLPatternSelectIdentityTable                             = " SELECT IDENT_CURRENT( '{0}' ) ";
   
   /// <summary>The SQL Pattern Update.</summary>  
   public static String   SQLPatternUpdate                                          = " UPDATE {0} SET {1} WHERE {2} ";

   /// <summary>The SQL Pattern Scalar.</summary>  
   public static String   SQLPatternScalar                                          = "SELECT {0} ({1}) FROM {2} (NOLOCK) ";

   /// <summary>The SQL Pattern Scalar unique.</summary>  
   public static String   SQLPatternScalarUnique                                    = "SELECT {0} FROM {1} (NOLOCK) WHERE {2} = '{3}' ";
   
   /// <summary>The SQL Pattern Select Insert Update.</summary>  
   public static String   SQLPatternSelectInsertUpdate                              = "{0} {1} ELSE {2}";

   /// <summary>SQLSelectTop1.</summary>  
   public static String  SQLSelectTop1                                              = "SELECT TOP 1 {0} FROM {1} WHERE {2} = '{3}' ";

   /// <summary>SQLStatementKeywordAnd</summary>  
   public static String  SQLStatementKeywordAnd                                     = " AND ";

   /// <summary>SQLStatementKeywordFrom</summary>  
   public static String  SQLStatementKeywordFrom                                    = " FROM ";

   /// <summary>SQLStatementKeywordLike</summary>  
   public static String  SQLStatementKeywordLike                                    = " LIKE ";

   /// <summary>SQLStatementKeywordUnion</summary>  
   public static String  SQLStatementKeywordUnion                                   = "UNION";

   /// <summary>SQLStatementKeywordWhere</summary>  
   public static String  SQLStatementKeywordWhere                                   = " WHERE ";

   /// <summary>The XPath Database.</summary>
   public static String  XPathDatabase                                              = @"/word/database";

   /// <summary>The XPath Connection String Database.</summary>
   public static String  XPathConnectionStringDatabaseFormat                        = @"/word/database[@name='{0}']/databaseConnectionString";

   /// <summary>The entry point for the application.</summary>
   /// <param name="argv">A list of command line arguments</param>
   public static void Main
   (
    string[] argv
   )
   {
   	Stub();
   }//public static void Main

   /// <summary>Stub</summary>
   public static void Stub()
   {
    SqlDataSourceEnumeratorStub();
   }//public static void Stub
 	
   /// <summary>Initializes a new instance of the OleDbConnection class.</summary>
   /// <code>
   ///  <example>
   ///   string          databaseConnectionString = "Provider=SQLOLEDB;Data Source=localhost;Initial Catalog=WordEngineering;Integrated Security=SSPI;";
   ///   string          exceptionMessage         = null;
   ///   OleDbConnection oleDbConnection          = null;
   ///   oleDbConnection = UtilityDatabase.DatabaseConnectionInitialize( databaseConnectionString, ref exceptionMessage );
   ///  </example>  
   /// </code>  
  public static OleDbConnection DatabaseConnectionInitialize
  (
       string databaseConnectionString,
   ref string exceptionMessage
  )
  {
   OleDbConnection oleDbConnection = null;
   exceptionMessage = null;
   try
   {
    oleDbConnection = new OleDbConnection(databaseConnectionString);

    #if (DEBUG)
     oleDbConnection.InfoMessage += new OleDbInfoMessageEventHandler(OleDbInfoMessage);
     oleDbConnection.StateChange += new StateChangeEventHandler(OnOleDbStateChange);    
    #endif
    
    oleDbConnection.Open();
    
    /*
    UtilityDebug.Write
    ( 
     String.Format
     (
      "Database ConnectionString: {0} | DataSource: {1} | Provider: {2} | ServerVersion: {3} | ConnectionTimeout",
      oleDbConnection.ConnectionString,
      oleDbConnection.DataSource,
      oleDbConnection.Provider,
      oleDbConnection.ServerVersion,
      oleDbConnection.ConnectionTimeout
     ) 
    );
    */
    
   }//try
   catch (OleDbException exception)
   {
    //exceptionMessage = DisplayOleDbErrorCollection( exception );
    exceptionMessage   = UtilityEventLog.WriteEntryOleDbErrorCollection( exception );
    exceptionMessage   = String.Format("OLEDbException: {0}", exceptionMessage );
   }//catch (OleDbException exception)
   catch (Exception exception)
   {
    exceptionMessage   = String.Format("Exception: {0}", exception.Message );
   }//catch (Exception exception)
   UtilityDebug.Write( exceptionMessage ); 
   return (oleDbConnection);
  }//DatabaseConnectionInitialize()
  
  /// <summary>Closes the connection to the data source. This is the preferred method of closing any open connection.</summary>
  /// <code>
  ///  <example>
  ///   string          databaseConnectionString = "Provider=SQLOLEDB;Data Source=localhost;Initial Catalog=WordEngineering;Integrated Security=SSPI;";
  ///   string          exceptionMessage         = null;
  ///   OleDbConnection oleDbConnection          = null;
  ///   oleDbConnection = UtilityDatabase.DatabaseConnectionInitialize( databaseConnectionString, ref exceptionMessage );
  ///   UtilityDatabase.DatabaseConnectionHouseKeeping( oleDbConnection, ref exceptionMessage );
  ///  </example>  
  /// </code>  
  public static void DatabaseConnectionHouseKeeping
  (
       OleDbConnection oleDbConnection,
   ref string          exceptionMessage
  )
  {
   exceptionMessage = null;
   try
   {
    oleDbConnection.Close();
   }//try
   catch (OleDbException exception)
   {
    //exceptionMessage = DisplayOleDbErrorCollection( exception );
    exceptionMessage   = UtilityEventLog.WriteEntryOleDbErrorCollection( exception );
    exceptionMessage   = String.Format("OLEDbException: {0}", exceptionMessage );
   }//catch (OleDbException exception)
   catch (Exception exception)
   {
    exceptionMessage   = String.Format("Exception: {0}", exception.Message );
   }//catch (Exception exception)
   UtilityDebug.Write( exceptionMessage ); 
  }//DatabaseConnectionHouseKeeping()

  /// <summary>Database Maintenance.</summary>
  /// <param name="databaseConnectionString">The database connection string.</param>
  /// <param name="exceptionMessage">The exception message.</param>
  /// <param name="filenameConfigurationXml">The configuration XML file name.</param>
  /// <param name="xPathTheseAreTheFirstFruitsDatabase">The XPath for the database(s).</param>  
  /// <param name="xPathTheseAreTheFirstFruitsTable">The XPath for the table(s).</param>  
  /// <param name="xPathSQLTable">The SQL table.</param>
  /// <param name="patternFileXml">The pattern for the XML file(s).</param>
  /// <param name="xPathImportPatternFilename">The XPath for the import pattern filename(s).</param>
  public static void DatabaseMaintenance
  (
       string   databaseConnectionString,
   ref string   exceptionMessage,
       string   filenameConfigurationXml,
       string   xPathTheseAreTheFirstFruitsDatabase,
       string   xPathTheseAreTheFirstFruitsTable,
       string   xPathSQLTable,
       string[] patternFileXml,
       string   xPathImportPatternFilename
  )
  {

   int                   databaseCount                            = -1;
   int                   databaseTableColumnValueOrdinal          = -1;
   int                   databaseTotal                            = -1;
   int                   indexOf                                  = -1;
   int                   tableCount                               = -1;
   int                   tableTotal                               = -1;
   
   string                databaseName                             = null; 
   string                dated                                    = (DateTime.Now).ToString(UtilityFile.FilenameDateTimeStringFormat);
   string                directoryname                            = null;
   string                importFilename                           = null;
   string                importDirectoryname                      = null;   
   string                importPatternFilename                    = null;
   string                tableName                                = null; 
   string[][]            databaseTableName                        = null;
   string                databaseTableColumnValueName             = null;
   string                databaseTableColumnValue                 = null;
   
   ArrayList             arrayListDatabaseName                    = null;
   ArrayList             arrayListImportDirectoryname             = null;
   ArrayList             arrayListImportFilename                  = null;
   ArrayList             arrayListTableName                       = null;   

   DataColumnCollection  dataColumnCollectionDatabaseTable        = null;
   DataRowCollection     dataRowCollectionDatabaseTable           = null;
   DataSet               dataSetDatabaseTable                     = null;
   DataTableCollection   dataTableCollectionDatabaseTable         = null;
   
   object                databaseTableValue                 = null;
   object                databaseTableIdentityMaximumValue        = null;
   OleDbConnection       oleDbConnection                          = null;
      
   StringBuilder         sbXPathTheseAreTheFirstFruitsTable       = null;
   StringBuilder         sbXPathSQLTable                          = null;
   StringBuilder         sbFileXml                                = null;
   StringBuilder         databaseTableSQLColumn                   = null;
   StringBuilder         databaseTableSQLIdentityInsertOff        = null;
   StringBuilder         databaseTableSQLIdentityInsertOn         = null;   
   StringBuilder         databaseTableSQLIdentityMaximum          = null;
   StringBuilder         databaseTableSQLIdentitySet              = null;
   StringBuilder         databaseTableSQLInsert                   = null;
   StringBuilder         databaseTableSQLTruncate                 = null;

   Type                  databaseTableColumnValueType             = null;

   XmlNodeList           xmlNodeListDatabase                      = null;
   XmlNodeList           xmlNodeListImportPatternFilename         = null;
   XmlNodeList           xmlNodeListTable                         = null;
   
   XmlReadMode           xmlReadMode;
 
   exceptionMessage                                               = null;

   /* del TheseAreTheFirstFruits\*yyyyMMddhhmm*.xml /S */
   UtilityXml.XmlDocumentNodeInnerText
   (
        filenameConfigurationXml,
    ref exceptionMessage,
        patternFileXml[PatternFileXmlRankXPath],
    ref patternFileXml[PatternFileXmlRankDefault]
   ); 

   if ( exceptionMessage != null )
   {
    UtilityDebug.Write( String.Format("Exception Message: {0}", exceptionMessage) );
    return;
   }
   
   xmlNodeListDatabase = UtilityXml.SelectNodes
   (
        filenameConfigurationXml,
    ref exceptionMessage,
        xPathTheseAreTheFirstFruitsDatabase
   );

   if ( exceptionMessage != null )
   {
    System.Console.WriteLine("Exception Message: {0}", exceptionMessage );
    return;
   }
   
   if ( xmlNodeListDatabase != null && xmlNodeListDatabase.Count > 0 )
   {
    arrayListDatabaseName = new ArrayList(); 
    foreach ( XmlNode xmlNode in xmlNodeListDatabase )
    {
     databaseName = xmlNode.InnerXml;
     if ( databaseName == null || databaseName == "" || databaseName == string.Empty )
     {
      continue;
     }//if ( databaseName == null || databaseName == "" || databaseName == string.Empty ) 	
     indexOf = databaseName.IndexOfAny(XmlMarkupCharacters);
     if ( indexOf >= 0 )
     {
      databaseName = databaseName.Substring( 0, indexOf ).Trim();
     }	
     arrayListDatabaseName.Add( databaseName );
    }//foreach ( XmlNode xmlNode in xmlNodeList )
   }//if ( xmlNodeListDatabase != null && xmlNodeListDatabase.Count > 0 )

   if ( arrayListDatabaseName == null )
   {
    arrayListDatabaseName = DatabaseName
    (
         databaseConnectionString,
     ref exceptionMessage
    );
   }//if ( arrayListDatabaseName == null || arrayListDatabaseName.Count <= 0 ) 
   
   databaseTotal = arrayListDatabaseName.Count;
   databaseTableName = new string[databaseTotal][];

   for ( databaseCount = 0; databaseCount < databaseTotal; ++databaseCount )
   {

    arrayListTableName = null;
    tableTotal = -1;
    
    databaseName = ( string ) arrayListDatabaseName[ databaseCount ];
    #if ( DEBUG )
     System.Console.WriteLine
     (
      "UtilityDatabase.DatabaseMaintenance() Database Name [{0}]: {1}", 
      databaseCount,
      databaseName
     );
    #endif

    sbXPathTheseAreTheFirstFruitsTable = new StringBuilder();

    sbXPathTheseAreTheFirstFruitsTable.AppendFormat
    (
      xPathTheseAreTheFirstFruitsTable,
      databaseName
    );

    xmlNodeListTable = UtilityXml.SelectNodes
    (
         filenameConfigurationXml,
     ref exceptionMessage,
         sbXPathTheseAreTheFirstFruitsTable.ToString()
    );
   
    if ( xmlNodeListTable != null && xmlNodeListTable.Count > 0 )
    {
     arrayListTableName = new ArrayList(); 
     foreach ( XmlNode xmlNode in xmlNodeListTable )
     {
      tableName = xmlNode.InnerXml;
      if ( tableName == null || tableName == "" || tableName == string.Empty )
      {
       continue;
      }//if ( tableName == null || tableName == "" || tableName == string.Empty ) 	
      indexOf = tableName.IndexOfAny(XmlMarkupCharacters);
      if ( indexOf >= 0 )
      {
       tableName = tableName.Substring( 0, indexOf ).Trim();
      }	
      arrayListTableName.Add( tableName );
     }//foreach ( XmlNode xmlNode in xmlNodeListTable )
    }//if ( xmlNodeListTable != null && xmlNodeListTable.Count > 0 )
    
    if ( arrayListTableName == null )
    {
     arrayListTableName = TableName
     (
          databaseConnectionString,
      ref exceptionMessage,
          databaseName
     );
    }//if ( arrayListTableName == null )
    
    if ( arrayListTableName != null  )
    {
     tableTotal = arrayListTableName.Count;	
    }//if ( arrayListTableName == null )

    databaseTableName[databaseCount] = new string[tableTotal];
 	
    for ( tableCount = 0; tableCount < tableTotal; ++tableCount )
    {
     
     sbXPathSQLTable  = new StringBuilder();
     sbFileXml        = new StringBuilder();
     tableName        = ( string ) arrayListTableName[ tableCount ];
     
     databaseTableName[databaseCount][tableCount] = tableName;
     
     #if ( DEBUG )
      System.Console.WriteLine
      (
       "UtilityDatabase.DatabaseMaintenance() Table Name [{0}]: {1}", 
       tableCount,
       tableName
      );
     #endif

     sbXPathSQLTable.AppendFormat( xPathSQLTable, databaseName, tableName );
     sbFileXml.AppendFormat
     ( 
      patternFileXml[PatternFileXmlRankDefault], 
      databaseName,
      dated, 
      tableName 
     );

     #if ( DEBUG )
      System.Console.WriteLine
      (
       "UtilityDatabase.DatabaseMaintenance() SQL Database Table: {0}", 
       sbXPathSQLTable
      );
     #endif

     DatabaseQuery
     ( 
          databaseConnectionString, 
      ref exceptionMessage, 
      ref dataSetDatabaseTable, 
          sbXPathSQLTable.ToString(), 
          CommandType.Text
     );

     #if ( DEBUG )
      System.Console.WriteLine
      (
       "UtilityDatabase.DatabaseMaintenance() XML Filename: {0}", 
       sbFileXml
      );
     #endif

     directoryname = Path.GetDirectoryName( sbFileXml.ToString() );
     if ( Directory.Exists( directoryname ) == false )
     {
      Directory.CreateDirectory( directoryname );
     }     	
     try
     {
      dataSetDatabaseTable.WriteXml
      ( 
       sbFileXml.ToString(),
       XmlWriteMode.WriteSchema
      ); 
     }//try
     catch (IOException exception)
     {
      exceptionMessage = String.Format("IOException: {0}", exception.Message );
     }//catch (IOException exception)
     catch (XmlException exception)
     {
      exceptionMessage = String.Format("XmlException: {0}", exception.Message );
     }//catch (XmlException exception)
     catch (Exception exception)
     {
      exceptionMessage = String.Format("Exception: {0}", exception.Message );
     }//catch (Exception exception)
    }//for ( tableCount = 0; tableCount < tableTotal; ++tableCount ) 
   }//for ( databaseCount = 0; databaseCount < databaseCount; ++databaseCount )

   #if ( DEBUG )
    for ( databaseCount = 0; databaseCount < databaseTableName.Length; ++databaseCount )
    {
     for ( tableCount = 0; tableCount < databaseTableName[databaseCount].Length; ++tableCount )
     {
      System.Console.WriteLine
      (
       "UtilityDatabase.DatabaseMaintenance() DatabaseTableName[{0}][{1}]: {2}", 
       databaseCount,
       tableCount,
       databaseTableName[databaseCount][tableCount]
      );
     }//for ( tableCount = 0; tableCount < databaseTableName[databaseCount]; ++tableCount )
    }//for ( databaseCount = 0; databaseCount < databaseTableName.Count; ++databaseCount ) 	
   #endif
   
   xmlNodeListImportPatternFilename = UtilityXml.SelectNodes
   (
        filenameConfigurationXml,
    ref exceptionMessage,
        xPathImportPatternFilename
   );
   
   foreach ( XmlNode xmlNodeImportPatternFilename in xmlNodeListImportPatternFilename )
   {
    importPatternFilename = (xmlNodeImportPatternFilename.InnerXml).Trim();
    directoryname = Path.GetDirectoryName( importPatternFilename );
     
    if ( directoryname == null || directoryname == "" )
    {
     directoryname = Directory.GetCurrentDirectory();
    }//if ( directoryname == null || directoryname == "" )

    #if ( DEBUG )
     System.Console.WriteLine
     (
      "UtilityDatabase.DatabaseMaintenance() Import Pattern Filename: {0} | Directory Name: {1}", 
      importPatternFilename,
      directoryname
     );
    #endif

    UtilityDirectory.Dir
    (
     ref directoryname,
     ref importPatternFilename,
     ref arrayListImportDirectoryname,
     ref arrayListImportFilename
    ); 

    oleDbConnection = DatabaseConnectionInitialize
    (
         databaseConnectionString,
     ref exceptionMessage
    ); 

    if ( exceptionMessage != null )
    {
     return;
    }     	
    
    foreach ( object objectImportFilename in arrayListImportFilename )
    {
     dataSetDatabaseTable = new DataSet();
     importFilename       = ( string ) objectImportFilename;
     indexOf              = importFilename.LastIndexOf( Path.DirectorySeparatorChar   );
     tableName            = importFilename.Substring( indexOf + 1 + UtilityFile.FilenameDateTimeStringFormat.Length );
     UtilityFile.Strip( ref tableName, true, true );
     if ( indexOf > 0 )
     {
      importDirectoryname = importFilename.Substring( 0, indexOf );
     }	
     indexOf              = importDirectoryname.LastIndexOf( Path.DirectorySeparatorChar   );
     if ( indexOf > 0 )
     {
      databaseName        = importDirectoryname.Substring( indexOf + 1 );
     }	
     indexOf              = importFilename.LastIndexOf( xPathImportPatternFilename );
     #if ( DEBUG )
      System.Console.WriteLine
      (
       "UtilityDatabase.DatabaseMaintenance() Import Filename: {0} | Directoryname: {1} | Database name: {2} | Table name: {3}", 
       importFilename,
       importDirectoryname,
       databaseName,
       tableName
      );
     #endif
     try
     {
      xmlReadMode = dataSetDatabaseTable.ReadXml
      (
       importFilename
      );   	
      
      dataTableCollectionDatabaseTable  = dataSetDatabaseTable.Tables;
     
      foreach ( DataTable dataTable in dataTableCollectionDatabaseTable )
      {

       databaseTableSQLTruncate = new StringBuilder();
       databaseTableSQLTruncate.AppendFormat
       ( 
        DatabaseTemplateTruncate, 
        databaseName, 
        tableName
       );
       #if ( DEBUG )
        System.Console.WriteLine
        (
         "UtilityDatabase.DatabaseMaintenance() Database Table Truncate: {0} | Directoryname: {1} | Database name: {2} | Table name: {3} | Truncate: {4}", 
          importFilename,
          importDirectoryname,
          databaseName,
          tableName,
          databaseTableSQLTruncate
         );
       #endif

       DatabaseNonQuery
       ( 
            oleDbConnection,
        ref exceptionMessage, 
            databaseTableSQLTruncate.ToString()
       );

       databaseTableSQLIdentityInsertOn = new StringBuilder();
       databaseTableSQLIdentityInsertOn.AppendFormat
       ( 
        DatabaseTemplateIdentityInsertOn, 
        databaseName, 
        tableName
       );
       #if ( DEBUG )
        System.Console.WriteLine
        (
         "UtilityDatabase.DatabaseMaintenance() Database Table Identity Insert On: {0} | Directoryname: {1} | Database name: {2} | Table name: {3} | Identity Insert On: {4}", 
          importFilename,
          importDirectoryname,
          databaseName,
          tableName,
          databaseTableSQLIdentityInsertOn
         );
       #endif

       DatabaseNonQuery
       ( 
            oleDbConnection,
        ref exceptionMessage, 
            databaseTableSQLIdentityInsertOn.ToString()
       );

       dataRowCollectionDatabaseTable    = dataTable.Rows;
       dataColumnCollectionDatabaseTable = dataTable.Columns;
       foreach ( DataRow dataRowDatabaseTable in dataRowCollectionDatabaseTable )
       {
        databaseTableSQLColumn = new StringBuilder();
        foreach ( DataColumn dataColumnDatabaseTable in dataColumnCollectionDatabaseTable )
        {
         databaseTableColumnValueOrdinal = dataColumnDatabaseTable.Ordinal;
         databaseTableColumnValueName    = dataColumnDatabaseTable.ColumnName;
         databaseTableColumnValueType    = dataColumnDatabaseTable.DataType;
         #if ( DEBUG )
          System.Console.WriteLine
          ( 
           "Column Ordinal: {0} | Name: {1} | Type: {2}",
           databaseTableColumnValueOrdinal,
           databaseTableColumnValueName,
           databaseTableColumnValueType
          ); 
         #endif
         databaseTableValue = dataRowDatabaseTable[dataColumnDatabaseTable];
         System.Console.WriteLine(databaseTableValue);
         if ( databaseTableColumnValueOrdinal > 0 )
         {
          databaseTableSQLColumn.Append(",");	
         }//if ( databaseTableSQLColumn != null )
         if ( databaseTableValue == null || databaseTableValue == DBNull.Value )
         {
          databaseTableSQLColumn.Append("null");		
          continue;
         }	
         if 
         ( 
          databaseTableColumnValueType == System.Type.GetType("System.String")     
         )
         {
          databaseTableColumnValue = databaseTableValue.ToString();
          databaseTableColumnValue = databaseTableColumnValue.Replace( "'", "''");
          databaseTableSQLColumn.Append("'");
          databaseTableSQLColumn.Append( databaseTableColumnValue );
          databaseTableSQLColumn.Append("'");
         }//if ( dataColumnDatabaseTable.DataType == System.Type.GetType("System.String") )
         else if 
         ( 
          databaseTableColumnValueType == System.Type.GetType("System.DateTime") ||
          databaseTableColumnValueType == System.Type.GetType("System.Guid")     
         )
         {
          databaseTableSQLColumn.Append("'");
          databaseTableSQLColumn.Append( databaseTableValue );
          databaseTableSQLColumn.Append("'");
         }//if ( dataColumnDatabaseTable.DataType == System.Type.GetType("System.DateTime") || databaseTableColumnValueType == System.Type.GetType("System.Guid") )
         else
         {
          databaseTableSQLColumn.Append( databaseTableValue );
         }//if ( dataColumnDatabaseTable.DataType == System.Type.GetType("System.String") == false )
        }//foreach ( DataColumn dataColumnDatabaseTable in dataColumnCollectionDatabaseTable )

        databaseTableSQLInsert = new StringBuilder();
        databaseTableSQLInsert.AppendFormat
        ( 
         DatabaseTemplateInsert, 
         databaseName, 
         tableName,
         databaseTableSQLColumn
        );
        #if ( DEBUG )
         System.Console.WriteLine
         (
          "UtilityDatabase.DatabaseMaintenance() Import Filename: {0} | Directoryname: {1} | Database name: {2} | Table name: {3} | Column: {4} | Insert: {5}", 
          importFilename,
          importDirectoryname,
          databaseName,
          tableName,
          databaseTableSQLColumn,
          databaseTableSQLInsert
         );
        #endif
        DatabaseNonQuery
        ( 
             oleDbConnection,
         ref exceptionMessage, 
             databaseTableSQLInsert.ToString()
        );

       }//foreach ( DataRow dataRowDatabaseTable in dataRowCollectionDatabaseTable )       	

       databaseTableSQLIdentityInsertOff = new StringBuilder();
       databaseTableSQLIdentityInsertOff.AppendFormat
       ( 
        DatabaseTemplateIdentityInsertOff, 
        databaseName, 
        tableName
       );
       #if ( DEBUG )
        System.Console.WriteLine
        (
         "UtilityDatabase.DatabaseMaintenance() Database Table Identity Insert On: {0} | Directoryname: {1} | Database name: {2} | Table name: {3} | Identity Insert Off: {4}", 
          importFilename,
          importDirectoryname,
          databaseName,
          tableName,
          databaseTableSQLIdentityInsertOff
         );
       #endif

       DatabaseNonQuery
       ( 
            oleDbConnection,
        ref exceptionMessage, 
            databaseTableSQLIdentityInsertOff.ToString()
       );

       databaseTableSQLIdentityMaximum = new StringBuilder();
       databaseTableSQLIdentityMaximum.AppendFormat
       ( 
        DatabaseTemplateIdentityMaximum, 
        databaseName, 
        tableName
       );
       #if ( DEBUG )
        System.Console.WriteLine
        (
         "UtilityDatabase.DatabaseMaintenance() Database Table Identity Maximum: {0} | Directoryname: {1} | Database name: {2} | Table name: {3} | Identity Maximum: {4}", 
          importFilename,
          importDirectoryname,
          databaseName,
          tableName,
          databaseTableSQLIdentityMaximum
         );
       #endif

       databaseTableIdentityMaximumValue = DatabaseQuery
       ( 
            databaseConnectionString,
        ref exceptionMessage, 
            databaseTableSQLIdentityMaximum.ToString(),
            CommandType.Text
       );

       if ( databaseTableIdentityMaximumValue == DBNull.Value || databaseTableIdentityMaximumValue == null ) 
       {
        continue;
       } 
 
       databaseTableSQLIdentitySet = new StringBuilder();
       databaseTableSQLIdentitySet.AppendFormat
       ( 
        DatabaseTemplateIdentitySet, 
        databaseName, 
        tableName,
        databaseTableIdentityMaximumValue
       );
       #if ( DEBUG )
        System.Console.WriteLine
        (
         "UtilityDatabase.DatabaseMaintenance() Database Table Identity Set: {0} | Directoryname: {1} | Database name: {2} | Table name: {3} | Identity Set: {4}", 
          importFilename,
          importDirectoryname,
          databaseName,
          tableName,
          databaseTableSQLIdentitySet
         );
       #endif

       DatabaseNonQuery
       ( 
            oleDbConnection,
        ref exceptionMessage, 
            databaseTableSQLIdentitySet.ToString()
       );

      }//foreach ( DataTable dataTable in dataTableCollection )
     }//try
     catch (SecurityException exception)
     {
      exceptionMessage = exception.Message;
      System.Console.WriteLine( "SecurityException: {0}", exception.Message );
     }//catch (SecurityException exception)
     catch (XmlException exception)
     {
      exceptionMessage = exception.Message;
      System.Console.WriteLine( "XmlException: {0}", exception.Message );
     }//catch (XmlException exception)
     catch (SystemException exception)
     {
      exceptionMessage = exception.Message;
      System.Console.WriteLine( "SystemException: {0}", exception.Message );
     }//catch (SystemException exception)
     catch (Exception exception)
     {
      exceptionMessage = exception.Message;   
      System.Console.WriteLine( "Exception: {0}", exception.Message );
     }//catch (Exception exception)
     UtilityDebug.Write( exceptionMessage );
    }//foreach ( object objectImportFilename in arrayListImportFilename )     
   }//foreach ( XmlNode xmlNodeImportFilename in xmlNodeListImportFilename )

   DatabaseConnectionHouseKeeping
   (
        oleDbConnection,
    ref exceptionMessage
   );

  }//public static void DatabaseMaintenance

  /// <summary>The database name(s).</summary>
  /// <param name="databaseConnectionString">The database connection string.</param>
  /// <param name="exceptionMessage">The exception message.</param>
  public static ArrayList DatabaseName
  (
       string databaseConnectionString,
   ref string exceptionMessage
  )
  {
   ArrayList arrayListDatabaseName = null;
   arrayListDatabaseName = DatabaseName
   (
        databaseConnectionString,
    ref exceptionMessage,
        InformationSchemaClassificationDatabaseDefault
   ); 
   return ( arrayListDatabaseName );
  }//public static ArrayList DatabaseName
  
  /// <summary>The database name(s).</summary>
  /// <param name="databaseConnectionString">The database connection string.</param>
  /// <param name="exceptionMessage">The exception message.</param>
  /// <param name="databaseClassification">The database classification, for example, sample, system, user.</param>
  public static ArrayList DatabaseName
  (
       string databaseConnectionString,
   ref string exceptionMessage,
       string databaseClassification
  )
  {
   int           databaseClassificationIndex = 0;
   int           databaseClassificationTotal = InformationSchemaClassificationDatabase.Length;
   string        databaseName                = null; 

   ArrayList     arrayListDatabaseName = null;
   IDataReader   iDataReader           = null;
   StringBuilder sbSQLCondition        = null;
   StringBuilder sbSQLStatement        = null;
   
   exceptionMessage                    = null;
   sbSQLCondition                      = new StringBuilder();
   sbSQLStatement                      = new StringBuilder();

   for 
   ( 
    databaseClassificationIndex = 0;
    databaseClassificationIndex < databaseClassificationTotal;
    ++databaseClassificationIndex
   )
   {
    if 
    (
     string.Compare
     ( 
      InformationSchemaClassificationDatabase[databaseClassificationIndex][InformationSchemaClassificationDatabaseRankName], 
      databaseClassification, 
      true 
     )
     ==
     0
    ) 
    {
     //Database classification found.
     sbSQLCondition.AppendFormat
     (
      InformationSchemaClassificationDatabase[databaseClassificationIndex][InformationSchemaClassificationDatabaseRankCondition],
      InformationSchemaColumnNameDatabase
     );
         
     sbSQLStatement.AppendFormat
     (
      InformationSchemaSQLDatabase,
      InformationSchemaColumnNameDatabase,
      sbSQLCondition
     ); 
     
     #if (DEBUG)
      System.Console.WriteLine
      (
       "UtilityDatabase.DatabaseName() Database Name SQL Index [{0}]: Classification: {1} | Condition: {2} | Statement: {3}",
       databaseClassificationIndex,
       databaseClassification,
       sbSQLCondition,
       sbSQLStatement
      );
     #endif
     break;
    }//if strcmp( InformationSchemaClassificationDatabase, databaseClassification, true )    
   }//for ( databaseClassificationIndex = 0; databaseClassificationIndex < databaseClassificationTotal; ++databaseClassificationIndex );
 
   DatabaseQuery
   ( 
        databaseConnectionString, 
    ref exceptionMessage, 
    ref iDataReader,
        sbSQLStatement.ToString(), 
        CommandType.Text
   );
   
   if ( exceptionMessage != null || iDataReader == null)
   {
    return ( arrayListDatabaseName );
   } 
  
   arrayListDatabaseName = new ArrayList();
   
   try
   {
    while ( iDataReader.Read() )
    {
     databaseName = ( string ) iDataReader[InformationSchemaColumnNameDatabase];
     #if (DEBUG)
      System.Console.WriteLine("UtilityDatabase.DatabaseName() Database Name: {0}", databaseName);
     #endif
     arrayListDatabaseName.Add( databaseName );
    }//while ( iDataReader.Read() )
    iDataReader.Close();
   }//try
   catch (OleDbException exception)
   {
    exceptionMessage = UtilityEventLog.WriteEntryOleDbErrorCollection( exception );
    System.Console.WriteLine("UtilityDatabase.DatabaseName() OleDbException: {0}", exceptionMessage);
   }//catch (OleDbException exception)
   catch (Exception exception)
   {
    exceptionMessage = exception.Message;
    System.Console.WriteLine("UtilityDatabase.DatabaseName() Exception: {0}", exception.Message);
   }//catch (Exception exception)
   finally
   {
   }//finally
   
   return ( arrayListDatabaseName );
  }//public static ArrayList DatabaseName  

  /// <summary>Executes the non query statement.</summary>
  /// <param name="oleDbConnection">The database connection.</param>
  /// <param name="exceptionMessage">The exception message.</param>
  /// <param name="commandText">The command text.</param>
  /// <code>
  ///  <example>
  ///   OleDbConnection oleDbConnection   = new OleDbConnection("");
  ///   string          exceptionMessage  = null;
  ///   string          commandText       = "master..xp_msver";
  ///   UtilityDatabase.DatabaseNonQuery
  ///   ( 
  ///        oleDbConnection, 
  ///    ref exceptionMessage, 
  ///        commandText, 
  ///   );
  ///  </example>  
  /// </code>  
  public static void DatabaseNonQuery
  (
       OleDbConnection  oleDbConnection,
   ref string           exceptionMessage,
       string           commandText
  )
  {
   OleDbCommand	 oleDbCommand = null;
   try
   {
    exceptionMessage = null;
    oleDbCommand = new OleDbCommand( commandText, oleDbConnection );
    oleDbCommand.ExecuteNonQuery();
   }//try
   catch (OleDbException exception)
   {
    //exceptionMessage = DisplayOleDbErrorCollection( exception );
    exceptionMessage   = UtilityEventLog.WriteEntryOleDbErrorCollection( exception );
    exceptionMessage   = String.Format("OLEDbException: {0}", exceptionMessage );
   }//catch (OleDbException exception)
   catch (Exception exception)
   {
    exceptionMessage   = String.Format("Exception: {0}", exception.Message );
   }//catch (Exception exception)
   UtilityDebug.Write( exceptionMessage ); 
  }//DatabaseNonQuery()
  
  /// <summary>Executes the query, and returns the first column of the first row in the resultset returned by the query. Extra columns or rows are ignored.</summary>
  /// <code>
  ///  <example>
  ///   string          databaseConnectionString = "Provider=SQLOLEDB;Data Source=localhost;Initial Catalog=WordEngineering;Integrated Security=SSPI;";
  ///   string          exceptionMessage         = null;
  ///   string          commandText              = "SELECT 'Language: ' + @@LANGUAGE + CHAR(13) + CHAR(10) + 'Server Name: ' + @@ServerName + CHAR(13) + CHAR(10) + 'Service Name: ' + @@ServiceName + CHAR(13) + CHAR(10) + 'Version: ' + @@Version";
  ///   object          commandReturn            = null;
  ///   commandReturn  = UtilityDatabase.DatabaseQuery( databaseConnectionString, ref exceptionMessage, commandText );
  ///   System.Console.WriteLine("Query: {0}\n{1}", commandText, commandReturn);
  ///  </example>  
  /// </code>  
  public static object DatabaseQuery
  (
       string  databaseConnectionString,
   ref string  exceptionMessage,
       string  commandText
  )
  {
   return
   (
    DatabaseQuery
    (
         databaseConnectionString,
     ref exceptionMessage,
         commandText,
         CommandType.Text
    ) 
   ); 
  }//public static string DatabaseQuery

  /// <summary>Executes the query, and returns the first column of the first row in the resultset returned by the query. Extra columns or rows are ignored.</summary>
  /// <code>
  ///  <example>
  ///   string          databaseConnectionString = "Provider=SQLOLEDB;Data Source=localhost;Initial Catalog=WordEngineering;Integrated Security=SSPI;";
  ///   string          exceptionMessage         = null;
  ///   string          commandText              = "master..xp_msver";
  ///   object          commandReturn            = null;
  ///   commandReturn  = UtilityDatabase.DatabaseQuery( databaseConnectionString, ref exceptionMessage, commandText, CommandType.StoredProcedure );
  ///   System.Console.WriteLine("Query: {0}\n{1}", commandText, commandReturn);
  ///  </example>  
  /// </code>  
  public static object DatabaseQuery
  (
       string       databaseConnectionString,
   ref string       exceptionMessage,       
       string       commandText,
       CommandType  commandType
  )
  {
   
   exceptionMessage                     = null;
   object           databaseReturnValue = null;
   OleDbConnection  oleDbConnection     = null;
   OleDbCommand     oleDbCommand        = null;
   OleDbDataReader  oleDbDataReader     = null;
      
   try
   {

    oleDbConnection = UtilityDatabase.DatabaseConnectionInitialize
    (
     databaseConnectionString,
     ref exceptionMessage
    );
    
    if ( oleDbConnection == null )
    {
     return ( null );
    }
  
    oleDbCommand =  new OleDbCommand( commandText, oleDbConnection);
    oleDbCommand.CommandType = commandType;
    databaseReturnValue = oleDbCommand.ExecuteScalar();
  
    /*
     object dbValue   = null;

     oleDbDataReader = oleDbCommand.ExecuteReader();
    
     while(oleDbDataReader.Read()) 
     {
      word[wordCount]             = oleDbDataReader.GetString(ResultSetOrdinalWord);
      scriptureReference          = oleDbDataReader.GetString(ResultSetOrdinalScriptureReference);
      verseForward                = oleDbDataReader.GetString(ResultSetOrdinalVerseForward);
      chapterForward              = oleDbDataReader.GetString(ResultSetOrdinalChapterForward);
      chapterBackward             = oleDbDataReader.GetString(ResultSetOrdinalChapterBackward);
      verseBackward               = oleDbDataReader.GetString(ResultSetOrdinalVerseBackward);
      if ( oleDbDataReader.IsDBNull(ResultSetOrdinalAlphabetSequence) )
      {
       alphabetSequence[wordCount] = 0;
      }
      else
      {
       dbValue = oleDbDataReader[ResultSetOrdinalAlphabetSequence];
       alphabetSequence[wordCount] = (Int32) dbValue;
      }//if ( oleDbDataReader.IsDBNull(ResultSetOrdinalAlphabetSequence) )
     }//while(oleDbDataReader.Read()) 
    */

    if ( oleDbDataReader != null )
    {
     oleDbDataReader.Close();
    } 
    UtilityDatabase.DatabaseConnectionHouseKeeping
    (
         oleDbConnection,
     ref exceptionMessage
    );
   
   }//try
   catch (OleDbException exception)
   {
    //exceptionMessage = DisplayOleDbErrorCollection( exception );
    exceptionMessage   = UtilityEventLog.WriteEntryOleDbErrorCollection( exception );
    exceptionMessage   = String.Format("OLEDbException: {0}", exceptionMessage );
   }//catch (OleDbException exception)
   catch (Exception exception)
   {
    exceptionMessage   = String.Format("Exception: {0}", exception.Message );
   }//catch (Exception exception)
   UtilityDebug.Write( exceptionMessage ); 
   
   return ( databaseReturnValue );
   
  }//DatabaseQuery()

  /// <summary>Executes the query, and returns the first column of the first row in the resultset returned by the query. Extra columns or rows are ignored.</summary>
  /// <code>
  ///  <example>
  ///   string          databaseConnectionString = "Provider=SQLOLEDB;Data Source=localhost;Initial Catalog=WordEngineering;Integrated Security=SSPI;";
  ///   OleDbConnection oleDbConnection          = null;
  ///   string          exceptionMessage         = null;
  ///   string          commandText              = "master..xp_msver";
  ///   object          commandReturn            = null;
  ///   oleDbConnection = UtilityDatabase.DatabaseConnectionInitialize
  ///   ( 
  ///      DatabaseConnectionString, 
  ///      ref exceptionMessage 
  ///   );
  ///   commandReturn  = UtilityDatabase.DatabaseQuery( oleDbConnection, ref exceptionMessage, commandText, CommandType.StoredProcedure );
  ///   System.Console.WriteLine("Query: {0}\n{1}", commandText, commandReturn);
  ///  </example>  
  /// </code>  
  public static object DatabaseQuery
  (
       OleDbConnection  oleDbConnection,
   ref string           exceptionMessage,       
       string           commandText,
       CommandType      commandType
  )
  {
   
   object           databaseReturnValue = null;
   OleDbCommand     oleDbCommand        = null;

   exceptionMessage                     = null;
         
   try
   {

    oleDbCommand =  new OleDbCommand( commandText, oleDbConnection);
    oleDbCommand.CommandType = commandType;
    databaseReturnValue = oleDbCommand.ExecuteScalar();
   }//try
   catch (OleDbException exception)
   {
    //exceptionMessage = DisplayOleDbErrorCollection( exception );
    exceptionMessage   = UtilityEventLog.WriteEntryOleDbErrorCollection( exception );
    exceptionMessage   = String.Format("OLEDbException: {0}", exceptionMessage );
   }//catch (OleDbException exception)
   catch (Exception exception)
   {
    exceptionMessage   = String.Format("Exception: {0}", exception.Message );
   }//catch (Exception exception)
   UtilityDebug.Write( exceptionMessage ); 
   
   return (databaseReturnValue);
   
  }//DatabaseQuery()

  /// <summary>Executes the query, and returns the first column of the first row in the resultset returned by the query. Extra columns or rows are ignored.</summary>
  /// <param name="databaseConnectionString">The database connection string, "Provider=SQLOLEDB;Data Source=localhost;Initial Catalog=master;Integrated Security=SSPI;"</param>
  /// <param name="exceptionMessage">The exception message.</param>
  /// <param name="dataSet">The data set.</param>
  /// <param name="commandText">The command text.</param>
  /// <param name="commandType">The command type.</param>
  /// <code>
  ///  <example>
  ///   string      databaseConnectionString = "Provider=SQLOLEDB;Data Source=localhost;Initial Catalog=master;Integrated Security=SSPI;";
  ///   string      exceptionMessage         = null;
  ///   string      commandText              = "master..xp_msver";
  ///   CommandType commandType              = "CommandType.StoredProcedure";  
  ///   DataSet     dataSet                  = null;
  ///   UtilityDatabase.DatabaseQuery
  ///   ( 
  ///        databaseConnectionString, 
  ///    ref exceptionMessage, 
  ///        dataSet, 
  ///        commandText, 
  ///        CommandType.StoredProcedure 
  ///   );
  ///  </example>  
  /// </code>  
  public static void DatabaseQuery
  (
       string      databaseConnectionString,
   ref string      exceptionMessage,
   ref DataSet     dataSet,
       string      commandText,
       CommandType commandType
  )
  {
   
   dataSet                           = null;
   exceptionMessage                  = null;
   OleDbConnection  oleDbConnection  = null;
   OleDbCommand     oleDbCommand     = null;
   OleDbDataAdapter oleDbDataAdapter = null;

   try
   {
    oleDbConnection = UtilityDatabase.DatabaseConnectionInitialize
    (
         databaseConnectionString,
     ref exceptionMessage
    );
    
    if ( oleDbConnection == null ) { return; }
  
    oleDbCommand =  new OleDbCommand( commandText, oleDbConnection);
    oleDbCommand.CommandType = commandType;
    oleDbDataAdapter = new OleDbDataAdapter( oleDbCommand );
    dataSet = new DataSet();
    oleDbDataAdapter.Fill(dataSet);
    UtilityDatabase.DatabaseConnectionHouseKeeping
    (
         oleDbConnection,
     ref exceptionMessage
    );
   }//try
   catch (OleDbException exception)
   {
    //exceptionMessage = DisplayOleDbErrorCollection( exception );
    exceptionMessage   = UtilityEventLog.WriteEntryOleDbErrorCollection( exception );
    exceptionMessage   = String.Format("OLEDbException: {0}", exceptionMessage );
   }//catch (OleDbException exception)
   catch (Exception exception)
   {
    exceptionMessage   = String.Format("Exception: {0}", exception.Message );
   }//catch (Exception exception)
   UtilityDebug.Write( exceptionMessage ); 
  }//DatabaseQuery()

  /// <summary>Executes the query, and returns the first column of the first row in the resultset returned by the query. Extra columns or rows are ignored.</summary>
  /// <param name="databaseConnectionString">The database connection string, "Provider=SQLOLEDB;Data Source=localhost;Initial Catalog=master;Integrated Security=SSPI;"</param>
  /// <param name="exceptionMessage">The exception message.</param>
  /// <param name="iDataReader">The data reader.</param>
  /// <param name="commandText">The command text.</param>
  /// <param name="commandType">The command type.</param>
  /// <code>
  ///  <example>
  ///   string          databaseConnectionString = "Provider=SQLOLEDB;Data Source=localhost;Initial Catalog=master;Integrated Security=SSPI;";
  ///   string          exceptionMessage         = null;
  ///   string          commandText              = "master..xp_msver";
  ///   IDataReader     iDataReader              = null;
  ///   CommandType     commandType              = "CommandType.StoredProcedure";  
  ///   UtilityDatabase.DatabaseQuery
  ///   ( 
  ///        databaseConnectionString, 
  ///    ref exceptionMessage, 
  ///        oleDbDataReader,
  ///        commandText, 
  ///        CommandType.StoredProcedure 
  ///   );
  ///  </example>  
  /// </code>  
  public static void DatabaseQuery
  (
       string           databaseConnectionString,
   ref string           exceptionMessage,
   ref IDataReader      iDataReader,
       string           commandText,
       CommandType      commandType
  )
  {
   
   exceptionMessage                  = null;
   OleDbConnection  oleDbConnection  = null;
   OleDbCommand     oleDbCommand     = null;

   try
   {
    oleDbConnection = UtilityDatabase.DatabaseConnectionInitialize
    (
         databaseConnectionString,
     ref exceptionMessage
    );
    
    if ( oleDbConnection == null ) { return; }
  
    oleDbCommand =  new OleDbCommand( commandText, oleDbConnection);
    oleDbCommand.CommandType = commandType;
    iDataReader = oleDbCommand.ExecuteReader();

    /*
    oleDbCommand =  new OleDbCommand( "SELECT @@ROWCOUNT", oleDbConnection);
    oleDbCommand.CommandType = CommandType.Text;
    rowCount = (Int32) oleDbCommand.ExecuteScalar();
    */

   }//try
   catch (OleDbException exception)
   {
    //exceptionMessage = DisplayOleDbErrorCollection( exception );
    exceptionMessage   = UtilityEventLog.WriteEntryOleDbErrorCollection( exception );
    exceptionMessage   = String.Format("OLEDbException: {0}", exceptionMessage );
   }//catch (OleDbException exception)
   catch (Exception exception)
   {
    exceptionMessage   = String.Format("Exception: {0}", exception.Message );
   }//catch (Exception exception)
   
   if ( exceptionMessage != null )
   {
    UtilityDebug.Write( exceptionMessage ); 
   }//if ( exceptionMessage != null )
    
  }//DatabaseQuery()

  /// <summary>Executes the query, and returns the first column of the first row in the resultset returned by the query. Extra columns or rows are ignored.</summary>
  /// <param name="databaseConnectionString">The database connection string, "Provider=SQLOLEDB;Data Source=localhost;Initial Catalog=master;Integrated Security=SSPI;"</param>
  /// <param name="exceptionMessage">The exception message.</param>
  /// <param name="databaseReturnValue">The database return Value.</param>
  /// <param name="selectColumn">The select column.</param>
  /// <param name="selectSource">The select source.</param>
  /// <param name="whereColumn">The where column.</param>
  /// <param name="whereValue">The where value.</param>
  /// <code>
  ///  <example>
  ///   string      databaseConnectionString = "Provider=SQLOLEDB;Data Source=localhost;Initial Catalog=master;Integrated Security=SSPI;";
  ///   string      exceptionMessage         = null;
  ///   string      commandText              = "master..xp_msver";
  ///   CommandType commandType              = "CommandType.StoredProcedure";  
  ///   DataSet     dataSet                  = null;
  ///   UtilityDatabase.DatabaseQuery
  ///   ( 
  ///        databaseConnectionString, 
  ///    ref exceptionMessage, 
  ///        dataSet, 
  ///        commandText, 
  ///        CommandType.StoredProcedure 
  ///   );
  ///  </example>  
  /// </code>  
  public static void DatabaseQuerySQLSelectTop1
  (
   ref String      databaseConnectionString,
   ref String      exceptionMessage,
   ref object      databaseReturnValue,
   ref String      selectColumn,
   ref String      selectSource,
   ref String      whereColumn,
   ref String      whereValue
  )
  {

   StringBuilder    sb                  = null;

   OleDbConnection  oleDbConnection     = null;
   OleDbCommand     oleDbCommand        = null;
   OleDbDataReader  oleDbDataReader     = null;

   exceptionMessage                     = null;

   sb = new StringBuilder();

   sb.AppendFormat
   ( 
    SQLSelectTop1,
    selectColumn,
    selectSource,
    whereColumn,
    whereValue
   );

   sb.Append("SELECT SequenceOrderId FROM TheWord WHERE SequenceOrderId = 530");

   #if (DEBUG)
    System.Console.WriteLine
    (
     "SQLSelectTop1: {0}", 
     sb
    );
   #endif

   try
   {

    oleDbConnection = UtilityDatabase.DatabaseConnectionInitialize
    (
     databaseConnectionString,
     ref exceptionMessage
    );

    if ( oleDbConnection == null )
    {
     return;
    }

    oleDbCommand =  new OleDbCommand( sb.ToString(), oleDbConnection);

    oleDbCommand.CommandType = CommandType.Text;

    /*
    oleDbDataReader = oleDbCommand.ExecuteReader();
    while( oleDbDataReader.Read() )
    {
     databaseReturnValue = oleDbDataReader[0];
    }//while( oleDbDataReader.Read() )
    */

    databaseReturnValue = oleDbCommand.ExecuteScalar();

    UtilityDebug.Write( String.Format( "DatabaseReturnValue: {0}", databaseReturnValue ) ); 

    if ( oleDbDataReader != null )
    {
     oleDbDataReader.Close();
    } 
    UtilityDatabase.DatabaseConnectionHouseKeeping
    (
         oleDbConnection,
     ref exceptionMessage
    );
   
   }//try
   catch (OleDbException exception)
   {
    //exceptionMessage = DisplayOleDbErrorCollection( exception );
    exceptionMessage   = UtilityEventLog.WriteEntryOleDbErrorCollection( exception );
    exceptionMessage   = String.Format("OLEDbException: {0}", exceptionMessage );
   }//catch (OleDbException exception)
   catch (Exception exception)
   {
    exceptionMessage   = String.Format("Exception: {0}", exception.Message );
   }//catch (Exception exception)
   UtilityDebug.Write( exceptionMessage ); 
   
  }//public static void DatabaseQuerySQLSelectTop1()

  /// <summary>DatabaseUpdate</summary>
  /// <param name="databaseConnectionString">The database connection string.</param>  
  /// <param name="exceptionMessage">The exception message.</param>    
  /// <param name="sender">The message source.</param>  
  public static void DatabaseUpdate
  (
       string databaseConnectionString,
   ref string exceptionMessage,
   ref object sender
  )
  {
  
   StringBuilder    sqlStatement       = null;
   StringBuilder    sqlStatementWhere  = null;
   StringBuilder    sqlStatementInsert = null;
   StringBuilder    sqlStatementUpdate = null;     

   DataTable        dataTable          = null;
   OleDbConnection  oleDbConnection    = null;
 
   oleDbConnection = DatabaseConnectionInitialize
   (
        databaseConnectionString,
    ref exceptionMessage
   );     

   InformationSchemaTableQuery
   (
        databaseConnectionString,
    ref exceptionMessage,
    ref sender,
    ref sqlStatement,        
    ref sqlStatementWhere,
    ref sqlStatementInsert,
    ref sqlStatementUpdate,      
    ref dataTable
   );
   
  }//public static void DatabaseUpdate( object sender, string SQLSelectStatement ){}

  /// <summary>DataReaderColumnNameValue().</summary>
  public static void DataReaderColumnNameValue
  (
   ref IDataReader  iDataReader,
   ref ArrayList    attributeName,
   ref ArrayList    attributeValue
  )
  {
   String  columnName   =  null;
   object  columnValue  =  null;
   
   attributeName   =  new ArrayList();
   attributeValue  =  new ArrayList();
   
   for ( int dataColumnIndex = 0; dataColumnIndex < iDataReader.FieldCount; dataColumnIndex++ )
   {
    columnName   =  iDataReader.GetName( dataColumnIndex );
    columnValue  =  iDataReader[ dataColumnIndex ];

    //UtilityDebug.Write(String.Format("iDataReader[{0}]: {1} = {2}", dataColumnIndex, columnName, columnValue));
    attributeName.Add( columnName );
    attributeValue.Add( columnValue );
    
   }//for ( int dataColumnIndex = 0; dataColumnIndex < FieldCount; dataColumnIndex++ )
   
  }//public static void DataReaderColumnNameValue()

  /// <summary>DataSetColumn</summary>
  public static void DataSetColumn
  (
   ref DataSet  dataSet,
   ref string[] columnName,
   ref string   exceptionMessage
  )
  {
   HttpContext           httpContext           =  HttpContext.Current;
   DataColumn            dataColumn            =  null;
   DataColumnCollection  dataColumnCollection  =  null;
   try
   {
    foreach ( DataTable dataTable in dataSet.Tables )
    {
   	 dataColumnCollection = dataTable.Columns;
   	 foreach ( string columnNameCurrent in columnName )
   	 {
      //if ( dataColumnCollection.IndexOf( columnNameCurrent ) < 0 )
      if ( dataColumnCollection.Contains( columnNameCurrent ) == false )
      {
       dataColumn = dataTable.Columns.Add( columnNameCurrent );
       //dataColumn = dataSet.Tables[dataTable.TableName].Columns.Add( columnNameCurrent );
       //httpContext.Response.Write( dataColumn.ColumnName );
      }//if ( dataColumnCollection.Contains( columnNameCurrent ) == false )
     }//foreach ( string columnNameCurrent in columnName )
    }//foreach ( DataTable dataTable in dataSet.Tables )
   }//try
   catch ( Exception exception )
   {
   	exceptionMessage = "Exception: " + exception.Message;
   }
   if ( exceptionMessage != null )
   {
    System.Console.WriteLine( exceptionMessage );   	
   }
  }//public static void DataSetColumn

  ///<Summary>DataSetFill</Summary>
  public static void DataSetFill
  (
   ref Hashtable  hashtable,
   ref DataSet    dataSet
  )
  {
   DataColumn             dataColumnKey          =  new DataColumn( "Key",   System.Type.GetType("System.String") );
   DataColumn             dataColumnValue        =  new DataColumn( "Value", System.Type.GetType("System.String") );
   DataRow                dataRow                =  null;
   DataTable              dataTable              =  new DataTable();
   IDictionaryEnumerator  iDictionaryEnumerator  =  null;
   dataSet = new DataSet();
   
   dataTable.Columns.Add( dataColumnKey );
   dataTable.Columns.Add( dataColumnValue );
   
   dataSet.Tables.Add( dataTable );
   
   iDictionaryEnumerator  =  hashtable.GetEnumerator();
  
   while (  iDictionaryEnumerator.MoveNext() )
   {
    dataRow = dataTable.NewRow();
    dataRow["Key"]    = iDictionaryEnumerator.Key;
    dataRow["Value"]  = iDictionaryEnumerator.Value;
    dataTable.Rows.Add( dataRow );
   }//while (  iDictionaryEnumerator.MoveNext() )
  }//DataSetFill()
  	
  /// <summary>DataSetTableRowColumn.</summary>
  /// <param name="dataSet">The dataset.</param>
  /// <param name="table">The table.</param>
  /// <param name="row">The row.</param>
  /// <param name="column">The column.</param>  
  public static object DataSetTableRowColumn
  (
   DataSet dataSet,
   string  table,
   int     row,
   string  column
  )
  {
   return ( dataSet.Tables[table].Rows[row][column] );	
  }//public static void DataSetTableRowColumn  	

  /// <summary>DataSetTableRowColumn.</summary>
  /// <param name="dataSet">The dataset.</param>
  /// <param name="table">The table.</param>
  /// <param name="row">The row.</param>
  /// <param name="column">The column.</param>
  /// <param name="value">The value.</param>  
  public static void DataSetTableRowColumn
  (
   DataSet dataSet,
   string  table,
   int     row,
   string  column,
   object  value
  )
  {
   dataSet.Tables[table].Rows[row][column] = value;
  }//public static void DataSetTableRowColumn  	

  /// <summary>DataSetTableColumnContains.</summary>
  /// <param name="dataSet">The dataset.</param>
  /// <param name="tableName">The name of the table.</param>
  /// <param name="columnName">The name of the column.</param>  
  public static bool DataSetTableColumnContains
  (
   DataSet dataSet,
   string  tableName,
   string  columnName
  )
  {
   #if (DEBUG)
    System.Console.WriteLine
    (
     "Table Name: {0} | Column Name: {1}", 
     tableName,
     columnName
    );      
   #endif
   return ( dataSet.Tables[tableName].Columns.Contains( columnName ) );	
  }//public static bool DataSetTableColumnContains

  /// <summary>DataSetTableColumnAdd.</summary>
  /// <param name="dataSet">The dataset.</param>
  /// <param name="table">The table.</param>
  /// <param name="column">The column.</param>  
  public static DataColumn DataSetTableColumnAdd
  (
   DataSet dataSet,
   string  table,
   string  column
  )
  {
   return ( dataSet.Tables[table].Columns.Add( column ) );	
  }//public static DataColumn DataSetTableColumnAdd

  /// <summary>DataSetTableColumnIndex.</summary>
  /// <param name="dataSet">The dataSet.</param>
  /// <param name="tableName">The table name.</param>
  /// <param name="columnName">The column name.</param>
  public static int DataSetTableColumnIndex
  (
   DataSet dataSet,
   string  tableName,
   string  columnName
  )
  {
   #if (DEBUG)
    System.Console.WriteLine
    (
     "Table Name: {0} | Column Name: {1}", 
     tableName,
     columnName
    );      
   #endif
   return ( dataSet.Tables[tableName].Columns.IndexOf( columnName ) );	
  }//public static int DataSetTableColumnIndex

  /// <summary>DataSetTableColumnVisible.</summary>
  /// <param name="dataGrid">The dataGrid.</param>
  /// <param name="columnName">The column name.</param>
  /// <param name="visible">visible.</param>  
  public static void DataSetTableColumnVisible
  (
   System.Web.UI.WebControls.DataGrid  dataGrid,
   string                              columnName,
   Boolean                             visible
  )
  {
   int  dataGridColumnIndex  =  -1;
   dataGridColumnIndex       =  DataGridColumnIndex( dataGrid, columnName );
   dataGrid.Columns[dataGridColumnIndex].Visible = visible;
  }//public static void DataSetTableColumnVisible

  /// <summary>DataSetTableColumnVisible.</summary>
  /// <param name="dataGrid">The dataGrid.</param>
  /// <param name="columnIndex">The column index.</param>
  /// <param name="visible">visible.</param>  
  public static void DataSetTableColumnVisible
  (
   System.Web.UI.WebControls.DataGrid  dataGrid,
   int                                 columnIndex,
   Boolean                             visible
  )
  {
   dataGrid.Columns[columnIndex].Visible = visible;
  }//public static void DataSetTableColumnVisible

  /// <summary>DataTableColumnIndex.</summary>
  /// <param name="dataTable">The dataTable.</param>
  /// <param name="columnName">The column name.</param>
  public static int DataTableColumnIndex
  (
   DataTable dataTable,
   string    columnName
  )
  {
   #if (DEBUG)
    System.Console.WriteLine
    (
     "Table Name: {0} | Column Name: {1}", 
     dataTable,
     columnName
    );      
   #endif
   return ( dataTable.Columns.IndexOf( columnName ) );
  }//public static int DataTableColumnIndex()

  /// <summary>DataTableColumnIndex.</summary>
  /// <param name="dataGrid">The dataTable.</param>
  /// <param name="columnName">The column name.</param>
  public static int DataGridColumnIndex
  (
   System.Web.UI.WebControls.DataGrid  dataGrid,
   string                              columnName
  )
  {

   int                                     dataGridColumnCount       =  -1;
   int                                     dataGridColumnIndex       =  -1;
   System.Web.UI.WebControls.BoundColumn   boundColumn               =  null;
   DataGridColumnCollection                dataGridColumnCollection  =  null;   
   

   #if (DEBUG)
    System.Console.WriteLine
    (
     "DataGrid Name: {0} | Column Name: {1}", 
     dataGrid.ID,
     columnName
    );      
   #endif

   dataGridColumnCollection   =  dataGrid.Columns;
   foreach ( DataGridColumn  dataGridColumn  in  dataGridColumnCollection )
   {
    ++dataGridColumnCount;
   	if ( UtilityClass.FullName( dataGridColumn ) == "System.Web.UI.WebControls.BoundColumn" )
   	{ 
   	 boundColumn = ( System.Web.UI.WebControls.BoundColumn )  dataGridColumn;
   	 if ( boundColumn.DataField == columnName )
     {
   	  dataGridColumnIndex = dataGridColumnCount;
      break;   	 	
     }//if ( dataGridColumn.DataField == columnName )
    }//if ( UtilityClass.FullName( dataGridColumn ) == "System.Web.UI.WebControls.BoundColumn" ) 
   }//foreach ( DataGridColumn  dataGridColumn  in  dataGridColumnCollection )	
   return ( dataGridColumnIndex );
  }//public static int DataGridColumnIndex()

  /// <summary>Create DataSet with table and column names.</summary>
  public static void DataSetTableColumn
  (
   ref DataSet   dataSet,
   ref string    exceptionMessage,
   ref string    tableName,
   ref ArrayList columnName
  )     
  {
   Boolean    primaryKeyFlag    = false;
   string     columnNameCurrent = null;
   DataColumn dataColumn        = null;
   DataColumn dataColumnPrimary = null;

   HttpContext httpContextCurrent = null; 
   httpContextCurrent             = HttpContext.Current; 
   
   dataSet = new DataSet( tableName );
   dataSet.Tables.Add(new DataTable( tableName ));
   foreach ( object objectCurrent in columnName )
   {
    columnNameCurrent = objectCurrent.ToString();
    if 
    ( 
     String.Compare( columnNameCurrent, "Dated", true ) == 0 
    )
    { 
     dataColumn = new DataColumn( columnNameCurrent, System.Type.GetType("System.DateTime") );
     dataColumn.DefaultValue = DateTime.Today; 
    }
    else
    {
     dataColumn = new DataColumn(columnNameCurrent, System.Type.GetType("System.String"));
    }
    if ( primaryKeyFlag == false )
    {
     primaryKeyFlag = true;
     dataColumn.DefaultValue = "";
     dataColumnPrimary = dataColumn;
    }
    dataSet.Tables[tableName].Columns.Add( dataColumn );
   }//foreach ( object columnNameColumn in columnName )
   dataSet.Tables[0].PrimaryKey = new DataColumn[] { dataColumnPrimary };
  }//public static void DataSetTableColumn()

  /// <summary>Create DataSet with table and column names.</summary>
  public static void DataSetTableColumn
  (
   ref string    DatabaseSQLSelect,
   ref DataSet   dataSet,
   ref string    exceptionMessage,
   ref string    tableName,
   ref ArrayList columnName
  )     
  {
   TableNameColumn
   (
    ref DatabaseSQLSelect,
    ref exceptionMessage,
    ref tableName,
    ref columnName
   );     
   DataSetTableColumn
   (
    ref dataSet,
    ref exceptionMessage,
    ref tableName,
    ref columnName
   );
  }//public static void DataSetTableColumn()

  /// <summary>DataSetRowAdd().</summary>
  public static void DataSetRowAdd
  (
   ref DataSet  dataSet,
   ref String   exceptionMessage,
   ref int      dataRowCount
  ) 	
  {
   DataRow   dataRow    =  null;
   DataTable dataTable  =  null;
   
   try
   {
    dataTable = dataSet.Tables[0];
    dataRow   =  dataTable.NewRow();
    dataTable.Rows.Add( dataRow );
    dataRowCount = dataTable.Rows.Count;
   }//try
   catch ( Exception exception )
   {
    exceptionMessage = exception.Message;
   }//catch	
   
  }//public static void DataSetRowAdd()

  /// <summary>Create DataSet with table and column names.</summary>
  public static void DataSetTablePrimaryKey
  (
   ref DataSet               dataSet,
   ref string                exceptionMessage,
   ref DataTableCollection   dataTableCollection,
   ref DataColumn[][]        dataColumnPrimaryKey,
   ref string[]              primaryKey
  )
  {
   int         dataTableTotal     = -1;
   HttpContext httpContextCurrent = null; 

   dataTableCollection  =  dataSet.Tables;
   dataTableTotal       =  dataSet.Tables.Count;
   primaryKey           =  new String[ dataTableTotal ];
   dataColumnPrimaryKey =  new DataColumn[ dataTableTotal ][];

   httpContextCurrent   =  HttpContext.Current; 

   try
   {
    for 
    ( 
     int dataTableCurrent = 0;
     dataTableCurrent < dataTableTotal;
     ++dataTableCurrent
    )
    {
     dataColumnPrimaryKey[dataTableCurrent] = dataSet.Tables[dataTableCurrent].PrimaryKey;
     primaryKey[dataTableCurrent] = "";

     for 
     ( 
      int dataColumnCount = 0;
      dataColumnCount < dataTableTotal; 
      ++ dataColumnCount
     )
     {
      if ( primaryKey[dataTableCurrent] != "" )
      {
       primaryKey[dataTableCurrent] += ", ";
      }
      primaryKey[dataTableCurrent] += dataColumnPrimaryKey[dataTableCurrent][dataColumnCount];
     }
    }//for ( int dataColumnCount = 0; dataColumnCount < dataTableTotal; ++ dataColumnCount )
   }//try
   catch( Exception exception )
   {
    exceptionMessage = "ExceptionMessage: " + exception.Message;
   }//catch( Exception exception )
    
   UtilityDebug.Write( exceptionMessage );
    
  }//public static void DataSetTablePrimaryKey     

  /// <summary>Gets a collection of one or more OleDbError objects that give detailed information about exceptions generated by the .NET Framework Data Provider for OLE DB.</summary>
  /// <code>
  ///  <example>
  ///   string          databaseConnectionString = "Provider=SQLOLEDB;Data Source=localhost;Initial Catalog=WordEngineering;Integrated Security=SSPI;";
  ///   string          exceptionMessage         = null;
  ///   OleDbConnection oleDbConnection          = null;
  ///   try
  ///   {
  ///    oleDbConnection = new OleDbConnection(databaseConnectionString);
  ///    oleDbConnection.Open();
  ///   }//try
  ///   catch (OleDbException exception)
  ///   {
  ///    exceptionMessage = DisplayOleDbErrorCollection( exception );
  ///    System.Console.WriteLine("OLEDbException: {0}", exceptionMessage);
  ///   }
  ///  </example>  
  /// </code>  
  public static string DisplayOleDbErrorCollection
  (
   OleDbException exception
  ) 
  {
   StringBuilder stringBuilderMessage = null;
   stringBuilderMessage = new StringBuilder();
   for (int i=0; i < exception.Errors.Count; i++)
   {
    stringBuilderMessage.Append("Index #: ");
    stringBuilderMessage.Append(i);
    stringBuilderMessage.Append(".\n");
    stringBuilderMessage.Append("Message: ");
    stringBuilderMessage.Append(exception.Errors[i].Message);
    stringBuilderMessage.Append("\n");
    stringBuilderMessage.Append("Native: ");
    stringBuilderMessage.Append(exception.Errors[i].NativeError.ToString());
    stringBuilderMessage.Append(".\n");
    stringBuilderMessage.Append("Source: ");
    stringBuilderMessage.Append(exception.Errors[i].Source);
    stringBuilderMessage.Append(".\n");
    stringBuilderMessage.Append("SQLState: ");
    stringBuilderMessage.Append(exception.Errors[i].SQLState);
    stringBuilderMessage.Append(".\n");
   }//for (int i=0; i < exception.Errors.Count; i++)
   return (stringBuilderMessage.ToString());
  }//DisplayOleDbErrorCollection(OleDbException exception) 

  /// <summary>Executes the non query statement.</summary>
  public static void ExecuteNonQuery
  (
       string       databaseConnectionString,
       string       commandText,
   ref string       exceptionMessage
  )
  {
   OleDbConnection  oleDbConnection  =  null;
   OleDbCommand	    oleDbCommand     =  null;

   exceptionMessage = null;
       
   oleDbConnection = UtilityDatabase.DatabaseConnectionInitialize
   (
    databaseConnectionString,
    ref exceptionMessage
   );

   if ( oleDbConnection == null || exceptionMessage != null )
   {
    return;
   }if ( oleDbConnection == null || exceptionMessage != null )
   
   try
   {
    oleDbCommand = new OleDbCommand( commandText, oleDbConnection );
    oleDbCommand.ExecuteNonQuery();
   }//try
   catch (OleDbException exception)
   {
    //exceptionMessage = DisplayOleDbErrorCollection( exception );
    exceptionMessage   = UtilityEventLog.WriteEntryOleDbErrorCollection( exception );
    exceptionMessage   = String.Format("OLEDbException: {0}", exceptionMessage );
   }//catch (OleDbException exception)
   catch (Exception exception)
   {
    exceptionMessage   = String.Format("Exception: {0}", exception.Message );
   }//catch (Exception exception)
   UtilityDebug.Write( exceptionMessage ); 
  }//ExecuteNonQuery()

  /// <summary>Information Schema Table Query.</summary>
  /// <param name="databaseConnectionString">The database connection string.</param>
  /// <param name="exceptionMessage">The exception message.</param>
  /// <param name="sender">The message source.</param>
  /// <param name="sqlStatement">The SQL statement.</param>
  /// <param name="sqlStatementWhere">The SQL statement Clause - Where.</param>
  /// <param name="sqlStatementInsert">The SQL statement Clause - Insert.</param>
  /// <param name="sqlStatementUpdate">The SQL statement Clause - Update.</param>
  /// <param name="dataTable">The data table for the table's columns.</param>
  public static void InformationSchemaTableQuery
  (
       string        databaseConnectionString,
   ref string        exceptionMessage,
   ref object        sender,
   ref StringBuilder sqlStatement,
   ref StringBuilder sqlStatementWhere,
   ref StringBuilder sqlStatementInsert,
   ref StringBuilder sqlStatementUpdate,      
   ref DataTable     dataTable
  )
  {
   int                       columnOrdinalPosition          = -1;
   int                       columnCharacterMaximumLength   = -1;   
   int                       rowTotal                       = 0;
   
   string                    columnName                     = null;
   string                    columnConstraintType           = null;
   string                    columnDataType                 = null;
   string                    columnDefault                  = null;
   string                    columnIsNullable               = null;

   string                    fullName                       = null;
   string                    simpleName                     = null;
 
   IDataReader               iDataReader                    = null;
      
   StringBuilder             commandText                    = null;
   
   object                    objectOrdinalPosition          = null;
   object                    objectCharacterMaximumLength   = null;
   object                    objectConstraintType           = null;
   object                    objectDefault                  = null;

   Type                      typeSender                     = null;
  
   commandText        = new StringBuilder();
   sqlStatement       = new StringBuilder();
   sqlStatementWhere  = new StringBuilder();
   sqlStatementInsert = new StringBuilder();
   sqlStatementUpdate = new StringBuilder();      

   exceptionMessage   = null;

   fullName           = UtilityClass.FullName( sender );
   simpleName         = UtilityClass.SimpleName( sender );
   typeSender         = UtilityClass.GetType( sender );
   
   #if (DEBUG)
    System.Console.WriteLine("FullName: {0} | SimpleName: {1}", fullName, simpleName);
   #endif

   commandText.AppendFormat( InformationSchemaTable, InformationSchemaTableParameterTableName, simpleName ); 
      
   #if (DEBUG)
    System.Console.WriteLine("SQLInformationSchemaTableQuery SQL Statement: {0}", commandText );
   #endif

   DatabaseQuery
   (
        databaseConnectionString,
    ref exceptionMessage,
    ref iDataReader,
        commandText.ToString(),
        CommandType.Text
   );
    
   while ( iDataReader.Read() )
   {
    ++rowTotal;
    columnName                   = ( string ) iDataReader[InformationSchemaColumnColumnName];
    objectOrdinalPosition        = iDataReader[InformationSchemaColumnOrdinalPosition]; 
    objectDefault                = iDataReader[InformationSchemaColumnColumnDefault];     
    columnIsNullable             = ( string ) iDataReader[InformationSchemaColumnIsNullable];
    columnDataType               = ( string ) iDataReader[InformationSchemaColumnDataType];
    objectCharacterMaximumLength = iDataReader[InformationSchemaColumnCharacterMaximumLength];
    objectConstraintType         = iDataReader[InformationSchemaColumnConstraintType];

    if ( objectOrdinalPosition == DBNull.Value )
    {
     columnOrdinalPosition = -1;
    } 
    else
    { 
     columnOrdinalPosition = System.Convert.ToInt32( objectOrdinalPosition );
    } 

    if ( objectDefault == DBNull.Value )
    {
     columnDefault = null;
    } 
    else
    { 
     columnDefault = ( string ) objectDefault ;
    } 

    if ( objectCharacterMaximumLength == DBNull.Value )
    {
     columnCharacterMaximumLength = -1;
    } 
    else
    { 
     columnCharacterMaximumLength = System.Convert.ToInt32( objectCharacterMaximumLength ) ;
    } 

    if ( objectConstraintType == DBNull.Value )
    {
     columnConstraintType = null;
    } 
    else
    { 
     columnConstraintType = ( string ) objectConstraintType ;
    } 

    UtilityDebug.Write
    (
     String.Format
     (
      "Column Name: {0} | Ordinal Position: {1} | Default: {2} | IsNullable: {3} | DataType: {4} | Character Maximum Length: {5} | ConstraintType: {6}",
      columnName,
      columnOrdinalPosition,
      columnDefault,
      columnIsNullable,
      columnDataType,
      columnCharacterMaximumLength,
      columnConstraintType
     ) 
    ); 
   }//while
  }//public static void InformationSchemaTableQuery   

  /// <summary>NameValue().</summary>
  public static void NameValue
  (
       String         norikoYoshidaName,
       String[]       norikoYoshidaValue,
       String         norikoYoshidaCompare,
   ref StringBuilder  norikoYoshidaNameValue
  )
  {      
   norikoYoshidaNameValue = new StringBuilder();
   
   if ( norikoYoshidaValue != null && norikoYoshidaValue.Length > 0 )
   {
    for ( int valueCount = 0; valueCount < norikoYoshidaValue.Length; ++valueCount )
    {
     norikoYoshidaNameValue.AppendFormat
     (
      NorikoYoshidaNameValue,
      norikoYoshidaName,
      norikoYoshidaCompare,
      norikoYoshidaValue[valueCount]
     );
    
     if ( valueCount < norikoYoshidaValue.Length - 1 )
     {
      norikoYoshidaNameValue.Append(" OR ");
     }//if ( valueCount < norikoYoshidaValue.Length - 1 )
     
    }//for ( int valueCount = 0; valueCount < norikoYoshidaValue.Length; ++valueCount )
   }//if ( norikoYoshidaValue != null && norikoYoshidaValue.Table.Length > 0 )
  }//public static void NameValue()

  /// <summary>The information message event occurs when a data source sends warnings and information messages.</summary>
  /// <param args="sender">The data source.</param>    
  /// <param args="args">A collection of messages from the data source.</param>    
  /// <code>
  ///  <example>
  /// <code>
  ///  <example>
  ///   string databaseConnectionString = "Provider=SQLOLEDB;Data Source=localhost;Initial Catalog=WordEngineering;Integrated Security=SSPI;";
  ///   OleDbConnection oleDbConnection = null;
  ///   oleDbConnection = new OleDbConnection(databaseConnectionString);
  ///   oleDbConnection.StateChange += new StateChangeEventHandler(OnOleDbStateChange);
  ///   oleDbConnection.Open();
  ///   oleDbConnection.Close();
  ///   }//try
  ///   catch (OleDbException exception)
  ///   {
  ///    System.Console.WriteLine("OLEDbException: {0}", exception.Message);
  ///   }
  ///   catch (Exception exception)
  ///   {
  ///    System.Console.WriteLine("Exception: {0}", exception.Message);
  ///   }
  ///  </example>  
  /// </code>  
  ///  </example>  
  /// </code>  
  protected static void OleDbInfoMessage
  (
   object                    sender,
   OleDbInfoMessageEventArgs args
  )
  { 
   foreach (OleDbError oleDbError in args.Errors)
   {
    UtilityDebug.Write
    (
     String.Format
     (
      "The {0} has received a SQLState {1} error number {2}:\n{3}",
      oleDbError.Source,
      oleDbError.SQLState,
      oleDbError.NativeError,
      oleDbError.Message
     )
    ); ;
   }//foreach (OleDbError oleDbError in args.Errors)	
  }//protected static void OnInfoMessage 	

  /// <summary>The StateChange event occurs when the state of a Connection changes.</summary>
  /// <param name="sender">The data source.</param>  
  /// <param name="args">The current and original state.</param>    
  /// <code>
  ///  <example>
  ///   string databaseConnectionString = "Provider=SQLOLEDB;Data Source=localhost;Initial Catalog=WordEngineering;Integrated Security=SSPI;";
  ///   OleDbConnection oleDbConnection = null;
  ///   oleDbConnection = new OleDbConnection(databaseConnectionString);
  ///   oleDbConnection.InfoMessage += new OleDbInfoMessageEventHandler(OleDbInfoMessage);
  ///   oleDbConnection.Open();
  ///   oleDbConnection.Close();
  ///   }//try
  ///   catch (OleDbException exception)
  ///   {
  ///    System.Console.WriteLine("OLEDbException: {0}", exception.Message);
  ///   }
  ///   catch (Exception exception)
  ///   {
  ///    System.Console.WriteLine("Exception: {0}", exception.Message);
  ///   }
  ///  </example>  
  /// </code>  
  protected static void OnOleDbStateChange
  (
   object               sender,
   StateChangeEventArgs args
  )
  { 
    System.Console.WriteLine("The current Connection state has changed from {0} to {1}.", args.OriginalState, args.CurrentState);
  }//protected static void OnOleDbStateChange

  /// <summary>PopulateDatabase.</summary>
  public static void PopulateDatabase
  (
   ref String       filenameConfigurationXml,
   ref XmlNodeList  xmlNodeListDatabase,
   ref String[]     databaseName,
   ref String       exceptionMessage
  )
  {

   HttpContext             httpContext                     =  HttpContext.Current;
   int                     databaseNameIndex               =  -1;
   XmlAttributeCollection  xmlAttributeCollectionDatabase  =  null;
   XmlAttribute            xmlAttributeDatabaseName        =  null;   

   UtilityXml.SelectNodes
   (
        filenameConfigurationXml,
    ref exceptionMessage,
        XPathDatabase,
    ref xmlNodeListDatabase
   );
   
   databaseName = new String[ xmlNodeListDatabase.Count ];
   
   foreach ( XmlNode xmlNodeDatabase in xmlNodeListDatabase )
   {
    xmlAttributeCollectionDatabase     =  xmlNodeDatabase.Attributes;
   	xmlAttributeDatabaseName           =  xmlAttributeCollectionDatabase["name"];
   	
   	if ( xmlAttributeDatabaseName == null )
   	{
     continue;
    }//if ( xmlAttributeDatabaseName == null )
        		
    ++databaseNameIndex;
   	databaseName[ databaseNameIndex ]  =  xmlAttributeDatabaseName.Value;
   	
    UtilityDebug.Write
    ( 
     String.Format
     (
      "Database Name: {0}", 
      databaseName[ databaseNameIndex ]
     ) 
    );

   }//foreach ( XmlNodeList xmlNodeDatabase in xmlNodeListDatabase ) 
  }//public static void PopulateDatabase()
  
  /// <summary>PopulateDatabaseTable.</summary>
  public static void PopulateDatabaseTable
  (
   ref String       filenameConfigurationXml,
   ref XmlNodeList  xmlNodeListDatabase,
   ref String[]     databaseName,
   ref ArrayList    arrayListTableName,
   ref String       exceptionMessage
  )
  {

   String        databaseConnectionString       =  null;
   String        databaseOwnerTable             =  null;
   String        xPathDatabaseConnectionString  =  null;
   DataSet       dataSetTable                   =  null;
   HttpContext   httpContext                    =  HttpContext.Current;
      
   if ( arrayListTableName == null )
   {
    arrayListTableName = new ArrayList();
   } 
   
   if ( databaseName == null || databaseName.Length == 0 )
   {
    PopulateDatabase
    (
     ref filenameConfigurationXml,
     ref xmlNodeListDatabase,
     ref databaseName,
     ref exceptionMessage
    );
   }//if ( databaseName == null || databaseName.Length == 0 )
   
   foreach ( String databaseNameCurrent in databaseName )
   {

    if ( databaseNameCurrent.Trim() == String.Empty )
    {
     continue;   	 	
    }//if ( databaseNameCurrent.Trim() == String.Empty )   	 	

   	xPathDatabaseConnectionString  =  String.Format( XPathConnectionStringDatabaseFormat, databaseNameCurrent);
  	
    UtilityXml.XmlDocumentNodeInnerText
    (
         filenameConfigurationXml,
     ref exceptionMessage,         
         xPathDatabaseConnectionString,
     ref databaseConnectionString
    );

    UtilityDebug.Write
    ( 
     String.Format
     (
      "Connection String Database: {0} | {1} | {2}",
      databaseNameCurrent, 
      xPathDatabaseConnectionString,
      databaseConnectionString
     ) 
    );

    if ( databaseConnectionString == null )
    {
     continue;
    }//if ( databaseConnectionString == null )     	

    DatabaseQuery
    (
         databaseConnectionString,
     ref exceptionMessage,
     ref dataSetTable,
         InformationSchemaTableView,
         CommandType.Text
    );
    
    foreach( DataTable dataTable in dataSetTable.Tables )
    {
     foreach( DataRow dataRow in dataTable.Rows )
     {
      databaseOwnerTable = String.Format
      (
       DatabaseOwnerTableFormat,
       (String) dataRow["TABLE_CATALOG"],
       (String) dataRow["TABLE_SCHEMA"],
       (String) dataRow["TABLE_NAME"]    
      );
      
      arrayListTableName.Add( databaseOwnerTable ); 
      
      UtilityDebug.Write
      ( 
       String.Format
       (
        "TableName: {0}",
        databaseOwnerTable
       ) 
      );

     }//foreach( DataRow dataRow in dataTable.Rows )
    }//foreach( DataTable dataTable in dataSetTable.Tables )
   }//foreach ( xmlNode xmlNodeDatabase in xmlNodeListDatabase )
  }//public static void PopulateDatabaseTable()  	 

  /// <summary>PrintValues().</summary>
  /// <param name="dataSet">The dataSet.</param>
  public static void PrintValues
  (
   DataSet dataSet
  )
  {
   HttpContext   httpContext                = HttpContext.Current;
   StringBuilder sb                         = null;

   foreach(DataTable dataTable in dataSet.Tables)
   {
    if ( httpContext == null )
    {
     System.Console.WriteLine("TableName: " + dataTable.TableName);
    } 	
    else
    {
     httpContext.Response.Write("TableName: " + dataTable.TableName);
    } 	
    foreach(DataRow dataRow in dataTable.Rows)
    {
     sb = new StringBuilder();
     foreach(DataColumn dataColumn in dataTable.Columns)
     {
      sb.Append(dataRow[dataColumn] + "|");	
     }////foreach(DataColumn dataColumn in dataTable.Columns) 
     if ( httpContext == null )
     {
      System.Console.WriteLine(sb);
     } 	
     else
     {
      httpContext.Response.Write(sb);
     } 	
    }//foreach(DataRow dataRow in dataTable.Rows)
   }//foreach(DataTable dataTable in dataSet.Tables)
  }//public void PrintValues( DataSet dataSet )

  /// <summary>SqlDataSourceEnumeratorStub</summary>
  /// <remarks>José Alarcón JASoft.org</remarks>
  public static void SqlDataSourceEnumeratorStub()
  {
   SqlDataSourceEnumerator  Descubridor_de_sql  =  SqlDataSourceEnumerator.Instance;
   DataTable sqls = Descubridor_de_sql.GetDataSources();
   foreach ( DataRow servSQL in sqls.Rows )
   {
    System.Console.WriteLine("///////////////////////////////////////////////////////////");
    System.Console.WriteLine("Nombre del servidor:" + servSQL["ServerName"]);
    System.Console.WriteLine("Nombre de la instancia:" + servSQL["InstanceName"]);
    System.Console.WriteLine("Versión:" + servSQL["Version"]);
    System.Console.WriteLine("¿Está en cluster?:" + servSQL["IsClustered"]);
   }
  }  	
  
  /// <summary>SQLInsertUpdate().</summary>
  public static void SQLInsertUpdate
  (
   ref String  databaseConnectionString,
   ref DataSet dataSet,
   ref String  exceptionMessage 
  )
  {

   bool             dataColumnValueSet         = false;
   bool             identityInsertFlag         = false;
   bool             sequenceOrderIdFlag        = false;
   
   DateTime         dateTime;
   
   String           dataColumnName             = null;
   String           dataRowPrimaryColumnName   = null;
   String           dataRowColumnValue         = null;

   StringBuilder    sbSQL                      = null;
   StringBuilder    sbIdentityInsertOff        = null;   
   StringBuilder    sbIdentityInsertOffCurrent = null;
   StringBuilder    sbIdentityInsertOn         = null;
   StringBuilder    sbIdentityInsertOnCurrent  = null;     
   StringBuilder    sbInsertColumnName         = null;
   StringBuilder    sbInsertColumnValue        = null;
   StringBuilder    sbPrimaryColumnValue       = null;   
   StringBuilder    sbUpdateColumnNameValue    = null;

   OleDbConnection  oleDbConnection            = null;
   
   oleDbConnection = UtilityDatabase.DatabaseConnectionInitialize
   ( 
        databaseConnectionString,
    ref exceptionMessage 
   );

   HttpContext   httpContext                = HttpContext.Current;
   
   UtilityDebug.Write(String.Format("Database Name: {0}", dataSet.DataSetName));
   
   sbInsertColumnName = new StringBuilder();
   
   foreach(DataTable dataTable in dataSet.Tables)
   {
    UtilityDebug.Write(String.Format("Table Name: {0}", dataTable.TableName));

    sbIdentityInsertOn  = new StringBuilder();
    sbIdentityInsertOff = new StringBuilder();
    
    sbIdentityInsertOff.AppendFormat( SQLPatternIdentityInsertOff, dataSet.DataSetName + ".." + dataTable.TableName);
    sbIdentityInsertOn.AppendFormat( SQLPatternIdentityInsertOn, dataSet.DataSetName + ".." + dataTable.TableName);
    
    sbIdentityInsertOff.Append(';');
    sbIdentityInsertOn.Append(';');    

    foreach(DataRow dataRow in dataTable.Rows)
    {

     dataColumnValueSet         =  false;
     identityInsertFlag         =  false;
     
     dataRowPrimaryColumnName   =  dataTable.Columns[0].ColumnName;

     sbSQL                      =  new StringBuilder();
     sbInsertColumnName         =  new StringBuilder(); 
     sbInsertColumnValue        =  new StringBuilder();
     sbIdentityInsertOffCurrent =  new StringBuilder();
     sbIdentityInsertOnCurrent  =  new StringBuilder();
     sbPrimaryColumnValue       =  new StringBuilder();
     sbUpdateColumnNameValue    =  new StringBuilder();

     sbPrimaryColumnValue.AppendFormat( SQLPatternColumnValue, dataRow[0] );
     
     for( int dataColumnCount = 0; dataColumnCount < dataTable.Columns.Count; ++dataColumnCount)
     {
      if ( dataRow[dataColumnCount] == null || dataRow[dataColumnCount] == DBNull.Value )
      {
       continue;
      }//if ( dataRow[dataColumnCount] == null )

      if ( dataColumnValueSet )
      {
       sbInsertColumnName.Append(',');
       sbInsertColumnValue.Append(',');

       if ( !sequenceOrderIdFlag )
       {
        sbUpdateColumnNameValue.Append(',');
       }

      }//if ( dataColumnValueSet )
      
      dataColumnValueSet = true;

      dataColumnName = dataTable.Columns[dataColumnCount].ColumnName;

      dataRowColumnValue = (String) dataRow[dataColumnCount];
      dataRowColumnValue = dataRowColumnValue.Trim();      

      UtilityDebug.Write(String.Format("dataRowColumnValue:      {0}", dataRowColumnValue));

      if ( String.Compare(dataColumnName, "sequenceOrderId", true) == 0 )
      {
       sequenceOrderIdFlag = true;

       if ( dataRowColumnValue != null && dataRowColumnValue != String.Empty )
       {
        identityInsertFlag = true;
       }//if ( dataRowColumnValue != null && dataRowColumnValue != String.Empty )
       
       sbIdentityInsertOnCurrent  = sbIdentityInsertOn;
       sbIdentityInsertOffCurrent = sbIdentityInsertOff;
       
      }//if ( String.Compare(dataColumnName, "sequenceOrderId", true) == 0 )
      else
      {
       sequenceOrderIdFlag = false;
      }    
      
      UtilityDebug.Write(String.Format("dataRowColumnValue:      {0}", dataRowColumnValue));
      
      /*
      UtilityRegularExpression.RegularExpressionPattern
      (
       ref dataRowColumnValue,
       ref matchFlag
      );
      */
      
      if ( dataColumnName.IndexOf("dated") >= 0 )
      {
       //dateTime           = DateTime.Parse( dataRowColumnValue );
       dateTime             = XmlConvert.ToDateTime( dataRowColumnValue );
       dataRowColumnValue   = dateTime.ToString();
      }
      else
      {
       dataRowColumnValue = dataRowColumnValue.Replace("'", "''");
      }

      dataRowColumnValue = "'" + dataRowColumnValue + "'";
       
      UtilityDebug.Write(String.Format("Column Name: {0}", dataColumnName));
      sbInsertColumnName.Append( dataTable.Columns[dataColumnCount] );
      sbInsertColumnValue.Append( dataRowColumnValue );

      if ( sequenceOrderIdFlag )
      {
       continue;
      }

      //UtilityDebug.Write(String.Format("dataColumnCount: {0} | dataColumnName: {1} | sequenceOrderIdFlag: {2}", dataColumnCount, dataColumnName, sequenceOrderIdFlag));

      sbUpdateColumnNameValue.Append( dataColumnName );
      sbUpdateColumnNameValue.Append( "= " );
      sbUpdateColumnNameValue.Append( dataRowColumnValue );

     }//for( int dataColumnCount = 0; dataColumnCount < dataTable.Columns.Count; ++dataColumnCount)

     UtilityDebug.Write(String.Format("sbInsertColumnName:      {0}", sbInsertColumnName));
     UtilityDebug.Write(String.Format("sbInsertColumnValue:     {0}", sbInsertColumnValue));
     UtilityDebug.Write(String.Format("sbUpdateColumnNameValue: {0}", sbUpdateColumnNameValue));

     sbSQL.AppendFormat
     (
      DatabaseTemplateUpdatePrimaryKey,
      sbIdentityInsertOnCurrent,
      dataRowPrimaryColumnName,
      dataSet.DataSetName + ".." + dataTable.TableName,
      sbPrimaryColumnValue,
      sbInsertColumnName, 
      sbInsertColumnValue,
      sbUpdateColumnNameValue,
      sbIdentityInsertOffCurrent
     );
       
     UtilityDebug.Write(String.Format("SQL: {0}", sbSQL));
     
     UtilityDatabase.DatabaseNonQuery
     ( 
          oleDbConnection,
      ref exceptionMessage,
          sbSQL.ToString()
     );
     
    }//foreach(DataRow dataRow in dataTable.Rows)
    
   }//foreach(DataTable dataTable in dataSet.Tables)
  }//public void SQLInsertUpdate( DataSet dataSet )

  /// <summary>SQLSelectParse().</summary>
  public static void SQLSelectParse
  (
       String     sqlStatement,
   ref ArrayList  unionIndex,
   ref ArrayList  sqlStatementUnion,
   ref ArrayList  databaseName,
   ref ArrayList  ownerName,   
   ref ArrayList  objectName,
   ref String     exceptionMessage
  )
  {
   int       sQLStatementKeywordIndexFrom           =  0;
   int       sQLStatementKeywordIndexFromSeparator  =  0;      
   int       sQLStatementKeywordIndexUnion          =  0;
   int       sQLStatementKeywordIndexUnionCurrent   =  0;
   int       sQLStatementIndexSpace                 =  0;
   
   int       sQLStatementLength                     =  sqlStatement.Length;
   
   String    databaseFromClauseBeyond               = null;
   String    databaseObjectName                     = null;
   String[]  databaseObjectNameArray                = null;
   String    sQLStatementSubset                     = null;
   String    sqlStatementUpper                      = null;
   
   databaseName                                 = new ArrayList();
   sqlStatementUnion                            = new ArrayList();
   objectName                                   = new ArrayList();   
   ownerName                                    = new ArrayList();
   unionIndex                                   = new ArrayList();   

   sqlStatementUpper = sqlStatement.ToUpper();

   while ( sQLStatementKeywordIndexUnion < sQLStatementLength )
   {
    sQLStatementKeywordIndexUnion = sqlStatementUpper.IndexOf
    ( 
     SQLStatementKeywordUnion, 
     sQLStatementKeywordIndexUnionCurrent
    );
    unionIndex.Add( sQLStatementKeywordIndexUnion );
    if ( sQLStatementKeywordIndexUnion <= -1 )
    {
     sQLStatementSubset = sqlStatement.Substring( sQLStatementKeywordIndexUnionCurrent );
    }
    else
    {
     sQLStatementSubset = sqlStatement.Substring( sQLStatementKeywordIndexUnionCurrent, sQLStatementKeywordIndexUnionCurrent - sQLStatementKeywordIndexUnion  );
    }    	
    sQLStatementSubset = sQLStatementSubset.Trim();
    sqlStatementUnion.Add( sQLStatementSubset );
    sQLStatementIndexSpace = sQLStatementSubset.IndexOf(' ');
    if ( sQLStatementIndexSpace < 0 )
    {
     databaseObjectName = sQLStatementSubset;     
    }//if ( sQLStatementIndexSpace < 0 )
    else
    {
     sQLStatementKeywordIndexFrom = sQLStatementSubset.IndexOf
     ( 
      SQLStatementKeywordFrom 
     );
     databaseFromClauseBeyond = sQLStatementSubset.Substring( sQLStatementKeywordIndexFrom + 6);
     databaseFromClauseBeyond = databaseFromClauseBeyond.Trim();
     sQLStatementKeywordIndexFromSeparator = databaseFromClauseBeyond.IndexOf(' ');
     if ( sQLStatementKeywordIndexFromSeparator <= -1 )
     {
      databaseObjectName = databaseFromClauseBeyond;
     }
     else
     {
      databaseObjectName = databaseFromClauseBeyond.Substring( 0, sQLStatementKeywordIndexFromSeparator );
     }    	
    }//if ( sQLStatementKeywordIndexFromSeparator <= -1 )
    databaseObjectNameArray = databaseObjectName.Split( DelimiterCharSplitDatabaseOwnerObject );
    switch ( databaseObjectNameArray.Length )
    {
     case 1:
      databaseName.Add( DefaultDatabase );
      ownerName.Add( DefaultOwner );
      objectName.Add( databaseObjectNameArray[0] );
      break;
     case 3: 
      databaseName.Add( databaseObjectNameArray[0] );     
      ownerName.Add( databaseObjectNameArray[1] );
      objectName.Add( databaseObjectNameArray[2] );
      break;
    }
    if ( sQLStatementKeywordIndexUnion == -1 )
    {
     break;
    }
    sQLStatementKeywordIndexUnionCurrent = sQLStatementKeywordIndexUnion;
   }// while ( sQLStatementKeywordUnionPosition < sQLStatementLength ) 
  }//public static void SQLSelectParse()  	

  /// <summary>Executes the query, and returns the first column of the first row in the resultset returned by the query. Extra columns or rows are ignored.</summary>
  /// <code>
  ///  <example>
  ///   string          databaseConnectionString = "Provider=SQLOLEDB;Data Source=localhost;Initial Catalog=WordEngineering;Integrated Security=SSPI;";
  ///   string          exceptionMessage         = null;
  ///   string          tableName                = "master..xp_msver";
  ///   object          commandReturn            = null;
  ///   commandReturn  = UtilityDatabase.TableIdentity( databaseConnectionString, ref exceptionMessage, tableName );
  ///   System.Console.WriteLine("Query: {0}\n{1}", tableName, commandReturn);
  ///  </example>  
  /// </code>  
  public static object TableIdentity
  (
       string       databaseConnectionString,
   ref string       exceptionMessage,
       string       tableName
  )     
  {
   object        databaseReturnValue = null;
   StringBuilder sb                  = null;
   sb = new StringBuilder();
   sb.AppendFormat( SQLPatternSelectIdentityTable, tableName );
   databaseReturnValue = DatabaseQuery
   (
        databaseConnectionString,
    ref exceptionMessage,       
        Convert.ToString( sb ),
        CommandType.Text
    );
    return ( databaseReturnValue );
  }//public static object TableIdentity  	

  /// <summary>Executes the query, and returns the first column of the first row in the resultset returned by the query. Extra columns or rows are ignored.</summary>
  /// <code>
  ///  <example>
  ///   int             tableIdentity            = -1;
  ///   String          databaseConnectionString = "Provider=SQLOLEDB;Data Source=localhost;Initial Catalog=WordEngineering;Integrated Security=SSPI;";
  ///   String          exceptionMessage         = null;
  ///   String          tableName                = "master..xp_msver";
  ///   object          commandReturn            = null;
  ///   commandReturn  = UtilityDatabase.TableIdentity( databaseConnectionString, ref exceptionMessage, tableName, ref tableIdentity );
  ///  </example>  
  /// </code>  
  public static void TableIdentity
  (
       String       databaseConnectionString,
   ref String       exceptionMessage,
       String       tableName,
   ref int          tableIdentity
  )
  {
   object        databaseReturnValue = null;
   StringBuilder sb                  = null;
   sb = new StringBuilder();
   sb.AppendFormat( SQLPatternSelectIdentityTable, tableName );

   #if ( DEBUG )
    System.Console.WriteLine("SQL: {0}", sb);
   #endif
   
   databaseReturnValue = DatabaseQuery
   (
        databaseConnectionString,
    ref exceptionMessage,       
        Convert.ToString( sb ),
        CommandType.Text
    );

    #if ( DEBUG )
     System.Console.WriteLine("databaseReturnValue: {0}", databaseReturnValue);
    #endif
    
    if ( databaseReturnValue == null || databaseReturnValue == DBNull.Value )
    {
     return;      	 
    }//if ( databaseReturnValue == null || databaseReturnValue == DBNull.Value )
    
    tableIdentity = System.Convert.ToInt32( databaseReturnValue );
  }//public static void TableIdentity()  	
  
  /// <summary>The table name(s).</summary>
  /// <param name="databaseConnectionString">The database connection string.</param>
  /// <param name="exceptionMessage">The exception message.</param>
  /// <param name="databaseName">The name of the database.</param>
  public static ArrayList TableName
  (
       string databaseConnectionString,
   ref string exceptionMessage,
       string databaseName
  )
  {
   ArrayList arrayListTableName = null;
   arrayListTableName = TableName
   (
        databaseConnectionString,
    ref exceptionMessage,
        databaseName,
        InformationSchemaClassificationTableDefault
   ); 
   return ( arrayListTableName );
  }//public static ArrayList TableName

  /// <summary>The database name(s).</summary>
  /// <param name="databaseConnectionString">The database connection string.</param>
  /// <param name="exceptionMessage">The exception message.</param>
  /// <param name="databaseName">The name of the database.</param>
  /// <param name="tableClassification">The database classification, for example, sample, system, user.</param>  
  public static ArrayList TableName
  (
       string databaseConnectionString,
   ref string exceptionMessage,
       string databaseName,
       string tableClassification
  )
  {
   int           tableClassificationIndex = 0;
   int           tableClassificationTotal = InformationSchemaClassificationTable.Length;
   string        tableName                = null; 

   ArrayList     arrayListTableName       = null;
   IDataReader   iDataReader              = null;
   StringBuilder sbSQLCondition           = null;
   StringBuilder sbSQLStatement           = null;
   
   exceptionMessage                       = null;
   sbSQLCondition                         = new StringBuilder();
   sbSQLStatement                         = new StringBuilder();

   for 
   ( 
    tableClassificationIndex = 0;
    tableClassificationIndex < tableClassificationTotal;
    ++tableClassificationIndex
   )
   {
    if 
    (
     string.Compare
     ( 
      InformationSchemaClassificationTable[tableClassificationIndex][InformationSchemaClassificationDatabaseRankName], 
      tableClassification, 
      true 
     )
     ==
     0
    ) 
    {
     //Table classification found.
     sbSQLCondition.AppendFormat
     (
      InformationSchemaClassificationTable[tableClassificationIndex][InformationSchemaClassificationTableRankCondition],
      InformationSchemaColumnNameTable
     );
         
     sbSQLStatement.AppendFormat
     (
      InformationSchemaSQLTable,
      InformationSchemaColumnNameTable,
      databaseName,
      sbSQLCondition
     ); 
     
     #if (DEBUG)
      System.Console.WriteLine
      (
       "UtilityDatabase.TableName() Table Name SQL Index [{0}]: Classification: {1} | Condition: {2} | Statement: {3}",
       tableClassificationIndex,
       tableClassification,
       sbSQLCondition,
       sbSQLStatement
      );
     #endif
     break;
    }//if strcmp( InformationSchemaClassificationDatabase, databaseClassification, true )    
   }//for ( databaseClassificationIndex = 0; databaseClassificationIndex < databaseClassificationTotal; ++databaseClassificationIndex );
 
   DatabaseQuery
   ( 
        databaseConnectionString, 
    ref exceptionMessage, 
    ref iDataReader,
        sbSQLStatement.ToString(), 
        CommandType.Text
   );
   
   if ( exceptionMessage != null || iDataReader == null)
   {
    return ( arrayListTableName );
   } 
  
   arrayListTableName = new ArrayList();
   
   try
   {
    while ( iDataReader.Read() )
    {
     tableName = ( string ) iDataReader[InformationSchemaColumnNameTable];
     #if (DEBUG)
      System.Console.WriteLine( "UtilityDatabase.TableName() Table Name: {0}", tableName );
     #endif
     arrayListTableName.Add( tableName );
    }//while ( iDataReader.Read() )
    iDataReader.Close();
   }//try
   catch (OleDbException exception)
   {
    //exceptionMessage = DisplayOleDbErrorCollection( exception );
    exceptionMessage   = UtilityEventLog.WriteEntryOleDbErrorCollection( exception );
    exceptionMessage   = String.Format("OLEDbException: {0}", exceptionMessage );
   }//catch (OleDbException exception)
   catch (Exception exception)
   {
    exceptionMessage   = String.Format("Exception: {0}", exception.Message );
   }//catch (Exception exception)
   UtilityDebug.Write( exceptionMessage ); 
   
   return ( arrayListTableName );
  }//public static ArrayList TableName  

  /// <summary>Table name and columns</summary>
  public static void TableNameColumn
  (
   ref string    DatabaseSQLSelect,
   ref string    exceptionMessage,
   ref string    tableName,
   ref ArrayList columnName
  )     
  {
   int databaseSQLSelectSubstringCount = 0;
   int databaseSQLSelectSubstringTotal = 0;

   string[] databaseSQLSelectSubstring      = null;

   HttpContext httpContextCurrent = null; 
   httpContextCurrent             = HttpContext.Current; 
   
   columnName = new ArrayList();
   tableName  = null;
   
   databaseSQLSelectSubstring = DatabaseSQLSelect.Split(DelimiterCharSplit);
   
   databaseSQLSelectSubstringTotal = databaseSQLSelectSubstring.Length;
   
   if ( databaseSQLSelectSubstringTotal > 0 )
   {
    tableName = databaseSQLSelectSubstring[databaseSQLSelectSubstringTotal - 1];
   }

   for 
   ( 
    databaseSQLSelectSubstringCount = 1; 
    databaseSQLSelectSubstringCount < databaseSQLSelectSubstringTotal - 2;
    ++databaseSQLSelectSubstringCount
   )
   {
    databaseSQLSelectSubstring[databaseSQLSelectSubstringCount] = databaseSQLSelectSubstring[databaseSQLSelectSubstringCount].Trim();
    if 
    ( 
     String.Compare( databaseSQLSelectSubstring[databaseSQLSelectSubstringCount], "" ) == 0 ||
     String.Compare( databaseSQLSelectSubstring[databaseSQLSelectSubstringCount], "," ) == 0
    )
    { 
     continue;
    }
    columnName.Add( databaseSQLSelectSubstring[databaseSQLSelectSubstringCount] ); 
   }   	 

   #if (DEBUG)   
    System.Console.WriteLine("Table Name: {0}", tableName);
    System.Console.WriteLine("Column Name:");
    foreach( object objectColumnName in columnName )
    {
     System.Console.WriteLine("{0}", objectColumnName);     	
    }    	
   #endif 
    
  }//public static void TableNameColumn

  ///<summary>Static.</summary>
  static UtilityDatabase()
  {
   DelimiterCharSplit                     = DelimiterStringSplit.ToCharArray();
   DelimiterCharSplitDatabaseOwnerObject  =  DelimiterStringSplitDatabaseOwnerObject.ToCharArray();
  }//static UtilityDatabase()
      
 }//public class UtilityDatabase
}//namespace WordEngineering
