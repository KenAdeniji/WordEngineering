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
    using System.Collections;    
    using PeopleSoft.ITDBA.reportWriter;        
    

    

    public class frmReport : System.Web.UI.Page
    {
       
       
       private String strContact = null;
       
       private String strDBConnection = null;
                                        
       private OleDbConnection objConnection = null;
       private OleDbCommand objDBCommand = null;       
       private OleDbDataAdapter objDbAdapter = null;			                                        
       
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
	   protected DropDownList cbADGroup; 	   	   
	   
	   protected string strReportID = null;
	   	   
       protected String strMemberID  = null;	   
       

       protected CheckBox chkPagedReport = null;
       
       private String strReportStartDate = null;
       private String strReportEndDate = null;
              
       String strValidationErrMessage = null;
       
       protected Label labelMessage;    		       
       
       private string strSortExpression = null;     
       
       private static String REQUESTED_REPORT_OPTION = "REQUESTED_REPORT_OPTION";  
       
       private DataTable objDataTable = null;
       

       protected StringBuilder strLog = new StringBuilder();       
       
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
				iASPScriptTimeoutInSecs = 60 * 60 * 3;				
			}            	                   		
       		
            strDBConnection = ConfigurationSettings.AppSettings["oleDBConnection.ConnectionString"];
            
            try
            {
            	strValue = ConfigurationSettings.AppSettings["SQLQueryTimeoutInSecs"];
            	
            	iSQLQueryTimeoutInSecs = Int32.Parse(strValue);
			}
			catch(Exception)
			{
				iSQLQueryTimeoutInSecs = 60 * 60 * 3;				
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
            
            getUserInfo();
           
            if (IsPostBack == false)
            {            
	            getBody();                     
			}
            
       }                                               
        
        
       protected void Page_UnLoad(Object Sender, EventArgs evt)
       {
            
			objDBCommand = null;
			       
            objConnection.Close();       
			objConnection = null;
			

        
       }               
       

       
       
       private void getBody()
       {
        
            populateCombobox(cbADGroup, "dbo.pssp_getADGroups");

            
       }             

       
       private void getADGroupMembers()
       {
        
            String strADGroup = null;
            
            if (cbADGroup.SelectedValue == String.Empty)
            {
            	return;
            }
            
            //strADGroup = "LDAP://CN=PSH-CTI-DEV,OU=Global,OU=Groups,OU=USA-Pleasanton,DC=CORP,DC=PEOPLESOFT,DC=COM";                                    
            //strADGroup = "PSH-CTI-DEV";                                                
            //strADGroup = "PSH-CorpDatabase Svc";     
            
            strADGroup = cbADGroup.SelectedValue;   

            //labelInfo.Text = "Selected item value " + strADGroup;            
            //labelInfo.Visible = true;
            
            //return;   
            
            //strADGroup = "PSH-CorpDatabase Svc";                                                                  

            DataSet objDataSet = null;            
            
            objDataSet = PeopleSoft.ADHelper.GetUsersForGroup(strADGroup);
            
            publishGrid(objDataSet);

            
       }             
              
	   private void publishGrid(DataSet objDataSet)
	   {
		
					
			//set data source
			gridReport.DataSource = objDataSet.Tables[0];
			
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
            
            objDbAdapter.SelectCommand = objDBCommand;
            
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

        
       private void populateCombobox(  DropDownList objDropDownList
                                     , String       strSQLQuery  )
       {
       
       
            OleDbDataReader objDBReader = null;
            String          strID = null;
            String          strLiteral = null;            
            int             iNumberofColumns = -1;
           
            try
            {
							
	            objDBCommand.CommandText = strSQLQuery;
	            
	            objDBCommand.CommandType = CommandType.StoredProcedure;            
	            
	            objDBCommand.Parameters.Clear();
	            
	            OleDbParameter objDBParameterIncludeBlank = new OleDbParameter();
	            objDBParameterIncludeBlank.Direction = ParameterDirection.Input;            
	            objDBParameterIncludeBlank.OleDbType = OleDbType.Integer;
	           	objDBParameterIncludeBlank.Value = 0;	            
	            objDBCommand.Parameters.Add(objDBParameterIncludeBlank);	                        	            
				
	            objDBReader = objDBCommand.ExecuteReader();	

            	objDropDownList.Items.Clear();		

	            
	            while (objDBReader.Read())
	            {
	                strID = objDBReader[0].ToString();
	                
	                if (iNumberofColumns == -1)
	                {
	                	iNumberofColumns = objDBReader.FieldCount;
	                }
	                
	                if (iNumberofColumns == 1)
	                {
	                	strLiteral = strID;
					}	                	
					else
   	                {
	                	strLiteral = objDBReader[1].ToString();
					}	                	
                	objDropDownList.Items.Add(new ListItem(strLiteral, strID));                
	                
	            }
	
	            
	            objDBReader.Close();



	            
	        }
			catch (Exception ex)
			{
				labelInfo.Text = "Exception occured in populateReportCombobox().  Exception is " + ex.Message
								+ "SQL Connection String is " + strDBConnection; 			
				labelInfo.Visible = true;	
			}	            


			
			if (objDBReader != null)
			{            
            	objDBReader = null;
			}            	
	
       
       } //populateCombobox
        
        
        protected void getUserInfo()
        {
        
            System.Security.Principal.IIdentity objIdentity;
            Boolean bAuthenticated;
        
            objIdentity = User.Identity;
            
            bAuthenticated = objIdentity.IsAuthenticated;
            strMemberID = objIdentity.Name;

            
        }       
        
       protected void ButtonGetGroupMembersClick(Object sender, EventArgs e) 
       {
       	
			getADGroupMembers();
       	
       }//        
    }


}