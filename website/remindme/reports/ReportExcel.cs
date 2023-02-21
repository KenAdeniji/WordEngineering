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
	   	   
       protected String strMemberID  = null;	   
       

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
       	
       		reportType objReportType = null;
       		String 	   strSQL = null;
       		int		   iNumberofParameters = -1;
       		int        iParameterIndex = -1;	
       		ArrayList  objParameterList = null;
       		reportParameter objReportParameter = null;
       		String     strParameterValue = null;
       		OleDbParameter objDBParameter = null;
       		int        iReportSQLType = -1;
       		String strReportOption = null;
       		
       		Boolean bNewConnection = false;
       		
       		int iReportDataStoreID = -1;
       		String strReportDataStoreConnectionString = null;       		       		
       		
      	
      		try
      		{
      				
	       		//strReportType = request("reporttype");
	       		strReportType = Request.QueryString["reporttype"];
	      		
	      		//determine report option id
	      		strReportOption = PeopleSoft.ITDBA.reportWriter.reportID.REQUESTED_REPORT_OPTION.ToString();
	       		
	       		//if report option is null, then no need to do more
	     		if (Session[strReportOption] == null)
	     		{
	     			return;	
	     		}       		
	       		
	       		//get report option
	     		objReportType = (reportType) Session[strReportOption];       
	     		
	     		if (objReportType == null)
	     		{
	     			return;	
	     		}
	     		
	     		objReportType.SQLGetReports = strSQLGetReports;
	       
	            labelCaption.Text = objReportType.reportName;
	            
	       		//get SQL
				strSQL = objReportType.reportSQL;
				
				iReportDataStoreID = objReportType.reportDataStoreID;    
				
				strReportDataStoreConnectionString = objReportType.reportDataStoreConnectionString;    
				
				//Get # of parameters in list
				iNumberofParameters = objReportType.NumberofParameters;
				
				//get Parameter List
				objParameterList = objReportType.parameterList;
				
				labelSQL.Text = strSQL;
				//labelSQL.Visible = true;
				
				if (strReportDataStoreConnectionString != null)
				{
				
				    if (strDBConnection.CompareTo(strReportDataStoreConnectionString) != 0)
				    {
				        bNewConnection = true;
	                }			        
				    
	            }
	            
	            if (bNewConnection)			    
	            {			    
	    			objConnectionReport = new OleDbConnection(strReportDataStoreConnectionString);
	    			
	    			objDBCommandReport = new OleDbCommand();
	    			
	    			objDBCommandReport.Connection = objConnectionReport;
	    			
	    			objDBCommandReport.CommandTimeout = iSQLQueryTimeoutInSecs;
	    			
	                objConnectionReport.Open();   
	                        
				}
				else
				{
	    			objConnectionReport = objConnection;
	    			objDBCommandReport = objDBCommand;    			
				}
	
	            if (bNewConnection)
	            {
	                //labelSQL.Text = "New connection needed " + bNewConnection + strReportDataStoreConnectionString;
	            }
	            else if(strReportDataStoreConnectionString == null)
	            {
	                //labelSQL.Text = "strReportDataStoreConnectionString is empty [" + iReportDataStoreID + "]";             
	            }
	            else
	            {
	                //labelSQL.Text = "New connection is not needed - Using existing connection " + strDBConnection;
	            }                            
	            labelSQL.Visible = false;         						
	                			
	            objDBCommandReport.CommandText = strSQL;			
				
				objDBCommandReport.Parameters.Clear();
				
				iReportSQLType = objReportType.reportSQLType;
				
				if (iReportSQLType == 1)
				{
	            	objDBCommandReport.CommandType = CommandType.StoredProcedure;   			            			
	            }
	            else
	            {
	            	objDBCommandReport.CommandType = CommandType.Text;   			            	
	            }
	
				
				//Iterate parameter list			
				for (iParameterIndex = 0;
				     iParameterIndex < iNumberofParameters;
				     iParameterIndex++)
				{
	
					objReportParameter = (reportParameter) objParameterList[iParameterIndex];	
	
					strParameterValue = objReportParameter.parameterValue;							
					
		            objDBParameter = new OleDbParameter();
		            
		            objDBParameter.OleDbType = OleDbType.VarChar;
		            objDBParameter.Size = 255;
		            objDBParameter.Value = strParameterValue; 
		            objDBCommandReport.Parameters.Add(objDBParameter);				
					
				}			     
	            
	            publishGrid();
	           
	            if (bNewConnection)
	            {
				    objDBCommandReport = null;
				       
	                objConnectionReport.Close();       
				    objConnectionReport = null;
	            }			    
	            
				//strErrorLog = "Report SQL is " + objDBCommandReport.CommandText;				
				
				//labelInfo.Text = strErrorLog;
	            //labelInfo.Visible = true;         						
	            
	            
			}
			catch (Exception ex)
			{
				
				strErrorLog = "Exception occurred in getBody(). Exception is " + ex.Message;
				
				if (bNewConnection)
				{
					strErrorLog = strErrorLog + "Errored connecting to report data store";
				}
				else
				{
					strErrorLog = strErrorLog + "Errored maintaining original db connection ";
								  
				}
				
				strErrorLog = strErrorLog + "Report SQL is " + objDBCommandReport.CommandText;				
				
				labelInfo.Text = strErrorLog;
	            labelInfo.Visible = true;         						
				
			}
            
       }             
        
        

       
       
	   private void publishGrid()
	   {
		
			ICollection objGridContents;
			
			
			//get Names
			objGridContents = executeGridSQL();
					
			//set data source
			gridReport.DataSource = objGridContents;
			
			//data Bind
			gridReport.DataBind();
			
			displayAsExcel();
			
	   }       


       private DataView executeGridSQL()
	   {
			

            OleDbDataAdapter objDbAdapter = null;			                                        			
			DataSet objDataSet = null;
		    DataView objDataView = null;	
		    			

            
            objDbAdapter = new OleDbDataAdapter();            
            
            objDbAdapter.SelectCommand = objDBCommandReport;
            
            objDataSet = new DataSet("gridContents");
                        
            objDbAdapter.Fill(objDataSet);						
			
			objDataView = objDataSet.Tables[0].DefaultView;
			
			return objDataView;
						
		}       	   

       void displayAsExcel()
       {
        
            //Verify if the page is to be displayed in Excel.
            if (strReportType == "Excel")
            {     
                       
                System.IO.StringWriter tw;
                System.Web.UI.HtmlTextWriter hw;
                
                labelCaption.Text = "";                
                labelCaption.Visible = false;                                
                                           
                //Set the content type to Excel.
                Response.ContentType = "application/vnd.ms-excel";
                
                //Remove the charset from the Content-Type header.
                Response.Charset = "";
                
                //Turn off the view state.
                EnableViewState = false;

                
                tw = new System.IO.StringWriter();
                
                hw = new System.Web.UI.HtmlTextWriter(tw);

                //Get the HTML for the control.
                gridReport.RenderControl(hw);
                
                //Write the HTML back to the browser.
                Response.Write(tw.ToString());
                
                //End the response.
                Response.End();
                
            }                

        }



                  
                  
                  
       private String getReportSQL(String strReportID)
       {
            
            String strReportSQL = null;
            
            OleDbDataReader objDBReader = null;
							
			strSQLQuery = "DBReport.dbo.sp_GetReportInfo";
		
            objDBCommand.CommandText = strSQLQuery;
            
            objDBCommand.CommandType = CommandType.StoredProcedure;            
            
            objDBCommand.Parameters.Clear();
            
            OleDbParameter objDBParameterReportID = new OleDbParameter();
            objDBParameterReportID.OleDbType = OleDbType.Integer;
            objDBParameterReportID.Value = strReportID; 
            objDBCommand.Parameters.Add(objDBParameterReportID);            
                
			
            objDBReader = objDBCommand.ExecuteReader();	
            
            
            while (objDBReader.Read())
            {

                strReportSQL = objDBReader["reportSQL"].ToString();
                                            
            }

            
            objDBReader.Close();
            
            objDBReader = null;
            
            return strReportSQL;
	
       
       }    
       
       

        
        
        private void displayAsExcel(DataTable objDataTable)
        {
            
            System.IO.StringWriter tw;
            System.Web.UI.HtmlTextWriter hw;
            
            //Verify if the page is to be displayed in Excel.
            //if (Request.QueryString["bExcel"] == "1" )
            {
                //Set the content type to Excel.
                Response.Buffer = true;
                                
                //Set the content type to Excel.
                Response.ContentType = "application/vnd.ms-excel";
                
                //Remove the charset from the Content-Type header.
                Response.Charset = "";
                
                //Turn off the view state.
                EnableViewState = false;

                tw = new System.IO.StringWriter();
                
                hw = new System.Web.UI.HtmlTextWriter(tw);

                //Get the HTML for the control.
                gridReport.RenderControl(hw);
                //labelSQL.Text = "False is not good!";
                //labelSQL.Visible = true;
                //labelSQL.RenderControl(hw);
                
                //Write the HTML back to the browser.
                Response.Write(tw.ToString());
                
                //Response.Write("<HR><H1>JOY</H1>");
                //End the response.
                Response.End();
            }

        } //displayAsExcel


    }


}