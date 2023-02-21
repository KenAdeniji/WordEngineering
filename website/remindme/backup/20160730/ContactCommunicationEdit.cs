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
    
	/*
		Introduction to Serialization
		by: Rincewind
		http://www.csharpfriends.com/Articles/getArticle.aspx?articleID=94
	*/
	[Serializable]
    class dataContactCommunication : object
    {
    	
    	private string strContactCommunicationID  = null; 	
    	private string strType  = null; 	
    	private string strItem  = null; 	
    	private string strComment = null;    	
    	private string strActive = null;    	    	
    	
      	public string ContactCommunicationID
      	{
            get{return strContactCommunicationID;}
        
            set
            {
                if (strContactCommunicationID != value)
                {
                    strContactCommunicationID = value;
                }
            }
           
      	}          	    	    	
    	    	
      	public string Type
      	{
            get{return strType;}
        
            set
            {
                if (strType != value)
                {
                    strType = value;
                }
            }
           
      	}          	    	

      	public string Item
      	{
            get{return strItem;}
        
            set
            {
                if (strItem != value)
                {
                    strItem = value;
                }
            }
           
      	}          	    	      	    	
      	    	
      	public string Comment
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
      	
      	public string Active
      	{
            get{return strActive;}
        
            set
            {
                if (strActive != value)
                {
                    strActive = value;
                }
            }
           
      	}          	    	      	      	      	

    }        
    
        

    public class frmContactCommunicationEdit : System.Web.UI.Page
    {
       
       
       private String strContact = null;
       
       private String strDBConnection = null;
                                        
       private OleDbConnection objConnection = null;
       private OleDbCommand objDBCommand = null;       
       private OleDbDataAdapter objDbAdapter = null;			                                        

       
	   private String strSQLQuery;
	   
	   protected DataGrid gridContactCommunicationInfo;	 
	   protected DataGrid gridContactAddressInfo;	 
	   protected DropDownList cbCommunicationType; 
	   	   
       protected HtmlInputHidden hiddenContactCommunicationID;	   
	   protected TextBox txtCommunicationData;
	   protected TextBox txtCommunicationComment;
	   protected CheckBox chkActive;
	   
	   protected Label labelSQL;         
	   protected Label labelDebug;
	   
	   protected Label labelContactID;         	   
	   protected Label labelContactName;         	   
	   	   
       protected String strMemberID  = null;	   
       protected String strMemberName  = null;
       protected String strContactID = null; 
       protected String strContactName = null;
       protected String strContactCommunicationID = null;

       //private static String strCookieContactID = "ContactID";       
       
       private String strCommunicationTypeID = null;
       
       private string SESSION_APP_DATA_ENTRY = "appDataEntry";
       private static string PARAMETER_MODE = "restore";              
	   private String strMode = null;

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
                
                populateCommunicationTypeComboBox();            
                
                if (strMode == "Restore")
                {
					dataEntryDataRetrieve();                	
                }
                else if (strContactCommunicationID != null)
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
       
            strMode = Request.QueryString["mode"];
                   
            //Retrieve Cookie Data
            //strContactID = Request[strCookieContactID];
            
            getStateData();
       
            //Review passed in parameters
            strContactCommunicationID = Request["ContactCommunicationID"];       
       
       }               
                      
                      
       private void savePassedInData()
       {
       
            //Review passed in parameters
            hiddenContactCommunicationID.Value = strContactCommunicationID;
       
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
            
							
			strSQLQuery = "getContactCommunicationRecord";
		
			labelSQL.Text = strCommunicationType;
            labelDebug.Text = "Contact Communication ID is " + strContactCommunicationID;			
			
            objDBCommand.CommandText = strSQLQuery;
            
            objDBCommand.CommandType = CommandType.StoredProcedure;            
            
            objDBCommand.Parameters.Clear();
                
            OleDbParameter objDBParameterMemberID = new OleDbParameter();
            objDBParameterMemberID.ParameterName = "contactCommunicationID";
            objDBParameterMemberID.OleDbType = OleDbType.VarChar;
            objDBParameterMemberID.Size = 255;
            objDBParameterMemberID.Value = strContactCommunicationID;
            objDBCommand.Parameters.Add(objDBParameterMemberID);
			
            objDBReader = objDBCommand.ExecuteReader();			
            
            while (objDBReader.Read())
            {

                strCommunicationType = objDBReader["CommunicationTypeID"].ToString();
                iCommunicationType = Int16.Parse(strCommunicationType);
                                
                txtCommunicationData.Text = objDBReader["CommunicationData"].ToString();
                txtCommunicationComment.Text = objDBReader["Comment"].ToString();   
                strActive = objDBReader["Active"].ToString();
                
			    //labelSQL.Text = strCommunicationType;                
			    
                                            
            }
            
            selectListBox(cbCommunicationType, strCommunicationType); 
            
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
        
        

        private DataView getCommunicationTypeDataView()
        {
        
            OleDbDataAdapter objDbAdapter = null;
            DataSet objDataSet = null;
            
            DataView objDataView = null;                       
                                            
            strSQLQuery = "";
            strSQLQuery = strSQLQuery + " select * from support_communication  ";                    
            strSQLQuery = strSQLQuery + " order by comm_type ";                  

            
            objDbAdapter = new OleDbDataAdapter();            
            
            objDbAdapter.SelectCommand = new OleDbCommand(strSQLQuery, 
                                                          objConnection);
            

            objDataSet = new DataSet("DS");
            objDbAdapter.Fill(objDataSet);

            
            objDataView = objDataSet.Tables[0].DefaultView;
            
            objDataView.RowFilter = String.Empty;

                                    
            return objDataView;                                                
                

                
        }
        
        
        private void populateCommunicationTypeComboBox()
        {
        
            DataView objDataView;                      
    
            objDataView = getCommunicationTypeDataView();
            
            cbCommunicationType.DataSource = objDataView;
            cbCommunicationType.DataValueField = "id";
            cbCommunicationType.DataTextField = "comm_type";                      
            
            cbCommunicationType.DataBind();
                                
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
            
            DBSave();
            
            strRedirectURL = "ContactBrowse.aspx?ContactID=" + strContactID;
            
            Response.Redirect(strRedirectURL);
            
        }        
                  


        protected Boolean DBSave()
        {
        
            Boolean bUpdated = false;
            Boolean bInserting = false;
            
            if (hiddenContactCommunicationID.Value == null)
            {
                bInserting = true;            
            }
            else
            {
                if (hiddenContactCommunicationID.Value.Length == 0)
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
                bUpdated = DBInsert();                        
            }
            else
            {
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
            
            int iCommunicationType = -1;
            String strCommunicate = null;
            String strComment = null;
            int iActive = 0;

            try
			{
			
				labelDebug.Text = "";			
				labelDebug.Visible = false;
            
				strSQLBuilder = new StringBuilder();
											
				strSQLBuilder.Append(" exec " + "" + "sp_ContactCommunicationUpdate " + " " );                                        
				strSQLBuilder.Append(" ?, ?, ?, ?, ? ");
					
	
																	
				strSQL = strSQLBuilder.ToString();
				
				//labelMessage.Text = strSQL + hiddenQuoteId.Value + "[" + hiddenQuoteId.Value.Length + "]"  ;
	
				OleDbConnection objDBConn = new OleDbConnection(strDBConnection);
	
				OleDbCommand objDbCommand = new OleDbCommand(strSQL, objDBConn);
				
				objDBConn.Open();
				
				if (cbCommunicationType.SelectedItem != null)
				{
					iCommunicationType = Int16.Parse(cbCommunicationType.SelectedItem.Value);
				}   
				
				strCommunicate = txtCommunicationData.Text;             
				strComment = txtCommunicationComment.Text;
				
				if (chkActive.Checked == true)
				{
					iActive = 1;
				}   
				else                        
				{
					iActive = 0;
				}              
				
				
				labelDebug.Text = "Communication Data is " +  strCommunicate +
								  "Communication active is " +  iActive ;            
							
				OleDbParameter objDBParameterContactCommunicationID = new OleDbParameter();
				objDBParameterContactCommunicationID.ParameterName = "ContactCommunicationID";
				objDBParameterContactCommunicationID.OleDbType = OleDbType.VarChar;
				objDBParameterContactCommunicationID.Size = 88;
				objDBParameterContactCommunicationID.Value = strContactCommunicationID;
				objDbCommand.Parameters.Add(objDBParameterContactCommunicationID);
					
	
				OleDbParameter objDBParameterCommunicationType = new OleDbParameter();
				objDBParameterCommunicationType.ParameterName = "ContactCommunicationType";
				objDBParameterCommunicationType.OleDbType = OleDbType.Integer;
				objDBParameterCommunicationType.Value = iCommunicationType;
				objDbCommand.Parameters.Add(objDBParameterCommunicationType);                
				
				OleDbParameter objDBParameterCommunicate = new OleDbParameter();
				objDBParameterCommunicate.ParameterName = "Communicate";
				objDBParameterCommunicate.OleDbType = OleDbType.VarChar;
				objDBParameterCommunicate.Value = strCommunicate;
				objDbCommand.Parameters.Add(objDBParameterCommunicate);                            
	
	
				OleDbParameter objDBParameterComment = new OleDbParameter();
				objDBParameterComment.ParameterName = "Comment";
				objDBParameterComment.OleDbType = OleDbType.VarChar;
				objDBParameterComment.Value = strComment;
				objDbCommand.Parameters.Add(objDBParameterComment);                            
				
				OleDbParameter objDBParameterActive = new OleDbParameter();
				objDBParameterActive.ParameterName = "Active";
				objDBParameterActive.OleDbType = OleDbType.Integer;
				objDBParameterActive.Value = iActive;
				objDbCommand.Parameters.Add(objDBParameterActive);                                        
													
				objDbCommand.ExecuteNonQuery();
					
				objDbCommand.Connection.Close();
					
				bUpdated = true;
				
			}	
			catch (Exception ex)
			{			
				labelDebug.Text = "Exception in save " + ex.Message;
				labelDebug.Visible = true;
			}	
            return bUpdated;        
            
        }                


        protected Boolean DBInsert()
        {
        
            StringBuilder strSQLBuilder = null;
            String strSQL = null;
            Boolean bUpdated = false;
            Boolean bInserting = false;
            
            int iCommunicationType = -1;
            String strCommunicate = null;
            String strComment = null;
            int iActive = 0;

                        
            strSQLBuilder = new StringBuilder();
                                        
            strSQLBuilder.Append(" exec " + "" + "sp_ContactCommunicationInsert " + " " );                                        
            strSQLBuilder.Append(" ?, ?, ?, ?, ?, ? ");
                

                                                                
            strSQL = strSQLBuilder.ToString();
            
            //labelMessage.Text = strSQL + hiddenQuoteId.Value + "[" + hiddenQuoteId.Value.Length + "]"  ;

            OleDbConnection objDBConn = new OleDbConnection(strDBConnection);

            OleDbCommand objDbCommand = new OleDbCommand(strSQL, objDBConn);
            
            objDBConn.Open();
            
            if (cbCommunicationType.SelectedItem != null)
            {
                iCommunicationType = Int16.Parse(cbCommunicationType.SelectedItem.Value);
            }   
            
            strCommunicate = txtCommunicationData.Text;             
            strComment = txtCommunicationComment.Text;
            
            if (chkActive.Checked == true)
            {
                iActive = 1;
            }   
            else                        
            {
                iActive = 0;
            }              
            
            
            labelDebug.Text = "Member ID is " +  strMemberID + " " +
                              "Contact ID is " +  strContactID + " " +                     
                              "Communication Type is " +  iCommunicationType + " " +                                           
                              "Communication Data is " +  strCommunicate + " " +           
                              "Communication active is " +  iActive ;            
                              
                        
            OleDbParameter objDBParameterMemberID = new OleDbParameter();
            objDBParameterMemberID.ParameterName = "MemberID";
            objDBParameterMemberID.OleDbType = OleDbType.VarChar;
            objDBParameterMemberID.Size = 88;
            objDBParameterMemberID.Value = strMemberID;
            objDbCommand.Parameters.Add(objDBParameterMemberID);

            OleDbParameter objDBParameterContactID = new OleDbParameter();
            objDBParameterContactID.ParameterName = "ContactID";
            objDBParameterContactID.OleDbType = OleDbType.VarChar;
            objDBParameterContactID.Value = strContactID;
            objDbCommand.Parameters.Add(objDBParameterContactID);                
            
            OleDbParameter objDBParameterCommunicationType = new OleDbParameter();
            objDBParameterCommunicationType.ParameterName = "ContactCommunicationType";
            objDBParameterCommunicationType.OleDbType = OleDbType.Integer;
            objDBParameterCommunicationType.Value = iCommunicationType;
            objDbCommand.Parameters.Add(objDBParameterCommunicationType);                            
            
            OleDbParameter objDBParameterCommunicate = new OleDbParameter();
            objDBParameterCommunicate.ParameterName = "Communicate";
            objDBParameterCommunicate.OleDbType = OleDbType.VarChar;
            objDBParameterCommunicate.Value = strCommunicate;
            objDbCommand.Parameters.Add(objDBParameterCommunicate);                            


            OleDbParameter objDBParameterComment = new OleDbParameter();
            objDBParameterComment.ParameterName = "Comment";
            objDBParameterComment.OleDbType = OleDbType.VarChar;
            objDBParameterComment.Value = strComment;
            objDbCommand.Parameters.Add(objDBParameterComment);                            
            
            OleDbParameter objDBParameterActive = new OleDbParameter();
            objDBParameterActive.ParameterName = "Active";
            objDBParameterActive.OleDbType = OleDbType.Integer;
            objDBParameterActive.Value = iActive;
            objDbCommand.Parameters.Add(objDBParameterActive);                                        
                                                
            objDbCommand.ExecuteNonQuery();
                
            objDbCommand.Connection.Close();
                
            bUpdated = true;
                
            return bUpdated;        
            
        }                
        

    protected void htmlAnchorManageListClick(Object objSender, EventArgs e)
    {

        string strRedirectURL = null;
        string strSenderID = null;
     
     	strSenderID = ((HtmlAnchor)(objSender)).ID;
                	
    	if (strSenderID == "htmlAnchorManageCommunicationTypes")
    	{
    	    strRedirectURL = "SupportCommunicationTypes.aspx";
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
        	dataContactCommunication objDataContactCommunication = new dataContactCommunication();
        	
        	objDataContactCommunication.ContactCommunicationID = hiddenContactCommunicationID.Value;
        	
        	try
        	{
        	    strCommunicationTypeID = cbCommunicationType.SelectedItem.Value;
        	    objDataContactCommunication.Type = strCommunicationTypeID;        	
            }
            catch(Exception)
            {
            }        	    


            objDataContactCommunication.Item = txtCommunicationData.Text;               
            
            objDataContactCommunication.Comment = txtCommunicationComment.Text;  
            
            if (chkActive.Checked)
            {
            	objDataContactCommunication.Active = "Y";            	
            }
            else
            {
            	objDataContactCommunication.Active = "N";
            }             
	        
	        Session[SESSION_APP_DATA_ENTRY] = objDataContactCommunication;
	        
	        
	    } //dataEntryDataSave()
	    
	    
		protected Boolean dataEntryDataRetrieve()
		{

			Boolean bRetrieved = false;				

			try
			{


	        	dataContactCommunication objDataContactCommunication = null;

				//get data	        					
		        objDataContactCommunication = (dataContactCommunication) Session[SESSION_APP_DATA_ENTRY];		
		 
		 		hiddenContactCommunicationID.Value = objDataContactCommunication.ContactCommunicationID;
		 		cbCommunicationType.SelectedValue = objDataContactCommunication.Type;      
            	txtCommunicationData.Text = objDataContactCommunication.Item;               		        
               	txtCommunicationComment.Text = objDataContactCommunication.Comment;
				chkActive.Checked = (objDataContactCommunication.Active == "Y");            	
        	            	            	    
	        	bRetrieved = true;

		        
	        }
			catch(Exception )
			{
				
			}
		
			return (bRetrieved);
			
	    }	//dataEntryDataRetrieve()    

        
    } //    public class frmContactCommunicationEdit : System.Web.UI.Page   


} //namespace EphraimTech.RemindME