using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;


namespace Ecommerce.Data.Model
{
    public class User: IdentityUser<int>
    {
       public int UserID { get; set; }
        public string?  FullName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? UserType { get; set; } // "Admin", "Customer"
        public DateTime? CreatedAt { get; set; } = DateTime.Now;

        // Navigation
        public ICollection<Order> Orders { get; set; } = new HashSet<Order>();
    }
}

