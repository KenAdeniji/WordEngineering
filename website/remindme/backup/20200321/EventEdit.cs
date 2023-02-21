namespace EphraimTech

{


    using System;
    using System.Collections;
    using System.Web.UI.HtmlControls;            
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.ComponentModel;
    using System.Data;
    using System.Data.OleDb;
    using System.Text;    //StringBuilder
    

	public class EventEdit : System.Web.UI.Page
	{
	
		protected DataView objDataView;
		protected DropDownList ddlSubject;
		
		protected DropDownList ddlDateStartMonth;
		protected DropDownList ddlDateStartDay;
		protected DropDownList ddlDateStartYear;
		protected DropDownList ddlTimeStartHour;
		protected DropDownList ddlTimeStartMinute;
		protected DropDownList ddlTimeStartAMPM;
								
		protected DropDownList ddlDateEndMonth;
		protected DropDownList ddlDateEndDay;
		protected DropDownList ddlDateEndYear;
		protected DropDownList ddlTimeEndHour;
		protected DropDownList ddlTimeEndMinute;
		protected DropDownList ddlTimeEndAMPM;
		
		protected CheckBox chkAllDayEvent;
										
		protected TextBox editQuote;
		protected TextBox editAuthored;
		protected TextBox editURL;		
        protected HtmlInputHidden hiddenQuoteId;   
        protected Label labelMessage;    		
                
        protected Button buttonDelete;
        protected Button buttonAddMore;
        
        Boolean bQuoteExists;
		
        String strDBConnection = "Provider=SQLOLEDB.1;" + 
                                 "Server=sql.ephraimtech.com;" +                                  
                                 "initial Catalog=quotes;" +
                                 "Integrated Security=SSPI;";                                    
                                 
        String strQuoteID = null;
        String strQuote = null;
        String strAuthored = null;
        String strURL = null;
        String strSubjectId = null;
        
        String strPassedInSubjectID = null;        
                
        static String PARAMETER_QUOTE_ID = "quoteID";
        static String PARAMETER_QUOTE_SUBJECT_ID = "SubjectID";
                                         		
        private DataView getRecordSetQuotesSubject()
        {
        
            OleDbConnection objConnection = null;
            OleDbDataAdapter objDbAdapter = null;
            DataSet objDataSet = null;
           
            String strSQLQuery;
            
            DataView objDataViewQuotesSubject = null;                       
                                            
            strSQLQuery = "";
            strSQLQuery = strSQLQuery + " select id, name from QuotesSubject  ";                    
            strSQLQuery = strSQLQuery + " order by name ";                  

            objConnection = new OleDbConnection(strDBConnection);
            
            objDbAdapter = new OleDbDataAdapter();            
            
            objDbAdapter.SelectCommand = new OleDbCommand(strSQLQuery, 
                                                          objConnection);
            

            objDataSet = new DataSet("QuotesSubject");
            objDbAdapter.Fill(objDataSet);

            
            objDataViewQuotesSubject = objDataSet.Tables[0].DefaultView;
            
            objDataViewQuotesSubject.RowFilter = String.Empty;

                                    
            return objDataViewQuotesSubject;                                                
                

                
        }
        
        
        private void populateQuotesSubjectComboBox()
        {
        
            DataView objDataViewQuotesSubject;                      
    
            objDataViewQuotesSubject = getRecordSetQuotesSubject();
            
            ddlSubject.DataSource = objDataViewQuotesSubject;
            ddlSubject.DataValueField = "id";
            ddlSubject.DataTextField = "name";                      
            
            ddlSubject.DataBind();
                                
        }		
        
        
        protected void Page_Load(Object Sender, EventArgs evt)
        {
            initPage(Sender, evt);
        }
        
        protected void initPage(Object Sender, EventArgs evt)
        {
        
            Boolean bFound = false;
            
            //getPassedInParameters();

            //reflectState();
                
            if (IsPostBack == false)
            {
            
                    //populate Start
                    populateComboBoxMonth(ddlDateStartMonth);
                    populateComboBoxDay(ddlDateStartDay);
                    populateComboBoxYear(ddlDateStartYear);
                    populateComboBoxHour(ddlTimeStartHour);
                    populateComboBoxMinute(ddlTimeStartMinute);
                    populateComboBoxAMPM(ddlTimeStartAMPM);
                    
                    //populate End
                    populateComboBoxMonth(ddlDateEndMonth);
                    populateComboBoxDay(ddlDateEndDay);
                    populateComboBoxYear(ddlDateEndYear);
                    populateComboBoxHour(ddlTimeEndHour);
                    populateComboBoxMinute(ddlTimeEndMinute);
                    populateComboBoxAMPM(ddlTimeEndAMPM);                    
                                                                                
                    //if we are adding data
                    //if (strQuoteID == null)
                    if ( 1 == 1)
                    {
                    
                        //indicate default subject based on caller's current subject
                        //SelectListBox(ddlSubject, strPassedInSubjectID);
                        
                        //editAuthored.Text = ddlSubject.SelectedItem.Text + "";                        
                    
                    }
                    else
                    {
                    
                        //bFound = getCurrentDataFromDB();                    
                        
                        if (bFound)
                        {
                        
                            //hiddenQuoteId.Value = strQuoteID;
    
                            //SelectListBox(ddlSubject, strSubjectId);
                                                        
                            //editQuote.Text = strQuote + "";
                            //editAuthored.Text = strAuthored + "";
                            //editURL.Text = strURL + "";                        
                        }                        
                        
                    }
            }            
            
        }                        
        
        
        protected void populateComboBoxMonth(DropDownList ddlMonth)
        {
        
            ddlMonth.Items.Clear();
        
            ddlMonth.Items.Add(new ListItem("January", "1"));
            ddlMonth.Items.Add(new ListItem("February", "2"));
            ddlMonth.Items.Add(new ListItem("March", "3"));
            ddlMonth.Items.Add(new ListItem("April", "4"));
            ddlMonth.Items.Add(new ListItem("May", "5"));
            ddlMonth.Items.Add(new ListItem("June", "6"));
            ddlMonth.Items.Add(new ListItem("July", "7"));                                                            
            ddlMonth.Items.Add(new ListItem("August", "8"));
            ddlMonth.Items.Add(new ListItem("September", "9"));
            ddlMonth.Items.Add(new ListItem("October", "10"));
            ddlMonth.Items.Add(new ListItem("November", "11"));
            ddlMonth.Items.Add(new ListItem("December", "12"));
        
        }
                

        protected void populateComboBoxDay(DropDownList ddlDay)
        {
        
            int iNumberofMonths = 31;
            int iIndex;
            String strMonth;
            
            ddlDay.Items.Clear();
            
            for (iIndex = 1; iIndex < iNumberofMonths; iIndex++)
            {
                strMonth = iIndex + "";
                ddlDay.Items.Add(new ListItem(strMonth, strMonth));            
            }
        
        }

        
        protected void populateComboBoxYear(DropDownList ddlYear)
        {
        
            int iNumberofYears = 5;
            int iNumberofYearstoGoBack = 2;            
            int iIndex;
            String strYear;
            int iYear;
            
            DateTime objNow;
            
            objNow = DateTime.Now;
            
            iYear = objNow.Year - iNumberofYearstoGoBack;
            
            ddlYear.Items.Clear();
            
            for (iIndex = iYear; iIndex < iYear + iNumberofYears; iIndex++)
            {
                strYear = iIndex + "";
                ddlYear.Items.Add(new ListItem(strYear, strYear));            
            }
        
        }        
        
        
        protected void SelectListBox(DropDownList objListControl, String strChoice)
        {
        
            int iIndex = 0;
            int iNumberofEntries =0;
            String strItem = null;
            ListItem objListItem = null;
            
            iNumberofEntries = objListControl.Items.Count;
            
            for (iIndex = 0; iIndex < iNumberofEntries; iIndex++)
            {
                objListItem = objListControl.Items[iIndex];
                
                strItem = objListItem.Value;
                
                if (strItem == strChoice)
                {
                    objListItem.Selected = true;                    
                }
                
            }
            
        }                        
		
		
        protected void populateComboBoxHour(DropDownList ddlDropDownList)
        {
        
            int iNumberofEntries = 12;
            int iIndex;
            String strData;
            
            ddlDropDownList.Items.Clear();
            
            iIndex = 12;
            strData = iIndex + "";            
            
            ddlDropDownList.Items.Add(new ListItem(strData, strData));                        
            
            for (iIndex = 1; iIndex < iNumberofEntries; iIndex++)
            {
                strData = iIndex + "";
                ddlDropDownList.Items.Add(new ListItem(strData, strData));            
            }
        
        }		
		
		
        protected void populateComboBoxMinute(DropDownList ddlDropDownList)
        {
            
            ddlDropDownList.Items.Clear();
           
            ddlDropDownList.Items.Add(new ListItem("00", "0"));                        
            ddlDropDownList.Items.Add(new ListItem("15", "15"));                        
            ddlDropDownList.Items.Add(new ListItem("30", "30"));                        
            ddlDropDownList.Items.Add(new ListItem("45", "45"));                                                            

        }		
        		
        		
        protected void populateComboBoxAMPM(DropDownList ddlDropDownList)
        {
            
            ddlDropDownList.Items.Clear();
           
            ddlDropDownList.Items.Add(new ListItem("AM", "AM"));                        
            ddlDropDownList.Items.Add(new ListItem("PM", "PM"));                        

        }	
        
        
        protected void buttonAllDayEventClicked(Object Sender, EventArgs E)
        {
        
            Boolean bChecked;
            Boolean bSetting;            
            
            bChecked = chkAllDayEvent.Checked;
            bSetting = (bChecked == false);
            
            ddlTimeStartHour.Enabled = bSetting;
            ddlTimeStartMinute.Enabled = bSetting;
            ddlTimeStartAMPM.Enabled = bSetting;

            ddlTimeEndHour.Enabled = bSetting;
            ddlTimeEndMinute.Enabled = bSetting;
            ddlTimeEndAMPM.Enabled = bSetting;
        
        }
        	
                		
        protected void buttonSaveAndMoreClicked(Object Sender, EventArgs E)
        {
        
            Boolean bUpdated = false;
            
            updateDB();

            editQuote.Text = "";
            //editAuthored.Text = "";
            editURL.Text = "";                                        

        }		



        protected void buttonSubmitClicked(Object Sender, EventArgs E)
        {
            /*
                    
            Boolean bUpdated = false;
            String strRedirectURL = "Quotes.aspx";
            
            updateDB();
                
            Response.Redirect(strRedirectURL);
            Response.Write("Redirect URL is " + strRedirectURL + "<BR>");                
            
            */
        }		
        
        
        protected void getPassedInParameters()
        {
        
            
            strQuoteID = Request[PARAMETER_QUOTE_ID];
            strPassedInSubjectID = Request[PARAMETER_QUOTE_SUBJECT_ID];            
            
            
            if (IsPostBack)
            {
            
            
            }
            else
            {

            }
            
        
        
        }

        
        protected void reflectState()
        {
        
            
            if (strQuoteID == null)
            {
                bQuoteExists = false;
            }
            else
            {
                bQuoteExists = true;
            }        
            
            buttonDelete.Visible = bQuoteExists;
            buttonAddMore.Visible = (bQuoteExists == false);
            
        }
        
        protected Boolean getCurrentDataFromDB()
        {
        
            StringBuilder strSQLBuilder = null;
            String strSQL = null;
            Boolean bFound = false;
            
            if (strQuoteID != null)
            {

                strSQLBuilder = new StringBuilder();
                            
                strSQLBuilder.Append(" select isNull(Subject, -1) ");
                strSQLBuilder.Append(" , isNull(Quote,'')  ");                                
                strSQLBuilder.Append(" , isNull(Authored,'')  ");                
                strSQLBuilder.Append(" , isNull(URL,'')  ");                                
                strSQLBuilder.Append(" from   quotes ");
                strSQLBuilder.Append(" where  quoteId = '" + strQuoteID + "' ");                            
                
                strSQL = strSQLBuilder.ToString();


                OleDbConnection objDBConn = new OleDbConnection(strDBConnection);

                OleDbCommand objDBCMD = new OleDbCommand(strSQL, objDBConn);
                
                objDBConn.Open();
                

                OleDbDataReader objDBReader = objDBCMD.ExecuteReader();
                

                while (objDBReader.Read())
                {
                
                    strSubjectId = objDBReader.GetInt32(0) + "";                                
                    strQuote = objDBReader.GetString(1) + "";                
                    strAuthored = objDBReader.GetString(2) + "";                
                    strURL = objDBReader.GetString(3) + "";                
                                                            
                    bFound = true;
                }
                
                objDBReader.Close();
                
                
            }
            
            return bFound;
            
        
        
        }        
        
        

        protected Boolean updateDB()
        {
        
            StringBuilder strSQLBuilder = null;
            String strSQL = null;
            Boolean bUpdated = false;
            Boolean bInserting = false;
            
            if (hiddenQuoteId.Value == null)
            {
                bInserting = true;            
            }
            else
            {
                if (hiddenQuoteId.Value.Length == 0)
                {
                    bInserting = true;                            
                }
                else
                {
                    bInserting = false;            
                }                    
            }                        
            
            
            if (bInserting == false)
            {

                strSQLBuilder = new StringBuilder();
                                        
                strSQLBuilder.Append(" exec " + "" + "sp_QuotesUpdate " + " " );                                        
                strSQLBuilder.Append(" ?, ?, ?, ?, ? ");
                
            }
            else    
            {

                strSQLBuilder = new StringBuilder();
                                        
                strSQLBuilder.Append(" exec " + "" + "sp_QuotesInsert " + " " );                                        
                strSQLBuilder.Append(" ?, ?, ?, ?, ? ");
                
            }
                                                                
                strSQL = strSQLBuilder.ToString();
                
                //labelMessage.Text = strSQL + hiddenQuoteId.Value + "[" + hiddenQuoteId.Value.Length + "]"  ;

                OleDbConnection objDBConn = new OleDbConnection(strDBConnection);

                OleDbCommand objDbCommand = new OleDbCommand(strSQL, objDBConn);
                
                objDBConn.Open();
                
                
                if (bInserting == false)
                {
                    OleDbParameter objDBParameterQuoteID = new OleDbParameter();
                    objDBParameterQuoteID.ParameterName = "QuoteID";
                    objDBParameterQuoteID.OleDbType = OleDbType.VarChar;
                    objDBParameterQuoteID.Size = 88;
                    objDBParameterQuoteID.Value = hiddenQuoteId.Value; 
                    objDbCommand.Parameters.Add(objDBParameterQuoteID);
                }
                
                
                OleDbParameter objDBParameterSubject = new OleDbParameter();
                objDBParameterSubject.ParameterName = "SubjectID";
                objDBParameterSubject.OleDbType = OleDbType.Integer;
                objDBParameterSubject.Value = ddlSubject.SelectedItem.Value;
                objDbCommand.Parameters.Add(objDBParameterSubject);                
                
                OleDbParameter objDBParameterQuote = new OleDbParameter();
                objDBParameterQuote.ParameterName = "Quote";
                objDBParameterQuote.Size = 1000;                
                objDBParameterQuote.OleDbType = OleDbType.VarChar;
                objDBParameterQuote.Value = editQuote.Text;
                objDbCommand.Parameters.Add(objDBParameterQuote);                
                

                OleDbParameter objDBParameterAuthored = new OleDbParameter();
                objDBParameterAuthored.ParameterName = "Authored";
                objDBParameterAuthored.Size = 255;                
                objDBParameterAuthored.OleDbType = OleDbType.VarChar;
                objDBParameterAuthored.Value = editAuthored.Text;
                objDbCommand.Parameters.Add(objDBParameterAuthored);                
                
                OleDbParameter objDBParameterURL = new OleDbParameter();
                objDBParameterURL.ParameterName = "URL";
                objDBParameterURL.Size = 500;                                
                objDBParameterURL.OleDbType = OleDbType.VarChar;
                objDBParameterURL.Value = editURL.Text;
                objDbCommand.Parameters.Add(objDBParameterURL);                                
                
                if (bInserting)
                {
                    OleDbParameter objDBParameterQuoteID = new OleDbParameter();
                    objDBParameterQuoteID.ParameterName = "QuoteID";
                    objDBParameterQuoteID.Direction = ParameterDirection.Output;
                    objDBParameterQuoteID.OleDbType = OleDbType.VarChar;
                    objDBParameterQuoteID.Size = 88;
                    objDBParameterQuoteID.Value = hiddenQuoteId.Value; 
                    objDbCommand.Parameters.Add(objDBParameterQuoteID);
                }                
                                                
                objDbCommand.ExecuteNonQuery();
                
                objDbCommand.Connection.Close();
                
                bUpdated = true;
                
            return bUpdated;        
        }                
        
        
        protected void buttonDeleteClicked(Object Sender, EventArgs E)
        {
            Boolean bUpdated = false;
            String strRedirectURL = "Quotes.aspx";
            
            DBDelete();
                
            Response.Redirect(strRedirectURL);
            Response.Write("Redirect URL is " + strRedirectURL + "<BR>");                
        }		
        
        
        protected Boolean DBDelete()
        {
        
            StringBuilder strSQLBuilder = null;
            String strSQL = null;
            Boolean bUpdated = false;
            Boolean bInserting = false;
            
            if (hiddenQuoteId.Value == null)
            {
                return false;            
            }


            strSQLBuilder = new StringBuilder();
                                        
            strSQLBuilder.Append(" exec " + "" + "sp_QuotesDelete " + " " );                                        
            strSQLBuilder.Append(" ? ");

                                                                
            strSQL = strSQLBuilder.ToString();
                
            labelMessage.Text = strSQL + hiddenQuoteId.Value + "[" + hiddenQuoteId.Value.Length + "]"  ;

            OleDbConnection objDBConn = new OleDbConnection(strDBConnection);

            OleDbCommand objDbCommand = new OleDbCommand(strSQL, objDBConn);
                
            objDBConn.Open();
                
            OleDbParameter objDBParameterQuoteID = new OleDbParameter();
            objDBParameterQuoteID.ParameterName = "QuoteID";
            objDBParameterQuoteID.OleDbType = OleDbType.VarChar;
            objDBParameterQuoteID.Size = 88;
            objDBParameterQuoteID.Value = hiddenQuoteId.Value; 
            objDbCommand.Parameters.Add(objDBParameterQuoteID);
                                        
            objDbCommand.ExecuteNonQuery();
        
            objDbCommand.Connection.Close();
        
            bUpdated = true;
        
            return bUpdated;        
            
        }                        
                
					
    }


}