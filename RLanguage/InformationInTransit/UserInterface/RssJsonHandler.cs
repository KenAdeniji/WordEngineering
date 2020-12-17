#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.ServiceModel;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Xml.Linq;
#endregion

namespace InformationInTransit.UserInterface
{
    #region RssJsonHandler definition
    public class RssJsonHandler : IHttpHandler
    {
        #region Methods
        public bool IsReusable
        {
            get { return false; }
        }

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            XDocument rssFeed = XDocument.Load("http://msdn.microsoft.com/msdnmag/rss/newrss.aspx");
            var posts = from item in rssFeed.Descendants("item")
                        select new
                        {
                            Title = item.Element("title").Value,
                            Link = item.Element("link").Value,
                            Description = item.Element("description").Value,
                            PubDate = DateTime.Parse(item.Element("pubDate").Value),
                        };
            var newPosts = from item in posts
                            where (DateTime.Now - item.PubDate).Days < 365
                            select item;
            List<FeedItem> itemsList = new List<FeedItem>();
            foreach (var item in newPosts)
            {
                itemsList.Add
                (
                    new FeedItem
                    {
                        Title = item.Title,
                        Link = item.Link,
                        Description = item.Description,
                        PubDate = item.PubDate
                    }
                );
            }
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(itemsList.GetType());
            serializer.WriteObject(context.Response.OutputStream, itemsList);
        }
        #endregion
    }
    #endregion

    [DataContract]
    public class FeedItem
    {
        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public string Link { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public DateTime PubDate { get; set; }
    }
}
