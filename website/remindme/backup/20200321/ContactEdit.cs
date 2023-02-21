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
    
	[Serializable]
    class dataContact : object
    {
    	

    	private string strContactID  = null; 	
    	private string strContactName  = null; 	    	
    	private string strAffliateID = null;
    	private string strProfessionID = null;
    	private string strComment = null;
    	private string strDOB = null;    	
    	
    	    	
      	public string contactID
      	{
            get{return strContactID;}
        
            set
            {
                if (strContactID != value)
                {
                    strContactID = value;
                }
            }
           
      	}          	    	

      	public string contactName
      	{
            get{return strContactName;}
        
            set
            {
                if (strContactName != value)
                {
                    strContactName = value;
                }
            }
           
      	}          	    	
      	
      	
      	public string affliateID
      	{
            get{return strAffliateID;}
        
            set
            {
                if (strAffliateID != value)
                {
                    strAffliateID = value;
                }
            }
           
      	}          	    	      	
      	

      	public string professionID
      	{
            get{return strProfessionID;}
        
            set
            {
                if (strProfessionID != value)
                {
                    strProfessionID = value;
                }
            }
           
      	}          	    	      	      	
      	    	
      	    	
      	public string comment
      	{
            get{return strComment;}
        
            set
            {
                if (strComment != value)
                {
                    strComment = value;
                }
            }
           
      	}          	    	      	      	
      	
      	
      	public string DOB
      	{
            get{return strDOB;}
        
            set
            {
                if (strDOB != value)
                {
                    strDOB = value;
                }
            }
           
      	}          	    	      	      	
      	      	
      	      	    	
    }        

    public class frmContactEdit : System.Web.UI.Page
    {
       
       
       private String strContact = null;
       
       private String strDBConnection = null;
                                        
       private OleDbConnection objConnection = null;
       private OleDbCommand objDBCommand = null;       
       private OleDbDataAdapter objDbAdapter = null;			                                        

       
	   private String strSQLQuery;
	   
	   protected DataGrid gridContactCommunicationInfo;	 
	   protected DataGrid gridContactAddressInfo;	 
	   	   
	   protected TextBox txtContact;
	   protected TextBox txtDOB;	   
	   protected TextBox txtComment;
	   protected DropDownList cbAffliate; 	   
	   protected DropDownList cbProfession; 	   
	   	   
	   
	   protected Label labelSQL;         
	   protected Label labelDebug;
	   protected Button btnSave;
	   
       protected String strMemberID  = null;	   
	   protected String strMemberName = null;
       protected String strContactName = null;              
       protected String strContactID = null;       

       private static String strCookieContactID = "ContactID";     
       private String strMode = null;  

       private String strErrMessage = "";
       
       private string SESSION_APP_DATA_ENTRY = "appDataEntry";
       
       private static string PARAMETER_MODE = "restore";       
       

       private string strAffliate = null;
       private int iAffliate = -1;
              
       private String strProfession = null;
       private int iProfession = -1;            

       private string strDOB = null;
       private string strComment = null;       

       protected HyperLink  hyperLinkContactBrowse = null;

 
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
                
                populateAffliateComboBox();  
                          
                populateProfessionComboBox();  
                
                getBody();                
                
				//btnSave.Attributes.Add("onclick","this.value='Please wait...';this.disabled = true;" + this.GetPostBackEventReference(this.btnSave));                
            
            
//                if (strContactID != null)
//                {
//                    if (strMode == "Edit")
//                    {
//                        getBody();            
//                    }
//                    else
//                    {
//                        
//                    }                        
//                }                    
//                else
//                {
//                    prepareBodyFoNewInsert();
//                }
                            
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
                      
       private void stateDataReset()
       {
       	
       		 sessionVars objSessionVars = null;
       		 
       		 objSessionVars = new remindME.stateManagement.sessionVars();
       		 
       		 	objSessionVars.Session = Session;
       		 
       		 	objSessionVars.contactID = null;
       		 	objSessionVars.contactName = null;       		 
       		 
       		 objSessionVars = null;
       	
       }                                                       
                      
       private void getPassedInData()
       {

            strMode = Request.QueryString["mode"];
           
            if (strMode == "Add")
            {
            
            	//System.Web.HttpCookie objCookie = null;
                        
                //Retrieve Cookie Data
                strContactID = null;

				//reset Cookie
				//Note this reset cookie is also used when adding/and user goes to
				//affliate & then come back
                //objCookie = new System.Web.HttpCookie(strCookieContactID); 
                //objCookie.Value = strContactID;
                //Response.Cookies.Add(objCookie);
                
                stateDataReset();
               

            }
            else if ( (strMode == "Edit") || (strMode == "Restore"))            
            {
                   
                //when restoring and we come back to an add, not that cookie should be nulled   
                //Retrieve Cookie Data
                //strContactID = Request[strCookieContactID];
                
                stateDataGet();

            
            }
       
       }               
                      
                      

       
       private void getBody()
       {
       
       		string strURL = null;
       		
            labelDebug.Text = strContactID;
            
            if (strContactID == null)
            {
            	strURL = "Cover.aspx";
			}            	
			else
            {
            	strURL = "ContactBrowse.aspx?ContactID=" + strContactID;
			}   
			         	            
			hyperLinkContactBrowse.NavigateUrl = strURL;
            
            if (strMode == "Edit")
            {
                //get Contact Info            
                getContactInfo();
                
                displayContactInfo();                
            }                
            else if (strMode == "Restore")
            {
                //get Contact Info            
                dataEntryDataRetrieve();
                
                displayContactInfo();
            }                            
            
       }            
       
       
       private void prepareBodyFoNewInsert()
       {
        
       
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


       private void getContactInfo()
       {
       
       
            OleDbDataReader objDBReader = null;
							
			strSQLQuery = "getContactRecord ? ";
		
			//labelSQL.Text = strCommunicationType;
            labelDebug.Text = "Contact Communication ID is " + strContactID;			
			
            objDBCommand.CommandText = strSQLQuery;
            
            objDBCommand.Parameters.Clear();
                
            OleDbParameter objDBParameterMemberID = new OleDbParameter();
            objDBParameterMemberID.ParameterName = "ContactID";
            objDBParameterMemberID.OleDbType = OleDbType.VarChar;
            objDBParameterMemberID.Size = 255;
            objDBParameterMemberID.Value = strContactID;
            objDBCommand.Parameters.Add(objDBParameterMemberID);
			
            objDBReader = objDBCommand.ExecuteReader();			
            
            while (objDBReader.Read())
            {
                                
                strContactName = objDBReader["Contact"].ToString();
                
                strAffliate = objDBReader["Affliation_code"].ToString();
                
                strProfession = objDBReader["Profession_code"].ToString();

                
                strDOB = objDBReader["DOB"].ToString();   
                
                strComment = objDBReader["comment"].ToString();   
			    
                                            
            }
            
            labelDebug.Text = "Contact ID is " + strContactID + 
            			      "Affliate is " + strAffliate;      
            

            
            
            objDBReader.Close();
            
            objDBReader = null;
	
       
       }                                        



       private void displayContactInfo()
       {
                                                       
            txtContact.Text = strContactName;
            selectListBox(cbAffliate, strAffliate);                     
            selectListBox(cbProfession, strProfession);                     
            txtDOB.Text = strDOB;   
            txtComment.Text = strComment;   
       
       }                                        
   		 	   
      
        

        private DataView getAffliateDataView()
        {
        
            OleDbDataAdapter objDbAdapter = null;
            DataSet objDataSet = null;
            
            DataView objDataView = null;                       
                                            
            strSQLQuery = "";
            strSQLQuery = strSQLQuery + " select affliation_code, affliation_name  ";                    
            strSQLQuery = strSQLQuery + " from affliations " ;                                            
            strSQLQuery = strSQLQuery + " where  memberIdentifier = '"  + strMemberID +  "'" ;                                
            strSQLQuery = strSQLQuery + " UNION  ";                  
            strSQLQuery = strSQLQuery + " select -1, ''  ";                    
            strSQLQuery = strSQLQuery + " order by affliation_name   ";                  
            
            objDbAdapter = new OleDbDataAdapter();            
            
            objDbAdapter.SelectCommand = new OleDbCommand(strSQLQuery, 
                                                          objConnection);
            

            objDataSet = new DataSet("DS");
            objDbAdapter.Fill(objDataSet);

            
            objDataView = objDataSet.Tables[0].DefaultView;
            
            objDataView.RowFilter = String.Empty;

                                    
            return objDataView;                                                
                

                
        }
        
        
        private void populateAffliateComboBox()
        {
        
            DataView objDataView;                      
    
            objDataView = getAffliateDataView();
            
            cbAffliate.DataSource = objDataView;
            cbAffliate.DataValueField = "affliation_code";
            cbAffliate.DataTextField = "affliation_name";                      
            
            cbAffliate.DataBind();
                                
        }        
        
        
        private DataView getProfessionDataView()
        {
        
            OleDbDataAdapter objDbAdapter = null;
            DataSet objDataSet = null;
            
            DataView objDataView = null;                       
                                            
            strSQLQuery = "";
            strSQLQuery = strSQLQuery + " select profession_code, description  ";                    
            strSQLQuery = strSQLQuery + " from   dbo.support_profession  ";                                
            strSQLQuery = strSQLQuery + " where  memberIdentifier = '"  + strMemberID +  "'" ;    
            strSQLQuery = strSQLQuery + " UNION  ";                  
            strSQLQuery = strSQLQuery + " select -1, ''  ";                    
            strSQLQuery = strSQLQuery + " order by description   ";                  
            
            objDbAdapter = new OleDbDataAdapter();            
            
            objDbAdapter.SelectCommand = new OleDbCommand(strSQLQuery, 
                                                          objConnection);
            

            objDataSet = new DataSet("DS");
            objDbAdapter.Fill(objDataSet);

            
            objDataView = objDataSet.Tables[0].DefaultView;
            
            objDataView.RowFilter = String.Empty;

                                    
            return objDataView;                                                
                

                
        }
        
        
        private void populateProfessionComboBox()
        {
        
            DataView objDataView;                      
    
            objDataView = getProfessionDataView();
            
            cbProfession.DataSource = objDataView;
            cbProfession.DataValueField = "profession_code";
            cbProfession.DataTextField = "description";                      
            
            cbProfession.DataBind();
                                
        }                
        
        
        
        protected void selectListBox(DropDownList objListControl, 
                                     String strChoice)
        {
        
            int iIndex = 0;
            int iNumberofEntries =0;
            String strItem = null;
            ListItem objListItem = null;
            
            iNumberofEntries = objListControl.Items.Count;
            
            for (iIndex = 0; iIndex < iNumberofEntries; iIndex++)
            {
                objListItem = objListControl.Items[iIndex];
                
                strItem = objListItem.Value;
                
                if (strItem == strChoice)
                {
                    objListItem.Selected = true;                    
                }
                
            }
            
        }                                         
        
        
        //Called when save button is clicked        
        protected void SaveBtnClicked(Object Sender, EventArgs E)
        {
        
            String strRedirectURL = null;
            
            if (Page.IsValid) 
            {
            
				//Trace.Write("DB", "Page is valid.  Saving data...");            		            	
				            
                DBSave();
                
                strRedirectURL = "ContactBrowse.aspx?ContactID=" + strContactID;
                
                Response.Redirect(strRedirectURL);
                
            }
            else
            {
				//Trace.Warn("DB", "Page is not valid");            		            	            	
            }
            
        }        
                 
                 


        protected Boolean DBSave()
        {
        
            Boolean bUpdated = false;
            Boolean bInserting = false;
            
            if (strContactID == null)
            {
                bInserting = true;            
            }
            else
            {
                if (strContactID.Length == 0)
                {
                    bInserting = true;                            
                }
                else
                {
                    bInserting = false;            
                }                    
            }                        
            
            if (bInserting)
            {
				//Trace.Write("DB", "Inserting...");            		
                bUpdated = DBInsert();                        
            }
            else
            {
				//Trace.Write("DB", "Updating....");            		            	
                bUpdated = DBUpdate();            
            }
            
            return bUpdated;
                
            
        }
        
            
        protected Boolean DBUpdate()
        {
        
            StringBuilder strSQLBuilder = null;
            String strSQL = null;
            Boolean bUpdated = false;
            Boolean bInserting = false;
            


                        
            strSQLBuilder = new StringBuilder();
                                        
            strSQLBuilder.Append("sp_ContactUpdate"  );                                        
                                                                
            strSQL = strSQLBuilder.ToString();
            
            //labelMessage.Text = strSQL + hiddenQuoteId.Value + "[" + hiddenQuoteId.Value.Length + "]"  ;

            OleDbConnection objDBConn = new OleDbConnection(strDBConnection);

            //OleDbCommand objDbCommand = new OleDbCommand(strSQL, objDBConn);
            
            objDBCommand.CommandType = CommandType.StoredProcedure;            

           objDBCommand.CommandText = strSQL;            
            
            
            objDBConn.Open();
            
            if (cbAffliate.SelectedItem != null)
            {
                iAffliate = Int16.Parse(cbAffliate.SelectedItem.Value);
            }   
            
            if (cbProfession.SelectedItem != null)
            {
                iProfession = Int16.Parse(cbProfession.SelectedItem.Value);
            }               
            
            strContact = txtContact.Text;
            strDOB = txtDOB.Text;
            strComment = txtComment.Text;            
        
            
            
            labelDebug.Text = "Contact is " +  strContact +
                              "DOB is " +  strDOB ;            
                              
            
            OleDbParameter objDBParameterContactID = new OleDbParameter();
            //objDBParameterContactID.ParameterName = "@strContactID";
            objDBParameterContactID.OleDbType = OleDbType.VarChar;
            objDBParameterContactID.Size = 88;
            objDBParameterContactID.Value = strContactID;
            objDBCommand.Parameters.Add(objDBParameterContactID);                
                
            OleDbParameter objDBParameterContact = new OleDbParameter();
            //objDBParameterContact.ParameterName = "@strContact";
            objDBParameterContact.OleDbType = OleDbType.VarChar;
            objDBParameterContact.Size = 88;
            objDBParameterContact.Value = strContact;
            objDBCommand.Parameters.Add(objDBParameterContact);                

            OleDbParameter objDBParameterAffliate = new OleDbParameter();
            //objDBParameterAffliate.ParameterName = "@iAffliate";
            objDBParameterAffliate.OleDbType = OleDbType.Integer;
            objDBParameterAffliate.Value = iAffliate;
            objDBCommand.Parameters.Add(objDBParameterAffliate);                
            
            OleDbParameter objDBParameterProfession = new OleDbParameter();
            //objDBParameterProfession.ParameterName = "@iProfession";
            objDBParameterProfession.OleDbType = OleDbType.Integer;
            objDBParameterProfession.Value = iProfession;
            objDBCommand.Parameters.Add(objDBParameterProfession);                


            OleDbParameter objDBParameterDOB = new OleDbParameter();
            //objDBParameterDOB.ParameterName = "@strDOB";
            objDBParameterDOB.OleDbType = OleDbType.VarChar;
            objDBParameterDOB.Value = strDOB;
            objDBCommand.Parameters.Add(objDBParameterDOB);                            

            OleDbParameter objDBParameterComment = new OleDbParameter();
            objDBParameterComment.OleDbType = OleDbType.VarChar;
            objDBParameterComment.Value = strComment;
            objDBCommand.Parameters.Add(objDBParameterComment);                            
                                                
            objDBCommand.ExecuteNonQuery();
                
            objDBCommand.Connection.Close();
                
            bUpdated = true;
                
            return bUpdated;        
            
        }                



        protected Boolean DBInsert()
        {
        
            StringBuilder strSQLBuilder = null;
            String strSQL = null;
            Boolean bUpdated = false;
            Boolean bInserting = false;
            
            int iUpdatedRecs = -1;
            
            //int iAffliate = -1;
            //int iProfession = -1;            
            //String strContact = null;
            //String strDOB = null;            
            //String strComment = null;

                        
            strSQLBuilder = new StringBuilder();
                                        
            strSQLBuilder.Append("sp_ContactInsert");                                        
                                                                
            strSQL = strSQLBuilder.ToString();
            
            //labelMessage.Text = strSQL + hiddenQuoteId.Value + "[" + hiddenQuoteId.Value.Length + "]"  ;

            
            if (cbAffliate.SelectedItem != null)
            {
                iAffliate = Int16.Parse(cbAffliate.SelectedItem.Value);
            }   
            
            if (cbProfession.SelectedItem != null)
            {
                iProfession = Int16.Parse(cbProfession.SelectedItem.Value);
            }               
            
            strContact = txtContact.Text;
            strDOB = txtDOB.Text;
            strComment = txtComment.Text;            
            
            labelDebug.Text = "Contact is " +  strContact +
                              "DOB is " +  strDOB ;            
                              

           objDBCommand.CommandType = CommandType.StoredProcedure;
           objDBCommand.Parameters.Clear();            
           objDBCommand.CommandText = strSQL;
            
            objDBCommand.Parameters.Clear();

            OleDbParameter objDBParameterMemberID = new OleDbParameter();
            objDBParameterMemberID.ParameterName = "@strMemberID";
            objDBParameterMemberID.OleDbType = OleDbType.VarChar;
            objDBParameterMemberID.Size = 88;
            objDBParameterMemberID.Value = strMemberID;
            objDBParameterMemberID.Direction = ParameterDirection.Input;                        
            objDBCommand.Parameters.Add(objDBParameterMemberID);

                
            OleDbParameter objDBParameterContact = new OleDbParameter();
            objDBParameterContact.ParameterName = "Contact";
            objDBParameterContact.OleDbType = OleDbType.VarChar;
            objDBParameterContact.Size = 88;
            objDBParameterContact.Value = strContact;
            objDBParameterContact.Direction = ParameterDirection.Input;                        
            objDBCommand.Parameters.Add(objDBParameterContact);                

            OleDbParameter objDBParameterAffliate = new OleDbParameter();
            objDBParameterAffliate.ParameterName = "Affliate";
            objDBParameterAffliate.OleDbType = OleDbType.Integer;
            objDBParameterAffliate.Value = iAffliate;
            objDBParameterAffliate.Direction = ParameterDirection.Input;                                    
            objDBCommand.Parameters.Add(objDBParameterAffliate);                
            
            OleDbParameter objDBParameterProfession = new OleDbParameter();
            objDBParameterProfession.ParameterName = "Profession";
            objDBParameterProfession.OleDbType = OleDbType.Integer;
            objDBParameterProfession.Value = iProfession;
            objDBParameterProfession.Direction = ParameterDirection.Input;                                    
            objDBCommand.Parameters.Add(objDBParameterProfession);                

            OleDbParameter objDBParameterDOB = new OleDbParameter();
            objDBParameterDOB.ParameterName = "DOB";            
            objDBParameterDOB.OleDbType = OleDbType.VarChar;
            objDBParameterDOB.Value = strDOB;
            objDBParameterDOB.Direction = ParameterDirection.Input;                                                
            objDBCommand.Parameters.Add(objDBParameterDOB);                            
            
            OleDbParameter objDBParameterComment = new OleDbParameter();
            objDBParameterComment.ParameterName = "Comment";
            objDBParameterComment.OleDbType = OleDbType.VarChar;
            objDBParameterComment.Value = strComment;
            objDBParameterComment.Direction = ParameterDirection.Input;                                                
            objDBCommand.Parameters.Add(objDBParameterComment);                            
            
            OleDbParameter objDBParameterContactID = new OleDbParameter();
            objDBParameterContactID.ParameterName = "@strContactIDOut";
            objDBParameterContactID.Size = 255;                        
            objDBParameterContactID.Direction = ParameterDirection.Output;            
            objDBParameterContactID.OleDbType = OleDbType.VarChar;
            objDBCommand.Parameters.Add(objDBParameterContactID);                            
                                                
            iUpdatedRecs = objDBCommand.ExecuteNonQuery();
            
           
            if (iUpdatedRecs == 1)
            {
                strContactID = objDBParameterContactID.Value.ToString(); 
                
                labelDebug.Text = "Contact is " +  strContact +
                                  "Contact ID is " +  strContactID +                            
                                  "DOB is " +  strDOB ;                                                              
            }
                
            objDBCommand.Connection.Close();
                
            bUpdated = true;
                
            return bUpdated;        
            
        }                
        
        
        
      protected void serverValidationDOB(object source, ServerValidateEventArgs args)
      {
      
         DateTime dtDOB = new DateTime();
         
         try 
         {
         
            if (args.Value != "")
            {
                dtDOB = DateTime.Parse(args.Value);
            }
                            
            args.IsValid = true;
         }
         catch
         {
            strErrMessage = strErrMessage + "DOB is not valid date";
            args.IsValid = false;
         }
         
      }
      
      
        protected void htmlAnchorManageListClick(Object objSender, EventArgs e)
        {
    
            string strRedirectURL = null;
            string strSenderID = null;
         
         	strSenderID = ((HtmlAnchor)(objSender)).ID;
                    	
        	if (strSenderID == "htmlAnchorManageAffliates")
        	{
        	    strRedirectURL = "SupportAffliates.aspx";
        	}
        	else if (strSenderID == "htmlAnchorManageProfessions")
        	{
        	    strRedirectURL = "SupportProfessions.aspx";
        	}        	
        	else
        	{
        	    return;
        	}        	
        	
        	dataEntryDataSave();
        	        	
    		strRedirectURL = strRedirectURL;
                
            Response.Redirect(strRedirectURL);
        	
        }      
      
      
		private void dataEntryDataSave()
		{
		
		   	//saveData
        	dataContact objDataContact = new dataContact();
        	
        	objDataContact.contactName = txtContact.Text;
        	
        	try
        	{
        	    strAffliate = cbAffliate.SelectedItem.Value;
        	    objDataContact.affliateID = strAffliate;        	
            }
            catch(Exception)
            {
            }        	    


        	try
        	{
        	    strProfession = cbProfession.SelectedItem.Value;
        	    objDataContact.professionID = strProfession;        	
            }
            catch(Exception)
            {
            }        	    
            
            objDataContact.DOB = txtDOB.Text;   
            objDataContact.comment = txtComment.Text;               
	        
	        Session[SESSION_APP_DATA_ENTRY] = objDataContact;
	        
	    }
	    
	    
		protected Boolean dataEntryDataRetrieve()
		{

			Boolean bRetrieved = false;				
							
			try
			{


        	    dataContact objDataContact = null;

				//get data	        					
		        objDataContact = (dataContact) Session[SESSION_APP_DATA_ENTRY];		
		        
               	strContactName = objDataContact.contactName;
        	    strAffliate = objDataContact.affliateID;        	               	
        	    strProfession = objDataContact.professionID;        	
        	    strComment = objDataContact.comment;        	
        	    strDOB = objDataContact.DOB;        	
        	            	            	    
	        	bRetrieved = true;

		        
	        }
			catch(Exception )
			{
				
			}
			
			return (bRetrieved);
			
	    }	    

        
    }
    
    
    


}