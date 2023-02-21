namespace PeopleSoft.ITDBA.reportWriter
{

    
    using System;
    using System.Collections;
    using System.Collections.Generic;	
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;        
    using System.Web.UI.WebControls;
	//using Microsoft.Reporting.WebForms; //Report Viewer Control
	//using Microsoft.Reporting.WebForms;	
	
    using System.ComponentModel;
    using System.Data;
    using System.Data.OleDb;
    using System.Web.Security;
    using System.Text;    //StringBuilder    
    using System.Configuration;    
	
	using System;
	using System.Data;
	using System.Data.SqlClient;
	using System.Configuration;
	using System.Collections;
	using System.Web;
	using System.Web.Security;
	using System.Web.UI;
	using System.Web.UI.WebControls;
	using System.Web.UI.WebControls.WebParts;
	using System.Web.UI.HtmlControls;
	//using Microsoft.ApplicationBlocks.Data;
	//using Microsoft.Reporting.WebForms;	
	using Microsoft.Reporting.WebForms;
    
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
	   protected Label labelReportName;
	   protected Label labelErrLog;
	   protected ReportViewer reportViewer;
	   protected DropDownList cbReport; 	   
	   
	   protected string strReportID = null;
	   	   
       protected String strMemberID  = null;	   
       

       protected CheckBox chkPagedReport = null;
       
       private String strReportStartDate = null;
       private String strReportEndDate = null;
              
       String strValidationErrMessage = null;
       
       protected Label labelMessage;    		       
       
       private string strSortExpression = null;     
       
       private String strErrorLog = "";
	   
	   private String strReportName = null;		   
	   
       private reportType objReportType = null;
       private reportParameter objReportParameter = null;	   
       
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
			
			labelCaption.Text = "";
			labelErrLog.Text = "";
            
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
       	

			
       		String 	   strSQL = null;
       		int		   iNumberofParameters = -1;
       		int        iParameterIndex = -1;	
       		ArrayList  objParameterList = null;
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
	      		strReportOption = 
					PeopleSoft.ITDBA.reportWriter.reportID.REQUESTED_REPORT_OPTION.ToString();
	       		
	       		//if report option is null, then no need to do more
	     		if ( (Session[strReportOption] == null) )
	     		{
				
					labelErrLog.Text = "Report Option is not defined";
	     			return;	
	     		}       		
	       		
	       		//get report option
	     		objReportType = (reportType) Session[strReportOption];       
	     		
				//labelCaption.Visible = true;
				
				labelErrLog.Text = "";
					
	     		if ( objReportType == null )
	     		{
					labelCaption.Text = "(objReportType == null)";
	     			return;	
	     		}
	     		
	     		objReportType.SQLGetReports = strSQLGetReports;
	       
	            labelCaption.Text = objReportType.reportName;
	            
	       		//get SQL
				strSQL = objReportType.reportSQL;
				
				iReportDataStoreID = objReportType.reportDataStoreID;    
				
				strReportDataStoreConnectionString = 
					objReportType.reportDataStoreConnectionString;    

				strReportName = objReportType.MSReportServicesURL;					
				//strReportName = objReportType.reportSQL;
					
			
				//Get # of parameters in list
				iNumberofParameters = objReportType.NumberofParameters;
				
				//get Parameter List
				objParameterList = objReportType.parameterList;
				
				labelSQL.Text = strSQL;
				//labelSQL.Visible = true;
				
				//labelErrLog.Text = "Joe -2 ";				
				publishGrid();
				

	            
	            
			}
			catch (Exception ex)
			{
				
				strErrorLog = 
						"Exception occurred in getBody(). Exception is " 
						+ ex.Message;
						
				labelErrLog.Text += strErrorLog;
				
				if (objDBCommandReport != null)				
				{
					if (objDBCommandReport.CommandText != null)
					{
						strErrorLog = strErrorLog 
									+ "Report SQL is " 
									+ objDBCommandReport.CommandText;				
					}						
				}
				
				labelInfo.Text = strErrorLog;
	            labelInfo.Visible = true;         						
				
			}
            
       }             
        
        

       
       
	   private void publishGrid()
	   {
	   
			String strReportBase = null;		   
			String strReportNameFull = null;	
			
		    strReportBase = "http://MSReportServices.ephraimtech.com/ReportServer";
			
/*
			
			strReportName = "/Models/ReportContactTasks";
			strReportName =  "/Report Project - Remindme"
							+"/Report - Contact Communication";
							
			strReportName = "/Models/ReportContactTasks";							
			strReportName = "/Models/ReportContactAddress";							
			
			//strReportName = 
			
*/			

			if (strReportName == null)
			{
			
				labelErrLog.Text = "1] Report Name is Null";
				
				if (objReportType.reportSQL == null)
				{
					labelErrLog.Text += "2] Report Type is Null";
				}
				else		
				{
					labelErrLog.Text += "3] Report SQL is " + objReportType.reportSQL;
				}
				
				return;
			}
			else
			{
				//labelErrLog.Text = "4] Report Name is Null";
			}
			
			strReportNameFull = strReportBase + strReportName;
			
			labelReportName.Text = "Report Name (full): " + strReportNameFull 
										+ "&nbsp;&nbsp;&nbsp"
										+ "Report Name (concise): " + strReportName;
										
			//http://community.discountasp.net/default.aspx?f=16&m=17808
			
			reportViewer.ProcessingMode 
				= Microsoft.Reporting.WebForms.ProcessingMode.Remote;

			reportViewer.ServerReport.ReportServerUrl = 
				new Uri(strReportBase);
				
			reportViewer.ServerReport.ReportPath = strReportName;

			setMSReportingServicesReportParameters();
			
			// Process and render the report
			//reportViewer.RefreshReport();			
			

			
	   }       

	   
	   void setMSReportingServicesReportParameters()
	   {
	   
			List<ReportParameter> paramList = new List<ReportParameter>();

			if ( 1 ==0)
			{
			
				paramList.Add(new ReportParameter("memberID", "51517064-0267-11D4-B8A6-006008408162", false));
				//paramList.Add(new ReportParameter("ReportMonth", "12", false));
				//paramList.Add(new ReportParameter("ReportYear", "2003", false));
				

				this.reportViewer.ServerReport.SetParameters(paramList);
				
			}
			
			
			{
			
				int		   iNumberofParameters = -1;
				int        iParameterIndex = 0;	
				ArrayList  objParameterList = null;
				
				String     strParameterName = null;
				String     strParameterValue = null;
				reportParameter objParameter = null;
				
				
			
				//Get # of parameters in list
				iNumberofParameters = objReportType.NumberofParameters;
				
				//get Parameter List
				objParameterList = objReportType.parameterList;		

				while (iParameterIndex < iNumberofParameters)
				{
				
					objParameter = (reportParameter) objReportType.parameterList[iParameterIndex];
				
					strParameterName = objParameter.parameterName;
					strParameterValue = objParameter.parameterValue;
					
					labelErrLog.Text = labelErrLog.Text
										 + iParameterIndex + ") " 
										 + "Report Parameter is " 
										 + strParameterName + " - "
										 + "Report Value is " 
										 + strParameterValue
										 + "<BR>";

					
					paramList.Add(new ReportParameter(
					                                      strParameterName
														//, "51517064-0267-11D4-B8A6-006008408162"
														, strParameterValue
														, false)
 								);
					
					++iParameterIndex;
					
				}
				
			}
			
			
		}	
        



    }


}