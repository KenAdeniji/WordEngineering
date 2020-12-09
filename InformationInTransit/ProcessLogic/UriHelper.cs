#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
#endregion

namespace InformationInTransit.ProcessLogic
{
    public static partial class UriHelper
    {
        public static void Main(string[] argv)
        {
			Uri longUri = new Uri("http://www.google.com");
			Uri shortUri = longUri.ToTiny();
			System.Console.WriteLine
			(
				"LongUri: {0} | ShortUri: {1}",
				longUri,
				shortUri
			);	
        }

        /*
			2017-12-15	http://www.devx.com/tips/dot-net/c-sharp/get-dns-name-from-a-httprequest-in-c-170320075508.html
		*/
		public static string DomainName()
        {
			string dnsName = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority);
            return dnsName;
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

        public static string ExtractDomainName2(string Url)
        {
            if (Url.Contains(@"://"))
            {
                Url = Url.Split(new string[] { "://" }, 2, StringSplitOptions.None)[1];
            }
            return Url.Split('/')[0];
        }

        public static string ExtractDomainName3(string Url)
        {
            return System.Text.RegularExpressions.Regex.Replace(
            Url,
            @"^([a-zA-Z]+:\/\/)?([^\/]+)\/.*?$",
            "$2"
            );
        } 

        public static bool IsValidUrl(this string url) 
        {
            Regex regex = new Regex(@"http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?");
            return regex.IsMatch(url);
        }
		
		///<example>
		///Uri longUri = new Uri("http://www.google.com");
		///Uri shortUri = longUri.ToTiny();
		///</example>
		///<remarks>
		///http://extensionmethod.net/csharp/uri/totiny
		///</remarks>
		public static Uri ToTiny(this Uri longUri)
        {
            WebRequest request = WebRequest.Create
			(
				String.Format
				(
					"http://tinyurl.com/api-create.php?url={0}",
					UrlEncode(longUri.ToString())
                )
			);
            WebResponse response = request.GetResponse();
            Uri returnUri = null;
            using(System.IO.StreamReader reader = new System.IO.StreamReader(response.GetResponseStream()))
            {
                returnUri = new Uri(reader.ReadToEnd());
            }
            return returnUri;
        }

        private static string UrlEncode(string str)
        {
            if (str == null)
            {
                return null;
            }
            return UrlEncode(str, Encoding.UTF8);
        }
 
		private static string UrlEncode(string str, Encoding e)
        {
            if (str == null)
            {
                return null;
            }
            return Encoding.ASCII.GetString(UrlEncodeToBytes(str, e));
        }
		
        private static byte[] UrlEncodeToBytes(string str, Encoding e)
        {
            if (str == null)
            {
                return null;
            }
            byte[] bytes = e.GetBytes(str);
            return UrlEncodeBytesToBytesInternal(bytes, 0, bytes.Length, false);
        }
		
        private static byte[] UrlEncodeBytesToBytesInternal(byte[] bytes, int offset, int count, bool alwaysCreateReturnValue)
        {
            int num = 0;
            int num2 = 0;
            for (int i = 0; i < count; i++)
            {
                char ch = (char)bytes[offset + i];
                if (ch == ' ')
                {
                    num++;
                }
                else if (!IsSafe(ch))
                {
                    num2++;
                }
            }
            if ((!alwaysCreateReturnValue && (num == 0)) && (num2 == 0))
            {
                return bytes;
            }
            byte[] buffer = new byte[count + (num2 * 2)];
            int num4 = 0;
            for (int j = 0; j < count; j++)
            {
                byte num6 = bytes[offset + j];
                char ch2 = (char)num6;
                if (IsSafe(ch2))
                {
                    buffer[num4++] = num6;
                }
                else if (ch2 == ' ')
                {
                    buffer[num4++] = 0x2b;
                }
                else
                {
                    buffer[num4++] = 0x25;
                    buffer[num4++] = (byte)IntToHex((num6 >> 4) & 15);
                    buffer[num4++] = (byte)IntToHex(num6 & 15);
                }
            }
            return buffer;
        }
        
		internal static bool IsSafe(char ch)
        {
            if ((((ch >= 'a') && (ch <= 'z')) || ((ch >= 'A') && (ch <= 'Z'))) || ((ch >= '0') && (ch <= '9')))
            {
                return true;
            }
            switch (ch)
            {
                case '\'':
                case '(':
                case ')':
                case '*':
                case '-':
                case '.':
                case '_':
                case '!':
                    return true;
            }
            return false;
        }
		
        internal static char IntToHex(int n)
        {
            if (n <= 9)
            {
                return (char)(n + 0x30);
            }
            return (char)((n - 10) + 0x61);
        }
    }
}
