using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;

using System.Numerics;

using InformationInTransit.DataAccess;
using InformationInTransit.UserInterface;

namespace WordEngineering
{
	/// <summary>UriView</summary>
	public partial class UriView : Page
	{
		protected string TableName
		{
			get
			{
				string stub = DropDownListTableName.SelectedItem.Value;
				return stub;
			}
		}

		protected string Uri
		{
			get
			{
				string stub = TextBoxURI.Text.Trim();
				if (stub == "")
				{
					stub = null;
				}
				return stub;
			}
		}
		
		protected string Title
		{
			get
			{
				string stub = TextBoxTitle.Text.Trim();
				if (stub == "")
				{
					stub = null;
				}
				return stub;
			}
		}

		protected string Keyword
		{
			get
			{
				string stub = TextBoxKeyword.Text.Trim();
				if (stub == "")
				{
					stub = null;
				}
				return stub;
			}
		}

		protected DateTime? DatedFrom
		{
			get
			{
				string stub = TextBoxDatedFrom.Text.Trim();
				if (stub == "") 
				{
					return null;
				}	
				DateTime dateTime = DateTime.MinValue;
				bool isDate = DateTime.TryParse(stub, out dateTime);
				return dateTime;
			}
		}

		protected DateTime? DatedTo
		{
			get
			{
				string stub = TextBoxDatedTo.Text.Trim();
				if (stub == "") 
				{
					return null;
				}	
				DateTime dateTime = DateTime.MinValue;
				bool isDate = DateTime.TryParse(stub, out dateTime);
				return dateTime;
			}
		}

		protected BigInteger? SequenceOrderIdFrom
		{
			get
			{
				string stub = TextBoxSequenceOrderIdFrom.Text.Trim();
				if (stub == "") 
				{
					return null;
				}	
				BigInteger bigInteger = -1;
				bool isValid = BigInteger.TryParse(stub, out bigInteger);
				return bigInteger;
			}
		}

		protected BigInteger? SequenceOrderIdTo
		{
			get
			{
				string stub = TextBoxSequenceOrderIdTo.Text.Trim();
				if (stub == "") 
				{
					return null;
				}	
				BigInteger bigInteger = 2147483647;
				bool isValid = BigInteger.TryParse(stub, out bigInteger);
				return bigInteger;
			}
		}

		protected string FeedBack
		{
			set
			{
				feedBack.Text = value;
			}
		}

		protected void Submit_Click(object sender, EventArgs e)
		{
			List<SqlParameter> sqlParameterCollection = new List<SqlParameter>();

			sqlParameterCollection.Add(new SqlParameter("@tableName", TableName));
			sqlParameterCollection.Add(new SqlParameter("@Uri", Uri));
			sqlParameterCollection.Add(new SqlParameter("@Title", Title));
			sqlParameterCollection.Add(new SqlParameter("@keyword", Keyword));
			sqlParameterCollection.Add(new SqlParameter("@datedFrom", DatedFrom));
			sqlParameterCollection.Add(new SqlParameter("@datedTo", DatedTo));
			sqlParameterCollection.Add(new SqlParameter("@sequenceOrderIdFrom", SequenceOrderIdFrom));
			sqlParameterCollection.Add(new SqlParameter("@sequenceOrderIdTo", SequenceOrderIdTo));
			
			DataTable dataTable = (DataTable) Repository.DatabaseCommand
			(
				"Uri..uspURISelect",
				CommandType.StoredProcedure,
				Repository.ResultSet.DataTable,
				sqlParameterCollection
			);
			
			ViewState["UriGridView"] = dataTable;
			UriGridView.DataSource = dataTable;
			UriGridView.DataBind();
		}
		
	    protected void UriGridView_Paging(Object sender, GridViewPageEventArgs e)
		{
			DataTable dataTable = (DataTable)ViewState["UriGridView"];
			if (dataTable != null)
			{
				UriGridView.DataSource = dataTable;
				GridViewHelper.PageIndexChange(UriGridView, e);
			}
		}

	    protected void UriGridView_Sorting(Object sender, GridViewSortEventArgs e)
		{
			DataTable dataTable = (DataTable)ViewState["UriGridView"];
			if (dataTable != null)
			{
				UriGridView.DataSource = dataTable;
				GridViewHelper.Sort(UriGridView, e);
			}
		}
	}
}