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

namespace InformationInTransit.ProcessLogic
{
	/*
		2018-01-20	Created.	Psalms 5:2, Psalms 6:10, Psalms 8:3
	*/
	public class GokeShowedMeABlackDatabaseAdministratorDBAPocketBookThatCostsTwentyPoundsHeMentionedSweden
	{
		public static void Main(string[] argv)
		{
			ScriptureReference("Psalms 6:10", 20);
		}
		
        public static string ScriptureReference
		(
			string scriptureReference,
			int verseSpan
		)
        {
			int verseIDSequence = (int) DataCommand.DatabaseCommand
			(
				String.Format
				(
					SelectQueryFormat,
					scriptureReference
				),	
                System.Data.CommandType.Text,
                DataCommand.ResultType.Scalar
            );
			
			int verseMinimum = verseIDSequence - verseSpan;
			int verseMaximum = verseIDSequence + verseSpan;
		
			string sqlStatement = String.Format
			(
				SelectQueryReferenceSetFormat,
				verseMinimum,
				verseIDSequence,
				verseMaximum
			);	

			string referenceSet = (string) DataCommand.DatabaseCommand
			(
				String.Format
				(
					SelectQueryReferenceSetFormat,
					verseMinimum,
					verseIDSequence,
					verseMaximum
				),	
                System.Data.CommandType.Text,
                DataCommand.ResultType.Scalar
            );
			
			if (referenceSet.EndsWith(","))
			{	
				referenceSet = referenceSet.Remove(referenceSet.Length - 1, 1);
			}
			
			return referenceSet;
        }
		
		public const string SelectQueryFormat = "SELECT verseIDSequence FROM Bible..Scripture WHERE ScriptureReference = '{0}'";
		
		public const string SelectQueryReferenceSetFormat = "SELECT STUFF((SELECT ' ' + ScriptureReference + ',' FROM Bible..Scripture_View WHERE verseIDSequence IN ({0}, {1}, {2}) ORDER BY verseIDSequence FOR XML PATH('')) ,1,1,'') AS referenceSet";
	}
}
