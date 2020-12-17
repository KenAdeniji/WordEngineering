namespace Checkbook_MDI_Windows
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.labelAccountBalance = new System.Windows.Forms.Label();
            this.accountBalance = new System.Windows.Forms.Label();
            this.labelTransactionType = new System.Windows.Forms.Label();
            this.comboBoxTransactionType = new System.Windows.Forms.ComboBox();
            this.labelAmount = new System.Windows.Forms.Label();
            this.numericUpDownAmount = new System.Windows.Forms.NumericUpDown();
            this.buttonAddTransaction = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelAccountBalance
            // 
            this.labelAccountBalance.AutoSize = true;
            this.labelAccountBalance.Location = new System.Drawing.Point(28, 44);
            this.labelAccountBalance.Name = "labelAccountBalance";
            this.labelAccountBalance.Size = new System.Drawing.Size(89, 17);
            this.labelAccountBalance.TabIndex = 0;
            this.labelAccountBalance.Text = "Account Balance";
            this.labelAccountBalance.UseCompatibleTextRendering = true;
            this.labelAccountBalance.Click += new System.EventHandler(this.labelAccountBalance_Click);
            // 
            // accountBalance
            // 
            this.accountBalance.AutoSize = true;
            this.accountBalance.Location = new System.Drawing.Point(153, 45);
            this.accountBalance.Name = "accountBalance";
            this.accountBalance.Size = new System.Drawing.Size(0, 16);
            this.accountBalance.TabIndex = 1;
            this.accountBalance.UseCompatibleTextRendering = true;
            this.accountBalance.Click += new System.EventHandler(this.accountBalance_Click);
            // 
            // labelTransactionType
            // 
            this.labelTransactionType.AutoSize = true;
            this.labelTransactionType.Location = new System.Drawing.Point(26, 87);
            this.labelTransactionType.Name = "labelTransactionType";
            this.labelTransactionType.Size = new System.Drawing.Size(92, 17);
            this.labelTransactionType.TabIndex = 2;
            this.labelTransactionType.Text = "Transaction Type";
            this.labelTransactionType.UseCompatibleTextRendering = true;
            // 
            // comboBoxTransactionType
            // 
            this.comboBoxTransactionType.FormattingEnabled = true;
            this.comboBoxTransactionType.Items.AddRange(new object[] {
            "Check",
            "Deposit",
            "Interest",
            "Service Charge"});
            this.comboBoxTransactionType.Location = new System.Drawing.Point(161, 91);
            this.comboBoxTransactionType.Name = "comboBoxTransactionType";
            this.comboBoxTransactionType.Size = new System.Drawing.Size(121, 21);
            this.comboBoxTransactionType.TabIndex = 3;
            this.comboBoxTransactionType.SelectedIndexChanged += new System.EventHandler(this.comboBoxTransactionType_SelectedIndexChanged);
            // 
            // labelAmount
            // 
            this.labelAmount.AutoSize = true;
            this.labelAmount.Location = new System.Drawing.Point(26, 152);
            this.labelAmount.Name = "labelAmount";
            this.labelAmount.Size = new System.Drawing.Size(43, 17);
            this.labelAmount.TabIndex = 4;
            this.labelAmount.Text = "Amount";
            this.labelAmount.UseCompatibleTextRendering = true;
            // 
            // numericUpDownAmount
            // 
            this.numericUpDownAmount.Location = new System.Drawing.Point(161, 153);
            this.numericUpDownAmount.Name = "numericUpDownAmount";
            this.numericUpDownAmount.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownAmount.TabIndex = 5;
            // 
            // buttonAddTransaction
            // 
            this.buttonAddTransaction.Location = new System.Drawing.Point(118, 203);
            this.buttonAddTransaction.Name = "buttonAddTransaction";
            this.buttonAddTransaction.Size = new System.Drawing.Size(96, 23);
            this.buttonAddTransaction.TabIndex = 6;
            this.buttonAddTransaction.Text = "Add Transaction";
            this.buttonAddTransaction.UseCompatibleTextRendering = true;
            this.buttonAddTransaction.UseVisualStyleBackColor = true;
            this.buttonAddTransaction.Click += new System.EventHandler(this.buttonAddTransaction_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 300);
            this.Controls.Add(this.buttonAddTransaction);
            this.Controls.Add(this.numericUpDownAmount);
            this.Controls.Add(this.labelAmount);
            this.Controls.Add(this.comboBoxTransactionType);
            this.Controls.Add(this.labelTransactionType);
            this.Controls.Add(this.accountBalance);
            this.Controls.Add(this.labelAccountBalance);
            this.Name = "MainForm";
            this.Text = "Check Book - [Transaction]";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelAccountBalance;
        private System.Windows.Forms.Label accountBalance;
        private System.Windows.Forms.Label labelTransactionType;
        private System.Windows.Forms.ComboBox comboBoxTransactionType;
        private System.Windows.Forms.Label labelAmount;
        private System.Windows.Forms.NumericUpDown numericUpDownAmount;
        private System.Windows.Forms.Button buttonAddTransaction;
        private System.Windows.Forms.ErrorProvider errorProvider1;

    }
}

