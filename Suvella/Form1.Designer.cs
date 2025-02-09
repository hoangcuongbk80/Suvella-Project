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
            dateTimePickerShip = new DateTimePicker();
            label5 = new Label();
            richTextBoxNote = new RichTextBox();
            label6 = new Label();
            groupBox1 = new GroupBox();
            buttonMinus = new Button();
            buttonAdd = new Button();
            buttonAddItem = new Button();
            textBoxCustomerName = new TextBox();
            textBoxCustomerPhone = new TextBox();
            textBoxCustomerAddress = new TextBox();
            listBoxCustomerSuggestions = new ListBox();
            groupBox2 = new GroupBox();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            listBoxOrderItems = new ListBox();
            label10 = new Label();
            textBoxShipFee = new TextBox();
            label11 = new Label();
            textBoxShippingAddress = new TextBox();
            label12 = new Label();
            textBoxDiscount = new TextBox();
            label13 = new Label();
            richTextBoxToPay = new RichTextBox();
            buttonSaveOrder = new Button();
            buttonRemoveOrder = new Button();
            groupBox3 = new GroupBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // comboBoxItems
            // 
            comboBoxItems.FormattingEnabled = true;
            comboBoxItems.Location = new Point(21, 809);
            comboBoxItems.Name = "comboBoxItems";
            comboBoxItems.Size = new Size(841, 49);
            comboBoxItems.TabIndex = 1;
            comboBoxItems.SelectedIndexChanged += comboBoxItems_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.LightBlue;
            label1.Location = new Point(25, 765);
            label1.Name = "label1";
            label1.Size = new Size(78, 41);
            label1.TabIndex = 3;
            label1.Text = "Item";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(252, 156);
            label2.Name = "label2";
            label2.Size = new Size(82, 41);
            label2.TabIndex = 4;
            label2.Text = "Price";
            // 
            // textBoxPrice
            // 
            textBoxPrice.Location = new Point(252, 200);
            textBoxPrice.Name = "textBoxPrice";
            textBoxPrice.Size = new Size(277, 47);
            textBoxPrice.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(575, 156);
            label3.Name = "label3";
            label3.Size = new Size(132, 41);
            label3.TabIndex = 6;
            label3.Text = "Quantity";
            // 
            // textBoxQuantity
            // 
            textBoxQuantity.Location = new Point(575, 200);
            textBoxQuantity.Name = "textBoxQuantity";
            textBoxQuantity.Size = new Size(162, 47);
            textBoxQuantity.TabIndex = 7;
            textBoxQuantity.Text = "1";
            textBoxQuantity.TextChanged += textBoxQuantity_TextChanged;
            // 
            // dateTimePickerShip
            // 
            dateTimePickerShip.Location = new Point(1151, 749);
            dateTimePickerShip.Name = "dateTimePickerShip";
            dateTimePickerShip.Size = new Size(500, 47);
            dateTimePickerShip.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.CadetBlue;
            label5.Location = new Point(921, 749);
            label5.Name = "label5";
            label5.Size = new Size(209, 41);
            label5.TabIndex = 11;
            label5.Text = "Shipping Time";
            // 
            // richTextBoxNote
            // 
            richTextBoxNote.Location = new Point(914, 861);
            richTextBoxNote.Name = "richTextBoxNote";
            richTextBoxNote.Size = new Size(843, 117);
            richTextBoxNote.TabIndex = 12;
            richTextBoxNote.Text = "";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.CadetBlue;
            label6.Location = new Point(914, 817);
            label6.Name = "label6";
            label6.Size = new Size(84, 41);
            label6.TabIndex = 13;
            label6.Text = "Note";
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.LightBlue;
            groupBox1.Controls.Add(buttonMinus);
            groupBox1.Controls.Add(buttonAdd);
            groupBox1.Controls.Add(buttonAddItem);
            groupBox1.Controls.Add(textBoxQuantity);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(textBoxPrice);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(6, 731);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(871, 371);
            groupBox1.TabIndex = 14;
            groupBox1.TabStop = false;
            groupBox1.Text = "Menu";
            // 
            // buttonMinus
            // 
            buttonMinus.Location = new Point(802, 200);
            buttonMinus.Name = "buttonMinus";
            buttonMinus.Size = new Size(53, 47);
            buttonMinus.TabIndex = 10;
            buttonMinus.Text = "-";
            buttonMinus.UseVisualStyleBackColor = true;
            buttonMinus.Click += buttonMinus_Click;
            // 
            // buttonAdd
            // 
            buttonAdd.Location = new Point(743, 200);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(53, 47);
            buttonAdd.TabIndex = 9;
            buttonAdd.Text = "+";
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += buttonAdd_Click;
            // 
            // buttonAddItem
            // 
            buttonAddItem.BackColor = Color.BurlyWood;
            buttonAddItem.Location = new Point(667, 292);
            buttonAddItem.Name = "buttonAddItem";
            buttonAddItem.Size = new Size(188, 58);
            buttonAddItem.TabIndex = 8;
            buttonAddItem.Text = "Add";
            buttonAddItem.UseVisualStyleBackColor = false;
            buttonAddItem.Click += buttonAddItem_Click;
            // 
            // textBoxCustomerName
            // 
            textBoxCustomerName.Location = new Point(19, 100);
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
            textBoxCustomerAddress.Location = new Point(19, 207);
            textBoxCustomerAddress.Name = "textBoxCustomerAddress";
            textBoxCustomerAddress.Size = new Size(838, 47);
            textBoxCustomerAddress.TabIndex = 17;
            // 
            // listBoxCustomerSuggestions
            // 
            listBoxCustomerSuggestions.FormattingEnabled = true;
            listBoxCustomerSuggestions.ItemHeight = 41;
            listBoxCustomerSuggestions.Location = new Point(24, 324);
            listBoxCustomerSuggestions.Name = "listBoxCustomerSuggestions";
            listBoxCustomerSuggestions.Size = new Size(838, 332);
            listBoxCustomerSuggestions.TabIndex = 18;
            listBoxCustomerSuggestions.SelectedIndexChanged += listBoxCustomerSuggestions_SelectedIndexChanged;
            // 
            // groupBox2
            // 
            groupBox2.BackColor = SystemColors.GradientInactiveCaption;
            groupBox2.Controls.Add(textBoxCustomerPhone);
            groupBox2.Controls.Add(label9);
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(textBoxCustomerAddress);
            groupBox2.Controls.Add(textBoxCustomerName);
            groupBox2.Location = new Point(5, 27);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(871, 677);
            groupBox2.TabIndex = 19;
            groupBox2.TabStop = false;
            groupBox2.Text = "Customer";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(17, 163);
            label9.Name = "label9";
            label9.Size = new Size(125, 41);
            label9.TabIndex = 20;
            label9.Text = "Address";
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
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(14, 56);
            label7.Name = "label7";
            label7.Size = new Size(97, 41);
            label7.TabIndex = 18;
            label7.Text = "Name";
            // 
            // listBoxOrderItems
            // 
            listBoxOrderItems.FormattingEnabled = true;
            listBoxOrderItems.ItemHeight = 41;
            listBoxOrderItems.Location = new Point(916, 83);
            listBoxOrderItems.Name = "listBoxOrderItems";
            listBoxOrderItems.Size = new Size(843, 332);
            listBoxOrderItems.TabIndex = 20;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = Color.CadetBlue;
            label10.Location = new Point(914, 516);
            label10.Name = "label10";
            label10.Size = new Size(191, 41);
            label10.TabIndex = 24;
            label10.Text = "Shipping Fee";
            // 
            // textBoxShipFee
            // 
            textBoxShipFee.Location = new Point(1111, 510);
            textBoxShipFee.Name = "textBoxShipFee";
            textBoxShipFee.Size = new Size(179, 47);
            textBoxShipFee.TabIndex = 23;
            textBoxShipFee.Text = "0";
            textBoxShipFee.TextChanged += textBoxShipFee_TextChanged;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.BackColor = Color.CadetBlue;
            label11.Location = new Point(914, 631);
            label11.Name = "label11";
            label11.Size = new Size(251, 41);
            label11.TabIndex = 26;
            label11.Text = "Shipping Address";
            // 
            // textBoxShippingAddress
            // 
            textBoxShippingAddress.Location = new Point(918, 675);
            textBoxShippingAddress.Name = "textBoxShippingAddress";
            textBoxShippingAddress.Size = new Size(842, 47);
            textBoxShippingAddress.TabIndex = 25;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.BackColor = Color.CadetBlue;
            label12.Location = new Point(918, 452);
            label12.Name = "label12";
            label12.Size = new Size(135, 41);
            label12.TabIndex = 28;
            label12.Text = "Discount";
            // 
            // textBoxDiscount
            // 
            textBoxDiscount.Location = new Point(1115, 446);
            textBoxDiscount.Name = "textBoxDiscount";
            textBoxDiscount.Size = new Size(102, 47);
            textBoxDiscount.TabIndex = 27;
            textBoxDiscount.Text = "0";
            textBoxDiscount.TextChanged += textBoxDiscount_TextChanged;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.BackColor = Color.CadetBlue;
            label13.Location = new Point(1237, 446);
            label13.Name = "label13";
            label13.Size = new Size(43, 41);
            label13.TabIndex = 29;
            label13.Text = "%";
            // 
            // richTextBoxToPay
            // 
            richTextBoxToPay.Location = new Point(1325, 425);
            richTextBoxToPay.Name = "richTextBoxToPay";
            richTextBoxToPay.Size = new Size(434, 225);
            richTextBoxToPay.TabIndex = 30;
            richTextBoxToPay.Text = "";
            // 
            // buttonSaveOrder
            // 
            buttonSaveOrder.BackColor = Color.Lime;
            buttonSaveOrder.Location = new Point(1038, 1023);
            buttonSaveOrder.Name = "buttonSaveOrder";
            buttonSaveOrder.Size = new Size(188, 58);
            buttonSaveOrder.TabIndex = 31;
            buttonSaveOrder.Text = "Save Order";
            buttonSaveOrder.UseVisualStyleBackColor = false;
            buttonSaveOrder.Click += buttonSaveOrder_Click;
            // 
            // buttonRemoveOrder
            // 
            buttonRemoveOrder.BackColor = Color.LightCoral;
            buttonRemoveOrder.Location = new Point(1430, 1021);
            buttonRemoveOrder.Name = "buttonRemoveOrder";
            buttonRemoveOrder.Size = new Size(235, 58);
            buttonRemoveOrder.TabIndex = 32;
            buttonRemoveOrder.Text = "Remove Order";
            buttonRemoveOrder.UseVisualStyleBackColor = false;
            buttonRemoveOrder.Click += buttonRemoveOrder_Click;
            // 
            // groupBox3
            // 
            groupBox3.BackColor = Color.CadetBlue;
            groupBox3.Location = new Point(896, 27);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(886, 1075);
            groupBox3.TabIndex = 33;
            groupBox3.TabStop = false;
            groupBox3.Text = "Order";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1792, 1110);
            Controls.Add(buttonRemoveOrder);
            Controls.Add(buttonSaveOrder);
            Controls.Add(richTextBoxToPay);
            Controls.Add(label13);
            Controls.Add(label12);
            Controls.Add(textBoxDiscount);
            Controls.Add(label11);
            Controls.Add(textBoxShippingAddress);
            Controls.Add(label10);
            Controls.Add(textBoxShipFee);
            Controls.Add(listBoxOrderItems);
            Controls.Add(label6);
            Controls.Add(listBoxCustomerSuggestions);
            Controls.Add(richTextBoxNote);
            Controls.Add(label5);
            Controls.Add(dateTimePickerShip);
            Controls.Add(label1);
            Controls.Add(comboBoxItems);
            Controls.Add(groupBox1);
            Controls.Add(groupBox2);
            Controls.Add(groupBox3);
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
        private DateTimePicker dateTimePickerShip;
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
        private Button buttonAddItem;
        private ListBox listBoxOrderItems;
        private Label label10;
        private TextBox textBoxShipFee;
        private Label label11;
        private TextBox textBoxShippingAddress;
        private Label label12;
        private TextBox textBoxDiscount;
        private Label label13;
        private RichTextBox richTextBoxToPay;
        private Button buttonSaveOrder;
        private Button buttonRemoveOrder;
        private GroupBox groupBox3;
        private Button buttonMinus;
        private Button buttonAdd;
    }
}
