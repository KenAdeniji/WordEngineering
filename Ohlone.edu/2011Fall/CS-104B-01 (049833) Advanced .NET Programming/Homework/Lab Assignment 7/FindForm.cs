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
    public partial class FindForm : Form
    {
        public FindForm()
        {
            InitializeComponent();
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

        private void findButton_Click(object sender, EventArgs e)
        {
            Customer customer = new Customer
            {
                FirstName = FirstName,
                LastName = LastName,
                Pin = Pin,
                PhoneNumber = Phone,
                CellPhoneNumber = Cell,
                FaxNumber = Fax
            };

            IEnumerable<Customer> customers = Customer.Find(customer);

            dataGridViewCustomer.DataSource = customers;
        }
    }
}
