namespace Lab_Assignment_7
{
    partial class FindForm
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
            this.faxTextBox = new System.Windows.Forms.TextBox();
            this.faxLabel = new System.Windows.Forms.Label();
            this.cellTextBox = new System.Windows.Forms.TextBox();
            this.phoneTextBox = new System.Windows.Forms.TextBox();
            this.cellLabel = new System.Windows.Forms.Label();
            this.phoneLabel = new System.Windows.Forms.Label();
            this.pinTextBox = new System.Windows.Forms.TextBox();
            this.pinLabel = new System.Windows.Forms.Label();
            this.lastNameTextBox = new System.Windows.Forms.TextBox();
            this.firstNameTextBox = new System.Windows.Forms.TextBox();
            this.lastNameLabel = new System.Windows.Forms.Label();
            this.firstNameLabel = new System.Windows.Forms.Label();
            this.findButton = new System.Windows.Forms.Button();
            this.dataGridViewCustomer = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCustomer)).BeginInit();
            this.SuspendLayout();
            // 
            // faxTextBox
            // 
            this.faxTextBox.Location = new System.Drawing.Point(124, 217);
            this.faxTextBox.Name = "faxTextBox";
            this.faxTextBox.Size = new System.Drawing.Size(172, 20);
            this.faxTextBox.TabIndex = 35;
            // 
            // faxLabel
            // 
            this.faxLabel.AutoSize = true;
            this.faxLabel.Location = new System.Drawing.Point(26, 217);
            this.faxLabel.Name = "faxLabel";
            this.faxLabel.Size = new System.Drawing.Size(26, 17);
            this.faxLabel.TabIndex = 34;
            this.faxLabel.Text = "Fax:";
            this.faxLabel.UseCompatibleTextRendering = true;
            // 
            // cellTextBox
            // 
            this.cellTextBox.Location = new System.Drawing.Point(124, 180);
            this.cellTextBox.Name = "cellTextBox";
            this.cellTextBox.Size = new System.Drawing.Size(172, 20);
            this.cellTextBox.TabIndex = 33;
            // 
            // phoneTextBox
            // 
            this.phoneTextBox.Location = new System.Drawing.Point(124, 139);
            this.phoneTextBox.Name = "phoneTextBox";
            this.phoneTextBox.Size = new System.Drawing.Size(172, 20);
            this.phoneTextBox.TabIndex = 32;
            // 
            // cellLabel
            // 
            this.cellLabel.AutoSize = true;
            this.cellLabel.Location = new System.Drawing.Point(26, 180);
            this.cellLabel.Name = "cellLabel";
            this.cellLabel.Size = new System.Drawing.Size(27, 17);
            this.cellLabel.TabIndex = 31;
            this.cellLabel.Text = "Cell:";
            this.cellLabel.UseCompatibleTextRendering = true;
            // 
            // phoneLabel
            // 
            this.phoneLabel.AutoSize = true;
            this.phoneLabel.Location = new System.Drawing.Point(26, 139);
            this.phoneLabel.Name = "phoneLabel";
            this.phoneLabel.Size = new System.Drawing.Size(40, 17);
            this.phoneLabel.TabIndex = 30;
            this.phoneLabel.Text = "Phone:";
            this.phoneLabel.UseCompatibleTextRendering = true;
            // 
            // pinTextBox
            // 
            this.pinTextBox.Location = new System.Drawing.Point(121, 104);
            this.pinTextBox.Name = "pinTextBox";
            this.pinTextBox.Size = new System.Drawing.Size(172, 20);
            this.pinTextBox.TabIndex = 29;
            // 
            // pinLabel
            // 
            this.pinLabel.AutoSize = true;
            this.pinLabel.Location = new System.Drawing.Point(26, 104);
            this.pinLabel.Name = "pinLabel";
            this.pinLabel.Size = new System.Drawing.Size(24, 17);
            this.pinLabel.TabIndex = 28;
            this.pinLabel.Text = "Pin:";
            this.pinLabel.UseCompatibleTextRendering = true;
            // 
            // lastNameTextBox
            // 
            this.lastNameTextBox.Location = new System.Drawing.Point(121, 67);
            this.lastNameTextBox.Name = "lastNameTextBox";
            this.lastNameTextBox.Size = new System.Drawing.Size(172, 20);
            this.lastNameTextBox.TabIndex = 27;
            // 
            // firstNameTextBox
            // 
            this.firstNameTextBox.Location = new System.Drawing.Point(121, 26);
            this.firstNameTextBox.Name = "firstNameTextBox";
            this.firstNameTextBox.Size = new System.Drawing.Size(172, 20);
            this.firstNameTextBox.TabIndex = 26;
            // 
            // lastNameLabel
            // 
            this.lastNameLabel.AutoSize = true;
            this.lastNameLabel.Location = new System.Drawing.Point(26, 67);
            this.lastNameLabel.Name = "lastNameLabel";
            this.lastNameLabel.Size = new System.Drawing.Size(62, 17);
            this.lastNameLabel.TabIndex = 25;
            this.lastNameLabel.Text = "Last Name:";
            this.lastNameLabel.UseCompatibleTextRendering = true;
            // 
            // firstNameLabel
            // 
            this.firstNameLabel.AutoSize = true;
            this.firstNameLabel.Location = new System.Drawing.Point(26, 26);
            this.firstNameLabel.Name = "firstNameLabel";
            this.firstNameLabel.Size = new System.Drawing.Size(63, 17);
            this.firstNameLabel.TabIndex = 24;
            this.firstNameLabel.Text = "First Name:";
            this.firstNameLabel.UseCompatibleTextRendering = true;
            // 
            // findButton
            // 
            this.findButton.Location = new System.Drawing.Point(94, 253);
            this.findButton.Name = "findButton";
            this.findButton.Size = new System.Drawing.Size(75, 23);
            this.findButton.TabIndex = 36;
            this.findButton.Text = "&Find";
            this.findButton.UseCompatibleTextRendering = true;
            this.findButton.UseVisualStyleBackColor = true;
            this.findButton.Click += new System.EventHandler(this.findButton_Click);
            // 
            // dataGridViewCustomer
            // 
            this.dataGridViewCustomer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCustomer.Location = new System.Drawing.Point(12, 291);
            this.dataGridViewCustomer.Name = "dataGridViewCustomer";
            this.dataGridViewCustomer.Size = new System.Drawing.Size(594, 118);
            this.dataGridViewCustomer.TabIndex = 37;
            // 
            // FindForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 413);
            this.Controls.Add(this.dataGridViewCustomer);
            this.Controls.Add(this.findButton);
            this.Controls.Add(this.faxTextBox);
            this.Controls.Add(this.faxLabel);
            this.Controls.Add(this.cellTextBox);
            this.Controls.Add(this.phoneTextBox);
            this.Controls.Add(this.cellLabel);
            this.Controls.Add(this.phoneLabel);
            this.Controls.Add(this.pinTextBox);
            this.Controls.Add(this.pinLabel);
            this.Controls.Add(this.lastNameTextBox);
            this.Controls.Add(this.firstNameTextBox);
            this.Controls.Add(this.lastNameLabel);
            this.Controls.Add(this.firstNameLabel);
            this.Name = "FindForm";
            this.Text = "FindForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCustomer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox faxTextBox;
        private System.Windows.Forms.Label faxLabel;
        private System.Windows.Forms.TextBox cellTextBox;
        private System.Windows.Forms.TextBox phoneTextBox;
        private System.Windows.Forms.Label cellLabel;
        private System.Windows.Forms.Label phoneLabel;
        private System.Windows.Forms.TextBox pinTextBox;
        private System.Windows.Forms.Label pinLabel;
        private System.Windows.Forms.TextBox lastNameTextBox;
        private System.Windows.Forms.TextBox firstNameTextBox;
        private System.Windows.Forms.Label lastNameLabel;
        private System.Windows.Forms.Label firstNameLabel;
        private System.Windows.Forms.Button findButton;
        private System.Windows.Forms.DataGridView dataGridViewCustomer;
    }
}