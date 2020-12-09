#region Using directives
using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
#endregion

namespace WordEngineering
{
    #region MasterPages_MasterPage definition
    public partial class MasterPages_MasterPage : System.Web.UI.MasterPage
    {
        #region Event handlers
        protected void Page_Load(object sender, EventArgs e)
        {
            LoginView loginView = (LoginView)FindControl("LoginView1");
            LinkButton requestCreateUserWizard = (LinkButton)loginView.FindControl("RequestCreateUserWizard");
            if (requestCreateUserWizard != null)
            {
                requestCreateUserWizard.Visible = true;
            }
            LinkButton requestPasswordRecovery = (LinkButton)loginView.FindControl("RequestPasswordRecovery");
            if (requestPasswordRecovery != null)
            {
                requestPasswordRecovery.Visible = true;
            }
        }

        public void CreateUserWizard_SendingMail(object sender, MailMessageEventArgs e)
        {
            //Set MailMessage fields.
            //e.Message.IsBodyHtml = true;

            // Replace placeholder text in message body with information provided by the user.
            CreateUserWizard createUserWizard = (CreateUserWizard)sender;
            e.Message.Body.Replace("<%PasswordQuestion%>", createUserWizard.Question);
            e.Message.Body.Replace("<%PasswordAnswer%>", createUserWizard.Answer);
        }

        /// <summary>CreateUserWizard_SendingMailError</summary>
        public void CreateUserWizard_SendMailError
        (
            object sender,
            SendMailErrorEventArgs sendMailErrorEventArgs
        )
        {
            sendMailErrorEventArgs.Handled = true;
        }

        public void RequestCreateUserWizard_OnClick(object sender, EventArgs e)
        {
            LoginView loginView = (LoginView)FindControl("LoginView1");

            LinkButton requestCreateUserWizard = (LinkButton)loginView.FindControl("RequestCreateUserWizard");
            requestCreateUserWizard.Visible = false;

            CreateUserWizard createUserWizard = new CreateUserWizard();
            /*
            createUserWizard.SendingMail += new EventHandler(CreateUserWizard_SendingMail);
            createUserWizard.SendMailError += new EventHandler(CreateUserWizard_SendMailError);
            */
            createUserWizard.MailDefinition.BodyFileName = "/Membership/RegistrationEmail.html";
            createUserWizard.MailDefinition.Subject = "Create User Wizard";
            PlaceHolder placeHolderMembership = (PlaceHolder)FindControl("placeHolderMembership");
            placeHolderMembership.Controls.Add(createUserWizard);
        }

        public void RequestPasswordRecovery_OnClick(object sender, EventArgs e)
        {
            LoginView loginView = (LoginView)FindControl("LoginView1");

            LinkButton requestPasswordRecovery = (LinkButton)loginView.FindControl("RequestPasswordRecovery");
            requestPasswordRecovery.Visible = false;

            PasswordRecovery passwordRecovery = new PasswordRecovery();
            passwordRecovery.MailDefinition.BodyFileName = "/PasswordRecoveryEmail.txt";
            passwordRecovery.MailDefinition.Subject = "Thanks for PasswordRecovery!";
            passwordRecovery.MailDefinition.From = "ken@comfort";
            PlaceHolder placeHolderMembership = (PlaceHolder)FindControl("PlaceHolderMembership");
            placeHolderMembership.Controls.Add(passwordRecovery);
        }
        #endregion
    }
    #endregion
}