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

    public class frmDBItemDelete : System.Web.UI.Page
    {
       
       
                                        
       private OleDbConnection objConnection = null;
       private OleDbCommand objDBCommand = null;       
       private OleDbDataAdapter objDbAdapter = null;			                                        

       private String strDBConnection = null;        
	   private String strSQLQuery;

       protected string strMemberName = null; 	   
       protected string strMemberID = null; 
       protected String strItemType = null;
       protected String strItemID = null;
      
      
	   protected Label labelDebug;

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
       
            //Review passed in parameters
            strItemType = Request["DBItemType"];       
       
            //Review passed in parameters
            strItemID = Request["DBItemEntryID"];       
                   
       }               
                      
                      

        
        
        //Called when save button is clicked        
        protected void redirect()
        {
        
            String strRedirectURL = null;
           
            if (Request.UrlReferrer != null)
            {
                strRedirectURL = Request.UrlReferrer.ToString();
            
                labelDebug.Text = strRedirectURL;
                
                Response.Redirect(strRedirectURL);
                            
            }
            else
            {
                strRedirectURL = "Request.UrlReferrer is null";                
                labelDebug.Visible = true;                                
                labelDebug.Text = strRedirectURL;                
            }                
            

            
        }        
                  


        
            
        protected Boolean DBDelete()
        {
        
            String strSQL = null;
            Boolean bUpdated = false;
            Boolean bInserting = false;
            
            int iAddressType = -1;
            String strCommunicate = null;
            String strComment = null;
            int iActive = 0;
            
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


            OleDbParameter objDBParametemItemID = new OleDbParameter();
            objDBParametemItemID.OleDbType = OleDbType.VarChar;
            objDBParametemItemID.Size = 88;
            objDBParametemItemID.Value = strItemID;
            objDBCommand.Parameters.Add(objDBParametemItemID);

                                                
            objDBCommand.ExecuteNonQuery();
                
               
            bUpdated = true;
                
            return bUpdated;        
            
        }                



        
    }


}