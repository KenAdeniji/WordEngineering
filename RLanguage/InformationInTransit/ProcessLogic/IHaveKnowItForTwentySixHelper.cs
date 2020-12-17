using System;

using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;	
using System.Xml;
using System.Xml.Serialization;

using InformationInTransit.ProcessLogic;	

/*
	2017-04-04	I have know it, for twenty six.	A stoop, bended woman, walks. 2016-12-31 ... 2017-04-04, 94 days, 94 / 365 = 0.25753424657534246575342465753425. 2017-04-04T23:26:00 26% of the year.
	2017-04-05	Barnes & Noble, statistics, Statistics in a Nutshell: A Desktop Quick Reference by Sarah Boslaugh	
	2017-04-05	Created.	IHaveKnowItForTwentySixHelper.cs
	2017-04-05	http://stackoverflow.com/questions/8526214/c-sharp-regex-match-anything-inside-parentheses
	2017-04-06	http://stackoverflow.com/questions/2877660/composite-key-dictionary
*/
namespace InformationInTransit.ProcessLogic
{
    public partial class IHaveKnowItForTwentySixHelper
    {
        public static void Main(string[] argv)
        {
			Query(DefaultAddress);
        }

        public static Dictionary<CompositeKey, TwentySix> Query
		(
			string	uri
		)
        {
			string[] uris = uri.Split( new string[] { Environment.NewLine }, StringSplitOptions.None  );
			string content = null;
			string htmlContent = null;
			string matchValue = null;
			
			Dictionary<CompositeKey, TwentySix> knowIts = new Dictionary<CompositeKey, TwentySix>();
			CompositeKey compositeKey = null;
			TwentySix twentySix = null;
			
			bool found = false;
			
			try
			{
				foreach(string currentUrl in uris)
				{
					content = WebHelper.GetPageAsString(currentUrl);
					
					string pattern = @"(?<=\().+?(?=\))";
					MatchCollection matches = Regex.Matches(content, pattern);
					
					string[] 	scriptureReferenceSubset = null; 
					
					List<ScriptureReferenceHelper.ScriptureReferenceSubset> scriptureReferenceSubsets = 
						new List<ScriptureReferenceHelper.ScriptureReferenceSubset>();
					
					foreach(Match match in matches)
					{
						htmlContent = matchValue = match.Value;
						System.Console.WriteLine(htmlContent);
						if (matchValue.IndexOf('>') > -1)
						{	
							htmlContent = StringHelper.HTMLContent(matchValue);
						}
						System.Console.WriteLine(htmlContent);
						scriptureReferenceSubsets = ScriptureReferenceHelper.Parse
						(
								htmlContent,
							ref scriptureReferenceSubset
						);
						if (scriptureReferenceSubsets == null) {continue;}
						foreach
						(
							ScriptureReferenceHelper.ScriptureReferenceSubset subsetCurrent in scriptureReferenceSubsets
						)
						{
							if (subsetCurrent == null) { continue; }
							compositeKey = new CompositeKey
							{
								Uri = currentUrl,
								ScriptureReferenceSubset = subsetCurrent
							};
							found = knowIts.TryGetValue(compositeKey, out twentySix);
							if (!found)
							{ 
								twentySix = new TwentySix
								{
									CompositeKey = compositeKey,
									Occurrence = 1
								};
								knowIts.Add(compositeKey, twentySix);
							}
							else
							{
								++twentySix.Occurrence;
							}			 			
						}		
					}	
				}
			}
			catch(Exception ex)
			{
				System.Console.WriteLine
				(
					"Exception: {0}",
					ex.Message
				);
			}	
			return knowIts;	
        }

		public static DataSet TransformDictionaryDataset(Dictionary<CompositeKey, TwentySix> knowIts)
		{
			DataTable dataTable = new DataTable();
			dataTable.Clear();
			dataTable.Columns.Add("Uri");
			dataTable.Columns.Add("ScriptureReference");
			dataTable.Columns.Add("Occurrence", typeof(Int64));
			
			foreach(KeyValuePair<IHaveKnowItForTwentySixHelper.CompositeKey, IHaveKnowItForTwentySixHelper.TwentySix> entry in knowIts)
			{
				// do something with entry.Value or entry.Key
				object[] o = 
				{ 
					entry.Key.Uri,
					entry.Key.ScriptureReferenceSubset.StringRepresentation,
					entry.Value.Occurrence
				};
				dataTable.Rows.Add(o);
			}

			DataSet dataSet = new DataSet();
			dataSet.Tables.Add(dataTable);
			
			return dataSet;
		}
		
		public partial class CompositeKey
		{
			public string Uri { get; set; }
			public ScriptureReferenceHelper.ScriptureReferenceSubset ScriptureReferenceSubset { get; set; }
			
			public override int GetHashCode()
			{
				return Uri.ToString().GetHashCode() ^ ScriptureReferenceSubset.ToString().GetHashCode();
			}
 
			public override bool Equals(object obj)
			{
				return true;
				if (obj is CompositeKey)
				{
					CompositeKey compositeKey = (CompositeKey)obj;
					return 
					(
						this.Uri.Equals(compositeKey.Uri, StringComparison.CurrentCultureIgnoreCase) 
						&& this.ScriptureReferenceSubset.ToString().Equals(compositeKey.ScriptureReferenceSubset.ToString(), StringComparison.CurrentCultureIgnoreCase)
					);
				}
				return false;
			}			
		}

		public partial class TwentySix
		{
			public CompositeKey CompositeKey { get; set; }
			public long	Occurrence  { get; set; }
		}

		public static readonly string DefaultAddress = 
			"http://localhost/WordEngineering/WordUnion/2017-04-06T1010ScriptureReferenceSample.html" +
			System.Environment.NewLine +
			"http://localhost/WordEngineering/WordUnion/2015-10-23DoctoralDissertation.html";
    }
}
