namespace PeopleSoft.telcoInventory
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
    
    
    public class initCache : System.Web.UI.Page
    {
      
       
       private String strDBConnection = null;
       private String strSQLGetReports = null;
                                        
       private OleDbConnection objConnection = null;
       private OleDbCommand objDBCommand = null;       
       private OleDbDataAdapter objDbAdapter = null;			                                        
       
	   private String strSQLQuery;
	   	   
	   protected Label LabelError;         	   	   	   
	   protected Label LabelInfo;         	   
	   protected Label LabelSQL;         	   	   
	   
	   	   
	   
	   private Boolean bForceCacheRefresh = true;	   
        

       protected void Page_Load(Object Sender, EventArgs evt)
       {
			           
            clearCache();                     
            
       }                                               
        
        
       private void clearCache()
       {

			string strID = "";           
			
            try
            {
							
				PeopleSoft.AppCache.supportTableCache objSupportTableCache;
				int iSectionID = -1;
				PeopleSoft.supportRepository.sectionEnum objSectionIDEnum;
				object objEnum;
				int iNumberofAppObjectsCleared = -1;

				
				objSupportTableCache = new PeopleSoft.AppCache.supportTableCache();
				
				objSupportTableCache.Application = Application;
				iNumberofAppObjectsCleared = objSupportTableCache.clearAllCache();
				
				if (objSupportTableCache.ErrorLog.Length > 0)
				{
					LabelError.Text = "Error log is " + objSupportTableCache.ErrorLog;
					LabelError.Visible = true;					
				}
				else
				{
					LabelError.Text = "log is " + objSupportTableCache.Log +
					                  "number of app objects cleared is " + iNumberofAppObjectsCleared;
					LabelError.Visible = true;					
				}									
				
				objSupportTableCache = null;
	            
	        }
			catch (Exception ex)
			{
				LabelError.Text =    "Exception occured in clearSectionCache().  Exception is " 
								   + ex.Message
								   + "Section ID is " + strID; 			
								   
				LabelError.Visible = true;	
			}	            
	
       
       } //clearSectionCache

    }


}