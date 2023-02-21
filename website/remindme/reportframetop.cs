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
    
    public class reportType 
    {
    
        private int    iReportID;
        private String strReportName;
        private String strSQL;
        
        public reportType()
        {
            this.iReportID = -1;
            this.strReportName = null;
            this.strSQL = null;                      
        }        
        
       
        
        public String reportName
        {
            
            get
            {
                return strReportName;
            }
            
            set
            {
                strReportName = value;
            }            
        }
    

        public int reportID
        {
            
            get
            {
                return iReportID;
            }
            
            set
            {
                iReportID = value;
            }            
        }
    
    }
    
    
    
    

    public class frmReport : System.Web.UI.Page
    {
       
       
       private String strContact = null;
       
       private String strDBConnection = null;
                                        
       private OleDbConnection objConnection = null;
       private OleDbCommand objDBCommand = null;       
       private OleDbDataAdapter objDbAdapter = null;			                                        
       
	   private String strSQLQuery;
	   
	   protected Button btnQuery;	 	   
	   protected DataGrid gridReport;	 
	   
	   protected Label labelSQL;         
	   protected Label labelInfo;         	   
	   protected Label labelNumberofHosts;
	   protected Label labelReportName;
	   protected Label labelSortedBy;
	   
	   protected DropDownList cbReportID; 	   
	   	   
       protected String strMemberID  = null;	   
       

       protected CheckBox chkPagedReport = null;
       
       private String strReportStartDate = null;
       private String strReportEndDate = null;
              
       String strValidationErrMessage = null;
       
       protected Label labelMessage;    		       
       
       private string strSortExpression = null;       
       
        //read configuration settings                                                                         
       protected void readConfigurationSettings()
       {
            strDBConnection = ConfigurationSettings.AppSettings["oleDBConnection.ConnectionString"];
       }             
        

       protected void Page_Load(Object Sender, EventArgs evt)
       {
       
            //Set the content type to Excel.
            Response.Buffer = true;
            
            if (Request.QueryString["bExcel"] == "1" )
            {
                //Set the content type to Excel.
                Response.Buffer = true;
                                
                //Set the content type to Excel.
                Response.ContentType = "application/vnd.ms-excel";
                
                //Set the content type to Excel.
                Response.Expires = 0;                
            }                            
                       
            readConfigurationSettings();       
       
			objConnection = new OleDbConnection(strDBConnection);
			
			objDBCommand = new OleDbCommand();
			
			objDBCommand.Connection = objConnection;
			        
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
       
            string strInit = null;
            
            strInit = Request["init"];
            
            if ((IsPostBack == false) || (strInit == "y"))
            {                
                populateReportCombobox();

            }                
            
            btnQuery.Attributes.Add ("onclick",
                  "generateReport();");            
            
       }      
        

       private void populateReportCombobox()
       {
       
       
            OleDbDataReader objDBReader = null;
            String          strActive = null;
            Boolean         bActive = false;
            
            String          strReportSQL = null;            
            String          strReportID = null;            
            String          strReportName = null;
            int             iReportID = -1;
           
            reportType      objReportType = null;                                                
            
            objReportType = new reportType();
							
			strSQLQuery = "getReports";
		
            objDBCommand.CommandText = strSQLQuery;
            
            objDBCommand.CommandType = CommandType.StoredProcedure;            
            
            objDBCommand.Parameters.Clear();
                
			
            objDBReader = objDBCommand.ExecuteReader();	
            
            cbReportID.Items.Clear();		
            
            while (objDBReader.Read())
            {


                strReportName = objDBReader["reportName"].ToString();
                
                strReportID = objDBReader["reportID"].ToString();                
                iReportID = Int16.Parse(strReportID);
                
                objReportType.reportName = strReportName;
                objReportType.reportID = iReportID;                
                
                cbReportID.Items.Add(new ListItem(objReportType.reportName, 
                                                strReportID));                
                
            }

            objReportType = null;                        
            
            objDBReader.Close();
            
            objDBReader = null;
	
       
       }                                                
                  
                  
                  
       private String getReportSQL(String strReportID)
       {
            
            String strReportSQL = null;
            
            OleDbDataReader objDBReader = null;
							
			strSQLQuery = "sp_GetReportInfo";
		
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