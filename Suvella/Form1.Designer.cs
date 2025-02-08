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
            SuspendLayout();
            // 
            // comboBoxItems
            // 
            comboBoxItems.FormattingEnabled = true;
            comboBoxItems.Location = new Point(27, 152);
            comboBoxItems.Name = "comboBoxItems";
            comboBoxItems.Size = new Size(841, 49);
            comboBoxItems.TabIndex = 1;
            comboBoxItems.SelectedIndexChanged += comboBoxItems_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(25, 95);
            label1.Name = "label1";
            label1.Size = new Size(78, 41);
            label1.TabIndex = 3;
            label1.Text = "Item";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(27, 238);
            label2.Name = "label2";
            label2.Size = new Size(82, 41);
            label2.TabIndex = 4;
            label2.Text = "Price";
            // 
            // textBoxPrice
            // 
            textBoxPrice.Location = new Point(26, 284);
            textBoxPrice.Name = "textBoxPrice";
            textBoxPrice.Size = new Size(305, 47);
            textBoxPrice.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(27, 382);
            label3.Name = "label3";
            label3.Size = new Size(132, 41);
            label3.TabIndex = 6;
            label3.Text = "Quantity";
            // 
            // textBoxQuantity
            // 
            textBoxQuantity.Location = new Point(25, 426);
            textBoxQuantity.Name = "textBoxQuantity";
            textBoxQuantity.Size = new Size(306, 47);
            textBoxQuantity.TabIndex = 7;
            // 
            // dateTimePickerOrder
            // 
            dateTimePickerOrder.Location = new Point(368, 284);
            dateTimePickerOrder.Name = "dateTimePickerOrder";
            dateTimePickerOrder.Size = new Size(500, 47);
            dateTimePickerOrder.TabIndex = 8;
            // 
            // dateTimePickerShip
            // 
            dateTimePickerShip.Location = new Point(368, 424);
            dateTimePickerShip.Name = "dateTimePickerShip";
            dateTimePickerShip.Size = new Size(500, 47);
            dateTimePickerShip.TabIndex = 9;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(368, 240);
            label4.Name = "label4";
            label4.Size = new Size(168, 41);
            label4.TabIndex = 10;
            label4.Text = "Order Time";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(368, 380);
            label5.Name = "label5";
            label5.Size = new Size(209, 41);
            label5.TabIndex = 11;
            label5.Text = "Shipping Time";
            // 
            // richTextBoxNote
            // 
            richTextBoxNote.Location = new Point(25, 566);
            richTextBoxNote.Name = "richTextBoxNote";
            richTextBoxNote.Size = new Size(843, 201);
            richTextBoxNote.TabIndex = 12;
            richTextBoxNote.Text = "";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(27, 513);
            label6.Name = "label6";
            label6.Size = new Size(84, 41);
            label6.TabIndex = 13;
            label6.Text = "Note";
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.LightBlue;
            groupBox1.Location = new Point(12, 32);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(884, 768);
            groupBox1.TabIndex = 14;
            groupBox1.TabStop = false;
            groupBox1.Text = "Order";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1694, 865);
            Controls.Add(label6);
            Controls.Add(richTextBoxNote);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(dateTimePickerShip);
            Controls.Add(dateTimePickerOrder);
            Controls.Add(textBoxQuantity);
            Controls.Add(label3);
            Controls.Add(textBoxPrice);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(comboBoxItems);
            Controls.Add(groupBox1);
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
        private DateTimePicker dateTimePickerOrder;
        private DateTimePicker dateTimePickerShip;
        private Label label4;
        private Label label5;
        private RichTextBox richTextBoxNote;
        private Label label6;
        private GroupBox groupBox1;
    }
}
