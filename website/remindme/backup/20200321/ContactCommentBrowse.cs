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
            

    public class frmContactCommentBrowse : System.Web.UI.Page
    {
       
       
       private String strContact = null;
       
       private String strDBConnection = null;
                                        
       private OleDbConnection objConnection = null;
       private OleDbCommand objDBCommand = null;       
       private OleDbDataAdapter objDbAdapter = null;			                                        

       
	   private String strSQLQuery;
	   
	   protected DataGrid gridContactCommentInfo;	 
	   protected DataGrid gridContactAddressInfo;	 
	   	   
	   protected Label labelContact;
	   protected Label labelContactProfession;
	   protected Label labelContactAffliate;	   	   
	   protected Label labelContactComment;
	   protected Label labelContactName;         	           
	    	   
	   protected Label labelSQL;         
	   
	   
	   
	   protected HyperLink idAnchorContactBrowse;
	   protected HyperLink idAnchorAddContactCommunication;
	   protected HtmlAnchor hyperLinkEditCustomer;
	   
       protected String strMemberID  = null;	   
       protected String strMemberName  = null;	          
       protected String strContactID = null;
       protected String strContactName = null;       
       protected String strContactCommentID = null;
              
       private static String strCookieContactID = "ContactID";
       
       private static String strContactCommentIDParameter = "CommentID";

       
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

               getBody();            
                            
            }                      
            
       }                                               
        
        
       protected void Page_UnLoad(Object Sender, EventArgs evt)
       {
            
			objDBCommand = null;
			       
            objConnection.Close();       
			objConnection = null;
			

        
       }               
       
       
       private void getBody()
       {
            
            String strRedirectURL = null;
            
            loadCommentGrid();
            
            strRedirectURL = "ContactBrowse.aspx?ContactID=" + strContactID;
            
            idAnchorContactBrowse.NavigateUrl = strRedirectURL;
            
            labelContactName.Text = strContactName;            
                        
            
       }                                        


       
       
       private DataView getContactCommentInfo()
	   {
			

            OleDbDataAdapter objDbAdapter = null;			                                        			
			DataSet objDataSet = null;
		    DataView objDataView = null;	
			
			strSQLQuery = "getContactCommentInfo";
		
			labelSQL.Text = strSQLQuery;

		    objDBCommand.Parameters.Clear();				            
		    			
            objDBCommand.CommandText = strSQLQuery;
            objDBCommand.CommandType = CommandType.StoredProcedure;            
                
            OleDbParameter objDBParameterMemberID = new OleDbParameter();
            objDBParameterMemberID.ParameterName = "@memberIdentifier";
            objDBParameterMemberID.OleDbType = OleDbType.VarChar;
            objDBParameterMemberID.Size = 255;
            objDBParameterMemberID.Value = strMemberID; 
            objDBCommand.Parameters.Add(objDBParameterMemberID);
            
            OleDbParameter objDBParameterMemberContactID = new OleDbParameter();
            objDBParameterMemberContactID.ParameterName = "@contactIdentifier";
            objDBParameterMemberContactID.OleDbType = OleDbType.VarChar;
            objDBParameterMemberContactID.Size = 255;
            objDBParameterMemberContactID.Value = strContactID; 
            objDBCommand.Parameters.Add(objDBParameterMemberContactID);            
			
	
            objDbAdapter = new OleDbDataAdapter();            


            objDbAdapter.SelectCommand = objDBCommand;

            objDataSet = new DataSet("namedetails");
            
            objDbAdapter.Fill(objDataSet);						
            
			
			objDataView = objDataSet.Tables[0].DefaultView;
			
			objDataView.RowFilter = String.Empty;
			
			
			return objDataView;
						
		}              
       
       
	   private void loadCommentGrid()
	   {
		
			ICollection objNames = null;
			
			//get Names
			objNames = getContactCommentInfo();
					
			//set data source
			gridContactCommentInfo.DataSource = objNames;
			
			//data Bind
			gridContactCommentInfo.DataBind();
			
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
                      
                      

                  

    }


}