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
    
    public class frmReport : System.Web.UI.Page
    {
      
       
       private String strDBConnection = null;
       private String strSQLGetReports = null;
                                        
       private OleDbConnection objConnection = null;
       private OleDbCommand objDBCommand = null;       
       private OleDbDataAdapter objDbAdapter = null;			                                        
       
	   private String strSQLQuery;
	   	   
	   protected Label LabelInfo;         	   
	   protected Label LabelSQL;         	   	   

       private StringBuilder objLog = new StringBuilder();    	
       private StringBuilder objErrorLog = new StringBuilder();    	        	   
	   	   
	   
	   private Boolean bForceCacheRefresh = true;	   
        

       protected void Page_Load(Object Sender, EventArgs evt)
       {
			           
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
        
       		Boolean bConfigurationRead = true;
                       
            bConfigurationRead = readConfigurationSettings();       
            
            if (bConfigurationRead == false)
            {
            	return;	
            }
       
			objConnection = new OleDbConnection(strDBConnection);
			
			objDBCommand = new OleDbCommand();
			
			objDBCommand.Connection = objConnection;
			        
            objConnection.Open();
        
            clearReportParametersDropDown();       
				              	                              
            populateReportCombobox();
            
			LabelInfo.Text = objLog.ToString();
			LabelInfo.Visible = true;
            
       }  //private void getBody()
           

       protected Boolean readConfigurationSettings()
       {
			       	
       		Boolean bConfigurationRead = true;
       		
            strDBConnection = ConfigurationSettings.AppSettings["oleDBConnection.ConnectionString"];
            
            return (bConfigurationRead);
            
       }             
        
       private void populateReportCombobox()
       {
       
			populateCombobox(     PeopleSoft.ITDBA.reportWriter.reportID.REPORT_DROPDOWNID_ID.ToString()
								, null
							    , strSQLGetReports);                             			                 							  								            
							    
							    
       
       }  //private void populateReportCombobox()       
       
       
       
       private void populateCombobox( 
       								   string strID 
       								 , DropDownList objDropDownList
                                     , String       strSQLQuery  )
       {
       
       

           
            try
            {
							
				PeopleSoft.AppCache.supportTableCache objSupportTableCache;
				
				objSupportTableCache = new PeopleSoft.AppCache.supportTableCache();
				
				objSupportTableCache.Application = Application;
				objSupportTableCache.SQLQuery = strSQLQuery;
				objSupportTableCache.idApp = PeopleSoft.ITDBA.reportWriter.reportID.REPORT_APP_ID.ToString();				
				objSupportTableCache.ID = strID;
				

           	    objSupportTableCache.clearCache();
				
				objSupportTableCache = null;
				
				objLog.Append("reportInit::cleared Support Table Cache " + strID + "<BR>");				
	            
	        }
			catch (Exception ex)
			{
				LabelInfo.Text = "Exception occured in populateReportCombobox().  Exception is " 
								 + ex.Message;
				LabelInfo.Visible = true;	
			}	            
	
       
       } //populateCombobox       
       
       
       private Boolean clearReportParametersDropDown()
       {
       
            String     strLog = "";
            String     strErrorLog = "";
          	Boolean    bDropDownCacheCleared = false;
          	ArrayList  objReportParameterList = null;
          	int        iNumberofReportParameters = -1;
          	int        iParameterIndex = 0;

		    OleDbDataReader	objDBReader	= null;
		    
		    String     strSQLQuery;
		    String     strParamName;
		    
		    PeopleSoft.AppCache.supportTableCache objSupportTableCache = null;
			                								           
            try
            {
                
                bDropDownCacheCleared = false;
                                
                objReportParameterList = new ArrayList();
                
    			if (objDBCommand ==	null)
    			{
    				//fill error log
    				objErrorLog.Append("Validation failed in reportInit::clearReportParametersDropDown. " +
    								   "DBCommand not specified");
    								   
    				LabelInfo.Text = objErrorLog.ToString();
	    			LabelInfo.Visible = true;	
    								   
    				return(false);	 
    			}
		   
		        strSQLQuery = "select paramName from reportParam order by paramName";
							
				objDBCommand.CommandText = strSQLQuery;
				
				objDBCommand.CommandType = CommandType.Text;			
				
				objDBCommand.Parameters.Clear();
				
				objDBReader	= objDBCommand.ExecuteReader();	
				
				objLog.Append("SQL Query is	" +	strSQLQuery);
				
				iNumberofReportParameters =	0;
				
				while (objDBReader.Read())
				{
					
					//objLog.Append("Iterating recordset");
									
					strParamName =	objDBReader["paramName"].ToString();

					iNumberofReportParameters =	iNumberofReportParameters +	1;					
					
					objLog.Append("Read Parameter " + iNumberofReportParameters + ") " + strParamName);					
					
					objReportParameterList.Add(strParamName);
					
					
				}
	
				
				objDBReader.Close();
				
			    objSupportTableCache = new PeopleSoft.AppCache.supportTableCache();
			    
			    objSupportTableCache.Application = Application;
				
				for (iParameterIndex = 0; 
				     iParameterIndex < iNumberofReportParameters; 
				     iParameterIndex ++)
				{
				    
				    if (objReportParameterList[iParameterIndex] != null)
				    {
				        objSupportTableCache.ID = objReportParameterList[iParameterIndex].ToString();
				        
				        objSupportTableCache.clearCache();
				        
				        objErrorLog.Append(objSupportTableCache.ErrorLog);
				        
				        objLog.Append(objSupportTableCache.Log);				        
				        
                    }				        
				    
				}
				
            	
            	bDropDownCacheCleared = true;
            	
				objLog.Append("All is well in reportInit::clearReportParametersDropDown()");

				            	
	        }
			catch (Exception ex)
			{
			    			    
				LabelInfo.Text = "Exception in reportInit::clearReportParametersDropDown() " 
				                 + "Exception is " + ex.Message + "  " + "<BR>"
				                 + "Log is " + strLog + "<BR>"
				                 + "Error Log is " + strErrorLog + "<BR>"
				                 + "DB Connect String is " + strDBConnection;
				                 
				LabelInfo.Visible = true;	
			}	            

            return (bDropDownCacheCleared);	
       
       } //private Boolean clearReportParametersDropDown()            

    }


}