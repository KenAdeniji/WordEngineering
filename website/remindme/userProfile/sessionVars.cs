namespace PeopleSoft.Security
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
    using System.Collections.Specialized;
    using PeopleSoft.Security;
    using System.Web.SessionState;
    
    public class sessionVars
    {
    
        private HttpSessionState objHttpSessionState = null;
        private OleDbCommand objDBCommand = null;
        private String strUsername = null;
        
        private StringBuilder objErrorLog = new StringBuilder();
        private StringBuilder objLog = new StringBuilder();                        
       
        private static String ID_APP_SECURITY_ROLE = "ID_APP_SECURITY_ROLE";
        
        private userSecurityRole objUserSecurityRole = new userSecurityRole();        
        
        public HttpSessionState Session
        {
            
            get
            {
                return (objHttpSessionState);   
            }

            set
            {
                objHttpSessionState = value;
            }

        }      
        
        public OleDbCommand DBCommand
        {
            
            get
            {
                return objDBCommand;
            }
            
            set
            {
                objDBCommand = value;
            }            
            
        } //public OleDbCommand DBCommand       
        
        
        public String username
        {
            
            get
            {
                return strUsername;
            }
            
            set
            {
                strUsername = value;                
            }            
            
        } //public String strUsername
                      
        
        public appSecurityRole appSecurityRole
        {
            
            get
            {

                appSecurityRole objAppSecurityRole = appSecurityRole.empty;               
                            
                if (Session[ID_APP_SECURITY_ROLE] == null)                
                {
                    //get App Security Role
                    objAppSecurityRole = getAppSecurityRole();
                    
                    //set session Vars
                    Session[ID_APP_SECURITY_ROLE] = objAppSecurityRole;
                }                    
                
                if (Session[ID_APP_SECURITY_ROLE] == null)
                {
                    return appSecurityRole.empty;   
                }
                
                if (Session[ID_APP_SECURITY_ROLE] is appSecurityRole)
                {
                    return ((appSecurityRole) Session[ID_APP_SECURITY_ROLE]);
                }                    
                else
                {
                    return (appSecurityRole.empty); 
                }                                    
            }
            
            


        }   
        
        
        
        protected appSecurityRole getAppSecurityRole()
        {
            
            appSecurityRole objAppSecurityRole = appSecurityRole.empty;            
            
            try
            {
                objErrorLog.Length = 0;
            
                objUserSecurityRole.username = strUsername;
            
                objUserSecurityRole.DBCommand = objDBCommand;
            
                objAppSecurityRole = objUserSecurityRole.role;
                
            }
            catch (Exception ex)
            {
                objErrorLog.Append(ex.Message);
            }   
            
            return (objAppSecurityRole);
                         
        }    
        
        public String ErrorLog
        {
            
            get
            {
                return objErrorLog.ToString();
            }
            
            
        } //public String ErrorLog
                
                
        public String Log
        {
            
            get
            {
                return objLog.ToString();
            }
            
            
        } //public String Log                                	           
        
        
        public Boolean isAppSecurityRoleMaintainSupportTable
        {
            
            get        
            {
                appSecurityRole objAppSecurityRole;
                
                objAppSecurityRole = appSecurityRole;
                                
                return  
                    ((objAppSecurityRole & appSecurityRole.maintainSupportTable) == appSecurityRole.maintainSupportTable);
                
            }
            
        }            

                
    } //sessionVars
    

    
}
    