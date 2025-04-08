using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Data.Data;
using Ecommerce.Data.Model;
using Ecommerce.Data.Repository.IRepo;
using Ecommerce.Data.Repository.ProductRepo;
using Microsoft.EntityFrameworkCore;


namespace Ecommerce.Data.Repository.ProductRepo
{
    public class ProductRepo : Repo<Product, Guid>, IProductRepo
    {
        private readonly ApplicationDbContext _context;

        public ProductRepo(ApplicationDbContext context) : base(context)
        {
            _context = context; // ✅ الحل هنا
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task AddAsync(Product product)
        {
            await _context.Products.AddAsync(product);
        }

        public void Update(Product product)
        {
            _context.Products.Update(product);
        }

        public void Delete(Product product)
        {
            _context.Products.Remove(product);
        }
    }

}
