namespace Product_Information
{
    partial class ProductForm
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
            this.productNameComboBox = new System.Windows.Forms.ComboBox();
            this.comboBoxProductName = new System.Windows.Forms.Label();
            this.labelProductId = new System.Windows.Forms.Label();
            this.productIdLabel = new System.Windows.Forms.Label();
            this.labelProductName = new System.Windows.Forms.Label();
            this.productNameLabel = new System.Windows.Forms.Label();
            this.labelUnitPrice = new System.Windows.Forms.Label();
            this.unitPriceLabel = new System.Windows.Forms.Label();
            this.labelUnitsInStock = new System.Windows.Forms.Label();
            this.unitsInStockLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // productNameComboBox
            // 
            this.productNameComboBox.FormattingEnabled = true;
            this.productNameComboBox.Location = new System.Drawing.Point(104, 37);
            this.productNameComboBox.Name = "productNameComboBox";
            this.productNameComboBox.Size = new System.Drawing.Size(303, 21);
            this.productNameComboBox.TabIndex = 0;
            this.productNameComboBox.SelectedIndexChanged += new System.EventHandler(this.ProductNameComboBox_SelectedIndexChanged);
            // 
            // comboBoxProductName
            // 
            this.comboBoxProductName.AutoSize = true;
            this.comboBoxProductName.Location = new System.Drawing.Point(12, 41);
            this.comboBoxProductName.Name = "comboBoxProductName";
            this.comboBoxProductName.Size = new System.Drawing.Size(76, 17);
            this.comboBoxProductName.TabIndex = 1;
            this.comboBoxProductName.Text = "Product Name";
            this.comboBoxProductName.UseCompatibleTextRendering = true;
            // 
            // labelProductId
            // 
            this.labelProductId.AutoSize = true;
            this.labelProductId.Location = new System.Drawing.Point(12, 83);
            this.labelProductId.Name = "labelProductId";
            this.labelProductId.Size = new System.Drawing.Size(56, 17);
            this.labelProductId.TabIndex = 2;
            this.labelProductId.Text = "Product Id";
            this.labelProductId.UseCompatibleTextRendering = true;
            // 
            // productIdLabel
            // 
            this.productIdLabel.AutoSize = true;
            this.productIdLabel.Location = new System.Drawing.Point(109, 82);
            this.productIdLabel.Name = "productIdLabel";
            this.productIdLabel.Size = new System.Drawing.Size(56, 17);
            this.productIdLabel.TabIndex = 3;
            this.productIdLabel.Text = "Product Id";
            this.productIdLabel.UseCompatibleTextRendering = true;
            // 
            // labelProductName
            // 
            this.labelProductName.AutoSize = true;
            this.labelProductName.Location = new System.Drawing.Point(12, 118);
            this.labelProductName.Name = "labelProductName";
            this.labelProductName.Size = new System.Drawing.Size(76, 17);
            this.labelProductName.TabIndex = 4;
            this.labelProductName.Text = "Product Name";
            this.labelProductName.UseCompatibleTextRendering = true;
            // 
            // productNameLabel
            // 
            this.productNameLabel.AutoSize = true;
            this.productNameLabel.Location = new System.Drawing.Point(109, 118);
            this.productNameLabel.Name = "productNameLabel";
            this.productNameLabel.Size = new System.Drawing.Size(76, 17);
            this.productNameLabel.TabIndex = 5;
            this.productNameLabel.Text = "Product Name";
            this.productNameLabel.UseCompatibleTextRendering = true;
            // 
            // labelUnitPrice
            // 
            this.labelUnitPrice.AutoSize = true;
            this.labelUnitPrice.Location = new System.Drawing.Point(12, 152);
            this.labelUnitPrice.Name = "labelUnitPrice";
            this.labelUnitPrice.Size = new System.Drawing.Size(53, 17);
            this.labelUnitPrice.TabIndex = 6;
            this.labelUnitPrice.Text = "Unit Price";
            this.labelUnitPrice.UseCompatibleTextRendering = true;
            // 
            // unitPriceLabel
            // 
            this.unitPriceLabel.AutoSize = true;
            this.unitPriceLabel.Location = new System.Drawing.Point(109, 152);
            this.unitPriceLabel.Name = "unitPriceLabel";
            this.unitPriceLabel.Size = new System.Drawing.Size(53, 17);
            this.unitPriceLabel.TabIndex = 7;
            this.unitPriceLabel.Text = "Unit Price";
            this.unitPriceLabel.UseCompatibleTextRendering = true;
            // 
            // labelUnitsInStock
            // 
            this.labelUnitsInStock.AutoSize = true;
            this.labelUnitsInStock.Location = new System.Drawing.Point(12, 188);
            this.labelUnitsInStock.Name = "labelUnitsInStock";
            this.labelUnitsInStock.Size = new System.Drawing.Size(73, 17);
            this.labelUnitsInStock.TabIndex = 8;
            this.labelUnitsInStock.Text = "Units in Stock";
            this.labelUnitsInStock.UseCompatibleTextRendering = true;
            // 
            // unitsInStockLabel
            // 
            this.unitsInStockLabel.AutoSize = true;
            this.unitsInStockLabel.Location = new System.Drawing.Point(112, 190);
            this.unitsInStockLabel.Name = "unitsInStockLabel";
            this.unitsInStockLabel.Size = new System.Drawing.Size(73, 17);
            this.unitsInStockLabel.TabIndex = 9;
            this.unitsInStockLabel.Text = "Units in Stock";
            this.unitsInStockLabel.UseCompatibleTextRendering = true;
            // 
            // ProductForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 273);
            this.Controls.Add(this.unitsInStockLabel);
            this.Controls.Add(this.labelUnitsInStock);
            this.Controls.Add(this.unitPriceLabel);
            this.Controls.Add(this.labelUnitPrice);
            this.Controls.Add(this.productNameLabel);
            this.Controls.Add(this.labelProductName);
            this.Controls.Add(this.productIdLabel);
            this.Controls.Add(this.labelProductId);
            this.Controls.Add(this.comboBoxProductName);
            this.Controls.Add(this.productNameComboBox);
            this.Name = "ProductForm";
            this.Text = "Product Information Form";
            this.Load += new System.EventHandler(this.ProductForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox productNameComboBox;
        private System.Windows.Forms.Label comboBoxProductName;
        private System.Windows.Forms.Label labelProductId;
        private System.Windows.Forms.Label productIdLabel;
        private System.Windows.Forms.Label labelProductName;
        private System.Windows.Forms.Label productNameLabel;
        private System.Windows.Forms.Label labelUnitPrice;
        private System.Windows.Forms.Label unitPriceLabel;
        private System.Windows.Forms.Label labelUnitsInStock;
        private System.Windows.Forms.Label unitsInStockLabel;
    }
}

