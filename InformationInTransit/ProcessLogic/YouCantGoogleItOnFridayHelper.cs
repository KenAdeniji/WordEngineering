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
using System.Text;
using System.Text.RegularExpressions;

namespace InformationInTransit.ProcessLogic
{
	/*
		2017-10-18	Created.
	*/
	public static partial class YouCantGoogleItOnFridayHelper
	{
		public static void Main(string[] argv)
		{
			Query("KingJamesVersion", "http://localhost/WordEngineering/WordUnion/2017-10-18YouCantGoogleItOnFriday.html");	
		}
		
		public static void BracketsParentheses(ref StringBuilder sbData)
		{
			int	indexOfBracketsParenthesesStart =	0;
			int	indexOfBracketsParenthesesEnd	=	-1;
			int	indexOfAchorStart = 0;
			
			String			newValue;
			StringBuilder 	oldValue;
			
			while(true)
			{
				indexOfBracketsParenthesesStart = sbData.IndexOf("(", indexOfBracketsParenthesesEnd + 1, false);
				if (indexOfBracketsParenthesesStart < 0)
				{
					break;
				}
				indexOfBracketsParenthesesEnd = sbData.IndexOf(")", indexOfBracketsParenthesesStart, false);
				indexOfAchorStart = sbData.IndexOf("<a", indexOfBracketsParenthesesStart, false);
				if (indexOfAchorStart > -1 && indexOfAchorStart < indexOfBracketsParenthesesEnd)
				{
					continue;	//Already has hyperlink
				}
				oldValue = 	sbData.SubString(indexOfBracketsParenthesesStart + 1, indexOfBracketsParenthesesEnd - indexOfBracketsParenthesesStart -1);
				newValue =	String.Format(AnchorFormat, oldValue);
				sbData = sbData.Replace
				(
					oldValue.ToString(),
					newValue,
					indexOfBracketsParenthesesStart,
					indexOfBracketsParenthesesEnd - indexOfBracketsParenthesesStart
				);
				indexOfBracketsParenthesesEnd += newValue.Length - oldValue.Length;
			}		
		}
		
		public static StringBuilder Query
		(
			string	bibleVersion,
			string	uri
		)
		{
			string	webContent 	=	WebHelper.GetPageAsString(uri);

			StringBuilder	sbData = new StringBuilder(webContent);
			
			BracketsParentheses(ref sbData);
		
			return sbData;
		}	

		public const string AnchorFormat = "<a href=\"http://e-comfort.ephraimtech.com/WordEngineering/WordUnion/scriptureReference.html?scriptureReference={0}\">{0}</a>";	 	
	}
}
