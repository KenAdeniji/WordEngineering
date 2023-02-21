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

    public class frmContactAddressEdit : System.Web.UI.Page
    {
       
       
       private String strContact = null;
       
       private String strDBConnection = null;
                                        
       private OleDbConnection objConnection = null;
       private OleDbCommand objDBCommand = null;       
       private OleDbDataAdapter objDbAdapter = null;			                                        

       
	   private String strSQLQuery;
	   
	   protected DataGrid gridContactCommunicationInfo;	 
	   protected DataGrid gridContactAddressInfo;	 
	   	   
       protected HtmlInputHidden hiddenContactAddressID;	   
	   protected TextBox txtAddress1;
	   protected TextBox txtAddress2;
	   protected TextBox txtCity;	   
	   protected TextBox txtState;	
	   protected TextBox txtPostalCode;	      
	   protected TextBox txtCountry;	   
	   protected TextBox txtComment;	   	   
	   protected CheckBox chkActive;
	   
	   protected Label labelSQL;         
	   protected Label labelDebug;
	   
       protected String strMemberID  = null;	   
       protected String strMemberName  = null;	          
       protected String strContactID = null;       
       protected String strContactName = null;              
       protected String strContactAddressID = null;
       
	   protected Label labelContactID;         	   
	   protected Label labelContactName;         	          

       private static String strCookieContactID = "ContactID";       
       
       private static String strContactAddressIDParameter = "ContactAddressID";              


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
            
                if (strContactAddressID != null)
                {
                    getBody();            
                }                    
                else
                {
                    prepareBodyFoNewInsert();
                }
                
                labelContactID.Text = strContactID;
                                
                labelContactName.Text = strContactName;
                            
            }


            
            
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
       
            //Review passed in parameters
            strContactAddressID = Request[strContactAddressIDParameter];       
       
       }               
                      
                      
       private void savePassedInData()
       {
       
            //Review passed in parameters
            hiddenContactAddressID.Value = strContactAddressID;
       
       }                                     
       
       private void getBody()
       {
            
            //get Contact Info            
            getContactCommunicationInfo();
            
            
       }            
       
       
       private void prepareBodyFoNewInsert()
       {
        
            chkActive.Checked = true;                                       
       
       }


       private void getContactCommunicationInfo()
       {
       
       
            OleDbDataReader objDBReader = null;
            String          strActive = null;
            Boolean         bActive = false;
            
            String          strCommunicationType = null;
            int             iCommunicationType = -1;
            
							
			strSQLQuery = "getContactAddressRecord";
		
			labelSQL.Text = strCommunicationType;
            labelDebug.Text = "Contact Communication ID is " + strContactAddressID;			
			
            objDBCommand.CommandText = strSQLQuery;
            
            objDBCommand.CommandType = CommandType.StoredProcedure;                        
            
            objDBCommand.Parameters.Clear();
                
            OleDbParameter objDBParameterMemberID = new OleDbParameter();
            objDBParameterMemberID.ParameterName = "contactCommunicationID";
            objDBParameterMemberID.OleDbType = OleDbType.VarChar;
            objDBParameterMemberID.Size = 255;
            objDBParameterMemberID.Value = strContactAddressID;
            objDBCommand.Parameters.Add(objDBParameterMemberID);
			
            objDBReader = objDBCommand.ExecuteReader();			
            
            while (objDBReader.Read())
            {
                                
                txtAddress1.Text = objDBReader["Address1"].ToString();
                txtAddress2.Text = objDBReader["Address2"].ToString();   
                txtCity.Text = objDBReader["City"].ToString();                   
                txtState.Text = objDBReader["State"].ToString();                   
                txtPostalCode.Text = objDBReader["PostalCode"].ToString();                   
                txtCountry.Text = objDBReader["Country"].ToString();                                   
                txtComment.Text = objDBReader["comment"].ToString();                                   
                                                                
                strActive = objDBReader["Active"].ToString();
                
			    //labelSQL.Text = strCommunicationType;                
			    
                                            
            }
            
            
            if (strActive == "0")
            {
                bActive = false;            
            }
            else
            {
                bActive = true;            
            }            
            
            chkActive.Checked = bActive;            
            
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
            
            strRedirectURL = "ContactBrowse.aspx?ContactID=" + strContactID;
            
            Response.Redirect(strRedirectURL);
            
        }        
                  


        protected Boolean DBSave()
        {
        
            Boolean bUpdated = false;
            Boolean bInserting = false;
            
            if (hiddenContactAddressID.Value == null)
            {
                bInserting = true;            
            }
            else
            {
                if (hiddenContactAddressID.Value.Length == 0)
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
            
            String strAddress1 = null;
            String strAddress2 = null;            
            String strCity = null;            
            String strState = null;            
            String strPostalCode = null;            
            String strCountry = null;            
            String strComment = null;                        
            int iActive = 0;
            
            int iUpdatedRecs = -1;
            
            OleDbParameter objDBParameterAddressID = null;

                        
            strSQLBuilder = new StringBuilder();
                
            if (bAdding)
            {                            
                strSQLBuilder.Append("sp_ContactAddressInsert");                                        
            }
            else                
            {                            
                strSQLBuilder.Append("sp_ContactAddressUpdate");                                        
            }
                                                                            
            strSQL = strSQLBuilder.ToString();
            
            //labelMessage.Text = strSQL + hiddenQuoteId.Value + "[" + hiddenQuoteId.Value.Length + "]"  ;
            
            strAddress1 = txtAddress1.Text;             
            strAddress2 = txtAddress2.Text;
            strCity = txtCity.Text;
            strState = txtState.Text;
            strPostalCode = txtPostalCode.Text;            
            strCountry = txtCountry.Text;
            strComment = txtComment.Text;
            
            if (chkActive.Checked == true)
            {
                iActive = 1;
            }   
            else                        
            {
                iActive = 0;
            }              
            
            
            labelDebug.Text = "Address1 is " +  strAddress1 +
                              "active is " +  iActive ;            
                              
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
                        
                OleDbParameter objDBParameterContactAddressID = new OleDbParameter();
                objDBParameterContactAddressID.OleDbType = OleDbType.VarChar;
                objDBParameterContactAddressID.Size = 88;
                objDBParameterContactAddressID.Value = strContactAddressID;
                objDBCommand.Parameters.Add(objDBParameterContactAddressID);
                
            }                
            
            
                
            OleDbParameter objDBParameterContactAddress1 = new OleDbParameter();
            objDBParameterContactAddress1.OleDbType = OleDbType.VarChar;
            objDBParameterContactAddress1.Size = 255;
            objDBParameterContactAddress1.Value = strAddress1;
            objDBCommand.Parameters.Add(objDBParameterContactAddress1);
            
            OleDbParameter objDBParameterContactAddress2 = new OleDbParameter();
            objDBParameterContactAddress2.OleDbType = OleDbType.VarChar;
            objDBParameterContactAddress2.Size = 255;
            objDBParameterContactAddress2.Value = strAddress2;
            objDBCommand.Parameters.Add(objDBParameterContactAddress2);            
            
            OleDbParameter objDBParameterContactCity = new OleDbParameter();
            objDBParameterContactCity.OleDbType = OleDbType.VarChar;
            objDBParameterContactCity.Size = 255;
            objDBParameterContactCity.Value = strCity;
            objDBCommand.Parameters.Add(objDBParameterContactCity);            
            
            OleDbParameter objDBParameterContactState = new OleDbParameter();
            objDBParameterContactState.OleDbType = OleDbType.VarChar;
            objDBParameterContactState.Size = 255;
            objDBParameterContactState.Value = strState;
            objDBCommand.Parameters.Add(objDBParameterContactState);                        
            
            OleDbParameter objDBParameterContactPostalCode = new OleDbParameter();
            objDBParameterContactPostalCode.OleDbType = OleDbType.VarChar;
            objDBParameterContactPostalCode.Size = 255;
            objDBParameterContactPostalCode.Value = strPostalCode;
            objDBCommand.Parameters.Add(objDBParameterContactPostalCode);                                    
            
            OleDbParameter objDBParameterContactCountry = new OleDbParameter();
            objDBParameterContactCountry.OleDbType = OleDbType.VarChar;
            objDBParameterContactCountry.Size = 255;
            objDBParameterContactCountry.Value = strCountry;
            objDBCommand.Parameters.Add(objDBParameterContactCountry);                                                
            
            
            OleDbParameter objDBParameterContactComment = new OleDbParameter();
            objDBParameterContactComment.OleDbType = OleDbType.VarChar;
            objDBParameterContactComment.Size = 255;
            objDBParameterContactComment.Value = strComment;
            objDBCommand.Parameters.Add(objDBParameterContactComment);                                                
                        
            
            OleDbParameter objDBParameterActive = new OleDbParameter();
            objDBParameterActive.OleDbType = OleDbType.Integer;
            objDBParameterActive.Value = iActive;
            objDBCommand.Parameters.Add(objDBParameterActive);                                        
            

            if (bAdding)
            {
                objDBParameterAddressID = new OleDbParameter();
                objDBParameterAddressID.OleDbType = OleDbType.VarChar;
                objDBParameterAddressID.Value = "";
                objDBParameterAddressID.Size = 255;            
                objDBParameterAddressID.Direction = ParameterDirection.Output;                        
                objDBCommand.Parameters.Add(objDBParameterAddressID);                                        
            }            
                        
                                                
            iUpdatedRecs = objDBCommand.ExecuteNonQuery();
            
            if (bAdding)
            {
                if (iUpdatedRecs == 1)
                {
                    strContactAddressID = objDBParameterAddressID.Value.ToString(); 
                    
                    labelDebug.Text = "Address ID is " +  strContactAddressID;
                    
                }
            }            
                
                
            bUpdated = true;
                
            return bUpdated;        
            
        }                


             
        
    }


}