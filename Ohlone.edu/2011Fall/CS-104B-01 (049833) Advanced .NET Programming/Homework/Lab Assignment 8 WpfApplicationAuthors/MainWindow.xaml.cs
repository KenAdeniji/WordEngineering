using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.ComponentModel;

namespace Lab_Assignment_8_WpfApplicationAuthors
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.authorID.SelectionChanged += new SelectionChangedEventHandler(AuthorID_SelectionChanged);

            exit.Click += new RoutedEventHandler(Exit_Click);

            add.Click += new RoutedEventHandler(Add_Click);
            delete.Click += new RoutedEventHandler(Delete_Click);
            edit.Click += new RoutedEventHandler(Edit_Click);

            first.Click += new RoutedEventHandler(NavigationFirstButton_Click);
            previous.Click += new RoutedEventHandler(NavigationPreviousButton_Click);
            next.Click += new RoutedEventHandler(NavigationNextButton_Click);
            last.Click += new RoutedEventHandler(NavigationLastButton_Click);
        }

        protected string AuthorID
        {
            get { return authorID.Text; }
            set { authorID.Text = value; }
        }

        protected string Address
        {
            get { return address.Text; }
            set { address.Text = value; }
        }

        protected string City
        {
            get { return city.Text; }
            set { city.Text = value; }
        }

        protected bool? Contract
        {
            get { return contract.IsChecked; }
            set { contract.IsChecked = value; }
        }

        protected string FirstName
        {
            get { return firstName.Text; }
            set { firstName.Text = value; }
        }

        protected string LastName
        {
            get { return lastName.Text; }
            set { lastName.Text = value; }
        }

        protected string Phone
        {
            get { return phone.Text; }
            set { phone.Text = value; }
        }

        protected string State
        {
            get { return state.Text; }
            set { state.Text = value; }
        }

        protected string Zip
        {
            get { return zip.Text; }
            set { zip.Text = value; }
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
                DataTable dataTable = (DataTable)authorID.DataContext;
                int recordCount = dataTable.Rows.Count;
                return recordCount;
            }
        }

        private void OnLoad(object sender, RoutedEventArgs e)
        {
            LoadForm();
        }

        private void Add_Click(object sender, EventArgs e)
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
            au_idPriorToAlter = authorID.Text;
            statusStrip.Text = "Adding";
            authorID.IsEnabled = true;
            //authorID.ResetText();
            authorID.Text = "";

            EnumVisualAddMode(this);

            add.Content = "&Save";
            delete.Content = "&Cancel";
        }

        // Enumerate all the descendants of the visual object.
        static public void EnumVisualAddMode(Visual myVisual)
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(myVisual); i++)
            {
                // Retrieve child visual at specified index value.
                Visual childVisual = (Visual)VisualTreeHelper.GetChild(myVisual, i);

                // Do processing of the child visual object.

                if (childVisual is TextBox)
                {
                    TextBox textBox = (TextBox)childVisual;
                    textBox.IsEnabled = true;
                    textBox.Text = "";
                }
                else if (childVisual is CheckBox)
                {
                    CheckBox checkBox = (CheckBox)childVisual;
                    checkBox.IsEnabled = true;
                    checkBox.IsChecked = false;
                }
                else if (childVisual is Button)
                {
                    Button button = (Button)childVisual;
                    int compareTo = button.Name.CompareTo("edit");
                    if (compareTo == 0)
                    {
                        button.IsEnabled = false;
                    }
                    else
                    {
                        button.IsEnabled = true;
                    }
                }

                // Enumerate children of the child visual object.
                EnumVisualAddMode(childVisual);
            }
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

        private void AuthorID_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Alter) { return; }
            // Retrieve the ID of the selected author.
            //string au_id = authorID.SelectedValue.ToString();
            //if (au_id == null) { return; }
            
            ListBoxItem listBoxItem = ((sender as ListBox).SelectedItem as ListBoxItem);
            string au_id = listBoxItem.Content.ToString();

            if (au_id == null) { return; }

            ShowRecord(au_id);
        }

        private void DefaultMode()
        {
            modeState = Mode.Default;
            authorID.IsEnabled = true;
            EnumVisualDefaultMode(this);
            add.Content = "&Add";
            delete.Content = "&Delete";
        }

        // Enumerate all the descendants of the visual object.
        static public void EnumVisualDefaultMode(Visual myVisual)
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(myVisual); i++)
            {
                // Retrieve child visual at specified index value.
                Visual childVisual = (Visual)VisualTreeHelper.GetChild(myVisual, i);

                // Do processing of the child visual object.

                if (childVisual is CheckBox)
                {
                    CheckBox checkBox = (CheckBox)childVisual;
                    checkBox.IsEnabled = false;
                }
                if (childVisual is TextBox)
                {
                    TextBox textBox = (TextBox)childVisual;
                    textBox.IsEnabled = false;
                }
                else if (childVisual is Button)
                {
                    Button button = (Button)childVisual;
                    button.IsEnabled = true;
                }
                // Enumerate children of the child visual object.
                EnumVisualDefaultMode(childVisual);
            }
        }

        private void Delete_Click(object sender, EventArgs e)
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

        private void Edit_Click(object sender, EventArgs e)
        {
            EditMode();
        }

        private void EditMode()
        {
            modeState = Mode.Edit;
            au_idPriorToAlter = authorID.Text;
            statusStrip.Text = "Editing";
            authorID.IsEnabled = false;
            EnumVisualEditMode(this);
            add.Content = "&Save";
            delete.Content = "&Cancel";
        }

        // Enumerate all the descendants of the visual object.
        static public void EnumVisualEditMode(Visual myVisual)
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(myVisual); i++)
            {
                // Retrieve child visual at specified index value.
                Visual childVisual = (Visual)VisualTreeHelper.GetChild(myVisual, i);

                // Do processing of the child visual object.

                if (childVisual is TextBox)
                {
                    TextBox textBox = (TextBox)childVisual;
                    textBox.IsEnabled = true;
                }
                else if (childVisual is CheckBox)
                {
                    CheckBox checkBox = (CheckBox)childVisual;
                    checkBox.IsEnabled = true;
                }
                else if (childVisual is Button)
                {
                    Button button = (Button)childVisual;
                    int compareTo = button.Name.CompareTo("edit");
                    if (compareTo == 0)
                    {
                        button.IsEnabled = false;
                    }
                    else
                    {
                        button.IsEnabled = true;
                    }
                }

                // Enumerate children of the child visual object.
                EnumVisualEditMode(childVisual);
            }
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
            //authorID.DataContext = dataTable;

            authorID.ItemsSource = ((IListSource)dataTable).GetList();
            authorID.DisplayMemberPath = "Au_LName";
            authorID.SelectedValuePath = "Au_ID"; 

            DefaultMode();
        }

        private void ShowRecord(string au_id)
        {
            au_idPriorToAlter = au_id;
            DataTable dataTable = (DataTable)authorID.DataContext; //.DataSource;
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

        private void NavigationFirstButton_Click(object sender, EventArgs e)
        {
            authorID.SelectedIndex = 0;
        }

        private void NavigationPreviousButton_Click(object sender, EventArgs e)
        {
            if (authorID.SelectedIndex > 0)
            {
                --authorID.SelectedIndex;
            }
        }

        private void NavigationNextButton_Click(object sender, EventArgs e)
        {
            if (authorID.SelectedIndex < RecordCount - 1)
            {
                ++authorID.SelectedIndex;
            }
        }

        private void NavigationLastButton_Click(object sender, EventArgs e)
        {
            authorID.SelectedIndex = RecordCount - 1;
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close(); //Application.Exit(); Code in the closing event, will not execute.
        }
    }
}
