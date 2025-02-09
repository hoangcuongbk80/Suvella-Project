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
            dateTimePickerOrder = new DateTimePicker();
            dateTimePickerShip = new DateTimePicker();
            label4 = new Label();
            label5 = new Label();
            richTextBoxNote = new RichTextBox();
            label6 = new Label();
            groupBox1 = new GroupBox();
            textBoxCustomerName = new TextBox();
            textBoxCustomerPhone = new TextBox();
            textBoxCustomerAddress = new TextBox();
            listBoxCustomerSuggestions = new ListBox();
            groupBox2 = new GroupBox();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // comboBoxItems
            // 
            comboBoxItems.FormattingEnabled = true;
            comboBoxItems.Location = new Point(26, 443);
            comboBoxItems.Name = "comboBoxItems";
            comboBoxItems.Size = new Size(841, 49);
            comboBoxItems.TabIndex = 1;
            comboBoxItems.SelectedIndexChanged += comboBoxItems_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.LightBlue;
            label1.Location = new Point(30, 386);
            label1.Name = "label1";
            label1.Size = new Size(78, 41);
            label1.TabIndex = 3;
            label1.Text = "Item";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(16, 348);
            label2.Name = "label2";
            label2.Size = new Size(82, 41);
            label2.TabIndex = 4;
            label2.Text = "Price";
            // 
            // textBoxPrice
            // 
            textBoxPrice.Location = new Point(15, 394);
            textBoxPrice.Name = "textBoxPrice";
            textBoxPrice.Size = new Size(305, 47);
            textBoxPrice.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(10, 210);
            label3.Name = "label3";
            label3.Size = new Size(132, 41);
            label3.TabIndex = 6;
            label3.Text = "Quantity";
            // 
            // textBoxQuantity
            // 
            textBoxQuantity.Location = new Point(15, 254);
            textBoxQuantity.Name = "textBoxQuantity";
            textBoxQuantity.Size = new Size(306, 47);
            textBoxQuantity.TabIndex = 7;
            textBoxQuantity.TextChanged += textBoxQuantity_TextChanged;
            // 
            // dateTimePickerOrder
            // 
            dateTimePickerOrder.Location = new Point(367, 575);
            dateTimePickerOrder.Name = "dateTimePickerOrder";
            dateTimePickerOrder.Size = new Size(500, 47);
            dateTimePickerOrder.TabIndex = 8;
            // 
            // dateTimePickerShip
            // 
            dateTimePickerShip.Location = new Point(367, 715);
            dateTimePickerShip.Name = "dateTimePickerShip";
            dateTimePickerShip.Size = new Size(500, 47);
            dateTimePickerShip.TabIndex = 9;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.LightBlue;
            label4.Location = new Point(367, 531);
            label4.Name = "label4";
            label4.Size = new Size(168, 41);
            label4.TabIndex = 10;
            label4.Text = "Order Time";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.LightBlue;
            label5.Location = new Point(367, 671);
            label5.Name = "label5";
            label5.Size = new Size(209, 41);
            label5.TabIndex = 11;
            label5.Text = "Shipping Time";
            // 
            // richTextBoxNote
            // 
            richTextBoxNote.Location = new Point(24, 857);
            richTextBoxNote.Name = "richTextBoxNote";
            richTextBoxNote.Size = new Size(843, 201);
            richTextBoxNote.TabIndex = 12;
            richTextBoxNote.Text = "";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.LightBlue;
            label6.Location = new Point(26, 804);
            label6.Name = "label6";
            label6.Size = new Size(84, 41);
            label6.TabIndex = 13;
            label6.Text = "Note";
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.LightBlue;
            groupBox1.Controls.Add(textBoxQuantity);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(textBoxPrice);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(11, 323);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(884, 768);
            groupBox1.TabIndex = 14;
            groupBox1.TabStop = false;
            groupBox1.Text = "Order";
            // 
            // textBoxCustomerName
            // 
            textBoxCustomerName.Location = new Point(12, 100);
            textBoxCustomerName.Name = "textBoxCustomerName";
            textBoxCustomerName.Size = new Size(339, 47);
            textBoxCustomerName.TabIndex = 15;
            textBoxCustomerName.TextChanged += textBoxCustomerName_TextChanged;
            // 
            // textBoxCustomerPhone
            // 
            textBoxCustomerPhone.Location = new Point(386, 100);
            textBoxCustomerPhone.Name = "textBoxCustomerPhone";
            textBoxCustomerPhone.Size = new Size(469, 47);
            textBoxCustomerPhone.TabIndex = 16;
            // 
            // textBoxCustomerAddress
            // 
            textBoxCustomerAddress.Location = new Point(6, 207);
            textBoxCustomerAddress.Name = "textBoxCustomerAddress";
            textBoxCustomerAddress.Size = new Size(851, 47);
            textBoxCustomerAddress.TabIndex = 17;
            // 
            // listBoxCustomerSuggestions
            // 
            listBoxCustomerSuggestions.FormattingEnabled = true;
            listBoxCustomerSuggestions.ItemHeight = 41;
            listBoxCustomerSuggestions.Location = new Point(888, 17);
            listBoxCustomerSuggestions.Name = "listBoxCustomerSuggestions";
            listBoxCustomerSuggestions.Size = new Size(1005, 250);
            listBoxCustomerSuggestions.TabIndex = 18;
            listBoxCustomerSuggestions.SelectedIndexChanged += listBoxCustomerSuggestions_SelectedIndexChanged;
            // 
            // groupBox2
            // 
            groupBox2.BackColor = SystemColors.GradientInactiveCaption;
            groupBox2.Controls.Add(textBoxCustomerPhone);
            groupBox2.Controls.Add(listBoxCustomerSuggestions);
            groupBox2.Controls.Add(label9);
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(textBoxCustomerAddress);
            groupBox2.Controls.Add(textBoxCustomerName);
            groupBox2.Location = new Point(12, 27);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1920, 290);
            groupBox2.TabIndex = 19;
            groupBox2.TabStop = false;
            groupBox2.Text = "Customer";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(12, 56);
            label7.Name = "label7";
            label7.Size = new Size(97, 41);
            label7.TabIndex = 18;
            label7.Text = "Name";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(386, 56);
            label8.Name = "label8";
            label8.Size = new Size(103, 41);
            label8.TabIndex = 19;
            label8.Text = "Phone";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(6, 163);
            label9.Name = "label9";
            label9.Size = new Size(125, 41);
            label9.TabIndex = 20;
            label9.Text = "Address";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1944, 1143);
            Controls.Add(label6);
            Controls.Add(richTextBoxNote);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(dateTimePickerShip);
            Controls.Add(dateTimePickerOrder);
            Controls.Add(label1);
            Controls.Add(comboBoxItems);
            Controls.Add(groupBox1);
            Controls.Add(groupBox2);
            Name = "Form1";
            Text = "Suvella";
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
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
        private DateTimePicker dateTimePickerOrder;
        private DateTimePicker dateTimePickerShip;
        private Label label4;
        private Label label5;
        private RichTextBox richTextBoxNote;
        private Label label6;
        private GroupBox groupBox1;
        private TextBox textBoxCustomerName;
        private TextBox textBoxCustomerPhone;
        private TextBox textBoxCustomerAddress;
        private ListBox listBoxCustomerSuggestions;
        private GroupBox groupBox2;
        private Label label9;
        private Label label8;
        private Label label7;
    }
}
