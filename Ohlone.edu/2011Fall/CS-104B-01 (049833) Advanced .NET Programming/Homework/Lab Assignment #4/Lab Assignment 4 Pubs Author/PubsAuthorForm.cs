using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using LabAssignment4ClassLibrary;

namespace Lab_Assignment_4_Pubs_Author
{
    public partial class PubsAuthorForm : Form
    {
        protected string AuthorID
        {
            get { return authorIDComboBox.Text; }
            set { authorIDComboBox.Text = value; }
        }

        protected string Address
        {
            get { return addressTextBox.Text; }
            set { addressTextBox.Text = value; }
        }

        protected string City
        {
            get { return cityTextBox.Text; }
            set { cityTextBox.Text = value; }
        }

        protected bool Contract
        {
            get { return contractCheckBox.Checked; }
            set { contractCheckBox.Checked = value; }
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

        protected string State
        {
            get { return stateTextBox.Text; }
            set { stateTextBox.Text = value; }
        }

        protected string Zip
        {
            get { return zipTextBox.Text; }
            set { zipTextBox.Text = value; }
        }

        protected bool Alter
        {
            get
            {
                if (modeState == Mode.Default) { return false; }
                return true;
            }
        }

        protected int RecordCount
        {
            get
            {
                DataTable dataTable = (DataTable)authorIDComboBox.DataSource;
                int recordCount = dataTable.Rows.Count;
                return recordCount;
            }
        }

        public PubsAuthorForm()
        {
            InitializeComponent();
        }

        private void PubsAuthorForm_Load(object sender, EventArgs e)
        {
            LoadForm();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (modeState == Mode.Default)
            {
                AddMode();
                return;
            }
            if (modeState == Mode.Add) { AddSave(); }
            if (modeState == Mode.Edit) { EditSave(); }
        }

        private void AddMode()
        {
            modeState = Mode.Add;
            au_idPriorToAlter = authorIDComboBox.Text;
            statusStrip.Text = "Adding";
            authorIDComboBox.Enabled = true;
            authorIDComboBox.ResetText();
            foreach (Control control in Controls)
            {
                if (control is TextBox)
                {
                    control.Enabled = true;
                    TextBox textBox = (TextBox)control;
                    textBox.Text = "";
                }
                else if (control is CheckBox)
                {
                    control.Enabled = true;
                    CheckBox checkBox = (CheckBox)control;
                    checkBox.Checked = false;
                }
                else if (control is Button)
                {
                    int compareTo = control.Name.CompareTo("editButton");
                    if (compareTo == 0)
                    {
                        control.Enabled = false;
                        continue;
                    }
                    control.Enabled = true;
                }
            }
            addButton.Text = "&Save";
            deleteButton.Text = "&Cancel";
        }

        private void AddSave()
        {
            DatabasePubsTableAuthors author = new DatabasePubsTableAuthors
            {
                AuthorID = this.AuthorID,
                LastName = this.LastName,
                FirstName = this.FirstName,
                Address = this.Address,
                City = this.City,
                State = this.State,
                Zip = this.Zip,
                Phone = this.Phone,
                Contract = this.Contract
            };
            string exceptionMessage = DatabasePubsTableAuthors.InsertAuthor(author);
            if (exceptionMessage != null)
            {
                MessageBox.Show(exceptionMessage);
                return;
            }
            modeState = Mode.Default;
            LoadForm();
        }

        private void authorIDComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Alter) { return; }
            // Retrieve the ID of the selected author.
            string au_id = authorIDComboBox.SelectedValue.ToString();
            if (au_id == null) { return; }
            ShowRecord(au_id);
        }

        private void DefaultMode()
        {
            modeState = Mode.Default;
            authorIDComboBox.Enabled = true;
            foreach (Control control in Controls)
            {
                if (control is TextBox || control is CheckBox)
                {
                    control.Enabled = false;
                }
                else if (control is Button)
                {
                    control.Enabled = true;
                } 
            }
            addButton.Text = "&Add";
            deleteButton.Text = "&Delete";
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (modeState == Mode.Default)
            {
                //Delete button
                DeleteAuthor();
                return;
            }
            //Cancel button
            modeState = Mode.Default;
            LoadForm();
        }

        private void DeleteAuthor()
        {
            string exceptionMessage = DatabasePubsTableAuthors.DeleteAuthor(au_idPriorToAlter);
            if (exceptionMessage != null)
            {
                MessageBox.Show(exceptionMessage);
                return;
            }
            modeState = Mode.Default;
            LoadForm();
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            EditMode();
        }

        private void EditMode()
        {
            modeState = Mode.Edit;
            au_idPriorToAlter = authorIDComboBox.Text;
            statusStrip.Text = "Editing";
            authorIDComboBox.Enabled = false;
            foreach (Control control in Controls)
            {
                if (control is TextBox || control is CheckBox)
                {
                    control.Enabled = true;
                }
                else if (control is Button)
                {
                    int compareTo = control.Name.CompareTo("editButton");
                    if (compareTo == 0)
                    {
                        control.Enabled = false;
                        continue;
                    }
                    control.Enabled = true;
                }
            }
            addButton.Text = "&Save";
            deleteButton.Text = "&Cancel";
        }

        private void EditSave()
        {
            DatabasePubsTableAuthors author = new DatabasePubsTableAuthors
            {
                AuthorID = this.AuthorID,
                LastName = this.LastName,
                FirstName = this.FirstName,
                Address = this.Address,
                City = this.City,
                State = this.State,
                Zip = this.Zip,
                Phone = this.Phone,
                Contract = this.Contract
            };
            string exceptionMessage = DatabasePubsTableAuthors.UpdateAuthor(author);
            if (exceptionMessage != null)
            {
                MessageBox.Show(exceptionMessage);
                return;
            }
            modeState = Mode.Default;
            LoadForm();
        }

        private void FormStatusRecord(string au_id, DataTable dataTable)
        {
            int currentRecord;
            int recordCount;
            bool recordFound = DatabasePubsTableAuthors.RecordOf(out currentRecord, out recordCount, au_id, dataTable);
            if (!recordFound) { return; }
            string formStatus = String.Format(RecordOf, currentRecord + 1, recordCount);
            statusStrip.Text = formStatus;
        }

        private void LoadForm()
        {
            DataTable dataTable = DatabasePubsTableAuthors.FillAuthors();
            authorIDComboBox.DataSource = dataTable;
            DefaultMode();
        }

        private void ShowRecord(string au_id)
        {
            au_idPriorToAlter = au_id;
            DataTable dataTable = (DataTable)authorIDComboBox.DataSource;
            //Linq to DataTable
            DataRow foundRow = (from myRow in dataTable.AsEnumerable()
                                where myRow.Field<string>("au_id") == au_id
                                select myRow).FirstOrDefault();

            if (foundRow == null) { return; }

            LastName = (string)foundRow["au_lname"];
            FirstName = (string)foundRow["au_fname"];
            Address = (string)foundRow["address"];
            City = (string)foundRow["city"];
            State = (string)foundRow["state"];
            Zip = (string)foundRow["zip"];
            Phone = (string)foundRow["phone"];
            Contract = (bool)foundRow["contract"];

            FormStatusRecord(au_id, dataTable);
        }

        string au_idPriorToAlter = null;
        public const string RecordOf = "Record {0} of {1}";

        public enum Mode
        {
            Default,
            Add,
            Delete,
            Edit
        }

        Mode modeState = Mode.Default;

        private void navigationFirstButton_Click(object sender, EventArgs e)
        {
            authorIDComboBox.SelectedIndex = 0;
        }

        private void navigationPreviousButton_Click(object sender, EventArgs e)
        {
            if (authorIDComboBox.SelectedIndex > 0)
            {
                --authorIDComboBox.SelectedIndex;
            }
        }

        private void navigationNextButton_Click(object sender, EventArgs e)
        {
            if (authorIDComboBox.SelectedIndex < RecordCount - 1)
            {
                ++authorIDComboBox.SelectedIndex;
            }
        }

        private void navigationLastButton_Click(object sender, EventArgs e)
        {
            authorIDComboBox.SelectedIndex = RecordCount - 1;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close(); //Application.Exit(); Code in the closing event, will not execute.
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Pubs database, Author table.");
        }
    }
}
