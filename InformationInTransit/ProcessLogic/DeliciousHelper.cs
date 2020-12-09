using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Net;
using System.Xml.XPath;

namespace InformationInTransit.ProcessLogic
{
    public static partial class DeliciousHelper
    {
        public static readonly Uri uri = new Uri("https://api.del.icio.us/v1/posts/all");

        public static void Main(string[] argv)
        {
            Bookmark(argv[0], argv[1]);
        }

        public static Collection<Post> Bookmark(string userName, string password)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.Credentials = new NetworkCredential(userName, password);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            XPathDocument xml = new XPathDocument(response.GetResponseStream());
            XPathNavigator navigator = xml.CreateNavigator();

            Collection<Post> posts = new Collection<Post>();
            foreach(XPathNavigator node in navigator.Select("/posts/post"))
            {
                string description = node.GetAttribute("description", "");
                string href = node.GetAttribute("href", "");
                System.Console.WriteLine(description + " | " + href);

                Post post = new Post
                {
                    Description = description,
                    Href = href
                };
                posts.Add(post);
            }
            return posts;
        }

        public partial class Post
        {
            public string Description { get; set; }
            public string Href { get; set; }
        }
    }
}
