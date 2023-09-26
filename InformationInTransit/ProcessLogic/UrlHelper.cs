#region Using directives
using System;
using System.Text;
#endregion

/*
	InternetCountryCodeTopLevelDomain_ccTLD(String url);	//Code 2023-09-25T15:35:00...2023-09-25T16:11:00
	InternetCountryCodeTopLevelDomain_ccTLD(String url);	//Debug 2023-09-25T16:59:00...2023-09-25T18:00:00
*/	
//namespace InformationInTransit.ProcessLogic
//{
    public static partial class UrlHelper
    {
        public static void Main(string[] argv)
        {
			System.Console.WriteLine
			(
				InternetCountryCodeTopLevelDomain_ccTLD
				(
					String.Join(".", argv)
				)	
			);	
        }

        public static string ExtractDomainName(string Url)
        {
            int pos = Url.IndexOf("://");
            if (pos == -1 || pos > 5)
            {
                Url = "http://" + Url;
            }
            return new Uri(Url).Host;
        }

		public static string InternetCountryCodeTopLevelDomain_ccTLD
		(
			string url
		)
		{
			String domainName = ExtractDomainName(url);
			String[] domainNameArray = domainName.Split('.');
			//String domainNameJoin = string.Join(".", domainNameArray.Skip(1));
			StringBuilder sb = new StringBuilder();
			for 
			(
				int index = 1, length = domainNameArray.Length;
				index < length;
				++index
			)
			{
				sb.Append('.');
				sb.Append(domainNameArray[index]);
			}		
			return sb.ToString();
		}		
    }
//}
