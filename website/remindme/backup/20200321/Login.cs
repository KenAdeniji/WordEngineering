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
    using System.Web; //URLReferrer
    using System.Configuration;
    

    public class frmLogin : System.Web.UI.Page
    {
        

        protected Label labelErrMessage;
		protected Label labelReferrerURL;
		protected Label labelRedirectURL;
		
        protected TextBox  txtMemberName;
        protected TextBox  txtMemberPassword;        
        protected HtmlInputHidden redirectURL;        
        protected HtmlInputHidden referrerURL;                
        protected CheckBox chkRememberMe;
        
        protected Label labelSQL;        
        
        String strMemberID = null;                
        String strMemberName = "";
        String strMemberPassword = "";      
		String strFullyQualifiedUsername = "";
		
		protected static String defaultDomainName = "ephraimtech.com";
        Boolean bPersists = false;
        
        public String strRedirectURL;                      
        public String strReferrer = null;

        String strDBConnection = null;


        //read configuration settings                                                                         
        protected void readConfigurationSettings()
        {
            //strDBConnection = ConfigurationSettings.AppSettings["oleDBConnection.ConnectionString"];
            strDBConnection = ConfigurationManager.ConnectionStrings["remindme"].ConnectionString;                        
        }
        
        
        protected void Page_Load(Object Sender, EventArgs evt)
        {

            //read configuration settings
            readConfigurationSettings();
            
            //labelErrMessage.Text = strDBConnection;
			if (Request.UrlReferrer != null)
			{
				labelReferrerURL.Text = "Referrer " + Request.UrlReferrer.ToString();
			}
			else
			{
				labelReferrerURL.Text = "Referrer " + "No referrer";
			}	
            
            strRedirectURL = Request["redirectURL"];              
            
            //redirectURL.Value = strRedirectURL;
 
        
            if (IsPostBack == false)
            {
                //get referrer's URL
                //and save in hidden field
				
                //if (Request != null)
                {
				
					if (Request["ReturnUrl"] != null)
					{					
                        strReferrer = Request["ReturnUrl"].ToString();
					}
                    else if (Request.UrlReferrer != null)
                    {
                        strReferrer = Request.UrlReferrer.ToString();
                    }                    
					
					if (strReferrer != null)
					{
						referrerURL.Value = strReferrer;                       
			            redirectURL.Value = strReferrer;
					}	
											
                }                
				
				//labelRedirectURL.Text = "Redirect URL - New request --  " + redirectURL.Value;

                

            }   
            else
            {
                
				//strReferrer = referrerURL.Value;                                   
				
				strReferrer = redirectURL.Value;                                   
            }         
            

        
        }                                        
        
        


        //Called when validate member button is clicked        
        protected void validateMember(Object Sender, EventArgs E)
        {
        
            Boolean bValidate = false;
            Boolean bValidReferer = false;
            
            
            bValidate = funcValidateMember();
            
            
            Dispose();
                            
            if (bValidate)
            {
                
                if (strReferrer == null)
                {
                    bValidReferer = false;                
                }
                
                if (strReferrer != null)
                {

                    if (strReferrer.Length != 0)                    
                    {
                        bValidReferer = false;                
                    }   
                    else                     
                    {
                        bValidReferer = true;                
                    }   
                }                
                
                //labelErrMessage.Text = getUserInfo();0203
                
                //bPersists =  true;
                
                Session["memberID"] = strMemberID;
                
                if (bValidReferer)
                {
                    System.Web.Security.FormsAuthentication.SetAuthCookie(strFullyQualifiedUsername, bPersists);
                    Response.Redirect(@"cover.aspx");
                    Response.Write("Redirect URL is " + strRedirectURL + "<BR>");                
                    
                }
                else
                {
                    Response.Write("Redirect URL is " + strRedirectURL + "<BR>");                
                    System.Web.Security.FormsAuthentication.RedirectFromLoginPage(strFullyQualifiedUsername, bPersists);                      
                } 

                
            }
            else
            {
                labelErrMessage.Text = labelErrMessage.Text + "<BR>" + "Invalid Credentials.  Please try again!";
            }
                            
                
        }
 
 

        
        
        protected Boolean funcValidateMember()
        {
        
            Boolean bValidate = false;
			int iValidate = -1;
            
            strMemberName = txtMemberName.Text;
            strMemberPassword = txtMemberPassword.Text;
            bPersists = chkRememberMe.Checked;            
            
            
            //bValidate = DBValidate();
			iValidate = ADValidate();            
			
			if (iValidate == 0)
			{
				bValidate = true;				
			}
			else
			{
				bValidate = false;				
			}
						
            
            return bValidate;
                
        }   
        
        
        
        protected Boolean DBValidate()
        {
        
            StringBuilder strSQLBuilder = null;
            String strSQL = null;
            int iPasswordMatched = -1;
            Boolean bPasswordMatched = false;

            

            strSQLBuilder = new StringBuilder();
                                        
            strSQLBuilder.Append(" exec " + "" + "security..validatePassword " + " " );                                        
            strSQLBuilder.Append(" ?, ? ");

                                                                
            strSQL = strSQLBuilder.ToString();
 
            OleDbConnection objDBConn = new OleDbConnection(strDBConnection);

            OleDbCommand objDbCommand = new OleDbCommand(strSQL, objDBConn);
                
            objDBConn.Open();
                
            OleDbParameter objDBParameterMemberName = new OleDbParameter();
            objDBParameterMemberName.ParameterName = "memberName";
            objDBParameterMemberName.OleDbType = OleDbType.VarChar;
            objDBParameterMemberName.Size = 255;
            objDBParameterMemberName.Value = strMemberName; 
            objDbCommand.Parameters.Add(objDBParameterMemberName);
            
            OleDbParameter objDBParameterMemberPassword = new OleDbParameter();
            objDBParameterMemberPassword.ParameterName = "memberPassword";
            objDBParameterMemberPassword.OleDbType = OleDbType.VarChar;
            objDBParameterMemberPassword.Size = 255;
            objDBParameterMemberPassword.Value = strMemberPassword; 
            objDbCommand.Parameters.Add(objDBParameterMemberPassword);            
            
            OleDbDataReader objDBReader = objDbCommand.ExecuteReader();
            

            while (objDBReader.Read())
            {
            
                strMemberID = objDBReader.GetString(0);                                

                
            }                            
            
            objDBReader.Close();            
                                        
        
            objDbCommand.Connection.Close();
            
            if (strMemberID != null)
            {
                bPasswordMatched = true;        
            } 
            
        
            return bPasswordMatched;
            
        }   
        
        
        protected int ADValidate()
        {

			string[] partsOfUserName = new string[100];
			int iNumberofParts = 0;
			Boolean bSplitted = false;
			Boolean bPasswordMatched = false;
			
			string domainName = null;
			string userName = null;
			
			char[] splitterAT  = {'@'};
			char[] splitterSlash  = {'\\'};
			
			//partsOfUserName = txtMemberName.Text.Split("\\".ToCharArray());			
			//Try spliting on @
			partsOfUserName = txtMemberName.Text.Split(splitterAT);			
			iNumberofParts = partsOfUserName.Length;
			
		    //labelErrMessage.Text = iNumberofParts.ToString() + "  number of parts";
		    //labelErrMessage.Visible = true;
			
			//return (-2);
			strFullyQualifiedUsername = null;  
			
			if (iNumberofParts == 2)
			{
				//userName = partsOfUserName[0];
				//domainName = partsofUserName[0];	
				
				userName = partsOfUserName[0];
				domainName = partsOfUserName[1];
				
				bSplitted = true;	
			}
			
			if (bSplitted == false)
			{
				partsOfUserName = txtMemberName.Text.Split(splitterSlash);			
				iNumberofParts = partsOfUserName.Length;			

				if (iNumberofParts == 2)
				{
					//domainName = partsofUserName[0];							
					//userName = partsOfUserName[1];
					
					//domainName = partsofUserName[0];							
					//userName = partsofUserName[1];
					
					domainName = partsOfUserName[0];
					userName = partsOfUserName[1];					

				}			
				
			}	
			
			if (bSplitted == false)
			{
				domainName = defaultDomainName;
				userName = partsOfUserName[0];
			}	
			
			strFullyQualifiedUsername = userName + "@" + domainName;			

			MembershipProvider domainProvider = null;
			switch (domainName)
			{
			  case "ephraimtech.com":
					domainProvider = Membership.Providers["MyADMembershipProviderEphraimtech"];
					break;

			  //default:
			  //	  throw(new Exception("This domain is not supported"));
			  default:
				labelErrMessage.Text = "The domain " + domainName + " is not supported.";
				labelErrMessage.Visible = true;		
				break;	
			}
			
			if (domainProvider == null)
			{
				return -100;
			}
			
			// Validate the user with the membership system.
			if(domainProvider.ValidateUser(strFullyQualifiedUsername, txtMemberPassword.Text))
			{
				
				 try
				  {

/*				  	
				    if (!Roles.IsUserInRole(txtMemberName.Text, "JOAdministrators"))
				    {
				    	
   			  		  labelErrMessage.Text = "Member not registered in database";
			  		  labelErrMessage.Visible = true;					
				      return (-300);
				      
				    }

*/				    
				    
				    
				  }
				  catch (HttpException e)
				  {
				    //Msg.Text = "There is no current logged on user. Role membership cannot be verified.";
   			  		labelErrMessage.Text = "There is no current logged on user. Role membership cannot be verified.";
			  		labelErrMessage.Visible = true;									    
				    return (-305);
				  }				
				
				strMemberID = DBGetMemberID(strFullyQualifiedUsername);
				
				if ( (strMemberID == string.Empty) || (strMemberID == null))
				{
			  		labelErrMessage.Text = "Member not registered in database";
			  		labelErrMessage.Visible = true;					
				}
				else
				{
					bPasswordMatched = true;								
				}
				
								
			}
			else
			{
			  labelErrMessage.Text = "Invalid UserID and Password";
			  labelErrMessage.Visible = true;
			}			
			
            if (bPasswordMatched)
			{
				return 0;
			}
			else
			{
				return -1;
			}        
			
            
        } //ADValidate                                            		
        
        
        protected string DBGetMemberID(string strMemberName)
        {
        
            StringBuilder strSQLBuilder = null;
            String strSQL = null;
			string strMemberID = null;

            strSQLBuilder = new StringBuilder();
                                        
            strSQLBuilder.Append(" exec " + "" + "security.dbo.usp_getMemberID " + " " );                                        
            strSQLBuilder.Append(" ? ");

                                                                
            strSQL = strSQLBuilder.ToString();
 
            OleDbConnection objDBConn = new OleDbConnection(strDBConnection);

            OleDbCommand objDbCommand = new OleDbCommand(strSQL, objDBConn);
                
            objDBConn.Open();
                
            OleDbParameter objDBParameterMemberName = new OleDbParameter();
            objDBParameterMemberName.ParameterName = "memberName";
            objDBParameterMemberName.OleDbType = OleDbType.VarChar;
            objDBParameterMemberName.Size = 255;
            objDBParameterMemberName.Value = strMemberName; 
            objDbCommand.Parameters.Add(objDBParameterMemberName);
           
            OleDbDataReader objDBReader = objDbCommand.ExecuteReader();
            

            while (objDBReader.Read())
            {
            
                strMemberID = objDBReader.GetString(0);                                

                
            }                            
            
            objDBReader.Close();            
                                        
        
            objDbCommand.Connection.Close();
            
			return (strMemberID);
			           
        }           
                                                            

    }


}