#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Net;
using System.Net.Mail;
#endregion

namespace InformationInTransit.ProcessLogic
{
    #region GoogleMailHelper definition
    public partial class GoogleMailHelper
    {
        #region Methods
        public static void Main(string[] argv)
        {
            SmtpClient mailClient = new SmtpClient("smtp.gmail.com", 587);
            mailClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            mailClient.EnableSsl = true;
            NetworkCredential networkCredential = new NetworkCredential("KehindeAdeniji@gmail.com", "password");
            mailClient.UseDefaultCredentials = false;
            mailClient.Credentials = networkCredential;
            mailClient.Send("KehindeAdeniji@gmail.com", "KehindeAdeniji@gmail.com", "Subject", "Body");
        }
        #endregion
    }
    #endregion
}
