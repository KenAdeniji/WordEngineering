using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mail;
using System.Text;

namespace InformationInTransit.ProcessLogic
{
    public static partial class YahooMailHelper
    {
        /// <summary>
        /// http://codekeep.net/snippets/1acbeb56-9e7f-447d-8527-27fa3f8ce3bb.aspx
        /// 2014-04-03 Soh Weng Hong
        /// </summary>
        public static void SendMail()
        {
            MailMessage message = new MailMessage();
            message.From = "Weng Hong";
            message.To = "emailaddress";
            message.Subject = "ddddd";
            message.BodyFormat = MailFormat.Text;
            message.Body = "yyyyy";

            message.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserverport", 25);
            message.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusing", 2);
            message.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", 1);
            message.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", "username");
            message.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", "password");
            SmtpMail.SmtpServer = "smtp.mail.yahoo.com";

            SmtpMail.Send(message);
        }
    }
}
