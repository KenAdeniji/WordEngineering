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
	   
	   protected DataGrid gridReport;	 
	   
	   protected Label labelSQL;         
	   
	   
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
       
      
            if (IsPostBack == false)
            {                
                populateReportCombobox();
            }                
            
       }      
       
       


        //Called when save button is clicked        
        protected void QueryBtnClicked(Object Sender, EventArgs E)
        {
            
            String strReportID = null;
            
            if (cbReport.SelectedItem == null)
            {
                return;
            }
            
            //get current report id
            strReportID = cbReport.SelectedItem.Value;
            
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
			
		
			labelSQL.Text = strSQLQuery;

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
			
	   }       
	   




        protected void getUserInfo()
        {
        
            System.Security.Principal.IIdentity objIdentity;
            Boolean bAuthenticated;
            
        
            objIdentity = User.Identity;
            
            bAuthenticated = objIdentity.IsAuthenticated;
            strMemberID = objIdentity.Name;
            
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
            
            cbReport.Items.Clear();		
            
            while (objDBReader.Read())
            {


                strReportName = objDBReader["reportName"].ToString();
                
                strReportID = objDBReader["reportID"].ToString();                
                iReportID = Int16.Parse(strReportID);
                
                objReportType.reportName = strReportName;
                objReportType.reportID = iReportID;                
                
                cbReport.Items.Add(new ListItem(objReportType.reportName, 
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