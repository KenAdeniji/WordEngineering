using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Lab_Assignment_7
{
    public partial class DisplayForm : Form
    {
        public DisplayForm(Customer customer)
        {
            InitializeComponent();
            Cell = customer.CellPhoneNumber;
            Fax = customer.FaxNumber;
            FirstName = customer.FirstName;
            LastName = customer.LastName;
            Phone = customer.PhoneNumber;
            Pin = customer.Pin;
        }

        protected string Cell
        {
            get { return cellTextBox.Text; }
            set { cellTextBox.Text = value; }
        }

        protected string Fax
        {
            get { return faxTextBox.Text; }
            set { faxTextBox.Text = value; }
        }

        protected string FirstName
        {
            get { return firstNameTextBox.Text; }
            set { firstNameTextBox.Text = value; }
        }

        protected string LastName
        {
            get { return lastNameTextBox.Text; }
            set { lastNameTextBox.Text = value; }
        }

        protected string Phone
        {
            get { return phoneTextBox.Text; }
            set { phoneTextBox.Text = value; }
        }

        protected string Pin
        {
            get { return pinTextBox.Text; }
            set { pinTextBox.Text = value; }
        }
    }
}
