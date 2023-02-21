namespace PeopleSoft.ITDBA.reportWriter
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
	using System.Text;	  //StringBuilder	 
	using System.Configuration;	  
	using System.Collections.Specialized;

	using PeopleSoft.ITDBA.reportWriter;
	
	public class reportList
	{
	
		private	String strSQLQuery;		   
		private String strSQLGetReportInfo;
		private String strSQLGetReportParameter;
		
		private	OleDbCommand objDBCommand =	null;
		
		private	StringBuilder objErrorLog =	new	StringBuilder();
		private	StringBuilder objLog = new StringBuilder();						   
	   
		private	static String strID	= "TAG__SUPPORT__REPORT__LIST__";
		
		private	ArrayList objListReports = null;
		
		private	System.Web.HttpApplicationState	objApplication = null; 
		
		protected Boolean bNewCache	= false;
		
		protected int iNumberofCacheEntries	= 0;
		
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
		
		
		public String ID
		{
			
			get
			{
				return strID;
			}
			
			set
			{
				strID =	value;
			}			 
			
		} //public ID
		
				
		public Boolean NewCache
		{
			
			get
			{
				return bNewCache;
			}
			
		} //public NewCache
		
		
		public void	clearCache()
		{
			
			objListReports = null;						

			objLog.Append("Clearing	cache");								
						   
			if (strID.Length !=	0)
			{	
				
				Application[ID]	= objListReports;							
				
				objLog.Append("Cleared cache for ID	" +	ID);								
							
			}				
			else
			{
				objErrorLog.Append("unable to clear	cache for empty	id |" +	ID + "|");												
			}
			

			
		}
		
		public IEnumerator GetEnumerator()
		{
						
			if (Application[ID]	!= null)
			{
				
				if (Application[ID]	is ArrayList)
				{
									   
					objListReports = (ArrayList) Application[ID];	
					
					return (objListReports.GetEnumerator());

				}	

		   }			
		   
		   return (null);
		   
		} 
		
		public ArrayList Cache
		{
			
			get
			{
				
				Boolean	bReadReportList	= false;					
				Boolean	bCachedFilled =	false;

				objLog.Append("Getting Cache...");
									
				if (Application[ID]	!= null)
				{
					
					objListReports = (ArrayList) Application[ID];	
									
					objLog.Append("Number of objects in	existing cache is "	+ objListReports.Count);							

				}

				if (objListReports == null)	
				{
					bReadReportList	= true;					
				}
				else
				{
					
					if (objListReports != null)
					{
						if (objListReports.Count ==	0)
						{
							bReadReportList	= true;					
						}
					}													 
					
				}
				
					
				if (bReadReportList)
				{	
					objLog.Append("Creating	new	Cache Object");					
					
					objListReports = new ArrayList();					 
					
					objLog.Append("filling cache from DB");										
					
					bCachedFilled =	fillCacheFromDB();	
					
					if (bCachedFilled == false)
					{
				
						objListReports = null;
						
						Application[ID]	= null;
					
						bNewCache =	false;
						
					}
					else
					{
						objLog.Append("set application[ID] to cache	from DB	" +	ID);															
					
						Application[ID]	= objListReports;
					
						bNewCache =	true;						 
						
					}						
				}
				else
				{
					objLog.Append("Using existing cache");										
					bNewCache =	false;					
				}
				
				
				return objListReports;
			}

			
		} //public OleDbCommand	DBCommand		
		
		public OleDbCommand	DBCommand
		{
			
			get
			{
				return objDBCommand;
			}
			
			set
			{
				objDBCommand = value;
			}			 
			
		} //public OleDbCommand	DBCommand				
		

		
		
		public String SQLQuery
		{
			
			get
			{
				return (strSQLQuery);
			}
			
			set
			{
				strSQLQuery	= value;
			}			 
			
		} //public String SQLQuery
		

        public String SQLGetReportInfo
        {
            
            get
            {
                return strSQLGetReportInfo;
            }
            
            set
            {
                strSQLGetReportInfo = value;
            }            
        }        		
		

        public String SQLGetReportParameter
        {
            
            get
            {
                return strSQLGetReportParameter;
            }
            
            set
            {
                strSQLGetReportParameter = value;
            }            
        }                
        		
		private String fetchingColumn(int iFetchColumnIndex)
		{
		
			String strColumnName = null;
			
			if ( iFetchColumnIndex == 1)
			{
				strColumnName = "reportName";	
			}	
			else if ( iFetchColumnIndex == 2)
			{
				strColumnName = "reportID";	
			}	
			else if ( iFetchColumnIndex == 3)
			{
				strColumnName = "reportSQL";	
			}	
			else if ( iFetchColumnIndex == 4)
			{
				strColumnName = "SQLType";	
			}	
			else if ( iFetchColumnIndex == 5)
			{
				strColumnName = "dataStoreID";	
			}	
			else if ( iFetchColumnIndex == 6)
			{
				strColumnName = "dataStoreConnectionString";	
			}	
			else if ( iFetchColumnIndex == 7)
			{
				strColumnName = "MSReportServicesURL";	
			}				
			else
			{
				strColumnName = "||Invalid Column Name||";	
			}
															
			return (strColumnName);						
			
		}        		
        		
		private	Boolean	fillCacheFromDB()
		{
		
			OleDbDataReader	objDBReader	= null;

			//String		  strActive	= null;
			//Boolean		  bActive =	false;
			
			String			strReportSQL = null;			
			String			strReportID	= null;			   
			String			strReportName =	null;
			int				iReportID =	-1;
			
			Boolean			bReportParametersRetrieved = false;
			
			String			strReportSQLType = null;				
			int				iReportSQLType = -1;								
			
            String          strReportDataStoreID = null;         
            int             iReportDataStoreID = -1;
	                
	        String          strReportDataStoreConnectionString = null;
	        
	        int				i_fetching_column_iTH = 0;
	        String			strFetchingColumnName = null;
			
			String          strMSReportServicesURL = null;
			
			reportType objReportType = null;
			
			if (objDBCommand ==	null)
			{
				//fill error log
				objErrorLog.Append("Validation failed in reportList.fillCacheFromDB(). " +
								   "DBCommand not specified");
				return(false);	 
			}
		   
			try
			{
				
				objListReports.Clear();
							
				objDBCommand.CommandText = strSQLQuery;
				
				objDBCommand.CommandType = CommandType.Text;			
				
				objDBCommand.Parameters.Clear();
				
				objDBReader	= objDBCommand.ExecuteReader();	
				
				objLog.Append("SQL Query is	" +	strSQLQuery);
				
				iNumberofCacheEntries =	0;
				
				while (objDBReader.Read())
				{
					
					i_fetching_column_iTH = 0;
					objLog.Append("Iterating recordset");
							
					i_fetching_column_iTH ++;									
					strReportName =	objDBReader["reportName"].ToString();
					
					i_fetching_column_iTH ++;														
					strReportID	= objDBReader["reportID"].ToString();				 
					iReportID =	Int16.Parse(strReportID);
					
					i_fetching_column_iTH ++;														
					strReportSQL = objDBReader["reportSQL"].ToString();					
					
					i_fetching_column_iTH ++;														
					strReportSQLType = objDBReader["SQLType"].ToString();				 
					iReportSQLType = Int16.Parse(strReportSQLType);					
					
					i_fetching_column_iTH ++;														
	                strReportDataStoreID = objDBReader["dataStoreID"].ToString();         
	                iReportDataStoreID = Int16.Parse(strReportDataStoreID);	
	                
					i_fetching_column_iTH ++;										                
	                strReportDataStoreConnectionString = objDBReader["dataStoreConnectionString"].ToString();	                	                       					
					i_fetching_column_iTH ++;										                
	                strMSReportServicesURL = objDBReader["MSReportServicesURL"].ToString();	                	                       					
					
					objReportType =	new	reportType();
					
					objListReports.Add(objReportType);
					
					objReportType.reportName = strReportName;
					objReportType.reportID = iReportID;		 
					objReportType.reportSQL	= strReportSQL;							  
					objReportType.SQLGetReportInfo = strSQLGetReportInfo;
					objReportType.SQLGetReportParameter	= strSQLGetReportParameter;
					objReportType.reportSQLType	= iReportSQLType;							  
					objReportType.MSReportServicesURL = strMSReportServicesURL;
					objReportType.reportDataStoreID = iReportDataStoreID;
					objReportType.reportDataStoreConnectionString = strReportDataStoreConnectionString;
					
															
					iNumberofCacheEntries =	iNumberofCacheEntries +	1;
					
					
				}
	
				
				objDBReader.Close();

				bReportParametersRetrieved = fillCacheParameterListFromDB();
				
				if (bReportParametersRetrieved == false)
				{
					//fill error log
					objErrorLog.Append("Unable to retrieve parameter list in reportList.fillCacheFromDB().");
					return(false);						 
				}				

				
			}
			catch (Exception ex)
			{
				
				strFetchingColumnName = fetchingColumn(i_fetching_column_iTH);
				
				//fill error log
				objErrorLog.Append("Exception occured in reportList.fillCacheFromDB(). " +
								   "Exception is " + ex.Message	+ 
								   "SQL	is " + strSQLQuery +
								   "Fetching column " +	i_fetching_column_iTH + ") " + strFetchingColumnName);									
								   
				 return	(false);								   
								   

			}				


			
			if (objDBReader	!= null)
			{			 
				objDBReader	= null;
			}				
			
			return (true);			
	
	   
	   } //fillCacheFromDB
		
		
		private	Boolean	fillCacheParameterListFromDB()
		{
		
			int	iParameterIndex	= 0;
			int	iParameterCount	= 0;
			reportType objReportType = null;
			Boolean	bReportParameterRetrieved =	false;
			
			try
			{
			
				if (objListReports == null)
				{
					//fill error log
					objErrorLog.Append("Exception occured in reportList.fillCacheParameterListFromDB. "	+
									   "objListReports is null");
														   
					return (false);													   
				}
				
				iParameterCount	= objListReports.Count;
				
				for	(iParameterIndex = 0; iParameterIndex <	iParameterCount; iParameterIndex++)
				{
					
					objReportType =	(reportType) objListReports[iParameterIndex];
					
					objReportType.DBCommand	= objDBCommand;					   
					
					//get report parameters
					bReportParameterRetrieved =	objReportType.getReportParameters();
					
					if (bReportParameterRetrieved == false)
					{
						//note error
						objErrorLog.Append("Exception in reportList.fillCacheParameterListFromDB.  " +
										   "Errored	while retrieving parameter list. " + 
										   "Error is " + objReportType.ErrorLog);	
						
						//null out list	reports
						objListReports = null;
						
						return (false);
					}
					
				}					
					
			}
			catch (Exception ex)
			{
				
				//fill error log
				objErrorLog.Append("Exception occured in reportList.fillCacheParameterListFromDB().	" +
								   "Exception is " + ex.Message	+ 
								   "SQL	is " + strSQLQuery);
								   
				 return	(false);								   
								   

			}				

			
			return (true);			
	
	   
	   } //fillCacheParameterListFromDB
		
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
				
	} //reportList
	
	

	
}
	