using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Checkbook_MDI_Windows
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void buttonAddTransaction_Click(object sender, EventArgs e)
        {
            Form mdiParent = this.MdiParent;
            CheckbookMDIForm checkbookMDIForm = (CheckbookMDIForm)mdiParent;
            decimal balance = 0;
            try
            {
                balance = checkbookMDIForm.checkbook.AddTransaction
                (
                    TransactionType,
                    NumericUpDownAmount
                );
                AccountBalance = balance;
            }
            catch (System.ApplicationException ex)
            {
                AccountBalance = checkbookMDIForm.checkbook.AccountBalance;
                errorProvider1.SetError(numericUpDownAmount, ex.Message);
            }
        }

        private void labelAccountBalance_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        
        decimal AccountBalance
        {
            set
            {
                accountBalance.Text = String.Format
                (
                    "{0:0.00}",
                    value
                );
            }
        }

        decimal NumericUpDownAmount
        {
            get
            {
                decimal amount = 0;
                bool flag = decimal.TryParse(numericUpDownAmount.Text, out amount);
                return amount;
            }
        }

        string TransactionType
        {
            get
            {
                string transactionType = comboBoxTransactionType.Text;
                return transactionType;
            }
        }

        private void comboBoxTransactionType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void accountBalance_Click(object sender, EventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            AccountBalance = 0;
        }
    }
}
