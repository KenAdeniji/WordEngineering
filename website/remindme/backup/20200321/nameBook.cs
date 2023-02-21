namespace EphraimTech

{


    using System;
    using System.Collections;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.ComponentModel;
    using System.Data;
    using System.Data.OleDb;
    

	public class nameBook : System.Web.UI.Page
	{
	
		protected DataGrid nameDataGrid;
		protected DataView objDataView;
		protected DropDownList ddlLanguage;
        protected Label labelCurrentPageNumber;		
		
		protected Label labelSQL;
		
		String SessionNameData = "SessionNameData";
		
		
        String strDBConnection = "Provider=SQLOLEDB.1;" + 
                                 "Server=guidance.ephraimtech.com;" + 
                                 "initial Catalog=nameBook;" +
                                 "Integrated Security=SSPI;";                                    


		                	 		
		private DataView getListofLanguages()
		{
		
            OleDbConnection objConnection = null;
            OleDbDataAdapter objDbAdapter = null;			
            
			DataSet objDataSet;			
			
			String strSQLQuery;
			
			DataView objDataViewLanguages;			
							
			strSQLQuery = "";
			strSQLQuery = strSQLQuery + " select languageID, languageName, sequence from listofLanguages  ";			
			strSQLQuery = strSQLQuery + " union  ";									
			strSQLQuery = strSQLQuery + " select -1 , ' All', 0  ";			
			strSQLQuery = strSQLQuery + " order by sequence   ";			
	                   
			objConnection = new OleDbConnection(strDBConnection);
			
            objDbAdapter = new OleDbDataAdapter();            
            
            objDbAdapter.SelectCommand = new OleDbCommand(strSQLQuery, 
                                                          objConnection);
            

            objDataSet = new DataSet("names");
            objDbAdapter.Fill(objDataSet);			
		
			objDataViewLanguages = objDataSet.Tables[0].DefaultView;
			
			objDataViewLanguages.RowFilter = String.Empty;
			
						
			return objDataViewLanguages; 						
			
		}
		
		
		private void populateLanguageComboBox()
		{
		
			DataView objDataView;			
		
			objDataView = getListofLanguages();
			
			ddlLanguage.DataSource = objDataView;
			ddlLanguage.DataValueField = "languageID";
			ddlLanguage.DataTextField = "languageName";			
			
			ddlLanguage.DataBind();
					
		}		
					
		private void getRecordSet()
		{
			
            OleDbConnection objConnection = null;
            OleDbDataAdapter objDbAdapter = null;			
			
			DataSet objDataSet;			
			
			String strSQLQuery;
			
			int iLanguageID;
			String strLanguageID;
			
			iLanguageID = ddlLanguage.SelectedIndex;
            strLanguageID = ddlLanguage.SelectedItem.Value;			

							
			strSQLQuery = "select * from v_listofNames  ";
		
		
			if (iLanguageID > 0)
			{
				//strLanguageID = ddlLanguage.SelectedItem.Value;				
				strSQLQuery = strSQLQuery + " where LanguageID = " + strLanguageID;
			}
			
			strSQLQuery = strSQLQuery + " order by actualName ";			
			
			labelSQL.Text = strSQLQuery;
			
			objConnection = new OleDbConnection(strDBConnection);
			
            objDbAdapter = new OleDbDataAdapter();            
            
            objDbAdapter.SelectCommand = new OleDbCommand(strSQLQuery, 
                                                          objConnection);
            

            objDataSet = new DataSet("namedetails");
            objDbAdapter.Fill(objDataSet);						
			
			objDataView = objDataSet.Tables[0].DefaultView;
			
			objDataView.RowFilter = String.Empty;
			
			//save dataset
			Session[SessionNameData] = objDataSet;
			
			
						
		}
				
		private void getNames()
		{
			getRecordSet();
		}
		
		private void loadNamesGrid()
		{
		
			ICollection objNames;
			
			//get Names
			getNames();
			
			//data View
			objNames = objDataView;
						
			//set data source
			nameDataGrid.DataSource = objNames;
			
			//data Bind
			nameDataGrid.DataBind();
			
		}
		
		
		protected void Page_Load(Object Sender, EventArgs evt)
		{
		
			if (IsPostBack == false)
			{
				populateLanguageComboBox();
			}		
							
			if (IsPostBack == false)
			{
				loadNamesGrid();
			}
		
		}        
		

     
    		protected void getNameClicked(Object Sender, EventArgs E)
    		{
    		
				//retset page to 0
				nameDataGrid.CurrentPageIndex = 0;				
			    		
				loadNamesGrid();    	

    		}


		protected void oldonPageIndexChangedNamesGrid(Object Sender, 
		                                           DataGridPageChangedEventArgs evt)
		{
		
            nameDataGrid.CurrentPageIndex = evt.NewPageIndex;
            
            nameDataGrid.CurrentPageIndex = 100;
                
            labelSQL.Text = nameDataGrid.CurrentPageIndex.ToString();    
                		
            labelSQL.Text = "Joy";
                            		
			loadNamesGrid();    	
			
			//data Bind
			//nameDataGrid.DataBind();			
		}	
		
		
		
        protected void onPageIndexChangedNamesGrid(Object Sender, 
                                                   DataGridPageChangedEventArgs evt)
        {
            int iSessionPageNumber = -1;
            
            try
            {
        
                nameDataGrid.CurrentPageIndex = evt.NewPageIndex;
                
                //save Page Number
                //Session[SessionCurrentPageIndex] = evt.NewPageIndex;            
                
                //display Page number
                labelCurrentPageNumber.Text = (nameDataGrid.CurrentPageIndex + 1).ToString();                                   
                
                //display Page number
                //iSessionPageNumber = (int) Session[SessionCurrentPageIndex];
                
                //labelCurrentPageNumber.Text = (nameDataGrid.CurrentPageIndex + 1).ToString() +  "[]" +
                //                              iSessionPageNumber;            
                                    
                loadNamesGrid();        
                
                
                //data Bind
                nameDataGrid.DataBind();                        
                
            }
            catch (Exception)
            {
            
            }                
                
        }       		
		

	
	}


}