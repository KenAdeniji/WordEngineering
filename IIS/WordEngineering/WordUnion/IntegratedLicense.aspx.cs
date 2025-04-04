﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;

using System.Data.Odbc;

using System.Collections;
using System.Collections.ObjectModel;

using InformationInTransit.DataAccess;
using InformationInTransit.UserInterface;

/*
2014-04-23 File created.
2014-06-10 CaseBasedReasoning included.
*/
public partial class IntegratedLicense : System.Web.UI.Page
{
	protected Int32? ContactId
	{
		get
		{
			Int32 temp = -1;
			bool isNumber = Int32.TryParse( contactId.Text, out temp);
			if (isNumber)
			{
				return temp;
			}
			else
			{
				return null;
			}	
		}	
	}

	protected DateTime? DatedFrom
	{
		get
		{
			DateTime temp = new DateTime(1, 1, 1);
			bool isDate = DateTime.TryParse( datedFrom.Text, out temp);
			if (isDate)
			{
				return temp;
			}
			else
			{
				return null;
			}	
		}	
	}

	protected DateTime? DatedUntil
	{
		get
		{
			DateTime temp = new DateTime(9999, 12, 31);
			bool isDate = DateTime.TryParse( datedFrom.Text, out temp);
			if (isDate)
			{
				return temp;
			}
			else
			{
				return null;
			}	
		}	
	}
	
	protected String DropDownListSource
	{
		get
		{
			return dropDownListSource.SelectedItem.Value;
		}	
	}
	
	protected void GridViewSource_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable dataTable = (DataTable)ViewState["gridViewSource"];
        if (dataTable != null)
        {
            gridViewSource.DataSource = dataTable;
            gridViewSource.Sort(e);
        }
	}

	protected void Page_Load(object sender, EventArgs e)
    {
		if ( !Page.IsPostBack )
		{
			dropDownListSource.DataSource = SourceList;
			dropDownListSource.DataBind();
		}
	}
	
 	protected void Submit_Click(object sender, EventArgs e)
    {
		Collection<OdbcParameter> odbcParameterCollection = new Collection<OdbcParameter>();

		odbcParameterCollection.Add(new OdbcParameter("@source", DropDownListSource));
		odbcParameterCollection.Add(new OdbcParameter("@commentary", commentary.Text));
		odbcParameterCollection.Add(new OdbcParameter("@datedFrom", DatedFrom));
		odbcParameterCollection.Add(new OdbcParameter("@datedUntil", DatedUntil));		
		odbcParameterCollection.Add(new OdbcParameter("@contactId", ContactId));

		DataTable dataTable = (DataTable) DataCommand.DatabaseCommand
		(
			"WordEngineering..usp_IntegratedLicenseSelect",
			CommandType.StoredProcedure,
			DataCommand.ResultType.DataTable,
			odbcParameterCollection
		);
		
		ViewState["gridViewSource"] = dataTable;
		gridViewSource.DataSource = dataTable;
		gridViewSource.DataBind();
    }
	
	public static readonly string[] SourceList = { 
		"CaseBasedReasoning",
		//"Dream",
		"Remember"
	};	
}
