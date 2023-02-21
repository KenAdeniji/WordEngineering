namespace EphraimTech.RemindME
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
    
    class eventDay
    {
    
        //strDate = objDBReader["date"].ToString();
        //strDay = objDBReader["day"].ToString();
        //strWeekDay = objDBReader["dayofweek"].ToString();                
        
        private String strDate;        
        private int iDay;        
        private String strWeekDay;        
        
        public String Date
        {
            get { return strDate;}
            set { strDate = value;}
        }
        
        
        public int Day
        {
            get { return iDay;}
            set { iDay = value;}
        }
        
        public String WeekDay
        {
            get { return strWeekDay;}
            set { strWeekDay = value;}
        }        
        
    
    }
        

    public class frmContactCalendarBrowse : System.Web.UI.Page
    {
       
       
       private String strContact = null;
       
       private ArrayList objArrayList = new ArrayList();
       
       private String strDBConnection = null;
                                        
       private OleDbConnection objConnection = null;
       private OleDbCommand objDBCommand = null;       
       private OleDbDataAdapter objDbAdapter = null;			                                        

       
	   private String strSQLQuery;
	   
	   protected DataGrid gridContactCalendarInfo;	 
	   protected DataGrid gridContactAddressInfo;	 
	   	   
	   protected Label labelContact;
	   protected Label labelContactProfession;
	   protected Label labelContactAffliate;	   	   
	   protected Label labelContactComment;
	   
	   protected Label labelSQL;         
	   protected Label labelMessage;
	   
	   protected HyperLink idAnchorContactBrowse;
	   protected HyperLink idAnchorAddContactCommunication;
	   protected HtmlAnchor hyperLinkEditCustomer;
	   
       protected String strMemberID  = null;	   
       protected String strMemberName  = null;	   
              
       protected String strSelectedDate = null;
       protected int iCalenderDisplayTypeChoice = 0;
              
       private static String strCookieSelectedDate = "CalendarSelectedDate";
       private static String strCookieCalendarDisplayType = "CalendarDisplayType";      
       private static String strQueryStringSelectedDate = "SelectedDate";
       
       private static int CALENDAR_CHOICE_TYPE_IS_DAY = 1;
       private static int CALENDAR_CHOICE_TYPE_IS_WEEK = 2;
       private static int CALENDAR_CHOICE_TYPE_IS_MONTH = 3;       
       
	   protected Calendar calendar;
	   protected RadioButton RadioButtonCalendarTypeSelectionDay;
	   protected RadioButton RadioButtonCalendarTypeSelectionWeek;
	   protected RadioButton RadioButtonCalendarTypeSelectionMonth;
       
       //read configuration settings                                                                         
       protected void readConfigurationSettings()
       {
            strDBConnection = ConfigurationSettings.AppSettings["oleDBConnection.ConnectionString"];
       }             
       

       protected void Page_Load(Object Sender, EventArgs evt)
       {
       
            readConfigurationSettings();
       
			objConnection = new OleDbConnection(strDBConnection);
			
			objDBCommand = new OleDbCommand();
			
			objDBCommand.Connection = objConnection;
			        
            objConnection.Open();

            getUserInfo();
            
            getSavedCookie();
            
            getPassedInData();            
                        
            if (IsPostBack == false)
            {  
                      
               markSelectedCalendarRenderType();
               
               markSelectedDateOnCalendar();
               
               getBody();            
                            
            }                      
            
       }                                               
        
        
       protected void Page_UnLoad(Object Sender, EventArgs evt)
       {
            
			objDBCommand = null;
			       
            objConnection.Close();       
			objConnection = null;
			

        
       }               
       
       
       private void getBody()
       {
            
            changeCalendarMonthVisibilityBasedOnDate();
            
            getEventDates();
            
            loadCommentGrid();
            
       }        
       

       private void markSelectedCalendarRenderType()
       {
             
             if (iCalenderDisplayTypeChoice == CALENDAR_CHOICE_TYPE_IS_DAY)
             {
                RadioButtonCalendarTypeSelectionDay.Checked = true;
             }
             else if (iCalenderDisplayTypeChoice == CALENDAR_CHOICE_TYPE_IS_WEEK)
             {
                RadioButtonCalendarTypeSelectionWeek.Checked = true;
             }             
             else if (iCalenderDisplayTypeChoice == CALENDAR_CHOICE_TYPE_IS_MONTH)
             {
                RadioButtonCalendarTypeSelectionMonth.Checked = true;
             }             
             else
             {
                RadioButtonCalendarTypeSelectionDay.Checked = true;
             }                         


       }       
       
       
       private void markSelectedDateOnCalendar()
       {
            
            if (strSelectedDate != null)     
            {
            
                DateTime dtSelectedDate = new DateTime();
            
                    try
                    {
                    
                        dtSelectedDate = DateTime.Parse(strSelectedDate);
            
                        calendar.VisibleDate = dtSelectedDate;
                        
                        calendar.SelectedDate = dtSelectedDate;
                                                
                     }
                     catch(Exception ex)
                     {
                     
                     }   
                
            }                                       

       }
       
       
       private void changeCalendarMonthVisibilityBasedOnDate()
       {
            
            if (strSelectedDate != null)     
            {
            
                DateTime dtSelectedDate = new DateTime();
            
                    try
                    {
                    
                        dtSelectedDate = DateTime.Parse(strSelectedDate);
            
                        calendar.VisibleDate = dtSelectedDate;
                                                       
                     }
                     catch(Exception ex)
                     {
                     
                     }   
                
            }
            
       }                                        
       
       

       private void getSavedCookie()
       {
       
            System.Web.HttpCookie objCookie = null;
            String strCalenderDisplayTypeChoice = null;
            
            if (Request.Cookies[strCookieSelectedDate] != null)
            {
                strSelectedDate = Request[strCookieSelectedDate].ToString();            
            }
       
            if (Request.Cookies[strCookieCalendarDisplayType] != null)
            {
                strCalenderDisplayTypeChoice = Request[strCookieCalendarDisplayType].ToString();            
                
                try
                {
                    iCalenderDisplayTypeChoice = Int32.Parse(strCalenderDisplayTypeChoice);
                }
                catch (Exception ex)
                {
                
                }
                
                labelMessage.Text = "Calendar Type is " + iCalenderDisplayTypeChoice;
                
                                    
            }       
       }


       private void saveSettingsAsCookieData()
       {
       
            System.Web.HttpCookie objCookie;
            
            //Get Selected Date
            if (strSelectedDate != null)
            {
                objCookie = new System.Web.HttpCookie(strCookieSelectedDate); 
                objCookie.Value = strSelectedDate;
                Response.Cookies.Add(objCookie);
                objCookie = null;
            }                
            
            //Save Calendar rendering display
            if (iCalenderDisplayTypeChoice != 0)
            {
                objCookie = new System.Web.HttpCookie(strCookieCalendarDisplayType); 
                objCookie.Value = iCalenderDisplayTypeChoice + "";
                Response.Cookies.Add(objCookie);
                objCookie = null;                
            } 


            
       }                                        
              
       
       private DataView getContactCommentInfo()
	   {
			

            OleDbDataAdapter objDbAdapter = null;			                                        			
			DataSet objDataSet = null;
		    DataView objDataView = null;	

            //Calendar Display Type is DAY
            if (iCalenderDisplayTypeChoice == CALENDAR_CHOICE_TYPE_IS_DAY)
            {			
			    strSQLQuery = "renderDayCalendar";
			}
			else    
            {			
			    strSQLQuery = "renderCalendar";
			}
					
			labelSQL.Text = strSQLQuery;
			labelSQL.Text = "date is " + strSelectedDate;			
			
			//if selected date is not in cookie, and was not passed in, 
			if (strSelectedDate == null)
			{
			    strSelectedDate = DateTime.Today.ToShortDateString();
			}
			

		    objDBCommand.Parameters.Clear();				            
		    			
            objDBCommand.CommandText = strSQLQuery;
            objDBCommand.CommandType = CommandType.StoredProcedure;            
                
            OleDbParameter objDBParameterMemberID = new OleDbParameter();
            objDBParameterMemberID.OleDbType = OleDbType.VarChar;
            objDBParameterMemberID.Size = 255;
            objDBParameterMemberID.Value = strMemberID; 
            objDBCommand.Parameters.Add(objDBParameterMemberID);
            
			
            OleDbParameter objDBParameterDate = new OleDbParameter();
            objDBParameterDate.OleDbType = OleDbType.VarChar;
            objDBParameterDate.Size = 255;
            objDBParameterDate.Value = strSelectedDate; 
            objDBCommand.Parameters.Add(objDBParameterDate);            			
            
            //Calendar Display Type is DAY
            if (iCalenderDisplayTypeChoice == CALENDAR_CHOICE_TYPE_IS_DAY)
            {
	
                OleDbParameter objDBParameterDateBeginHr = new OleDbParameter();
                objDBParameterDateBeginHr.OleDbType = OleDbType.Integer;
                objDBParameterDateBeginHr.Value = 8;
                objDBCommand.Parameters.Add(objDBParameterDateBeginHr);            			
                	
                OleDbParameter objDBParameterDateEndHr = new OleDbParameter();
                objDBParameterDateEndHr.OleDbType = OleDbType.Integer;
                objDBParameterDateEndHr.Value = 17;
                objDBCommand.Parameters.Add(objDBParameterDateEndHr);         
                
            }
            //Calendar Display Type is Week or Month
            else if ( (iCalenderDisplayTypeChoice == CALENDAR_CHOICE_TYPE_IS_WEEK) ||
                      (iCalenderDisplayTypeChoice == CALENDAR_CHOICE_TYPE_IS_MONTH))
            {
	
                OleDbParameter objDBParameterRenderType = new OleDbParameter();
                objDBParameterRenderType.OleDbType = OleDbType.Integer;
                
                if (iCalenderDisplayTypeChoice == CALENDAR_CHOICE_TYPE_IS_WEEK)
                {
                    objDBParameterRenderType.Value = 1;
                }
                else                    
                {
                    objDBParameterRenderType.Value = 2;
                }
                                
                objDBCommand.Parameters.Add(objDBParameterRenderType);            			
                
            }            

            objDbAdapter = new OleDbDataAdapter();            


            objDbAdapter.SelectCommand = objDBCommand;

            objDataSet = new DataSet("namedetails");
            
            objDbAdapter.Fill(objDataSet);						
            
			
			objDataView = objDataSet.Tables[0].DefaultView;
			
			objDataView.RowFilter = String.Empty;
			
			
			return objDataView;
			

						
		}              
       
       
	   private void loadCommentGrid()
	   {
		
			ICollection objNames = null;
			
			//get Names
			objNames = getContactCommentInfo();
					
			//set data source
			gridContactCalendarInfo.DataSource = objNames;
			
			//data Bind
			gridContactCalendarInfo.DataBind();
			
	   }       
	   
   		 	   



        protected void getUserInfo()
        {
        
            System.Security.Principal.IIdentity objIdentity;
            Boolean bAuthenticated;
            
        
            objIdentity = User.Identity;
            
            bAuthenticated = objIdentity.IsAuthenticated;

            strMemberName = objIdentity.Name;
            
            if (Session["memberID"] != null)
            {
            	strMemberID = Session["memberID"].ToString();
            }	            
			
			//On 2015-08-10, dadeniji
			//santize
			if ( ( strMemberID == null) || ( strMemberID == String.Empty) )
			{
				
				String strURLHome = "login.aspx";
				Response.Redirect(strURLHome,true);
				
			}		
			
            
        }     
        
        
       private void getPassedInData()
       {
       
             if (Request.QueryString[strQueryStringSelectedDate] != null)
             {    
                strSelectedDate = Request.QueryString[strQueryStringSelectedDate];
             }                          
       
       }               
                      
        
        protected void getCurrentChoices()
        {
        
             if (calendar.SelectedDate != DateTime.MinValue)
             {    
             
                strSelectedDate = calendar.SelectedDate.ToShortDateString();
                
             }                   
             
             
             if (RadioButtonCalendarTypeSelectionDay.Checked)
             {
                iCalenderDisplayTypeChoice = CALENDAR_CHOICE_TYPE_IS_DAY;
             }
             else if (RadioButtonCalendarTypeSelectionWeek.Checked)
             {
                iCalenderDisplayTypeChoice = CALENDAR_CHOICE_TYPE_IS_WEEK;
             }
             else if (RadioButtonCalendarTypeSelectionMonth.Checked)
             {
                iCalenderDisplayTypeChoice = CALENDAR_CHOICE_TYPE_IS_MONTH;
             }
             else
             {
                iCalenderDisplayTypeChoice = CALENDAR_CHOICE_TYPE_IS_DAY;
             }
                                                    
             saveSettingsAsCookieData();             
        
        
        }
        
        
                      
        protected void dateSelectionChanged(Object sender, 
                                            EventArgs e) 
        {
         
             //get current choices
             getCurrentChoices();
             
             //get body
             getBody();
             
        }
        
        
        protected void RadioCalendarDisplayTypeBtnClicked(Object sender,
                                                          EventArgs e)
        {
            
             labelMessage.Text = "Calendar Type is " + iCalenderDisplayTypeChoice + " ";
                
             //get current choices
             getCurrentChoices();
             
             //get body
             getBody();
                                                         
        }
        

        //respond to Calendar Month Changes        
        protected void dateSelectionMonthChanged(Object sender, 
                                                 System.Web.UI.WebControls.MonthChangedEventArgs eventArgs) 
        {
         
             calendar.SelectedDate = eventArgs.NewDate;
             
             //get current choices
             getCurrentChoices();
             
             //get body
             getBody();
             
        }        
        
        
        protected void DayRender(Object source, DayRenderEventArgs e) 
        {

            Boolean bDateHasEvent = false;
            int iDay;
            
             // Change the background color of the days in the month
             // to yellow.
            if (!e.Day.IsOtherMonth)
            {
            
                iDay = e.Day.Date.Day;
                
                bDateHasEvent = DoesDateHaveAnEvent(iDay);
                
                if (bDateHasEvent)
                {
                
                    e.Cell.BackColor=System.Drawing.Color.Green;
                    
                }    

                // Add custom text to cell in the Calendar control.
                //if (e.Day.Date.Day == 18)
                //{
                //   e.Cell.Controls.Add(new LiteralControl("<br>Holiday"));
                //  
                //}
            }
        }        
        
        
        
       private void getEventDates()
	   {
			

            OleDbDataReader objDBReader = null;
			String strSQLQuery = "listDatesWithEventsForMonth";
			
            String strDate = null;
            String strDay = null;
            int    iDay = -1;
            String strWeekDay = null; 
            
            eventDay objEventDay = null;
                			
			
			//if selected date is not in cookie, and was not passed in, 
			//then use today
			if (strSelectedDate == null)
			{
			    strSelectedDate = DateTime.Today.ToShortDateString();
			}
			

		    objDBCommand.Parameters.Clear();				            
		    			
            objDBCommand.CommandText = strSQLQuery;
            objDBCommand.CommandType = CommandType.StoredProcedure;            
                
            OleDbParameter objDBParameterMemberID = new OleDbParameter();
            objDBParameterMemberID.OleDbType = OleDbType.VarChar;
            objDBParameterMemberID.Size = 255;
            objDBParameterMemberID.Value = strMemberID; 
            objDBCommand.Parameters.Add(objDBParameterMemberID);
			
            OleDbParameter objDBParameterDate = new OleDbParameter();
            objDBParameterDate.OleDbType = OleDbType.VarChar;
            objDBParameterDate.Size = 255;
            objDBParameterDate.Value = strSelectedDate; 
            objDBCommand.Parameters.Add(objDBParameterDate);            			
	

            objDBReader = objDBCommand.ExecuteReader();			
            
            while (objDBReader.Read())
            {

                                            
                strDate = objDBReader["date"].ToString();
                strDay = objDBReader["day"].ToString();
                strWeekDay = objDBReader["dayofweek"].ToString();                
               
                try
                {
                    iDay = Int32.Parse(strDay);
                }
                catch(Exception ex)
                {
                    iDay = -1;
                }    
                
                objEventDay = new eventDay();
                
                objEventDay.Date = strDate;                
                objEventDay.Day = iDay;                
                objEventDay.WeekDay = strWeekDay;                

                objArrayList.Add(objEventDay);                                                
                                            
            }
            
            objDBReader.Close();
            
            objDBReader = null;
			

						
		}              
		
		
       private Boolean DoesDateHaveAnEvent(int iDay)
	   {
			
            int iIndex;
            int iNumberofDays;
            eventDay objEventDay = null;            

            iIndex = 0;
            iNumberofDays = objArrayList.Count;

            for (iIndex = 0;
                 iIndex < iNumberofDays;
                 iIndex++)
            {     
            
                objEventDay = (eventDay) objArrayList[iIndex];                                                
                
                if (objEventDay.Day == iDay)
                {
                    return true;
                }
                
            }                               

			
            return false;
						
		}              		
                  

    }


}