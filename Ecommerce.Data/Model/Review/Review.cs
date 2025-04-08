using System;

namespace Ecommerce.Data.Model
{
    public class Review
    {
        public int ReviewID { get; set; }
        public int ProductID { get; set; }
        public Product? Product { get; set; }
        public int? UserID { get; set; }
        public User? User { get; set; }
        public string? Content { get; set; }
        public int? Rating { get; set; } // 1 to 5
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}

