using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Windows.Forms;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;

namespace WordEngineering
{
 /// <summary>URIMaintenancePage</summary>
 public class URIMaintenancePage : Page
 {
  /// <summary>ColumnName</summary>
  public String[] ColumnNameURI                = UtilityURI.ColumnNameURI;

  /// <summary>The database connection String.</summary>
  public String DatabaseConnectionString       = "Provider=SQLOLEDB;Data Source=localhost;Integrated Security=SSPI;Initial Catalog=URI;";

  /// <summary>The configuration XML filename.</summary>
  public String FilenameConfigurationXml       = @"WordEngineering.config";

  /// <summary>FilenameStylesheet</summary>
  public string FilenameStylesheet             = UtilityURI.FilenameStylesheet;

  /// <summary>The server map path.</summary>
  public String ServerMapPath                  = null;

  /// <summary>TableName</summary>
  public String[] TableNameURI                = UtilityURI.TableNameURI;

  /// <summary>TableNameDefault</summary>
  public string   TableNameURIDefault         = UtilityURI.TableNameURIDefault;

  /// <summary>HtmlInputFileURI</summary>  
  protected System.Web.UI.HtmlControls.HtmlInputFile         HtmlInputFileURI;

  /// <summary>ButtonFileOpen</summary>  
  protected System.Web.UI.WebControls.Button                 ButtonFileOpen;

  /// <summary>ButtonFileSave</summary>  
  protected System.Web.UI.WebControls.Button                 ButtonFileSave;

  /// <summary>ButtonReset</summary>  
  protected System.Web.UI.WebControls.Button                 ButtonReset;

  /// <summary>ButtonSubmit</summary>  
  protected System.Web.UI.WebControls.Button                 ButtonSubmit;

  /// <summary>DropDownListTableName</summary>
  protected System.Web.UI.WebControls.DropDownList           DropDownListTableName;

  /// <summary>DetailsViewURI</summary>
  protected System.Web.UI.WebControls.DetailsView            DetailsViewURI;

  /// <summary>GridViewURI</summary>
  protected System.Web.UI.WebControls.GridView               GridViewURI;

  /// <summary>LiteralFeedback</summary>
  protected System.Web.UI.WebControls.Literal                LiteralFeedback;

  /// <summary>SqlDataSourceURIDetailsView</summary>
  protected System.Web.UI.WebControls.SqlDataSource          SqlDataSourceURIDetailsView;
  
  /// <summary>SqlDataSourceURIGridView</summary>
  protected System.Web.UI.WebControls.SqlDataSource          SqlDataSourceURIGridView;

  /// <summary>SqlDataSourceTable</summary>
  protected System.Web.UI.WebControls.SqlDataSource          SqlDataSourceTable;

  /// <summary>TextBoxDatedFrom</summary>
  protected System.Web.UI.WebControls.TextBox                TextBoxDatedFrom;

  /// <summary>TextBoxDatedTo</summary>
  protected System.Web.UI.WebControls.TextBox                TextBoxDatedTo;

  /// <summary>TextBoxKeyword</summary>
  protected System.Web.UI.WebControls.TextBox                TextBoxKeyword;

  /// <summary>TextBoxSequenceOrderIdFrom</summary>
  protected System.Web.UI.WebControls.TextBox                TextBoxSequenceOrderIdFrom;

  /// <summary>TextBoxSequenceOrderIdTo</summary>
  protected System.Web.UI.WebControls.TextBox                TextBoxSequenceOrderIdTo;

  /// <summary>TextBoxTitle</summary>
  protected System.Web.UI.WebControls.TextBox                TextBoxTitle;

  /// <summary>TextBoxURI</summary>
  protected System.Web.UI.WebControls.TextBox                TextBoxURI;

  /// <summary>Page Load.</summary>
  public void Page_Load
  (
   object     sender, 
   EventArgs  e
  ) 
  {

   String  exceptionMessage  =  null;

   ServerMapPath = this.MapPath("");

   if ( !Page.IsPostBack )
   {
    /* 
    FilenameConfigurationXml = Server.MapPath( FilenameConfigurationXml );
    */

    if ( ServerMapPath != null)
    {
     FilenameConfigurationXml = ServerMapPath + @"\" + FilenameConfigurationXml;
    }//if ( ServerMapPath != null)

    UtilityURI.ConfigurationXml
    (
         FilenameConfigurationXml,
     ref exceptionMessage,         
     ref DatabaseConnectionString,
     ref FilenameStylesheet,
     ref ColumnNameURI,
     ref TableNameURI,
     ref TableNameURIDefault
    );
    if ( exceptionMessage != null )
    {
     Feedback = exceptionMessage;
     return;
    }//if ( exceptionMessage != null )

    GridViewURI.Focus();
    Page.SetFocus( GridViewURI );
    DetailsViewURI.Attributes.Add("autocomplete", "on");
    GridViewURI.Attributes.Add("autocomplete", "on");
   }//if ( !Page.IsPostBack )
   	
  }//Page_Load

  /// <summary>DropDownListTableName_PreRender</summary>
  public void DropDownListTableName_PreRender
  (
   object     sender, 
   EventArgs  e
  ) 
  {
   if ( !Page.IsPostBack )
   {
    if ( DropDownListTableName.Items.Count < 1 )
    {
     DropDownListTableName.DataSourceID    =  null;
     DropDownListTableName.DataTextField   =  null;
     DropDownListTableName.DataValueField  =  null;
     DropDownListTableName.DataSource      =  TableNameURI;
     DropDownListTableName.DataBind();
    }//if ( DropDownListTableName.Items.Count < 1 )
    UtilityWebControl.SelectItem
    ( 
     DropDownListTableName,
     TableNameURIDefault
    );
   }//if ( !Page.IsPostBack ) 
  }//public void DropDownListTableName_PreRender()

  /// <summary>Feedback.</summary>
  public String Feedback
  {
   get
   {
    return ( LiteralFeedback.Text);
   } 
   set
   {
    LiteralFeedback.Text = value;
   }
  }//public String public String Feedback

  /// <summary>FilenameURI</summary>
  public String FilenameURI
  {
   get
   {
    return ( HtmlInputFileURI.PostedFile.FileName  );
   } 
  }//public String FilenameURI

  /// <summary>DatedFrom</summary>
  public String DatedFrom
  {
   get
   {
    return ( TextBoxDatedFrom.Text );
   } 
   set
   {
    TextBoxDatedFrom.Text = value;
   }
  }//public String DatedFrom

  /// <summary>DatedTo</summary>
  public String DatedTo
  {
   get
   {
    return ( TextBoxDatedTo.Text );
   } 
   set
   {
    TextBoxDatedTo.Text = value;
   }
  }//public String DatedTo

  /// <summary>Keyword</summary>
  public String Keyword
  {
   get
   {
    return ( TextBoxKeyword.Text );
   } 
   set
   {
    TextBoxKeyword.Text = value;
   }
  }//public String Keyword

  /// <summary>SequenceOrderIdFrom</summary>
  public String SequenceOrderIdFrom
  {
   get
   {
    return ( TextBoxSequenceOrderIdFrom.Text );
   } 
   set
   {
    TextBoxSequenceOrderIdFrom.Text = value;
   }
  }//public String SequenceOrderIdFrom

  /// <summary>SequenceOrderIdTo</summary>
  public String SequenceOrderIdTo
  {
   get
   {
    return ( TextBoxSequenceOrderIdTo.Text );
   } 
   set
   {
    TextBoxSequenceOrderIdTo.Text = value;
   }
  }//public String SequenceOrderIdTo

  /// <summary>URITitle</summary>
  public String URITitle
  {
   get
   {
    return ( TextBoxTitle.Text );
   } 
   set
   {
    TextBoxTitle.Text = value;
   }
  }//public String URITitle

  /// <summary>URI</summary>
  public String URI  
  {
   get
   {
    return ( TextBoxURI.Text );
   } 
   set
   {
    TextBoxURI.Text = value;
   }
  }//public String URI

  /// <summary>ButtonFileOpen_Click().</summary>
  public void ButtonFileOpen_Click
  (
   Object sender, 
   EventArgs e
  )
  {
   /*
   XmlDataSourceURIGridView.DataFile = FilenameURI;
   GridViewURI.AllowPaging=false;
   GridViewURI.DataKeyNames=null;
   GridViewURI.DataSourceID = XmlDataSourceURIGridView.ID;
   GridViewURI.DataBind();
   */

   string     exceptionMessage  =  null;
   string     filenameXml       =  null;
   DataSet    dataSet           =  null;
   
   try
   {
    filenameXml                =  FilenameURI;
    if ( string.IsNullOrEmpty( filenameXml ) )
    {
     return;
    }
    UtilityURI.ReadXml
    (
     ref filenameXml,
     ref dataSet,
     ref exceptionMessage,
     ref ColumnNameURI
    );
    if ( exceptionMessage != null )
    {
     Feedback = exceptionMessage;
     return;
    }     	 
    if ( dataSet != null )
    {
     ViewState["URIMaintenancePage_DataSet"] = dataSet;
     GridViewURI.AllowPaging   =  false;
     GridViewURI.AllowSorting  =  false;     
     GridViewURI.DataSourceID  =  null;
     GridViewURI.DataSource    =  dataSet;
     GridViewURI.DataBind();
    }
   }//try
   catch ( Exception exception )
   {
   	exceptionMessage = "Exception: " + exception.Message;
   }
   if ( exceptionMessage != null )
   {
   	Feedback = exceptionMessage;
   }
  }//public void ButtonFileOpen_Click()

  /// <summary>ButtonFileSaveRelease20050830_Click()</summary>
  public void ButtonFileSaveRelease20050830_Click
  (
   Object sender, 
   EventArgs e
  )
  {
   string     exceptionMessage      =  null;
   string     filenameXml           =  null;
   string     typeDataSourceString  =  null;
   object     dataSource            =  null;
   DataSet    dataSet               =  null;
   Type       typeDataSource        =  null;
   
   try
   {
    filenameXml     =  FilenameURI;
    if ( string.IsNullOrEmpty( filenameXml ) )
    {
     return;
    }
    if ( string.IsNullOrEmpty( GridViewURI.DataSourceID ) )
    {
     dataSource      =  GridViewURI.DataSource;
     if ( dataSource == null )
     {
      return;
     }           	
     typeDataSource  =  dataSource.GetType();
     if ( typeDataSource == null )
     {
      return;
     }      	     
     typeDataSourceString = typeDataSource.ToString();
     if ( typeDataSourceString != "System.Data.DataSet")
     {
      return;
     }      	
     dataSet = dataSource as DataSet;
     dataSet = ( DataSet ) dataSource;
     if ( dataSet == null )
     {
      return;
     }
     UtilityXml.WriteXml
     (
          dataSet,
      ref exceptionMessage,
      ref filenameXml,
      ref FilenameStylesheet
     );
     if ( exceptionMessage != null )
     {
      Feedback = exceptionMessage;
      return;
     }     	 
    }//if ( GridViewURI.DataSourceID == null && GridViewURI.DataSource != null )
   }//try
   catch ( Exception exception )
   {
   	exceptionMessage = "Exception: " + exception.Message;
   }
   if ( exceptionMessage != null )
   {
   	Feedback = exceptionMessage;
   }
  }//public void ButtonFileSaveRelease20050830_Click()

  /// <summary>ButtonFileSave_Click()</summary>
  public void ButtonFileSave_Click
  (
   Object sender, 
   EventArgs e
  )
  {
   string   exceptionMessage  =  null;
   string   filenameXml       =  null;
   DataSet  dataSet           =  null;
   
   try
   {
    filenameXml     =  FilenameURI;
    if ( string.IsNullOrEmpty( filenameXml ) )
    {
     return;
    }
    dataSet = ( DataSet ) ViewState["URIMaintenancePage_DataSet"];
    if ( dataSet == null )
    {
     return;
    }
    UtilityXml.WriteXml
    (
         dataSet,
     ref exceptionMessage,
     ref filenameXml,
     ref FilenameStylesheet
    );
    if ( exceptionMessage != null )
    {
     Feedback = exceptionMessage;
     return;
    }     	 
   }//try
   catch ( Exception exception )
   {
   	exceptionMessage = "Exception: " + exception.Message;
   }
   if ( exceptionMessage != null )
   {
   	Feedback = exceptionMessage;
   }
  }//public void ButtonFileSave_Click()
  
  /// <summary>ButtonSubmit_Click().</summary>
  public void ButtonSubmit_Click
  (
   Object sender, 
   EventArgs e
  )
  {
   GridViewURI.DataBind();
  }//public void ButtonSubmit_Click()

  /// <summary>ButtonReset_Click().</summary>
  public void ButtonReset_Click
  (
   Object sender, 
   EventArgs e
  )
  {

   Feedback             =  null;
   DatedFrom            =  null;
   DatedTo              =  null;
   Keyword              =  null;
   SequenceOrderIdFrom  =  null;
   SequenceOrderIdTo    =  null;
   URI                  =  null;
   URITitle             =  null;
   
   UtilityJavaScript.SetFocus
   ( 
    this,
    DropDownListTableName
   );

  }//public void ButtonReset_Click()

  /// <summary>DetailsViewURI_ItemInserted</summary>
  public void DetailsViewURI_ItemInserted
  (
   Object                        sender, 
   DetailsViewInsertedEventArgs  detailsViewInsertedEventArgs
  )
  {
   // Use the Exception property to determine whether an exception
   // occurred during the insert operation.
   if ( detailsViewInsertedEventArgs.Exception != null )
   {
    // Insert the code to handle the exception.
    Feedback = detailsViewInsertedEventArgs.Exception.Message;

    // Use the ExceptionHandled property to indicate that the 
    // exception is already handled.
    detailsViewInsertedEventArgs.ExceptionHandled = true;

    // When an exception occurs, keep the DetailsView
    // control in insert mode.
    detailsViewInsertedEventArgs.KeepInInsertMode = true;
   }//if ( detailsViewInsertedEventArgs.Exception != null )
   else
   {
    GridViewURI.DataBind();
   }
  }//public void DetailsViewURI_ItemInserted

  /// <summary>DetailsViewURI_ItemInserting</summary>
  public void DetailsViewURI_ItemInserting
  (
   Object                      sender, 
   DetailsViewInsertEventArgs  detailsViewInsertEventArgs
  )
  {
   int       sequenceOrderId   =  -1;
   DateTime  dated             =  DateTime.MinValue;
   string    exceptionMessage  =  null;
   string    keyword           =  null;
   string    title             =  null;
   string    uri               =  null;
   
   IOrderedDictionary  iOrderedDictionary;     
   try
   {
    /*
    iOrderedDictionary = detailsViewInsertEventArgs.Values;
    feedback = "";
    foreach ( DictionaryEntry dictionaryEntry in iOrderedDictionary )
    {
     feedback += dictionaryEntry.Key;
     if ( dictionaryEntry.Value != null )
     {
      feedback += " = " + dictionaryEntry.Value + " | ";
     }//if ( dictionaryEntry.Value != null )
    }//foreach ( DictionaryEntry dictionaryEntry in iOrderedDictionary )
    return;
    */

    if ( detailsViewInsertEventArgs.Values["Dated"] != null )
    {
     DateTime.TryParse( detailsViewInsertEventArgs.Values["Dated"].ToString(), out dated );
    }
    if ( detailsViewInsertEventArgs.Values["SequenceOrderId"] != null )
    {
     Int32.TryParse( detailsViewInsertEventArgs.Values["SequenceOrderId"].ToString(), out sequenceOrderId );
    } 
    if ( detailsViewInsertEventArgs.Values["URI"] != null )
    {
     uri = detailsViewInsertEventArgs.Values["URI"].ToString();
    }
    if ( detailsViewInsertEventArgs.Values["Title"] != null )
    {
     title = detailsViewInsertEventArgs.Values["Title"].ToString();
    } 
    if ( detailsViewInsertEventArgs.Values["Keyword"] != null )
    {
     keyword = detailsViewInsertEventArgs.Values["Keyword"].ToString();
    }
    if ( sequenceOrderId > 0 )
    {
     SqlDataSourceURIDetailsView.InsertParameters["sequenceOrderId"].DefaultValue  =  System.Convert.ToString( sequenceOrderId );
    }
    if ( dated != DateTime.MinValue )
    {
     SqlDataSourceURIDetailsView.InsertParameters["dated"].DefaultValue            =  System.Convert.ToString( dated );
    }
    SqlDataSourceURIDetailsView.InsertParameters["keyword"].DefaultValue           =  keyword;
    SqlDataSourceURIDetailsView.InsertParameters["title"].DefaultValue             =  title;
    SqlDataSourceURIDetailsView.InsertParameters["uri"].DefaultValue               =  uri;
    SqlDataSourceURIDetailsView.Insert();
   }//try
   catch ( Exception exception )
   {
   	exceptionMessage = exception.Message;
   }
   if ( exceptionMessage != null )
   {
    Feedback = exceptionMessage;
    return;
   }
  }//void DetailsViewURI_ItemInserting()

  /// <summary>DetailsViewURI_ItemUpdated</summary>
  public void DetailsViewURI_ItemUpdated
  (
   Object                        sender, 
   DetailsViewUpdatedEventArgs   detailsViewUpdatedEventArgs
  )
  {
   // Use the Exception property to determine whether an exception
   // occurred during the insert operation.
   if ( detailsViewUpdatedEventArgs.Exception != null )
   {
    // Insert the code to handle the exception.
    Feedback = detailsViewUpdatedEventArgs.Exception.Message;

    // Use the ExceptionHandled property to indicate that the 
    // exception is already handled.
    detailsViewUpdatedEventArgs.ExceptionHandled = true;

    // When an exception occurs, keep the DetailsView
    // control in edit mode.
    detailsViewUpdatedEventArgs.KeepInEditMode = true;
   }//if ( detailsViewUpdatedEventArgs.Exception != null )
   else
   {
    GridViewURI.DataBind();
   }
  }//public void DetailsViewURI_ItemUpdated

  /// <summary>GridViewURI_RowCommand</summary>
  public void GridViewURI_RowCommand
  (
   Object                    sender, 
   GridViewCommandEventArgs  gridViewCommandEventArgs
  )
  { 
   int       sequenceOrderId   =  -1;
   DateTime  dated;
   string    exceptionMessage  =  null;
   string    keyword           =  null;
   string    title             =  null;
   string    uri               =  null;
   
   try
   {
    switch ( gridViewCommandEventArgs.CommandName  )
    {
   	 case "ButtonGridViewURIFooterTemplateAdd":
      DateTime.TryParse( ( ( System.Web.UI.WebControls.TextBox ) GridViewURI.FooterRow.FindControl("TextBoxGridViewURIFooterTemplateDated")).Text, out dated );
      Int32.TryParse( ( ( System.Web.UI.WebControls.TextBox ) GridViewURI.FooterRow.FindControl("TextBoxGridViewURIFooterTemplateSequenceOrderId")).Text, out sequenceOrderId );
      keyword  =  ( ( System.Web.UI.WebControls.TextBox ) GridViewURI.FooterRow.FindControl("TextBoxGridViewURIFooterTemplateKeyword")).Text;
      title    =  ( ( System.Web.UI.WebControls.TextBox ) GridViewURI.FooterRow.FindControl("TextBoxGridViewURIFooterTemplateTitle")).Text;
      uri      =  ( ( System.Web.UI.WebControls.TextBox ) GridViewURI.FooterRow.FindControl("TextBoxGridViewURIFooterTemplateURI")).Text;
      
      if ( sequenceOrderId > 0 )
      {
       SqlDataSourceURIGridView.InsertParameters["sequenceOrderId"].DefaultValue  =  System.Convert.ToString( sequenceOrderId );
      }
      if ( dated != DateTime.MinValue )
      {
       SqlDataSourceURIGridView.InsertParameters["dated"].DefaultValue            =  System.Convert.ToString( dated );
      }
      SqlDataSourceURIGridView.InsertParameters["keyword"].DefaultValue           =  keyword;
      SqlDataSourceURIGridView.InsertParameters["title"].DefaultValue             =  title;
      SqlDataSourceURIGridView.InsertParameters["uri"].DefaultValue               =  uri;
      SqlDataSourceURIGridView.Insert();
      
      break;
    }//switch ( gridViewCommandEventArgs.CommandName  )
   }//try
   catch ( System.Exception exception )
   {
    exceptionMessage = "System.Exception: " + exception.Message;
   }//catch ( System.Exception exception )
   if ( exceptionMessage != null )
   {
   	Feedback = exceptionMessage;
   	return;
   }//if ( exceptionMessage != null )
   GridViewURI.DataBind();
  }//public void GridViewURI_RowCommand()

  /// <summary>GridViewURI_RowDeleting</summary>
  public void GridViewURI_RowDeleting
  (
   Object                    sender, 
   GridViewDeleteEventArgs   gridViewDeleteEventArgs
  )
  {
   int          sequenceOrderId   =  -1;
   string       exceptionMessage  =  null;
   GridViewRow  gridViewRow       =  null;
   
   try
   {  	
    gridViewRow = GridViewURI.Rows[ gridViewDeleteEventArgs.RowIndex ];
    if ( gridViewRow == null )
    {
     return;
    }     	

    Int32.TryParse( ( ( System.Web.UI.WebControls.Label ) gridViewRow.FindControl("LabelGridViewURIItemTemplateSequenceOrderId")).Text, out sequenceOrderId );

    SqlDataSourceURIGridView.DeleteParameters["original_sequenceOrderId"].DefaultValue = sequenceOrderId.ToString();
	SqlDataSourceURIGridView.Delete();
	
   }//try
   catch ( Exception exception )
   {
   	exceptionMessage = exception.Message;
   }
   if ( exceptionMessage != null )
   {
    Feedback = exceptionMessage;
    return;
   }    	
  }//public void GridViewURI_RowDeleting()

  /// <summary>GridViewURI_RowUpdating</summary>
  /// <details>
  ///  http://fredrik.nsquared2.com/viewpost.aspx?PostID=173&amp;showfeedback=true Get a control or value from a GridView row.
  ///  http://www.chrisfrazier.net/blog/archive/category/1014.aspx
  /// </details>  
  public void GridViewURI_RowUpdating
  (
   Object                    sender, 
   GridViewUpdateEventArgs   gridViewUpdateEventArgs
  )
  {
   int          sequenceOrderId   =  -1;
   DateTime     dated;

   string       exceptionMessage  =  null;
   string       keyword           =  null;
   string       title             =  null;
   string       uri               =  null;
   
   GridViewRow  gridViewRow       =  null;
   
   try
   {  	
    gridViewRow = GridViewURI.Rows[ gridViewUpdateEventArgs.RowIndex ];
    if ( gridViewRow == null )
    {
     return;
    }     	

    Int32.TryParse( ( ( System.Web.UI.WebControls.Label ) gridViewRow.FindControl("LabelGridViewURIItemTemplateSequenceOrderId")).Text, out sequenceOrderId );
	DateTime.TryParse( ( ( System.Web.UI.WebControls.TextBox ) gridViewRow.FindControl("TextBoxGridViewURIEditItemTemplateDated")).Text, out dated );
    uri = ( ( System.Web.UI.WebControls.TextBox ) gridViewRow.FindControl("TextBoxGridViewURIEditItemTemplateURI")).Text;
    title = ( ( System.Web.UI.WebControls.TextBox ) gridViewRow.FindControl("TextBoxGridViewURIEditItemTemplateTitle")).Text;
    keyword = ( ( System.Web.UI.WebControls.TextBox ) gridViewRow.FindControl("TextBoxGridViewURIEditItemTemplateKeyword")).Text;

    SqlDataSourceURIGridView.UpdateParameters["original_sequenceOrderId"].DefaultValue = sequenceOrderId.ToString();
    if ( dated != DateTime.MinValue )
    {
  	 SqlDataSourceURIGridView.UpdateParameters["dated"].DefaultValue = dated.ToString();
  	} 
  	SqlDataSourceURIGridView.UpdateParameters["uri"].DefaultValue = uri;
  	SqlDataSourceURIGridView.UpdateParameters["title"].DefaultValue = title;
  	SqlDataSourceURIGridView.UpdateParameters["keyword"].DefaultValue = keyword;
	SqlDataSourceURIGridView.Update();
	
   }//try
   catch ( Exception exception )
   {
   	exceptionMessage = exception.Message;
   }
   if ( exceptionMessage != null )
   {
    Feedback = exceptionMessage;
    return;
   }
  }//public void GridViewURI_RowUpdating()

  /// <summary>GridViewURI_RowUpdated</summary>
  public void GridViewURI_RowUpdated
  (
   Object                    sender, 
   GridViewUpdatedEventArgs  gridViewUpdatedEventArgs
  )
  {
   // Use the Exception property to determine whether an exception
   // occurred during the insert operation.
   if ( gridViewUpdatedEventArgs.Exception != null )
   {
    // Insert the code to handle the exception.
    Feedback = gridViewUpdatedEventArgs.Exception.Message;

    // Use the ExceptionHandled property to indicate that the 
    // exception is already handled.
    gridViewUpdatedEventArgs.ExceptionHandled = true;

    // When an exception occurs, keep the GridView
    // control in edit mode.
    gridViewUpdatedEventArgs.KeepInEditMode = true;
   }//if ( GridViewUpdatedEventArgs.Exception != null )
  }//public void GridViewURI_ItemUpdated

 }//URIMaintenancePage class.
}//WordEngineering namespace.