namespace Suvella
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            comboBoxItems = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            textBoxPrice = new TextBox();
            label3 = new Label();
            textBoxQuantity = new TextBox();
            SuspendLayout();
            // 
            // comboBoxItems
            // 
            comboBoxItems.FormattingEnabled = true;
            comboBoxItems.Location = new Point(26, 114);
            comboBoxItems.Name = "comboBoxItems";
            comboBoxItems.Size = new Size(611, 49);
            comboBoxItems.TabIndex = 1;
            comboBoxItems.SelectedIndexChanged += comboBoxItems_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(25, 60);
            label1.Name = "label1";
            label1.Size = new Size(78, 41);
            label1.TabIndex = 3;
            label1.Text = "Item";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(27, 203);
            label2.Name = "label2";
            label2.Size = new Size(82, 41);
            label2.TabIndex = 4;
            label2.Text = "Price";
            // 
            // textBoxPrice
            // 
            textBoxPrice.Location = new Point(26, 249);
            textBoxPrice.Name = "textBoxPrice";
            textBoxPrice.Size = new Size(417, 47);
            textBoxPrice.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(27, 347);
            label3.Name = "label3";
            label3.Size = new Size(132, 41);
            label3.TabIndex = 6;
            label3.Text = "Quantity";
            // 
            // textBoxQuantity
            // 
            textBoxQuantity.Location = new Point(25, 391);
            textBoxQuantity.Name = "textBoxQuantity";
            textBoxQuantity.Size = new Size(417, 47);
            textBoxQuantity.TabIndex = 7;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1694, 865);
            Controls.Add(textBoxQuantity);
            Controls.Add(label3);
            Controls.Add(textBoxPrice);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(comboBoxItems);
            Name = "Form1";
            Text = "Suvella";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ComboBox comboBoxItems;
        private Label label1;
        private Label label2;
        private TextBox textBoxPrice;
        private Label label3;
        private TextBox textBoxQuantity;
    }
}
