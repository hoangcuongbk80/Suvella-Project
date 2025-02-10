using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suvella
{
    public class Order
    {
        public Customer Customer { get; set; }
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        public decimal TotalPrice => OrderItems.Sum(item => item.TotalPrice);
        public string ShippingAddress { get; set; }
        public string ShippingMethod { get; set; }
        public string OrderID { get; set; }
        public decimal Discount { get; set; }  // Shipping Fee
        public decimal ShippingFee { get; set; }  // Shipping Fee
        public decimal FinalPayment { get; set; }  // Final price
        public DateTime ShippingTime { get; set; }  // Shipping Date/Time
        public DateTime OrderTime { get; set; }  // Order Date/Time

        public string Note { get; set; }  // Notes about the order
        public string Feedback { get; set; }
        public string PaymentStatus { get; set; }  // Payment status (e.g., "Paid", "Unpaid")
        public string OrderStatus { get; set; }  // Order status (e.g., "Processing", "Shipped", "Delivered")

        public Order(Customer customer)
        {
            Customer = customer;
        }

        // Method to calculate total price including shipping fee
        public decimal TotalPriceWithShipping => TotalPrice + ShippingFee;
    }

    public class OrderItem
    {
        public string ItemName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice => Price * Quantity;
    }
}
