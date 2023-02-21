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
    using System.Text;    //StringBuilder    
    using System.Configuration;                

    public class SupportAffliates : System.Web.UI.Page
    {
        
        protected DataGrid nameDataGrid;
        protected DataView objDataView;
        protected DropDownList ddlSubject;
        protected Label labelSQL;
        protected Label labelSubjectID;
        protected Label labelCurrentPageNumber;
        protected Label labelMessage;
   		protected TextBox editQuoteSubject;		
                
        protected HyperLink hyperLinkQuoteEdit;
        protected HyperLink hyperLinkLogoff;
                
        private String initialArrangementColumn = "Dated";        
        
        private Boolean bGuest;
                       
        String SessionNameData = "SessionNameData";


        String strDBConnection = null;
                                                                         
        String strSortExpression = "";                   
        
        String SessionSortExpression = "SessionSortExpressionQuoteTopics";     
        String SessionCurrentPageIndex = "CurrentPageIndexQuoteTopics";
        
        string strMemberName;		
        string strMemberID;

        //read configuration settings                                                                         
        protected void readConfigurationSettings()
        {
            strDBConnection = ConfigurationSettings.AppSettings["oleDBConnection.ConnectionString"];
        }             

                                                    
        private DataSet getRecords()
        {
        
            OleDbConnection objConnection = null;
            OleDbDataAdapter objDbAdapter = null;
            DataSet objDataSet = null;
           
            String strSQLQuery;
            String strSQLConnection;
                                            
            strSQLQuery = "";
            strSQLQuery = strSQLQuery + " select [affliation_code], [affliation_name]  ";                    
            strSQLQuery = strSQLQuery + " from   [dbo].[affliations]  ";      
            strSQLQuery = strSQLQuery + " where  [memberIdentifier] = '" + strMemberID + "' " ;                  
            strSQLQuery = strSQLQuery + " order by [affliation_name] ";                  
    
            strSQLConnection = strDBConnection;
        

            objConnection = new OleDbConnection(strSQLConnection);
            
            objDbAdapter = new OleDbDataAdapter();            
            
            objDbAdapter.SelectCommand = new OleDbCommand(strSQLQuery, 
                                                          objConnection);
            

            objDataSet = new DataSet("QuotesSubject");
            objDbAdapter.Fill(objDataSet);

            return (objDataSet);

                
        }
        

        
        private void loadGrid()
        {
        
            DataSet objDataSet = null;
            
            //get Data
            objDataSet = getRecords();
            
            //set data source
            nameDataGrid.DataSource = objDataSet;
            
            //data Bind
            nameDataGrid.DataBind();
                
                
        }
        
        
        protected void Page_Load(Object Sender, EventArgs evt)
        {
            
            readConfigurationSettings();
            
            getUserInfo();
            
                        
            if (IsPostBack == false)
            {
                                                    
                //load names grid
                loadGrid();        
            }            
            
        
        }       
        

        protected void getUserInfo()
        {
        
            System.Security.Principal.IIdentity objIdentity;
        
            objIdentity = User.Identity;

            strMemberName = objIdentity.Name;
            
            if (Session["memberID"] != null)
            {
            	strMemberID = Session["memberID"].ToString();
            }				
            
        }                       
        

        protected void onPageIndexChangedNamesGrid(Object Sender, 
                                                   DataGridPageChangedEventArgs evt)
        {
            int iSessionPageNumber = -1;
        
            nameDataGrid.CurrentPageIndex = evt.NewPageIndex;
            
            //save Page Number
            Session[SessionCurrentPageIndex] = evt.NewPageIndex;            
            
            //display Page number
            labelCurrentPageNumber.Text = (nameDataGrid.CurrentPageIndex + 1).ToString();                                   
            
            //display Page number
            iSessionPageNumber = (int) Session[SessionCurrentPageIndex];
                                
            loadGrid();        
            
            //data Bind
            nameDataGrid.DataBind();                        
                
        }       
        


       protected void GridEdit(Object sender, DataGridCommandEventArgs e)
       {
          nameDataGrid.EditItemIndex = e.Item.ItemIndex;
          loadGrid();
       }

       protected void GridCancel(Object sender, DataGridCommandEventArgs e)
       {
            nameDataGrid.EditItemIndex = -1;
            loadGrid();
       }


       protected void GridUpdate(Object sender, DataGridCommandEventArgs e)
       {
       
       
          // For bound columns the edited value is stored in a textbox,
          // and the textbox is the 0th element in the column's cell.
          TextBox txtAffliate;
          String strID = "";  
          string strData = "";      
          String strSubject;    
          int iDataGridRowIndex = -1;
          object objDataKey = null;
          DataGridItemCollection objDataGridItemCollection = null;
          DataGridItem objDataGridItem = null;
          
          //get Data Grid Items
          objDataGridItemCollection = nameDataGrid.Items;
          
          //get the index of the currently selected data grid row
          iDataGridRowIndex = (int)e.Item.ItemIndex;      
          
          //get current data grid row          
          objDataGridItem = objDataGridItemCollection[iDataGridRowIndex];          
          
          //get data key associated with row
          //in our case it is affliate_code
          //this property/column is indicated when defining the data grid
          objDataKey = nameDataGrid.DataKeys[iDataGridRowIndex];
          
          //get the data key - affliate_code
          strID = objDataKey.ToString();
          
          //get the edited affliate name
          txtAffliate = (TextBox)e.Item.Cells[1].Controls[0];
              
          //get the edited affliate name                
          //strData = e.Item.Cells[1].Text;        
          //strData = objDataGridItem.Cells[2].Text;
          
          strSubject = txtAffliate.Text;          
          
          labelMessage.Text = "Data Grid Row is " + iDataGridRowIndex + ".   " + 
                              "ID is " + strID + ".   " +           
                              "Subject is " + strSubject;

          if (strID == "-1")
          { 
            DBInsert(strMemberID, strSubject);
          }
          else              
          { 
            DBUpdate(strMemberID, strID, strSubject);
          }
          
          nameDataGrid.EditItemIndex = -1;
          
          loadGrid();
          
       }
       
       
        protected Boolean DBUpdate(String strMemberID, 
                                   String strAffliateID, 
                                   String strSubject)
        {
        
            StringBuilder strSQLBuilder = null;
            String strSQL = null;
            Boolean bUpdated = false;
            Boolean bInserting = false;
            

            strSQLBuilder = new StringBuilder();
                                        
            strSQLBuilder.Append("usp_AffliateUpdate");                                        
                                                                
            strSQL = strSQLBuilder.ToString();
                
            //labelMessage.Text = strSQL + hiddenQuoteId.Value + "[" + hiddenQuoteId.Value.Length + "]"  ;

            OleDbConnection objDBConn = new OleDbConnection(strDBConnection);

            OleDbCommand objDbCommand = new OleDbCommand(strSQL, objDBConn);
            
            objDbCommand.CommandType = CommandType.StoredProcedure;            
                
            objDBConn.Open();
            
            OleDbParameter objDBParameterMemberID = new OleDbParameter();
            //objDBParameterMemberID.ParameterName = "MemberID";
            objDBParameterMemberID.OleDbType = OleDbType.VarChar;
            objDBParameterMemberID.Size = 88;
            objDBParameterMemberID.Value = strMemberID;
            objDbCommand.Parameters.Add(objDBParameterMemberID);            
                
            OleDbParameter objDBParameterQuoteID = new OleDbParameter();
            //objDBParameterQuoteID.ParameterName = "AffliateID";
            objDBParameterQuoteID.OleDbType = OleDbType.Integer;
            objDBParameterQuoteID.Size = 88;
            objDBParameterQuoteID.Value = strAffliateID;
            objDbCommand.Parameters.Add(objDBParameterQuoteID);
            
            
            OleDbParameter objDBParameterQuoteSubject = new OleDbParameter();
            //objDBParameterQuoteSubject.ParameterName = "QuoteSubject";
            objDBParameterQuoteSubject.OleDbType = OleDbType.VarChar;
            objDBParameterQuoteSubject.Size = 88;
            objDBParameterQuoteSubject.Value = strSubject;
            objDbCommand.Parameters.Add(objDBParameterQuoteSubject);
                                        

            objDbCommand.ExecuteNonQuery();
        
            objDbCommand.Connection.Close();
        
            bUpdated = true;
        
            return bUpdated;        
            
        }                               
        

        protected Boolean DBInsert(String strMemberID, 
                                   String strSubject)
        {
        
            StringBuilder strSQLBuilder = null;
            String strSQL = null;
            Boolean bUpdated = false;
            Boolean bInserting = false;
            

            strSQLBuilder = new StringBuilder();
                                        
            strSQLBuilder.Append("usp_AffliateInsert");                                        
                                                                
            strSQL = strSQLBuilder.ToString();
                
            //labelMessage.Text = strSQL + hiddenQuoteId.Value + "[" + hiddenQuoteId.Value.Length + "]"  ;

            OleDbConnection objDBConn = new OleDbConnection(strDBConnection);

            OleDbCommand objDbCommand = new OleDbCommand(strSQL, objDBConn);
            
            objDbCommand.CommandType = CommandType.StoredProcedure;            
                
            objDBConn.Open();
            
            OleDbParameter objDBParameterMemberID = new OleDbParameter();
            //objDBParameterMemberID.ParameterName = "MemberID";
            objDBParameterMemberID.OleDbType = OleDbType.VarChar;
            objDBParameterMemberID.Size = 88;
            objDBParameterMemberID.Value = strMemberID;
            objDbCommand.Parameters.Add(objDBParameterMemberID);            
            
            
            OleDbParameter objDBParameterQuoteSubject = new OleDbParameter();
            //objDBParameterQuoteSubject.ParameterName = "QuoteSubject";
            objDBParameterQuoteSubject.OleDbType = OleDbType.VarChar;
            objDBParameterQuoteSubject.Size = 88;
            objDBParameterQuoteSubject.Value = strSubject;
            objDbCommand.Parameters.Add(objDBParameterQuoteSubject);
                                        

            objDbCommand.ExecuteNonQuery();
        
            objDbCommand.Connection.Close();
        
            bUpdated = true;
        
            return bUpdated;        
            
        }                               


        
        
        
        
        protected void buttonAddClicked(Object Sender, EventArgs E)
        {
            

            DataSet objDataSet = null;
            System.Data.DataRow objDataRow = null;
            CommandEventArgs objCommandArgs = null;
            DataGridItem objDataGridItem;            
            DataGridCommandEventArgs objDataGridCommandEventArgs;            
            int iDataGridRowIndexNew = 0;
            
            //get Data
            objDataSet = getRecords();
                        
                        
            //Add new row
            objDataRow = objDataSet.Tables[0].NewRow();
            
            objDataSet.Tables[0].Rows.InsertAt(objDataRow, iDataGridRowIndexNew);
            
            objDataRow["affliation_name"] = "";
                        
            //set row key to -1                        
            //nameDataGrid.DataKeys[iDataGridRowIndexNew] = "-1";            
            objDataRow["affliation_code"] = "-1";
          
            //set data source
            nameDataGrid.DataSource = objDataSet;
            
            //App does work properly unless we 're on first page
            //rather than displaying blank row, previous page data is displayed
            //And, so we 'are setting current page to first page
            nameDataGrid.CurrentPageIndex = 0;
            
            //get newly inserted data
            objDataGridItem = nameDataGrid.Items[0];            
            
            //http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpref/html/frlrfsystemwebuiwebcontrolscommandeventargsclasstopic.asp
            objCommandArgs = new CommandEventArgs("Add", "-1");      
            
            objDataGridCommandEventArgs = new DataGridCommandEventArgs(objDataGridItem,
                                                                       nameDataGrid,
                                                                       objCommandArgs);
            
            nameDataGrid.EditItemIndex = objDataGridItem.ItemIndex;
            
            //rebind data grid
            nameDataGrid.DataBind();                        
            
                
        }		        
        
        protected Boolean DBInsert(String strSubject, int iID)
        {
        
            StringBuilder strSQLBuilder = null;
            String strSQL = null;
            Boolean bUpdated = false;
            Boolean bInserting = false;
            

            strSQLBuilder = new StringBuilder();
                                        
            strSQLBuilder.Append("sp_QuotesSubjectInsert" + " " );                                                                
                                                                
            strSQL = strSQLBuilder.ToString();
                

            OleDbConnection objDBConn = new OleDbConnection(strDBConnection);

            OleDbCommand objDbCommand = new OleDbCommand(strSQL, objDBConn);
            
            objDbCommand.CommandType = CommandType.StoredProcedure;
                
            objDBConn.Open();
            
            OleDbParameter objDBParameterQuoteSubject = new OleDbParameter();
            objDBParameterQuoteSubject.ParameterName = "@QuoteSubject";
            objDBParameterQuoteSubject.OleDbType = OleDbType.VarChar;
            objDBParameterQuoteSubject.Size = 88;
            objDBParameterQuoteSubject.Value = strSubject;
            objDbCommand.Parameters.Add(objDBParameterQuoteSubject);            
                
            OleDbParameter objDBParameterQuoteID = new OleDbParameter();
            objDBParameterQuoteID.ParameterName = "@QuoteID";
            objDBParameterQuoteID.OleDbType = OleDbType.Integer;
            objDBParameterQuoteID.Direction = ParameterDirection.Output;            
            objDbCommand.Parameters.Add(objDBParameterQuoteID);
            

            objDbCommand.ExecuteNonQuery();
            
            //labelMessage.Text = strSQL + " [" + objDBParameterQuoteID.Value + "]";
            //labelMessage.Text = strSQL + " [" + objDbCommand.Parameters[0].Value + "-" +  objDbCommand.Parameters[1].Value + "]";
                    
            objDbCommand.Connection.Close();
        
            bUpdated = true;
        
            return bUpdated;        
            
        }                                           
            

    }
    
    



}