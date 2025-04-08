using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Dtos
{
    public class OrderDto
    {
        public decimal TotalAmount { get; set; }
        public string? Status { get; set; } // "Pending", "Processing", "Shipped", "Delivered", "Cancelled"
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int Id { get; set; }
    }
}
