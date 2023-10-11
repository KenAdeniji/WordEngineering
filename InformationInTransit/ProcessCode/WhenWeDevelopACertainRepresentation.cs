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
	///	2023-10-11T09:39:00 WhenWeDevelopACertainRepresentation.cs
	///	Composite class. Inner class.
	/// 2023-10-11T11:10:00	http://stackoverflow.com/questions/42875765/how-to-access-nested-class-from-instance-of-a-class
	///	2023-10-11T09:39:00...2023-10-11T11:46:00 WhenWeDevelopACertainRepresentation.cs	
	///	2023-10-11T11:56:00...2023-10-11T12:32:00 AlphabetSequence AlphabetSequenceInstance { get; set; }
	///</summary>
	public partial class WhenWeDevelopACertainRepresentation
	{
		public WhenWeDevelopACertainRepresentation Query
		(
			string word
		)	
		{
			WhenWeDevelopACertainRepresentation 
				whenWeDevelopACertainRepresentation = 
					new WhenWeDevelopACertainRepresentation();
				
			WhenWeDevelopACertainRepresentation.AlphabetSequence
				alphabetSequence = 
					new WhenWeDevelopACertainRepresentation.AlphabetSequence
					(
						word
					);

			whenWeDevelopACertainRepresentation.AlphabetSequenceInstance =
				alphabetSequence;

			return whenWeDevelopACertainRepresentation;
		}
		
		///<summary>
		///	2023-10-11T10:07:00 Do you need to create it? To use it?
		///</summary>
		public class AlphabetSequence
		{
			public AlphabetSequence
			(
				string word
			)	
			{
				this.AlphabetSequenceIndex = InformationInTransit.ProcessLogic.AlphabetSequence.Id
				(
					word
				);
				this.AlphabetSequenceIndexScriptureReference =
					InformationInTransit.ProcessLogic.AlphabetSequence.ScriptureReference
				(
					this.AlphabetSequenceIndex
				);
			}
			
			public int AlphabetSequenceIndex { get; set; }
			public String AlphabetSequenceIndexScriptureReference { get; set; }
		}	
		
		public AlphabetSequence AlphabetSequenceInstance { get; set; }
	}
}
