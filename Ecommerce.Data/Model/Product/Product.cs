using System;
using System.Collections.Generic;

namespace Ecommerce.Data.Model
{
    public class Product 
    {
        //public Product()
        //{
        //    OrderItems = new List<OrderItem>(); 
        //    Reviews = new List<Review>();
        //}
         public int ProductID { get; set; }
       // public Guid Id { get; set; } = new Guid();
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string? ImageURL { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public int CategoryID { get; set; }
        public Category? Category { get; set; }

        // Navigation
        public ICollection<OrderItem> OrderItems { get; set; } = new HashSet<OrderItem>();
        public ICollection<Review> Reviews { get; set; } = new HashSet<Review>();
    }
}

