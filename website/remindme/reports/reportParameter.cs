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
    using System.Text;    //StringBuilder    
    using System.Configuration;
    using PeopleSoft.AppCache;
    
    public enum reportParameterDBType
    {
    
    	 String,
    	 Integer,
    	 Float,
    	 Date
    	
    }   
    
    	
    public class reportParameter
    {
    	
    	private int	iParameterID = -1;
    	private String strParameterName = null;
    	private String strParameterNameLiteral = null;    	
    	private String strParameterSQL = null;    	
    	private String strParameterValue = null;
    	private String strParameterDataType = null;    	
    	private Boolean bParameterIsSystem = false;
    	
    	private reportParameterDBType iParameterDataType;    	    	
        private StringBuilder objLog = new StringBuilder();    	
        private StringBuilder objErrorLog = new StringBuilder();    	        
        private OleDbCommand objDBCommand = null;       
        private System.Web.HttpApplicationState objApplication = null; 
        
        public reportParameter()
        {
            
        }
        
        public reportParameter(reportParameter objReportParameter)
        {
            
            Application = objReportParameter.Application;
            DBCommand = objReportParameter.DBCommand;
            parameterName =  objReportParameter.parameterName;
            parameterNameLiteral = objReportParameter.parameterNameLiteral;
            parameterSQL = objReportParameter.parameterSQL;
            parameterDataType = objReportParameter.parameterDataType;
            parameterValue = objReportParameter.parameterValue;
            parameterID = objReportParameter.parameterID;
            parameterIsSystem = objReportParameter.parameterIsSystem;
        }
        
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
        
        public String parameterName
        {
            
            get
            {
                return strParameterName;
            }
            
            set
            {
                strParameterName = value;
            }            
        }
    
        public String parameterNameAsSystemParameter
        {
            
            get
            {
                return strParameterName.Substring(1);
            }
            

        }    
    
        public String parameterNameLiteral
        {
            
            get
            {
                return strParameterNameLiteral;
            }
            
            set
            {
                strParameterNameLiteral = value;
            }            
        }
        
            
        public String parameterSQL
        {
            
            get
            {
                return strParameterSQL;
            }
            
            set
            {
                strParameterSQL = value;
            }            
        }    


        public Boolean dropDown
        {
            

            
            get
            {
                
               
                if (strParameterSQL != null)
                {
                    if (strParameterSQL.Length > 0)
                    {
                        return true;
                    }   
                }
                
                return false;

            }
            

        }    
        
        public String parameterNameAsDisplay
        {
            
            get
            {
            	string strParameterNameLiteralLocal;
            	
       			if ( (strParameterNameLiteral == null) ||
       			     (strParameterNameLiteral.Length == 0))
				{		            			     
    	    		strParameterNameLiteralLocal = strParameterName.Substring(1);
				}        	    			            	
				else
				{
    	    		strParameterNameLiteralLocal = strParameterNameLiteral;						
				}						
						
                return (strParameterNameLiteralLocal) ;
            }
            

        }
    
    
    
        public String parameterDataTypeAsString
        {
            
            get
            {
                return strParameterDataType;
            }
            
            set
            {
                strParameterDataType = value;
                
                if ( 
                	    (strParameterDataType.CompareTo("date") == 0)
   	               	 || (strParameterDataType.CompareTo("datetime") == 0)
				   )
				{
					iParameterDataType = reportParameterDBType.Date;
				}				      	               	 
				
                
                else if ( 
                	    (strParameterDataType.CompareTo("int") == 0)
				   )
				{
					iParameterDataType = reportParameterDBType.Integer;
				}				      	               	 

                else 
				{
					iParameterDataType = reportParameterDBType.String;
				}				      	               	 				
								
            }            
        }
    
    
    
        public reportParameterDBType parameterDataType
        {
            
            get
            {
                return iParameterDataType;
            }
            
            set
            {
                iParameterDataType = value;
            }                        
            

        }
        
        public String parameterValue
        {
            
            get
            {
                return strParameterValue;
            }
            
            set
            {
                strParameterValue = value;
            }            
        }    

        public int parameterID
        {
            
            get
            {
                return iParameterID;
            }
            
            set
            {
                iParameterID = value;
            }            
        }    	
        
        
        public Boolean parameterIsSystem
        {
            
            get
            {
                return(bParameterIsSystem);
            }
            
            set
            {
                bParameterIsSystem = value;
            }            
        }    	        
        
        public void setParameterIsSystem(String strValue)
        {
        
        	if (strValue.CompareTo("0") == 0)
        	{
        		parameterIsSystem = false;
        	}
        	else
        	{
        		parameterIsSystem = true;
        	}        	
        	
        }
        
        public void setParameterIsSystem(int iValue)
        {
        
        	if (iValue == 0)
        	{
        		parameterIsSystem = false;
        	}
        	else
        	{
        		parameterIsSystem = true;
        	}        	
        	
        }        
        public Boolean validateParameter()
        {
        	
        	Boolean bValidated = true;
        	
        	try
        	{
        	
        		if (iParameterDataType == reportParameterDBType.Integer)
        		{
        			int iValue;
        			
        			iValue = Int32.Parse(strParameterValue);

					bValidated = true;        			
        		}
        		else if (iParameterDataType == reportParameterDBType.Float)
        		{
        			double dValue;
        			
        			dValue = Double.Parse(strParameterValue);

					bValidated = true;        			
        		}        		
        		else if (iParameterDataType == reportParameterDBType.Date)
        		{
        			DateTime dtValue;
        			
        			dtValue = DateTime.Parse(strParameterValue);

					bValidated = true;        			
        		}        		
        		
        		objLog.Append("Value of " + strParameterValue + " is invalid for " + strParameterName + ".  ");	
        		objLog.Append("Expecting and validated " + iParameterDataType.ToString() + ".  ");	        		        		

        		
        	}
        	catch (Exception ex)
        	{
        		objErrorLog.Append("Value of " + strParameterValue + " is invalid for " + strParameterName + ".  ");	
        		objErrorLog.Append("Expecting " + iParameterDataType.ToString() + ".  ");	        		        		
        		objErrorLog.Append("Exception is " + ex.Message);	        		
				bValidated = false;        			        		
        	}
        	
        	return (bValidated);
        	
        }
        
        
       public void populateParamCombobox(System.Web.UI.WebControls.ListControl objListControl)
       {
	
	
            try
            {
							
				PeopleSoft.AppCache.supportTableCache objSupportTableCache;
				
				objSupportTableCache = new PeopleSoft.AppCache.supportTableCache();
				
				objLog.Append("reportParameter::populateParamCombobox::Parameter name is " + strParameterName);				
				objLog.Append("reportParameter::populateParamCombobox::Parameter SQL is " + strParameterSQL);								
				
				objSupportTableCache.Application = Application;
	            objDBCommand.CommandType = CommandType.Text;            				
				objSupportTableCache.DBCommand = objDBCommand;
				objSupportTableCache.SQLQuery = strParameterSQL;
				objSupportTableCache.ID = strParameterName;
				objSupportTableCache.fill(objListControl.Items, 0);
				
				objLog.Append("reportParameter::populateParamCombobox::SupportTableCache Log is " + objSupportTableCache.Log);				
				
				objLog.Append("reportParameter::populateParamCombobox::SupportTableCache ErrorLog is " + objSupportTableCache.ErrorLog);				
								
				objLog.Append("reportParameter::populateParamCombobox::Number of entries for Parameter is " + objListControl.Items.Count);				
								
				if (objSupportTableCache.ErrorLog.Length > 0)
				{
				    objLog.Append(objSupportTableCache.ErrorLog);
				}
				else
				{
				    objLog.Append(objSupportTableCache.Log);
				}									
				
				objSupportTableCache = null;
	            
	        }
			catch (Exception ex)
			{
			    objErrorLog.Append("Exception in reportParameter.populateParamCombobox.  Exception is " 
			                       + ex.Message
								   + "SQL is " + strParameterSQL);
			}	                                        

	
       
       }                                                
    	
    	
       public void populateParamComboboxArchive(System.Web.UI.WebControls.ListControl objListControl)
       {
       
       
            OleDbDataReader objDBReader = null;
            String strItemValue = null;
            String strItemText = null;
	                            
           
            try
            {
            	
            	if (strParameterSQL == null)
            	{
            	    return;   
            	}

            	objListControl.Items.Clear();		            	    
            								
	            objDBCommand.CommandText = strParameterSQL;
	            
	            objDBCommand.CommandType = CommandType.Text;            
	            
	            objDBCommand.Parameters.Clear();
				
	            objDBReader = objDBCommand.ExecuteReader();	
	            
	            while (objDBReader.Read())
	            {
	
	
	                strItemValue = objDBReader[0].ToString();
	                strItemText = objDBReader[1].ToString();	                
	                
                	objListControl.Items.Add(new ListItem(strItemText, 
	                		                          strItemValue));                
	                
	            }
	
	            
	            objDBReader.Close();


	            
	        }
			catch (Exception ex)
			{
				objErrorLog.Append("Exception occured in populateParamCombobox().  Exception is " + ex.Message);
			}	            


			
			if (objDBReader != null)
			{            
            	objDBReader = null;
			}            	
	
       
       }                                                    	
    	
    }
}    