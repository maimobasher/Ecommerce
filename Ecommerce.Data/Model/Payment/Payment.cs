using System;

namespace Ecommerce.Data.Model
{
    public class Payment
    {
        public int PaymentID { get; set; }
        public decimal Amount { get; set; }
        public string?  PaymentMethod { get; set; } // "Credit Card", "PayPal", etc.
        public string?  PaymentStatus { get; set; } // "Pending", "Completed", "Failed", "Refunded"
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public int OrderID { get; set; }
        public Order? Order { get; set; }
    }
}

