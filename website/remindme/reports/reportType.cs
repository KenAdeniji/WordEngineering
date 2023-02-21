namespace reportWriter
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

    
	[Serializable]
    public class reportType 
    {
		[NonSerializedAttribute]
        private OleDbCommand objDBCommand = null;       
           
        private int    iReportID;
        private String strReportName;
        private String strReportSQL;
        private String strMSReportServicesURL;		
        private int    iReportSQLType;        
        private ArrayList objParameterList;
        private StringBuilder objLog = null;
        private StringBuilder objErrorLog = null;
        
        private string strSQLGetReports = null;
        private string strSQLGetReportInfo = null;        
        private string strSQLGetReportParameter = null;
        
        private int iReportDataStoreID;
        private string strReportDataStoreConnectionString;        
        
        public reportType()
        {
		
            this.iReportID = -1;
            this.iReportSQLType = -1;
            this.strReportName = null;
			this.strMSReportServicesURL = null;			
            this.strReportSQL = null;                      
            this.strSQLGetReports = null;
            objParameterList = new ArrayList();
            objLog = new StringBuilder();
            objErrorLog = new StringBuilder();            
            
            this.iReportDataStoreID = -1;
            this.strReportDataStoreConnectionString = null;
            
        }        
        
        
        public reportType(reportType objReportTypeShell)
        {
            

            
            try
            {

                            
                this.reportID = objReportTypeShell.reportID;
                this.reportSQLType = objReportTypeShell.reportSQLType;
                this.reportName = objReportTypeShell.reportName;
                this.reportSQL = objReportTypeShell.reportSQL;                      
				this.MSReportServicesURL = objReportTypeShell.MSReportServicesURL;                      
                this.SQLGetReports = objReportTypeShell.SQLGetReports;
                this.reportDataStoreID = objReportTypeShell.reportDataStoreID;
                this.reportDataStoreConnectionString = objReportTypeShell.reportDataStoreConnectionString;                
                this.DBCommand = objReportTypeShell.DBCommand;
                
                objLog = new StringBuilder();
                objErrorLog = new StringBuilder();            
                
                cloneReportParameterList(objReportTypeShell);
                
            }
            catch (Exception ex)
            {
				objErrorLog.Append("Exception in reportType(reportType objReportTypeShell) " + ex.Message);				                
            }                
                        
        }    
        
        
        protected Boolean cloneReportParameterList(reportType objReportTypeShell)
        {

            int iParameterIndex = -1;
            int iParameterCount = -1;
            ArrayList objParameterListShell = null;            
            reportParameter objReportParameter = null;                               
            reportParameter objReportParameterShell = null;                                                       
            
            if (objReportTypeShell == null)
            {
                
				objLog.Append("Warning generated in cloneReportParameterList(reportType objReportTypeShell) ");				                                
				objLog.Append("Unable to clone an empty shell");				                                				
				
                this.objParameterList = new ArrayList();
                objParameterListShell = null;
                
                return (true);                
				                
            }
            else
            {
                
				objLog.Append(" cloneReportParameterList -- shell [objReportTypeShell] is not empty ");				                                
				
                objParameterListShell = objReportTypeShell.parameterList;
				
				                
            }            
            
            
            try
            {
            
                this.objParameterList = new ArrayList();
                
				objLog.Append(" cloneReportParameterList -- created array list ");				                                                
                                
                
                if (objParameterList != null)
                {
                    
                    iParameterCount = objParameterListShell.Count; 
                    
				    objLog.Append(" cloneReportParameterList -- parameter count of shell is " + iParameterCount);				                                                                    
                
                    for (iParameterIndex = 0; iParameterIndex < iParameterCount; iParameterIndex++)
                    {
                        
                        objReportParameterShell = (reportParameter) objParameterListShell[iParameterIndex];  
                        
                        if (objReportParameterShell == null)
                        {       
                                      
				            objLog.Append("Creating objReportParameter for empty shell... ");				                                
                                objReportParameter = new reportParameter();                        
				            objLog.Append("Created objReportParameter for empty shell <BR> ");				                                                            
				            
                        }                            
                        else
                        {                 
				            objLog.Append("Creating objReportParameter for filled shell... ");				                                                            
                                objReportParameter = new reportParameter(objReportParameterShell);        
				            objLog.Append("Creating objReportParameter for filled shell... ");				                                                                
                        }                                            
                                
                        this.objParameterList.Add(objReportParameter);
                        
                                                                 
                    } //for
                    
                }  //if (objParameterList != null)              
                else
                {
		            objLog.Append("In cloneReportParameterList::parameter list is empty");
                }
                
                return (true);                
                
            } //try
            catch (Exception ex)
            {
				objErrorLog.Append("Exception in cloneReportParameterList(reportType objReportTypeShell 1.78) " 
				                   + ex.Message
				                   + ":log contents is " +  objLog.ToString());				                
				                   
                return (false);                				                   
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
        }       
        
        public String reportName
        {
            
            get
            {
                return strReportName;
            }
            
            set
            {
                strReportName = value;
            }            
        }
    

        public int reportID
        {
            
            get
            {
                return iReportID;
            }
            
            set
            {
                iReportID = value;
            }            
        }
        
        public String reportSQL
        {
            
            get
            {
                return strReportSQL;
            }
            
            set
            {
                strReportSQL = value;
            }            
        }        
		
		public String MSReportServicesURL
        {
            
            get
            {
                return strMSReportServicesURL;
            }
            
            set
            {
                strMSReportServicesURL = value;
            }            
        }        		
        
                
        public String SQLGetReports
        {
            
            get
            {
                return strSQLGetReports;
            }
            
            set
            {
                strSQLGetReports = value;
            }            
        }        
    
    
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
            
        public int reportSQLType
        {
            
            get
            {
                return iReportSQLType;
            }
            
            set
            {
                iReportSQLType = value;
            }            
        }
        
        public int reportDataStoreID    
        {
            get
            {
                return iReportDataStoreID;
            }
            
            set
            {
                iReportDataStoreID = value;
            }                        
            
        }
        
        public String reportDataStoreConnectionString
        {
            get
            {
                return strReportDataStoreConnectionString;
            }
            
            set
            {
                strReportDataStoreConnectionString = value;
            }                        
            
        }        
    
        public ArrayList parameterList
        {
            
            get
            {
                return objParameterList;
            }
            

        }    
        
        
        public int NumberofParameters
        {
            
            get
            {
                return objParameterList.Count;
            }
            

        }    
                
        public String Log
        {
            
            get
            {
                return (objLog.ToString());
            }
            

        }        
        
        
        public String ErrorLog
        {
            
            get
            {
                return (objErrorLog.ToString());
            }
            

        }        
                
       public Boolean queryReportInfo(int iInputReportID)
       {
       
       
            OleDbDataReader objDBReader = null;

			String          strDBReportID = null;
            String          strDBReportSQLType = null;
            String          strReportDataStoreID = null;
            
			String          strSQLQuery = null;
            Boolean         bOK = true;
           
            try
            {
								
				strSQLQuery = strSQLGetReportInfo;
							
	            objDBCommand.CommandText = strSQLQuery;
	            
	            objDBCommand.CommandType = CommandType.Text;            
	            
	            objDBCommand.Parameters.Clear();
				
	            OleDbParameter objDBParameterReportID = new OleDbParameter();
	            objDBParameterReportID.OleDbType = OleDbType.Integer;
	            objDBParameterReportID.Value = iInputReportID; 
	            objDBCommand.Parameters.Add(objDBParameterReportID);		            	            
	            	            
	            objDBReader = objDBCommand.ExecuteReader();		            
	            
	            while (objDBReader.Read())
	            {
	
					strMSReportServicesURL = objDBReader["MSReportServicesURL"].ToString();

					strDBReportID = objDBReader["reportID"].ToString();                
	                reportID = Int16.Parse(strDBReportID);
	                	
	                reportName = objDBReader["reportName"].ToString();
	                reportSQL = objDBReader["reportSQL"].ToString();	                
	                
                	strDBReportSQLType = objDBReader["SQLType"].ToString();                
	                reportSQLType = Int16.Parse(strDBReportSQLType);	                
	                
	                strReportDataStoreID = objDBReader["dataStoreID"].ToString();         
	                iReportDataStoreID = Int16.Parse(strReportDataStoreID);	
	                
	                strReportDataStoreConnectionString = objDBReader["dataStoreConnectionString"].ToString();	                	                       
					//if (objDBReader[MSReportServicesURL].GetValue() == DBValue.Null)


	                
	                
	            }
	
	            
	            objDBReader.Close();
				            
	            getReportParameters();

	            
	        }
			catch (Exception ex)
			{
				bOK = false;
				
				objErrorLog.Append("<BR>" + "Exception in queryReportInfo() " + 
				                   "report id is " + iInputReportID 
				                   +"Exception is " + ex.Message);				
				                   
				objErrorLog.Append("Attempted SQL is " + strSQLQuery);
				
			}	            


			
			if (objDBReader != null)
			{            
            	objDBReader = null;
			}   
			
			return (bOK);         	
	
       
       }                                                
                   
        
        public void addParameter(reportParameter objReportParameter)
        {
			objParameterList.Add(objReportParameter);        	
        }

        
       public Boolean getReportParameters()
       {
       
       
            OleDbDataReader objDBReader = null;
            String          strSQLQuery = null;
            //Object          objPlain = null;
            reportParameter objReportParm = null;
            Boolean         bOK = true;
            OleDbParameter  objDBParameter = null;
            
            string          strParameterNameLiteral = null;
            //string          strParameterIsSystem = null;
            //int				iParameterIsSystem = -1;
            Boolean			bParameterIsSystem = false;
				           
            try
            {

				//truncate log StringBuilder instance            	
				//objLog.Length = 0;	
				
				//clear Parameter List
				objParameterList.Clear();
				
				//if not SP, then no need to fill in 
				if (reportSQLType == 1)
				{
							
					//If SQLGetReportParameter is undefined							
					if (strSQLGetReportParameter == null)
					{
						
						bOK = false;
						
						objErrorLog.Append("Exception in source file reportType.cs " +
				        		           "Method -- reportType.getReportParameters() -- " +  
				                		   "Parameter SQLGetReportParameter is undefined");
				                		   
						return (bOK);				                		   
							
					}							
							
					//get Report SQL								
					strSQLQuery = strSQLGetReportParameter;
								
					//Build SQL Command Text								
		            //objDBCommand.CommandText = "dbo.usp_GetReportParameters";
		            //objDBCommand.CommandText = "dbo.usp_GetReportParameters ?";
		            		            
		            objDBCommand.CommandText = strSQLQuery;
		            
		            //set Command Type to Text
		            objDBCommand.CommandType = CommandType.Text;            
		            
		            objDBCommand.Parameters.Clear();
		            
		            
		            //pass the name of the SP has the parameter to get report parameters
		            objDBParameter = new OleDbParameter();
		            objDBParameter.OleDbType = OleDbType.VarChar;
		            objDBParameter.Value = reportSQL;
		            objDBCommand.Parameters.Add(objDBParameter);					            		            
		            
					objLog.Append("reportType::getReportParameters() " +
					              "Preparing to get parameter list "  +
				                  "SQL Query is " + strSQLQuery + "  " + 
				                  "SQL Parameter 1 [Name of SP] is " + reportSQL);
				                  
		            
					
		            objDBReader = objDBCommand.ExecuteReader();	
		            
		            
		            while (objDBReader.Read())
		            {

						//instanciate parameter
            			objReportParm = new reportParameter();
            			
            			//add parameter
            			addParameter(objReportParm);            			
            			
            			//stamp Parameter Name
            			objReportParm.parameterName = objDBReader["columnName"].ToString();

            			//stamp Parameter Type
            			objReportParm.parameterDataTypeAsString = objDBReader["dataType"].ToString();            			
            			            			
            			//stamp Parameter Name Literal
            			strParameterNameLiteral = objDBReader["parameterNameLiteral"].ToString();
						//stamp Parameter Name Literal
            			objReportParm.parameterNameLiteral = strParameterNameLiteral;
						     	    			            			            			
            			//stamp Parameter SQL
            			objReportParm.parameterSQL = objDBReader["paramSQL"].ToString();         
            			
            			//stamp Parameter Is System
            			bParameterIsSystem = objDBReader.GetBoolean(4);            			   			
            			
            			objReportParm.parameterIsSystem = bParameterIsSystem;
            			
	                
		            }

		            if (objDBReader != null)
		            {
		            	objDBReader.Close();
					}	            			            
					
	            } //if (reportSQLType == 1)
	            
   				bOK = true;

	        }
			catch (Exception ex)
			{
				bOK = false;
				objErrorLog.Append("Exception in source file reportType.cs " +
				                   "Method -- reportType.getReportParameters() " +  
				                   "SQL Query is " + strSQLQuery + "  " + 
				                   "SQL Parameter 1 [Name of SP] is " + reportSQL + "  " + 				                   
				                   "Exception: " + ex.Message);
			}	            

			if (objDBReader != null)
			{            
            	objDBReader = null;
			}            	
			
			return (bOK);
	
       
       } //getReportParameters()                                                             
       
       
       
       public Boolean validateReportParameters()
       {

            Boolean   		bOK = true;
            int       		iParameterIndex = -1;
            int       	    iParameterCount = -1;
            reportParameter objReportParameter = null;
                        
           
			//LabelInfo.Text = "In getReportParameters()";
			//LabelInfo.Visible = true;	
			
			
				           
            try
            {
            	
           		objLog.Length = 0;
           	
            	//get number of reports
            	iParameterCount = objParameterList.Count;
            	
            	for (iParameterIndex = 0;
            	     iParameterIndex < iParameterCount;
            	     iParameterIndex++)
				{            	     
		
					objReportParameter = (reportParameter) objParameterList[iParameterIndex];
					
					if (objReportParameter.parameterValue == null)
					{
												
                        objLog.Append("Validation failed on " + objReportParameter.parameterNameAsDisplay + ".  " );					
                        objLog.Append("It can not be null.");					                            
                        bOK = false;					   
                        break; 						
						
					}
							
					if (objReportParameter.parameterValue.CompareTo("") == 0)
					{
                            objLog.Append("Validation failed on " + objReportParameter.parameterNameAsDisplay + ".  " );					
                            objLog.Append("It can not be empty.");					                            
                        	bOK = false;					   
                        	break; 
					}
					else
					{
					
    					bOK = objReportParameter.validateParameter() && bOK;
    							
    					if (bOK == false)
    					{					 							
    						objLog.Append("Validation failed on " + objReportParameter.parameterNameAsDisplay + ".  " );					
    						objLog.Append("The value tested is " + objReportParameter.parameterValue + ".  " );	
    						objLog.Append("The system was expecting" );																											
    						if (objReportParameter.parameterDataType == reportParameterDBType.Integer)
    						{
    							objLog.Append(" an " );																																														
    						}
    						else
    						{
    							objLog.Append(" a " );																																																					
    						}
    						objLog.Append(objReportParameter.parameterDataType.ToString() + ".  " );																																	
    						bOK = false;
    						break;
    					}						
		            }
				}
	            
	            

	        }
			catch (Exception ex)
			{
				objLog.Append(     "Exception in reportTpe.validateReportParameters: " 
				                 + "Exception is " + ex.Message + "  "
				                 + "Parameter index is " + iParameterIndex + ".  "
				                 + "Parameter count is " + iParameterCount
				              );
				                 
				bOK = false;
			}	            

			return (bOK);
       
       }                                                                  
       
              
        
    }
}
    