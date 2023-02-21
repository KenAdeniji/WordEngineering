 
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
    
    
    using PeopleSoft.ITDBA.reportWriter;
    using PeopleSoft.ITDBA.ASPNET.Form;
        
    public class _default : System.Web.UI.Page
    {
      
       
       private String strDBConnection = null;
       private String strSQLGetReports = null;
       private String strSQLGetReportInfo = null;
       private String strSQLGetReportParameter = null;
                                               
       private OleDbConnection objConnection = null;
       private OleDbCommand objDBCommand = null;       
       private OleDbDataAdapter objDbAdapter = null;			                                        
       
	   private String strSQLQuery;
	   
	   protected Button btnQuery;	 	   
	   protected Button btnQueryHidden;
	   
	   protected DataGrid gridReport;	 
	   
	   protected TextBox txtMediaSearchTag;	   
	   protected Label LabelInfo;         	   
	   protected Label LabelDebug;	   
	   protected Label LabelSQL;         	   	   

	   	   
       protected String strMemberID  = null;	   
       

       protected CheckBox chkPagedReport = null;
       protected CheckBox chkInaNewWindow;
       
       private String strReportStartDate = null;
       private String strReportEndDate = null;
              
       String strValidationErrMessage = null;
       
       protected Label labelMessage;    		       
       
       private string strSortExpression = null;       
       

	   	   
	   private static String SESSION_APP_DATA_ENTRY = "DOCUMENT_ATTACHMENT_FORM";
	   private static String SESSION_ATTACHMENT_FILTER = "SearchAttachmentTag";
	   private static String LINE_BREAK = "<BR>";
	   
	   private Boolean bForceCacheRefresh = false;	   
	   
       private PeopleSoft.ITDBA.ASPNET.Form.sessionState objSessionState = null;
       
       private String strLog = null;
       private String strLogError = null;       
       
       private StringBuilder objLog = new StringBuilder();
       private StringBuilder objLogError = new StringBuilder();       
              
        //read configuration settings                                                                         
       protected Boolean readConfigurationSettings()
       {
			       	
       		Boolean bConfigurationRead = true;
       		
            strDBConnection = ConfigurationSettings.AppSettings["oleDBConnection.ConnectionString"];
                        
            return (bConfigurationRead);
            
       }             
        

       protected void Page_Load(Object Sender, EventArgs evt)
       {
       
       		Boolean bConfigurationRead = true;
                       
            bConfigurationRead = readConfigurationSettings();       
            
			LabelDebug.Text = "";
			
            if (bConfigurationRead == false)
            {
				LabelDebug.Text = "Page_Load::Configuration read is false";
				LabelDebug.Visible = true;            	
            	return;	
            }
       
			objConnection = new OleDbConnection(strDBConnection);
			
			objDBCommand = new OleDbCommand();
			
			objDBCommand.Connection = objConnection;
			        
            objConnection.Open();
           
            getBody();                     


            
       }                                               
        
        
       protected void Page_UnLoad(Object Sender, EventArgs evt)
       {
            
			objDBCommand = null;
			       
            if (objConnection != null)
            {			       
                objConnection.Close();       
            }                
            
			objConnection = null;
        
       }  //protected void Page_UnLoad(Object Sender, EventArgs evt)             
    
	
       private void getBody()
       {
       
            string strInit = null;
            Boolean bDataRestored = false;
            Boolean bOK = false;
            
				            
            if (IsPostBack == false)
            {
                
				LabelDebug.Text = LabelDebug.Text + "Restoring data from cache...";
				
                bDataRestored = restoreDataFromCache();  

                                    
                if (bDataRestored)
                {
                                        
                    restoreDataFromCache();  
                    
                }                    
                else
                {
                    //reflectSelectedReport();
                }
                
                
            }   
            
            //btnQuery.Attributes.Add ("onclick",  "generateReport();");            
            
       }  //private void getBody()
           
        

      	   
	   

       
       
	  protected void BtnGetReportClicked(Object sender, EventArgs e) 
      {
           
		Boolean bOK = false;
		           
        //bOK = processSelectedReport();      	
           
        //LabelDebug.Text ="";
      	saveDataIntoCache();      	
      	    
      	if (bOK == false)
      	{
      	
      		LabelDebug.Text = "processSelectedReport():: failed " + objLogError.ToString();
      		LabelDebug.Visible = true;   	
      	    	
      	}
      	else
      	{
      		LabelDebug.Visible = false;   		
      	}
      	
      	//LabelInfo.Visible = true;
      	//LabelInfo.Text = objLog.ToString();
      	    
      }
      
	  
        protected void saveDataIntoCache()
        {
        	
			PeopleSoft.ITDBA.ASPNET.Form.sessionState objSessionState = null; 
			ArrayList objFormControlStateCollection = null;       	
			String strLog = null;
			String strLogError = null;
						
			objSessionState = new PeopleSoft.ITDBA.ASPNET.Form.sessionState();
			
				objSessionState.page = Page;
				objFormControlStateCollection = objSessionState.state;
				
				strLog = objSessionState.getLog();
				strLogError = objSessionState.getLogException();				
				
				if (strLogError.Length != 0)
				{
					LabelInfo.Text = strLogError;					
				    LabelInfo.Visible = true;					
					
					LabelDebug.Text = LabelDebug.Text + LINE_BREAK + "Cache is not properly saved";				
				
				}
				else
				{
				
					LabelDebug.Text = LabelDebug.Text + LINE_BREAK + "Cache is saved";				
				
					//LabelInfo.Text = strLog;					
				    LabelInfo.Visible = false;										
					
				}				
				
				//sava data into cache
		        Session[SESSION_APP_DATA_ENTRY] =  objFormControlStateCollection;
				

							
			objSessionState = null;			
			
		}   
		
      
        protected Boolean restoreDataFromCache()
        {
        	
			ArrayList objFormControlStateCollection = null;       	
			Boolean bDataRestored = false;
			
						
			if (Session[SESSION_APP_DATA_ENTRY] == null)
			{
				LabelDebug.Text = LabelDebug.Text + LINE_BREAK + "(Session[SESSION_APP_DATA_ENTRY] == null)";
				return(bDataRestored);
			}
			
			if ((Session[SESSION_APP_DATA_ENTRY] is System.Collections.ArrayList) == false)
			{
				objLogError.Append("Cache is not empty.  But it is of wrong type.  It is of " 
				                    + Session[SESSION_APP_DATA_ENTRY].GetType()) ;
									
				LabelDebug.Text = LabelDebug.Text + LINE_BREAK + "Cache is not empty.  But it is of wrong type.";
				
				return(bDataRestored);
			}
						
			//sava data into cache
	        objFormControlStateCollection = (ArrayList) Session[SESSION_APP_DATA_ENTRY];			
						
			objSessionState = new PeopleSoft.ITDBA.ASPNET.Form.sessionState();
			
				objSessionState.page = Page;
				objSessionState.FormControlStateCollection = objFormControlStateCollection ;
				
				objSessionState.setFormState();
				
				objLog.Append( objSessionState.getLog());
				objLogError.Append(objSessionState.getLogException());				
				
				if ((objLogError.ToString()).Length != 0)
				{

					LabelDebug.Text = LabelDebug.Text + LINE_BREAK + "Cache restored";
								
					return (bDataRestored);
				}
							
			objSessionState = null;		

			bDataRestored = true;
							
			return(bDataRestored);				
			
		}  

	protected void AnchorSearchBtnClick( Object objSource, EventArgs objEvent)
	{
	
		btnFilterClicked(objSource, objEvent);                        

	}
		

	//Called when button btnFilter is clicked        
	protected void btnFilterClicked(Object Sender, EventArgs E)
	{
	
		//getDataEntryDataSave();
		
		//getDBApps();        
		
		//gridMedia.DataBind();
		
		dataEntryDataSave();
		
		saveDataIntoCache();
	
	}
	
	
	private void dataEntryDataSave()
	{
		
	   	//saveData
        Session[SESSION_ATTACHMENT_FILTER] = txtMediaSearchTag.Text;
		
    }  

	
	 protected  void GridViewRowCommand(object sender, GridViewCommandEventArgs e)
	{

		if (e.CommandName == "Select")
		{
		
			String strDocumentAttachmentIdentifier = null;
			
			// get the Document Attachment Identifier
			strDocumentAttachmentIdentifier = Convert.ToString(e.CommandArgument); 
			
			// process Attachment Reauest
			processAttachmentRequest(strDocumentAttachmentIdentifier); // Implement this on your own :)
		
		}
	
	}


      protected Boolean processAttachmentRequest(String strDocumentAttachmentIdentifier)
      {
       	
      	StringBuilder strScriptJS = null;
      	Boolean       bOK = false;

      	
      	strScriptJS = new StringBuilder();      	
      	
      	strScriptJS.Append("<script>");

			strScriptJS.Append("renderAttachment");
			strScriptJS.Append("(");			
				strScriptJS.Append("'" + strDocumentAttachmentIdentifier + "'");						
			strScriptJS.Append(")");						
      	
      	strScriptJS.Append("</script>");      	

		RegisterClientScriptBlock("btnRequestAttachmentScript", strScriptJS.ToString());
		
		return (true);

      	
      } //	  protected void BtnGetReportClicked(Object sender, EventArgs e) 	
 		
					

    }


