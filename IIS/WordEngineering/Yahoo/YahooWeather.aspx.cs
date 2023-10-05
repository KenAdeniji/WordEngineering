using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Text;
using System.Xml;
using System.Xml.XPath;

namespace WordEngineering.Yahoo
{
    public partial class YahooWeather : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            WeatherXmlDocument();
        }

        protected void WeatherXmlDocument()
        {
            string uri = String.Format(Uri, ZipCode);
            // Create a new XmlDocument  
            XmlDocument doc = new XmlDocument();

            // Load data  
            doc.Load(uri);

            // Set up namespace manager for XPath  
            XmlNamespaceManager ns = new XmlNamespaceManager(doc.NameTable);
            ns.AddNamespace("yweather", "http://xml.weather.yahoo.com/ns/rss/1.0");

            // Get forecast with XPath  
            XmlNodeList nodes = doc.SelectNodes("/rss/channel/item/yweather:forecast", ns);

            // You can also get elements based on their tag name and namespace,  
            // though this isn't recommended  
            //XmlNodeList nodes = doc.GetElementsByTagName("forecast",   
            //                          "http://xml.weather.yahoo.com/ns/rss/1.0");  

            StringBuilder sb = new StringBuilder();

            foreach (XmlNode node in nodes)
            {
                Console.WriteLine
                (
                    "{0}: {1}, {2}F - {3}F",
                    node.Attributes["day"].InnerText,
                    node.Attributes["text"].InnerText,
                    node.Attributes["low"].InnerText,
                    node.Attributes["high"].InnerText
                );
                /*
                Response.Output.Write
                (
                    "{0}: {1}, {2}F - {3}F<br/>",
                    node.Attributes["day"].InnerText,
                    node.Attributes["text"].InnerText,
                    node.Attributes["low"].InnerText,
                    node.Attributes["high"].InnerText
                );
                */ 
                sb.AppendFormat
                (
                    "{0}: {1}, {2}F - {3}F<br/>",
                    node.Attributes["day"].InnerText,
                    node.Attributes["text"].InnerText,
                    node.Attributes["low"].InnerText,
                    node.Attributes["high"].InnerText
                );
            }
            Forecast = sb.ToString();
        }

        protected void WeatherXmlReader()
        {
            string uri = String.Format(Uri, ZipCode);

            // Retrieve XML document  
            XmlTextReader reader = new XmlTextReader(uri);

            // Skip non-significant whitespace  
            reader.WhitespaceHandling = WhitespaceHandling.Significant;

            // Read nodes one at a time  
            while (reader.Read())
            {
                // Print out info on node  
                Console.WriteLine("{0}: {1}", reader.NodeType.ToString(), reader.Name);
                Response.Output.Write("{0}: {1} <br/>", reader.NodeType.ToString(), reader.Name);
            }
        }

        protected void WeatherXPathDocument()
        {
            string uri = String.Format(Uri, ZipCode);

            // Create a new XmlDocument  
            XPathDocument doc = new XPathDocument(uri);  
      
            // Create navigator  
            XPathNavigator navigator = doc.CreateNavigator();  
      
            // Set up namespace manager for XPath  
            XmlNamespaceManager ns = new XmlNamespaceManager(navigator.NameTable);  
            ns.AddNamespace("yweather", "http://xml.weather.yahoo.com/ns/rss/1.0");  
      
            // Get forecast with XPath  
            XPathNodeIterator nodes = navigator.Select("/rss/channel/item/yweather:forecast", ns);

            StringBuilder sb = new StringBuilder();

            while(nodes.MoveNext())  
            {  
                XPathNavigator node = nodes.Current;  
      
                Console.WriteLine
                (
                    "{0}: {1}, {2}F - {3}F",  
                    node.GetAttribute("day", ns.DefaultNamespace),  
                    node.GetAttribute("text", ns.DefaultNamespace),  
                    node.GetAttribute("low", ns.DefaultNamespace),  
                    node.GetAttribute("high", ns.DefaultNamespace)
                );

                sb.AppendFormat
                (
                    "{0}: {1}, {2}F - {3}F",
                    node.GetAttribute("day", ns.DefaultNamespace),
                    node.GetAttribute("text", ns.DefaultNamespace),
                    node.GetAttribute("low", ns.DefaultNamespace),
                    node.GetAttribute("high", ns.DefaultNamespace)
                );
            }  
        }

        protected string Forecast
        {
            get { return forecast.Text.Trim(); }
            set { forecast.Text = value; }
        }

        protected string ZipCode
        {
            get { return zipCode.Text.Trim(); }
            set { zipCode.Text = value; }
        }

        public const string Uri = "http://xml.weather.yahoo.com/forecastrss?p={0}";

    }
}
