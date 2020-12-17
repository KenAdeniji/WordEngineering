using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;//
using System.Linq;
using System.Net;//
using System.Text;
using System.Windows.Forms;

namespace InformationInTransit.ProcessLogic
{
	///<remarks>
	///	2016-02-18	http://www.codeproject.com/Tips/1076400/Twitter-API-for-beginners
	///	https://www.base64encode.org/
	///</remarks>
    public partial class TwitterHelper
    {
        //TODO obfuscation
        public const string Credentials = "UFYzVXJxbnYzVzJQcE5UVXNCSnkyaGtweTpDdjg0ZnJidkpGQTdsbnFrbzFkZ1hUSFhTdE8wN2xTdWt3RWdLeVBXR3RjRzhKR3Zjaw==";

		public const string TwitterRequest = 
			"https://api.twitter.com/1.1/statuses/user_timeline.json?count=3&screen_name={0}";
        public static void Main(string[] argv)
        {
            Process("twitterapi");
        }

        public static string Process(string screen_name)
        {
			string resultSet = "";
			//obtaining access_token
            string access_token = "";
            var post = WebRequest.Create("https://api.twitter.com/oauth2/token") as HttpWebRequest;
            post.Method = "POST";
            post.ContentType = "application/x-www-form-urlencoded";
            post.Headers[HttpRequestHeader.Authorization] = "Basic " + Credentials;
            var reqbody = Encoding.UTF8.GetBytes("grant_type=client_credentials");
            post.ContentLength = reqbody.Length;
            using (var req = post.GetRequestStream())
            {
                req.Write(reqbody, 0, reqbody.Length);
            }
            try
            {
                string respbody = null;
                using (var resp = post.GetResponse().GetResponseStream())//there request sends
                {
                    var respR = new StreamReader(resp);
                    respbody = respR.ReadToEnd();
                }

                //TODO use a library to parse json
                access_token = respbody.Substring(respbody.IndexOf("access_token\":\"") + "access_token\":\"".Length, respbody.IndexOf("\"}") - (respbody.IndexOf("access_token\":\"") + "access_token\":\"".Length));
            }
            catch //if credentials are not valid (403 error)
            {
                //TODO
            }

            //rest api using

            string twitterRequest = String.Format(TwitterRequest, screen_name);
			var gettimeline = WebRequest.Create(twitterRequest) as HttpWebRequest;
            gettimeline.Method = "GET";
            gettimeline.Headers[HttpRequestHeader.Authorization] = "Bearer " + access_token;
            try
            {
                string respbody = null;
                using (var resp = gettimeline.GetResponse().GetResponseStream())//there request sends
                {
                    var respR = new StreamReader(resp);
                    respbody = respR.ReadToEnd();
                }

                //TODO use a library to parse json
                Console.WriteLine(respbody);
				resultSet = respbody;
            }
            catch //401 (access token invalid or expired)
            {
                //TODO
            }

            //invalidating un necessary access token

            var inv = WebRequest.Create("https://api.twitter.com/oauth2/invalidate_token") as HttpWebRequest;
            inv.Method = "POST";
            inv.ContentType = "application/x-www-form-urlencoded";
            inv.Headers[HttpRequestHeader.Authorization] = "Basic " + Credentials;
            var reqbodyinv = Encoding.UTF8.GetBytes("access_token=" + access_token);
            inv.ContentLength = reqbodyinv.Length;
            using (var req = inv.GetRequestStream())
            {
                req.Write(reqbodyinv, 0, reqbodyinv.Length);
            }
            try
            {
                post.GetResponse();
            }
            catch //token not invalidated
            {
                //TODO
            }
			
			return resultSet;
        }
    }
}
