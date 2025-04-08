using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Dtos
{
    public class PaymentDto
    {
        public decimal Amount { get; set; }
        public string? PaymentMethod { get; set; } // "Credit Card", "PayPal", etc.
        public string? PaymentStatus { get; set; } // "Pending", "Completed", "Failed", "Refunded"
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public object Id { get; set; }
    }
}
