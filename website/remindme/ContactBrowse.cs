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
    using remindME.stateManagement;   

    public class frmContactBrowse : System.Web.UI.Page
    {
       
       
       
       private String strContact = null;
       
       private String strDBConnection = null;
                                        
       private OleDbConnection objConnection = null;
       private OleDbCommand objDBCommand = null;       
       private OleDbDataAdapter objDbAdapter = null;			                                        

       
	   private String strSQLQuery;
	   
	   protected DataGrid gridContactCommunicationInfo;	 
	   protected DataGrid gridContactAddressInfo;	
	   protected DataGrid gridContactEventInfo; 
	   protected DataGrid gridContactAttachmentInfo; 
	   	   	   
	   protected Label labelContact;
       protected Label labelContactDOB;	   
	   protected Label labelContactProfession;
	   protected Label labelContactAffliate;	   	   
	   protected Label labelContactComment;
	   
	   protected Label labelSQL;         
	   
	   protected HyperLink idAnchorAddContactCommunication;
	   protected HtmlAnchor hyperLinkEditCustomer;
	   protected HtmlAnchor hyperLinkDeleteCustomer;
	   	   
	   protected HiddenField hfContactID;	   
	   protected TextBox txtContactMinorSearchTag;
	   
	
       protected String strMemberID  = null;	   
       protected String strMemberName  = null;	          
       protected String strContactID = null;
       protected String strContactName = null;
       
	   protected String strContactMinor = null;
	   
       private static String strCookieContactID = "ContactID";
       
       
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
           
            getBody();                     
            
       }                                               
        
        
       protected void Page_UnLoad(Object Sender, EventArgs evt)
       {
            
			objDBCommand = null;
			       
            objConnection.Close();       
			objConnection = null;
			

        
       }   
       
       private void saveStateDataOldStyle()
       {
       	
             System.Web.HttpCookie objCookie = null;
            			       	
             objCookie = new System.Web.HttpCookie(strCookieContactID); 
             objCookie.Value = strContactID;
             
             Response.Cookies.Add(objCookie);       	
       	
       }            
       
       private void saveStateData()
       {
       	
       		 sessionVars objSessionVars = null;
       		 
       		 objSessionVars = new remindME.stateManagement.sessionVars();
       		 
       		 	objSessionVars.Session = Session;
       		 
       		 	objSessionVars.contactID = strContactID;
       		 	objSessionVars.contactName = strContactName;       		 
       		 
       		 objSessionVars = null;
       	
       }                   
       
       private void getBody()
       {
       
            //System.Web.HttpCookie objCookie = null;
            
			if (IsPostBack == false)
			{
				
				//Review passed in parameters
				strContactID = Request.QueryString["ContactID"];
            
				if (strContactID != null)
				{
					hfContactID.Value = strContactID;
				}
			}
			else
			{
				strContactID = hfContactID.Value;
				
			}
			
			
			strContactMinor = txtContactMinorSearchTag.Text;
            
            //get Contact Info            
            getContactInfo();
            
            saveStateData();            
            
            loadGridContactCommunication();
            
            loadGridAddress();
            
            loadGridEvents();
            
            loadGridDocumentAttachments();
            
       }                                        


       private void getContactInfo()
       {
       
            OleDbDataReader objDBReader = null;
            
            String strHREF;
							
			strSQLQuery = "getContactInfo ?, ? ";
		
			labelSQL.Text = strSQLQuery;
			
            objDBCommand.CommandText = strSQLQuery;
                
            OleDbParameter objDBParameterMemberID = new OleDbParameter();
            objDBParameterMemberID.ParameterName = "@memberIdentifier";
            objDBParameterMemberID.OleDbType = OleDbType.VarChar;
            objDBParameterMemberID.Size = 255;
            objDBParameterMemberID.Value = strMemberID; 
            objDBCommand.Parameters.Add(objDBParameterMemberID);
            
            OleDbParameter objDBParameterMemberContactID = new OleDbParameter();
            objDBParameterMemberContactID.ParameterName = "@contactIdentifier";
            objDBParameterMemberContactID.OleDbType = OleDbType.VarChar;
            objDBParameterMemberContactID.Size = 255;
            objDBParameterMemberContactID.Value = strContactID; 
            objDBCommand.Parameters.Add(objDBParameterMemberContactID);            
                        
			
            objDBReader = objDBCommand.ExecuteReader();			
            
            while (objDBReader.Read())
            {
            	
				strContactName = objDBReader["Contact"].ToString();
                labelContact.Text = strContactName;
                
                labelContactDOB.Text = objDBReader["DOB"].ToString();                                
                labelContactAffliate.Text = objDBReader["Affliate"].ToString();
                labelContactProfession.Text = objDBReader["Profession"].ToString();
                labelContactComment.Text = objDBReader["Comment"].ToString();                
                                            
            }
            
            hyperLinkEditCustomer.HRef = "ContactEdit.aspx?mode=Edit";
            //hyperLinkDeleteCustomer.HRef = "ContactDelete.aspx";
            
            strHREF = "DBUpdate.aspx?DBItemType=ContactDelete"
						//+ "&DBItemEntryID=" + strContactID
						+ "&"
						+ strCookieContactID
						+ "=" 
						+ strContactID						
						;
						
            strHREF = strHREF + "&nextURL=Cover.aspx";
            
            hyperLinkDeleteCustomer.HRef = strHREF;
                                    
            objDBReader.Close();
            
            objDBReader = null;
	
       
       }                                        


       
       private DataView getRecordSetContactCommunication()
	   {
			

            OleDbDataAdapter objDbAdapter = null;			                                        			
			DataSet objDataSet = null;
		    DataView objDataView = null;	
			
			//strSQLQuery = "getContactCommunicationInfo";
			strSQLQuery = "dbo.usp_GetContactCommunicationInfo";		
			labelSQL.Text = strSQLQuery;

		    objDBCommand.Parameters.Clear();				            
		    			
            objDBCommand.CommandText = strSQLQuery;
            objDBCommand.CommandType = CommandType.StoredProcedure;            
                
            OleDbParameter objDBParameterMemberID = new OleDbParameter();
            objDBParameterMemberID.ParameterName = "@memberIdentifier";
            objDBParameterMemberID.OleDbType = OleDbType.VarChar;
            objDBParameterMemberID.Size = 255;
            objDBParameterMemberID.Value = strMemberID; 
            objDBCommand.Parameters.Add(objDBParameterMemberID);
            
            OleDbParameter objDBParameterMemberContactID = new OleDbParameter();
            objDBParameterMemberContactID.ParameterName = "@contactIdentifier";
            objDBParameterMemberContactID.OleDbType = OleDbType.VarChar;
            objDBParameterMemberContactID.Size = 255;
            objDBParameterMemberContactID.Value = strContactID; 
            objDBCommand.Parameters.Add(objDBParameterMemberContactID);            
			
            OleDbParameter objDBParameterMemberContactMinorID = new OleDbParameter();
            objDBParameterMemberContactMinorID.ParameterName = "@contactIdentifier";
            objDBParameterMemberContactMinorID.OleDbType = OleDbType.VarChar;
            objDBParameterMemberContactMinorID.Size = 255;
            objDBParameterMemberContactMinorID.Value = strContactMinor; 
            objDBCommand.Parameters.Add(objDBParameterMemberContactMinorID);  
			
            objDbAdapter = new OleDbDataAdapter();            


            objDbAdapter.SelectCommand = objDBCommand;

            objDataSet = new DataSet("namedetails");
            
            objDbAdapter.Fill(objDataSet);						
            
			
			objDataView = objDataSet.Tables[0].DefaultView;
			
			objDataView.RowFilter = String.Empty;
			
			
			return objDataView;
						
		}       
       
       
       
       
	   private void loadGridContactCommunication()
	   {
		
			ICollection objNames;
			
			//get Names
			objNames = getRecordSetContactCommunication();
					
			//set data source
			gridContactCommunicationInfo.DataSource = objNames;
			
			//data Bind
			gridContactCommunicationInfo.DataBind();
			
	   }       
	   
	   
       private DataView getAddresses()
	   {
			

            OleDbDataAdapter objDbAdapter = null;			                                        			
			DataSet objDataSet = null;
		    DataView objDataView = null;	
			
			strSQLQuery = "getContactAddressInfo";
		
			labelSQL.Text = strSQLQuery;

		    objDBCommand.Parameters.Clear();				            
		    			
            objDBCommand.CommandText = strSQLQuery;

            objDBCommand.CommandType = CommandType.StoredProcedure;            
                
            OleDbParameter objDBParameterMemberID = new OleDbParameter();
            objDBParameterMemberID.ParameterName = "@memberIdentifier";
            objDBParameterMemberID.OleDbType = OleDbType.VarChar;
            objDBParameterMemberID.Size = 255;
            objDBParameterMemberID.Value = strMemberID; 
            objDBCommand.Parameters.Add(objDBParameterMemberID);
            
            OleDbParameter objDBParameterMemberContactID = new OleDbParameter();
            objDBParameterMemberContactID.ParameterName = "@contactIdentifier";
            objDBParameterMemberContactID.OleDbType = OleDbType.VarChar;
            objDBParameterMemberContactID.Size = 255;
            objDBParameterMemberContactID.Value = strContactID; 
            objDBCommand.Parameters.Add(objDBParameterMemberContactID);            
			
	
            objDbAdapter = new OleDbDataAdapter();            


            objDbAdapter.SelectCommand = objDBCommand;

            objDataSet = new DataSet("namedetails");
            
            objDbAdapter.Fill(objDataSet);						
            
			
			objDataView = objDataSet.Tables[0].DefaultView;
			
			objDataView.RowFilter = String.Empty;
			
			
			return objDataView;
						
		}      
		
		
	   private void loadGridAddress()
	   {
		
			ICollection objNames;
			
			//get Names
			objNames = getAddresses();
					
			//set data source
			gridContactAddressInfo.DataSource = objNames;
			
			//data Bind
			gridContactAddressInfo.DataBind();
			
	   }       		 	   


       private DataView getEvents()
	   {
			

            OleDbDataAdapter objDbAdapter = null;			                                        			
			DataSet objDataSet = null;
		    DataView objDataView = null;	
			
			strSQLQuery = "dbo.usp_getContactEventInfo";
		
			labelSQL.Text = strSQLQuery;

		    objDBCommand.Parameters.Clear();				            
		    			
            objDBCommand.CommandText = strSQLQuery;

            objDBCommand.CommandType = CommandType.StoredProcedure;            
                
            OleDbParameter objDBParameterMemberID = new OleDbParameter();
            objDBParameterMemberID.ParameterName = "@memberIdentifier";
            objDBParameterMemberID.OleDbType = OleDbType.VarChar;
            objDBParameterMemberID.Size = 255;
            objDBParameterMemberID.Value = strMemberID; 
            objDBCommand.Parameters.Add(objDBParameterMemberID);
            
            OleDbParameter objDBParameterMemberContactID = new OleDbParameter();
            objDBParameterMemberContactID.ParameterName = "@contactIdentifier";
            objDBParameterMemberContactID.OleDbType = OleDbType.VarChar;
            objDBParameterMemberContactID.Size = 255;
            objDBParameterMemberContactID.Value = strContactID; 
            objDBCommand.Parameters.Add(objDBParameterMemberContactID);            
			
	
            objDbAdapter = new OleDbDataAdapter();            


            objDbAdapter.SelectCommand = objDBCommand;

            objDataSet = new DataSet("namedetails");
            
            objDbAdapter.Fill(objDataSet);						
            
			
			objDataView = objDataSet.Tables[0].DefaultView;
			
			objDataView.RowFilter = String.Empty;
			
			
			return objDataView;
						
		}      
		

	   private void loadGridEvents()
	   {
		
			ICollection objList;
			
			//get Names
			objList = getEvents();
					
			//set data source
			gridContactEventInfo.DataSource = objList;
			
			//data Bind
			gridContactEventInfo.DataBind();
			
	   }       		 	   


	   private void loadGridDocumentAttachments()
	   {
		
			ICollection objList;
			
			//get Names
			objList = getDocumentAttachments();
					
			//set data source
			gridContactAttachmentInfo.DataSource = objList;
			
			//data Bind
			gridContactAttachmentInfo.DataBind();
			
	   }    


       private DataView getDocumentAttachments()
	   {
			

            OleDbDataAdapter objDbAdapter = null;			                                        			
			DataSet objDataSet = null;
		    DataView objDataView = null;	
			
			strSQLQuery = "dbo.usp_getContactAttachments";
		
			labelSQL.Text = strSQLQuery;

		    objDBCommand.Parameters.Clear();				            
		    			
            objDBCommand.CommandText = strSQLQuery;

            objDBCommand.CommandType = CommandType.StoredProcedure;            
                
            OleDbParameter objDBParameterMemberID = new OleDbParameter();
            objDBParameterMemberID.ParameterName = "@memberIdentifier";
            objDBParameterMemberID.OleDbType = OleDbType.VarChar;
            objDBParameterMemberID.Size = 255;
            objDBParameterMemberID.Value = strMemberID; 
            objDBCommand.Parameters.Add(objDBParameterMemberID);
            
            OleDbParameter objDBParameterMemberContactID = new OleDbParameter();
            objDBParameterMemberContactID.ParameterName = "@contactIdentifier";
            objDBParameterMemberContactID.OleDbType = OleDbType.VarChar;
            objDBParameterMemberContactID.Size = 255;
            objDBParameterMemberContactID.Value = strContactID; 
            objDBCommand.Parameters.Add(objDBParameterMemberContactID);            
			
	
            objDbAdapter = new OleDbDataAdapter();            


            objDbAdapter.SelectCommand = objDBCommand;

            objDataSet = new DataSet("namedetails");
            
            objDbAdapter.Fill(objDataSet);						
            
			
			objDataView = objDataSet.Tables[0].DefaultView;
			
			objDataView.RowFilter = String.Empty;
			
			
			return objDataView;
						
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
        

        protected void DataGridItemCreated(object objSender,
                                           DataGridItemEventArgs objEvent)
        {
            
            DataGridItem objDataGridItem = null;
            System.Web.UI.WebControls.ListItemType iDataGridItemType;
            
            //get Data Grid Item
            objDataGridItem = objEvent.Item;    
            
            //get Data Grid Item Item
            iDataGridItemType = objDataGridItem.ItemType;
            
            if ( (iDataGridItemType == ListItemType.Item) ||
                 (iDataGridItemType == ListItemType.AlternatingItem))
            {
                
                WebControl objWebControl;
                
                objWebControl = (WebControl) objEvent.Item.Cells[8].Controls[0];
                
                objWebControl.Attributes.Add("onclick",
                                             "return confirm(\"Are you sure?\");");                     
            }
                             
                 
            
        } //DataGridItemCreated     



       public void AnchorBtnClick(Object objSource, EventArgs objEvent)
       {
		   
			AnchorBtnClickInternal(	objSource, objEvent);

	   }
	   
	   public void AnchorBtnClickInternal(Object objSource, EventArgs objEvent)
	   {
          HtmlAnchor objAnchor  = null;
          String     strContactFilter = null;
          
          string     strAnchorID = null;
          string     strAnchorInnerText = null;
          string     strAnchorName = null;          
          
          string     strQueryTag = null;
          string     strQueryFilter = null;
          string     strQueryTagRevised = null;          

		  Boolean 	 bFilterOnContactNameOnly = false;

    
		  if (objSource is HtmlAnchor)
		  {
		  
			  objAnchor = (HtmlAnchor) objSource;  
			  
			  /******************************************************************/
			  /*Get Anchor Tags                                                 */
			  /******************************************************************/          
			  strAnchorID = objAnchor.ID;
			  strAnchorInnerText = objAnchor.InnerText;
			  strAnchorName = objAnchor.Name;          
			  
			  bFilterOnContactNameOnly = true;
			  
		  }
		  else if (objSource is ImageButton)
		  {

			  ImageButton objAnchorHtml;
			  
			  objAnchorHtml = (ImageButton) objSource;  
			  
			  /******************************************************************/
			  /*Get Anchor Tags                                                 */
			  /******************************************************************/          
			  strAnchorID = objAnchorHtml.ID;
			  strAnchorInnerText = ""; //objAnchorHtml.InnerText;
			  strAnchorName = objAnchorHtml.ID; //objAnchorHtml.Name;          		  
			  
  			  bFilterOnContactNameOnly = false;

          }		  
		  
          
          if (strContact == "")
          {
            return;            
          }

/*          
          labelInfo.Text = "Anchor Inner text is " + objAnchor.InnerText + " | " + 
                           "Anchor Name is " + objAnchor.Name + " | " +
                           "Anchor ID is " + strAnchorID + " | ";
                                                      
*/
                           
          if ((strAnchorID != "") && (strAnchorName != ""))
          {
               strQueryTag = "%" +  txtContactMinorSearchTag.Text + "%";            
               strQueryTagRevised = txtContactMinorSearchTag.Text;
          }                             
          else  
          {
               strQueryTag = "" +  strAnchorInnerText + "%"; 
               strQueryTagRevised = strAnchorInnerText;                                        
          }                            

          labelSQL.Text = "Query Tag is " + strQueryTag;
          
          if (strQueryTag == null)
          {
            return;  
          }
        
          //strContactFilter = " contact  like '" +  strQueryTag + "'";          
          
          //labelSQL.Text = "Query Filter is " + strContactFilter;          
		  
          //loadNamesGrid(strQueryTagRevised, bFilterOnContactNameOnly);           
             
       }  //AnchorBtnClickInternal
	   
		
                  

    }


}