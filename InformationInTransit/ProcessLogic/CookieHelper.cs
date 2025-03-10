﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Net;
using System.Web;

namespace InformationInTransit.ProcessLogic
{
    public static partial class CookieHelper
    {
        public static void Main(string[] argv)
        {
            ParseCookie(argv);
        }

        public static void ParseCookie(string[] argv)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(argv[0]);
            request.CookieContainer = new CookieContainer();

            HttpWebResponse response = (HttpWebResponse) request.GetResponse();
            
            // Print the properties of each cookie.
            foreach (Cookie cook in response.Cookies)
            {
                Console.WriteLine("Cookie:");
                Console.WriteLine("{0} = {1}", cook.Name, cook.Value);
                Console.WriteLine("Domain: {0}", cook.Domain);
                Console.WriteLine("Path: {0}", cook.Path);
                Console.WriteLine("Port: {0}", cook.Port);
                Console.WriteLine("Secure: {0}", cook.Secure);

                Console.WriteLine("When issued: {0}", cook.TimeStamp);
                Console.WriteLine("Expires: {0} (expired? {1})", 
                    cook.Expires, cook.Expired);
                Console.WriteLine("Don't save: {0}", cook.Discard);    
                Console.WriteLine("Comment: {0}", cook.Comment);
                Console.WriteLine("Uri for comments: {0}", cook.CommentUri);
                Console.WriteLine("Version: RFC {0}" , cook.Version == 1 ? "2109" : "2965");

                // Show the string representation of the cookie.
                Console.WriteLine ("String: {0}", cook.ToString());
            }
        }

        public static void Write(string name, string subkey)
        {
            HttpCookie myCookie = new HttpCookie("UserSettings");
            myCookie["Font"] = "Arial";
            myCookie["Color"] = "Blue";
            myCookie.Expires = DateTime.Now.AddDays(1d);
            HttpContext.Current.Response.Cookies.Add(myCookie);
        }

    }
}

