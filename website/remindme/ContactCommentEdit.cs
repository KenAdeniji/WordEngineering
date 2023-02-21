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
    
    
    public class frmContactCommentEdit : System.Web.UI.Page
    {
       
       
       private String strContact = null;
       
       private String strDBConnection = null;
                                        
       private OleDbConnection objConnection = null;
       private OleDbCommand objDBCommand = null;       
       private OleDbDataAdapter objDbAdapter = null;			                                        

       
	   private String strSQLQuery;
	   
	   protected DataGrid gridContactCommunicationInfo;	 
	   protected DataGrid gridContactAddressInfo;	 
	   	   
       protected HtmlInputHidden hiddenContactCommentID;	   
	   protected TextBox txtAddress1;
	   protected TextBox txtAddress2;
	   protected TextBox txtCity;	   
	   protected TextBox txtState;	
	   protected TextBox txtPostalCode;	      
	   protected TextBox txtCountry;	   
	   protected TextBox txtComment;	   	   

	   protected Label labelContactName;         	           
	   	   
	   protected CheckBox chkActive;
	   
	   protected Label labelSQL;         
	   protected Label labelDebug;
	   
       protected String strMemberID  = null;	   
       protected String strMemberName  = null;	          
       protected String strContactID = null;       
       protected String strContactName = null;              
       protected String strContactCommentID = null;

       //private static String strCookieContactID = "ContactID";       
       
       private static String strContactCommentIDParameter = "ContactCommentID";              

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
            
            getPassedInData();            
                        
            if (IsPostBack == false)
            {            
                
                savePassedInData();
            
                if (strContactCommentID != null)
                {
                    getBody();            
                }                    
                else
                {
                    prepareBodyFoNewInsert();
                }
                
                labelContactName.Text = strContactName;
                            
            }


            
            
       }                                               
        
        
       protected void Page_UnLoad(Object Sender, EventArgs evt)
       {
            
			objDBCommand = null;
			       
            objConnection.Close();       
			objConnection = null;
			

        
       }
       
       private void getStateData()
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
            
            getStateData();
       
            //Review passed in parameters
            strContactCommentID = Request[strContactCommentIDParameter];       
       
       }               
                      
                      
       private void savePassedInData()
       {
       
            //Review passed in parameters
            hiddenContactCommentID.Value = strContactCommentID;
       
       }                                     
       
       private void getBody()
       {
            
            //get Contact Info            
            getContactCommentInfo();
            
            
       }            
       
       
       private void prepareBodyFoNewInsert()
       {
        
      
       }


       private void getContactCommentInfo()
       {
       
       
            OleDbDataReader objDBReader = null;
            String          strActive = null;
            Boolean         bActive = false;
            
            String          strCommunicationType = null;
            int             iCommunicationType = -1;
            
							
			strSQLQuery = "getContactCommentRecord";
		
			labelSQL.Text = strCommunicationType;
            labelDebug.Text = "Contact Communication ID is " + strContactCommentID;			
			
            objDBCommand.CommandText = strSQLQuery;
            
            objDBCommand.CommandType = CommandType.StoredProcedure;                        
            
            objDBCommand.Parameters.Clear();
                
            OleDbParameter objDBParameterMemberID = new OleDbParameter();
            objDBParameterMemberID.ParameterName = "contactCommunicationID";
            objDBParameterMemberID.OleDbType = OleDbType.VarChar;
            objDBParameterMemberID.Size = 255;
            objDBParameterMemberID.Value = strContactCommentID;
            objDBCommand.Parameters.Add(objDBParameterMemberID);
			
            objDBReader = objDBCommand.ExecuteReader();			
            
            while (objDBReader.Read())
            {
                
                txtComment.Text = objDBReader["comment"].ToString();                                   
                                            
            }
            
           
            objDBReader.Close();
            
            objDBReader = null;
	
       
       }                                        

   		 	   



        protected void getUserInfo()
        {
        
            System.Security.Principal.IIdentity objIdentity;
            Boolean bAuthenticated;
            
        
            objIdentity = User.Identity;
            
            bAuthenticated = objIdentity.IsAuthenticated;

            strMemberName = objIdentity.Name;
            
            if (Session["memberID"] != null)
            {
            	strMemberID = Session["memberID"].ToString();
            }	            
            
        }        
        
        


        
        
        //Called when save button is clicked        
        protected void SaveBtnClicked(Object Sender, EventArgs E)
        {
        
            String strRedirectURL = null;
            
            DBSave();
            
            strRedirectURL = "ContactCommentBrowse.aspx";
            
            Response.Redirect(strRedirectURL);
            
        }        
                  


        protected Boolean DBSave()
        {
        
            Boolean bUpdated = false;
            Boolean bInserting = false;
            
            if (hiddenContactCommentID.Value == null)
            {
                bInserting = true;            
            }
            else
            {
                if (hiddenContactCommentID.Value.Length == 0)
                {
                    bInserting = true;                            
                }
                else
                {
                    bInserting = false;            
                }                    
            }                        
            
            bUpdated = DBUpdate(bInserting);
            
            return bUpdated;
                
            
        }
        
            
        protected Boolean DBUpdate(Boolean bAdding )
        {
        
            StringBuilder strSQLBuilder = null;
            String strSQL = null;
            Boolean bUpdated = false;
            Boolean bInserting = false;
            
            String strComment = null;                        
            
            int iUpdatedRecs = -1;
            
            OleDbParameter objDBParameterCommentID = null;

                        
            strSQLBuilder = new StringBuilder();
                
            if (bAdding)
            {                            
                strSQLBuilder.Append("sp_ContactCommentInsert");                                        
            }
            else                
            {                            
                strSQLBuilder.Append("sp_ContactCommentUpdate");                                        
            }
                                                                            
            strSQL = strSQLBuilder.ToString();
            
            //labelMessage.Text = strSQL + hiddenQuoteId.Value + "[" + hiddenQuoteId.Value.Length + "]"  ;
            

            strComment = txtComment.Text;
            
            
            //labelDebug.Text = "Address1 is " +  strAddress1 +
            //                  "active is " +  iActive ;            
                              
            objDBCommand.CommandText = strSQL;
            objDBCommand.CommandType = CommandType.StoredProcedure;                        
            
            if (bAdding)
            {                              
                        
                OleDbParameter objDBParameterContactMemberID = new OleDbParameter();
                objDBParameterContactMemberID.OleDbType = OleDbType.VarChar;
                objDBParameterContactMemberID.Size = 88;
                objDBParameterContactMemberID.Value = strMemberID;
                objDBCommand.Parameters.Add(objDBParameterContactMemberID);
                
                OleDbParameter objDBParameterContactContactID = new OleDbParameter();
                objDBParameterContactContactID.OleDbType = OleDbType.VarChar;
                objDBParameterContactContactID.Size = 88;
                objDBParameterContactContactID.Value = strContactID;
                objDBCommand.Parameters.Add(objDBParameterContactContactID);                
                
            }                            
            else
            {                              
                        
                OleDbParameter objDBParameterContactCommentID = new OleDbParameter();
                objDBParameterContactCommentID.OleDbType = OleDbType.VarChar;
                objDBParameterContactCommentID.Size = 88;
                objDBParameterContactCommentID.Value = strContactCommentID;
                objDBCommand.Parameters.Add(objDBParameterContactCommentID);
                
            }                
            
            OleDbParameter objDBParameterContactComment = new OleDbParameter();
            objDBParameterContactComment.OleDbType = OleDbType.VarChar;
            objDBParameterContactComment.Size = 3000;
            objDBParameterContactComment.Value = strComment;
            objDBCommand.Parameters.Add(objDBParameterContactComment);                                                
                        
            

            if (bAdding)
            {
                objDBParameterCommentID = new OleDbParameter();
                objDBParameterCommentID.OleDbType = OleDbType.VarChar;
                objDBParameterCommentID.Value = "";
                objDBParameterCommentID.Size = 255;            
                objDBParameterCommentID.Direction = ParameterDirection.Output;                        
                objDBCommand.Parameters.Add(objDBParameterCommentID);                                        
            }            
                        
                                                
            iUpdatedRecs = objDBCommand.ExecuteNonQuery();
            
            if (bAdding)
            {
                if (iUpdatedRecs == 1)
                {
                    strContactCommentID = objDBParameterCommentID.Value.ToString(); 
                    
                    labelDebug.Text = "Address ID is " +  strContactCommentID;
                    
                }
            }            
                
                
            bUpdated = true;
                
            return bUpdated;        
            
        }                


             
        
    }


}