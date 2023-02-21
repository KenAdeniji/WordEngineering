    
	//http://www.codeproject.com/useritems/Store_and_manipulat_BLOBs.asp
	//Store and retrieve objects as BLOBs in SQL server 2000 using ASP.Net 2.0
	//By Ziyad Mohammad. 
	
	//GridView Confirm When Delete By AzamSharp 
	//http://www.gridviewguy.com/ArticleDetails.aspx?articleID=138
	
    using System;
    using System.Collections;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;        
    using System.Web.UI.WebControls;
    using System.ComponentModel;
    using System.Data;
    using System.Data.OleDb;
    using System.Web.Security;
    using System.Text;    //StringBuilder    
    using System.Configuration;    
    using System.IO;    
    
    using PeopleSoft.ITDBA.reportWriter;        
    

    

    public class _defaultBottom : System.Web.UI.Page
    {
       
       
       private String strContact = null;
       
       private String strDBConnection = null;
                                        
       private OleDbConnection objConnection = null;
       private OleDbCommand objDBCommand = null;       
       private OleDbDataAdapter objDbAdapter = null;			                                        
       
       private OleDbConnection objConnectionReport = null;
       private OleDbCommand objDBCommandReport = null;       
       private OleDbDataAdapter objDbAdapterReport = null;			                                               
       
       private int iASPScriptTimeoutInSecs = -1;
	   private String strSQLQuery;
	   private int    iSQLQueryTimeoutInSecs = -1;
	   
	   private string strSQLGetReports;
       private String strReportType;	   
	   protected DataGrid gridReport;	 
	   
	   protected Label labelSQL;         
	   protected Label labelInfo;         	   
	   protected Label labelCaption;
	   
	   protected DropDownList cbReport; 	   
	   
	   protected string strReportID = null;
	   	   
       protected String strMemberID = null;	   
	   protected String strMemberName = null;	   
       private String strDocumentAttachmentId = null;

       protected CheckBox chkPagedReport = null;
       
       private String strReportStartDate = null;
       private String strReportEndDate = null;
              
       String strValidationErrMessage = null;
       
       protected Label labelMessage;    		       
       
       private string strSortExpression = null;     
       
       private String strErrorLog = null;
       
       //private static String REQUESTED_REPORT_OPTION = "REQUESTED_REPORT_OPTION";  
       
        //read configuration settings                                                                         
       protected void readConfigurationSettings()
       {
       		String strValue;
       		
            try
            {
            	strValue = ConfigurationSettings.AppSettings["ASPScriptTimeoutInSecs"];
            	
            	iASPScriptTimeoutInSecs = Int32.Parse(strValue);
			}
			catch(Exception)
			{
				iASPScriptTimeoutInSecs = 60 * 60 * 120;				
			}            	                   		
       		
            strDBConnection = ConfigurationSettings.AppSettings["oleDBConnection.ConnectionString"];
            
            try
            {
            	strValue = ConfigurationSettings.AppSettings["SQLQueryTimeoutInSecs"];
            	
            	iSQLQueryTimeoutInSecs = Int32.Parse(strValue);
			}
			catch(Exception)
			{
				iSQLQueryTimeoutInSecs = 60 * 60 * 120;				
			}            	

            strSQLGetReports = ConfigurationSettings.AppSettings["SQLGetReports"];            

       }             
        

       protected void Page_Load(Object Sender, EventArgs evt)
       {

                       
            readConfigurationSettings();    
            
            //Server Script timeout
            Server.ScriptTimeout = iASPScriptTimeoutInSecs;
       
			objConnection = new OleDbConnection(strDBConnection);
			
			objDBCommand = new OleDbCommand();
			
			objDBCommand.Connection = objConnection;
			
			objDBCommand.CommandTimeout = iSQLQueryTimeoutInSecs;
			        
            objConnection.Open();
            
            //getUserInfo();
           
            getBody();                     
            
       }                                               
        
        
       protected void Page_UnLoad(Object Sender, EventArgs evt)
       {
            
			objDBCommand = null;
			       
            objConnection.Close();       
			objConnection = null;
			

        
       }               
       

       private void getBody()
	   {
	   
			strDocumentAttachmentId = Request["documentAttachmentIdentifier"];
			
			getUserInfo();
	   
			writeDocumentWithStreaming();
			
	   }
       
	   
		private void writeDocumentWithStreaming()
		{
		
			string docuid = "864d9871-b6f2-41ec-8a4d-615bd0f03763";// Request.QueryString["docid"].ToString(); 
			//Connection and Parameters
			OleDbParameter paramMemberID = null;
			OleDbParameter paramDocumentAttachmentId = null;
			
			OleDbCommand cmd = new OleDbCommand("dbo.usp_getDocumentAttachment", objConnection);
			
			cmd.CommandType = CommandType.StoredProcedure;
			
			paramMemberID = new OleDbParameter("@memberID", OleDbType.VarChar, 255);
			paramMemberID.Direction = ParameterDirection.Input;
			paramMemberID.Value = strMemberID;
			cmd.Parameters.Add(paramMemberID);

			paramDocumentAttachmentId = new OleDbParameter("@documentAttachmentId", OleDbType.VarChar, 255);
			paramDocumentAttachmentId.Direction = ParameterDirection.Input;
			paramDocumentAttachmentId.Value = strDocumentAttachmentId;
			cmd.Parameters.Add(paramDocumentAttachmentId);
			
			//Open connection and fetch the data with reader
			
			OleDbDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
			
			if (reader.HasRows)
			{
				reader.Read();
				//
				string doctype = reader["contentType"].ToString();
				string docname = reader["attachmentFilename"].ToString();
				//
				Response.Buffer = false; 
				Response.ClearHeaders();
				Response.ContentType = doctype;
				Response.AddHeader("Content-Disposition", "attachment; filename=" + docname); 
				//
				//Code for streaming the object while writing
				const int ChunkSize = 1024;
				byte[] buffer = new byte[ChunkSize];
				byte[] binary = (reader["attachment"]) as byte[];
				MemoryStream ms = new MemoryStream(binary);
				int SizeToWrite = ChunkSize;
		
				for (int i = 0; i < binary.GetUpperBound(0)-1; i=i+ChunkSize)
				{
					if (!Response.IsClientConnected) return;
					if (i + ChunkSize >= binary.Length) SizeToWrite = binary.Length - i;
					byte[] chunk = new byte[SizeToWrite];
					ms.Read(chunk, 0, SizeToWrite);
					Response.BinaryWrite(chunk);
					Response.Flush();
				}
				
				Response.Close(); 
				
			} //if (reader.HasRows)
			
		} //WriteDocumentWithStreaming()
		
		
        protected void getUserInfo()
        {
        
            System.Security.Principal.IIdentity objIdentity;
            Boolean bAuthenticated;
        
            objIdentity = User.Identity;
            
            bAuthenticated = objIdentity.IsAuthenticated;
            strMemberName = objIdentity.Name;
            
            if (Session["memberID"] != null)
            {
            	strMemberID = Session["memberID"].ToString();
            }	

            
        }        		

	}
	
