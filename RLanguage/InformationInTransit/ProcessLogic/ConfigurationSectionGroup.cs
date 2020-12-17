using System;
using System.Collections;
using System.Collections.Specialized;
using System.Text;

using System.Configuration;
using System.Web.Configuration;

namespace InformationInTransit.ProcessLogic
{
    public static partial class ConfigurationSectionGroup
    {
        public static NameValueCollection GetSectionGroup(string sectionGroup, string sectionName)
        {
            NameValueCollection nameValueCollection;
            nameValueCollection = (NameValueCollection)ConfigurationManager.GetSection
            (
                sectionGroup + "/" + sectionName
            );
            return nameValueCollection;
        }

        public static IDictionary ToDictionary(NameValueCollection nameValueCollection)
        {
            Hashtable hashtable = new Hashtable(nameValueCollection.Count);
            /*
            foreach(string key in nameValueCollection)
            {
                hashtable[key] = nameValueCollection[key];
            }
            */
            for (int index = 0; index < nameValueCollection.Count; ++index)
            {
                //hashtable.Add(nameValueCollection[index]);
                hashtable.Add(nameValueCollection.GetKey(index), nameValueCollection.GetValues(index));
            }
            return hashtable;
        }
    }
}
