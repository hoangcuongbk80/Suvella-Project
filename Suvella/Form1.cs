using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Suvella
{
    public partial class Form1 : Form
    {
        // List to hold items and prices
        List<string> items = new List<string>();
        List<decimal> prices = new List<decimal>();

        // List to hold customer data
        List<Customer> customers = new List<Customer>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // File paths for the menu and customer Excel sheets
            string menuFilePath = "menu.xlsx";
            string customerFilePath = "customers.xlsx";

            try
            {
                // Load menu data
                LoadMenuData(menuFilePath);

                // Load customer data
                LoadCustomerData(customerFilePath);

                // Set up AutoComplete for customer name in the TextBox
                SetUpCustomerAutoComplete();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
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
    }
}
