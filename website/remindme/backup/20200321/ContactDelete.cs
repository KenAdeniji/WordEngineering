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
    using remindME.stateManagement;               

    public class frmContactDelete : System.Web.UI.Page
    {
       
       
       private String strDBConnection = null;
                                        
       private OleDbConnection objConnection = null;
       private OleDbCommand objDBCommand = null;       
       private OleDbDataAdapter objDbAdapter = null;			                                        

       
	   private String strSQLQuery;

       protected String strContactID = null;
       protected String strContactName = null;
              
       private static String strCookieContactID = "ContactID";       
       
	   protected Label labelDebug;
	   
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
           
            getPassedInData();            
                
            DBDelete();
                
            redirect();    
            
       }                                               
        

        
       protected void Page_UnLoad(Object Sender, EventArgs evt)
       {
            
			objDBCommand = null;
			       
            objConnection.Close();       
			objConnection = null;
        
       }
       
       
       private void stateDataGet()
       {
       	
       		 sessionVars objSessionVars = null;
       		 
       		 objSessionVars = new remindME.stateManagement.sessionVars();
       		 
       		 	objSessionVars.Session = Session;
       		 
       		 	strContactID = objSessionVars.contactID;
       		 	strContactName = objSessionVars.contactName;       		 
       		 
       		 objSessionVars = null;
       	
       }                                 
                             
       private void getPassedInData()
       {
       
            //Retrieve Cookie Data
            //strContactID = Request[strCookieContactID];
            
			stateDataGet();	            
       
       }               
                      
                      

        
        
        //Called when save button is clicked        
        protected void redirect()
        {
        
            String strRedirectURL = null;
           
            strRedirectURL = "Cover.aspx";
            
            Response.Redirect(strRedirectURL);
            
        }        
                  


        
            
        protected Boolean DBDelete()
        {
        
            StringBuilder strSQLBuilder = null;
            String strSQL = null;
            Boolean bUpdated = false;
            Boolean bInserting = false;
            
            int iCommentType = -1;
            String strCommunicate = null;
            String strComment = null;
            int iActive = 0;

                        
            strSQLBuilder = new StringBuilder();
                                        
            strSQLBuilder.Append("sp_ContactDelete");                                        

                                                                
            strSQL = strSQLBuilder.ToString();
            
            objDBCommand.CommandText = strSQL;
            objDBCommand.CommandType = CommandType.StoredProcedure;                        
            
            labelDebug.Text = "strContactID is " + strContactID;
            
                        
            OleDbParameter objDBParameterContactID = new OleDbParameter();
            objDBParameterContactID.ParameterName = "ContactID";
            objDBParameterContactID.OleDbType = OleDbType.VarChar;
            objDBParameterContactID.Size = 88;
            objDBParameterContactID.Value = strContactID;
            objDBCommand.Parameters.Add(objDBParameterContactID);

                                                
            objDBCommand.ExecuteNonQuery();
                
            objDBCommand.Connection.Close();
                
            bUpdated = true;
                
            return bUpdated;        
            
        }                



        
    }


}