namespace remindME.stateManagement
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
    using System.Web.SessionState;
    
	[Serializable]
    public class sessionVars
    {

	    protected System.Web.HttpApplicationState objApplication = null;    
        private HttpSessionState objHttpSessionState = null;
       
        private StringBuilder objErrorLog = new StringBuilder();
        private StringBuilder objLog = new StringBuilder();                        
        
        private static String ID_CONTACT_ID = "ContactID";
        private static String ID_CONTACT_NAME = "ContactName";
        
        //save session for 72 hrs.
        private static int lSessionTimeoutInMinutes = 72 *60;
                
        public System.Web.HttpApplicationState Application
        {
            
            get
            {
                return objApplication;
            }
            
            set
            {
                objApplication = value;
            }            
            
        } //public Application
        
                
        public HttpSessionState Session
        {
            
            get
            {
                return (objHttpSessionState);   
            }

            set
            {
                objHttpSessionState = value;
                objHttpSessionState.Timeout = lSessionTimeoutInMinutes;                
            }

        }      
        
        
        
        public String contactID
        {
            
            get
            {
            	if ((Session[ID_CONTACT_ID]) == null)
            	{
            		return null;
				}            		
            	else if ((Session[ID_CONTACT_ID]) is String)
            	{
            		return ((String)Session[ID_CONTACT_ID]);
				}            	
				else
				{					
                	return null;
				}                	
            }
            
            set
            {
            	
                Session[ID_CONTACT_ID] = value;

            }            
            
        } //public String contactID
                      
        
        public String contactName
        {
            
            get
            {
            	if ((Session[ID_CONTACT_NAME]) == null)
            	{
            		return null;
				}            		
            	else if ((Session[ID_CONTACT_NAME]) is String)
            	{
            		return ((Session[ID_CONTACT_NAME]).ToString());
				}            	
				else
				{					
                	return null;
				}                	
            }
            
            set
            {
            	
                Session[ID_CONTACT_NAME] = value;

            }            
            
        } //public String contactName
        
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
        
        
                 
                        
    } //sessionVars
    

    
}
    