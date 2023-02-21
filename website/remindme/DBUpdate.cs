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
	
    public class frmDBItemDelete : System.Web.UI.Page
    {
       
       
                                        
       private OleDbConnection objConnection = null;
       private OleDbCommand objDBCommand = null;       
       private OleDbDataAdapter objDbAdapter = null;			                                        

       private String strDBConnection = null;        
	   private String strSQLQuery;

       protected string strMemberID = null; 
       protected string strMemberName = null;        
       protected string strContactID = null;
	   protected String strItemType = null;
       protected String strItemID = null;
      
       private static String strCookieContactID = "ContactID";       
	   
	   protected Label labelDebug;

	   private String strLog=null;
	   
	   //protected Label labelDebug;
	   
	   private String CHAR_SPACE = "&nbsp";
	   private String CHAR_LINEBREAK = "</BR>";
    
        //read configuration settings                                                                         
       protected void readConfigurationSettings()
       {
            strDBConnection = ConfigurationSettings.AppSettings["oleDBConnection.ConnectionString"];
       }             

       protected void getUserInfo()
       {
        
            System.Security.Principal.IIdentity objIdentity;
        
            objIdentity = User.Identity;

            strMemberName = objIdentity.Name;
            
            if (Session["memberID"] != null)
            {
            	strMemberID = Session["memberID"].ToString();
            }	            
            

       }
	                                   
                     
       private void getPassedInData()
       {
       
            //Review passed in parameters
            strItemType = Request["DBItemType"];   
			
            //Retrieve Cookie Data
            strContactID = Request[strCookieContactID];			
       
            //Review passed in parameters
            strItemID = Request["DBItemEntryID"];       
                   
       }               
         					  

       protected void Page_Load(Object Sender, EventArgs evt)
       {
       
			Boolean bRCUpdate = false;
			
            readConfigurationSettings();
            
            getUserInfo();
            
			objConnection = new OleDbConnection(strDBConnection);
			
			objDBCommand = new OleDbCommand();
			
			objDBCommand.Connection = objConnection;
			        
            objConnection.Open();
           
            getPassedInData();            
                
            bRCUpdate = DBUpdate();
                
            if (bRCUpdate)
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
        
        
        //Called when save button is clicked        
        protected void redirect()
        {
        
            String strRedirectURL = null;
           
            if (Request.QueryString["nextURL"] != null)
            {
                strRedirectURL = Request.QueryString["nextURL"];
            
                labelDebug.Text = strRedirectURL;
                
                Response.Redirect(strRedirectURL);
                
                //Server.Transfer(strRedirectURL);
                            
            }
            else if (Request.UrlReferrer != null)
            {
                strRedirectURL = Request.UrlReferrer.ToString();
            
                labelDebug.Text = strRedirectURL;
                
                Response.Redirect(strRedirectURL);
                
                //Server.Transfer(strRedirectURL);                
                            
            }            
            else
            {
                strRedirectURL = "Request.UrlReferrer is null";                
                labelDebug.Visible = true;                                
                labelDebug.Text = strRedirectURL;                
            }                
            

            
        }        
                  


        
            
        protected Boolean DBUpdate()
        {
        
            String strSQL = null;
            Boolean bUpdated = false;
            Boolean bInserting = false;
            
            int iAddressType = -1;
            String strCommunicate = null;
            String strComment = null;
            int iActive = 0;

			try
			{			
				if (strItemType == "Affliate")
				{
					strSQL = "usp_AffliateDelete";
				}            
				else if (strItemType == "Profession")
				{
					strSQL = "usp_ProfessionDelete";
				}                        
				else if (strItemType == "CommunicationType")
				{
					strSQL = "usp_CommunicationTypeDelete";
				}                                    
				else if (strItemType == "CommunicationItemDelete")
				{
					strSQL = "usp_ContactCommunicationDelete";
				}                                                
				else if (strItemType == "CommunicationItemActivateToggle")
				{
					strSQL = "usp_ContactCommunicationActivateToggle";
				}   
				else if (strItemType == "CommunicationItemCopy")
				{
					strSQL = "usp_ContactCommunicationCopy";
				}			
				else if (strItemType == "AddressItemDelete")
				{
					strSQL = "usp_ContactAddressDelete";
				}                                                            
				else if (strItemType == "EventItemDelete")
				{
					strSQL = "usp_ContactEventDelete";
				}                                                                        
				else if (strItemType == "AttachmentItemDelete")
				{
					strSQL = "usp_ContactAttachmentItemDelete";
				}                                                                                    
				else if (strItemType == "ContactCommentItemDelete")
				{
					strSQL = "usp_ContactCommentDelete";
				}                                                                                    
			   else if (strItemType == "ContactDelete")
				{
					strSQL = "usp_ContactDelete";
				}                                                            
				else
				{
					return false;            
				}                

				objDBCommand.CommandType = CommandType.StoredProcedure;               
				objDBCommand.CommandText = strSQL;

						   
				labelDebug.Text = "ItemID is " + strItemID;
				
							
				OleDbParameter objDBParametemItemMemberID = new OleDbParameter();
				objDBParametemItemMemberID.OleDbType = OleDbType.VarChar;
				objDBParametemItemMemberID.Size = 88;
				objDBParametemItemMemberID.Value = strMemberID;
				objDBCommand.Parameters.Add(objDBParametemItemMemberID);

				OleDbParameter objDBParametemItemContactID = new OleDbParameter();
				objDBParametemItemContactID.OleDbType = OleDbType.VarChar;
				objDBParametemItemContactID.Size = 88;
				objDBParametemItemContactID.Value = strContactID;
				objDBCommand.Parameters.Add(objDBParametemItemContactID);

				if (
						   (strItemID != null )
						&& (strItemID != "")
				   )
			    {   
					OleDbParameter objDBParametemItemID = new OleDbParameter();
					objDBParametemItemID.OleDbType = OleDbType.VarChar;
					objDBParametemItemID.Size = 88;
					objDBParametemItemID.Value = strItemID;
					objDBCommand.Parameters.Add(objDBParametemItemID);
				}
														
				objDBCommand.ExecuteNonQuery();
              
				bUpdated = true;
             					
 			}
			catch (Exception ex)
			{
				bUpdated = false;
				
				strLog = "";
				
				strLog += "Member ID is " + strMemberID + CHAR_LINEBREAK;
				
				strLog += CHAR_SPACE + "Contact ID is " + strContactID + CHAR_LINEBREAK;				
				
				strLog += CHAR_SPACE + "Contact Communication ID is " + strItemID + CHAR_LINEBREAK;
				
				strLog += CHAR_SPACE + "Exception is " + ex.Message + CHAR_LINEBREAK;

				labelDebug.Text = strLog;

				labelDebug.Visible = true;
			}
			
            return bUpdated;        
            
        }                



        
    }


}