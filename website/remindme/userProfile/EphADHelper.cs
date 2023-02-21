using System;
using System.DirectoryServices;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Configuration;    
using System.Collections.Specialized;

    
namespace PeopleSoft.Security
{
	/// <summary>
	/// This is an Active Directory helper class.
	/// </summary>
	public class EphADHelper
	{
	    
	    StringBuilder objLog = new StringBuilder();	    
	    StringBuilder objErrorLog = new StringBuilder();
	    
		#region Private Variables
		private static string ADPath = ConfigurationSettings.AppSettings["ADPath"].ToString() ; 
		private static string ADUser = ConfigurationSettings.AppSettings["ADAdminUser"].ToString();
		private static string ADPassword =ConfigurationSettings.AppSettings["ADAdminPassword"].ToString();
        private static string ADServer = ConfigurationSettings.AppSettings["ADServer"].ToString() ; 		

		//private static string ADPath = ConfigurationSettings.AppSettings["ADPath"].ToString() ; 
		//private static string ADUser = "itmssql";
		//private static string ADPassword = "181827717";
        //private static string ADServer = "corp.peoplesoft.com";
        
		#endregion	    

        public String ErrorLog
        {
            
            get
            {
                return (objErrorLog.ToString());
            }

        }                	    

        public String Log
        {
            
            get
            {
                return (objLog.ToString());
            }

        }                	    
		protected DirectoryEntry GetDirectoryObject()
		{
			DirectoryEntry oDE;
			
			oDE = new DirectoryEntry(ADPath,ADUser,ADPassword,AuthenticationTypes.Secure);

			return oDE;
		}

		
		private String stripExtraData(String strCn)
		{
		 
		    String strPlain = null;
		    int    iIndexEqual = -1;
		    int    iIndexComma = -1;
		    		    
		    iIndexEqual = strCn.IndexOf("=", 1);
		    
		    iIndexComma = strCn.IndexOf(",", 1);
		    
		    if ((iIndexEqual != -1) && (iIndexComma > iIndexEqual))
		    {
                strPlain = strCn.Substring(iIndexEqual + 1, iIndexComma - iIndexEqual - 1);
		    }
		    
		    return strPlain;
		    
		}
		public Object GetGroupsUserBelongsTo(  string strUsername
		                                     , int iRenderType)
		{
		    
   			DirectoryEntry objDirectorySearchBase = null;
   			DirectorySearcher objDirectorySearcher = null;
   			String strSearchString = null;
   			SearchResult objDirectorySearchResult = null;
   			DirectoryEntry objDirectoryEntryUser = null;
            System.DirectoryServices.ResultPropertyValueCollection objDirectoryEntryMemberOf = null;            

		    StringCollection objGroups = new StringCollection();
		    StringCollection objGroupsPlain = new StringCollection();		    
   			DataSet dsUser = new DataSet();
   			
   			string strCn = null;
   			int    iNumberofGroups = -1;
    					    
		    String strGroupName = null;
		    String strGroupNamePlain = null;

    					       			
		    try
		    {
		        
                
                objErrorLog.Length = 0;		            
                
		        //objLog.Append("ADPath is " + ADPath + " " +
		        //              "ADUser is " + ADUser + " " +
		        //              "ADPassword is " + ADPassword + " " +
		        //              "ADServer is " + ADServer);
		                          			
    			//Create a new table object within the dataset
    			DataTable tblGroup = dsUser.Tables.Add("userGroup");
    			tblGroup.Columns.Add("groupName");

    			objLog.Append("Get directory object");       			
    			objDirectorySearchBase = GetDirectoryObject();

    			
    			strSearchString = "(sAMAccountName=" + strUsername + ")";

    			objLog.Append("instanciate directory search ");    			
    			objDirectorySearcher = new DirectorySearcher(objDirectorySearchBase, 
    			                                             strSearchString);
    			                                             
    			objLog.Append("Add property to load (cn) ");    			    			                                             
                objDirectorySearcher.PropertiesToLoad.Add("cn");    			                                             
                objDirectorySearcher.PropertiesToLoad.Add("memberOf");    			                                                             

    			objLog.Append("directory find one ");    			
                objDirectorySearchResult = objDirectorySearcher.FindOne();
                
                if (objDirectorySearchResult == null)
                {
                    objErrorLog.Append("User " + strUsername + " not found!");   
                }
                else
                {
                    
    			    objLog.Append("find path to directory entry");    			                    
                    objDirectoryEntryUser = new DirectoryEntry(objDirectorySearchResult.Path);
                    
                    if (objDirectoryEntryUser == null)
                    {

                        objErrorLog.Append("Unable to position AD to path for user " + strUsername +
                                          "Path is suppose to be " + objDirectorySearchResult.Path);
                                          
                        
                    }
                    else
                    {
                        
                        strCn = (String) objDirectorySearchResult.Properties["cn"][0];
    			        objLog.Append("cn is " + strCn);    	                        
    			        
    			        if (objDirectorySearchResult.Properties["memberOf"] == null)
    			        {
    			            
                            objErrorLog.Append("Unable to get member of property " + strUsername 
                                               + "Make sure it was included in propertyToLoad list for AD Object " 
                                               + objDirectorySearchResult.Path);
                                               
                                                                           
    			            
    			        }
                        else
                        {
    			        
        			        objDirectoryEntryMemberOf = objDirectorySearchResult.Properties["memberOf"];
        			        
                            iNumberofGroups = (int) objDirectoryEntryMemberOf.Count;
        			        objLog.Append("iNumberofGroups is " + iNumberofGroups);    	                            			        
    
                			for (int iGroupIndex = 0; iGroupIndex < iNumberofGroups; iGroupIndex++)
                			{
                			    
                			    strGroupName = (String) objDirectoryEntryMemberOf[iGroupIndex];
                			    
                				objGroups.Add(strGroupName);
                				
                				strGroupNamePlain = stripExtraData(strGroupName);
                				
                				objGroupsPlain.Add(strGroupNamePlain);
                				
        						//set a new empty row
        						DataRow objDataRow = tblGroup.NewRow();
        						
        						//populate the column
        						objDataRow["groupName"]= strGroupName;
        						
        						tblGroup.Rows.Add(objDataRow);
        						
                			}
                        }
            			
			            objLog.Append("iterated directory entry groups");    			                                                                			
                            
                       
                    }

                }

            }
            catch (Exception ex)
            {
		        objErrorLog.Append(ex.Message);    
            }
            
            if (iRenderType == 1)
            {
	            return dsUser;            
            }	            
            else if (iRenderType == 2)
            {
	            return objGroups;            
            }	                        
            else
            {
	            return objGroupsPlain;            
            }	            

                        	        
        } //GetGroupsUserBelongsTo               
		    
		    

	    
	} // class
	
}	