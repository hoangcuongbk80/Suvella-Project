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
            dateTimePickerShip = new DateTimePicker();
            label5 = new Label();
            richTextBoxNote = new RichTextBox();
            label6 = new Label();
            textBoxCustomerName = new TextBox();
            textBoxCustomerPhone = new TextBox();
            textBoxCustomerAddress = new TextBox();
            listBoxCustomerSuggestions = new ListBox();
            groupBox2 = new GroupBox();
            buttonSaveNewCustomer = new Button();
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
            label1 = new Label();
            comboBoxItems = new ComboBox();
            groupBox1 = new GroupBox();
            buttonMinus = new Button();
            buttonAdd = new Button();
            buttonAddItem = new Button();
            textBoxQuantity = new TextBox();
            label3 = new Label();
            textBoxPrice = new TextBox();
            label2 = new Label();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            groupBox6 = new GroupBox();
            richTextBoxOverall = new RichTextBox();
            groupBox3 = new GroupBox();
            tabPage2 = new TabPage();
            comboBoxSorting = new ComboBox();
            buttonSorting = new Button();
            richTextBoxOrderDetails = new RichTextBox();
            textBoxSearchOrder = new TextBox();
            buttonSearchOrder = new Button();
            buttonLoadOrders = new Button();
            dataGridViewOrder = new DataGridView();
            groupBox4 = new GroupBox();
            label14 = new Label();
            comboBoxPaymentStatus = new ComboBox();
            label4 = new Label();
            comboBoxOrderStatus = new ComboBox();
            buttonUpdate = new Button();
            tabPage3 = new TabPage();
            groupBox5 = new GroupBox();
            richTextBoxStatistic = new RichTextBox();
            buttonStatisticItem = new Button();
            dataGridViewItem = new DataGridView();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            groupBox6.SuspendLayout();
            groupBox3.SuspendLayout();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewOrder).BeginInit();
            groupBox4.SuspendLayout();
            tabPage3.SuspendLayout();
            groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewItem).BeginInit();
            SuspendLayout();
            // 
            // dateTimePickerShip
            // 
            dateTimePickerShip.Location = new Point(1313, 745);
            dateTimePickerShip.Name = "dateTimePickerShip";
            dateTimePickerShip.Size = new Size(500, 47);
            dateTimePickerShip.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.CadetBlue;
            label5.Location = new Point(1083, 745);
            label5.Name = "label5";
            label5.Size = new Size(209, 41);
            label5.TabIndex = 11;
            label5.Text = "Shipping Time";
            // 
            // richTextBoxNote
            // 
            richTextBoxNote.Location = new Point(1076, 857);
            richTextBoxNote.Name = "richTextBoxNote";
            richTextBoxNote.Size = new Size(843, 117);
            richTextBoxNote.TabIndex = 12;
            richTextBoxNote.Text = "";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.CadetBlue;
            label6.Location = new Point(1078, 813);
            label6.Name = "label6";
            label6.Size = new Size(84, 41);
            label6.TabIndex = 13;
            label6.Text = "Note";
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
            textBoxCustomerAddress.Size = new Size(888, 47);
            textBoxCustomerAddress.TabIndex = 17;
            textBoxCustomerAddress.TextChanged += textBoxCustomerAddress_TextChanged;
            // 
            // listBoxCustomerSuggestions
            // 
            listBoxCustomerSuggestions.FormattingEnabled = true;
            listBoxCustomerSuggestions.ItemHeight = 41;
            listBoxCustomerSuggestions.Location = new Point(54, 752);
            listBoxCustomerSuggestions.Name = "listBoxCustomerSuggestions";
            listBoxCustomerSuggestions.Size = new Size(888, 332);
            listBoxCustomerSuggestions.TabIndex = 18;
            listBoxCustomerSuggestions.SelectedIndexChanged += listBoxCustomerSuggestions_SelectedIndexChanged;
            // 
            // groupBox2
            // 
            groupBox2.BackColor = SystemColors.GradientInactiveCaption;
            groupBox2.Controls.Add(buttonSaveNewCustomer);
            groupBox2.Controls.Add(textBoxCustomerPhone);
            groupBox2.Controls.Add(label9);
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(textBoxCustomerAddress);
            groupBox2.Controls.Add(textBoxCustomerName);
            groupBox2.Location = new Point(35, 455);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(935, 662);
            groupBox2.TabIndex = 19;
            groupBox2.TabStop = false;
            groupBox2.Text = "Customer";
            // 
            // buttonSaveNewCustomer
            // 
            buttonSaveNewCustomer.BackColor = Color.Bisque;
            buttonSaveNewCustomer.Font = new Font("Algerian", 9.900001F, FontStyle.Bold | FontStyle.Italic);
            buttonSaveNewCustomer.Location = new Point(666, 18);
            buttonSaveNewCustomer.Name = "buttonSaveNewCustomer";
            buttonSaveNewCustomer.Size = new Size(189, 58);
            buttonSaveNewCustomer.TabIndex = 21;
            buttonSaveNewCustomer.Text = "Save";
            buttonSaveNewCustomer.UseVisualStyleBackColor = false;
            buttonSaveNewCustomer.Click += buttonSaveNewCustomer_Click;
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
            listBoxOrderItems.Location = new Point(1078, 79);
            listBoxOrderItems.Name = "listBoxOrderItems";
            listBoxOrderItems.Size = new Size(843, 332);
            listBoxOrderItems.TabIndex = 20;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = Color.CadetBlue;
            label10.Location = new Point(1076, 512);
            label10.Name = "label10";
            label10.Size = new Size(191, 41);
            label10.TabIndex = 24;
            label10.Text = "Shipping Fee";
            // 
            // textBoxShipFee
            // 
            textBoxShipFee.Location = new Point(1273, 506);
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
            label11.Location = new Point(1076, 627);
            label11.Name = "label11";
            label11.Size = new Size(251, 41);
            label11.TabIndex = 26;
            label11.Text = "Shipping Address";
            // 
            // textBoxShippingAddress
            // 
            textBoxShippingAddress.Location = new Point(1080, 671);
            textBoxShippingAddress.Name = "textBoxShippingAddress";
            textBoxShippingAddress.Size = new Size(842, 47);
            textBoxShippingAddress.TabIndex = 25;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.BackColor = Color.CadetBlue;
            label12.Location = new Point(1132, 448);
            label12.Name = "label12";
            label12.Size = new Size(135, 41);
            label12.TabIndex = 28;
            label12.Text = "Discount";
            // 
            // textBoxDiscount
            // 
            textBoxDiscount.Location = new Point(1275, 442);
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
            label13.Location = new Point(1380, 442);
            label13.Name = "label13";
            label13.Size = new Size(43, 41);
            label13.TabIndex = 29;
            label13.Text = "%";
            // 
            // richTextBoxToPay
            // 
            richTextBoxToPay.Location = new Point(1487, 421);
            richTextBoxToPay.Name = "richTextBoxToPay";
            richTextBoxToPay.Size = new Size(434, 225);
            richTextBoxToPay.TabIndex = 30;
            richTextBoxToPay.Text = "";
            // 
            // buttonSaveOrder
            // 
            buttonSaveOrder.BackColor = Color.Lime;
            buttonSaveOrder.Font = new Font("Algerian", 9.900001F, FontStyle.Bold | FontStyle.Italic);
            buttonSaveOrder.Location = new Point(304, 1004);
            buttonSaveOrder.Name = "buttonSaveOrder";
            buttonSaveOrder.Size = new Size(285, 58);
            buttonSaveOrder.TabIndex = 31;
            buttonSaveOrder.Text = "Save Order";
            buttonSaveOrder.UseVisualStyleBackColor = false;
            buttonSaveOrder.Click += buttonSaveOrder_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.LightBlue;
            label1.Location = new Point(54, 79);
            label1.Name = "label1";
            label1.Size = new Size(78, 41);
            label1.TabIndex = 35;
            label1.Text = "Item";
            // 
            // comboBoxItems
            // 
            comboBoxItems.FormattingEnabled = true;
            comboBoxItems.Location = new Point(50, 123);
            comboBoxItems.Name = "comboBoxItems";
            comboBoxItems.Size = new Size(841, 49);
            comboBoxItems.TabIndex = 34;
            comboBoxItems.SelectedIndexChanged += comboBoxItems_SelectedIndexChanged;
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
            groupBox1.Location = new Point(35, 26);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(935, 388);
            groupBox1.TabIndex = 36;
            groupBox1.TabStop = false;
            groupBox1.Text = "Menu";
            // 
            // buttonMinus
            // 
            buttonMinus.Location = new Point(802, 221);
            buttonMinus.Name = "buttonMinus";
            buttonMinus.Size = new Size(53, 47);
            buttonMinus.TabIndex = 10;
            buttonMinus.Text = "-";
            buttonMinus.UseVisualStyleBackColor = true;
            buttonMinus.Click += buttonMinus_Click;
            // 
            // buttonAdd
            // 
            buttonAdd.Location = new Point(743, 221);
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
            buttonAddItem.Font = new Font("Algerian", 9.900001F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            buttonAddItem.Location = new Point(667, 297);
            buttonAddItem.Name = "buttonAddItem";
            buttonAddItem.Size = new Size(188, 58);
            buttonAddItem.TabIndex = 8;
            buttonAddItem.Text = "Add";
            buttonAddItem.UseVisualStyleBackColor = false;
            buttonAddItem.Click += buttonAddItem_Click;
            // 
            // textBoxQuantity
            // 
            textBoxQuantity.Location = new Point(575, 221);
            textBoxQuantity.Name = "textBoxQuantity";
            textBoxQuantity.Size = new Size(162, 47);
            textBoxQuantity.TabIndex = 7;
            textBoxQuantity.Text = "1";
            textBoxQuantity.TextChanged += textBoxQuantity_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(575, 177);
            label3.Name = "label3";
            label3.Size = new Size(132, 41);
            label3.TabIndex = 6;
            label3.Text = "Quantity";
            // 
            // textBoxPrice
            // 
            textBoxPrice.Location = new Point(252, 221);
            textBoxPrice.Name = "textBoxPrice";
            textBoxPrice.Size = new Size(277, 47);
            textBoxPrice.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(252, 177);
            label2.Name = "label2";
            label2.Size = new Size(82, 41);
            label2.TabIndex = 4;
            label2.Text = "Price";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Location = new Point(0, 1);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(2816, 1276);
            tabControl1.TabIndex = 37;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(groupBox6);
            tabPage1.Controls.Add(listBoxCustomerSuggestions);
            tabPage1.Controls.Add(label1);
            tabPage1.Controls.Add(groupBox2);
            tabPage1.Controls.Add(listBoxOrderItems);
            tabPage1.Controls.Add(comboBoxItems);
            tabPage1.Controls.Add(dateTimePickerShip);
            tabPage1.Controls.Add(groupBox1);
            tabPage1.Controls.Add(label5);
            tabPage1.Controls.Add(label6);
            tabPage1.Controls.Add(label12);
            tabPage1.Controls.Add(richTextBoxNote);
            tabPage1.Controls.Add(textBoxShipFee);
            tabPage1.Controls.Add(richTextBoxToPay);
            tabPage1.Controls.Add(label10);
            tabPage1.Controls.Add(label13);
            tabPage1.Controls.Add(textBoxShippingAddress);
            tabPage1.Controls.Add(label11);
            tabPage1.Controls.Add(textBoxDiscount);
            tabPage1.Controls.Add(groupBox3);
            tabPage1.Location = new Point(10, 58);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(2796, 1208);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Place Order";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(richTextBoxOverall);
            groupBox6.Location = new Point(2025, 26);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new Size(748, 1091);
            groupBox6.TabIndex = 38;
            groupBox6.TabStop = false;
            groupBox6.Text = "Statistic";
            // 
            // richTextBoxOverall
            // 
            richTextBoxOverall.Location = new Point(26, 53);
            richTextBoxOverall.Name = "richTextBoxOverall";
            richTextBoxOverall.Size = new Size(699, 1014);
            richTextBoxOverall.TabIndex = 0;
            richTextBoxOverall.Text = "";
            // 
            // groupBox3
            // 
            groupBox3.BackColor = Color.CadetBlue;
            groupBox3.Controls.Add(buttonSaveOrder);
            groupBox3.Location = new Point(1035, 22);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(929, 1094);
            groupBox3.TabIndex = 37;
            groupBox3.TabStop = false;
            groupBox3.Text = "Order";
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(comboBoxSorting);
            tabPage2.Controls.Add(buttonSorting);
            tabPage2.Controls.Add(richTextBoxOrderDetails);
            tabPage2.Controls.Add(textBoxSearchOrder);
            tabPage2.Controls.Add(buttonSearchOrder);
            tabPage2.Controls.Add(buttonLoadOrders);
            tabPage2.Controls.Add(dataGridViewOrder);
            tabPage2.Controls.Add(groupBox4);
            tabPage2.Location = new Point(10, 58);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(2796, 1208);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Manage Order";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // comboBoxSorting
            // 
            comboBoxSorting.FormattingEnabled = true;
            comboBoxSorting.Items.AddRange(new object[] { "By Shipping Time" });
            comboBoxSorting.Location = new Point(1538, 38);
            comboBoxSorting.Name = "comboBoxSorting";
            comboBoxSorting.Size = new Size(302, 49);
            comboBoxSorting.TabIndex = 12;
            // 
            // buttonSorting
            // 
            buttonSorting.BackColor = Color.RosyBrown;
            buttonSorting.Font = new Font("Cooper Black", 9F);
            buttonSorting.Location = new Point(1335, 35);
            buttonSorting.Name = "buttonSorting";
            buttonSorting.Size = new Size(188, 58);
            buttonSorting.TabIndex = 11;
            buttonSorting.Text = "Sorting";
            buttonSorting.UseVisualStyleBackColor = false;
            buttonSorting.Click += buttonSorting_Click;
            // 
            // richTextBoxOrderDetails
            // 
            richTextBoxOrderDetails.Location = new Point(2083, 473);
            richTextBoxOrderDetails.Name = "richTextBoxOrderDetails";
            richTextBoxOrderDetails.Size = new Size(687, 680);
            richTextBoxOrderDetails.TabIndex = 4;
            richTextBoxOrderDetails.Text = "";
            // 
            // textBoxSearchOrder
            // 
            textBoxSearchOrder.Location = new Point(836, 42);
            textBoxSearchOrder.Name = "textBoxSearchOrder";
            textBoxSearchOrder.Size = new Size(316, 47);
            textBoxSearchOrder.TabIndex = 3;
            // 
            // buttonSearchOrder
            // 
            buttonSearchOrder.BackColor = Color.MediumAquamarine;
            buttonSearchOrder.Font = new Font("Cooper Black", 9F);
            buttonSearchOrder.Location = new Point(645, 42);
            buttonSearchOrder.Name = "buttonSearchOrder";
            buttonSearchOrder.Size = new Size(176, 52);
            buttonSearchOrder.TabIndex = 2;
            buttonSearchOrder.Text = "Search";
            buttonSearchOrder.UseVisualStyleBackColor = false;
            buttonSearchOrder.Click += buttonSearchOrder_Click;
            // 
            // buttonLoadOrders
            // 
            buttonLoadOrders.BackColor = Color.PaleGoldenrod;
            buttonLoadOrders.Font = new Font("Cooper Black", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonLoadOrders.Location = new Point(202, 38);
            buttonLoadOrders.Name = "buttonLoadOrders";
            buttonLoadOrders.Size = new Size(253, 55);
            buttonLoadOrders.TabIndex = 1;
            buttonLoadOrders.Text = "Load Orders";
            buttonLoadOrders.UseVisualStyleBackColor = false;
            buttonLoadOrders.Click += buttonLoadOrders_Click;
            // 
            // dataGridViewOrder
            // 
            dataGridViewOrder.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewOrder.Location = new Point(6, 120);
            dataGridViewOrder.Name = "dataGridViewOrder";
            dataGridViewOrder.RowHeadersWidth = 102;
            dataGridViewOrder.Size = new Size(2052, 1019);
            dataGridViewOrder.TabIndex = 0;
            dataGridViewOrder.SelectionChanged += dataGridViewOrder_SelectionChanged;
            // 
            // groupBox4
            // 
            groupBox4.BackColor = Color.PaleTurquoise;
            groupBox4.Controls.Add(label14);
            groupBox4.Controls.Add(comboBoxPaymentStatus);
            groupBox4.Controls.Add(label4);
            groupBox4.Controls.Add(comboBoxOrderStatus);
            groupBox4.Controls.Add(buttonUpdate);
            groupBox4.Location = new Point(2083, 134);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(563, 310);
            groupBox4.TabIndex = 10;
            groupBox4.TabStop = false;
            groupBox4.Text = "Update";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(327, 66);
            label14.Name = "label14";
            label14.Size = new Size(221, 41);
            label14.TabIndex = 9;
            label14.Text = "Payment Status";
            // 
            // comboBoxPaymentStatus
            // 
            comboBoxPaymentStatus.FormattingEnabled = true;
            comboBoxPaymentStatus.Items.AddRange(new object[] { "Unpaid", "Paid" });
            comboBoxPaymentStatus.Location = new Point(19, 65);
            comboBoxPaymentStatus.Name = "comboBoxPaymentStatus";
            comboBoxPaymentStatus.Size = new Size(302, 49);
            comboBoxPaymentStatus.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(327, 154);
            label4.Name = "label4";
            label4.Size = new Size(183, 41);
            label4.TabIndex = 8;
            label4.Text = "Order Status";
            // 
            // comboBoxOrderStatus
            // 
            comboBoxOrderStatus.FormattingEnabled = true;
            comboBoxOrderStatus.Items.AddRange(new object[] { "Processing", "Shipped", "Cancelled" });
            comboBoxOrderStatus.Location = new Point(19, 151);
            comboBoxOrderStatus.Name = "comboBoxOrderStatus";
            comboBoxOrderStatus.Size = new Size(302, 49);
            comboBoxOrderStatus.TabIndex = 6;
            // 
            // buttonUpdate
            // 
            buttonUpdate.BackColor = Color.Orange;
            buttonUpdate.Font = new Font("Cooper Black", 9F);
            buttonUpdate.Location = new Point(133, 233);
            buttonUpdate.Name = "buttonUpdate";
            buttonUpdate.Size = new Size(188, 58);
            buttonUpdate.TabIndex = 7;
            buttonUpdate.Text = "Update";
            buttonUpdate.UseVisualStyleBackColor = false;
            buttonUpdate.Click += buttonUpdate_Click;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(groupBox5);
            tabPage3.Location = new Point(10, 58);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(2796, 1208);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Statistic";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(richTextBoxStatistic);
            groupBox5.Controls.Add(buttonStatisticItem);
            groupBox5.Controls.Add(dataGridViewItem);
            groupBox5.Location = new Point(29, 29);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(2733, 1084);
            groupBox5.TabIndex = 0;
            groupBox5.TabStop = false;
            groupBox5.Text = "Item";
            // 
            // richTextBoxStatistic
            // 
            richTextBoxStatistic.Location = new Point(1724, 122);
            richTextBoxStatistic.Name = "richTextBoxStatistic";
            richTextBoxStatistic.Size = new Size(972, 945);
            richTextBoxStatistic.TabIndex = 2;
            richTextBoxStatistic.Text = "";
            // 
            // buttonStatisticItem
            // 
            buttonStatisticItem.BackColor = Color.PeachPuff;
            buttonStatisticItem.Font = new Font("Showcard Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonStatisticItem.ForeColor = SystemColors.MenuHighlight;
            buttonStatisticItem.Location = new Point(729, 40);
            buttonStatisticItem.Name = "buttonStatisticItem";
            buttonStatisticItem.Size = new Size(247, 67);
            buttonStatisticItem.TabIndex = 1;
            buttonStatisticItem.Text = "Tell Me";
            buttonStatisticItem.UseVisualStyleBackColor = false;
            buttonStatisticItem.Click += buttonStatisticItem_Click;
            // 
            // dataGridViewItem
            // 
            dataGridViewItem.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewItem.Location = new Point(18, 122);
            dataGridViewItem.Name = "dataGridViewItem";
            dataGridViewItem.RowHeadersWidth = 102;
            dataGridViewItem.Size = new Size(1624, 945);
            dataGridViewItem.TabIndex = 0;
            dataGridViewItem.CellValueChanged += dataGridViewItem_CellValueChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2842, 1289);
            Controls.Add(tabControl1);
            Name = "Form1";
            Text = "Suvella";
            Load += Form1_Load;
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            groupBox6.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewOrder).EndInit();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            tabPage3.ResumeLayout(false);
            groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewItem).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private DateTimePicker dateTimePickerShip;
        private Label label5;
        private RichTextBox richTextBoxNote;
        private Label label6;
        private TextBox textBoxCustomerName;
        private TextBox textBoxCustomerPhone;
        private TextBox textBoxCustomerAddress;
        private ListBox listBoxCustomerSuggestions;
        private GroupBox groupBox2;
        private Label label9;
        private Label label8;
        private Label label7;
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
        private Label label1;
        private ComboBox comboBoxItems;
        private GroupBox groupBox1;
        private Button buttonMinus;
        private Button buttonAdd;
        private Button buttonAddItem;
        private TextBox textBoxQuantity;
        private Label label3;
        private TextBox textBoxPrice;
        private Label label2;
        private Button buttonSaveNewCustomer;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private GroupBox groupBox3;
        private DataGridView dataGridViewOrder;
        private Button buttonLoadOrders;
        private TextBox textBoxSearchOrder;
        private Button buttonSearchOrder;
        private RichTextBox richTextBoxOrderDetails;
        private Button buttonUpdate;
        private ComboBox comboBoxOrderStatus;
        private ComboBox comboBoxPaymentStatus;
        private Label label4;
        private GroupBox groupBox4;
        private Label label14;
        private TabPage tabPage3;
        private GroupBox groupBox5;
        private Button buttonStatisticItem;
        private DataGridView dataGridViewItem;
        private ComboBox comboBoxSorting;
        private Button buttonSorting;
        private GroupBox groupBox6;
        private RichTextBox richTextBoxOverall;
        private RichTextBox richTextBoxStatistic;
    }
}
