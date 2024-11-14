using System;
using System.Data;
using System.Data.OleDb;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Management;
using System.Security;
using System.Text;
using System.Web;
using System.Web.Caching;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Xsl;

namespace WordEngineering
{

 ///<summary>UtilityContact</summary>
 ///<remarks />
 public class UtilityContact
 {

  /// <summary>The database connection string.</summary>
  public static  String     DatabaseConnectionString                    = "Provider=SQLOLEDB;Data Source=localhost;Integrated Security=SSPI;Initial Catalog=WordEngineering;";

  /// <summary>The database connection string - ElectronicCopy.</summary>
  public static  String     DatabaseConnectionStringElectronicCopy      = "Provider=SQLOLEDB;Data Source=localhost;Integrated Security=SSPI;Initial Catalog=ElectronicCopy;";

  /// <summary>The configuration XML filename.</summary>
  public static  String     FilenameConfigurationXml                    = @"WordEngineering.config";

  /// <summary>The SQL select for the Contact.</summary>
  public static  String     SQLSelectContactBrowse                      = "SELECT SequenceOrderId, ISNULL(FirstName + ' ','') + IsNull(OtherName + ' ','') + IsNull(LastName + ' ','') + IsNull(Company + ' ','') AS Name, Dated, Company, Prefix, Suffix, Commentary FROM Contact ORDER BY LastName, FirstName, OtherName, Company";

  /// <summary>The SQL select for the Contact.</summary>
  public static  String     SQLSelectContactDetail                      = "SELECT SequenceOrderId, FirstName, LastName, OtherName, Company, Prefix, Suffix, Commentary, ScriptureReference FROM Contact WHERE SequenceOrderId = {0} ORDER BY LastName, FirstName, OtherName, Company";

  /// <summary>The SQL select for the Contact.</summary>
  public static  string[]   SQLSelectContactDetailGridView              = { 
                                                                           "SELECT TheWordId, SequenceOrderId, ContactId, Dated, EmailAddress  FROM ContactEmail WHERE ContactId = {0} ORDER BY EmailAddress",
                                                                           "SELECT TheWordId, SequenceOrderId, ContactId, Dated, InternetAddress FROM ContactURI WHERE ContactId = {0} ORDER BY InternetAddress",
                                                                           "SELECT TheWordId, SequenceOrderId, ContactId, Dated, TelephoneNo, TelephoneLocation FROM Telephone WHERE ContactId = {0} ORDER BY TelephoneNo, TelephoneLocation",
                                                                           "SELECT TheWordId, SequenceOrderId, ContactId, Dated, AddressLine1, City, State, ZipCode, Country FROM StreetAddress WHERE ContactId = {0} ORDER BY AddressLine1, City, State, ZipCode, Country"
                                                                          };
                                                                         
  /// <summary>The SQL select for the ContactEmail.</summary>
  public static  String     SQLSelectContactEmail                       = "SELECT TheWordId, SequenceOrderId, ContactId, EmailAddress FROM ContactEmail WHERE ContactId = {0} ORDER BY EmailAddress";

  /// <summary>The SQL update for the Contact.</summary>
  public static  String     SQLUpdateContactDetail                      = "UPDATE Contact SET FirstName = '{1}', LastName = '{2}', OtherName = '{3}', Company = '{4}', Prefix = '{5}', Suffix = '{6}', Commentary = '{7}', ScriptureReference = '{8}' WHERE SequenceOrderId = {0}";

  /// <summary>The XPath database connection string.</summary>
  public const   String     XPathDatabaseConnectionString               = @"/word/database/sqlServer/wordEngineering/databaseConnectionString";

  /// <summary>The XPath database connection string - ElectronicCopy.</summary>
  public const   String     XPathDatabaseConnectionStringElectronicCopy = @"/word/database/sqlServer/electronicCopy/databaseConnectionString";
  
  ///<summary>The entry point for the application.</summary>
  ///<param name="argv">A list of command line arguments</param>
  public static void Main
  (
   String[] argv
  )
  {

  }//public static void Main( String[] argv )

  ///<summary>ContactBrowse</summary>
  public static void ContactBrowse
  (
   ref String         databaseConnectionString,
   ref String         exceptionMessage,
   ref IDataReader    iDataReader
  )
  {

   String         SQLSelect  =  null;
   StringBuilder  sb         =  null;
   
   sb = new StringBuilder();
   sb.AppendFormat( SQLSelectContactBrowse );
   SQLSelect = sb.ToString();

   ContactBrowse
   (
    ref databaseConnectionString,
    ref exceptionMessage,
    ref iDataReader,
    ref SQLSelect
   );
  }
  	
  /// <summary>ContactBrowse</summary>
  public static void ContactBrowse
  (
   ref String         databaseConnectionString,
   ref String         exceptionMessage,
   ref IDataReader    iDataReader,
   ref String         SQLSelect
  )
  {

   UtilityDatabase.DatabaseQuery
   (
        databaseConnectionString,
    ref exceptionMessage,
    ref iDataReader,
        SQLSelect,
        CommandType.Text 
   );
  }//public static void ContactBrowse()

  /// <summary>ContactDetail</summary>
  public static void ContactDetail
  (
       string      databaseConnectionString,
   ref string      exceptionMessage,
   ref DataSet     dataSetContact,
   ref int         contactID,
   ref Contact     contact,
   ref DataSet[]   dataSetMultiple
  )
  {  

   String  firstName                 =  null;
   String  lastName                  =  null;
   String  otherName                 =  null;
   String  company                   =  null;
   String  prefix                    =  null;
   String  suffix                    =  null;
   String  commentary                =  null;
   String  scriptureReference        =  null;

   StringBuilder  sb                 =  null;
   
   sb = new StringBuilder();
   sb.AppendFormat
   ( 
    SQLSelectContactDetail,
    contactID
   );

   UtilityDatabase.DatabaseQuery
   (
        databaseConnectionString,
    ref exceptionMessage,
    ref dataSetContact,
        sb.ToString(),
        CommandType.Text   
   );
   
   //UtilityDatabase.PrintValues( dataSet );
   
   try
   {
    firstName = System.Convert.ToString
    (
     UtilityDatabase.DataSetTableRowColumn
     ( 
      dataSetContact,
      "Table",
      0,
      "FirstName"
     )
    ); 

    lastName = System.Convert.ToString
    (
     UtilityDatabase.DataSetTableRowColumn
     ( 
      dataSetContact,
      "Table",
      0,
      "LastName"
     )
    ); 

    otherName = System.Convert.ToString
    (
     UtilityDatabase.DataSetTableRowColumn
     ( 
      dataSetContact,
      "Table",
      0,
      "OtherName"
     )
    ); 

    company = System.Convert.ToString
    (
     UtilityDatabase.DataSetTableRowColumn
     ( 
      dataSetContact,
      "Table",
      0,
      "Company"
     )
    );

    prefix = System.Convert.ToString
    (
     UtilityDatabase.DataSetTableRowColumn
     ( 
      dataSetContact,
      "Table",
      0,
      "Prefix"
     )
    );

    suffix = System.Convert.ToString
    (
     UtilityDatabase.DataSetTableRowColumn
     ( 
      dataSetContact,
      "Table",
      0,
      "Suffix"
     )
    );

    commentary = System.Convert.ToString
    (
     UtilityDatabase.DataSetTableRowColumn
     ( 
      dataSetContact,
      "Table",
      0,
      "Commentary"
     )
    );

    scriptureReference = System.Convert.ToString
    (
     UtilityDatabase.DataSetTableRowColumn
     ( 
      dataSetContact,
      "Table",
      0,
      "ScriptureReference"
     )
    );
    
    contact = new Contact
    (
     contactID,
     firstName,
     lastName,
     otherName,
     company,
     prefix,
     suffix,
     commentary,
     scriptureReference
    );    
    
   }//try
   catch ( Exception exception )
   {
   	exceptionMessage = exception.Message;
   }	 

   for( int dataSetIndex = 0; dataSetIndex < dataSetMultiple.Length; ++dataSetIndex )
   {
    sb = new StringBuilder();  

    sb.AppendFormat
    ( 
     SQLSelectContactDetailGridView[dataSetIndex],
     contact.contactID
    );

    UtilityDatabase.DatabaseQuery
    (
          databaseConnectionString,
     ref  exceptionMessage,
     ref  dataSetMultiple[dataSetIndex],
          sb.ToString(),
          CommandType.Text
    );

   }//for( int dataSetIndex = 0; dataSetIndex <= dataSet.Length; ++dataSetIndex )
   
  }//public static void ContactDetail()

  /// <summary>ContactDetailSave</summary>
  public static void ContactDetailSave
  (
       String     databaseConnectionString,
   ref String     exceptionMessage,
   ref Contact    contact
  )
  {
   StringBuilder  sb  =  new StringBuilder();
   	
   sb.AppendFormat
   ( 
    SQLUpdateContactDetail,
    contact.ContactID,     
    contact.FirstName,
    contact.LastName,
    contact.OtherName,
    contact.Company,
    contact.Prefix,
    contact.Suffix,
    contact.Commentary,
    contact.ScriptureReference
   );

   UtilityDatabase.DatabaseQuery
   (
        databaseConnectionString,
    ref exceptionMessage,       
        sb.ToString(),
        CommandType.Text
   );
    
  }//public static void UtilityContact.ContactDetailSave()   	

  ///<summary>ContactImageUpdate</summary>
  public static void ContactImageUpdate
  (
   ref string      databaseConnectionStringElectronicCopy,
   ref string      exceptionMessage,
   ref int         contactImageID,
   ref DateTime    dated,   
   ref int         contactID,
   ref byte[]      imageContent,
   ref FileUpload  imageSource,
   ref string      imageType
  )
  {
   int              databaseNumberOfRowsAffected  =  -1;
   string           imageSourcePath               =  null;
   OleDbCommand     oleDbCommand                  =  null;
   OleDbConnection  oleDbConnection               =  null;
   OleDbParameter   oleDbParameter                =  null;
   try
   {
    if ( imageSource.HasFile == false ) { return; }
    imageSourcePath  =  imageSource.PostedFile.FileName;    
    UtilityImage.FileUploadByte
    (
     ref imageSource,
     ref imageContent,
     ref exceptionMessage
    );
    if ( exceptionMessage != null ) { return; }
    oleDbConnection  =  UtilityDatabase.DatabaseConnectionInitialize
    (
         databaseConnectionStringElectronicCopy,
     ref exceptionMessage
    );
	if ( exceptionMessage != null ) { return; }
	oleDbCommand                  =  new OleDbCommand( "uspContactImageUpdate", oleDbConnection );
    if ( oleDbCommand == null ) { return; }
    oleDbCommand.CommandType      =  CommandType.StoredProcedure;
    oleDbParameter                =  new OleDbParameter( "@contactImageID", OleDbType.Integer );
    if ( contactImageID > 0 )
    {
     oleDbParameter.Value         =  contactImageID;
    }
    else
    {
     oleDbParameter.Value         =  DBNull.Value;
    } 
    oleDbCommand.Parameters.Add( oleDbParameter );
    
    oleDbParameter                =  new OleDbParameter( "@dated", OleDbType.Date );
    if ( dated > DateTime.MinValue )
    {
     oleDbParameter.Value          =  dated;
    }
    else
    {
     oleDbParameter.Value         =  DBNull.Value;
    } 
    oleDbCommand.Parameters.Add( oleDbParameter );

    oleDbParameter                =  new OleDbParameter( "@contactID", OleDbType.Integer );
    if ( contactID > 0 )
    {
     oleDbParameter.Value         =  contactID;
    }
    else
    {
     oleDbParameter.Value         =  DBNull.Value;
    } 
    oleDbCommand.Parameters.Add( oleDbParameter );

    oleDbParameter                =  new OleDbParameter( "@imageContent", OleDbType.Binary );
    oleDbParameter.Value          =  imageContent;
    oleDbCommand.Parameters.Add( oleDbParameter );

    oleDbParameter                =  new OleDbParameter( "@ImageSource", OleDbType.VarChar, 255 );
    oleDbParameter.Value          =  imageSourcePath;
    oleDbCommand.Parameters.Add( oleDbParameter );

    oleDbParameter                =  new OleDbParameter( "@imageType", OleDbType.VarChar, 255 );
    oleDbParameter.Value          =  imageType;
    oleDbCommand.Parameters.Add( oleDbParameter );
    
    databaseNumberOfRowsAffected  =  oleDbCommand.ExecuteNonQuery();
   }//try
   catch ( Exception exception ) { UtilityException.ExceptionLog( exception, exception.GetType().Name, ref exceptionMessage ); }
  }

  /// <summary>Read the XML Configuration file.</summary>
  public static void ConfigurationXml()
  {  
   string exceptionMessage = null;
   
   ConfigurationXml
   (
        FilenameConfigurationXml,
    ref exceptionMessage,
    ref DatabaseConnectionString,
	ref DatabaseConnectionStringElectronicCopy
   );
   
  }//public static void ConfigurationXml()

  /// <summary>Read the XML Configuration file.</summary>
  /// <param name="filenameConfigurationXml">The XML Configuration file.</param>
  /// <param name="exceptionMessage">The exception message.</param>
  /// <param name="databaseConnectionString">The database connection string.</param>  
  /// <param name="databaseConnectionStringElectronicCopy">The database connection string - ElectronicCopy.</param>
  public static void ConfigurationXml
  (
       string filenameConfigurationXml,
   ref string exceptionMessage,
   ref string databaseConnectionString,
   ref string databaseConnectionStringElectronicCopy
  )
  {
   UtilityXml.XmlDocumentNodeInnerText
   (
         filenameConfigurationXml,
     ref exceptionMessage,
         XPathDatabaseConnectionString,
     ref databaseConnectionString
    );
   UtilityXml.XmlDocumentNodeInnerText
   (
         filenameConfigurationXml,
     ref exceptionMessage,
         XPathDatabaseConnectionStringElectronicCopy,
     ref databaseConnectionStringElectronicCopy
    );
  }//ConfigurationXml	 
  
  static UtilityContact()
  {
   ConfigurationXml();
  }//static UtilityContact()
  
 }//public class UtilityContact
 
}//namespace WordEngineering