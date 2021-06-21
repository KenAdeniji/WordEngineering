using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;

using System.Collections;
using System.IO;
using System.Net;
using System.Web;
using System.Xml;

using JayMuntzCom;

using InformationInTransit.ProcessLogic;
using InformationInTransit.DataAccess;	

namespace InformationInTransit.ProcessCode
{
	/*
		2021-06-20	Created.	https://www.codeproject.com/Articles/11666/Dynamic-Holiday-Date-Calculator
	*/
    public partial class MoKanNiOFileNaNi //I just said, you should leave it alone.
    {
		public String DetermineFilename(String filename)
		{
			HttpContext context = HttpContext.Current;
			String serverMapPath = context.Server.MapPath("");

			if ( serverMapPath != null)
			{
				filename = Path.Combine( serverMapPath, filename );
			}
			
			return filename;
		}	

		public List<String> ExtractHolidayNames(String filename)
		{
			filename = DetermineFilename(filename);
			XmlDocument xmlDocument = RetrieveXmlDocument(filename);
			List<String> holidayNames = new List<String>();
		
			foreach (XmlNode xmlNode in xmlDocument.SelectNodes("/Holidays/Holiday"))
			{
				holidayNames.Add
				(
					xmlNode.Attributes["name"].Value.ToString()
				);	
			}
			
			return holidayNames;
		}	

		public List<DateTime> ProcessHolidayNames
		(
			String filename,
			String[] holidayNames,
			int	fromYear,
			int untilYear
		)
		{
			filename = DetermineFilename(filename);
			DateTime dated;
			List<DateTime> holidays = new List<DateTime>();
			for 
			(
				int currentYear = fromYear;
				currentYear <= untilYear;
				++currentYear
			)
			{	
				dated = new DateTime(currentYear, 1, 1);
				HolidayCalculator hc = new HolidayCalculator(dated, filename);
				foreach (HolidayCalculator.Holiday h in hc.OrderedHolidays)
				{
					if (Array.IndexOf(holidayNames, h.Name) >= 0)
					{	
						holidays.Add(h.Date);
					}	
				}
			}
			return holidays;
		}	
		
		public XmlDocument RetrieveXmlDocument
		(
			String filename
		)
		{
			HttpContext context = HttpContext.Current;
			String serverMapPath = context.Server.MapPath("");

			if ( serverMapPath != null)
			{
				filename = Path.Combine( serverMapPath, filename );
			}

			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.Load(filename);

			return (xmlDocument);
		}	
		
		public String FilenameConfigurationXml = @"..\HolidayCalculator.xml";
    }
}
