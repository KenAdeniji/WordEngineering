using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

using InformationInTransit.DataAccess;
using InformationInTransit.ProcessLogic;

public partial class NotOnlyMeIWillBeAsSomePage : System.Web.UI.Page
{
	protected long FrequencyOfOccurrenceLimit
	{
		get { 
			long frequencyOfOccurrenceLimitHold = FrequencyOfOccurrenceLimitDefault;
			long temp = -1;
			bool parse = Int64.TryParse(frequencyOfOccurrenceLimit.Text.Trim(), out temp);
			if (parse)
			{
				frequencyOfOccurrenceLimitHold = temp;	
			}
			return frequencyOfOccurrenceLimitHold; 
		}
		set { frequencyOfOccurrenceLimit.Text = value.ToString(); }
	}

	protected string Question
	{
		get { return question.Text.Trim(); }
		set { question.Text = value; }
	}
	
	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack)
		{
			FrequencyOfOccurrenceLimit = FrequencyOfOccurrenceLimitDefault;
			Question = "Genesis 12:14, 1 Kings 22, Hosea 14, Revelation 5:10";
			Query();
		}		
	}

    protected void Submit_Click(object sender, EventArgs e)
    {
		Query();
	}
	
	protected void Query()
	{
		string[] argv = new string[] {
 			String.Format("/frequencyOfOccurrenceLimit:{0}", FrequencyOfOccurrenceLimit),
			Question
		};
		DataSet result = null;		
		string[] scriptureReferenceSubset = null;
		
		DataSet notOnlyMeIWillBeAsSomeArgumentsDataSet = NotOnlyMeIWillBeAsSome.Process(argv, ref scriptureReferenceSubset, ref result);
		informationSet.DataSource = notOnlyMeIWillBeAsSomeArgumentsDataSet;
		informationSet.DataBind();
	}
	
	public const long FrequencyOfOccurrenceLimitDefault = 50;
}
