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
using Microsoft.EntityFrameworkCore; // Removed 'static'

namespace Ecommerce.Data.Repository.CategoryRepo
{
    public class CategoryRepo : Repo<Category, Guid>, ICategoryRepo
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepo(ApplicationDbContext context) : base(context)
        {
            _context = context; // هذا هو المهم
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category?> GetByIdAsync(int id)
        {
            return await _context.Categories.FindAsync(id);
        }

        public async Task AddAsync(Category category)
        {
            await _context.Categories.AddAsync(category);
        }

        public void Update(Category category)
        {
            _context.Categories.Update(category);
        }

        public void Delete(Category category)
        {
            _context.Categories.Remove(category);
        }

        public Category Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Category> GetAsync(int id)
        {
            throw new NotImplementedException();
        }
    }


}