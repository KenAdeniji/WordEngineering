using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Multiple_Document_Interface
{
    public partial class ChildOneForm : Form
    {
        private static ChildOneForm singletonInstance;

        private ChildOneForm()
        {
            InitializeComponent();
        }

        public static ChildOneForm SingletonInstance
        {
            get
            {
                if (singletonInstance == null)
                {
                    singletonInstance = new ChildOneForm();
                }
                return singletonInstance;
            }
        }

        private void ChildOneForm_FormClosing(object sender, EventArgs e)
        {
            //Delete the singleton when the form is closed.
            singletonInstance = null;
        }
    }
}
