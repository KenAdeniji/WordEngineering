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
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Text;

using InformationInTransit.DataAccess;
using InformationInTransit.ProcessLogic;

namespace InformationInTransit.ProcessLogic
{
	/*
		2015-11-15	GetAPage.
		2015-12-11	NumberSignHelper.cs Created.
		2015-12-13	Use dictionary, rather than collection, to collate data.
	*/
	public static partial class NumberSignHelper
	{
		public static void Main(string[] argv)
		{
			DataSet result = null;
			String[] scriptureReferenceSubset = null;
			if (argv.Length > 0)
			{
				Dictionary<int, NumberSignScriptureReference> numberSignScriptureReferences = TalentBonding
				(
						argv[0],
					ref scriptureReferenceSubset,
					ref result
				);
			}		
		}
		
		public static Dictionary<int, NumberSignScriptureReference> TalentBonding
		(
				string scriptureReference,
			ref String[] scriptureReferenceSubset,
			ref DataSet dataSet
		)
		{
			ScriptureReferenceHelper.Process
            (
                scriptureReference,
                ref scriptureReferenceSubset,
                ref dataSet,
                ScriptureReferenceHelper.BibleQueryFormat,
                "KingJamesVersion"
            );
			Dictionary<int, NumberSignScriptureReference> numberSignScriptureReferences = 
				new Dictionary<int, NumberSignScriptureReference>();	
			foreach(DataTable dataTable in dataSet.Tables)
			{
				foreach(DataRow dataRow in dataTable.Rows)
				{
					int bookId = (int) dataRow["bookId"];
					string bookTitle = ScriptureReferenceHelper.ScriptureReference.BookName(bookId);
					int chapterId = (int) dataRow["chapterId"];
					int verseId = (int) dataRow["verseId"];
					string verseText = (string) dataRow["verseText"];
					string scriptureReferenceLocal = bookTitle + " " + chapterId.ToString() + ":" + verseId.ToString();
					
					String cmdText = String.Format(NumberSignQueryFormat, scriptureReferenceLocal);
					
					DataSet dataSetNumberSign = (DataSet) DataCommand.DatabaseCommand
					(
						cmdText,
						CommandType.Text,
						DataCommand.ResultType.DataSet
					);
					
					foreach(DataTable dataTableNumberSign in dataSetNumberSign.Tables)
					{
						foreach(DataRow dataRowNumberSign in dataTableNumberSign.Rows)
						{
							int number = ((int) dataRowNumberSign["Number"]);
							string scriptureReferenceInside = (string) dataRowNumberSign["ScriptureReference"];
							string[] scriptureReferenceBreakup = scriptureReferenceInside.Split(SubsetSeparator);
							for (int index = 0, length = scriptureReferenceBreakup.Length; index < length; ++index)
							{
								scriptureReferenceBreakup[index] = scriptureReferenceBreakup[index].Trim();
							}			
							int breakUpIndex = Array.IndexOf(scriptureReferenceBreakup, scriptureReferenceLocal);
							if (breakUpIndex > -1)
							{	
								NumberSignScriptureReference numberSignScriptureReference = null;
								bool found = numberSignScriptureReferences.TryGetValue(number, out numberSignScriptureReference);
								if (!found)
								{	
									numberSignScriptureReference = new NumberSignScriptureReference
									{
										ScriptureReference = scriptureReferenceLocal
									};
									numberSignScriptureReferences.Add
									(
										number,
										numberSignScriptureReference
									);
								}
								else
								{
									numberSignScriptureReference.ScriptureReference += ", " + scriptureReferenceLocal;
								}		
							}	
						}
					}
				}	
			}
		
			return numberSignScriptureReferences;
		}
		
		public static readonly char[] SubsetSeparator = {',', ';'};
		public const string NumberSignQueryFormat = "SELECT Number, ScriptureReference FROM WordEngineering..NumberSign WHERE ScriptureReference LIKE \'%{0}%\' ORDER BY number;";
		
		public class NumberSignScriptureReference
		{
			public 	string	ScriptureReference 	{ get; set; }
			
			public override string ToString()
			{
				return ScriptureReference;
			}			
		}		
	}
}
