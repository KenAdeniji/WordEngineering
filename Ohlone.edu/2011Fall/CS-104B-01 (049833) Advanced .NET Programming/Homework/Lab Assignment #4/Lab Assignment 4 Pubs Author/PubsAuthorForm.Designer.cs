namespace Lab_Assignment_4_Pubs_Author
{
    partial class PubsAuthorForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.authorIDComboBox = new System.Windows.Forms.ComboBox();
            this.authorIdLabel = new System.Windows.Forms.Label();
            this.lastNameLabel = new System.Windows.Forms.Label();
            this.lastNameTextBox = new System.Windows.Forms.TextBox();
            this.firstNameLabel = new System.Windows.Forms.Label();
            this.firstNameTextBox = new System.Windows.Forms.TextBox();
            this.addressLabel = new System.Windows.Forms.Label();
            this.addressTextBox = new System.Windows.Forms.TextBox();
            this.cityLabel = new System.Windows.Forms.Label();
            this.cityTextBox = new System.Windows.Forms.TextBox();
            this.stateLabel = new System.Windows.Forms.Label();
            this.stateTextBox = new System.Windows.Forms.TextBox();
            this.ziplabel = new System.Windows.Forms.Label();
            this.zipTextBox = new System.Windows.Forms.TextBox();
            this.phoneLabel = new System.Windows.Forms.Label();
            this.phoneTextBox = new System.Windows.Forms.TextBox();
            this.contractLabel = new System.Windows.Forms.Label();
            this.contractCheckBox = new System.Windows.Forms.CheckBox();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.addButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.navigationFirstButton = new System.Windows.Forms.Button();
            this.navigationPreviousButton = new System.Windows.Forms.Button();
            this.navigationNextButton = new System.Windows.Forms.Button();
            this.navigationLastButton = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // authorIDComboBox
            // 
            this.authorIDComboBox.DisplayMember = "au_id";
            this.authorIDComboBox.FormattingEnabled = true;
            this.authorIDComboBox.Location = new System.Drawing.Point(165, 39);
            this.authorIDComboBox.Name = "authorIDComboBox";
            this.authorIDComboBox.Size = new System.Drawing.Size(121, 21);
            this.authorIDComboBox.TabIndex = 0;
            this.authorIDComboBox.ValueMember = "au_id";
            this.authorIDComboBox.SelectedIndexChanged += new System.EventHandler(this.authorIDComboBox_SelectedIndexChanged);
            // 
            // authorIdLabel
            // 
            this.authorIdLabel.AutoSize = true;
            this.authorIdLabel.Location = new System.Drawing.Point(33, 41);
            this.authorIdLabel.Name = "authorIdLabel";
            this.authorIdLabel.Size = new System.Drawing.Size(55, 17);
            this.authorIdLabel.TabIndex = 1;
            this.authorIdLabel.Text = "Author ID:";
            this.authorIdLabel.UseCompatibleTextRendering = true;
            // 
            // lastNameLabel
            // 
            this.lastNameLabel.AutoSize = true;
            this.lastNameLabel.Location = new System.Drawing.Point(33, 75);
            this.lastNameLabel.Name = "lastNameLabel";
            this.lastNameLabel.Size = new System.Drawing.Size(62, 17);
            this.lastNameLabel.TabIndex = 2;
            this.lastNameLabel.Text = "Last Name:";
            this.lastNameLabel.UseCompatibleTextRendering = true;
            // 
            // lastNameTextBox
            // 
            this.lastNameTextBox.Location = new System.Drawing.Point(165, 72);
            this.lastNameTextBox.Name = "lastNameTextBox";
            this.lastNameTextBox.Size = new System.Drawing.Size(197, 20);
            this.lastNameTextBox.TabIndex = 3;
            // 
            // firstNameLabel
            // 
            this.firstNameLabel.AutoSize = true;
            this.firstNameLabel.Location = new System.Drawing.Point(33, 108);
            this.firstNameLabel.Name = "firstNameLabel";
            this.firstNameLabel.Size = new System.Drawing.Size(63, 17);
            this.firstNameLabel.TabIndex = 4;
            this.firstNameLabel.Text = "First Name:";
            this.firstNameLabel.UseCompatibleTextRendering = true;
            // 
            // firstNameTextBox
            // 
            this.firstNameTextBox.Location = new System.Drawing.Point(165, 105);
            this.firstNameTextBox.Name = "firstNameTextBox";
            this.firstNameTextBox.Size = new System.Drawing.Size(197, 20);
            this.firstNameTextBox.TabIndex = 5;
            // 
            // addressLabel
            // 
            this.addressLabel.AutoSize = true;
            this.addressLabel.Location = new System.Drawing.Point(33, 141);
            this.addressLabel.Name = "addressLabel";
            this.addressLabel.Size = new System.Drawing.Size(49, 17);
            this.addressLabel.TabIndex = 6;
            this.addressLabel.Text = "Address:";
            this.addressLabel.UseCompatibleTextRendering = true;
            // 
            // addressTextBox
            // 
            this.addressTextBox.Location = new System.Drawing.Point(165, 138);
            this.addressTextBox.Name = "addressTextBox";
            this.addressTextBox.Size = new System.Drawing.Size(197, 20);
            this.addressTextBox.TabIndex = 7;
            // 
            // cityLabel
            // 
            this.cityLabel.AutoSize = true;
            this.cityLabel.Location = new System.Drawing.Point(33, 174);
            this.cityLabel.Name = "cityLabel";
            this.cityLabel.Size = new System.Drawing.Size(27, 17);
            this.cityLabel.TabIndex = 8;
            this.cityLabel.Text = "City:";
            this.cityLabel.UseCompatibleTextRendering = true;
            // 
            // cityTextBox
            // 
            this.cityTextBox.Location = new System.Drawing.Point(165, 171);
            this.cityTextBox.Name = "cityTextBox";
            this.cityTextBox.Size = new System.Drawing.Size(197, 20);
            this.cityTextBox.TabIndex = 9;
            // 
            // stateLabel
            // 
            this.stateLabel.AutoSize = true;
            this.stateLabel.Location = new System.Drawing.Point(33, 207);
            this.stateLabel.Name = "stateLabel";
            this.stateLabel.Size = new System.Drawing.Size(34, 17);
            this.stateLabel.TabIndex = 10;
            this.stateLabel.Text = "State:";
            this.stateLabel.UseCompatibleTextRendering = true;
            // 
            // stateTextBox
            // 
            this.stateTextBox.Location = new System.Drawing.Point(165, 204);
            this.stateTextBox.Name = "stateTextBox";
            this.stateTextBox.Size = new System.Drawing.Size(197, 20);
            this.stateTextBox.TabIndex = 11;
            // 
            // ziplabel
            // 
            this.ziplabel.AutoSize = true;
            this.ziplabel.Location = new System.Drawing.Point(33, 240);
            this.ziplabel.Name = "ziplabel";
            this.ziplabel.Size = new System.Drawing.Size(23, 17);
            this.ziplabel.TabIndex = 12;
            this.ziplabel.Text = "Zip:";
            this.ziplabel.UseCompatibleTextRendering = true;
            // 
            // zipTextBox
            // 
            this.zipTextBox.Location = new System.Drawing.Point(165, 237);
            this.zipTextBox.Name = "zipTextBox";
            this.zipTextBox.Size = new System.Drawing.Size(197, 20);
            this.zipTextBox.TabIndex = 13;
            // 
            // phoneLabel
            // 
            this.phoneLabel.AutoSize = true;
            this.phoneLabel.Location = new System.Drawing.Point(33, 273);
            this.phoneLabel.Name = "phoneLabel";
            this.phoneLabel.Size = new System.Drawing.Size(40, 17);
            this.phoneLabel.TabIndex = 14;
            this.phoneLabel.Text = "Phone:";
            this.phoneLabel.UseCompatibleTextRendering = true;
            // 
            // phoneTextBox
            // 
            this.phoneTextBox.Location = new System.Drawing.Point(165, 270);
            this.phoneTextBox.Name = "phoneTextBox";
            this.phoneTextBox.Size = new System.Drawing.Size(197, 20);
            this.phoneTextBox.TabIndex = 15;
            // 
            // contractLabel
            // 
            this.contractLabel.AutoSize = true;
            this.contractLabel.Location = new System.Drawing.Point(33, 306);
            this.contractLabel.Name = "contractLabel";
            this.contractLabel.Size = new System.Drawing.Size(50, 17);
            this.contractLabel.TabIndex = 16;
            this.contractLabel.Text = "Contract:";
            this.contractLabel.UseCompatibleTextRendering = true;
            // 
            // contractCheckBox
            // 
            this.contractCheckBox.AutoSize = true;
            this.contractCheckBox.Location = new System.Drawing.Point(165, 303);
            this.contractCheckBox.Name = "contractCheckBox";
            this.contractCheckBox.Size = new System.Drawing.Size(15, 14);
            this.contractCheckBox.TabIndex = 17;
            this.contractCheckBox.UseCompatibleTextRendering = true;
            this.contractCheckBox.UseVisualStyleBackColor = true;
            // 
            // statusStrip
            // 
            this.statusStrip.Location = new System.Drawing.Point(0, 378);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(508, 22);
            this.statusStrip.TabIndex = 18;
            this.statusStrip.Text = "statusStrip1";
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(409, 72);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 19;
            this.addButton.Text = "&Add";
            this.addButton.UseCompatibleTextRendering = true;
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(409, 112);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 23);
            this.deleteButton.TabIndex = 20;
            this.deleteButton.Text = "&Delete";
            this.deleteButton.UseCompatibleTextRendering = true;
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // editButton
            // 
            this.editButton.Location = new System.Drawing.Point(409, 143);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(75, 23);
            this.editButton.TabIndex = 21;
            this.editButton.Text = "&Edit";
            this.editButton.UseCompatibleTextRendering = true;
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // navigationFirstButton
            // 
            this.navigationFirstButton.Location = new System.Drawing.Point(33, 337);
            this.navigationFirstButton.Name = "navigationFirstButton";
            this.navigationFirstButton.Size = new System.Drawing.Size(75, 23);
            this.navigationFirstButton.TabIndex = 22;
            this.navigationFirstButton.Text = "First";
            this.navigationFirstButton.UseCompatibleTextRendering = true;
            this.navigationFirstButton.UseVisualStyleBackColor = true;
            this.navigationFirstButton.Click += new System.EventHandler(this.navigationFirstButton_Click);
            // 
            // navigationPreviousButton
            // 
            this.navigationPreviousButton.Location = new System.Drawing.Point(123, 337);
            this.navigationPreviousButton.Name = "navigationPreviousButton";
            this.navigationPreviousButton.Size = new System.Drawing.Size(75, 23);
            this.navigationPreviousButton.TabIndex = 23;
            this.navigationPreviousButton.Text = "Previous";
            this.navigationPreviousButton.UseCompatibleTextRendering = true;
            this.navigationPreviousButton.UseVisualStyleBackColor = true;
            this.navigationPreviousButton.Click += new System.EventHandler(this.navigationPreviousButton_Click);
            // 
            // navigationNextButton
            // 
            this.navigationNextButton.Location = new System.Drawing.Point(211, 337);
            this.navigationNextButton.Name = "navigationNextButton";
            this.navigationNextButton.Size = new System.Drawing.Size(75, 23);
            this.navigationNextButton.TabIndex = 24;
            this.navigationNextButton.Text = "Next";
            this.navigationNextButton.UseCompatibleTextRendering = true;
            this.navigationNextButton.UseVisualStyleBackColor = true;
            this.navigationNextButton.Click += new System.EventHandler(this.navigationNextButton_Click);
            // 
            // navigationLastButton
            // 
            this.navigationLastButton.Location = new System.Drawing.Point(302, 337);
            this.navigationLastButton.Name = "navigationLastButton";
            this.navigationLastButton.Size = new System.Drawing.Size(75, 23);
            this.navigationLastButton.TabIndex = 25;
            this.navigationLastButton.Text = "Last";
            this.navigationLastButton.UseCompatibleTextRendering = true;
            this.navigationLastButton.UseVisualStyleBackColor = true;
            this.navigationLastButton.Click += new System.EventHandler(this.navigationLastButton_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(508, 24);
            this.menuStrip1.TabIndex = 26;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // PubsAuthorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 400);
            this.Controls.Add(this.navigationLastButton);
            this.Controls.Add(this.navigationNextButton);
            this.Controls.Add(this.navigationPreviousButton);
            this.Controls.Add(this.navigationFirstButton);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.contractCheckBox);
            this.Controls.Add(this.contractLabel);
            this.Controls.Add(this.phoneTextBox);
            this.Controls.Add(this.phoneLabel);
            this.Controls.Add(this.zipTextBox);
            this.Controls.Add(this.ziplabel);
            this.Controls.Add(this.stateTextBox);
            this.Controls.Add(this.stateLabel);
            this.Controls.Add(this.cityTextBox);
            this.Controls.Add(this.cityLabel);
            this.Controls.Add(this.addressTextBox);
            this.Controls.Add(this.addressLabel);
            this.Controls.Add(this.firstNameTextBox);
            this.Controls.Add(this.firstNameLabel);
            this.Controls.Add(this.lastNameTextBox);
            this.Controls.Add(this.lastNameLabel);
            this.Controls.Add(this.authorIdLabel);
            this.Controls.Add(this.authorIDComboBox);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "PubsAuthorForm";
            this.Text = "Authors";
            this.Load += new System.EventHandler(this.PubsAuthorForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox authorIDComboBox;
        private System.Windows.Forms.Label authorIdLabel;
        private System.Windows.Forms.Label lastNameLabel;
        private System.Windows.Forms.TextBox lastNameTextBox;
        private System.Windows.Forms.Label firstNameLabel;
        private System.Windows.Forms.TextBox firstNameTextBox;
        private System.Windows.Forms.Label addressLabel;
        private System.Windows.Forms.TextBox addressTextBox;
        private System.Windows.Forms.Label cityLabel;
        private System.Windows.Forms.TextBox cityTextBox;
        private System.Windows.Forms.Label stateLabel;
        private System.Windows.Forms.TextBox stateTextBox;
        private System.Windows.Forms.Label ziplabel;
        private System.Windows.Forms.TextBox zipTextBox;
        private System.Windows.Forms.Label phoneLabel;
        private System.Windows.Forms.TextBox phoneTextBox;
        private System.Windows.Forms.Label contractLabel;
        private System.Windows.Forms.CheckBox contractCheckBox;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Button navigationFirstButton;
        private System.Windows.Forms.Button navigationPreviousButton;
        private System.Windows.Forms.Button navigationNextButton;
        private System.Windows.Forms.Button navigationLastButton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    }
}