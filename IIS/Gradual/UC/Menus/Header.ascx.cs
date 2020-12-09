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
    #region UC_Menus_Header definition
    public partial class UC_Menus_Header : System.Web.UI.UserControl
    {
        #region Methods
        public void MenuCancel_Click(object sender, EventArgs e)
        {
            ToggleInitiateEnd();
            MenuCancelEventArgs menuCancelEventArgs = new MenuCancelEventArgs();
            OnMenuCancel(menuCancelEventArgs);
        }

        public void MenuDelete_Click(object sender, EventArgs e)
        {
            MenuDeleteEventArgs menuDeleteEventArgs = new MenuDeleteEventArgs();
            OnMenuDelete(menuDeleteEventArgs);
        }

        public void MenuEdit_Click(object sender, EventArgs e)
        {
            ToggleInitiateEnd();
            MenuEditEventArgs menuEditEventArgs = new MenuEditEventArgs();
            OnMenuEdit(menuEditEventArgs);
        }

        public void MenuNew_Click(object sender, EventArgs e)
        {
            ToggleInitiateEnd();
            MenuNewEventArgs menuNewEventArgs = new MenuNewEventArgs();
            OnMenuNew(menuNewEventArgs);
        }

        public void MenuSave_Click(object sender, EventArgs e)
        {
            ToggleInitiateEnd();
            MenuSaveEventArgs menuSaveEventArgs = new MenuSaveEventArgs();
            OnMenuSave(menuSaveEventArgs);
        }

        private void ToggleInitiateEnd()
        {
            if (End.Style["Display"] == "none")
            {
                Initiate.Style["Display"] = "none";
                End.Style["Display"] = "block";
            }
            else
            {
                Initiate.Style["Display"] = "block";
                End.Style["Display"] = "none";
            }
        }
        #endregion

        #region Event members
        public event MenuCancelEventHandler MenuCancel;
        public event MenuDeleteEventHandler MenuDelete;
        public event MenuEditEventHandler MenuEdit;
        public event MenuNewEventHandler MenuNew;
        public event MenuSaveEventHandler MenuSave;
        #endregion

        #region Raise events by invoking the delegates. The sender is always this, the current instance of the class.
        protected virtual void OnMenuCancel(MenuCancelEventArgs e)
        {
            MenuCancelEventHandler handler = MenuCancel;
            if (handler != null)
                handler(this, e);
        }

        protected virtual void OnMenuDelete(MenuDeleteEventArgs e)
        {
            MenuDeleteEventHandler handler = MenuDelete;
            if (handler != null)
                handler(this, e);
        }

        protected virtual void OnMenuEdit(MenuEditEventArgs e)
        {
            MenuEditEventHandler handler = MenuEdit;
            if (handler != null)
                handler(this, e);
        }

        protected virtual void OnMenuNew(MenuNewEventArgs e)
        {
            MenuNewEventHandler handler = MenuNew;
            if (handler != null)
                handler(this, e);
        }

        protected virtual void OnMenuSave(MenuSaveEventArgs e)
        {
            MenuSaveEventHandler handler = MenuSave;
            if (handler != null)
                handler(this, e);
        }
        #endregion
    }
    #endregion
}