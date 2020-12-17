#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Net;
using System.Reflection;
using System.Web;
#endregion

namespace InformationInTransit.ProcessLogic
{
    #region TechnoratiApi definition
    public partial class TechnoratiApi
    {
        #region Properties
        public string DataFormat
        {
            get { return dataFormat; }
        }

        public string Key
        {
            get { return key; }
            set { key = value; }
        }

        public string Keyword
        {
            get { return keyword; }
            set { keyword = value; }
        }

        public APIQuery Operation
        {
            get { return operation; }
            set { operation = value; }
        }

        public string RequestUri
        {
            get
            {
                string requestUri = ServiceEndpoint + "/" + 
                    Operation.ToString().ToLower() + "?" +
                    "url=" + Url + "&" +
                    "key=" + Key + "&" +
                    "format=" + DataFormat + "&" +
                    "version=" + Version;
                switch (Operation)
                {
                    case APIQuery.Dailycounts:
                        requestUri += "&q=" + Keyword;
                        break;

                    case APIQuery.Getinfo:
                        requestUri += "&username=" + Username;
                        break;
                }
                return requestUri;
            }
        }

        public string Url
        {
            get 
            {
                return String.IsNullOrEmpty(url) ? DefaultUrl : url;
            }
            set { url = value; }
        }

        public string Username
        {
            get { return username; }
            set { username = value; } 
        }

        public int Start
        {
            get { return start; }
        }

        public string Version
        {
            get { return version; }
        }
        #endregion

        #region Methods
        public static Dictionary<string, string> AvailableAPIQueries()
        {
            Dictionary<string, string> availableAPIQueries = new Dictionary<string, string>();
            string[] apiQueryNames = Enum.GetNames(typeof(APIQuery));
            int[] apiQueryValues = (int[]) Enum.GetValues(typeof(APIQuery));
            for (int index = 0; index <= apiQueryNames.GetUpperBound(0); index++)
            {
                string enumDescription = EnumHelper.ToDescription( (APIQuery) apiQueryValues[index]);
                availableAPIQueries.Add(apiQueryNames[index], enumDescription);
            }
            return availableAPIQueries;
        }

        public static string RequestData(TechnoratiApi technoratiApi)
        {
            string resultSet = null;
            try
            {
                WebRequest request = WebRequest.Create(technoratiApi.RequestUri);
                WebResponse response = request.GetResponse();

                StreamReader stream = new StreamReader(response.GetResponseStream());

                resultSet = stream.ReadToEnd();
            }

            catch (WebException) { }

            return resultSet;
        }
        #endregion

        #region Fields
        private string dataFormat = DefaultDataFormat;
        private string key = null;
        private string keyword = null;
        /// <summary>
        /// For example, cosmos, search, tag, dailycounts, toptags, bloginfo, blogposttags, getinfo.
        /// </summary>
        private APIQuery operation = DefaultOperation;
        private int start = 1;
        private string url = DefaultUrl;
        private string username = null;
        private string version = DefaultVersion;
        #endregion

        #region Enumerations
        public enum APIQuery
        {
            [Description("Blogs linking to a given URL.")]
            Cosmos,
            [Description("Blog posts featuring a given keyword or phrase.")]
            Search,
            [Description("Blog posts tagged with a specific topic.")]
            Tag,
            [Description("Daily counts of posts containing the queried keyword.")]
            Dailycounts,
            [Description("Top tags indexed by Technorati.")]
            Toptags,
            [Description("Information about a specific blog URL such as link counts, rank, and available feeds.")]
            Bloginfo,
            [Description("The top tags used by a specific blog.")]
            Blogposttags,
            [Description("Information about a Technorati member such as full name and other blogs by the same author.")]
            Getinfo
        }
        #endregion

        #region Constants
        private const string DefaultDataFormat = "xml";
        public const int DefaultOperation = (int)APIQuery.Cosmos;
        public const string DefaultUrl = "technorati.com";
        public const string DefaultVersion = "0.9";
        public const string ServiceEndpoint = "http://api.technorati.com";
        #endregion
    }
    #endregion
}
