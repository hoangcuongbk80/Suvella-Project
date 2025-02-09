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

        public Order(Customer customer)
        {
            Customer = customer;
        }
    }

    public class OrderItem
    {
        public string ItemName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice => Price * Quantity;
    }

}
