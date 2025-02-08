using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Suvella
{
    public partial class Form1 : Form
    {
        // Declare lists to hold items and prices
        List<string> items = new List<string>();
        List<decimal> prices = new List<decimal>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string filePath = "menu.xlsx";

            try
            {
                using (var package = new ExcelPackage(new FileInfo(filePath)))
                {
                    var worksheet = package.Workbook.Worksheets[0];

                    comboBoxItems.Items.Clear();
                    items.Clear();
                    prices.Clear();

                    // Loop through the rows and add items and prices to the lists
                    for (int row = 2; row <= worksheet.Dimension.End.Row; row++) // Start from row 2 to skip the header
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
                MessageBox.Show("Error loading data: " + ex.Message);
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
                textBoxQuantity.Text = "1";
            }
        }
    }
}
