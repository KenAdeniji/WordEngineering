using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml.Linq; 

namespace WordEngineering
{
	public partial class WorldBankDataWebAPIPage : Page
	{
		protected void Page_Load
		(
			object     sender, 
			EventArgs  e
		) 
		{
			if( !Page.IsPostBack )
			{
				BindData();
			}
		}

		protected String FeedBack
		{
			get
			{
				return ( feedBack.Text);
			} 
			set
			{
				feedBack.Text = value;
			}
		}
		
		protected void BindData()
		{
			DataSet dataSet = new DataSet();
			dataSet.ReadXml(AddressXml);

			WorldBankGridView.DataSource = dataSet.Tables[1];
			WorldBankGridView.DataBind();
		}
		
		public const string AddressXml = "http://api.worldbank.org/countries?format=xml";
	}
}
