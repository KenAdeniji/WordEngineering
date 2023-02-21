namespace PeopleSoft.ITDBA.reportWriter
{

    
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
        
    public class frmReport : System.Web.UI.Page
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
	   
	   protected Label LabelParameter1;
	   protected Label LabelParameter2;
	   protected Label LabelParameter3;	   
	   protected Label LabelParameter4;
	   protected Label LabelParameter5;
	   protected Label LabelParameter6;
	   	   

	   protected TextBox textParameter1;
	   protected TextBox textParameter2;
	   protected TextBox textParameter3;	   
	   protected TextBox textParameter4;
	   protected TextBox textParameter5;
	   protected TextBox textParameter6;
	   
	   protected DropDownList cbParameter1;
	   protected DropDownList cbParameter2;
	   protected DropDownList cbParameter3;
	   protected DropDownList cbParameter4;
	   protected DropDownList cbParameter5;
	   protected DropDownList cbParameter6;	   	   	   	   	   
	   	   
	   protected Label LabelInfo;         	   
	   protected Label LabelDebug;	   
	   protected Label LabelSQL;         	   	   
	   
	   protected DropDownList cbReportID; 	   
	   protected DropDownList cbReportType;
	   	   
       protected String strMemberID  = null;	   
       

       protected CheckBox chkPagedReport = null;
       protected CheckBox chkInaNewWindow;
       
       private String strReportStartDate = null;
       private String strReportEndDate = null;
              
       String strValidationErrMessage = null;
       
       protected Label labelMessage;    		       
       
       private string strSortExpression = null;       
       
       private ArrayList objListReports = null;
       
	   private static int CONTROL_TYPE_LABEL = 1;
	   private static int CONTROL_TYPE_TEXTBOX = 2;
	   private static int CONTROL_TYPE_DROPDOWN = 3;
	   
	   private static string CONTROL_NAME_PREFIX_LABEL = "LabelParameter";
	   private static string CONTROL_NAME_PREFIX_TEXTBOX = "textParameter";
	   private static string CONTROL_NAME_PREFIX_DROPDOWN = "cbParameter";	   
	   	   
	   private static String SESSION_APP_DATA_ENTRY = "REPORT_FORM";
	   
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
            strSQLGetReports = ConfigurationSettings.AppSettings["SQLGetReports"];            
            strSQLGetReportInfo = ConfigurationSettings.AppSettings["SQLGetReportInfo"];            
            strSQLGetReportParameter = ConfigurationSettings.AppSettings["SQLGetReportParameter"];            
                                    
            if (strSQLGetReports == null)
            {
				LabelInfo.Text = "ConfigurationSettings.AppSettings['SQLGetReports'] returned null";
				LabelInfo.Visible = true;	
				
				bConfigurationRead = false;
            }
            
            if (strSQLGetReportInfo == null)
            {
				LabelInfo.Text = "ConfigurationSettings.AppSettings['SQLGetReportInfo'] returned null";
				LabelInfo.Visible = true;	
				
				bConfigurationRead = false;
            }
             
                        
            return (bConfigurationRead);
            
       }             
        

       protected void Page_Load(Object Sender, EventArgs evt)
       {
       
       		Boolean bConfigurationRead = true;
       		Boolean bExcel = false;
       		       
            //Set the content type to Excel.
            Response.Buffer = true;
            
            if (IsPostBack)            
            {
                if (Request.QueryString["bExcel"] == "1" )
                {
                    bExcel = true;
                }            
                
            }
            else
            {
                 bExcel = false;                
                 cbReportType.SelectedIndex = 0;
                 chkInaNewWindow.Checked = false;
            }
            
            if (bExcel)
            {
                //Set the content type to Excel.
                Response.Buffer = true;
                                
                //Set the content type to Excel.
                Response.ContentType = "application/vnd.ms-excel";
                
                //Set the content type to Excel.
                Response.Expires = 0;                
            }    
                       
            bConfigurationRead = readConfigurationSettings();       
            
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
            
            strInit = Request["init"];
            
            //indicate whether to force a cache refresh
            if (strInit != null)
            {
	            if (strInit.CompareTo("y") == 0)
	            {
	                bForceCacheRefresh = true;   
	            }
	            else
	            {
	                bForceCacheRefresh = false;   
	            }            
            }
            
            if ((IsPostBack == false) || (bForceCacheRefresh == true) || (cbReportID.Items.Count == 0) )
            {   
                             
				              	                              
                bOK = populateReportCombobox();
                
                //select first entry
                //cbReportID.SelectedIndex = 0;
                
                if (bOK == false)
                {
					LabelDebug.Text = strLog;
					
                	strLog = "populateReportCombobox() failed " 
								+ objLogError.ToString() 
								+ "|" 
								+ objLog.ToString();
								
					LabelDebug.Visible = true;
					return;
                }
                
                //Commented out by DA on 1/17/2004 @ 18:48
                bOK = getReportParameters();

            }   
            else
            {
	            bOK = getReportParameters();            
			}
			
			if (bOK == false)
			{
				
				LabelDebug.Text = "getReportParameters() failed.  Error Log is " + objLogError.ToString();
				LabelDebug.Visible = true;
				
				LabelInfo.Text =  "getReportParameters() failed.  Log is " + objLog.ToString();
				
				if (strSQLGetReportParameter != null)
				{
					LabelInfo.Text = LabelInfo.Text + "<BR>" + "Param log is " + strSQLGetReportParameter;
				}
									
				LabelInfo.Visible = true;
				
				btnQuery.Enabled = false;
				btnQuery.Visible = false;
								
				return;	
				
			}
			
				            
            if ((IsPostBack == false) && (1==1))
            {
                
                bDataRestored = restoreDataFromCache();  

                                    
                if (bDataRestored)
                {
                   
                    reflectSelectedReport();
                                        
                    restoreDataFromCache();  
                    
                    //supper impose HTML & same window for post back is false
                    cbReportType.SelectedIndex = 0;
                
                    chkInaNewWindow.Checked = false;                    
                    
                    processSelectedReport();
                }                    
                else
                {
                    
                    //supper impose HTML & same window for post back is false
                    cbReportType.SelectedIndex = 0;
                
                    chkInaNewWindow.Checked = false;                    
                    
                   
                    reflectSelectedReport();
                }
                
                
            }   
            
            //btnQuery.Attributes.Add ("onclick",  "generateReport();");            
            
       }  //private void getBody()
           
        
       private Boolean populateReportCombobox()
       {
       
       		Boolean bDataReturned = false;
       		
			bDataReturned = populateCombobox(     PeopleSoft.ITDBA.reportWriter.reportID.REPORT_DROPDOWNID_ID.ToString()
												, cbReportID
							    				, strSQLGetReports);
							    				
			return (bDataReturned);		                             			                 							  								            
       
       }  //private void populateReportCombobox()       
       
       
       
       private Boolean populateCombobox( 
       									   string strID 
       									 , DropDownList objDropDownList
                                	     , String       strSQLQuery  )
       {
       
       
       		Boolean bDataReturned = false;
           
            try
            {
							
				PeopleSoft.AppCache.supportTableCache objSupportTableCache;
				
				objSupportTableCache = new PeopleSoft.AppCache.supportTableCache();
				
				objLog.Append("Populating drop down " +
							  "ID is " + strID + " " + 
				              "SQL is " + strSQLQuery);
				
				objSupportTableCache.Application = Application;
				objSupportTableCache.DBCommand = objDBCommand;
				objSupportTableCache.SQLQuery = strSQLQuery;
				objSupportTableCache.idApp = PeopleSoft.ITDBA.reportWriter.reportID.REPORT_APP_ID.ToString();				
				objSupportTableCache.ID = strID;
				
            	if (bForceCacheRefresh)
            	{
             	    objSupportTableCache.clearCache();
            	}
            					
				objSupportTableCache.fill(objDropDownList.Items, 0);
				
				if (objSupportTableCache.ErrorLog.Length > 0)
				{
					strLog = "Drop down populate error log is " + objSupportTableCache.ErrorLog + "<BR>";
					objLogError.Append(strLog);
				}
				
				objSupportTableCache = null;
				
				bDataReturned = true;
	            
	        }
			catch (Exception ex)
			{
				objLogError.Append("Exception occured in populateReportCombobox().  Exception is " + ex.Message);
			}	            
	
			return (bDataReturned);
       
       } //populateCombobox       
       
       
       private Boolean getReportParameters()
       {
       
          	reportList objReportList = null;
          	Boolean    bReportParameterListRetrieved = false;
            								           
            try
            {
            	
            	objReportList = new reportList();
            	
            	objReportList.Application = Application;
            	
            	objReportList.DBCommand = objDBCommand;
            	
            	objReportList.ID = PeopleSoft.ITDBA.reportWriter.reportID.REPORT_LIST_ID.ToString();            	
            	
            	objReportList.SQLQuery = strSQLGetReports;
            	objReportList.SQLGetReportInfo = strSQLGetReportInfo;            	            	
            	objReportList.SQLGetReportParameter = strSQLGetReportParameter;            	
            	
            	if (bForceCacheRefresh)
            	{
             	    objReportList.clearCache();
            	}
            	
            	objListReports = objReportList.Cache;
			    
			    bReportParameterListRetrieved = (objListReports != null);
			    
			    if (bReportParameterListRetrieved == false)
			    {
			     
    				objLogError.Append("Exception in reportTop.getReportParameters: " 
    				                 	+ "Error Log is " + objReportList.ErrorLog);				                 
							        
			    }
			    else
			    {
			    	objLog.Append("reportList::Log is " + objReportList.Log);
			    	
			    }

	        }
			catch (Exception ex)
			{
			    
			    			    
				objLogError.Append("Exception in reportTop.getReportParameters: " 
				                 	+ "Exception is " + ex.Message + "  " + "<BR>"				
				                 	+ "Log is " + objReportList.Log + "<BR>" 
				                 	+ "Error Log is " + objReportList.ErrorLog);				                 			    			    

			}	            

            return (bReportParameterListRetrieved);	
       
       } //private Boolean getReportParameters()            


       
	   protected void reportSelected(Object sender, EventArgs e) 
	   {
	    
    				    
			reflectSelectedReport();	   	
			
						
	   } //	   protected void reportSelected(Object sender, EventArgs e) 
	   
	   protected String getControlNamePrefix(int iControlIndex, int iControlType)
	   {
	    
	        String strControlName = null;
	        
	        //private static CONTROL_NAME_PREFIX_LABEL = "LabelParameter";
	        //private static CONTROL_NAME_PREFIX_TEXTBOX = "textParameter";
	        //private static CONTROL_NAME_PREFIX_DROPDOWN = "cbParameter";	   	        
	        
	        if (iControlType == CONTROL_TYPE_LABEL)
	        {
    	        strControlName = CONTROL_NAME_PREFIX_LABEL;
            }	    
	        else if (iControlType == CONTROL_TYPE_TEXTBOX)
	        {
    	        strControlName = CONTROL_NAME_PREFIX_TEXTBOX;
            }	    	    
	        else if (iControlType == CONTROL_TYPE_DROPDOWN)
	        {
    	        strControlName = CONTROL_NAME_PREFIX_DROPDOWN;
            }	 
            
            if (strControlName  != null)
            {
                strControlName =  strControlName + iControlIndex;  	                
            }
            
            return ( strControlName);                
            
            
	   } //protected String getControlNamePrefix(int iControlIndex, int iControlType)
	   
	   protected Control findControlBasedOnPosition(int iControlIndex, int iControlType)
	   {	
	       
	        String strControlName = null;
	        Control objControl = null;
	        
	        strControlName = getControlNamePrefix(iControlIndex, iControlType);
	        
	        if (strControlName == null)
	        {
	            return (null);
            }	            
            
            objControl = FindControl(strControlName);
            
            return (objControl);
	        
	   } //protected Control findControlBasedOnPosition(int iControlIndex, int iControlType)
	   
	   
	   	   
	   protected Control findControlArchive(int iControlIndex, int iControlType)
	   {
	    
	        if ((iControlIndex == 1) && (iControlType == 1))
	        {
	            return LabelParameter1;
	        }
	        else if ((iControlIndex == 1) && (iControlType == 2))
	        {
	            return textParameter1;
	        }	        
	        else if ((iControlIndex == 1) && (iControlType == 3))
	        {
	            return cbParameter1;
	        }	        
	        else if ((iControlIndex == 2) && (iControlType == 1))
	        {
	            return LabelParameter2;
	        }
	        else if ((iControlIndex == 2) && (iControlType == 2))
	        {
	            return textParameter2;
	        }	        
	        else if ((iControlIndex == 2) && (iControlType == 3))
	        {
	            return cbParameter2;
	        }	        	        
	        else if ((iControlIndex == 3) && (iControlType == 1))
	        {
	            return LabelParameter3;
	        }
	        else if ((iControlIndex == 3) && (iControlType == 2))
	        {
	            return textParameter3;
	        }	        
	        else if ((iControlIndex == 3) && (iControlType == 3))
	        {
	            return cbParameter3;
	        }	        	        
	        else if ((iControlIndex == 4) && (iControlType == 1))
	        {
	            return LabelParameter4;
	        }
	        else if ((iControlIndex == 4) && (iControlType == 2))
	        {
	            return textParameter4;
	        }	        
	        else if ((iControlIndex == 4) && (iControlType == 3))
	        {
	            return cbParameter4;
	        }	        	        
	        else if ((iControlIndex == 5) && (iControlType == 1))
	        {
	            return LabelParameter5;
	        }
	        else if ((iControlIndex == 5) && (iControlType == 2))
	        {
	            return textParameter5;
	        }	        
	        else if ((iControlIndex == 5) && (iControlType == 3))
	        {
	            return cbParameter5;
	        }	        	        
	        else if ((iControlIndex == 6) && (iControlType == 1))
	        {
	            return LabelParameter6;
	        }
	        else if ((iControlIndex == 6) && (iControlType == 2))
	        {
	            return textParameter6;
	        }	        
	        else if ((iControlIndex == 6) && (iControlType == 3))
	        {
	            return cbParameter6;
	        }	        	        	        	        	        
            else
	        {
	            return null;   
	        }	        
	        
	   } //protected Control findControlArchive(int iControlIndex, int iControlType)
      	   
	   

       
       
	  protected void BtnGetReportClicked(Object sender, EventArgs e) 
      {
           
		Boolean bOK = false;
		           
        bOK = processSelectedReport();      	
           
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
      
      protected Boolean processSelectedReport()
      {
       	
      	StringBuilder strScriptJS = null;
      	int           iSelectedIndex = -1;
      	int           iSelectedItemValue = -1;      	
      	Boolean       bOK = false;
      	String        strSelectedItemValue = null;
      	
      	Boolean       bInANewWindow = true;
      	int           iInANewWindow = 0;
      	
      	String        strReportType = null;
     	
      	iSelectedIndex = cbReportID.SelectedIndex;
      	
      	if (iSelectedIndex == -1)
      	{
      		return(bOK);	
      	}
      	
      	//strSelectedItemValue = cbReportID.SelectedValue;
      	
      	strSelectedItemValue = cbReportID.SelectedItem.Value;      	
      	
      	try
      	{
      		iSelectedItemValue = Int32.Parse(strSelectedItemValue);
		}
		catch (Exception ex)
		{
			objLogError.Append("processSelectedReport()::Unable to parse report drop down " + ex.Message); 
			return(bOK);	
		}      		
		
      	
      	bOK = tagSelectedReport(iSelectedItemValue, iSelectedIndex);
      	
      	if (bOK == false)
      	{
			objLogError.Append("processSelectedReport()::tag selected report failed"); 			
      		return(bOK);	
      	}


        if ((IsPostBack) || ( 1==1))           
        {

          	//get Report type
          	if (cbReportType.SelectedIndex == -1)
          	{
          		strReportType = "";
          	}
          	else
          	{
          		strReportType = cbReportType.SelectedItem.Value;
    		}      		
          	
          	bInANewWindow = chkInaNewWindow.Checked;
          	
          	if (bInANewWindow == true)
          	{
          		iInANewWindow = 1;
          	}
          	else
          	{
          		iInANewWindow = 0;
          	}      	
          	//chkInaNewWindow            
            
        }
        else
        {

      		strReportType = cbReportType.Items[0].Value;
            iInANewWindow = 0;              

        }    

      	objLog.Append("Report type is " + strReportType);
      	
      	strScriptJS = new StringBuilder();      	
      	
      	strScriptJS.Append("<script>");
      	
      	strScriptJS.Append("generateReport");
      	strScriptJS.Append("(");      	
      	strScriptJS.Append(iInANewWindow);      	      	
      	strScriptJS.Append(",");      	      	
      	strScriptJS.Append("'");      	      	      	
      	strScriptJS.Append(strReportType);      	    
      	strScriptJS.Append("'");      	      	      	      	  	      	
      	strScriptJS.Append(")");      	      	
      	
      	strScriptJS.Append("</script>");      	

		RegisterClientScriptBlock("btnRequestReportScript", strScriptJS.ToString());
		
		return (true);

      	
      } //	  protected void BtnGetReportClicked(Object sender, EventArgs e) 


      
      
      protected Boolean tagSelectedReport(int iReportID, int iSelectedIndex)
      {
      	
      	Boolean  		bOK = true;
      	ArrayList 		objReportParameterList = null;
      	int       		iNumberofParameters = -1;
      	int       		iParameterIndex = -1;
      	TextBox   		objTextBox = null;
      	DropDownList    objDropDown = null;
      	reportParameter objParameter = null;
      	String    		strParameter = "";
      	int             iParameterIndexAdjusted = -1;
      	Boolean         bDropDown = false;
      	String          strReportOption = null;
      	
   		reportType      objReportTypeShell = null;      		      	      	
   		reportType      objReportType = null;      		      	
   		Object          objGeneric = null; 
   		int             iNumberofReportNodes = -1;   
   		
   		String          strLog = null;  
   		Boolean         bReportParameterListRetrieved = false;		      	   		
   		
   		Object			objParameterValue = null;
   		String			strParameterValue = "";
   		
   		Boolean			bParameterValueFilled = false;
      	
      	try
      	{
      		
      		objReportType = new reportType();
      		
     		objReportType.SQLGetReports = strSQLGetReports;
     		objReportType.SQLGetReportInfo = strSQLGetReportInfo;
     		objReportType.SQLGetReportParameter = strSQLGetReportParameter;
     		     		      		
      		objReportType.DBCommand = objDBCommand;
      		
      		bOK = objReportType.queryReportInfo(iReportID);
      		
      		if (bOK == false)
      		{

                objLogError.Append("TagSelectedReport::ReportType.queryReportInfo Error Log is " +
                				   objReportType.ErrorLog + "<BR>");
								
				return(bOK);
      		} 
      		
            objLog.Append("Preparing to call getReportParameters()" + "<BR>");
      		
			bReportParameterListRetrieved = getReportParameters();      		
			
            objLog.Append("Called getReportParameters()!" + "<BR>");
            
			
			if (bReportParameterListRetrieved == false)
			{
				
                objLogError.Append("Unable to tag selected report::getReportParameters() returned false!");
	        			    
			    return(false);    
			}

            objLog.Append("Called getReportParameters()! returned true" + "<BR>");
                  		
      		if (objListReports == null)
      		{
      			
                objLogError.Append("objListReports is null!");
	            				
                return(false);      		    
      		}      		
      		
            objLog.Append("objListReports != null!");
      		
      		iNumberofReportNodes = objListReports.Count;
      		
      		//If things are not synched, then say so
      		if (iSelectedIndex > iNumberofReportNodes)
      		{
      		    objLogError.Append("tagSelectedReport::Selected report (" + 
      		    					iSelectedIndex + 
      		    					") is out of bounds (" + 
      		    					iNumberofReportNodes + ")");
            				
                return(false);      		    
      		}
      		
            objLog.Append("tagSelectedReport::Selected report (" + iSelectedIndex
      		                  + ") is in bounds (" + iNumberofReportNodes + ")"
      		                  + "Number of parameters is " + objReportType.parameterList.Count + "<BR>");
      		                  
     		
      		//get report node
      		objGeneric = objListReports[iSelectedIndex];
      		
      		//if unable to get generic node, then display error message stating so
      		if (objGeneric == null)
      		{
      		    
      		    objLogError.Append("tagSelectedReport::Unable to get pointer to report list. " 
      		             			+ "Attempted report id is " + iReportID + ".  "
      		             			+ "Number of nodes is (" + iNumberofReportNodes);
      		             
	            				
                return(false);      		    
      		}      		
      		
      		//Get report type node
      		objReportTypeShell = (reportType) objGeneric;
      		
      		//Create new "session" node based on existing "application" node
      		objReportType = new reportType(objReportTypeShell);
      		
      		if (objReportType == null)
      		{
      		    
      		    objLogError.Append("tagSelectedReport::Unable to get duplicate report node.  "
      		             			+ "Attempted report id is " + iReportID + ".  "
      		             			+ "Number of nodes is (" + iNumberofReportNodes + ")");
	            				
                return(false);      		    
      		}      		      	
      		
      		
      		//get report type parameter list
      		objReportParameterList = objReportType.parameterList;
      		
      		//count parameter list      		
      		iNumberofParameters = objReportParameterList.Count;
      		
            objLog.Append("tagSelectedReport::reportType::getReportParameters() -- " 
                           + "Number of parameters in shell is " + objReportTypeShell.parameterList.Count + "  "
                           + "Parameter list count in copy is " + iNumberofParameters);

      		
      		for (iParameterIndex = 0; 
      			 iParameterIndex < iNumberofParameters; 
      			 iParameterIndex++)
      		{
      			
      			iParameterIndexAdjusted = iParameterIndex + 1;
      			
      			bParameterValueFilled = false;
    			
                objLog.Append("tagSelectedReport::Iterating parameter list -- " 
                              + "Parameter iterator is " + iParameterIndexAdjusted) ;
                			
    			                                        
      			objTextBox = (System.Web.UI.WebControls.TextBox) findControlBasedOnPosition(iParameterIndexAdjusted
      			                                                                   , CONTROL_TYPE_TEXTBOX);    			                                        
      			
      			objDropDown = (System.Web.UI.WebControls.DropDownList) findControlBasedOnPosition(iParameterIndexAdjusted
      			                                                                   , CONTROL_TYPE_DROPDOWN);
      			
      			if (objTextBox == null)
      			{
      				
	                objLogError.Append("tagSelectedReport::Iterating parameter list -- parameter " +
	                				   iParameterIndexAdjusted + " text box was not found!");	

					return(bOK);
				}      			
				
      			if (objDropDown == null)
      			{
      			    
	                objLogError.Append("tagSelectedReport::Iterating parameter list -- parameter " +
	                				   iParameterIndexAdjusted + " dropdown was not found!");	
					return(bOK);
				}      			
								
      			objParameter = (reportParameter) objReportParameterList[iParameterIndex];
      			
				strParameterValue = ""; 	
      			
      			if (objParameter.parameterIsSystem)
      			{
					      				
      				objParameterValue = Session[objParameter.parameterName];
      				
      				if (objParameterValue != null)
      				{
      					if (objParameterValue is String)
      					{
      						
     			    		objParameter.parameterValue = (String) objParameterValue;
							strParameterValue = objParameter.parameterValue; 	
							
							bParameterValueFilled = true;
						}
						
					}	
					
					if (bParameterValueFilled == false)
					{
						
						objLogError.Append("parameter name is " + objParameter.parameterName + " " +
								  		   "it is a system parameter " + 	
					              		   "Session parameter name is " + objParameter.parameterName + " " +
					              		   "Session parameter as sysparm is " + objParameter.parameterNameAsSystemParameter + " " +
					              		   "Session parameter value is " + strParameterValue +
					              		   "<font color='red'>" + " System parameter not filled " + "</font>" +
					              	       "<BR>");
						
						return (bOK);
					}
					
					objLog.Append("parameter name is " + objParameter.parameterName + " " +
								  "it is a system parameter " + 	
					              "Session parameter name is " + objParameter.parameterName + " " +
					              "Session parameter as sysparm is " + objParameter.parameterNameAsSystemParameter + " " +
					              "Session parameter value is " + strParameterValue +
					              "<BR>");
					              										     			    		
      			}
      			else
      			{
      			    
									       			    
	      			bDropDown = objParameter.dropDown;
	      			
	      			if (bDropDown)
	      			{
	      			    objParameter.parameterValue = objDropDown.SelectedValue;
	                }      			    
	                else
	      			{
	      			    objParameter.parameterValue = objTextBox.Text;
	                }      			    
	                
					bParameterValueFilled = true;	                
	                
					objLog.Append("parameter name is " + objParameter.parameterName + " " +
								  "it is a non-system parameter " + 	
				        	      "parameter value is " + objParameter.parameterValue +
				        	      "<BR>");      				                
            	}
                      			
      			strParameter = strParameter +  objParameter.parameterValue + " ";
      			

      			
      		}
      		
			bOK = objReportType.validateReportParameters();      		
			//bOK = false;
			//return (false);
      		
      		if (bOK == false)
      		{

				objLog.Append("Report Parameters validation failed::Info log is " + objReportType.Log + "<HR>" +
   				              "Tag selected report log is " + objLog.ToString());				
				
				objLogError.Append("Report Parameters validation failed ::log is:: report type error log is " + 
				                   objReportType.ErrorLog + "<BR>" + 
				                   "tagSelectedReport::error log is "  +
				                   objLogError.ToString() + "<BR>");
								
				return(bOK);
      		}      		
      		
			
			objLog.Append("Report id is " + iReportID + " - " +
			              "Parms: " + iNumberofParameters + "] " + strParameter +
		                  "report type Log is " + objReportType.Log);
			                 
      		
      		strReportOption = PeopleSoft.ITDBA.reportWriter.reportID.REQUESTED_REPORT_OPTION.ToString();

			//set session var for report option      		
      		Session[strReportOption] = objReportType;
      		
			bOK = true;
      		
      		
		}
		catch (Exception ex)
		{
		    
			objLog.Append("Number of Parms is " + iNumberofParameters);
			
			objLogError.Append("Exception in tagSelectedReport " + ex.Message);
					
			bOK = false;
		}      		
      	
      	return (bOK);
      	
      	
      } //protected Boolean tagSelectedReport(int iReportID)
       

	   protected Boolean reflectSelectedReport()
	   {
 
 			int 		iSelectedIndex = cbReportID.SelectedIndex;
 			Object 		objPlain = null;
            reportType  objReport = null; 			
            int         iParameterIndex = -1;
            int         iParameterSecIndex = -1;
            int         iNumberofParms = -1;
            ArrayList   objParameterList = null;
            reportParameter objParameter = null;
            String      strParameterSQL = null;
            
            Label         objControlLabel = null;
            TextBox       objControlText = null;
            DropDownList  objControlDropdown = null;            
            
            Control     objControl = null;
            Boolean     bDropDown = false;
            
            Boolean     bReportParameterListRetrieved = false;
            
            int         iNumberofReports = -1;
            
            String      strLog = "Starting...";

            
            
            Boolean     bParameterIsSystem = false;
            
            int         iSavedSelectedDropdownIndex = -1;
            int         iDropdownNumberofEntries = -1;            
            
            Boolean		bOK = false;
            
            
            try
            {
    			
    			btnQuery.Enabled = false;  	
    			btnQuery.Visible = false;  	
    			
    			objLog.Append("Started getReportParameters().." + (DateTime.Now).ToString());
    			
    			bReportParameterListRetrieved = getReportParameters();
    			
    			objLog.Append("Ending getReportParameters(v1.0).." + (DateTime.Now).ToString());			
    			
    			if (bReportParameterListRetrieved == false)
    			{
    			    objLogError.Append("reflectSelectedReport()::bReportParameterListRetrieved == false" + (DateTime.Now).ToString());			
    			    return(bOK);   
    			}
    				       	
    	       	if (iSelectedIndex == -1)
    	       	{
    			    objLogError.Append("reflectSelectedReport()::iSelectedIndex == -1::");			
    	       		return(bOK);	
    	       	}
    	       	
    	       	
    	       	
    	       	if (objListReports == null)
    	       	{
    		       	objLogError.Append("reflectSelectedReport()::objListReports is blank");	       	    
    	       		return(bOK);	
    	       	}
    	       	
    			    	       	
    	       	//count number of reports
    	       	iNumberofReports = objListReports.Count;
    	       	
           	    
           	    if (iSelectedIndex >= iNumberofReports)
           	    {
           	        objLogError.Append("reflectSelectedReport():: " +
           	        				   "Selected index " + iSelectedIndex + " is out of bounds.  " +
           	                           "Number of reports (Bound) is " + iNumberofReports);
           	        return(bOK);	       		         	        
           	    }    	
    	       		       	
    			//get Report Object
    			objPlain = objListReports[iSelectedIndex];   
    			
           	    if (objPlain == null)
           	    {
           	        
           	        objLogError.Append("reflectSelectedReport()::report object (objPlain) is null");

           	        return(bOK);	       		         	                   	        
           	    }    				
    
    			objReport = (reportType) objPlain;
    			
    			if (objReport.parameterList == null)
    			{
           	        objLogError.Append("reflectSelectedReport()::objReport.parameterList is null");    	       	    
    	       	    return(bOK);
    			}
    			
    			//count # of parameters
    			iNumberofParms = (objReport.parameterList).Count;			
    			
    			objParameterList = (objReport.parameterList);
    			
    			hideAllParameterControls();
    			
    			
    			for (iParameterIndex = 1;  
    			     iParameterIndex <= iNumberofParms; 
    			     iParameterIndex++)
    			{
    			    
    			    objParameter = (reportParameter) objParameterList[iParameterIndex - 1];				
    			    
    			    //Is Parameter Visible
    			    bParameterIsSystem = objParameter.parameterIsSystem;
                        				    			    
    			    //If parameter Is System
    			    if (bParameterIsSystem == false)
    			    {
    
    				    objParameter.Application = Application;
    				    
    				    strParameterSQL = objParameter.parameterSQL;
    				    
    	                objControlLabel = (Label) findControlBasedOnPosition(  iParameterIndex
    	                                                                     , CONTROL_TYPE_LABEL );
    	                
    	                if (objControlLabel != null)
    	                {
    	                    objControlLabel.Visible = true;	       							        
    	                    
    					    objControlLabel.Text = (objParameter.parameterNameAsDisplay);			                        
    					    
    	                }                        
    	                    			    
    	
    				    //is Parameter a dropdown
    				    bDropDown = objParameter.dropDown;
    				    
    				    if (bDropDown)
    				    {
    				        
    	                    objControlDropdown = (DropDownList) findControlBasedOnPosition(    iParameterIndex
    	                                                                                     , CONTROL_TYPE_DROPDOWN);
    				        
    	                    if (objControlDropdown != null)
    	                    {
    				        			        
    				            objParameter.DBCommand = objDBCommand;
    				            
    				            iSavedSelectedDropdownIndex =  objControlDropdown.SelectedIndex;
   				            
    	                        objControlDropdown.Visible = true;	       							            				            
    				              
    	    			        objParameter.populateParamCombobox(objControlDropdown);
    	    			        
    	    			        if (objParameter.ErrorLog != String.Empty)
    	    			        
    	    			        {
    								//LabelInfo.Text = "Exception occurred in reportTop::reflectSelectedReport() " +
    			                 	//				 "Exception is " + objParameter.ErrorLog + "<BR>" +
    			                 	//				 "Log is " + objParameter.Log;    			                 
    			                 
    								//LabelInfo.Visible = true;    	    			        	
    	    			        	
    	    			        }
    	    			        else if (objControlDropdown.Items.Count == 0)
    	    			        {
    								//LabelInfo.Text = "No Exception in reportTop::reflectSelectedReport() " +
    			                 	//				 "Log is " + objParameter.Log;    			                 
    			                 
    								//LabelInfo.Visible = true;    	    			        	
								}    								    	    			        
    	    			        else
    	    			        {
    								//LabelInfo.Text = "No Exception in reportTop::reflectSelectedReport() " +
    			                 	//				 "Log is " + objParameter.Log;    			                 
    			                 
    								//LabelInfo.Visible = false;    	    			        	
								}    
																    	    			        								
    				            iDropdownNumberofEntries = objControlDropdown.Items.Count;    	    			        
    	    			        
    	    			        //if previously chosen data is still inclusive in new list
    	    			        //then select it
    	    			        if (iSavedSelectedDropdownIndex < iDropdownNumberofEntries)
    	    			        {
    	    			            objControlDropdown.SelectedIndex = iSavedSelectedDropdownIndex;
    	    			        }
    				        
    	    			        if (objParameter.ErrorLog != String.Empty)
    	    			        {
    	                            //LabelInfo.Text = "Error is " + objParameter.ErrorLog 
    	                            //                 + "<BR>" + " Log is " + objParameter.Log;
    	                            //LabelInfo.Visible = true;			        
    	                        }    
    	                        else                    
    	    			        {
    	                            //LabelInfo.Text = "Log is " + objParameter.Log;
    	                            //LabelInfo.Visible = true;			        
    	                        }                        			        
    	
   	                        
    	                    } //if (objControlDropdown != null)                        
    	                                        			        
    				    }
    				    else
    				    {
    	
    	                    objControlText = (TextBox) findControlBasedOnPosition(  iParameterIndex
    	                                                                          , CONTROL_TYPE_TEXTBOX);
    	                    
    	                    if (objControlText != null)
    	                    {
    	                        objControlText.Visible = true;	       							        
    	                    }                                            
    	
    				    }
    			    } //if (bParameterIsSystem == false)
    			    
    			} // for (iParameterIndex = 1; iParameterIndex <= iNumberofParms; iParameterIndex++)
    			
				bOK = true;
				
				btnQuery.Enabled = true;  	
			
				btnQuery.Visible = true;				
			
		    }
		    catch(Exception ex)
		    {
		        objLogError.Append("Exception occurred in reflectSelectedReport()::" + ex.Message);
		        
		        //strLog = "Number of parameters is " + iNumberofParms + ".  ";
		        //strLog = strLog + "Number of drop down entries is " + iDropdownNumberofEntries + ".  ";		        
		        //strLog = strLog + "Saved drop down entry position is " + iSavedSelectedDropdownIndex + ".  ";		        
		        		        
    			//LabelInfo.Text = "Exception occurred in reportTop::reflectSelectedReport() " +
    			//                 "Exception is " + strLogError + "<BR>" +
    			//                 "Exception Log is " + strLog;    			                 
    			          
    			LabelDebug.Text = objLogError.ToString();
    			LabelDebug.Visible = true;

		    }
		
			return (bOK);
			
       } //protected void reflectSelectedReport()
       
       
       protected void hideAllParameterControls()
       {
       
       		int     iParameterIndex = -1;
       		int     iParameterSecIndex = -1;
       		
       		Control objControl = null;
       		
			//Make all editable controls invisible
			for (iParameterIndex = 1;  iParameterIndex <= 6; iParameterIndex++)
			{
			    for (iParameterSecIndex = 1;  iParameterSecIndex <= 3; iParameterSecIndex++)			    
			    {
			        
                    objControl = findControlBasedOnPosition(   iParameterIndex
                                                             , iParameterSecIndex);
                    
                    if (objControl != null)
                    {
                        objControl.Visible = false;	       							        
                    }                        
                    
			    } //for (iParameterSecIndex = 1;  iParameterSecIndex <= 3; iParameterSecIndex++)		
			    	    
			} //for (iParameterIndex = 1;  iParameterIndex <= 6; iParameterIndex++)		       
			
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
				}
				else
				{
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
				return(bDataRestored);
			}
			
			if ((Session[SESSION_APP_DATA_ENTRY] is System.Collections.ArrayList) == false)
			{
				objLogError.Append("Cache is not empty.  But it is of wrong type.  It is of " 
				                    + Session[SESSION_APP_DATA_ENTRY].GetType()) ;
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
					return (bDataRestored);
				}
							
			objSessionState = null;		

			bDataRestored = true;
							
			return(bDataRestored);				
			
		}   		
					

    }


}