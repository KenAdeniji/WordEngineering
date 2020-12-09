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

///<summary>
///	2013-08-11	Created.
///	2013-08-11	GridView caption.
///</summary>
public partial class InSeldomWeekInComputerTermsWhatIsItCalledPage : System.Web.UI.Page
{
	protected string Question
	{
		get { return question.Text.Trim(); }
		set { question.Text = value; }
	}
	
	public static DataSet ProcessSql(String sql)
	{
		DataSet dataSet = null;
		dataSet = (DataSet)Repository.DatabaseCommand
		(
			sql,
			CommandType.Text,
			Repository.ResultSet.DataSet
		);
		return dataSet;
	}

    protected void Submit_Click(object sender, EventArgs e)
    {
		String sql = String.Format
		(
			BibleDictionaryQueryFormat,
			Question
		);	
		DataSet result = ProcessSql(sql);
		
		jamesStrongConcordance.DataSource = result.Tables[BibleFoundationJamesStrongExhaustiveConcordanceOfGreekAndHebrewWords];
		jamesStrongConcordance.DataBind();
		
		biblicalName.DataSource = result.Tables[BibleDatabaseHitchcockBiblicalName];
		biblicalName.DataBind();

		easton.DataSource = result.Tables[BibleDatabaseEaston];
		easton.DataBind();
		
		naveTopicalBible.DataSource = result.Tables[BibleFoundationNaveTopicalBible];
		naveTopicalBible.DataBind();

		raTorrey.DataSource = result.Tables[BibleFoundationRATorreyTheNewTopicalTextbook];
		raTorrey.DataBind();
	}
	
	public const string BibleDictionaryQueryFormat = 	"SELECT * FROM BibleDictionary..BibleFoundationJamesStrongExhaustiveConcordanceOfGreekAndHebrewWords WHERE DictionaryWord LIKE '%{0}%' ORDER BY LanguageGreekHebrew DESC, DictionaryId; " +
														"SELECT * FROM BibleDictionary..BibleDatabaseHitchcockBiblicalName WHERE DictionaryWord LIKE '%{0}%' ORDER BY DictionaryId; " +
														"SELECT * FROM BibleDictionary..BibleDatabaseEaston WHERE DictionaryWord LIKE '%{0}%' ORDER BY DictionaryId; " + 
														"SELECT * FROM BibleDictionary..BibleFoundationNaveTopicalBible WHERE DictionaryWord LIKE '%{0}%' ORDER BY DictionaryId; " + 
														"SELECT * FROM BibleDictionary..BibleFoundationRATorreyTheNewTopicalTextbook WHERE DictionaryWord LIKE '%{0}%' ORDER BY DictionaryId";
														
	public const int BibleFoundationJamesStrongExhaustiveConcordanceOfGreekAndHebrewWords = 0;
	public const int BibleDatabaseHitchcockBiblicalName = 1;
	public const int BibleDatabaseEaston = 2;
	public const int BibleFoundationNaveTopicalBible = 3;
	public const int BibleFoundationRATorreyTheNewTopicalTextbook = 4;
}
