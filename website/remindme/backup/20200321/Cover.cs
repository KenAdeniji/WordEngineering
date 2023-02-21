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
    

    public class frmCover : System.Web.UI.Page
    {
       
       
       private String strContact = null;
       
       private String strDBConnection = null;
                                        
       private OleDbConnection objConnection = null;
       private OleDbDataAdapter objDbAdapter = null;			                                        
	   private String strSQLQuery;
	   
	   protected DataGrid gridContact;	 
	   
	   protected Label labelInfo;
	   protected Label labelOrderBy;	   
	   protected Label labelSQL;         
	   
	   protected Label labelMemberName;
	   protected Label labelSortInformation;
	   
       protected String strMemberID;	   
       protected String strMemberName;
       
       protected TextBox txtContactSearchTag;
       
	   protected ImageButton idAnchorContactSearch;
	   
	   private string currentSortColumn = null;
	   private string currentSortDirection = null;
	   
       
        //read configuration settings                                                                         
        protected void readConfigurationSettings()
        {
            strDBConnection = ConfigurationSettings.AppSettings["oleDBConnection.ConnectionString"];
        }       
       

       protected void Page_Load(Object Sender, EventArgs evt)
       {
    
            try
            {   
                
                readConfigurationSettings();
           
        	    objConnection = new OleDbConnection(strDBConnection);
            
                objConnection.Open();
                
                getUserInfo();
                
                setReportSessionVars();
                
            }
            catch (Exception ex)
            {
                
                labelInfo.Text = "Exception occurred in cover.aspx " + ex.Message + "<BR>"
                                 + "Database Connection Info is " + strDBConnection;
                                 
                labelInfo.Visible = true;    
                
            }
                            
            
            //loadNamesGrid(null);                      
            
       }                                               
        
        
       protected void Page_UnLoad(Object Sender, EventArgs evt)
       {
       
            objConnection.Close();       
			objConnection = null;
        
       }                                                       


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
               strQueryTag = "%" +  txtContactSearchTag.Text + "%";            
               strQueryTagRevised = txtContactSearchTag.Text;
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
        
          strContactFilter = " contact  like '" +  strQueryTag + "'";          
          
          labelSQL.Text = "Query Filter is " + strContactFilter;          
		  
          loadNamesGrid(strQueryTagRevised, bFilterOnContactNameOnly);           
                        
       
       }   
       
       
       public void AnchorAllBtnClick(Object objSource, EventArgs objEvent)
       {                             
         
          loadNamesGrid(null, true);          
       
       }          
       

       
       
       private DataView getRecordSetNames
	   (
		  	  String strContactFilter
			, Boolean bCheckContactOnly
	   )
	   {
			
			int iCheckContactOnly = 0;
			
			if (bCheckContactOnly)
			{
				iCheckContactOnly = 1;
			}
			else
			{
				iCheckContactOnly = 0;
			}
			
			if ( (strMemberID == null) || (strMemberID == string.Empty))
			{
				return null;	
			}
			
            OleDbDataAdapter objDbAdapter = null;			                                        			
			DataSet objDataSet;
		    DataView objDataView;						            
			OleDbCommand objOleDBCommand;

			
			//labelSQL.Visible = false;			
			strSQLQuery = "dbo.usp_GetContactsForMember";
			labelSQL.Text = strSQLQuery;
            
			objOleDBCommand = new OleDbCommand();
			objOleDBCommand.Connection = objConnection;			
			objOleDBCommand.CommandType = CommandType.StoredProcedure;
			objOleDBCommand.CommandText = strSQLQuery;
			
            OleDbParameter objDBParametemItemMemberID = new OleDbParameter();
            objDBParametemItemMemberID.OleDbType = OleDbType.VarChar;
            objDBParametemItemMemberID.Size = 88;
            objDBParametemItemMemberID.Value = strMemberID;
            objOleDBCommand.Parameters.Add(objDBParametemItemMemberID);			
            
            OleDbParameter objDBParametemItemContactFilterParam = new OleDbParameter();
            objDBParametemItemContactFilterParam.OleDbType = OleDbType.VarChar;
            objDBParametemItemContactFilterParam.Size = 88;
            objDBParametemItemContactFilterParam.Value = strContactFilter;
            objOleDBCommand.Parameters.Add(objDBParametemItemContactFilterParam);			            

            OleDbParameter objDBParametemItemContactFilterOnContactNameOnly = new OleDbParameter();
            objDBParametemItemContactFilterOnContactNameOnly.OleDbType = OleDbType.Integer;
            objDBParametemItemContactFilterOnContactNameOnly.Value = iCheckContactOnly;
            objOleDBCommand.Parameters.Add(objDBParametemItemContactFilterOnContactNameOnly);			            
			
            objDbAdapter = new OleDbDataAdapter();            		            
            objDbAdapter.SelectCommand = objOleDBCommand;

            objDataSet = new DataSet("namedetails");
            
            objDbAdapter.Fill(objDataSet);						
			
			objDataView = objDataSet.Tables[0].DefaultView;
			
			objDataView.RowFilter = String.Empty;
			
			return objDataView;
						
		}              
       
       
	   private void loadNamesGrid(String strContactFilter, Boolean bCheckContactOnly)
	   {
		
			//ICollection objNames;
			DataView    objNames;
			System.Web.UI.WebControls.Unit iWidth;
			
			//get Names
			objNames = getRecordSetNames(strContactFilter, bCheckContactOnly);
			
			iWidth = gridContact.Width;
					
			//set data source
			gridContact.DataSource = objNames;
			
			//data Bind
			gridContact.DataBind();
			
			//https://msdn.microsoft.com/en-us/library/system.web.ui.webcontrols.gridview.sorting(v=vs.110).aspx
			//Persist the table in the Session object.
			Session["gridContact"] = objNames;
			
			ifSingleRowFoundDisplayRow(objNames);
			
	   }       


	   private void ifSingleRowFoundDisplayRow(DataView objGridContents)
	   {
	   	
		int         iNumberofMatches = -1;
                DataRowView objDataRowView = null;
                
                object      objHandleID = null;
                string      strHandleID = null;
                
                string      strURLPrefix = "ContactBrowse.aspx?ContactID=";
                string      strRedirectURL = null;
   	                    
	        //objDataView = objDataSet.Tables[0].DefaultView;   	        
	        
	        	if (objGridContents == null)
	        	{
	        		return;	
	        	}
	        	
	   	
                iNumberofMatches = objGridContents.Count;   
                
                //labelSQL.Text = "Number of matches " + iNumberofMatches;
                //labelSQL.Visible = true;                     
                
                if (iNumberofMatches == 1)
                {
                    
                    //get the first row
                    objDataRowView = objGridContents[0];

                    //If data row is view is valid
                    if (objDataRowView != null)
                    {
                        
                        objHandleID = objDataRowView[0];
                    
                        if (objHandleID != null)
                        {
                        
                            //get the Hardware id
                            strHandleID = objHandleID.ToString();
                                        
                            //format the redirect URL                                        
                            strRedirectURL = strURLPrefix + strHandleID;
                            
                            //Redirect
                            Response.Redirect(strRedirectURL);
                            
                        } //if (objHWID != null)
                        
                    } //if (objDataRowView != null)
                    
                } //if (iNumberofMatches == 1)
                
                
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
                 
                 
        protected void setReportSessionVars()
        {
        	
        	Boolean	bSessionVarSet = false;
        	
        	if (strMemberID != null)
        	{
	        	if (strMemberID.CompareTo(Session["@memberID"]) != 0)
	        	{
	        		Session["@memberID"] = strMemberID;
	        		bSessionVarSet = true;
				}
			}    
			    		

        }              


		/*
		
			asp.net gridview sorting custom datasource
				http://stackoverflow.com/questions/12538578/asp-net-gridview-sorting-custom-datasource
				
		*/
		
		private string getSortDirection(string column)
		{
			
			// By default, set the sort direction to ascending.
			string sortDirection = "ASC";

			// Retrieve the last column that was sorted.
			string sortExpression = ViewState["gridContactSortExpression"] as string;

			if (sortExpression != null)
			{
			  // Check if the same column is being sorted.
			  // Otherwise, the default value can be returned.
			  if (sortExpression == column)
			  {
				string lastDirection = ViewState["gridContactSortDirection"] as string;
				if ((lastDirection != null) && (lastDirection == "ASC"))
				{
				  sortDirection = "DESC";
				}
			  }
			  
			}
				

			// Save new values in ViewState.
			ViewState["gridContactSortDirection"] = sortDirection;
			ViewState["gridContactSortExpression"] = column;

			return sortDirection;

		}

		
	    protected void gridContactSortEvent(
		                                       Object sender
											 , DataGridSortCommandEventArgs e
										   )
	    { 

	
			DataView dv = (DataView)Session["gridContact"];
			
			String strSortColumn = e.SortExpression;
		 
			String strSortDir = getSortDirection(strSortColumn);
			
			String strSortColumnANDDir = strSortColumn + " " + strSortDir;
		 
			 // The DataView provides an easy way to sort. 
			 //Simply set the Sort property with
			 // the name of the field to sort by.
			 //dv.Sort = e.SortExpression;
			 dv.Sort = strSortColumnANDDir;

			 // Re-bind the data source and specify that it should be sorted
			 // by the field specified in the SortExpression property.
			 gridContact.DataSource = dv;
			 gridContact.DataBind();

 	    } // gridContactSortEvent

                                                   
    } // public class frmCover : System.Web.UI.Page


} //namespace