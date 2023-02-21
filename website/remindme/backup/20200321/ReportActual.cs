namespace EphraimTech.RemindME
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

    public class frmReport : System.Web.UI.Page
    {
       
       
       private String strContact = null;
       
       private String strDBConnection = null;
                                        
       private OleDbConnection objConnection = null;
       private OleDbCommand objDBCommand = null;       
       private OleDbDataAdapter objDbAdapter = null;			                                        
       
	   private String strSQLQuery;
	   
	   protected DataGrid gridReport;	 
	   
	   protected Label labelSQL;         
       private String strReportID = null;	   
	   private string strReportType;
	   
	   
	   protected DropDownList cbReport; 	   
	   	   
       protected String strMemberID  = null;	   
       
       //private String strReport = null;
       
       
        //read configuration settings                                                                         
       protected void readConfigurationSettings()
       {
            strDBConnection = ConfigurationSettings.AppSettings["oleDBConnection.ConnectionString"];
       }             
        

       protected void Page_Load(Object Sender, EventArgs evt)
       {
       
            readConfigurationSettings();       
       
			objConnection = new OleDbConnection(strDBConnection);
			
			objDBCommand = new OleDbCommand();
			
			objDBCommand.Connection = objConnection;
			        
            objConnection.Open();
            
            getUserInfo();
           
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
                                    

            
            strReportID = Request.QueryString["ReportID"];
            if ( (strReportID == null) || (strReportID == ""))
            {
                return;
            }
            
            strReportType = Request.QueryString["ReportType"];
            
            executeReport(strReportID);        
            
        }        
        
        
        protected void executeReport(String strReportID)
        {
            
            String strSQL = null; 
            
            strSQL = getReportSQL(strReportID);
            
            publishGrid(strSQL);
        
        
        }



       
       private DataView executeGridSQL(String strSQLQuery)
	   {
			

            OleDbDataAdapter objDbAdapter = null;			                                        			
			DataSet objDataSet = null;
		    DataView objDataView = null;	

		    objDBCommand.Parameters.Clear();				            
		    			
            objDBCommand.CommandText = strSQLQuery;
            objDBCommand.CommandType = CommandType.StoredProcedure;            
                
            OleDbParameter objDBParameterMemberID = new OleDbParameter();
            objDBParameterMemberID.ParameterName = "@memberIdentifier";
            objDBParameterMemberID.OleDbType = OleDbType.VarChar;
            objDBParameterMemberID.Size = 255;
            objDBParameterMemberID.Value = strMemberID; 
            objDBCommand.Parameters.Add(objDBParameterMemberID);
			
	
            objDbAdapter = new OleDbDataAdapter();            


            objDbAdapter.SelectCommand = objDBCommand;

            objDataSet = new DataSet("gridContents");
            
            objDbAdapter.Fill(objDataSet);						
            
			
			objDataView = objDataSet.Tables[0].DefaultView;
			
			objDataView.RowFilter = String.Empty;
			
			
			return objDataView;
						
		}       
       
       
       
       
	   private void publishGrid(String strSQL)
	   {
		
			ICollection objGridContents;
			
			//get Names
			objGridContents = executeGridSQL(strSQL);
					
			//set data source
			gridReport.DataSource = objGridContents;
			
			//data Bind
			gridReport.DataBind();
			
            if ( (strReportType == "Excel")  || (strReportType == "Word"))
            {
                displayAsMSDoc();   
            }
			
	   }       
	   

       void displayAsMSDoc()
       {
        
            //Verify if the page is to be displayed in Excel.
            if ( (strReportType == "Excel")  || (strReportType == "Word"))
            {     
                       
                System.IO.StringWriter tw;
                System.Web.UI.HtmlTextWriter hw;
                                           
                //Set the content type to Excel.
                if ( strReportType == "Excel")
                {
                    Response.ContentType = "application/vnd.ms-excel";
                }                    
                else if ( strReportType == "Word")
                {
                    Response.ContentType = "application/msword";
                }                    
                                
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
    
        protected void getUserInfo()
        {
        
            System.Security.Principal.IIdentity objIdentity;
            Boolean bAuthenticated;
            
        
            objIdentity = User.Identity;
            
            bAuthenticated = objIdentity.IsAuthenticated;
            strMemberID = objIdentity.Name;
            
        }        
        
                  
                  
       private String getReportSQL(String strReportID)
       {
            
            String strReportSQL = null;
            
            OleDbDataReader objDBReader = null;
							
			strSQLQuery = "getReportInfo";
		
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

    }


}