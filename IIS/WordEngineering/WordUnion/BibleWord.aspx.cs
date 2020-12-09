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

/*
	2013-03-23 BibleWord.aspx.cs BibleWordPage created. HtmlBible.com example.
	2013-05-23T18:00:00 Support for phrase added.
		Here I am (Genesis 22).
		Here am I (1 Samuel 3).
		I Am here (Acts 9:10).
	2013-07-11T15:49:00 ScriptureReference concatenate visible
	2014-08-02 	ParseLimit(). Limit All, Old, New.
	2015-10-04	http://stackoverflow.com/questions/5444300/search-for-whole-word-match-with-sql-server-like-pattern
	2015-10-04 	WholeWordsWildCardSearchQueryFormat.
	2015-10-04 	Verse(s) count.
	2015-10-04	http://www.textfixer.com/tutorials/css-table-alternating-rows.php
*/
public partial class BibleWordPage : System.Web.UI.Page
{
	protected string AndOrPhrase
	{
		get { return andOrPhrase.Value.Trim(); }
		set { andOrPhrase.Value = value; }
	}

	protected string LimitChosen
	{
		get { return limitChosen.Text.Trim(); }
		set { limitChosen.Text = value; }
	}

	protected string Question
	{
		get { return question.Text.Trim(); }
		set { question.Text = value; }
	}
	
	protected string SacredText
	{
		get { return sacredText.Text.Trim(); }
		set { sacredText.Text = value; }
	}

	protected bool WholeWords
	{
		get { return wholeWords.Checked; }
		set { wholeWords.Checked = value; }
	}
	
	protected void Query()
	{
		DataSet resultSet = BibleWordHelper.Query
		(
			AndOrPhrase,
			LimitChosen,
			Question,
			WholeWords
		);

		StringBuilder htmlTable = BibleWordHelper.BuildResult(resultSet);
		SacredText = htmlTable.ToString();
	}
	
	protected void Page_Load(object sender, EventArgs e)
    {
		if (!Page.IsPostBack)
		{
			WholeWords = true;
		}
 	}
	
	protected void Submit_Click(object sender, EventArgs e)
    {
		Query();
	}
}
