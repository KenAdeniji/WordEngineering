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

    public class frmContactEventCopy : System.Web.UI.Page
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
       
	   private String strLog=null;
	   
	   protected Label labelDebug;
	   
	   private String CHAR_SPACE = "&nbsp";
	   private String CHAR_LINEBREAK = "</BR>";


        //read configuration settings                                                                         
       protected void readConfigurationSettings()
       {
            strDBConnection = ConfigurationSettings.AppSettings["oleDBConnection.ConnectionString"];
       }             
       	   

       protected void Page_Load(Object Sender, EventArgs evt)
       {
       
			Boolean bResult = false;
	   
            readConfigurationSettings();
            
            getUserInfo();
            
			objConnection = new OleDbConnection(strDBConnection);
			
			objDBCommand = new OleDbCommand();
			
			objDBCommand.Connection = objConnection;
			        
            objConnection.Open();
           
            getPassedInData();            
                
            bResult = DBCopy();
            
			if (bResult)
			{	
				redirect();    
            }
            
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
                  

        protected Boolean DBCopy()
        {
        
            StringBuilder strSQLBuilder = null;
            String strSQL = null;
            Boolean bUpdated = false;
            Boolean bInserting = false;
            
            int iUpdatedRecs = -1;
                        
			try
			{			
				strSQLBuilder = new StringBuilder();

				//SP name changed from usp_ContactEventCopy
				//strSQLBuilder.Append("usp_ContactEventCopy");                                        
				strSQLBuilder.Append("[dbo].[usp_ContactEventCopy]");   
				
				strSQL = strSQLBuilder.ToString();
								  
				objDBCommand.CommandText = strSQL;
				objDBCommand.CommandType = CommandType.StoredProcedure;                        

							
				OleDbParameter objDBParameterContactMemberID = new OleDbParameter();
				objDBParameterContactMemberID.OleDbType = OleDbType.VarChar;
				objDBParameterContactMemberID.Size = 88;
				objDBParameterContactMemberID.Value = strMemberID;
				objDBCommand.Parameters.Add(objDBParameterContactMemberID);

				OleDbParameter objDBParameterContactID = new OleDbParameter();
				objDBParameterContactID.OleDbType = OleDbType.VarChar;
				objDBParameterContactID.Size = 88;
				objDBParameterContactID.Value = strContactID;
				objDBCommand.Parameters.Add(objDBParameterContactID);				
						
				OleDbParameter objDBParameterContactEventID = new OleDbParameter();
				objDBParameterContactEventID.OleDbType = OleDbType.VarChar;
				objDBParameterContactEventID.Size = 88;
				objDBParameterContactEventID.Value = strContactEventID;
				objDBCommand.Parameters.Add(objDBParameterContactEventID);

			
				
				iUpdatedRecs = objDBCommand.ExecuteNonQuery();
					
				bUpdated = true;
			
				/*
				
					strLog = "";
					strLog += "Member ID is " + strMemberID;
					strLog += "Contact Event ID is " + strContactEventID;
					strLog += "Number of records updated is " + iUpdatedRecs;

					labelDebug.Text = strLog;
					
				*/
				
				labelDebug.Text = "";
				
				labelDebug.Visible = false;
				
				
			}
			catch (Exception ex)
			{
				bUpdated = false;
				
				strLog = "";
				
				strLog += "Member ID is " + strMemberID + CHAR_LINEBREAK;
				
				strLog += CHAR_SPACE + "Contact ID is " + strContactID + CHAR_LINEBREAK;				
				
				strLog += CHAR_SPACE + "Contact Event ID is " + strContactEventID + CHAR_LINEBREAK;
				
				strLog += CHAR_SPACE + "Exception is " + ex.Message + CHAR_LINEBREAK;

				labelDebug.Text = strLog;

				labelDebug.Visible = true;
			}
			
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