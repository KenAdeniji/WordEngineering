namespace PeopleSoft.AppCache
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

    
    public class supportTableCache
    {
    
        private String strID;
        private String strSQLQuery;        
        private OleDbCommand objDBCommand = null;
        
        private StringBuilder objErrorLog = new StringBuilder();
        private StringBuilder objLog = new StringBuilder();                        
       
        private static String ID_APP = "TAG__SUPPORT__TABLE__APP__CACHE__";
        
        private ArrayList objCache = null;
        
        private System.Web.HttpApplicationState objApplication = null; 
        
        private int iNumberofCacheEntries = -1;
        
        protected supportTableCacheObject objSupportTableCacheObject = null;
        
        protected Boolean bNewCache = false;
        
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
        
        
        public String idApp
        {
            
            get
            {
                return ID_APP;
            }
            
            set
            {
                ID_APP = idApp;
            }            
            
        } //public idApp
        
                
        public Boolean NewCache
        {
            
            get
            {
                return bNewCache;
            }
            
        } //public NewCache
        
        public int clearAllCache()
        {
            
            int iIndex = -1;
            int iNumberofAppCaches = -1;
            int iNumberofAppCachesCleared = 0;
            String strBaseAppKey = ID_APP;
            String strIDLocal = null;
            
            iNumberofAppCaches = Application.Count;
            
            for (iIndex = 0; iIndex < iNumberofAppCaches; iIndex++)
            {
                //get app key
                strIDLocal = Application.GetKey(iIndex);   
                
                if (strIDLocal.IndexOf(strBaseAppKey) > -1)
                {
                    
                    Application[strIDLocal] = null;   
                    
                    iNumberofAppCachesCleared = iNumberofAppCachesCleared + 1;
                    
            	    objLog.Append("Cleared cache for |" + strIDLocal + "|" + "<BR>");            		            
            	                    
                }
                else
                {
            	    objLog.Append("skipping cache clear for object with key |" + strIDLocal + "|" + "<BR>");            		            				                    
                }
                
            }
            
            return (iNumberofAppCachesCleared);

            
        }        
        
        public void clearCache()
        {
            
            objSupportTableCacheObject = null;			        	

            objLog.Append("Clearing cache for id |" + ID + "|");            		            
                           
            if (strID.Length != 0)
            {   
            	
            	Application[ID] = objSupportTableCacheObject;                        	
            	
            	objLog.Append("Cleared cache for id |" + ID + "|");            		            
                        	
			}            	
			else
			{
            	objErrorLog.Append("unable to clear cache for empty id |" + ID + "|");            		            				
			}
            

            
        }
        
        public IEnumerator GetEnumerator()
        {
			        	
            if (Application[ID] != null)
            {
                
            	if (Application[ID] is supportTableCacheObject)
            	{
                    		           
		            objSupportTableCacheObject = (supportTableCacheObject) Application[ID]; 	
		            
		            objCache = objSupportTableCacheObject.cache;
           			
           			return (objCache.GetEnumerator());

            	}	

           }        	
           
           return (null);
           
        } 
        
        public ArrayList Cache
        {
            
            get
            {

            	objLog.Append("Getting Cache");
   	            	            	
            	if (Application[ID] != null)
            	{
            	    
		            objSupportTableCacheObject = (supportTableCacheObject) Application[ID]; 	
		            
		            objCache = objSupportTableCacheObject.cache;
		                        	    
	            	objLog.Append("Number of objects in existing cache is " + objCache.Count);            				

            	}

            	if (objCache == null)
            	{
            		
		            objLog.Append("Creating new Cache Object");            		
		            
                    objSupportTableCacheObject = new supportTableCacheObject();
                    
            		objCache = new ArrayList();                    
            		
            		objSupportTableCacheObject.cache = objCache;

            		objSupportTableCacheObject.SQLQuery = SQLQuery;            		
            		
            		objSupportTableCacheObject.ID = ID;            		            		
            		
		            objLog.Append("filling cache from DB");            		            		
            		
            		fillCacheFromDB();	
            		
		            objLog.Append("set application[ID] to cache from DB " + ID);            		            		            		
            		
            		Application[ID] = objSupportTableCacheObject;
            		
            		bNewCache = true;
            	}
            	else
            	{
            		bNewCache = false;            	    
            	}
            	
            	
                return objCache;
            }

            
        } //public OleDbCommand DBCommand       
        
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
        
        public String ID
        {
            
            get
            {
                return (ID_APP + strID);
            }
            
            set
            {
                strID = value;
            }            
            
        } //public String strID
        
        
        public String SQLQuery
        {
            
            get
            {
                return (strSQLQuery);
            }
            
            set
            {
                strSQLQuery = value;
            }            
            
        } //public String SQLQuery
        
        
        private void fillCacheFromDB()
        {
        
            OleDbDataReader objDBReader = null;
            String          strID = null;
            String          strLiteral = null;            
            supportTableObject objSupportTableObject = null;
           
            try
            {
				
				objCache.Clear();
							
	            objDBCommand.CommandText = strSQLQuery;
	            
	            objDBCommand.CommandType = CommandType.Text;            
	            
	            objDBCommand.Parameters.Clear();
				
	            objDBReader = objDBCommand.ExecuteReader();	
            	
            	objLog.Append("SQL Query is " + strSQLQuery);
            	
	            iNumberofCacheEntries = 0;
	            
	            while (objDBReader.Read())
	            {
	            	
   	            	objLog.Append("Iterating recordset");
	            	            	
	                strID = objDBReader[0].ToString();
	                strLiteral = objDBReader[1].ToString();
	                
	                objSupportTableObject = new supportTableObject();
	                	                
					objSupportTableObject.value = strID;
					objSupportTableObject.text = strLiteral;					
						                	                
	                objCache.Add( objSupportTableObject);
	                
	                iNumberofCacheEntries = iNumberofCacheEntries + 1;
	                
	                
	            }
	
	            
	            objDBReader.Close();



	            
	        }
			catch (Exception ex)
			{
				//fill error log
				objErrorLog.Append("Exception occured in supportTableCache.fillCacheFromDB(). " +
				                   "Exception is " + ex.Message + 
				                   "SQL is " + strSQLQuery);
				                   

			}	            


			
			if (objDBReader != null)
			{            
            	objDBReader = null;
			}            	
	
       
       } //fillCacheFromDB
       
       public int fill(ListItemCollection objListItemCollection)
       {
            return (fill(objListItemCollection, 0));
       }
            
            
       public int fill(   ListItemCollection objListItemCollection
                        , int iIncludeBlank)
       {
       	
       		int iIndex = -1;
       		supportTableObject objSupportTableObject;
       		
       		//get cache
       		objCache = Cache;
       		
       		//count of number of entries in Cache
       		iNumberofCacheEntries = objCache.Count;
       		
       		//fill List Collection
       		objListItemCollection.Clear();
       		
       		objLog.Append("In fill function::Number of cache entries is " + iNumberofCacheEntries);
       		
       		//if instructed to add blanks, then do so
       		if (iIncludeBlank == 1)
       		{
       			objListItemCollection.Add(new ListItem("", ""));
       		}
       		
       		for (iIndex = 0; iIndex < iNumberofCacheEntries; iIndex ++)
       		{
       			
       			objSupportTableObject = (supportTableObject) objCache[iIndex];
       			
       			objListItemCollection.Add(new ListItem(   objSupportTableObject.text
       			                                        , objSupportTableObject.value));                
       					
       			
       		}
       		
       		return (iNumberofCacheEntries);
       		
       	
       }
        
	    
        public string ErrorLog
        {
            
            get
            {
                return objErrorLog.ToString();
            }
            
        } //public String ErrorLog

        public string Log
        {
            
            get
            {
                return objLog.ToString();
            }
            
        } //public String Log
                
    } //supportTableCache
    
    

    
}
    