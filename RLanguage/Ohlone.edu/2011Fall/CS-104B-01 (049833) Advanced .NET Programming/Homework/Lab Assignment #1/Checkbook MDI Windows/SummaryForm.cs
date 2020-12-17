using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Checkbook_ClassLibrary;

namespace Checkbook_MDI_Windows
{
    public partial class SummaryForm : Form
    {
        public SummaryForm()
        {
            InitializeComponent();
        }

        private void SummaryForm_Load(object sender, EventArgs e)
        {
            Form mdiParent = this.MdiParent;
            CheckbookMDIForm checkbookMDIForm = (CheckbookMDIForm)mdiParent;
            Checkbook checkbook = checkbookMDIForm.checkbook;

            AmountOfChecks = checkbook.AmountOfChecks;
            AmountOfDeposits = checkbook.AmountOfDeposits;
            AmountOfInterest = checkbook.AmountOfInterest;
            AmountOfServiceCharges = checkbook.AmountOfServiceCharges;

            NumberOfChecks = checkbook.NumberOfChecks;
            NumberOfDeposits = checkbook.NumberOfDeposits;
            NumberOfInterest = checkbook.NumberOfInterest;
            NumberOfServiceCharges = checkbook.NumberOfServiceCharges;
        }

        decimal AmountOfChecks
        {
            set
            {
                amountOfChecks.Text = String.Format
                (
                    "{0:0.00}",
                    value
                );
            }
        }

        decimal AmountOfDeposits
        {
            set
            {
                amountOfDeposits.Text = String.Format
                (
                    "{0:0.00}",
                    value
                );
            }
        }

        decimal AmountOfInterest
        {
            set
            {
                amountOfInterest.Text = String.Format
                (
                    "{0:0.00}",
                    value
                );
            }
        }

        decimal AmountOfServiceCharges
        {
            set
            {
                amountOfServiceCharges.Text = String.Format
                (
                    "{0:0.00}",
                    value
                );
            }
        }

        int NumberOfChecks
        {
            set
            {
                numberOfChecks.Text = value.ToString();
            }
        }

        int NumberOfDeposits
        {
            set
            {
                numberOfDeposits.Text = value.ToString();
            }
        }

        int NumberOfInterest
        {
            set
            {
                numberOfInterest.Text = value.ToString();
            }
        }

        int NumberOfServiceCharges
        {
            set
            {
                numberOfServiceCharges.Text = value.ToString();
            }
        }

    }
}
