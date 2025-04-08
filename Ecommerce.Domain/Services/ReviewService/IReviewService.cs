using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Domain.Dtos;

namespace Ecommerce.Domain.Services.ReviewService
{
    public interface IReviewService
    {
        Task<IEnumerable<ReviewDto>> GetAllReviewsAsync();
        Task<ReviewDto?> GetReviewByIdAsync(int id);
        Task AddReviewAsync(ReviewDto review);
        Task UpdateReviewAsync(int id, ReviewDto review);
        Task DeleteReviewAsync(int id);
    }
}

