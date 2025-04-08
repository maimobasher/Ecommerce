using Ecommerce.Data.Model;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Data.Data
{
    public class ApplicationDbContext : IdentityDbContext<User, IdentityRole<int>, int>

    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        //public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Review> Reviews { get; set; }

        //public DbSet<Model.User.ResetPassword> ResetPasswords { get; set; }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    string connectionString = "Data Source=.;Initial Catalog=Ecommerce;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
        //    optionsBuilder.UseSqlServer(connectionString);
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
       .HasOne(o => o.Payment)
       .WithOne(p => p.Order)
       .HasForeignKey<Payment>(p => p.OrderID)  // Explicitly set Payment as dependent
       .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}

