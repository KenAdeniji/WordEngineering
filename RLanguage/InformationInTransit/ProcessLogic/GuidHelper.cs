#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Diagnostics;
using System.Globalization;
using System.Text.RegularExpressions;
#endregion

namespace InformationInTransit.ProcessLogic
{
    public static partial class GuidHelper
    {
        public static void Main(string[] argv)
        {
			string s = Guid.NewGuid().ToString();
			bool isGuid = s.IsGuid();
			Debug.Assert(isGuid, "Type parameter is guid");
			System.Console.WriteLine(isGuid);
		}

		/// <summary>
		/// Converts the string representation of a Guid to its Guid 
		/// equivalent. A return value indicates whether the operation 
		/// succeeded. 
		/// </summary>
		/// <param name="s">A string containing a Guid to convert.</param>
		/// <param name="result">
		/// When this method returns, contains the Guid value equivalent to 
		/// the Guid contained in <paramref name="s"/>, if the conversion 
		/// succeeded, or <see cref="Guid.Empty"/> if the conversion failed. 
		/// The conversion fails if the <paramref name="s"/> parameter is a 
		/// <see langword="null" /> reference (<see langword="Nothing" /> in 
		/// Visual Basic), or is not of the correct format. 
		/// </param>
		/// <value>
		/// <see langword="true" /> if <paramref name="s"/> was converted 
		/// successfully; otherwise, <see langword="false" />.
		/// </value>
		/// <exception cref="ArgumentNullException">
		///        Thrown if <pararef name="s"/> is <see langword="null"/>.
		/// </exception>
		/// <remarks>
		/// Original code at https://connect.microsoft.com/VisualStudio/feedback/ViewFeedback.aspx?FeedbackID=94072&wa=wsignin1.0#tabs
		/// http://extensionmethod.net/csharp/string/isguid
		/// </remarks>
		/// <example>
		/// string s = Guid.NewGuid().ToString();
		/// Assert.IsTrue(s.IsGuid());
		/// </example>
		public static bool IsGuid(this string s)
		{
			if (s == null)
				throw new ArgumentNullException("s");
		 
			Regex format = new Regex(
				"^[A-Fa-f0-9]{32}$|" +
				"^({|\\()?[A-Fa-f0-9]{8}-([A-Fa-f0-9]{4}-){3}[A-Fa-f0-9]{12}(}|\\))?$|" +
				"^({)?[0xA-Fa-f0-9]{3,10}(, {0,1}[0xA-Fa-f0-9]{3,6}){2}, {0,1}({)([0xA-Fa-f0-9]{3,4}, {0,1}){7}[0xA-Fa-f0-9]{3,4}(}})$");
			Match match = format.Match(s);
			return match.Success;
		}		
	}
}
