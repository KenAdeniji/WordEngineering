using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace WordEngineering
{
    public static partial class CultureInfoHelper
    {
        public static void Main(string[] argv)
        {
            List<string> list = RetrieveCultureInfo();
			System.Linq.IOrderedEnumerable<System.Collections.Generic.KeyValuePair<string, string>> culture = FetchCultureInfo();
        }

        public static List<string> RetrieveCultureInfo()
        {
            // get culture names
            List<string> list = new List<string>();
            int uniqueCulture = 0;
            foreach (CultureInfo ci in CultureInfo.GetCultures(CultureTypes.AllCultures))
            {
                if (ci.Name.Length == 2)
                {
                    ++uniqueCulture;
                }
                string specName = "(none)";
                try { specName = CultureInfo.CreateSpecificCulture(ci.Name).Name; }
                catch { }
                list.Add(String.Format("{0,-12}{1,-12}{2}", ci.Name, specName, ci.EnglishName));
            }

            list.Sort();  // sort by name

            // write to console
            Console.WriteLine("CULTURE   SPEC.CULTURE  ENGLISH NAME");
            Console.WriteLine("--------------------------------------------------------------");
            foreach (string str in list)
                Console.WriteLine(str);
            System.Console.WriteLine("{0} | {1}", list.Count, uniqueCulture);
            return (list);
        }
		
		public static System.Linq.IOrderedEnumerable<System.Collections.Generic.KeyValuePair<string, string>> FetchCultureInfo()
		{	
			Dictionary<string, string> cultureDetails = new Dictionary<string, string>();
			foreach (CultureInfo cultureInfo in CultureInfo.GetCultures(CultureTypes.SpecificCultures))
			{
				RegionInfo regionInfo = new RegionInfo(cultureInfo.Name);
				if (!cultureDetails.ContainsKey(regionInfo.EnglishName))
				{
					cultureDetails.Add(regionInfo.EnglishName, regionInfo.Name);
				}
			}	
			var orderedCultureDetails = cultureDetails.OrderBy(x => x.Key);
			foreach(System.Collections.Generic.KeyValuePair<string,string> cultureName in orderedCultureDetails)
			{
				System.Console.WriteLine(cultureName);
			}
			return orderedCultureDetails;
		}
	}	
}
