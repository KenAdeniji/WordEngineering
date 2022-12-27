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
using System.Collections.Specialized;

using System.Data.SqlClient;
using System.Text;
using System.Text.RegularExpressions;

using System.Globalization;
using System.Threading;

using InformationInTransit.DataAccess;
using InformationInTransit.ProcessCode;
using InformationInTransit.ProcessLogic;

namespace InformationInTransit.ProcessCode
{
	///<summary>
	///	2022-12-27T09:21:00 Created.
	///</summary>
	public class IWillBringAsMuchAsMyself
	{
		public static StringBuilder Query(String scriptureReference, string scriptureReferenceIn)
		{
			String[] scriptureReferenceSubset = null;
			DataSet dataSet = null;
			
			String[] scriptureReferenceSubsetIn = null;
			DataSet dataSetIn = null;
			
			ScriptureReferenceHelper.Process
			(
					scriptureReference,
				ref	scriptureReferenceSubset,
				ref dataSet,
					ScriptureReferenceHelper.BibleSequenceQueryFormat,
					ScriptureReferenceHelper.BibleVersionDefault
			);

			ScriptureReferenceHelper.Process
			(
					scriptureReferenceIn,
				ref	scriptureReferenceSubsetIn,
				ref dataSetIn,
					ScriptureReferenceHelper.BibleSequenceQueryFormat,
					ScriptureReferenceHelper.BibleVersionDefault
			);
			
			StringBuilder sb = new StringBuilder();
			
			int	scriptureReferenceSubsetIndex = 0;
			int verseIDSequenceFrom, verseIDSequenceUntil;
			int verseIDSequenceFromIn, verseIDSequenceUntilIn;
			
			DataTable dataTableIn = dataSetIn.Tables[0];
			verseIDSequenceFromIn = (int)dataTableIn.Rows[0]["VerseIDSequence"];
			verseIDSequenceUntilIn = (int)dataTableIn.Rows[dataTableIn.Rows.Count - 1]["VerseIDSequence"];
			
			foreach(DataTable dataTable in dataSet.Tables)
			{
				verseIDSequenceFrom = (int)dataTable.Rows[0]["VerseIDSequence"];
				verseIDSequenceUntil = (int)dataTable.Rows[dataTable.Rows.Count - 1]["VerseIDSequence"];
				
				if
				(
					verseIDSequenceFromIn >= verseIDSequenceFrom &&
					verseIDSequenceUntilIn <= verseIDSequenceUntil
				)
				{
					if (sb.Length > 0)
					{
						sb.Append(", ");
					}
					sb.Append
					(
						scriptureReferenceSubset[scriptureReferenceSubsetIndex]
					);
				}
				++scriptureReferenceSubsetIndex;		
			}
			
			return sb;
		}	
	}
}
