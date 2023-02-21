namespace EphraimTech.RemindME

{


    using System;
    using System.Collections;
	using System.Collections.Generic;
    using System.Web.UI.HtmlControls;            
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.ComponentModel;
    using System.Data;
    using System.Data.OleDb;
    using System.Text;    //StringBuilder
    using System.Configuration;                
    using remindME.stateManagement;       
        

	public class frmContactEventEdit : System.Web.UI.Page
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
		protected CheckBox chkSameDayEvent;		
		protected RadioButtonList radioButtonEventStatus;
										
		protected TextBox editEventName;
		protected TextBox editEventComment;
		protected TextBox editEventLink;
		
        protected HtmlInputHidden hiddenContactEventID;   
        protected HtmlInputHidden hiddenURLReferer;
        
        protected Label labelMessage;    		
                
        protected Button buttonDelete;
        protected Button buttonAddMore;
        
	    //protected Label labelContactID;         	   
	    protected Label labelContactName;         	           
        
        Boolean bEventExists;
		
        String strDBConnection = null;
        
        private String strMemberID = null;
        private String strMemberName = null;        
        private String strContactID = null;
        private String strContactName = null;        
        private String strContactEventID = null;
        
                
        private static String PARAMETER_EVENT_ID = "ContactEventID";
        
        private static String strCookieContactID = "ContactID";               
        
        private OleDbConnection objConnection = null;
        private OleDbCommand objDBCommand = null;       
        private OleDbDataAdapter objDbAdapter = null;			                                                
        
        private String strEventName = null;
        private String strEventComment = null;
		private String strEventLink = null;
        private String strEventStartDate = null;                        
        private String strEventEndDate = null;                        
        private String strEventStatusCode = null;
        private int iEventStatusCode = -1;
        private int iAllDayEvent = -1;        
        private int iSameDayEvent = -1;                                         		
        
        private String strBaseEventStartDate = null;
        private String strBaseEventEndDate = null;        
        
        private String strValidationErrMessage = "";
        
        //read configuration settings                                                                         
        protected void readConfigurationSettings()
        {
            strDBConnection = ConfigurationSettings.AppSettings["oleDBConnection.ConnectionString"];
        }             
               
        protected void Page_Load(Object Sender, EventArgs evt)
        {
            initPage(Sender, evt);
        }
        
        protected void setDefaultStartDates()
        {
            
            selectListBox(ddlDateStartYear, DateTime.Now.Year.ToString());
            selectListBox(ddlDateStartMonth, DateTime.Now.Month.ToString());            
            selectListBox(ddlDateStartDay, DateTime.Now.Day.ToString());                        

            selectListBox(ddlDateEndYear, DateTime.Now.Year.ToString());
            selectListBox(ddlDateEndMonth, DateTime.Now.Month.ToString());            
            selectListBox(ddlDateEndDay, DateTime.Now.Day.ToString());                        
                        
        
        }
		
        protected void setDefaultTime
		(
			  int startHour
			, int startMinute
			, int endHour
			, int endMinute
		)
        {
			
			int startHourAdjusted =0;
			int endHourAdjusted =0;
			String strHourAMPM;
			
			
			if (startHour >= 12)
			{
				strHourAMPM = "PM";
				startHourAdjusted = startHour - 12;
			}
			else
			{
				strHourAMPM = "AM";          
				startHourAdjusted = startHour;			
			}
            
            selectListBox(ddlTimeStartHour, startHourAdjusted);
            selectListBox(ddlTimeStartMinute, startMinute);            
            selectListBox(ddlTimeStartAMPM, strHourAMPM);
			
			if (endHour >= 12)
			{
				strHourAMPM = "PM";
				endHourAdjusted = endHour - 12;				
			}
			else
			{
				strHourAMPM = "AM";    
				endHourAdjusted = endHour;					
			}			
			
            selectListBox(ddlTimeEndHour, endHourAdjusted);
            selectListBox(ddlTimeEndMinute, endMinute);   
            selectListBox(ddlTimeEndAMPM, strHourAMPM);
			
        }	
		
		/*
			getTimeBlock
		*/
		private	static void getTimeBlock
		(
			  List<int>  arrTime
			, int 		 iCurrent
			, List<int>  arrTimeBlock
			, ref int 	 iPrevious
			, ref int 	 iNext
		) 
		{

			  // set variables value
			  iPrevious = 0;
			  iNext = 0;

			  //iterate through time array
			  foreach (int arrayContextValue in arrTime)
			  {

				//when array context value is greater than the current minute 
				//please exit loop
				if (arrayContextValue > iCurrent) 
				{

				  //save next value
				  iNext = arrayContextValue;

				  break;

				};

				// save current array context as previous value
				iPrevious = arrayContextValue;

			  };

			  //save values
			  arrTimeBlock.Add(iPrevious);
			  arrTimeBlock.Add(iNext);

		}

		public void setDefaultTime()
		{
			
			//Boolean bDebug = false;
			List<int> arrTimeMinute;
			//new List<int>{1,2,3,4,5};
			//List<int> arrTimeMinute = new List<int>(){0, 15, 30, 45};
			arrTimeMinute = new List<int>();
			
			for (int i=0; i<=45;)
			{
				arrTimeMinute.Add(i);
				i = i+15;
			}	
			
			List<int> arrTimeHour12;
									
			/*	
			
				arrTimeHour12 = new List<int>()
								{0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12};
			
			*/					
			
			arrTimeHour12 = new List<int>();
			for (int i=0; i<=12;i++)
			{
				arrTimeHour12.Add(i);
			}	
			

			List<int> arrTimeHour24;

			/*
				
				arrTimeHour24 = new List<int>()
									{
											0, 1, 2, 3
										  , 4, 5, 6, 7
										  , 8, 9, 10, 11
										  , 12, 13, 14, 15
										  , 16, 17, 18, 19
										  , 20, 21, 22, 23
									};
			*/
			
			arrTimeHour24 = new List<int>();
			
			for (int i=0; i<=23;i++)
			{
				arrTimeHour24.Add(i);
			}	

			//Declare array
			List<int> arrTimeBlock;

			arrTimeBlock = new List<int>();

			int timeBlockMinuteBegin = 0;
			int timeBlockMinuteEnd = 0;

			int timeBlockHourBegin = 0;
			int timeBlockHourEnd = 0;

			//get current date and time
			DateTime objTS = DateTime.Now;

			//get current minute
			int iMinuteCurrent = objTS.Minute;

			//get current hour
			int iHourCurrent = objTS.Hour;
			
			//call time function
			//arrTimeBlock.length = 0;
			arrTimeBlock.Clear();
			
			getTimeBlock
			(
				  arrTimeMinute
				, iMinuteCurrent
				, arrTimeBlock
				, ref timeBlockMinuteBegin
				, ref timeBlockMinuteEnd
			);
			
			/*
			
				//save function result
				int timeBlockMinuteBegin = arrTimeBlock[0];
				int timeBlockMinuteEnd = arrTimeBlock[1];
				
			*/
						
			/*
				If tipped over to next hour or day, then get next hour
			*/
			if (timeBlockMinuteEnd < timeBlockMinuteBegin)
			{
				
				//call time function
				arrTimeBlock.Clear();

				getTimeBlock
				(
					  arrTimeHour24
					, iHourCurrent
					, arrTimeBlock
					, ref timeBlockHourBegin
					, ref timeBlockHourEnd
				);
				
				/*
				
					//save function result
					int timeBlockHourBegin = arrTimeBlock[0];
					int timeBlockHourEnd = arrTimeBlock[1];
				
				*/
				
			}
			/*
				stay on current hour
			*/
			else
			{
			  timeBlockHourBegin = iHourCurrent;
			  timeBlockHourEnd = iHourCurrent;			  
			}	
				

			setDefaultTime
			(
				  timeBlockHourBegin
				, timeBlockMinuteBegin
				, timeBlockHourEnd
				, timeBlockMinuteEnd
			);
			
			
		}
		


       private void getStateData()
       {
       	
       		 sessionVars objSessionVars = null;
       		 
       		 objSessionVars = new remindME.stateManagement.sessionVars();
       		 
       		 	objSessionVars.Session = Session;
       		 
       		 	strContactID = objSessionVars.contactID;
       		 	strContactName = objSessionVars.contactName;       		 
       		 
       		 objSessionVars = null;
       	
       }                                  
        
        protected void initPage(Object Sender, EventArgs evt)
        {
        
            Boolean bFound = false;
            
            readConfigurationSettings();       
       
			objConnection = new OleDbConnection(strDBConnection);
			
			objDBCommand = new OleDbCommand();
			
			objDBCommand.Connection = objConnection;
			        
            objConnection.Open();

            getUserInfo();            
            
            getPassedInParameters();
                
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

                    reflectState();
                                                                                                        
                    //if we are adding data
                    if (strContactEventID == null)
                    {
                        setDefaultStartDates();
						
						setDefaultTime();
						
                    }
                    else
                    {
                        
                        if (bFound)
                        {
                        

                        }                        
                        
                    }
                    
            } //isPostBack

            
            if (IsPostBack == false)
            {            

                if (strContactEventID != null)
                {
                    getBody();            
                }                    
                else
                {
                    prepareBodyForNewInsert();
                }                            
                
                savePassedInData();
                                
            }    
            
            //labelContactID.Text = strContactID;
                                
            labelContactName.Text = strContactName;            
            
        }                        
        
        
       private void getBody()
       {
       
            getContactEventInfo();
            
            reflectSameDay();
            
            reflectAllDayEvent();
            
       }

        
       private void getContactEventInfo()
       {
       
       
            OleDbDataReader objDBReader = null;
            String          strActive = null;
            Boolean         bActive = false;
            
            String          strCommunicationType = null;
            int             iCommunicationType = -1;
            
            String          strSQLQuery = null;
            
            String          strHour;
            int             iHour;
            String          strHourAMPM;
            
            String          strDaysApart;
            int             iDaysApart;
            
            String          strAllDayEvent;
            int             iAllDayEvent;
                
            String          strStatusCode;
            int             iStatusCode;                
                							
			strSQLQuery = "[dbo].[usp_getContactEventRecord]";
		
			//labelSQL.Text = strCommunicationType;
            //labelDebug.Text = "Contact Communication ID is " + strContactEventID;			
			
            objDBCommand.CommandText = strSQLQuery;
            
            objDBCommand.CommandType = CommandType.StoredProcedure;                        
            
            objDBCommand.Parameters.Clear();
                
            OleDbParameter objDBParameterEventID = new OleDbParameter();
            objDBParameterEventID.OleDbType = OleDbType.VarChar;
            objDBParameterEventID.Size = 255;
            objDBParameterEventID.Value = strContactEventID;
            objDBCommand.Parameters.Add(objDBParameterEventID);
			
            objDBReader = objDBCommand.ExecuteReader();			
            
            while (objDBReader.Read())
            {
                                
                editEventName.Text = objDBReader["eventName"].ToString();
				editEventLink.Text = objDBReader["eventLink"].ToString();				
                editEventComment.Text = objDBReader["eventComment"].ToString();
                
                selectListBox(ddlDateStartYear, 
                              objDBReader["startDateYear"].ToString());                
                selectListBox(ddlDateStartMonth, 
                              objDBReader["startDateMonth"].ToString());                
                selectListBox(ddlDateStartDay, 
                              objDBReader["startDateDay"].ToString());                
                              
                strHour = objDBReader["startDateHour"].ToString();
                iHour = Int32.Parse(strHour);
                
                if (iHour >= 12)
                {
                    iHour = iHour - 12;
                    strHourAMPM = "PM";
                }
                else
                {
                    strHourAMPM = "AM";                
                }
                                
                strHour = iHour + "";
                                              
                selectListBox(ddlTimeStartHour, 
                              strHour);                                              
                selectListBox(ddlTimeStartMinute, 
                              objDBReader["startDateMinute"].ToString());                                              
                selectListBox(ddlTimeStartAMPM, strHourAMPM);                                              
                                                            
                selectListBox(ddlDateEndYear, 
                              objDBReader["endDateYear"].ToString());                
                selectListBox(ddlDateEndMonth, 
                              objDBReader["endDateMonth"].ToString());                
                selectListBox(ddlDateEndDay, 
                              objDBReader["endDateDay"].ToString());                
                              
                strHour = objDBReader["endDateHour"].ToString();
                iHour = Int32.Parse(strHour);
                
                if (iHour >= 12)
                {
                    iHour = iHour - 12;
                    strHourAMPM = "PM";
                }
                else
                {
                    strHourAMPM = "AM";                
                }
                
                strHour = iHour + "";
                                              
                selectListBox(ddlTimeEndHour, 
                              strHour);                                              
                                                            
                selectListBox(ddlTimeEndMinute, 
                              objDBReader["endDateMinute"].ToString());                                                                                                          
                selectListBox(ddlTimeEndAMPM, strHourAMPM);   
                
                strDaysApart = objDBReader["daysApart"].ToString();
                iDaysApart = Int32.Parse(strDaysApart);                                                                                         
                
                if (iDaysApart == 0)
                {
                    chkSameDayEvent.Checked = true;
                }
                else
                {
                    chkSameDayEvent.Checked = false;                
                }
			    
                strAllDayEvent = objDBReader["allDayEvent"].ToString();
                iAllDayEvent = Int32.Parse(strAllDayEvent);                                                                                         
                
                if (iAllDayEvent == 1)
                {
                    chkAllDayEvent.Checked = true;
                }
                else
                {
                    chkAllDayEvent.Checked = false;                
                }
                
                
                strStatusCode = objDBReader["statusCode"].ToString();
                iStatusCode = Int32.Parse(strStatusCode);                                                                                         
                
                if (iStatusCode == 2)
                {
                    radioButtonEventStatus.SelectedIndex = 1;
                }
                else if (iStatusCode == 3)
                {
                    radioButtonEventStatus.SelectedIndex = 2;                
                }    
                else
                {
                    radioButtonEventStatus.SelectedIndex = 0;                                
                }            			    
                                            
            }
            
            objDBReader.Close();
            
            objDBReader = null;
	
       
       }                                                

       private void savePassedInData()
       {
       
            //Review passed in parameters
            hiddenContactEventID.Value = strContactEventID;
            
            //save URL
            if (Request.UrlReferrer != null)
            {
                hiddenURLReferer.Value = Request.UrlReferrer.ToString();   
            }                
       
       }                                     
       
       
       private void prepareBodyForNewInsert()
       {
       
            radioButtonEventStatus.SelectedIndex = 0;
            
            chkSameDayEvent.Checked = true;

            //reflect same day event            
            reflectSameDay();

       }
       
       protected void Page_UnLoad(Object Sender, EventArgs evt)
       {
            
			objDBCommand = null;
			       
            objConnection.Close();       
			objConnection = null;
        
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
        
        
            int iNumberofDays = 31;
            int iIndex;
            String strMonth;
            
            ddlDay.Items.Clear();
            
            
            for (iIndex = 1; iIndex <= iNumberofDays; iIndex++)
            {
                strMonth = iIndex + "";
                ddlDay.Items.Add(new ListItem(strMonth, strMonth));            
            }
        
        }

        
        protected void populateComboBoxYear(DropDownList ddlYear)
        {
        
            int iNumberofYears = 15;
            int iNumberofYearstoGoBack = 7;            
            int iIndex;
            String strYear;
            int iYear;
            int iYearEnd;
            
            DateTime objNow;
            
            objNow = DateTime.Now;
            
            //iYear = objNow.Year - iNumberofYearstoGoBack;
            iYear = 1960;
            iYearEnd = objNow.Year + 5;
            
            ddlYear.Items.Clear();
            
            for (iIndex = iYear; iIndex < iYearEnd; iIndex++)
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
           
            ddlDropDownList.Items.Add(new ListItem("00", "00"));                        
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
            
            reflectAllDayEvent();
        
        }
        
        protected void reflectAllDayEvent()
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


        protected void buttonSameDayEventClicked(Object Sender, EventArgs E)
        {
            reflectSameDay();
        }
  
        
        protected void reflectSameDay()
        {
            Boolean bChecked;
            Boolean bSetting;   
            String strMessage = "";         
            
            bChecked = chkSameDayEvent.Checked;
            bSetting = (bChecked == false);
            

            
            ddlDateEndMonth.Enabled = true;
            ddlDateEndDay.Enabled = true;
            ddlDateEndYear.Enabled = true;                        
            
            if (bChecked)
            {
            
                if (ddlDateStartYear.SelectedItem != null)
                {
                    selectListBox(ddlDateEndYear, 
                                  ddlDateStartYear.SelectedItem.Value);
                                  
                    
                }
                            
                if (ddlDateStartMonth.SelectedItem != null)
                {
                    selectListBox(ddlDateEndMonth, 
                                  ddlDateStartMonth.SelectedItem.Value);
                                                      
                }
                
                if (ddlDateStartDay.SelectedItem != null)
                {
                    selectListBox(ddlDateEndDay, 
                                  ddlDateStartDay.SelectedItem.Value);
                                                      
                }                
                
                ddlDateEndMonth.Enabled = bSetting;
                ddlDateEndDay.Enabled = bSetting;
                ddlDateEndYear.Enabled = bSetting;                
                
                                                    
            }
            
            
        }
        

        protected Boolean DBSave()
        {
        
            Boolean bInserting = false;
            Boolean bUpdated = false;
                        
            if (hiddenContactEventID.Value == null)
            {
                bInserting = true;            
            }
            else
            {
                if (hiddenContactEventID.Value.Length == 0)
                {
                    bInserting = true;                            
                }
                else
                {
                    bInserting = false;            
                }                    
            }                        
            
            bUpdated = DBUpdate(bInserting);        
            
            return (bUpdated);
            
        }            


        
        protected Boolean DBUpdate(Boolean bAdding )
        {
        
            String strSQL = null;
            Boolean bUpdated = false;
            Boolean bInserting = false;
            String strProcess = "";
            Boolean bValidData = false;

            
            int iUpdatedRecs = -1;
            
            String strHour = "";
            
            OleDbParameter objDBParameterEventID = null;
                
            if (bAdding)
            {                            
                strSQL = "[dbo].usp_ContactEventInsert";
            }
            else                
            {                            
                strSQL = "[dbo].usp_ContactEventUpdate";                
            }
                                                                            
            
            //labelMessage.Text = strSQL + hiddenQuoteId.Value + "[" + hiddenQuoteId.Value.Length + "]";
            
            strEventName = editEventName.Text;             
            strEventComment = editEventComment.Text; 
			strEventLink = editEventLink.Text; 
						
            //all day event
            if (chkAllDayEvent.Checked == true)
            {
                iAllDayEvent = 1;
            }   
            else                        
            {
                iAllDayEvent = 0;            
            }              
            
            
            //same day event
            if (chkSameDayEvent.Checked == true)
            {
                iSameDayEvent = 1;
            }   
            else                        
            {
                iSameDayEvent = 0;            
            }                          
            
            
            labelMessage.Text = strSQL + 
                                " " + 
                                "Same day is [" + iSameDayEvent + "]";
                        
            //if not an all day event, then get time
            if (iAllDayEvent == 0)
            {        
                
                strHour = ddlTimeStartHour.SelectedItem.Value;            
                
                if ( (ddlTimeStartAMPM.SelectedItem.Text == "PM") &&
                     (strHour != "12"))
                {
                    strHour = (Int32.Parse(strHour) + 12).ToString();
                }    

            }
            

            strEventStartDate = ddlDateStartMonth.SelectedItem.Value + '/' + 
                                ddlDateStartDay.SelectedItem.Value + '/' + 
                                ddlDateStartYear.SelectedItem.Value;
                                
            strBaseEventStartDate = strEventStartDate;                                

            //if not an all day event, then take time into consideration
            if (iAllDayEvent == 0)
            {                                        
                strEventStartDate = strEventStartDate + ' ' + 
                                    strHour + ":" + 
                                    ddlTimeStartMinute.SelectedItem.Value;
                                    
            }                                    
                     
                     
            //if not an all day event, then get time
            if (iAllDayEvent == 0)
            {                                        
                strHour = ddlTimeEndHour.SelectedItem.Value;            
                
                
                if ( (ddlTimeEndAMPM.SelectedItem.Text == "PM") &&
                     (strHour != "12"))           
                {
                    strHour = (Int32.Parse(strHour) + 12).ToString();
                }                                    
                
            }
            
            //if same day event == 1, then end date is same as start date
            //else get start date
            if (iSameDayEvent == 1)
            {                                
                strEventEndDate = strBaseEventStartDate; 
            }                                              
            else
            {                                
                strEventEndDate = ddlDateEndMonth.SelectedItem.Value + '/' + 
                                  ddlDateEndDay.SelectedItem.Value + '/' + 
                                  ddlDateEndYear.SelectedItem.Value;
            }                                  
            
                              
            strBaseEventEndDate = strEventEndDate;                                
                                          
            //if not an all day event, then take time into consideration
            if (iAllDayEvent == 0)
            {                                        

                strEventEndDate = strEventEndDate + ' ' + 
                              strHour + ":" + 
                              ddlTimeEndMinute.SelectedItem.Value;
                                    
            }   
            else
            {                                        

                strEventEndDate = strEventEndDate + " 23:59";
                                    
            }                                                                              

            
            if (radioButtonEventStatus.SelectedItem == null)
            {
                iEventStatusCode = 0;            
            }
            else
            {
                strEventStatusCode = radioButtonEventStatus.SelectedItem.Value;
                
                iEventStatusCode = Int32.Parse(strEventStatusCode); 
                
            }                
            
            labelMessage.Text = "Event Name is " +  strEventName + "<BR>" +
                                "Event Comment is " +  strEventComment + "<BR>" +
                                "Start Date is " + strEventStartDate + "<BR>" +
                                "End Date is " + strEventEndDate + "<BR>" +
                                "All Day Event is " + iAllDayEvent + "<BR>" +                                
                                "Same day is [" + iSameDayEvent + "]" + "<BR>" +                                
                                "Status is " + iEventStatusCode + "<BR>" +
                                "Process is " + strProcess + "<BR>";                                
                                
            bValidData = validateData();                                
            
            if (bValidData == false)
            {
                labelMessage.Text = strValidationErrMessage;
                labelMessage.Visible = true;
                return false;
            }
                              
            objDBCommand.CommandText = strSQL;
            objDBCommand.CommandType = CommandType.StoredProcedure;                        

                        
            OleDbParameter objDBParameterContactMemberID = new OleDbParameter();
            objDBParameterContactMemberID.OleDbType = OleDbType.VarChar;
            objDBParameterContactMemberID.Size = 88;
            objDBParameterContactMemberID.Value = strMemberID;
            objDBCommand.Parameters.Add(objDBParameterContactMemberID);
          
            
			OleDbParameter objDBParameterContactID = new OleDbParameter();
			objDBParameterContactID.OleDbType = OleDbType.VarChar;
			objDBParameterContactID.Size = 88;
			objDBParameterContactID.Value = strContactID;
			objDBCommand.Parameters.Add(objDBParameterContactID);

			objDBParameterEventID = new OleDbParameter();
			objDBParameterEventID.OleDbType = OleDbType.VarChar;
			if (hiddenContactEventID.Value == null)
			{
				
				objDBParameterEventID.Value = DBNull.Value;
				objDBParameterEventID.Direction = ParameterDirection.Output;                        				
				
			}
			else
			{
				objDBParameterEventID.Value = hiddenContactEventID.Value;
				
			}		
			objDBParameterEventID.Size = 255;            

			objDBCommand.Parameters.Add(objDBParameterEventID);                                        

			
                
            OleDbParameter objDBParameterContactAddress1 = new OleDbParameter();
            objDBParameterContactAddress1.OleDbType = OleDbType.VarChar;
            objDBParameterContactAddress1.Size = 255;
            objDBParameterContactAddress1.Value = strEventName;
            objDBCommand.Parameters.Add(objDBParameterContactAddress1);
            
            OleDbParameter objDBParameterContactAddress2 = new OleDbParameter();
            objDBParameterContactAddress2.OleDbType = OleDbType.VarChar;
            objDBParameterContactAddress2.Size = 1000;
            objDBParameterContactAddress2.Value = strEventComment;
            objDBCommand.Parameters.Add(objDBParameterContactAddress2);            
            
            OleDbParameter objDBParameterContactCity = new OleDbParameter();
            objDBParameterContactCity.OleDbType = OleDbType.VarChar;
            objDBParameterContactCity.Size = 255;
            objDBParameterContactCity.Value = strEventStartDate;
            objDBCommand.Parameters.Add(objDBParameterContactCity);            
            
            OleDbParameter objDBParameterContactState = new OleDbParameter();
            objDBParameterContactState.OleDbType = OleDbType.VarChar;
            objDBParameterContactState.Size = 255;
            objDBParameterContactState.Value = strEventEndDate;
            objDBCommand.Parameters.Add(objDBParameterContactState);                        
            
            OleDbParameter objDBParameterContactPostalCode = new OleDbParameter();
            objDBParameterContactPostalCode.OleDbType = OleDbType.Integer;
            objDBParameterContactPostalCode.Value = iAllDayEvent;
            objDBCommand.Parameters.Add(objDBParameterContactPostalCode);                                    
            
            OleDbParameter objDBParameterContactCountry = new OleDbParameter();
            objDBParameterContactCountry.OleDbType = OleDbType.Integer;
            objDBParameterContactCountry.Value = iEventStatusCode;
            objDBCommand.Parameters.Add(objDBParameterContactCountry);                                                
            OleDbParameter objDBParameterEventLink = new OleDbParameter();
            objDBParameterEventLink.OleDbType = OleDbType.VarChar;
            objDBParameterEventLink.Size = 600;
			
			if (strEventLink == String.Empty)
			{
				objDBParameterEventLink.Value = DBNull.Value;
			}							
			else	
			{
				objDBParameterEventLink.Value = strEventLink;
			}		
				
            objDBCommand.Parameters.Add(objDBParameterEventLink);            

                        
                                                
            iUpdatedRecs = objDBCommand.ExecuteNonQuery();
            
            if (bAdding)
            {
                if (iUpdatedRecs == 1)
                {
                    strContactEventID = objDBParameterEventID.Value.ToString(); 
                    
                    labelMessage.Text = "Address ID is " +  strContactEventID;
                    
                }
            }            
                


                
            bUpdated = true;
                
            return bUpdated;        
            
        }                        
        	
        	
        protected Boolean DBDelete()
        {
        
            String strSQL = null;
            Boolean bUpdated = false;
            Boolean bInserting = false;
            String strProcess = "";
            Boolean bValidData = false;

            
            int iUpdatedRecs = -1;
            
            String strHour = "";
            
            OleDbParameter objDBParameterEventID = null;
         
            //strSQL = "sp_ContactEventDelete";
			//SP name changed from usp_ContactEventDelete
            //strSQLBuilder.Append("usp_ContactEventDelete");                                        
            strSQL = "[dbo].[usp_ContactEventDelete]";			
            
            //labelMessage.Text = strSQL + hiddenQuoteId.Value + "[" + hiddenQuoteId.Value.Length + "]";
            
            labelMessage.Text = strSQL;
            
            labelMessage.Text = "Event Name is " +  strEventName + "<BR>";                          
                              
            objDBCommand.CommandText = strSQL;
            objDBCommand.CommandType = CommandType.StoredProcedure;                        

                        
            OleDbParameter objDBParameterContactMemberID = new OleDbParameter();
            objDBParameterContactMemberID.OleDbType = OleDbType.VarChar;
            objDBParameterContactMemberID.Size = 88;
            objDBParameterContactMemberID.Value = strMemberID;
            objDBCommand.Parameters.Add(objDBParameterContactMemberID);
            
            OleDbParameter objDBParameterContactAddressID = new OleDbParameter();
            objDBParameterContactAddressID.OleDbType = OleDbType.VarChar;
            objDBParameterContactAddressID.Size = 88;
            objDBParameterContactAddressID.Value = strContactEventID;
            objDBCommand.Parameters.Add(objDBParameterContactAddressID);
                                                
            iUpdatedRecs = objDBCommand.ExecuteNonQuery();
                
            bUpdated = true;
                
            return bUpdated;        
            
        }                        
                	
                		
        protected void buttonSaveAndMoreClicked(Object Sender, EventArgs E)
        {
        
            Boolean bUpdated = false;
            
            bUpdated = DBSave();

            //editQuote.Text = "";
            //editAuthored.Text = "";
            //editURL.Text = "";                                        
            

        }		



        protected void buttonSaveClicked(Object Sender, EventArgs E)
        {
                    
            Boolean bUpdated = false;
            String strRedirectURL = null;
            
            bUpdated = DBSave();
            
            if (bUpdated == false)
            {
                return;
            }
            
            redirect();
            

        }		
        
        
        protected void buttonDeleteClicked(Object Sender, EventArgs E)
        {
                    
            Boolean bDeleted = false;
            
            bDeleted = DBDelete();
            
            if (bDeleted)
            {
                redirect();
            }                
            

        }		        


        protected void buttonCloseClicked(Object Sender, EventArgs E)
        {
                    
            redirect();

        }		        
        
        protected void redirect()
        {
                    
            String strRedirectURL = null;
            if (hiddenURLReferer.Value != null)
            {
                strRedirectURL = hiddenURLReferer.Value;
            }
            else
            {
                strRedirectURL = "ContactBrowse.aspx?ContactID=" + strContactID;                        
            }
                
            Response.Redirect(strRedirectURL);        
        
        }
    
          
        protected void getPassedInParameters()
        {
        
            
            strContactEventID = Request[PARAMETER_EVENT_ID];
            
            //Retrieve Cookie Data
            //strContactID = Request[strCookieContactID];
            
            getStateData();
                   
            
            if (IsPostBack)
            {
            
            
            }
            else
            {

            }
            
        
        
        }
        

        
        protected void reflectState()
        {
        
            
            if (strContactEventID == null)
            {
                bEventExists = false;
            }
            else
            {
                bEventExists = true;
            }        
            
            buttonDelete.Visible = bEventExists;
            buttonAddMore.Visible = (bEventExists == false);
            
            //no need for add more
            buttonAddMore.Visible = false;
            
        }
        
        protected Boolean getCurrentDataFromDB()
        {
        
            Boolean bFound = false;
                        
            return bFound;
            
        
        
        }        
        
        protected void selectListBox
		(
			  DropDownList objListControl
			, int          iChoice
		)
        {
			selectListBox(objListControl, iChoice.ToString());
        
	    }
		
        protected void selectListBox(DropDownList objListControl, String strChoice)
        {
        
            int iIndex = 0;
            int iNumberofEntries =0;
            String strItem = null;
            ListItem objListItem = null;
            
            iNumberofEntries = objListControl.Items.Count;
            
            for (iIndex = 0; iIndex < iNumberofEntries; iIndex++)
            {
                objListItem = objListControl.Items[iIndex];
                
                objListItem.Selected = false;                    
                    
            }                            
            
            for (iIndex = 0; iIndex < iNumberofEntries; iIndex++)
            {
                objListItem = objListControl.Items[iIndex];
                
                strItem = objListItem.Value;
                
                if (strItem == strChoice)
                {
                
                    objListItem.Selected = true;                    
                   
                    break;
                    
                }
                
            }
            
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
            
            
        }                    
        
        
        private Boolean validateData()
        {
        
            Boolean bValid = true;
            
            strValidationErrMessage = "";
            
            bValid = validateDates(); 
            
            return bValid;
        
        }
        
        
        private Boolean validateDates()
        {
        
            DateTime dtDateStart = new DateTime();
            DateTime dtDateEnd = new DateTime();
            Boolean bValid = true;
            int iNumberofValidatedDates = 0;
            Boolean bDateParsingException = false;
            

            try
            {
            
                dtDateStart = DateTime.Parse(strBaseEventStartDate);
                iNumberofValidatedDates = iNumberofValidatedDates + 1;
                
                dtDateEnd = DateTime.Parse(strBaseEventEndDate);
                iNumberofValidatedDates = iNumberofValidatedDates + 1;                
                
                if (dtDateStart > dtDateEnd)
                {
                    strValidationErrMessage = strValidationErrMessage +
                                              "Date is inaccurate.  " +
                                              "Start date (" + strBaseEventStartDate + ") " +
                                              " can not be after " +
                                              "end date (" + strBaseEventEndDate + ")";
                                              
                    bValid = false;                                              
                }                            

            
            }
            catch (Exception ex)
            {
            
                bDateParsingException = true;
            
            }
            
            if (bDateParsingException)
            {
 
                if (iNumberofValidatedDates == 1)
                {
                
                    strValidationErrMessage = strValidationErrMessage +
                                              "Date is inaccurate.  " +
                                              "Start date (" + strBaseEventStartDate + ") " +
                                              " is not a valid date";
                
                
                }           
                else if (iNumberofValidatedDates == 2)
                {
                
                    strValidationErrMessage = strValidationErrMessage +
                                              "Date is inaccurate.  " +
                                              "End date (" + strBaseEventEndDate + ") " +
                                              " is not a valid date";
                
                
                }                                                         
                else
                {
                    strValidationErrMessage = strValidationErrMessage +
                                              "Error validating dates.  " +
                                              "Start date (" + strBaseEventStartDate + ") " +                                              
                                              "End date (" + strBaseEventEndDate + ") ";
                }                                              
                
                bValid = false;                                                          
            
            }
        

            return bValid;
        
        }        

                            
					
    }


}