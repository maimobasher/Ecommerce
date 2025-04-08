using System;
using System.Collections.Generic;

namespace Ecommerce.Data.Model
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string? CategoryName { get; set; }

        // Navigation
        public ICollection<Product> Products { get; set; } = new HashSet<Product>();
    }
}


