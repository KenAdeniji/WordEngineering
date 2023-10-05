using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.Services;

public partial class WebServiceRequester_WebLogIPWhoIs : System.Web.UI.Page
{
    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        ip_addresses.Text = "";
        List<string> IPs = new List<string>();
        StringBuilder sb = new StringBuilder();
        DateTime date = Calendar1.SelectedDate;

        string filedate = string.Format("{0:yyMMdd}", date);
        string path = @"C:\WINDOWS\system32\LogFiles\W3SVC1\ex" + filedate + ".log";
        
        if (File.Exists(path))
        {
            string content;
            using (StreamReader sr = new StreamReader(path))
            {
                content = sr.ReadToEnd();
            }

            Regex re = new Regex(@"\w\d{1,3}\.\d{1,3}\.\d{1,3}.\d{1,3}\w");
            MatchCollection mc = re.Matches(content);

            foreach (Match mt in mc)
            {
                if (mt.ToString() != "xxx.xxx.xxx.xxx")
                    IPs.Add(mt.ToString());
            }

            var result = IPs.Select(i => i).Distinct().ToList();
            foreach (string ip in result)
            {
                sb.Append("<span>" + ip + "</span>\n");
            }

            ip_addresses.Text = "<pre>" + sb.ToString() + "</pre>";
        }
        else
        {
            ip_addresses.Text = "No logs available for that date";
        }
    }

    private static string GetHtmlPage(string url)
    {
        String result;
        WebResponse response;
        WebRequest request = HttpWebRequest.Create(url);
        response = request.GetResponse();
        using (StreamReader sr = new StreamReader(response.GetResponseStream()))
        {
            result = sr.ReadToEnd();
            sr.Close();
        }
        return result;
    }

    private static string PostHtmlPage(string url, string post)
    {
        ASCIIEncoding enc = new ASCIIEncoding();
        byte[] data = enc.GetBytes(post);
        WebRequest request = HttpWebRequest.Create(url);
        request.Method = "POST";
        request.ContentType = "application/x-www-form-urlencoded";
        request.ContentLength = data.Length;
        Stream stream = request.GetRequestStream();
        stream.Write(data, 0, data.Length);
        stream.Close();
        WebResponse response = request.GetResponse();
        string result;
        using (StreamReader sr = new StreamReader(response.GetResponseStream()))
        {
            result = sr.ReadToEnd();
            sr.Close();
        }
        return result;
    }

    [WebMethod]
    public static string GetWhois(string ip)
    {
        string response = "";
        string arin = "https://ws.arin.net/whois/?queryinput=" + ip;
        string ripe = "http://www.db.ripe.net/whois?form_type=simple&full_query_string=&searchtext=" + ip + "&do_search=Search";
        string apnic = "http://wq.apnic.net/apnic-bin/whois.pl";
        string lacnic = "http://lacnic.net/cgi-bin/lacnic/whois?lg=EN";
        string lacnicFields = "query=" + ip;
        string apnicFields = ".cgifields=object_type&.cgifields=reverse_delegation_domains&do_search=Search&" +
                             "form_type=advancedfull_query_string=&inverse_attributes=None&object_type=All&searchtext=" + ip;

        response = GetHtmlPage(arin);
        Regex pre = new Regex(@"<pre>[.\n\W\w]*</pre>", RegexOptions.IgnoreCase);
        Match m = pre.Match(response);

        if (pre.IsMatch(response))
        {
            if (m.Value.IndexOf("OrgName:    RIPE Network Coordination Centre") > 0)
            {
                response = GetHtmlPage(ripe);
                m = pre.Match(response);
            }
            else if (m.Value.IndexOf("OrgName:    Asia Pacific Network Information Centre") > 0)
            {
                response = PostHtmlPage(apnic, apnicFields);
                m = pre.Match(response);
            }
            else if (m.Value.IndexOf("OrgName:    Latin American and Caribbean IP address Regional Registry") > 0)
            {
                response = PostHtmlPage(lacnic, lacnicFields);
                m = pre.Match(response);
            }
            return m.Value;
        }
        else
        {
            return "<pre>No Data</pre>";
        }
    }
}
