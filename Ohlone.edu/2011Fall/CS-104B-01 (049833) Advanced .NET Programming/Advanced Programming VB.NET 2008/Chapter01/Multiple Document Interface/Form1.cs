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
    public partial class Form1 : Form
    {
        private static int childTwoDocumentIndex = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void displayChildTwoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ++childTwoDocumentIndex;
            FormChildTwo formChildTwo = new FormChildTwo();
            formChildTwo.MdiParent = this;
            formChildTwo.Show();
            formChildTwo.Text = "Child Two Document" + childTwoDocumentIndex.ToString();
        }

        private void tileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void tileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void cascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void displayChildOneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChildOneForm childOneForm = ChildOneForm.SingletonInstance;
            childOneForm.MdiParent = this;
            childOneForm.Show();
            childOneForm.Focus();
        }
    }
}
