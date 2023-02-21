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

    public class frmCommunicationTypesEdit : System.Web.UI.Page
    {
       
       
       private String strContact = null;
       
       private String strDBConnection = null;
                                        
       private OleDbConnection objConnection = null;
       private OleDbCommand objDBCommand = null;       
       private OleDbDataAdapter objDbAdapter = null;			                                        

       
	   private String strSQLQuery;
	   
	   protected DataGrid gridContactCommunicationInfo;	 
	   protected DataGrid gridContactAddressInfo;	 
	   	   
       protected HtmlInputHidden hiddenCommunicationTypeID;	   
       protected HtmlInputHidden hiddenURLCaller;
	   protected TextBox txtCommunicationType;
	   protected CheckBox chkIsPrivate;	   
	   protected CheckBox chkIsPhone;	   

	   
	   protected Label labelSQL;         
	   protected Label labelDebug;
	   protected Label labelErrMessage;         	   
	   
       protected String strMemberID  = null;	   
       protected String strMemberName  = null;	   	   
       protected String strCommunicationTypeID = null;

       private static String strCookieContactID = "ContactID";       


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
                
            
                if (strCommunicationTypeID != null)
                {
                    getBody();            
                }                    
                else
                {
                    prepareBodyFoNewInsert();
                }
                            
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
       
            //Review passed in parameters
            strCommunicationTypeID = Request["CommunicationTypeID"];       
       
       }               
                      
                      
       private void savePassedInData()
       {
       
            //Review passed in parameters
            hiddenCommunicationTypeID.Value = strCommunicationTypeID;
            
            //save off Caller's URL
            UrlCallerSave();
       
       }                                     
       
       private void getBody()
       {
            
            //get Contact Info            
            getCommunicationTypeInfo();
            
            
       }            
       
       
       private void prepareBodyFoNewInsert()
       {
        
            chkIsPrivate.Checked = true;                                       
       
       }


       private void getCommunicationTypeInfo()
       {
       
       
            OleDbDataReader objDBReader = null;
            
            String          strIsPrivate = null;
            Boolean         bIsPrivate = false;
            
            String          strIsPhone = null;
            Boolean         bIsPhone = false;
                        
            String          strCommunicationType = null;
            int             iCommunicationType = -1;
							
			strSQLQuery = "usp_CommunicationTypeGet";
		
			labelSQL.Text = strCommunicationType;
            labelDebug.Text = "Contact Communication ID is " + strCommunicationTypeID;			
			
            objDBCommand.CommandText = strSQLQuery;
            
            objDBCommand.CommandType = CommandType.StoredProcedure;            
            
            objDBCommand.Parameters.Clear();
            
            OleDbParameter objDBParameterMemberID = new OleDbParameter();
            objDBParameterMemberID.ParameterName = "@strMemberIdentifier";
            objDBParameterMemberID.OleDbType = OleDbType.VarChar;
            objDBParameterMemberID.Size = 255;
            objDBParameterMemberID.Value = strMemberID;
            objDBCommand.Parameters.Add(objDBParameterMemberID);            
                
            OleDbParameter objDBParameterCommunicationTypeID = new OleDbParameter();
            objDBParameterCommunicationTypeID.ParameterName = "contactCommunicationID";
            objDBParameterCommunicationTypeID.OleDbType = OleDbType.Integer;
            objDBParameterCommunicationTypeID.Value = strCommunicationTypeID;
            objDBCommand.Parameters.Add(objDBParameterCommunicationTypeID);
			
            objDBReader = objDBCommand.ExecuteReader();			
            
            while (objDBReader.Read())
            {
                                
                txtCommunicationType.Text = objDBReader["comm_type"].ToString();
                
                strIsPrivate = objDBReader["IsPrivate"].ToString();
                                            
                strIsPhone = objDBReader["IsPhoneNumber"].ToString();                                            
            }
            
            
            if (strIsPrivate == "1")
            {
                bIsPrivate = true;            
            }
            else
            {
                bIsPrivate = false;            
            }            
            
            chkIsPrivate.Checked = bIsPrivate;
            
            
            if (strIsPhone == "1")
            {
                bIsPhone = true;            
            }
            else
            {
                bIsPhone = false;            
            }            
            
            chkIsPhone.Checked = bIsPhone;                        
            
            objDBReader.Close();
            
            objDBReader = null;
	
       
       }                                        

   		 	   



        protected void getUserInfo()
        {
        
            System.Security.Principal.IIdentity objIdentity;
            Boolean bAuthenticated;
            
        
            objIdentity = User.Identity;
            
            bAuthenticated = objIdentity.IsAuthenticated;
			
            //strMemberID = objIdentity.Name;

			strMemberName = objIdentity.Name;
            
            if (Session["memberID"] != null)
            {
            	strMemberID = Session["memberID"].ToString();
            }							
            
        }        
        
        

                                 
        
        
        //Called when save button is clicked        
        protected void SaveBtnClicked(Object Sender, EventArgs E)
        {
            
            Boolean bSaved;
            
            bSaved = DBSave();
            
            if (bSaved)
            {
                UrlCallerRedirect();
            }                
            
        }        
                 
                 
        protected void DiscardBtnClicked(Object Sender, EventArgs E)
        {
            
            UrlCallerRedirect();
            
        }                          


        protected Boolean DBSave()
        {
        
            Boolean bUpdated = false;
            Boolean bInserting = false;
            
            if (hiddenCommunicationTypeID.Value == null)
            {
                bInserting = true;            
            }
            else
            {
                if (hiddenCommunicationTypeID.Value.Length == 0)
                {
                    bInserting = true;                            
                }
                else
                {
                    bInserting = false;            
                }                    
            }                        
            

            bUpdated = DBSaveInternal(bInserting);                        
            
            return bUpdated;
                
            
        }
        
            


        protected Boolean DBSaveInternal(Boolean bInserting)
        {
        
            String strSQL = null;
            Boolean bUpdated = false;
            
            string strCommunicationTypeID = "";
            int iCommunicationTypeID = -1;
            String strCommunicationType = null;
            int iCommunicationTypeIsPrivate = -1;
            int iCommunicationTypeIsPhone = -1;

            try
			{
			
				labelErrMessage.Visible = false;
			
				strSQL = "usp_CommunicationTypeSave";
				
				
				strCommunicationTypeID = hiddenCommunicationTypeID.Value.Trim();
				
				if (strCommunicationTypeID.Length == 0)
				{
					iCommunicationTypeID = -1;                   
				}
				else
				{
					iCommunicationTypeID = Int32.Parse(strCommunicationTypeID);                   
				}   
						 
				strCommunicationType = txtCommunicationType.Text;             
				
				if (chkIsPrivate.Checked == true)
				{
					iCommunicationTypeIsPrivate = 1;
				}   
				else                        
				{
					iCommunicationTypeIsPrivate = 0;
				}              
				
				if (chkIsPhone.Checked == true)
				{
					iCommunicationTypeIsPhone = 1;
				}   
				else                        
				{
					iCommunicationTypeIsPhone = 0;
				}              
				
				
				labelDebug.Text = "Member ID is " +  strMemberID + " " +
								  "Communication Type ID is " +  iCommunicationTypeID + " " +                                           
								  "Communication Type Data is " +  strCommunicationType + " " +           
								  "Communication Type IsPrivate is " +  iCommunicationTypeIsPrivate + 
								  "Communication Type IsPhone is " +  iCommunicationTypeIsPhone + 
								  "";           
																
				if ( 1 == 0)
				{
					return (false);   
				}
				
				objDBCommand.CommandText = strSQL;
				objDBCommand.CommandType = CommandType.StoredProcedure;            
				objDBCommand.Parameters.Clear();
										
				OleDbParameter objDBParameterMemberID = new OleDbParameter();
				objDBParameterMemberID.ParameterName = "MemberID";
				objDBParameterMemberID.OleDbType = OleDbType.VarChar;
				objDBParameterMemberID.Size = 88;
				objDBParameterMemberID.Value = strMemberID;
				objDBCommand.Parameters.Add(objDBParameterMemberID);
	
				
				OleDbParameter objDBParameterCommunicationType = new OleDbParameter();
				objDBParameterCommunicationType.ParameterName = "CommunicationTypeID";
				objDBParameterCommunicationType.OleDbType = OleDbType.Integer;
				objDBParameterCommunicationType.Value = iCommunicationTypeID;
				objDBCommand.Parameters.Add(objDBParameterCommunicationType);                            
				
				OleDbParameter objDBParameterCommunicate = new OleDbParameter();
				objDBParameterCommunicate.ParameterName = "CommunicationType";
				objDBParameterCommunicate.OleDbType = OleDbType.VarChar;
				objDBParameterCommunicate.Value = strCommunicationType;
				objDBCommand.Parameters.Add(objDBParameterCommunicate);                            
	
				
				OleDbParameter objDBParameterIsPrivate = new OleDbParameter();
				objDBParameterIsPrivate.ParameterName = "IsPrivate";
				objDBParameterIsPrivate.OleDbType = OleDbType.Integer;
				objDBParameterIsPrivate.Value = iCommunicationTypeIsPrivate;
				objDBCommand.Parameters.Add(objDBParameterIsPrivate);                                        
				
				OleDbParameter objDBParameterIsPhone = new OleDbParameter();
				objDBParameterIsPhone.ParameterName = "IsPhone";
				objDBParameterIsPhone.OleDbType = OleDbType.Integer;
				objDBParameterIsPhone.Value = iCommunicationTypeIsPhone;
				objDBCommand.Parameters.Add(objDBParameterIsPhone);                                                    
													
				objDBCommand.ExecuteNonQuery();
					
				objDBCommand.Connection.Close();
					
				bUpdated = true;
				
			}
			catch (Exception ex)
			{
				labelErrMessage.Text = "Unable to save data  " + ex.Message;
				labelErrMessage.Visible = true;
			}
			
                
            return bUpdated;        
            
        }              
        
        
        //Called when save button is clicked        
        protected void UrlCallerSave()
        {
        
            String strRedirectURL = null;
           
            if (Request.UrlReferrer != null)
            {
                strRedirectURL = Request.UrlReferrer.ToString();

                hiddenURLCaller.Value = strRedirectURL;
                            
                labelDebug.Text = strRedirectURL;
                

                            
            }
            
        }                


        //Called when save/discard button is clicked        
        protected void UrlCallerRedirect()
        {
        
            String strRedirectURL = null;
            
            strRedirectURL = hiddenURLCaller.Value;
            
            if (strRedirectURL == null)
            {
                strRedirectURL = "/remindme/SupportCommunicationTypes.aspx";
                            
            }            
           
            if (strRedirectURL != null)
            {
                Response.Redirect(strRedirectURL);
                            
            }
            
        }                
        
    }


}