using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using ProductInformationClassLibrary;

namespace Product_Information
{
    public partial class ProductForm : Form
    {
        public int ProductId
        {
            set { productIdLabel.Text = value.ToString(); }
        }

        public string InfoProductName
        {
            set { productNameLabel.Text = value; }
        }

        public decimal UnitPrice
        {
            set { unitPriceLabel.Text = value.ToString("c"); }
        }

        public int UnitsInStock
        {
            set { unitsInStockLabel.Text = value.ToString(); }
        }

        public ProductForm()
        {
            InitializeComponent();
        }

        private void ProductForm_Load(object sender, EventArgs e)
        {
            productNameComboBox.DataSource = ProductInformation.FillProducts();
            productNameComboBox.DisplayMember = "ProductName";
            productNameComboBox.ValueMember = "ProductID";
        }

        private void ProductNameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            String selectedValue = productNameComboBox.SelectedValue.ToString();

            int selectedProductId = -1;

            bool flag = Int32.TryParse(selectedValue, out selectedProductId);

            if (!flag) { return; }

            DataTable dataTable = (DataTable) productNameComboBox.DataSource;

            //Linq to DataTable
            DataRow foundRow = (from myRow in dataTable.AsEnumerable()
                                where myRow.Field<int>("ProductId") == selectedProductId
                               select myRow).First();

            ProductId = (int)foundRow["ProductId"];
            InfoProductName = (string)foundRow["ProductName"];
            UnitPrice = (decimal)foundRow["UnitPrice"];
            UnitsInStock = (int)foundRow["UnitsInStock"];
        }
     }
}
