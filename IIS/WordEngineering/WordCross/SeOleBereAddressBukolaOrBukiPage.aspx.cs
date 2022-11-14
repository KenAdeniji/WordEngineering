using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Windows.Forms;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;

using System.Configuration;

namespace WordEngineering
{
	/*
		2022-11-13T13:17:00	Created. 
	*/
	public partial class WordCross_SeOLeBereAddressBukolaOrBukiPage : System.Web.UI.Page
	{
		/// <summary>Page Load.</summary>
		public void Page_Load
		(
			object     sender, 
			EventArgs  e
		) 
		{
			if ( !Page.IsPostBack )
			{
				GridViewHisWord.Focus();
				Page.SetFocus( GridViewHisWord );
				GridViewHisWord.Attributes.Add("autocomplete", "on");
			}
		}

		/// <summary>Feedback.</summary>
		public String Feedback
		{
			get
			{
				return ( LiteralFeedback.Text);
			} 
			set
			{
				LiteralFeedback.Text = value;
			}
		}

		/// <summary>SearchQuery</summary>
		public String Query
		{
			get
			{
				return ( TextBoxQuery.Text);
			} 
			set
			{
				TextBoxQuery.Text = value;
			}
		}

		/// <summary>ButtonSubmit_Click()</summary>
		public void ButtonSubmit_Click
		(
			Object sender, 
			EventArgs e
		)
		{
			GridViewHisWord.DataBind();
		}
	}
} 
