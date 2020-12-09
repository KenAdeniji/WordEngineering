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
using System.Text.RegularExpressions;

using InformationInTransit.DataAccess;
using InformationInTransit.ProcessLogic;

namespace InformationInTransit.ProcessLogic
{
	/*
		2017-10-12	Created.
	*/
	public static partial class BibleBookGroupsHelper
	{
		public static DataSet Query()
		{
			DataSet	dataSet = (DataSet)DataCommand.DatabaseCommand
			(
				GroupQuery,
				CommandType.Text,
				DataCommand.ResultType.DataSet
			);
			return dataSet;
		}
		
		public const string GroupQuery = "SELECT Minor, Commentary FROM WordEngineering..ActToGod WHERE Major = 'Bible Book Group' ORDER BY Minor";
		
		public static readonly Collection<BookGroup> BookGroups = new Collection<BookGroup>
		{
			new BookGroup{ Title = "Pentateuch", BookIDs = new System.Collections.Generic.List<int>(){1,2,3,4,5}},
			new BookGroup{ Title = "Major Prophets", BookIDs = new System.Collections.Generic.List<int>(){23, 24, 25, 26, 27}},
			new BookGroup{ Title = "Minor Prophets", BookIDs = new System.Collections.Generic.List<int>(){28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39}},
			new BookGroup{ Title = "Gospel", BookIDs = new System.Collections.Generic.List<int>(){40, 41, 42, 43}},
			new BookGroup{ Title = "Apocalyptic", BookIDs = new System.Collections.Generic.List<int>(){27, 66}}
		};
		
		public class BookGroup
		{
			public String Title { get; set; }
			public System.Collections.Generic.List<int> BookIDs { get; set; }
		}	
	}
}
