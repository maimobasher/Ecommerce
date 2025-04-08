using System.Linq.Expressions;
using Ecommerce.Data.Data;
using Ecommerce.Data.Model;
using Ecommerce.Data.Repository.IRepo;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Data.Repository.ReviewRepo
{
    public class ReviewRepo : Repo<Review, Guid>, IReviewRepo
    {
        public ReviewRepo(ApplicationDbContext context) : base(context)
        {
             _context = context;

        }

        private readonly ApplicationDbContext _context;

        //public ReviewRepo(ApplicationDbContext context)
        //{
        //    _context = context;
        //}

        public async Task<IEnumerable<Review>> GetAllAsync()
        {
            return await _context.Reviews.ToListAsync();
        }

        public async Task<Review?> GetByIdAsync(int id)
        {
            return await _context.Reviews.FindAsync(id);
        }

        public async Task AddAsync(Review review)
        {
            await _context.Reviews.AddAsync(review);
        }

        public void Update(Review review)
        {
            _context.Reviews.Update(review);
        }

        public void Delete(Review review)
        {
            _context.Reviews.Remove(review);
        }
    }
}