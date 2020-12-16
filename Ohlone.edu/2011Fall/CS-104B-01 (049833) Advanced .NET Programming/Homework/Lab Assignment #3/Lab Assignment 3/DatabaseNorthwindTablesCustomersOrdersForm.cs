using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using LabAssignment3ClassLibrary;

namespace Lab_Assignment_3
{
    public partial class DatabaseNorthwindTablesCustomersOrdersForm : Form
    {
        public DatabaseNorthwindTablesCustomersOrdersForm()
        {
            InitializeComponent();
        }

        private void DatabaseNorthwindTablesCustomersOrdersForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'northwindDataSet.Orders' table. You can move, or remove it, as needed.
            this.ordersTableAdapter.Fill(this.northwindDataSet.Orders);
            // TODO: This line of code loads data into the 'northwindDataSet.Customers' table. You can move, or remove it, as needed.
            this.customersTableAdapter.Fill(this.northwindDataSet.Customers);

        }

        private void customersComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Retrieve the ID of the selected company.
            string customerID = customersComboBox.SelectedValue.ToString();
            if (customerID == null) { return; }

            DataTable dataTable = CustomersOrders.FillCustomers(customerID);
            customersDataGridView.DataSource = dataTable;

            dataTable = CustomersOrders.FillOrders(customerID);
            ordersDataGridView.DataSource = dataTable;
        }
    }
}

/*
In CompanyNameComboBox_SelectionChangeCommitted
 
 
        // Retrieve the ID of the selected company.
        String CustomerIDString = CompanyNameComboBox.SelectedValue.ToString();
        String sql = "select * from customers where customerid = '" +
CustomerIDString + "'";
 
 
        SqlCommand command = new SqlCommand(sql, connectionString)
        Dataset mydataset = new Dataset(...)
 
        // create the binding source for a newly create dataset
        customerDataGriew.datasource = dataset
        customerDataGriew.datamember = "customers"
       ....
 J 
*/