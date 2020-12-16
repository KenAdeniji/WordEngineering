using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace Assembly_Information
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            labelAssemblyTitle.Text = AssemblyTitle;
            RefreshClock();
        }

        /// <summary>
        /// Gets the assembly title.
        /// </summary>
        /// <value>The assembly title.</value>
        //  http://www.codekeep.net/snippets/170dc91f-1077-4c7f-ab05-8f82b9d1b682.aspx
        public string AssemblyTitle
        {
            get
            {
                // Get all Title attributes on this assembly
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                // If there is at least one Title attribute
                if (attributes.Length > 0)
                {
                    // Select the first one
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    // If it is not an empty string, return it
                    if (titleAttribute.Title != "")
                        return titleAttribute.Title;
                }
                // If there was no Title attribute, or if the Title attribute was the empty string, return the .exe name
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        private void timerClock_Tick(object sender, EventArgs e)
        {
            RefreshClock();
        }

        public void RefreshClock()
        {
            string today = DateTime.Today.ToShortDateString();
            DateToolStripStatusLabel.Text = today;
            string now = DateTime.Now.ToShortTimeString();
            TimeToolStripStatusLabel.Text = now;
        }
    }
}
