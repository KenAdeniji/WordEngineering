namespace EphraimTech.RemindME

{


    using System;
    using System.Collections;
    using System.Web.UI.HtmlControls;            
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.ComponentModel;
    using System.Data;
    using System.IO;    //Stream
    using System.Data.OleDb;
    using System.Text;    //StringBuilder
    using System.Configuration;                
    using remindME.stateManagement;       
        

	public class frmContactAttachmentEdit : System.Web.UI.Page
	{
	
		protected DataView objDataView;

										
		//protected TextBox editEventName;
		//protected TextBox editEventComment;

        protected TextBox editAttachmentName;	
        protected TextBox editAttachmentDescription;	
		protected System.Web.UI.HtmlControls.HtmlInputFile editAttachmentFile;
		
        protected HtmlInputHidden hiddenContacAttachmentID;   
        protected HtmlInputHidden hiddenURLReferer;
        
        protected Label labelMessage;    		
        protected Label labelDebug;    		
                        
        protected Button buttonDelete;
        protected Button buttonAddMore;
        
	    protected Label labelContactID;         	   
	    protected Label labelContactName;         	           
        
        Boolean bEventExists;
		
        String strDBConnection = null;
        
        private String strMemberID = null;
        private String strMemberName = null;        
        private String strContactID = null;
        private String strContactName = null;        
        private String strContactAttachmentID = null;
        
        private string strAttachmentName;
        private string strAttachmentFileName;
        private string strAttachmentDescription;
        
                
        private static String PARAMETER_ATTACHMENT_ID = "ContactAttachmentID";
        
        private static String strCookieContactID = "ContactID";               
        
        private OleDbConnection objConnection = null;
        private OleDbCommand objDBCommand = null;       
        private OleDbDataAdapter objDbAdapter = null;			                                                
        
        private String strEventName = null;
        private String strEventComment = null;
        private String strEventStartDate = null;                        
        private String strEventEndDate = null;                        
        private String strEventStatusCode = null;
        private int iEventStatusCode = -1;
        private int iAllDayEvent = -1;        
        private int iSameDayEvent = -1;                                         		
        
        private String strBaseEventStartDate = null;
        private String strBaseEventEndDate = null;        
        
        private String strValidationErrMessage = "";
        
        //read configuration settings                                                                         
        protected void readConfigurationSettings()
        {
            strDBConnection = ConfigurationSettings.AppSettings["oleDBConnection.ConnectionString"];
        }             
               
        protected void Page_Load(Object Sender, EventArgs evt)
        {
            initPage(Sender, evt);
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
        
        protected void initPage(Object Sender, EventArgs evt)
        {
        
            Boolean bFound = false;
            
            readConfigurationSettings();       
       
			objConnection = new OleDbConnection(strDBConnection);
			
			objDBCommand = new OleDbCommand();
			
			objDBCommand.Connection = objConnection;
			        
            objConnection.Open();

            getUserInfo();            
      
            getPassedInParameters();
                
/*
                
            if (IsPostBack == false)
            {
                
                reflectState();

                    
            } //isPostBack

            
            if (IsPostBack == false)
            {            

                if (strContactAttachmentID != null)
                {
                    getBody();            
                }                    
                else
                {
                    prepareBodyForNewInsert();
                }                            
                
                savePassedInData();
                                
            }    
            
  */
            labelContactID.Text = strContactID;
                                
            labelContactName.Text = strContactName;            
            
        }                        
        
        
       private void getBody()
       {
            
       }

        


       private void savePassedInData()
       {
       
            //Review passed in parameters
            hiddenContacAttachmentID.Value = strContactAttachmentID;
            
            //save URL
            if (Request.UrlReferrer != null)
            {
                hiddenURLReferer.Value = Request.UrlReferrer.ToString();   
            }                
       
       }                                     
       
       
       private void prepareBodyForNewInsert()
       {
       


       }
       
       protected void Page_UnLoad(Object Sender, EventArgs evt)
       {
            
			objDBCommand = null;
			       
            objConnection.Close();       
			objConnection = null;
        
       }
       
       
        
        

  
        

        

        protected Boolean DBSave()
        {
        
            Boolean bInserting = false;
            Boolean bUpdated = false;
                        
            if (hiddenContacAttachmentID.Value == null)
            {
                bInserting = true;            
            }
            else
            {
                if (hiddenContacAttachmentID.Value.Length == 0)
                {
                    bInserting = true;                            
                }
                else
                {
                    bInserting = false;            
                }                    
            }                        
            
            bUpdated = DBUpdate(bInserting);        
            
            return (bUpdated);
            
        }            


        
        protected Boolean DBUpdate(Boolean bAdding )
        {
        
            String strSQL = null;
            Boolean bUpdated = false;
            Boolean bInserting = false;
            String strProcess = "";
            Boolean bValidData = false;
            


            
            int iUpdatedRecs = -1;
            
            
            OleDbParameter objDBParameterEventID = null;

            strSQL = "usp_ContactAttachmentUpdate";                
            
            strAttachmentName = editAttachmentName.Text;
            strAttachmentDescription = editAttachmentDescription.Text;
           
/*           
            labelMessage.Text = 
                                "Member ID is " +  strMemberID + "<BR>" +
                                "Contact ID is " + strContactID + "<BR>";                                
*/

            bValidData = validateData();                                
            
            if (bValidData == false)
            {
                labelMessage.Text = strValidationErrMessage + " :: validation failed";
                labelMessage.Visible = true;
                return false;
            }
            
            if (strAttachmentName == string.Empty)
            {
                strAttachmentName = editAttachmentFile.PostedFile.FileName;
            }
            
                              
            objDBCommand.CommandText = strSQL;
            objDBCommand.CommandType = CommandType.StoredProcedure;                        

            Stream objAttachmentStream = editAttachmentFile.PostedFile.InputStream;
            int    iAttachmentLength = editAttachmentFile.PostedFile.ContentLength;
            string strAttachmentContentType = editAttachmentFile.PostedFile.ContentType;
            
            byte[] objAttachmentBinaryData = new byte[iAttachmentLength];
            int iNumberofBytes = objAttachmentStream.Read(objAttachmentBinaryData, 0, iAttachmentLength); 
                        
            //labelMessage.Text = "The image size is " +  iNumberofBytes;                                  
            //labelMessage.Visible = true;
            
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

            
            OleDbParameter objDBParameterAttachmentID = new OleDbParameter();
            objDBParameterAttachmentID.OleDbType = OleDbType.VarChar;
            objDBParameterAttachmentID.Size = 88;
            objDBParameterAttachmentID.Value = System.DBNull.Value;
            objDBCommand.Parameters.Add(objDBParameterAttachmentID);
            

            OleDbParameter objDBParameterAttachmentName = new OleDbParameter();
            objDBParameterAttachmentName.OleDbType = OleDbType.VarChar;
            objDBParameterAttachmentName.Size = 255;
            objDBParameterAttachmentName.Value = strAttachmentName;
            objDBCommand.Parameters.Add(objDBParameterAttachmentName);
            
            OleDbParameter objDBParameterAttachmentFileName = new OleDbParameter();
            objDBParameterAttachmentFileName.OleDbType = OleDbType.VarChar;
            objDBParameterAttachmentFileName.Size = 255;
            objDBParameterAttachmentFileName.Value = editAttachmentFile.PostedFile.FileName;
            objDBCommand.Parameters.Add(objDBParameterAttachmentFileName);         
            
            OleDbParameter objDBParameterAttachmentContentType = new OleDbParameter();
            objDBParameterAttachmentContentType.OleDbType = OleDbType.VarChar;
            objDBParameterAttachmentContentType.Size = 255;
            objDBParameterAttachmentContentType.Value = strAttachmentContentType;
            objDBCommand.Parameters.Add(objDBParameterAttachmentContentType);                      

            OleDbParameter objDBParameterAttachmentDescription = new OleDbParameter();
            objDBParameterAttachmentDescription.OleDbType = OleDbType.VarChar;
            objDBParameterAttachmentDescription.Size = 200;
            objDBParameterAttachmentDescription.Value = strAttachmentDescription;
            objDBCommand.Parameters.Add(objDBParameterAttachmentDescription);    

            OleDbParameter objDBParameterAttachmentData = new OleDbParameter();
            objDBParameterAttachmentData.OleDbType = OleDbType.VarBinary;
            objDBParameterAttachmentData.Value = objAttachmentBinaryData;
            objDBCommand.Parameters.Add(objDBParameterAttachmentData);

            
            iUpdatedRecs = objDBCommand.ExecuteNonQuery();
            
            if (bAdding)
            {
                if (iUpdatedRecs == 1)
                {
                    //strContactAttachmentID = objDBParameterEventID.Value.ToString(); 
                    
                    //labelMessage.Text = "Address ID is " +  strContactAttachmentID;
                    
                }
            }            
                


                
            bUpdated = true;
                
            return bUpdated;        
            
        }                        
        	
        	

                	
                		




        protected void buttonSaveClicked(Object Sender, EventArgs E)
        {
                    
            Boolean bUpdated = false;
            String strRedirectURL = null;
            
            bUpdated = DBSave();
            
            if (bUpdated == false)
            {
                labelDebug.Text = "Unable to save data";        
                return;
            }
            else
            {
                labelDebug.Text = "saved data, will redirect";                        
            }
            
            
            redirect();

            labelDebug.Text = "saved data, but no redirect";        
            return;            

        }		
        
        



        protected void buttonCloseClicked(Object Sender, EventArgs E)
        {
                    
            redirect();

        }		        
        
        protected void redirect()
        {
                    
            String strRedirectURL = null;
            if (hiddenURLReferer.Value != string.Empty)
            {
                strRedirectURL = hiddenURLReferer.Value;
            }
            else if (strContactID != string.Empty)
            {
                strRedirectURL = "ContactBrowse.aspx?ContactID=" + strContactID;                        
            }
            else
            {
                strRedirectURL = "Cover.aspx";
            }
            
            //labelDebug.Text = strRedirectURL;
                         
            //Response.Write(strRedirectURL);  
                
            Response.Redirect(strRedirectURL);        
        
        }
    
          
        protected void getPassedInParameters()
        {
        
            
            strContactAttachmentID = Request[PARAMETER_ATTACHMENT_ID];
            
            //Retrieve Cookie Data
            //strContactID = Request[strCookieContactID];
            
            getStateData();
                   
            
            if (IsPostBack)
            {
            
            
            }
            else
            {

            }
            
        
        
        }
        

        
        protected void reflectState()
        {
        
            
            if (strContactAttachmentID == null)
            {
                bEventExists = false;
            }
            else
            {
                bEventExists = true;
            }        
            
            //buttonDelete.Visible = bEventExists;
            //buttonAddMore.Visible = (bEventExists == false);
            
            //no need for add more
            //buttonAddMore.Visible = false;
            
        }
        
        protected Boolean getCurrentDataFromDB()
        {
        
            Boolean bFound = false;
                        
            return bFound;
            
        
        
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
        
        
        private Boolean validateData()
        {
        
            Boolean bValid = true;
            
            strValidationErrMessage = "";
            
            if (editAttachmentFile.PostedFile.ContentLength == 0)
            {
                bValid = false;  
                strValidationErrMessage = "Please select to upload a valid file";  
            }
            
            //bValid = validateDates(); 
            
            return bValid;
        
        }
        
        


                            
					
    }


}