using System;
using System.Collections.Generic;

namespace Ecommerce.Data.Model
{
    public class Order
    {
        public int OrderID { get; set; }
        public int UserID { get; set; }
        public decimal TotalAmount { get; set; }
        public string? Status { get; set; } // "Pending", "Processing", "Shipped", "Delivered", "Cancelled"
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public int PaymentID { get; set; }
        public Payment? Payment { get; set; }
        public User? User { get; set; }

        // Navigation
        public ICollection<OrderItem> OrderItems { get; set; } = new HashSet<OrderItem>();
    }
}

