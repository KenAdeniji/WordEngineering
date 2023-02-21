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

    public class frmContactEventDelete : System.Web.UI.Page
    {
       
       
                                        
       private OleDbConnection objConnection = null;
       private OleDbCommand objDBCommand = null;       
       private OleDbDataAdapter objDbAdapter = null;			                                        

       private String strDBConnection = null;        
	   private String strSQLQuery;

       private String strMemberID = null;
       private String strContactID = null;
       private String strContactEventID = null;
       
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
            
            getUserInfo();
            
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
       
       
                      
       private void getPassedInData()
       {
       
            //Retrieve Cookie Data
            strContactID = Request[strCookieContactID];
       
            //Review passed in parameters
            strContactEventID = Request["ContactEventID"];       
       
       }               
                      
                      

        
        
        //Called when save button is clicked        
        protected void redirect()
        {
            
            String strRedirectURL = null;
            
            strRedirectURL = Request.UrlReferrer.ToString();
            
            if (strRedirectURL == null)
            {
           
                strRedirectURL = "ContactBrowse.aspx?ContactID=" + strContactID;
                
            }                
            
            //labelDebug.Text = "Redirect is " + strRedirectURL;
            
            Response.Redirect(strRedirectURL);            
            
        }        
                  

        protected Boolean DBDelete()
        {
        
            StringBuilder strSQLBuilder = null;
            String strSQL = null;
            Boolean bUpdated = false;
            Boolean bInserting = false;
            
            int iUpdatedRecs = -1;
                        
            strSQLBuilder = new StringBuilder();

            strSQLBuilder.Append("usp_ContactEventDelete");                                        
                                                                            
            strSQL = strSQLBuilder.ToString();
            

                              
            objDBCommand.CommandText = strSQL;
            objDBCommand.CommandType = CommandType.StoredProcedure;                        

                        
            OleDbParameter objDBParameterContactMemberID = new OleDbParameter();
            objDBParameterContactMemberID.OleDbType = OleDbType.VarChar;
            objDBParameterContactMemberID.Size = 88;
            objDBParameterContactMemberID.Value = strMemberID;
            objDBCommand.Parameters.Add(objDBParameterContactMemberID);
            
                    
            OleDbParameter objDBParameterContactAddressID = new OleDbParameter();
            objDBParameterContactAddressID.OleDbType = OleDbType.VarChar;
            objDBParameterContactAddressID.Size = 88;
            objDBParameterContactAddressID.Value = strContactEventID;
            objDBCommand.Parameters.Add(objDBParameterContactAddressID);
                        
                                                
            iUpdatedRecs = objDBCommand.ExecuteNonQuery();
                
            bUpdated = true;
                
            return bUpdated;        
            
        }                
        

        protected void getUserInfo()
        {
        
            System.Security.Principal.IIdentity objIdentity;
            Boolean bAuthenticated;
            
        
            objIdentity = User.Identity;
            
            bAuthenticated = objIdentity.IsAuthenticated;
            strMemberID = objIdentity.Name;
            
        }                        

        
    }


}