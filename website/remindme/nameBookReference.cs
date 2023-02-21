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

	public class nameBookReference : System.Web.UI.Page
	{
	
		protected DataGrid nameReferenceDataGrid;
		protected DataView objDataView;
		String strNameID;
		
        String strDBConnection = "Provider=SQLOLEDB.1;" + 
                                 "Server=guidance.ephraimtech.com;" + 
                                 "initial Catalog=nameBook;" +
                                 "Integrated Security=SSPI;";                                    		
                                 
        OleDbConnection objConnection = null;
        OleDbDataAdapter objDbAdapter = null;                                 
					
					
		private void getRecordSet()
		{
		
			//OleDBConnection objConnection;
            //OleDbDataAdapter objDbAdapter2 = null;
			DataSet objDataSet;			
			
			String strSQLQuery;
			String strSQLConnection;
			

			
			strNameID = Request.QueryString["nameID"];
							
			strSQLQuery = "select * from v_listofNameReferences  ";
			
			if (strNameID != null)
			{
				strSQLQuery = strSQLQuery + " where nameID = '" + strNameID + "' "; 
			}
			
			strSQLQuery = strSQLQuery + " order by sequence ";			
		                	   

/*

			objConnection = new ADOConnection(strDBConnection);
			
			objDSCommand = new ADODataSetCommand(strSQLQuery, objConnection);

			objDataSet = new DataSet();
			objDSCommand.FillDataSet(objDataSet, "names");
			
			objDataView = objDataSet.Tables["names"].DefaultView;
			
			objDataView.RowFilter = String.Empty;
			
			*/
			
            objConnection = new OleDbConnection(strDBConnection );
            
            objDbAdapter = new OleDbDataAdapter();            
            
            objDbAdapter.SelectCommand = new OleDbCommand(strSQLQuery, 
                                                          objConnection);
            

            objDataSet = new DataSet("NameRef");
            objDbAdapter.Fill(objDataSet);

            
            objDataView = objDataSet.Tables[0].DefaultView;
            
            objDataView.RowFilter = String.Empty;			
			
			
						
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
			nameReferenceDataGrid.DataSource = objNames;
			
			//data Bind
			nameReferenceDataGrid.DataBind();
			
		}
		

		
		protected void Page_Load(Object Sender, EventArgs evt)
		{
		

			
			if (IsPostBack == false)
			{
				loadNamesGrid();
			}
		
		}        		
		
		

	        // Handles the ItemCreated event to customize the footer
        	// to display summary information
        	protected void OnItemCreatedGrid(object sender,
        	                                 DataGridItemEventArgs e)
		{
		
            		if (e.Item.ItemType == ListItemType.Footer) 
            		{
            		
                		int cellCount = e.Item.Cells.Count;

                		for (int i = 0; i < cellCount - 1; i++) 
                		{
                    			e.Item.Cells.RemoveAt(0);
                		}

                		int itemCount = nameReferenceDataGrid.Items.Count;
                		string itemCountString;
                		TableCell summaryCell = e.Item.Cells[0];                		
                		
                		if (itemCount == 0) 
                		{
                    			itemCountString = "---No References Found---";
                			summaryCell.HorizontalAlign = HorizontalAlign.Center;                    			
                		}
                		else if (itemCount == 1) 
                		{
                    			itemCountString = " Single Reference";
                			summaryCell.HorizontalAlign = HorizontalAlign.Center;                    			
                		}
                		else 
                		{
                   			//itemCountString = Int32.ToString(itemCount) + " references(s)";
                   			itemCountString = itemCount + " references(s)";                   			
                			summaryCell.HorizontalAlign = HorizontalAlign.Right;                    			
                		}

                
                		summaryCell.Text = itemCountString;
                		summaryCell.ColumnSpan = cellCount;

                		
            		} //Footer
            		
        	} //OnItemCreatedGrid
		
		

	}     //class



} //nameSpace