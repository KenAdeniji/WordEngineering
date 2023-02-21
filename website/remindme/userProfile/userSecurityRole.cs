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
    
    public class userSecurityRole
    {
    
        protected OleDbCommand objDBCommand = null;       
        protected String strADUsername = null;
        protected String strUsername = null;
        protected appSecurityRole objRole;
        protected StringBuilder objLog = new StringBuilder();        
        protected StringBuilder objErrorLog = new StringBuilder();
        protected StringCollection objUserADGroups = null;
        protected Boolean bAppSecurityRoleRendered = false;
       
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
                strADUsername = stripDomainPrefix(value);
            }            
            
        } //public String strUsername
        
        
        public String ADUsername
        {
            
            get
            {
                return strADUsername;
            }
            
            
        } //public String strUsername        
        
        
            
		private String stripDomainPrefix(String strDomainUsername)
		{
		 
		    String strUsername = null;
		    int    iIndexBackSlash = -1;
		    
		    if ((strDomainUsername == null) || (strDomainUsername == String.Empty))
		    {
		        return strDomainUsername;   
		    }
		    		    
		    iIndexBackSlash = strDomainUsername.IndexOf("\\", 1);
		    
		    if (iIndexBackSlash != -1)
		    {
                strUsername = strDomainUsername.Substring(iIndexBackSlash + 1);
		    }
		    else
		    {
                strUsername = strDomainUsername;
		    }		    
		    
		    return strUsername;
		    
            
        } //public String strUsername
                
        public appSecurityRole role
        {
            
            get
            {
                getAppSecurityRole();
                
                return objRole;
            }
            

            
        } //public String strUsername        
        
        protected void getAppSecurityRole()
        {
       
            if (bAppSecurityRoleRendered)
            {
                return;   
            }
            
            try
            {   

                int iNumberofADGroups = -1;
                int iADGroupIndex = -1;
                EphADHelper objEphADHelper;
                StringBuilder strSQLPopulateUserADGroup = new StringBuilder();
                String strADGroupName = null;
                String strSQL = null;
                OleDbDataReader objDBReader = null;                
                
                String strValue = null;
				int	iRoleID = -1;	                           
				String	strRoleName = null;	                           						
				int	iRoleValue = -1;
				
				Object objUserADGroupV = null;
                                
                objErrorLog.Length = 0; 
                                
                if ((strUsername == null) || (strUsername == String.Empty))
                {
                    objErrorLog.Append("username has not been set in userSecurityRole");                       
                    return;   
                }

             
                objEphADHelper = new EphADHelper();
                
                objLog.Append("preparing to get user groups for user " + strADUsername);   

                //get list of AD Groups
                objUserADGroupV = objEphADHelper.GetGroupsUserBelongsTo(strADUsername, 3);                                
             
                strSQLPopulateUserADGroup.Append("exec dbo.pssp_UserADGroupsDelete '" + strUsername + "' ");
                
                if (objUserADGroupV != null)
                {                
                    
                    objLog.Append("attempting to typecast user group to StringCollection for user " + strUsername);                   
                                    
                    objUserADGroups = (StringCollection) objUserADGroupV;
                    
                    objLog.Append("typecasted user group to StringCollection for user " + strUsername);                                       
                    
                    objLog.Append("preparing to iterate through user groups for user " + strUsername);                                       
                 
                    iNumberofADGroups = objUserADGroups.Count;                    
                    
                    for (iADGroupIndex = 0; iADGroupIndex < iNumberofADGroups; iADGroupIndex++)
                    {
                        strADGroupName = objUserADGroups[iADGroupIndex];
                        
                        strSQLPopulateUserADGroup.Append("exec dbo.pssp_UserADGroupsAdd " 
                                                           +    "'" + strUsername + "'" 
                                                           + ", '" + strADGroupName + "'"                                                      
                                                         );
                        
                    }                                 
                }
                
                                    
                strSQLPopulateUserADGroup.Append("exec dbo.pssp_getUserRoles '" + strUsername + "' ");                

                strSQL = strSQLPopulateUserADGroup.ToString();
                
                objDBCommand.CommandType = CommandType.Text;  
                objDBCommand.CommandText = strSQL;
                                          
	            objDBReader = objDBCommand.ExecuteReader();	
	            
	            while (objDBReader.Read())
	            {	 
                    	                
					strValue = objDBReader["roleID"].ToString();	                           
					iRoleID = Int16.Parse(strValue);	
					
					strRoleName = objDBReader["roleName"].ToString();	                           						
					
					strValue = objDBReader["roleValue"].ToString();	                           												
					iRoleValue = Int16.Parse(strValue);						
					
					prepRole(iRoleID, strRoleName, iRoleValue);

                }                
                                          
	            objDBReader.Close();
	            
                objEphADHelper = null;
                
                bAppSecurityRoleRendered = true;
                
                objLog.Append("finished retrieving user groups for user " + strADUsername);                   
                
            }
            catch (Exception ex)
            {
                objErrorLog.Append(ex.Message);   
            }                
            
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

        public StringCollection userADGroups
        {
            
            get
            {
                return (objUserADGroups);
            }
            
        } //public  StringCollection userADGroups
        
        public String userADGroupsAsString
        {
            
            get
            {
                int iIndex = -1;
                int iCount = -1;
                String strGroupName = null;
                String strADGroupName = "";
                
                iCount = objUserADGroups.Count;
                
                for (iIndex = 0; iIndex < iCount; iIndex++)
                {
                    strGroupName = objUserADGroups[iIndex];
                    
                    if (strADGroupName != String.Empty)
                    {
                        strADGroupName = strADGroupName + ", ";
                    }
                    
                    strADGroupName = strADGroupName + strGroupName;                    
                }
                
                return (strADGroupName);
                
            }
            
        } //public  StringCollection userADGroups
        
        
        protected void prepRole(int iRoleID,
                                String strRoleName,
                                int iRoleValue)
        {
            
            try
            {
                appSecurityRole iAppSecurityRoleValue;
                
                iAppSecurityRoleValue = (appSecurityRole) iRoleValue;
                
                if ( (objRole & iAppSecurityRoleValue) == iAppSecurityRoleValue)
                {
                    
                }
                else
                {
                    objRole ^= iAppSecurityRoleValue;   
                }            
                
                objLog.Append("security role: " 
                                   + "roleID is " + iRoleID + " "
                                   + "roleName is " + strRoleName + " "                                   
                                   + "roleValue is " + iRoleValue + " "                                                                      
                                   );                                                   
            }
            catch (Exception ex)
            {
                objErrorLog.Append("Unable to process security role: " 
                                   + "roleID is " + iRoleID + " "
                                   + "roleName is " + strRoleName + " "                                   
                                   + "roleValue is " + iRoleValue + " "                                                                      
                                   );                                   
                objErrorLog.Append("Exception is " + ex.Message);                   
            }
        }
                
    } //userSecurityRole
    

    
}
    