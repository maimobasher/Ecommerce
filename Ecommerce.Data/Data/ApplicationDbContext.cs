using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace Ecommerce.Data.Data
{
    internal class ApplicationDbContext:DbContext
    {
        //public  DbSet<Brand> Brands { get; set; }
        //public DbSet<Category>Categories { get; set; }  
        //public DbSet<CreditCard>CreditCards { get; set; }   
        //public DbSet<OrderDetail>OrderDetails { get; set; }
        //public DbSet<OrderHeader> OrderHeaders { get; set; }    
        //public DbSet<Product>Products { get; set; } 
        //public DbSet<Review> Reviews { get; set; }  
        //public DbSet<ShoppingCart>ShoppingCarts { get; set; }   
        //public DbSet<User> Users { get; set; }  
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=Ecommerce;Integrated Security=True");
        }
    }
}
