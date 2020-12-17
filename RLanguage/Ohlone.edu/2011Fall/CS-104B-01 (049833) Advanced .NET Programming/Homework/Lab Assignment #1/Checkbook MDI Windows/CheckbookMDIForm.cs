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
    public partial class CheckbookMDIForm : Form
    {
        public Checkbook checkbook;
    
        public CheckbookMDIForm()
        {
            InitializeComponent();
        }

        private void mainToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenMainForm();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close(); //Application.Exit(); Code in the closing event, will not execute.
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm aboutForm = new AboutForm();
            aboutForm.ShowDialog();
            aboutForm.Focus();
        }

        private void CheckbookMDIForm_Load(object sender, EventArgs e)
        {
            checkbook = new Checkbook();
            EverySecond();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void verticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void horizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void cascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void summaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenSummaryForm();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            EverySecond();
        }

        private void EverySecond()
        {
            dateToolStripStatusLabel.Text = DateTime.Today.ToShortDateString();
            timeToolStripStatusLabel.Text = DateTime.Now.ToShortTimeString();
        }


        private void OpenMainForm()
        {
            MainForm mainForm = new MainForm();
            mainForm.MdiParent = this;
            mainForm.Show();
            mainForm.Focus();
        }

        private void OpenSummaryForm()
        {
            SummaryForm summaryForm = new SummaryForm();
            summaryForm.MdiParent = this;
            summaryForm.Show();
            summaryForm.Focus();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void transactionToolStripLabel_Click(object sender, EventArgs e)
        {
            OpenMainForm();
        }

        private void summaryToolStripLabel_Click(object sender, EventArgs e)
        {
            OpenSummaryForm();
        }
    }
}
