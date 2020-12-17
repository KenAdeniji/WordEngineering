#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using Outlook = Microsoft.Office.Interop.Outlook;
//using MSOUTL;
#endregion

/*
 * http://support.microsoft.com/?kbid=819398
 */

/*
namespace InformationInTransit.ProcessLogic
{
    #region OutlookHelper definition
    public static partial class OutlookHelper
    {
        private static Outlook.Application outlook;

        #region Methods
        public static void Main(string[] argv)
        {
            CreateAppointmentItem();
        }

        public static void SendMessage()
        {
            Microsoft.Office.Interop.Outlook.Application app = null;
            Microsoft.Office.Interop.Outlook.NameSpace nameSpace = null;
            Microsoft.Office.Interop.Outlook.MailItem memo = null;
            Microsoft.Office.Interop.Outlook.MAPIFolder outbox = null;

            try
            {

                app = new Microsoft.Office.Interop.Outlook.Application();
                nameSpace = app.GetNamespace("MAPI");
                nameSpace.Logon(null, null, false, false);

                outbox = nameSpace.GetDefaultFolder(Microsoft.Office.Interop.Outlook.OlDefaultFolders.olFolderDrafts);

                memo = (Microsoft.Office.Interop.Outlook.MailItem)app.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem);
                memo.To = "Anthony.Patton@Ingenix.com";
                memo.Subject = "TechRepublic.com Test";
                memo.Body = "Hello there";
                memo.SaveSentMessageFolder = outbox;
                memo.Send();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static void CreateTaskItem(Outlook.Application outlookApp)
        {
            // Create a new TaskItem.
            Outlook.TaskItem newTask = (Outlook.TaskItem)outlookApp.CreateItem(Outlook.OlItemType.olTaskItem);
            // Configure the task at hand and save it.
            newTask.Body = "Don't forget to send DOM the links...";
            newTask.DueDate = DateTime.Now;
            newTask.Importance = Outlook.OlImportance.olImportanceHigh;
            newTask.Subject = "Get DOM to stop bugging me.";
            newTask.Save();
        }

        public static void CreateEmailMessage()
        {
            //Initialize the envelope values.
            string strTo = "kadeniji@ephraimtech.com";
            string strBCC = "kadeniji@ephraimtech.com";
            string strCC = "kadeniji@ephraimtech.com";
            string strSubject = "Outlook Automation";
            string strBody = "HTMLPage1.htm";

            //Automate the Word document.
            wApp = new Word.Application();
            wApp.Visible = false;
            object template = System.Reflection.Missing.Value;
            object newTemplate = System.Reflection.Missing.Value;
            object documentType = Word.WdNewDocumentType.wdNewEmailMessage;
            object visible = false;
            wApp.Visible = false;
            Word._Document doc = wApp.Documents.Add(
                ref template,
                ref newTemplate,
                ref documentType,
                ref visible);

            //Automate the Outlook mail item.
            Outlook.MailItemClass mItem = (Outlook.MailItemClass)doc.MailEnvelope.Item;
            mItem.To = strTo;
            mItem.BCC = strBCC;
            mItem.CC = strCC;
            mItem.Subject = strSubject;
            mItem.BodyFormat = Outlook.OlBodyFormat.olFormatHTML;
            mItem.HTMLBody = GetString(strBody);
            mItem.ItemEvents_Event_Close += new Outlook.ItemEvents_CloseEventHandler(this.wApp_Close);
        }

        public static void CreateAppointmentItem()
        {
            try
            {
                outlook = new Outlook.Application();
                Outlook.NameSpace mapiNamespace = outlook.GetNamespace("MAPI");
                Outlook.MAPIFolder mapiFolder = mapiNamespace.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderCalendar);
                mapiFolder.Display();

                Outlook.AppointmentItem appointment = (Outlook.AppointmentItem)outlook.CreateItem(
                Outlook.OlItemType.olAppointmentItem);
                appointment.Start = DateTime.Now.AddMinutes(1);
                appointment.Duration = 60;
                appointment.Subject = "Coffee";
                appointment.Body = "Go to cafe to get more coffee";
                appointment.Location = "London";
                appointment.Save();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
            outlook.Quit();
            outlook = null;
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
        #endregion
    }
    #endregion
}
*/