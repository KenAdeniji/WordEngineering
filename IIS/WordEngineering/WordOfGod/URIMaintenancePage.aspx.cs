using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Diagnostics;
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

/*
	2016-11-11	URIMaintenancePage.aspx.cs Added the commentary column.
	2024-11-06T02:04:00	Schema columns re-arrangement, and column additions.
CREATE TABLE URIWordEngineering
(
	[URI] [nvarchar](450) NOT NULL,
	[Title] [nvarchar](4000) NULL,
	[Keyword] [nvarchar](4000) NULL,
	[Commentary] [nvarchar](max) NULL,
	[URIReferrer] [nvarchar](450) NULL,
	[Referrer] [nvarchar](max) NULL,
	[ContactID] [int] NULL,
	[ScriptureReference] [nvarchar](max) NULL,	
	[Dated] [datetime] NOT NULL,
	[SequenceOrderID] [int] IDENTITY(1,1) NOT NULL,
	CONSTRAINT [PK_URIWordEngineering] PRIMARY KEY CLUSTERED 
	(
		[URI] ASC
	)
)
	2024-11-06T16:54:00 Credit to the source. Columns added URIReferrer, Referrer, ContactID.
	2024-11-06T17:13:00 Changed name DatedTo... DatedUntil.
	2024-11-07T00:24:00	You are no longer working for me.
		We are driving and we return southward. The word came out. 
		04:59 The driver, passengers were not identified, but the direction (Daniel 9).
		05:01 When the president make a statement... who should fulfill it? President Joe Biden goes to the Middle East, Africa Summit. Means of movement? 
		05:09 With my adopted father he would listen to the budget and critic the plan.
		05:11 With me, I understand the word of God 05:11 and the relevance to our life.
	2024-11-07T05:14:00	aljazeera.com/news/2024/11/7/biden-rushing-billions-in-aid-to-ukraine-as-trump-win-fuels-uncertainty
		2024-11-07T05:35:00	microsoft windows operating system, mozilla firefox, microsoft sql server management studio mouse error, user-interface (UI) error.
	2024-11-07T05:18:00 And Abram said unto Lot, Let there be no strife, I pray thee, between me and thee, and between my herdmen and thy herdmen; for we be brethren. Genesis 13:8.
	2024-11-07T05:05:35 How do we personally be the same?
	2024-11-07T05:05:35	What are resemblance of thing?
	2024-11-07T01:57:00	The stimulus and trigger for these changes:
		Referrer
		Data entry clockwise
	2024-11-07T05:52:00	What perhaps... I have grown as?
*/
namespace WordEngineering
{
	public class URIMaintenancePage : Page
	{
		public String[] ColumnNameURI                = UtilityURI.ColumnNameURI;
		public String DatabaseConnectionString       = "Provider=SQLOLEDB;Data Source=localhost;Integrated Security=SSPI;Initial Catalog=URI;";
		public String FilenameConfigurationXml       = @"WordEngineering.config";
		public string FilenameStylesheet             = UtilityURI.FilenameStylesheet;
		public String ServerMapPath                  = null;
		public String[] TableNameURI                = UtilityURI.TableNameURI;
		public string   TableNameURIDefault         = UtilityURI.TableNameURIDefault;
		protected System.Web.UI.HtmlControls.HtmlInputFile         HtmlInputFileURI;
		protected System.Web.UI.WebControls.Button                 ButtonFileOpen;
		protected System.Web.UI.WebControls.Button                 ButtonFileSave;
		protected System.Web.UI.WebControls.Button                 ButtonReset;
		protected System.Web.UI.WebControls.Button                 ButtonSubmit;
		protected System.Web.UI.WebControls.DropDownList           DropDownListTableName;
		protected System.Web.UI.WebControls.DetailsView            DetailsViewURI;
		protected System.Web.UI.WebControls.GridView               GridViewURI;
		protected System.Web.UI.WebControls.Literal                LiteralFeedback;
		protected System.Web.UI.WebControls.SqlDataSource          SqlDataSourceURIDetailsView;
		protected System.Web.UI.WebControls.SqlDataSource          SqlDataSourceURIGridView;
		protected System.Web.UI.WebControls.SqlDataSource          SqlDataSourceTable;
		protected System.Web.UI.WebControls.TextBox                TextBoxCommentary;
		protected System.Web.UI.WebControls.TextBox                TextBoxContactID;
		protected System.Web.UI.WebControls.TextBox                TextBoxDatedFrom;
		protected System.Web.UI.WebControls.TextBox                TextBoxDatedUntil;
		protected System.Web.UI.WebControls.TextBox                TextBoxInternetCountryCodeTopLevelDomain_ccTLD;
		protected System.Web.UI.WebControls.TextBox                TextBoxKeyword;
		protected System.Web.UI.WebControls.TextBox                TextBoxReferrer;
		protected System.Web.UI.WebControls.TextBox                TextBoxSequenceOrderIDFrom;
		protected System.Web.UI.WebControls.TextBox                TextBoxSequenceOrderIDTo;
		protected System.Web.UI.WebControls.TextBox                TextBoxTitle;
		protected System.Web.UI.WebControls.TextBox                TextBoxURI;
		protected System.Web.UI.WebControls.TextBox                TextBoxURIReferrer;

		public void Page_Load
		(
			object     sender, 
			EventArgs  e
		) 
		{
			String  exceptionMessage  =  null;
			ServerMapPath = this.MapPath("");

			if ( !Page.IsPostBack )
			{
				//FilenameConfigurationXml = Server.MapPath( FilenameConfigurationXml );

				try
				{
					if ( ServerMapPath != null)
					{
						FilenameConfigurationXml = ServerMapPath + @"\" + FilenameConfigurationXml;
					}

					UtilityURI.ConfigurationXml
					(
							FilenameConfigurationXml,
						ref exceptionMessage,         
						ref DatabaseConnectionString,
						ref FilenameStylesheet,
						ref ColumnNameURI,
						ref TableNameURI,
						ref TableNameURIDefault
					);
		
					if ( exceptionMessage != null )
					{
						LiteralFeedback.Text = exceptionMessage;
						return;
					}

					GridViewURI.Focus();
					Page.SetFocus( GridViewURI );
					DetailsViewURI.Attributes.Add("autocomplete", "on");
					GridViewURI.Attributes.Add("autocomplete", "on");
				}
				catch (Exception ex)
				{
					LiteralFeedback.Text = ex.Message;
				}	
			}
   		}

		public void DropDownListTableName_PreRender
		(
			object     sender, 
			EventArgs  e
		) 
		{
			if ( !Page.IsPostBack )
			{
				if ( DropDownListTableName.Items.Count < 1 )
				{
					DropDownListTableName.DataSourceID    =  null;
					DropDownListTableName.DataTextField   =  null;
					DropDownListTableName.DataValueField  =  null;
					DropDownListTableName.DataSource      =  TableNameURI;
					DropDownListTableName.DataBind();
				}
				UtilityWebControl.SelectItem
				( 
					DropDownListTableName,
					TableNameURIDefault
				);
			}
		}

		public String DatedFrom
		{
			get
			{
				return ( TextBoxDatedFrom.Text );
			} 
			set
			{
				TextBoxDatedFrom.Text = value;
			}
		}

		public String DatedUntil
		{
			get
			{
				return ( TextBoxDatedUntil.Text );
			} 
			set
			{
				TextBoxDatedUntil.Text = value;
			}
		}

		public String Feedback
		{
			get
			{
				return ( LiteralFeedback.Text );
			} 
			set
			{
				LiteralFeedback.Text = value;
			}
		}

		public String FilenameURI
		{
			get
			{
				return ( HtmlInputFileURI.PostedFile.FileName  );
			} 
		}

		public String InternetCountryCodeTopLevelDomain_ccTLD
		{
			get
			{
				return ( TextBoxInternetCountryCodeTopLevelDomain_ccTLD.Text );
			} 
			set
			{
				TextBoxInternetCountryCodeTopLevelDomain_ccTLD.Text = value;
			}
		}

		public String Keyword
		{
			get
			{
				return ( TextBoxKeyword.Text );
			} 
			set
			{
				TextBoxKeyword.Text = value;
			}
		}

		public String SequenceOrderIDFrom
		{
			get
			{
				return ( TextBoxSequenceOrderIDFrom.Text );
			} 
			set
			{
				TextBoxSequenceOrderIDFrom.Text = value;
			}
		}

		public String SequenceOrderIDTo
		{
			get
			{
				return ( TextBoxSequenceOrderIDTo.Text );
			} 
			set
			{
				TextBoxSequenceOrderIDTo.Text = value;
			}
		}

		public String URICommentary
		{
			get
			{
				return ( TextBoxCommentary.Text );
			} 
			set
			{
				TextBoxCommentary.Text = value;
			}
		}

		public String URITitle
		{
			get
			{
			return ( TextBoxTitle.Text );
			} 
		set
			{
			TextBoxTitle.Text = value;
			}
		}

		public String URI  
		{
			get
			{
				return ( TextBoxURI.Text );
			} 
			set
			{
				TextBoxURI.Text = value;
			}
		}

		public void ButtonFileOpen_Click
		(
			Object sender, 
			EventArgs e
		)
		{
			string     exceptionMessage  =  null;
			string     filenameXml       =  null;
			DataSet    dataSet           =  null;

			try
			{
				if ( string.IsNullOrEmpty( FilenameURI ) )
				{
					return;
				}
				filenameXml = FilenameURI;
				UtilityURI.ReadXml
				(
					 ref filenameXml,
					 ref dataSet,
					 ref exceptionMessage,
					 ref ColumnNameURI
				);
				if ( exceptionMessage != null )
				{
					Feedback = exceptionMessage;
					return;
				}     	 
				if ( dataSet != null )
				{
					 ViewState["URIMaintenancePage_DataSet"] = dataSet;
					 GridViewURI.AllowPaging   =  false;
					 GridViewURI.AllowSorting  =  false;     
					 GridViewURI.DataSourceID  =  null;
					 GridViewURI.DataSource    =  dataSet;
					 GridViewURI.DataBind();
				}
			}
			catch ( Exception exception )
			{
				exceptionMessage = "Exception: " + exception.Message;
			}
			if ( exceptionMessage != null )
			{
				Feedback = exceptionMessage;
			}
		}

		public void ButtonFileSave_Click
		(
			Object sender, 
			EventArgs e
		)
		{
			string   exceptionMessage  =  null;
			string   filenameXml       =  null;
			DataSet  dataSet           =  null;

			try
			{
				if ( string.IsNullOrEmpty( FilenameURI ) )
				{
					return;
				}
				filenameXml     =  FilenameURI;
				dataSet = ( DataSet ) ViewState["URIMaintenancePage_DataSet"];
				if ( dataSet == null )
				{
					return;
				}
				UtilityXml.WriteXml
				(
						dataSet,
					ref exceptionMessage,
					ref filenameXml,
					ref FilenameStylesheet
				);
				if ( exceptionMessage != null )
				{
					Feedback = exceptionMessage;
					return;
				}     	 
			}
				catch ( Exception exception )
			{
				exceptionMessage = "Exception: " + exception.Message;
			}
			if ( exceptionMessage != null )
			{
				Feedback = exceptionMessage;
			}
		}
  
		public void ButtonSubmit_Click
		(
			Object sender, 
			EventArgs e
		)
		{
			GridViewURI.DataBind();
		}

		public void ButtonReset_Click
		(
			Object sender, 
			EventArgs e
		)
		{
			Feedback             =  null;
			DatedFrom            =  null;
			DatedUntil              =  null;
			Keyword              =  null;
			SequenceOrderIDFrom  =  null;
			SequenceOrderIDTo    =  null;
			URI                  =  null;
			URITitle             =  null;

			UtilityJavaScript.SetFocus
			( 
				this,
				DropDownListTableName
			);
		}

		public void DetailsViewURI_ItemInserted
		(
			Object                        sender, 
			DetailsViewInsertedEventArgs  detailsViewInsertedEventArgs
		)
		{
			// Use the Exception property to determine whether an exception
			// occurred during the insert operation.
			if ( detailsViewInsertedEventArgs.Exception != null )
			{
				// Insert the code to handle the exception.
				Feedback = detailsViewInsertedEventArgs.Exception.Message;

				// Use the ExceptionHandled property to indicate that the 
				// exception is already handled.
				detailsViewInsertedEventArgs.ExceptionHandled = true;

				// When an exception occurs, keep the DetailsView
				// control in insert mode.
				detailsViewInsertedEventArgs.KeepInInsertMode = true;
			}
			else
			{
			GridViewURI.DataBind();
			}
		}

		public void DetailsViewURI_ItemInserting
		(
			Object                      sender, 
			DetailsViewInsertEventArgs  detailsViewInsertEventArgs
		)
		{
			int       sequenceOrderID   =  -1;
			DateTime  dated             =  DateTime.MinValue;
			string    exceptionMessage  =  null;
			string    commentary        =  null;
			string    keyword           =  null;
			string    title             =  null;
			string    uri               =  null;

			IOrderedDictionary  iOrderedDictionary;     
			try
			{
				if ( detailsViewInsertEventArgs.Values["URI"] != null )
				{
					uri = detailsViewInsertEventArgs.Values["URI"].ToString();
				}
				if ( detailsViewInsertEventArgs.Values["Title"] != null )
				{
					title = detailsViewInsertEventArgs.Values["Title"].ToString();
				} 
				if ( detailsViewInsertEventArgs.Values["Commentary"] != null )
				{
					commentary = detailsViewInsertEventArgs.Values["Commentary"].ToString();
				} 
				if ( detailsViewInsertEventArgs.Values["Keyword"] != null )
				{
					keyword = detailsViewInsertEventArgs.Values["Keyword"].ToString();
				}
				if ( sequenceOrderID > 0 )
				{
					SqlDataSourceURIDetailsView.InsertParameters["SequenceOrderID"].DefaultValue  =  System.Convert.ToString( sequenceOrderID );
				}
				if ( dated != DateTime.MinValue )
				{
					SqlDataSourceURIDetailsView.InsertParameters["Dated"].DefaultValue            =  System.Convert.ToString( dated );
				}
				if ( detailsViewInsertEventArgs.Values["Dated"] != null )
				{
					DateTime.TryParse( detailsViewInsertEventArgs.Values["Dated"].ToString(), out dated );
				}
				if ( detailsViewInsertEventArgs.Values["SequenceOrderID"] != null )
				{
					Int32.TryParse( detailsViewInsertEventArgs.Values["SequenceOrderID"].ToString(), out sequenceOrderID );
				} 
				SqlDataSourceURIDetailsView.InsertParameters["commentary"].DefaultValue        =  commentary;
				SqlDataSourceURIDetailsView.InsertParameters["keyword"].DefaultValue           =  keyword;
				SqlDataSourceURIDetailsView.InsertParameters["title"].DefaultValue             =  title;
				SqlDataSourceURIDetailsView.InsertParameters["uri"].DefaultValue               =  uri;
				SqlDataSourceURIDetailsView.Insert();
			}
			catch ( Exception exception )
			{
				exceptionMessage = exception.Message;
			}
			if ( exceptionMessage != null )
			{
				Feedback = exceptionMessage;
				return;
			}
		}

		public void DetailsViewURI_ItemUpdated
		(
			Object                        sender, 
			DetailsViewUpdatedEventArgs   detailsViewUpdatedEventArgs
		)
		{
			// Use the Exception property to determine whether an exception
			// occurred during the insert operation.
			if ( detailsViewUpdatedEventArgs.Exception != null )
			{
				// Insert the code to handle the exception.
				Feedback = detailsViewUpdatedEventArgs.Exception.Message;

				// Use the ExceptionHandled property to indicate that the 
				// exception is already handled.
				detailsViewUpdatedEventArgs.ExceptionHandled = true;

				// When an exception occurs, keep the DetailsView
				// control in edit mode.
				detailsViewUpdatedEventArgs.KeepInEditMode = true;
			}
			else
			{
				GridViewURI.DataBind();
			}
		}

		public void GridViewURI_RowCommand
		(
			Object                    sender, 
			GridViewCommandEventArgs  gridViewCommandEventArgs
		)
		{ 
			string    	exceptionMessage  		=  	null;

			string    	commentary        		=  	null;
			int			contactID				=	-1;
			DateTime  	dated;
			string    	keyword           		=  	null;
			string		referrer				=	null;
			string		scriptureReference		=	null;
			int			sequenceOrderID			=	-1;
			string    	title            		=	null;
			string    	uri               		=  	null;
			string		uriReferrer				=	null;

			try
			{
				switch ( gridViewCommandEventArgs.CommandName  )
				{
					case "ButtonGridViewURIFooterTemplateAdd":
						commentary = ( ( System.Web.UI.WebControls.TextBox ) GridViewURI.FooterRow.FindControl("TextBoxGridViewURIFooterTemplateCommentary")).Text;
						Int32.TryParse( ( ( System.Web.UI.WebControls.TextBox ) GridViewURI.FooterRow.FindControl("TextBoxGridViewURIFooterTemplateContactID")).Text, out contactID );
						DateTime.TryParse( ( ( System.Web.UI.WebControls.TextBox ) GridViewURI.FooterRow.FindControl("TextBoxGridViewURIFooterTemplateDated")).Text, out dated );
						keyword  = ( ( System.Web.UI.WebControls.TextBox ) GridViewURI.FooterRow.FindControl("TextBoxGridViewURIFooterTemplateKeyword")).Text;
						referrer = ( ( System.Web.UI.WebControls.TextBox ) GridViewURI.FooterRow.FindControl("TextBoxGridViewURIFooterTemplateReferrer")).Text;
						scriptureReference = ( ( System.Web.UI.WebControls.TextBox ) GridViewURI.FooterRow.FindControl("TextBoxGridViewURIFooterTemplateScriptureReference")).Text;
						Int32.TryParse( ( ( System.Web.UI.WebControls.TextBox ) GridViewURI.FooterRow.FindControl("TextBoxGridViewURIFooterTemplateSequenceOrderID")).Text, out sequenceOrderID );
						title = ( ( System.Web.UI.WebControls.TextBox ) GridViewURI.FooterRow.FindControl("TextBoxGridViewURIFooterTemplateTitle")).Text;
						uri = ( ( System.Web.UI.WebControls.TextBox ) GridViewURI.FooterRow.FindControl("TextBoxGridViewURIFooterTemplateURI")).Text;
						uriReferrer = ( ( System.Web.UI.WebControls.TextBox ) GridViewURI.FooterRow.FindControl("TextBoxGridViewURIFooterTemplateURIReferrer")).Text;

						SqlDataSourceURIGridView.InsertParameters["commentary"].DefaultValue    		=  commentary;
						if ( contactID > 0 )
						{
							SqlDataSourceURIGridView.InsertParameters["contactID"].DefaultValue 		=      Report

|
March 26, 2025

X
Facebook
Threads
LinkedIn

    WhatsApp

Around the World, Many People Are Leaving Their Childhood Religions
Surveys in 36 countries find that Christianity and Buddhism have the biggest losses from ‘religious switching’
By
Kirsten Lesage
,
Kelsey Jo Starr
and
William Miner    Report

|
March 26, 2025

X
Facebook
Threads
LinkedIn

    WhatsApp

Around the World, Many People Are Leaving Their Childhood Religions
Surveys in 36 countries find that Christianity and Buddhism have the biggest losses from ‘religious switching’
By
Kirsten Lesage
,
Kelsey Jo Starr
and
William Miner    Report

|
March 26, 2025

X
Facebook
Threads
LinkedIn

    WhatsApp

Around the World, Many People Are Leaving Their Childhood Religions
Surveys in 36 countries find that Christianity and Buddhism have the biggest losses from ‘religious switching’
By
Kirsten Lesage
,
Kelsey Jo Starr
and
William Miner    Report

|
March 26, 2025

X
Facebook
Threads
LinkedIn

    WhatsApp

Around the World, Many People Are Leaving Their Childhood Religions
Surveys in 36 countries find that Christianity and Buddhism have the biggest losses from ‘religious switching’
By
Kirsten Lesage
,
Kelsey Jo Starr
and
William Miner    Report

|
March 26, 2025

X
Facebook
Threads
LinkedIn

    WhatsApp

Around the World, Many People Are Leaving Their Childhood Religions
Surveys in 36 countries find that Christianity and Buddhism have the biggest losses from ‘religious switching’
By
Kirsten Lesage
,
Kelsey Jo Starr
and
William Miner    Report

|
March 26, 2025

X
Facebook
Threads
LinkedIn

    WhatsApp

Around the World, Many People Are Leaving Their Childhood Religions
Surveys in 36 countries find that Christianity and Buddhism have the biggest losses from ‘religious switching’
By
Kirsten Lesage
,
Kelsey Jo Starr
and
William Miner    Report

|
March 26, 2025

X
Facebook
Threads
LinkedIn

    WhatsApp

Around the World, Many People Are Leaving Their Childhood Religions
Surveys in 36 countries find that Christianity and Buddhism have the biggest losses from ‘religious switching’
By
Kirsten Lesage
,
Kelsey Jo Starr
and
William Miner    Report

|
March 26, 2025

X
Facebook
Threads
LinkedIn

    WhatsApp

Around the World, Many People Are Leaving Their Childhood Religions
Surveys in 36 countries find that Christianity and Buddhism have the biggest losses from ‘religious switching’
By
Kirsten Lesage
,
Kelsey Jo Starr
and
William Miner    Report

|
March 26, 2025

X
Facebook
Threads
LinkedIn

    WhatsApp

Around the World, Many People Are Leaving Their Childhood Religions
Surveys in 36 countries find that Christianity and Buddhism have the biggest losses from ‘religious switching’
By
Kirsten Lesage
,
Kelsey Jo Starr
and
William Miner    Report

|
March 26, 2025

X
Facebook
Threads
LinkedIn

    WhatsApp

Around the World, Many People Are Leaving Their Childhood Religions
Surveys in 36 countries find that Christianity and Buddhism have the biggest losses from ‘religious switching’
By
Kirsten Lesage
,
Kelsey Jo Starr
and
William Miner    Report

|
March 26, 2025

X
Facebook
Threads
LinkedIn

    WhatsApp

Around the World, Many People Are Leaving Their Childhood Religions
Surveys in 36 countries find that Christianity and Buddhism have the biggest losses from ‘religious switching’
By
Kirsten Lesage
,
Kelsey Jo Starr
and
William MinerSystem.Convert.ToString( contactID );
						}
						if ( dated != DateTime.MinValue )
						{
							SqlDataSourceURIGridView.InsertParameters["dated"].DefaultValue           	=  System.Convert.ToString( dated );
						}
						SqlDataSourceURIGridView.InsertParameters["keyword"].DefaultValue       	    =  keyword;
						SqlDataSourceURIGridView.InsertParameters["referrer"].DefaultValue       	    =  referrer;
						SqlDataSourceURIGridView.InsertParameters["scriptureReference"].DefaultValue    =  scriptureReference;
						if ( sequenceOrderID > 0 )
						{
							SqlDataSourceURIGridView.InsertParameters["sequenceOrderID"].DefaultValue 	=  System.Convert.ToString( sequenceOrderID );
						}
						SqlDataSourceURIGridView.InsertParameters["title"].DefaultValue  				=  title;
						SqlDataSourceURIGridView.InsertParameters["uriReferrer"].DefaultValue          	=  uriReferrer;
						SqlDataSourceURIGridView.InsertParameters["uri"].DefaultValue               	=  uri;
						SqlDataSourceURIGridView.Insert();

						break;
				}
			}
			catch ( System.Exception exception )
			{
				exceptionMessage = "System.Exception: " + exception.Message;
			}
			if ( exceptionMessage != null )
			{
				Feedback = exceptionMessage;
				return;
			}
			GridViewURI.DataBind();
		}

		public void GridViewURI_RowDeleting
		(
			Object                    sender, 
			GridViewDeleteEventArgs   gridViewDeleteEventArgs
		)
		{
			int          sequenceOrderID   =  -1;
			string       exceptionMessage  =  null;
			GridViewRow  gridViewRow       =  null;

			try
			{  	
				gridViewRow = GridViewURI.Rows[ gridViewDeleteEventArgs.RowIndex ];
				if ( gridViewRow == null )
				{
					return;
				}     	
				Int32.TryParse( ( ( System.Web.UI.WebControls.Label ) gridViewRow.FindControl("LabelGridViewURIItemTemplateSequenceOrderID")).Text, out sequenceOrderID );
				SqlDataSourceURIGridView.DeleteParameters["original_SequenceOrderID"].DefaultValue = sequenceOrderID.ToString();
				SqlDataSourceURIGridView.Delete();
			}
			catch ( Exception exception )
			{
				exceptionMessage = exception.Message;
			}
			if ( exceptionMessage != null )
			{
				Feedback = exceptionMessage;
				return;
			}
		}

		/// <summary>GridViewURI_RowUpdating</summary>
		/// <details>
		///  http://fredrik.nsquared2.com/viewpost.aspx?PostID=173&amp;showfeedback=true Get a control or value from a GridView row.
		///  http://www.chrisfrazier.net/blog/archive/category/1014.aspx
		/// </details>  
		public void GridViewURI_RowUpdating
		(
			Object                    sender, 
			GridViewUpdateEventArgs   gridViewUpdateEventArgs
		)
		{
			GridViewRow  	gridViewRow       =  null;

			string			exceptionMessage  		=  	null;

			string    		commentary        		=  	null;
			int				contactID				=	-1;
			DateTime  		dated;
			string    		keyword           		=  	null;
			string			referrer				=	null;
			string			scriptureReference		=	null;
			int				sequenceOrderID			=	-1;
			string    		title            		=	null;
			string    		uri               		=  	null;
			string			uriReferrer				=	null;

			try
			{  	
				gridViewRow = GridViewURI.Rows[ gridViewUpdateEventArgs.RowIndex ];
				if ( gridViewRow == null )
				{
					return;
				}     	

				commentary  = ( ( System.Web.UI.WebControls.TextBox ) gridViewRow.FindControl("TextBoxGridViewURIEditItemTemplateCommentary")).Text;
				Int32.TryParse( ( ( System.Web.UI.WebControls.Label ) gridViewRow.FindControl("TextBoxGridViewURIEditItemTemplateContactID")).Text, out contactID );
				DateTime.TryParse( ( ( System.Web.UI.WebControls.TextBox ) gridViewRow.FindControl("TextBoxGridViewURIEditItemTemplateDated")).Text, out dated );
				keyword = ( ( System.Web.UI.WebControls.TextBox ) gridViewRow.FindControl("TextBoxGridViewURIEditItemTemplateKeyword")).Text;
				referrer = ( ( System.Web.UI.WebControls.TextBox ) gridViewRow.FindControl("TextBoxGridViewURIEditItemTemplateReferrer")).Text;
				scriptureReference = ( ( System.Web.UI.WebControls.TextBox ) gridViewRow.FindControl("TextBoxGridViewURIEditItemTemplateScriptureReference")).Text;
				Int32.TryParse( ( ( System.Web.UI.WebControls.Label ) gridViewRow.FindControl("LabelGridViewURIItemTemplateSequenceOrderID")).Text, out sequenceOrderID );
				uri = ( ( System.Web.UI.WebControls.TextBox ) gridViewRow.FindControl("TextBoxGridViewURIEditItemTemplateURI")).Text;
				title = ( ( System.Web.UI.WebControls.TextBox ) gridViewRow.FindControl("TextBoxGridViewURIEditItemTemplateTitle")).Text;
				uriReferrer = ( ( System.Web.UI.WebControls.TextBox ) gridViewRow.FindControl("TextBoxGridViewURIEditItemTemplateURIReferrer")).Text;
				
				SqlDataSourceURIGridView.UpdateParameters["uri"].DefaultValue = uri;
				SqlDataSourceURIGridView.UpdateParameters["title"].DefaultValue = title;
				SqlDataSourceURIGridView.UpdateParameters["keyword"].DefaultValue = keyword;				
				SqlDataSourceURIGridView.UpdateParameters["commentary"].DefaultValue = commentary;
				SqlDataSourceURIGridView.UpdateParameters["uriReferrer"].DefaultValue = uriReferrer;
				SqlDataSourceURIGridView.UpdateParameters["referrer"].DefaultValue = referrer;
				SqlDataSourceURIGridView.UpdateParameters["contactID"].DefaultValue = contactID;
				SqlDataSourceURIGridView.UpdateParameters["scriptureReference"].DefaultValue = scriptureReference;
				if ( dated != DateTime.MinValue )
				{
					SqlDataSourceURIGridView.UpdateParameters["dated"].DefaultValue = dated;
				} 
				SqlDataSourceURIGridView.UpdateParameters["original_SequenceOrderID"].DefaultValue = sequenceOrderID;
								
				SqlDataSourceURIGridView.Update();
			}
			catch ( Exception exception )
			{
				exceptionMessage = exception.Message;
			}
			if ( exceptionMessage != null )
			{
				Feedback = exceptionMessage;
				return;
			}
		}

		public void GridViewURI_RowUpdated
		(
			Object                    sender, 
			GridViewUpdatedEventArgs  gridViewUpdatedEventArgs
		)
		{
			// Use the Exception property to determine whether an exception
			// occurred during the insert operation.
			if ( gridViewUpdatedEventArgs.Exception != null )
			{
				// Insert the code to handle the exception.
				Feedback = gridViewUpdatedEventArgs.Exception.Message;

				// Use the ExceptionHandled property to indicate that the 
				// exception is already handled.
				gridViewUpdatedEventArgs.ExceptionHandled = true;

				// When an exception occurs, keep the GridView
				// control in edit mode.
				gridViewUpdatedEventArgs.KeepInEditMode = true;
			}
		}
	}
}
