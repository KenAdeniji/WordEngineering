#region Using directives
using System;
using System.Collections.Generic;
using System.Text;

using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
#endregion

namespace InformationInTransit.UserInterface
{
    #region ControlHelper definition
    public static partial class ControlHelper
    {
        #region Methods
        public static void DisableControls(Control control)
        {
            if (control is WebControl)
            {
                ((WebControl)control).Enabled = false;
            }

            foreach (Control child in control.Controls)
            {
                DisableControls(child);
            }
        }

        public static void EnableControls(Control control, bool enable)
        {
            if (control is WebControl)
            {
                ((WebControl)control).Enabled = enable;
            }

            foreach (Control child in control.Controls)
            {
                EnableControls(child, enable);
            }
        }

        /// <summary>
        /// Replace any of the contained controls with literals
        /// </summary>
        public static void ObjectLiteralReplacement(this Control control)
        {
            for (int i = 0; i < control.Controls.Count; i++)
            {
                Control current = control.Controls[i];
                if (current is LinkButton)
                {
                    control.Controls.Remove(current);
                    control.Controls.AddAt(i, new LiteralControl((current as LinkButton).Text));
                }
                else if (current is ImageButton)
                {
                    control.Controls.Remove(current);
                    control.Controls.AddAt(i, new LiteralControl((current as ImageButton).AlternateText));
                }
                else if (current is HyperLink)
                {
                    control.Controls.Remove(current);
                    control.Controls.AddAt(i, new LiteralControl((current as HyperLink).Text));
                }
                else if (current is DropDownList)
                {
                    control.Controls.Remove(current);
                    control.Controls.AddAt(i, new LiteralControl((current as DropDownList).SelectedItem.Text));
                }
                else if (current is CheckBox)
                {
                    control.Controls.Remove(current);
                    control.Controls.AddAt(i, new LiteralControl((current as CheckBox).Checked ? "True" : "False"));
                }
                else if (current is RadioButtonList)
                {
                    control.Controls.Remove(current);
                    control.Controls.AddAt(i, new LiteralControl((current as RadioButtonList).SelectedValue));
                }
                if (current.HasControls())
                {
                    ObjectLiteralReplacement(current);
                }
            }
        }

        public static bool OnlyNonemptyCheck(Control root, TextBox nonempty)
        {
            return OnlyNonemptyCheck(root, new TextBox[] { nonempty });
        }

        public static bool OnlyNonemptyCheck(Control root, TextBox[] nonempties)
        {
            List<TextBox> containsText = new List<TextBox>(nonempties);
            bool isNullOrEmpty;
            foreach (TextBox retrieved in RetrieveControlsOfType<TextBox>(root))
            {
                isNullOrEmpty = String.IsNullOrEmpty(retrieved.Text.Trim());
                if (!isNullOrEmpty)
                {
                    if (containsText.Count == 0)
                    {
                        return false;
                    }
                    for (int containsIndex = 0; containsIndex < containsText.Count; ++containsIndex)
                    {
                        if (Object.ReferenceEquals(retrieved, containsText[containsIndex]))
                        {
                            containsText.Remove(containsText[containsIndex]);
                            break;
                        }
                    }
                }
            }
            return containsText.Count == 0 ? true : false;
        }

        public static IEnumerable<T> RetrieveControlsOfType<T>(Control root) where T : class
        {
            return RetrieveControlsOfType<T>(root, false);
        }

        public static IEnumerable<T> RetrieveControlsOfType<T>(Control root, bool excludeDerivedTypes) where T : class
        {
            // Determine the Type we need to look out for
            Type searchType = typeof(T);

            foreach (Control control in root.Controls)
            {
                if (!excludeDerivedTypes)
                {
                    if (control is T)
                    {
                        yield return (control as T);
                    }
                }
                else
                {
                    if (control.GetType().Equals(searchType))
                    {
                        yield return (control as T);
                    }
                }

                if (control.HasControls())
                {
                    foreach (T controlType in RetrieveControlsOfType<T>(control, excludeDerivedTypes))
                    {
                        yield return controlType;
                    }
                }
            }
        }

        public static string RetrieveFriendlyControlId(string renderedControlId)
        {
            int indexOfSeparator = renderedControlId.LastIndexOf("$");
            if (indexOfSeparator >= 0)
            {
                renderedControlId = renderedControlId.Substring(indexOfSeparator + 1);
            }
            return renderedControlId;
        }

        /// <summary>
        /// An Alternative is:
        /// if (Request.Form[customerSearchRequest.UniqueId] == customerSearchRequest.Text)
        /// </summary>
        public static Control RetrievePostBackControl(Page page)
        {
            Control control = null;

            string controlName = page.Request.Params.Get("__EVENTTARGET");
            if (!string.IsNullOrEmpty(controlName))
            {
                control = page.FindControl(controlName);
            }
            else
            {
                Control buttonControl;
                foreach (string pageControlName in page.Request.Form)
                {
                    if (pageControlName.EndsWith(".x") || pageControlName.EndsWith(".y"))
                    {
                        buttonControl = page.FindControl(pageControlName.Substring(0, pageControlName.Length - 2));
                    }
                    else
                    {
                        buttonControl = page.FindControl(pageControlName);
                    }

                    if (buttonControl is System.Web.UI.WebControls.Button || buttonControl is System.Web.UI.WebControls.ImageButton)
                    {
                        control = buttonControl;
                        break;
                    }
                }
            }
            return control;
        }

        public static string RetrieveOriginalId(string clientId)
        {
            string originalId = null;
            int indexOfSeparator = clientId.LastIndexOf("_");
            if (indexOfSeparator < 0)
            {
                originalId = clientId;
            }
            else
            {
                originalId = clientId.Substring(indexOfSeparator + 1);
            }
            return originalId;
        }

        public static bool ValidateAtLeastOneFieldCompleted(Control root)
        {
            foreach (TextBox textBox in RetrieveControlsOfType<TextBox>(root))
            {
                if (!String.IsNullOrEmpty(textBox.Text.Trim()))
                {
                    return true;
                }
            }
            return false;
        }

        public static StringBuilder RenderUserControl(Control objControl)
        {
            StringBuilder sb = new StringBuilder();
            HtmlTextWriter textWriter = new HtmlTextWriter(new StringWriter(sb));
            if (objControl != null)
            {
                objControl.RenderControl(textWriter);
            }
            return (sb);
        }

        public static void Reset(Control root)
        {
            foreach (TextBox textBox in RetrieveControlsOfType<TextBox>(root))
            {
                textBox.Text = String.Empty;
            }

            foreach (DropDownList dropDownList in RetrieveControlsOfType<DropDownList>(root))
            {
                dropDownList.ClearSelection();
            }

            foreach (RadioButtonList radioButtonList in RetrieveControlsOfType<RadioButtonList>(root))
            {
                radioButtonList.ClearSelection();
            }

            foreach (CheckBox checkBox in RetrieveControlsOfType<CheckBox>(root))
            {
                checkBox.Checked = false;
            }

            foreach (ListBox listBox in RetrieveControlsOfType<ListBox>(root))
            {
                listBox.Items.Clear();
            }
        }
        #endregion
    }
    #endregion
}