using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Suvella
{
    public partial class Form1 : Form
    {
        List<string> items = new List<string>();
        List<decimal> prices = new List<decimal>();
        List<Customer> customers = new List<Customer>();
        Order currentOrder;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string menuFilePath = "menu.xlsx";
            string customerFilePath = "customers.xlsx";

            try
            {
                LoadMenuData(menuFilePath);
                LoadCustomerData(customerFilePath);
                SetUpCustomerAutoComplete();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }

            InitializeCurrentOrder();
            ConfigureDataGridView();
        }

        private void ConfigureDataGridView()
        {
            // Set column headers
            dataGridViewOrder.Columns.Clear();  // Clear existing columns first (if any)

            dataGridViewOrder.Columns.Add("OrderID", "Order ID");
            dataGridViewOrder.Columns.Add("CustomerName", "Customer Name");
            dataGridViewOrder.Columns.Add("OrderTime", "Order Time");
            dataGridViewOrder.Columns.Add("TotalPrice", "Total Price");
            dataGridViewOrder.Columns.Add("PaymentStatus", "Payment Status");
            dataGridViewOrder.Columns.Add("OrderStatus", "Order Status");
            dataGridViewOrder.Columns.Add("Discount", "Discount");

            // Enable automatic column sizing
            dataGridViewOrder.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewOrder.SelectionMode = DataGridViewSelectionMode.FullRowSelect;  // Allow row selection
            dataGridViewOrder.ReadOnly = true;  // Make the grid read-only (optional, based on your needs)
        }


        private void InitializeCurrentOrder()
        {
            // Ensure the currentOrder is initialized
            Customer customer = new Customer
            {
                Name = textBoxCustomerName.Text,
                Address = textBoxCustomerAddress.Text,
                Phone = textBoxCustomerPhone.Text
            };

            // Initialize currentOrder with the Customer object
            currentOrder = new Order(customer)
            {
                // Initialize other properties of the currentOrder
                OrderItems = new List<OrderItem>(),  // Empty list for order items initially
            };
        }
        private void LoadMenuData(string filePath)
        {
            try
            {
                using (var package = new ExcelPackage(new FileInfo(filePath)))
                {
                    var worksheet = package.Workbook.Worksheets[0];

                    comboBoxItems.Items.Clear();
                    items.Clear();
                    prices.Clear();

                    // Loop through the rows and add items and prices to the lists
                    for (int row = 2; row <= worksheet.Dimension.End.Row; row++) // Start from row 2 to skip header
                    {
                        string item = worksheet.Cells[row, 1].Text;  // Column 1: Item
                        string priceText = worksheet.Cells[row, 2].Text; // Column 2: Price
                        decimal price;

                        // Parse the price and add to the list
                        if (decimal.TryParse(priceText, out price))
                        {
                            items.Add(item);
                            prices.Add(price);

                            // Add item to comboBoxItems
                            comboBoxItems.Items.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading menu data: " + ex.Message);
            }
        }

        private void LoadCustomerData(string filePath)
        {
            try
            {
                using (var package = new ExcelPackage(new FileInfo(filePath)))
                {
                    var worksheet = package.Workbook.Worksheets[0];

                    customers.Clear();

                    // Loop through the rows and add customer data to the list
                    for (int row = 2; row <= worksheet.Dimension.End.Row; row++) // Start from row 2 to skip header
                    {
                        string name = worksheet.Cells[row, 1].Text;  // Column 1: Customer Name
                        string phone = worksheet.Cells[row, 2].Text; // Column 2: Phone Number
                        string address = worksheet.Cells[row, 3].Text; // Column 3: Address

                        customers.Add(new Customer { Name = name, Phone = phone, Address = address });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading customer data: " + ex.Message);
            }
        }

        private void SetUpCustomerAutoComplete()
        {
            // Set up AutoComplete for customer name (using TextBox)
            textBoxCustomerName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBoxCustomerName.AutoCompleteSource = AutoCompleteSource.CustomSource;

            // Create AutoCompleteStringCollection for customer names
            AutoCompleteStringCollection customerNames = new AutoCompleteStringCollection();

            // Add customer names to the AutoComplete collection
            foreach (var customer in customers)
            {
                customerNames.Add(customer.Name);
            }

            // Assign the AutoComplete collection to the TextBox
            textBoxCustomerName.AutoCompleteCustomSource = customerNames;
        }

        // Event handler to update customer info when a name is typed
        private void textBoxCustomerName_TextChanged(object sender, EventArgs e)
        {
            // Get the customer name typed in the TextBox
            string typedName = textBoxCustomerName.Text;

            // Find all customers whose names match the typed input
            var matchingCustomers = customers.Where(c => c.Name.StartsWith(typedName, StringComparison.OrdinalIgnoreCase)).ToList();

            // If we find any matching customers, show their details
            if (matchingCustomers.Any())
            {
                // Show matching customer details (Name, Phone, Address) in the ListBox
                listBoxCustomerSuggestions.Items.Clear();
                foreach (var customer in matchingCustomers)
                {
                    // Format the string to show Name, Phone, and Address
                    string customerInfo = $"{customer.Name} | {customer.Phone} | {customer.Address}";
                    listBoxCustomerSuggestions.Items.Add(customerInfo);
                }

                // Select the first match if there are any suggestions
                var selectedCustomer = matchingCustomers.First();
                textBoxCustomerPhone.Text = selectedCustomer.Phone;
                textBoxCustomerAddress.Text = selectedCustomer.Address;
            }
            else
            {
                // Clear the customer details if no match is found
                listBoxCustomerSuggestions.Items.Clear();
                textBoxCustomerPhone.Clear();
                textBoxCustomerAddress.Clear();
            }
        }

        // Event handler when a customer is selected from the ListBox
        private void listBoxCustomerSuggestions_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the selected customer information from the ListBox
            string selectedCustomerInfo = listBoxCustomerSuggestions.SelectedItem.ToString();

            // Split the customer info into Name, Phone, and Address
            string[] customerInfoParts = selectedCustomerInfo.Split('|');

            if (customerInfoParts.Length >= 3)
            {
                string selectedName = customerInfoParts[0].Trim();
                string selectedPhone = customerInfoParts[1].Trim();
                string selectedAddress = customerInfoParts[2].Trim();

                // Find the customer details by matching Name, Phone, and Address
                var selectedCustomer = customers.FirstOrDefault(c =>
                    c.Name == selectedName &&
                    c.Phone == selectedPhone &&
                    c.Address == selectedAddress);

                if (selectedCustomer != null)
                {
                    // Display selected customer details
                    textBoxCustomerPhone.Text = selectedCustomer.Phone;
                    textBoxCustomerAddress.Text = selectedCustomer.Address;
                    textBoxShippingAddress.Text = selectedCustomer.Address;
                    currentOrder = new Order(selectedCustomer); // Initialize with the selected customer
                }
            }
        }

        // Event handler to update price when an item is selected
        private void comboBoxItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the selected item from the comboBox
            string selectedItem = comboBoxItems.SelectedItem.ToString();

            // Find the index of the selected item in the items list
            int index = items.IndexOf(selectedItem);

            // If a valid index is found, update the TextBox with the corresponding price
            if (index >= 0 && index < prices.Count)
            {
                textBoxPrice.Text = prices[index].ToString();
                textBoxQuantity.Text = "1";  // Set default quantity to 1
                decimal quantity, totalPrice;
                if (decimal.TryParse(textBoxQuantity.Text, out quantity))
                {
                    totalPrice = quantity * prices[index];
                    textBoxPrice.Text = totalPrice.ToString();
                }
                else
                {
                    MessageBox.Show("Please enter valid numbers for Quantity and Price.");
                }
            }
        }

        // Event handler to update total price when quantity changes
        private void textBoxQuantity_TextChanged(object sender, EventArgs e)
        {
            // Get the selected item from the comboBox
            string selectedItem = comboBoxItems.SelectedItem.ToString();

            // Find the index of the selected item in the items list
            int index = items.IndexOf(selectedItem);

            // If a valid index is found, update the TextBox with the corresponding price
            if (index >= 0 && index < prices.Count)
            {
                decimal quantity, totalPrice;
                if (decimal.TryParse(textBoxQuantity.Text, out quantity))
                {
                    totalPrice = quantity * prices[index];
                    textBoxPrice.Text = totalPrice.ToString();
                }
            }
        }

        private void buttonAddItem_Click(object sender, EventArgs e)
        {
            // Get the selected item from the comboBox
            string selectedItem = comboBoxItems.SelectedItem.ToString();
            int quantity;
            if (!int.TryParse(textBoxQuantity.Text, out quantity) || quantity <= 0)
            {
                MessageBox.Show("Please enter a valid quantity.");
                return;
            }

            // Find the price of the selected item
            int itemIndex = items.IndexOf(selectedItem);
            decimal itemPrice = prices[itemIndex];

            // Create a new order item and add it to the current order
            OrderItem newItem = new OrderItem
            {
                ItemName = selectedItem,
                Price = itemPrice,
                Quantity = quantity
            };

            currentOrder.OrderItems.Add(newItem);

            // Update the order items display
            listBoxOrderItems.Items.Clear();
            foreach (var item in currentOrder.OrderItems)
            {
                listBoxOrderItems.Items.Add($"{item.ItemName} - {item.Quantity} x {item.Price:N0} = {item.TotalPrice:N0}");
            }
            UpdateOrderSummary();
        }
        private void textBoxShipFee_TextChanged(object sender, EventArgs e)
        {
            UpdateOrderSummary();
        }

        private void textBoxDiscount_TextChanged(object sender, EventArgs e)
        {
            UpdateOrderSummary();
        }

        private void UpdateOrderSummary()
        {
            decimal shippingFee = 0;
            decimal discount = 0;

            bool isValidShippingFee = decimal.TryParse(textBoxShipFee.Text, out shippingFee);
            bool isValidDiscount = decimal.TryParse(textBoxDiscount.Text, out discount);

            if (isValidShippingFee && isValidDiscount)
            {
                currentOrder.ShippingFee = shippingFee;
                currentOrder.Discount = (discount / 100) * currentOrder.TotalPrice;
            }
            else
            {
                // Handle invalid input for shipping fee or discount
                MessageBox.Show("Please enter valid values for shipping fee and discount.");
                return;  // Exit early if input is invalid
            }

            currentOrder.FinalPayment = currentOrder.TotalPrice + currentOrder.ShippingFee - currentOrder.Discount;

            richTextBoxToPay.Clear();
            richTextBoxToPay.AppendText($"Total: +{currentOrder.TotalPrice:N0}\n");
            richTextBoxToPay.AppendText($"Discount: -{currentOrder.Discount:N0}\n");
            richTextBoxToPay.AppendText($"Shipping: +{currentOrder.ShippingFee:N0}\n");
            richTextBoxToPay.AppendText($"-------------------\n");
            richTextBoxToPay.AppendText($"Final: {currentOrder.FinalPayment:N0}");
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            // Try to get the current quantity from the TextBox
            int currentQuantity = 0;

            // Check if the current value in textBoxQuantity is a valid number
            if (int.TryParse(textBoxQuantity.Text, out currentQuantity))
            {
                currentQuantity++;  // Increment the quantity by 1
                textBoxQuantity.Text = currentQuantity.ToString();  // Update the TextBox with the new value
            }
            else
            {
                // Handle invalid input if necessary
                MessageBox.Show("Please enter a valid quantity.");
            }
        }

        private void buttonMinus_Click(object sender, EventArgs e)
        {
            int currentQuantity = 0;

            if (int.TryParse(textBoxQuantity.Text, out currentQuantity))
            {
                if (currentQuantity > 0)  // Ensure quantity doesn't go below 0
                {
                    currentQuantity--;  // Decrement the quantity by 1
                    textBoxQuantity.Text = currentQuantity.ToString();  // Update the TextBox with the new value
                }
                else
                {
                    MessageBox.Show("Quantity cannot be less than 0.");
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid quantity.");
            }
        }

        private void buttonSaveOrder_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxCustomerName.Text))
            {
                MessageBox.Show("Please fill in customer name.");
                return;
            }
            if (currentOrder.OrderItems.Count == 0)
            {
                MessageBox.Show("Please add items to the order.");
                return;
            }
            completeCurrentOrder();
            saveToFile();
        }

        private void completeCurrentOrder()
        {
            currentOrder.Customer.Name = textBoxCustomerName.Text;
            currentOrder.Customer.Phone = textBoxCustomerPhone.Text;
            currentOrder.Customer.Address = textBoxCustomerAddress.Text;
            currentOrder.ShippingAddress = textBoxShippingAddress.Text;
            currentOrder.Note = richTextBoxNote.Text;
            currentOrder.ShippingTime = dateTimePickerShip.Value;
            currentOrder.OrderTime = DateTime.Now;
            currentOrder.Feedback = "Not Yet";
            currentOrder.PaymentStatus = "Unpaid";
            currentOrder.OrderStatus = "Processing";
        }

        private void saveToFile()
        {
            string filePath = "orders.xlsx";  // Make sure to adjust the path

            FileInfo fileInfo = new FileInfo(filePath);

            using (var package = new ExcelPackage(fileInfo))
            {
                ExcelWorksheet worksheet;

                // Check if the file exists, otherwise create a new worksheet with proper headers
                if (fileInfo.Exists)
                {
                    worksheet = package.Workbook.Worksheets[0];
                }
                else
                {
                    worksheet = package.Workbook.Worksheets.Add("Orders");

                    // Set headers for the columns
                    worksheet.Cells[1, 1].Value = "Name";
                    worksheet.Cells[1, 2].Value = "Phone";
                    worksheet.Cells[1, 3].Value = "Address";
                    worksheet.Cells[1, 4].Value = "Items"; // Replaced Item Name and Item Quantity with a single "Items" column
                    worksheet.Cells[1, 5].Value = "Shipping Address";
                    worksheet.Cells[1, 6].Value = "Shipping Time";
                    worksheet.Cells[1, 7].Value = "Payment";
                    worksheet.Cells[1, 8].Value = "Payment Status";
                    worksheet.Cells[1, 9].Value = "Order Status";
                    worksheet.Cells[1, 10].Value = "Feedback";
                    worksheet.Cells[1, 11].Value = "Order Note";
                    worksheet.Cells[1, 12].Value = "Discount";
                    worksheet.Cells[1, 13].Value = "Order Time"; // Added Order Time column
                }

                // Get the last row number to append the new order data
                int lastRow = worksheet.Dimension?.End.Row ?? 1;
                int row = lastRow + 1;

                // Fill individual cells with relevant information
                // Customer Info
                worksheet.Cells[row, 1].Value = currentOrder.Customer.Name;  // Customer Name
                worksheet.Cells[row, 2].Value = currentOrder.Customer.Phone; // Customer Phone
                worksheet.Cells[row, 3].Value = currentOrder.Customer.Address; // Customer Address

                // Items: Combine Item Name and Quantity in a single column
                StringBuilder itemsInfo = new StringBuilder();
                foreach (var item in currentOrder.OrderItems)
                {
                    itemsInfo.AppendLine($"{item.ItemName}: {item.Quantity}");
                }
                worksheet.Cells[row, 4].Value = itemsInfo.ToString();  // Items Column

                // Shipping Info
                worksheet.Cells[row, 5].Value = currentOrder.ShippingAddress;  // Shipping Address
                worksheet.Cells[row, 6].Value = currentOrder.OrderTime.ToString("yyyy-MM-dd HH:mm");  // Shipping Time (Order Time)

                // Payment Info
                worksheet.Cells[row, 7].Value = currentOrder.FinalPayment;  // Total Payment
                worksheet.Cells[row, 8].Value = currentOrder.PaymentStatus;  // Payment Status

                // Order Status
                worksheet.Cells[row, 9].Value = currentOrder.OrderStatus;  // Order Status

                // Feedback
                worksheet.Cells[row, 10].Value = currentOrder.Feedback ?? "Not Provided";  // Feedback (or placeholder)

                // Order Note
                worksheet.Cells[row, 11].Value = currentOrder.Note;  // Order Note

                // Discount
                worksheet.Cells[row, 12].Value = currentOrder.Discount.ToString();  // Discount Amount

                // Order Time
                worksheet.Cells[row, 13].Value = currentOrder.OrderTime.ToString("yyyy-MM-dd HH:mm");  // Order Time

                // Save the changes to the file
                package.Save();

                MessageBox.Show("Order saved successfully!");
            }
        }
        private void buttonRemoveOrder_Click(object sender, EventArgs e)
        {
            InitializeCurrentOrder();

            listBoxOrderItems.Items.Clear();  // Clear displayed items
            // Optionally, clear other fields as needed
            textBoxQuantity.Text = "1";
            textBoxPrice.Clear();
            richTextBoxToPay.Clear();

            MessageBox.Show("Order removed successfully!");
        }

        private void buttonSaveNewCustomer_Click(object sender, EventArgs e)
        {
            string filePath = "customers.xlsx";  // Ensure the path is correct
            FileInfo fileInfo = new FileInfo(filePath);

            using (var package = new ExcelPackage(fileInfo))
            {
                ExcelWorksheet worksheet;

                // Check if the file exists, otherwise create it
                if (fileInfo.Exists)
                {
                    worksheet = package.Workbook.Worksheets[0];
                }
                else
                {
                    worksheet = package.Workbook.Worksheets.Add("Customers");

                    // Set headers for the columns
                    worksheet.Cells[1, 1].Value = "Name";
                    worksheet.Cells[1, 2].Value = "Phone";
                    worksheet.Cells[1, 3].Value = "Address";
                }

                // Get the last row and append new customer data
                int lastRow = worksheet.Dimension?.End.Row ?? 1;
                int row = lastRow + 1;

                worksheet.Cells[row, 1].Value = textBoxCustomerName.Text;
                worksheet.Cells[row, 2].Value = textBoxCustomerPhone.Text;
                worksheet.Cells[row, 3].Value = textBoxCustomerAddress.Text;

                package.Save();
                MessageBox.Show("Saved a new customer to customers.xlsx file.");

            }
        }

        private void buttonLoadOrders_Click(object sender, EventArgs e)
        {

        }
    }
}
