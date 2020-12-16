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
    public partial class MainForm : Form
    {
        public MainForm()
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
            get {return firstNameTextBox.Text;}
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

        protected int CustomersCollectionCount
        {
            get 
            {
                return Int32.Parse(customersCollectionCount.Text); 
            }
            set { customersCollectionCount.Text = value.ToString(); }
        }

        private void addCustomerButton_Click(object sender, EventArgs e)
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

            customer.Add();
            customersListBox.Items.Add(customer.Header);

            ++CustomersCollectionCount;
        }

        private void removeCustomerButton_Click(object sender, EventArgs e)
        {
            int customerCollectionIndex = customersListBox.SelectedIndex;
            if (customerCollectionIndex < 0)
            {
                MessageBox.Show("Please select customer, prior to attempting to delete the selected customer.");
                return;
            }
            Customer.Remove(customerCollectionIndex);
            customersListBox.Items.RemoveAt(customerCollectionIndex);
            --CustomersCollectionCount;
        }

        private void displaySelectedCustomerButton_Click(object sender, EventArgs e)
        {
            int customerCollectionIndex = customersListBox.SelectedIndex;
            if (customerCollectionIndex < 0)
            {
                MessageBox.Show("Please select customer, prior to attempting to display the selected customer.");
                return;
            }
            String collate = Customer.Collate(customerCollectionIndex);
            MessageBox.Show(collate, "Customer");
        }

        private void ShowSelectedCustomerButton_Click(object sender, EventArgs e)
        {
            int customerCollectionIndex = customersListBox.SelectedIndex;
            if (customerCollectionIndex < 0)
            {
                MessageBox.Show("Please select customer, prior to attempting to show the selected customer.");
                return;
            }
            Customer customer = Customer.Select(customerCollectionIndex);
            DisplayForm displayForm = new DisplayForm(customer);
            displayForm.ShowDialog();
        }

        private void findCustomerButton_Click(object sender, EventArgs e)
        {
            FindForm findForm = new FindForm();
            findForm.ShowDialog();
        }
    }
}
