namespace PeopleSoft.AppCache
{
	
    using System;
    using System.Collections;
    using System.ComponentModel;

    
    public class supportTableCacheObject
    {
    
        private String strID;
        private String strSQLQuery;        
        private ArrayList objCache = null;
        
        public String ID
        {
            
            get
            {
                return (strID);
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
        
        public ArrayList cache 
        {
            
            get
            {
                return (objCache);
            }
            
            set
            {
                objCache = value;
            }            
            
        } //public ArrayList cache 
        
	    

                
    } //supportTableCacheObject
    
    

    
}
    