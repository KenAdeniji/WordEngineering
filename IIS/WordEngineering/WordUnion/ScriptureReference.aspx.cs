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

public partial class ScriptureReferencePage : System.Web.UI.Page
{
	protected string Question
	{
		get { return question.Text.Trim(); }
		set { question.Text = value; }
	}
	
	protected string ResultSet
	{
		get { return resultSet.Text.Trim(); }
		set { resultSet.Text = value; }
	}

    protected void Submit_Click(object sender, EventArgs e)
    {
		String[] scriptureReferenceSubset = null;
		DataSet result = null;
		ScriptureReferenceHelper.Process
		(
				Question,
			ref	scriptureReferenceSubset,
			ref result
		);
		StringBuilder table = ScriptureReferenceHelper.BuildResult(scriptureReferenceSubset, result);
		ResultSet = table.ToString();
	}
}
