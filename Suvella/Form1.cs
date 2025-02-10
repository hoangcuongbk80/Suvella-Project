using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
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

        private List<Order> orders = new List<Order>();
        private List<Order> filteredOrders = new List<Order>();
        private DataTable dataTable;

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

        //-----------------------Place Orders-----------------------
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

        //----------------------------Manage Orders---------------------------
        private void buttonLoadOrders_Click(object sender, EventArgs e)
        {
            loadOrders();
            bindDataGridView();

            // Display the number of orders
            //MessageBox.Show($"Total Orders: {orders.Count}", "Order Count", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void loadOrders()
        {
            orders.Clear();
            string filePath = "orders.xlsx";  // Make sure this path is correct

            try
            {
                using (var package = new ExcelPackage(new FileInfo(filePath)))
                {
                    var worksheet = package.Workbook.Worksheets[0];  // Assuming data is in the first sheet

                    // Loop through the rows and read the data
                    for (int row = 2; row <= worksheet.Dimension.End.Row; row++) // Start from row 2 to skip the header
                    {
                        // Create a new Customer object using the data from the row
                        var customer = new Customer
                        {
                            Name = worksheet.Cells[row, 1].Text.Trim(),  // Customer Name in column 1
                            Phone = worksheet.Cells[row, 2].Text.Trim(),  // Customer Phone in column 2
                            Address = worksheet.Cells[row, 3].Text.Trim(), // Customer Address in column 3
                        };

                        // Initialize the order object and populate its properties
                        var order = new Order(customer)
                        {
                            ShippingAddress = worksheet.Cells[row, 5].Text.Trim(),  // Shipping Address in column 5
                            ShippingTime = DateTime.TryParse(worksheet.Cells[row, 6].Text, out var shippingTime) ? shippingTime : DateTime.MinValue,  // Order Time in column 13

                            OrderTime = DateTime.TryParse(worksheet.Cells[row, 13].Text, out var orderTime) ? orderTime : DateTime.MinValue,  // Order Time in column 13
                            Discount = decimal.TryParse(worksheet.Cells[row, 12].Text, out var discount) ? discount : 0,  // Discount in column 12
                            FinalPayment = decimal.TryParse(worksheet.Cells[row, 7].Text, out var finalPayment) ? finalPayment : 0, // Final Payment in column 7
                            PaymentStatus = worksheet.Cells[row, 8].Text.Trim(),  // Payment Status in column 8
                            OrderStatus = worksheet.Cells[row, 9].Text.Trim(),  // Order Status in column 9
                            Feedback = worksheet.Cells[row, 10].Text.Trim(),  // Feedback in column 10
                            Note = worksheet.Cells[row, 11].Text.Trim(),  // Order Note in column 11
                            OrderID = row.ToString(),
                        };

                        // Parse the "Items" column (column 4) into individual order items
                        var itemsInfo = worksheet.Cells[row, 4].Text.Trim(); // Items in column 4
                        var orderItems = new List<OrderItem>();
                        if (!string.IsNullOrEmpty(itemsInfo))
                        {
                            var itemLines = itemsInfo.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                            foreach (var itemLine in itemLines)
                            {
                                var parts = itemLine.Split(':');
                                if (parts.Length == 2)
                                {
                                    var itemName = parts[0].Trim();
                                    if (int.TryParse(parts[1].Trim(), out var itemQuantity))
                                    {
                                        orderItems.Add(new OrderItem
                                        {
                                            ItemName = itemName,
                                            Quantity = itemQuantity,
                                            Price = 0  // Assuming the price is not saved in the Excel file, you might need to calculate it elsewhere
                                        });
                                    }
                                }
                            }
                        }

                        // Assign the loaded order items to the order
                        order.OrderItems = orderItems;

                        // Add the order to the list
                        orders.Add(order);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading orders: " + ex.Message);
            }
            filteredOrders = orders;
        }
        private void bindDataGridView(List<Order> ordersToBind = null)
        {
            // Create a new DataTable if it's not already created or if it's a new set of data
            if (dataTable == null)
            {
                dataTable = new DataTable();

                // Add columns to DataTable
                dataTable.Columns.Add("Customer Name");
                dataTable.Columns.Add("Phone");
                dataTable.Columns.Add("Final Payment");
                dataTable.Columns.Add("Payment Status");
                dataTable.Columns.Add("Order Status");
            }

            // Clear any existing data in the DataTable
            dataTable.Rows.Clear();

            // Use the provided orders list or all orders
            var ordersToDisplay = ordersToBind ?? orders;

            // Loop through the orders list and populate the DataTable
            foreach (var order in ordersToDisplay)
            {
                var row = dataTable.NewRow();
                row["Customer Name"] = order.Customer.Name;
                row["Phone"] = order.Customer.Phone;
                row["Final Payment"] = order.FinalPayment;
                row["Payment Status"] = order.PaymentStatus;
                row["Order Status"] = order.OrderStatus;

                dataTable.Rows.Add(row);
            }

            // Bind the DataTable to the DataGridView
            dataGridViewOrder.DataSource = dataTable;
        }

        private void buttonSearchOrder_Click(object sender, EventArgs e)
        {
            string searchTerm = textBoxSearchOrder.Text.Trim().ToLower();

            // Filter the orders based on the search term (you can extend this to multiple fields)
            filteredOrders = orders.Where(order =>
                order.Customer.Name.ToLower().Contains(searchTerm) ||        // Search by customer name
                order.OrderStatus.ToLower().Contains(searchTerm) ||          // Search by order status
                order.PaymentStatus.ToLower().Contains(searchTerm)           // Search by payment status
            ).ToList();

            // Use bindDataGridView to bind the filtered orders to the DataGridView
            bindDataGridView(filteredOrders);

            // Display a message if no results found
            if (filteredOrders.Count == 0)
            {
                MessageBox.Show("No orders found matching the search criteria.", "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dataGridViewOrder_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewOrder.SelectedRows.Count > 0)
            {
                // Get the selected row index
                int selectedRowIndex = dataGridViewOrder.SelectedRows[0].Index;

                // Get the corresponding order from the filteredOrders list
                var selectedOrder = filteredOrders[selectedRowIndex];

                // Prepare the information to be displayed in the RichTextBox
                StringBuilder orderInfo = new StringBuilder();

                orderInfo.AppendLine("Name: " + selectedOrder.Customer.Name);
                orderInfo.AppendLine("Phone: " + selectedOrder.Customer.Phone);
                orderInfo.AppendLine("Address: " + selectedOrder.Customer.Address);
                orderInfo.AppendLine("----------------------------------");
                orderInfo.AppendLine("Final Payment: " + selectedOrder.FinalPayment);
                orderInfo.AppendLine("Payment Status: " + selectedOrder.PaymentStatus);
                orderInfo.AppendLine("Order Status: " + selectedOrder.OrderStatus);
                orderInfo.AppendLine("----------------------------------");
                orderInfo.AppendLine("Shipping Address: " + selectedOrder.ShippingAddress);
                orderInfo.AppendLine("Shipping Time: " + selectedOrder.ShippingTime.ToString("yyyy-MM-dd HH:mm"));
                orderInfo.AppendLine("----------------------------------");
                orderInfo.AppendLine("Order Time: " + selectedOrder.OrderTime.ToString("yyyy-MM-dd HH:mm"));
                orderInfo.AppendLine("Discount: " + selectedOrder.Discount);
                orderInfo.AppendLine("Order Note: " + selectedOrder.Note);
                orderInfo.AppendLine("Feedback: " + selectedOrder.Feedback);

                // Items (iterate through the order items)
                orderInfo.AppendLine("\nOrder Items:");
                foreach (var item in selectedOrder.OrderItems)
                {
                    orderInfo.AppendLine($"{item.ItemName}: {item.Quantity} x {item.Price} = {item.TotalPrice}");
                }

                // Display the order details in the RichTextBox
                richTextBoxOrderDetails.Text = orderInfo.ToString();

                // Set the ComboBox to the current status of the selected order
                comboBoxOrderStatus.SelectedItem = selectedOrder.OrderStatus;
                comboBoxPaymentStatus.SelectedItem = selectedOrder.PaymentStatus;
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridViewOrder.SelectedRows.Count > 0)
            {
                // Get the selected row index
                int selectedRowIndex = dataGridViewOrder.SelectedRows[0].Index;

                // Ensure the selected index is within bounds of the filteredOrders list
                if (selectedRowIndex >= 0 && selectedRowIndex < filteredOrders.Count)
                {
                    // Get the corresponding order from the filteredOrders list
                    var selectedOrder = filteredOrders[selectedRowIndex];

                    // Get the new status from the ComboBox
                    string newOrderStatus = comboBoxOrderStatus.SelectedItem.ToString();
                    string newPaymentStatus = comboBoxPaymentStatus.SelectedItem.ToString();


                    // Update the order status in the filteredOrders list
                    selectedOrder.OrderStatus = newOrderStatus;
                    selectedOrder.PaymentStatus = newPaymentStatus;

                    // If the order is in the orders list, we need to reflect the change there as well
                    var orderInAllOrders = orders.FirstOrDefault(order => order.OrderID == selectedOrder.OrderID);
                    if (orderInAllOrders != null)
                    {
                        orderInAllOrders.OrderStatus = newOrderStatus;
                        orderInAllOrders.PaymentStatus = newPaymentStatus;
                    }

                    // Save the orders to Excel after update
                    SaveOrdersToExcel();

                    // Refresh the DataGridView to reflect the updated status
                    bindDataGridView(filteredOrders);

                    // Optionally, you could reset the ComboBox if needed
                    comboBoxOrderStatus.SelectedIndex = -1;
                }
                else
                {
                    // Handle the case where no order is selected or index is out of range
                    MessageBox.Show("Please select a valid order to update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Handle case when no order is selected
                MessageBox.Show("Please select an order first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void SaveOrdersToExcel()
        {
            string filePath = "orders.xlsx";  // Make sure this path is correct

            try
            {
                using (var package = new ExcelPackage(new FileInfo(filePath)))
                {
                    var worksheet = package.Workbook.Worksheets[0];  // Assuming data is in the first sheet

                    // Loop through the orders and update the Excel file
                    for (int row = 2; row <= worksheet.Dimension.End.Row; row++) // Assuming data starts from row 2
                    {
                        var order = orders[row - 2]; // Map rows to orders list

                        // Update the order status and payment status in the Excel sheet
                        worksheet.Cells[row, 9].Value = order.OrderStatus; // Order Status is in column 9
                        worksheet.Cells[row, 8].Value = order.PaymentStatus; // Payment Status is in column 8
                    }

                    // Save the changes
                    package.Save();
                    MessageBox.Show("Orders updated successfully in Excel.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving orders: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //----------------------------Manage Orders---------------------------
        private void buttonStatisticItem_Click(object sender, EventArgs e)
        {
            loadOrders();
            doStatistic();
        }

        private void doStatistic()
        {
            // Dictionary to hold item statistics: {ItemName => (processingCount, shippedCount)}
            var itemStatistics = new Dictionary<string, (int processingCount, int shippedCount)>();

            // Loop through all orders to extract item information and statuses
            foreach (var order in orders)
            {
                // Check if the order status is 'Processing' or 'Shipped' to categorize items
                string orderStatus = order.OrderStatus.ToLower();  // Example: 'Processing' or 'Shipped'

                // If order is in processing or shipped, loop through the items
                foreach (var item in order.OrderItems)
                {
                    // Determine which status to count the item under
                    if (orderStatus == "processing")
                    {
                        // Add item to the 'processing' count
                        if (itemStatistics.ContainsKey(item.ItemName))
                        {
                            var stats = itemStatistics[item.ItemName];
                            itemStatistics[item.ItemName] = (stats.processingCount + item.Quantity, stats.shippedCount);
                        }
                        else
                        {
                            itemStatistics[item.ItemName] = (item.Quantity, 0);
                        }
                    }
                    else if (orderStatus == "shipped")
                    {
                        // Add item to the 'shipped' count
                        if (itemStatistics.ContainsKey(item.ItemName))
                        {
                            var stats = itemStatistics[item.ItemName];
                            itemStatistics[item.ItemName] = (stats.processingCount, stats.shippedCount + item.Quantity);
                        }
                        else
                        {
                            itemStatistics[item.ItemName] = (0, item.Quantity);
                        }
                    }
                }
            }

            // Read inventory data from target_production.xlsx if it exists
            Dictionary<string, int> targetProductionData = new Dictionary<string, int>();
            string targetProductionFilePath = "target_production.xlsx";

            if (File.Exists(targetProductionFilePath))
            {
                try
                {
                    using (var package = new ExcelPackage(new FileInfo(targetProductionFilePath)))
                    {
                        var worksheet = package.Workbook.Worksheets[0]; // Assuming the data is in the first sheet

                        // Loop through the rows and get the inventory data
                        for (int row = 2; row <= worksheet.Dimension.End.Row; row++) // Start from row 2 to skip the header
                        {
                            string itemName = worksheet.Cells[row, 1].Text.Trim();
                            int targetProduction = 0;
                            int.TryParse(worksheet.Cells[row, 2].Text.Trim(), out targetProduction); // Assuming inventory quantity is in column 4

                            // Add the item and its inventory to the dictionary
                            targetProductionData[itemName] = targetProduction;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error reading inventory data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            // Prepare a DataTable to bind the data to the DataGridView
            DataTable itemDataTable = new DataTable();
            itemDataTable.Columns.Add("Item Name");
            itemDataTable.Columns.Add("Production Target");
            itemDataTable.Columns.Add("Processing Quantity");
            itemDataTable.Columns.Add("Shipped Quantity");
            itemDataTable.Columns.Add("Inventory Quantity");

            // Fill the DataTable with item statistics and calculate the production target
            foreach (var itemStat in itemStatistics)
            {
                var row = itemDataTable.NewRow();
                string itemName = itemStat.Key;

                // Get inventory quantity (default to 0 if not found in the inventory data)
                int targetProductionQuantity = targetProductionData.ContainsKey(itemName) ? targetProductionData[itemName] : 0;

                // Calculate production target
                int processingQuantity = itemStat.Value.processingCount;
                int shippedQuantity = itemStat.Value.shippedCount;
                int inventoryQuantity = targetProductionQuantity - processingQuantity - shippedQuantity;

                // Populate the row with values
                row["Item Name"] = itemName;
                row["Production Target"] = targetProductionQuantity;
                row["Processing Quantity"] = processingQuantity;
                row["Shipped Quantity"] = itemStat.Value.shippedCount;
                row["Inventory Quantity"] = inventoryQuantity;

                // Add the row to the DataTable
                itemDataTable.Rows.Add(row);
            }

            // Bind the DataTable to the DataGridView
            dataGridViewItem.DataSource = itemDataTable;
        }

        private void dataGridViewItem_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the changed cell is the "Production Target" column
            if (e.ColumnIndex == dataGridViewItem.Columns["Production Target"].Index)
            {
                // Get the corresponding item name
                string itemName = dataGridViewItem.Rows[e.RowIndex].Cells["Item Name"].Value.ToString();

                // Get the inventory quantity input by the user
                int productionTarget = Convert.ToInt32(dataGridViewItem.Rows[e.RowIndex].Cells["Production Target"].Value);

                // Get the processing quantity for the item
                int processingQuantity = Convert.ToInt32(dataGridViewItem.Rows[e.RowIndex].Cells["Processing Quantity"].Value);
                int shippedQuantity = Convert.ToInt32(dataGridViewItem.Rows[e.RowIndex].Cells["Shipped Quantity"].Value);

                // Calculate the Production Target
                int inventoryQuantity = productionTarget - processingQuantity - shippedQuantity;

                // Update the "Production Target" column in the DataGridView
                dataGridViewItem.Rows[e.RowIndex].Cells["Inventory Quantity"].Value = inventoryQuantity;
                saveToProductionTargetFile();
            }
        }

        private void saveToProductionTargetFile()
        {
            try
            {
                // Create a new Excel package to write data
                using (var package = new ExcelPackage())
                {
                    // Add a worksheet to the Excel package
                    var worksheet = package.Workbook.Worksheets.Add("Production Targets");

                    // Set the column headers in the first row
                    worksheet.Cells[1, 1].Value = "Item Name";
                    worksheet.Cells[1, 2].Value = "Production Target";
                    worksheet.Cells[1, 3].Value = "Processing Quantity";
                    worksheet.Cells[1, 4].Value = "Shipped Quantity";
                    worksheet.Cells[1, 5].Value = "Inventory Quantity";

                    // Loop through each row in the DataGridView and add data to Excel
                    for (int rowIndex = 0; rowIndex < dataGridViewItem.Rows.Count; rowIndex++)
                    {
                        // Skip the last row (if it's empty)
                        if (dataGridViewItem.Rows[rowIndex].IsNewRow) continue;

                        // Get the values from the DataGridView cells for each row
                        string itemName = dataGridViewItem.Rows[rowIndex].Cells["Item Name"].Value?.ToString() ?? string.Empty;
                        int shippedQuantity = Convert.ToInt32(dataGridViewItem.Rows[rowIndex].Cells["Shipped Quantity"].Value);
                        int processingQuantity = Convert.ToInt32(dataGridViewItem.Rows[rowIndex].Cells["Processing Quantity"].Value);
                        int inventoryQuantity = Convert.ToInt32(dataGridViewItem.Rows[rowIndex].Cells["Inventory Quantity"].Value);
                        int productionTarget = Convert.ToInt32(dataGridViewItem.Rows[rowIndex].Cells["Production Target"].Value);

                        // Write the values into the Excel worksheet, starting from the second row
                        worksheet.Cells[rowIndex + 2, 1].Value = itemName;
                        worksheet.Cells[rowIndex + 2, 2].Value = productionTarget; 
                        worksheet.Cells[rowIndex + 2, 3].Value = processingQuantity;
                        worksheet.Cells[rowIndex + 2, 4].Value = shippedQuantity; 
                        worksheet.Cells[rowIndex + 2, 5].Value = inventoryQuantity;
                    }

                    // Save the Excel file to disk
                    string filePath = "target_production.xlsx"; // You can customize the file path
                    FileInfo file = new FileInfo(filePath);
                    package.SaveAs(file);

                    // Inform the user that the file has been saved
                    //MessageBox.Show("Data has been saved to target_production.xlsx", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving data to Excel: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
