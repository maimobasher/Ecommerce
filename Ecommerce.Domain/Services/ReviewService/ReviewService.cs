using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Data.Model;
using Ecommerce.Data.Repository.UnitOfWork;
using Ecommerce.Domain.Dtos;

namespace Ecommerce.Domain.Services.ReviewService
{
    public class ReviewService:IReviewService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ReviewService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ReviewDto>> GetAllReviewsAsync()
        {
            var reviews = await _unitOfWork.Review.GetAllAsync();
            return reviews.Select(r => new ReviewDto
            {
                Content = r.Content,
                Rating = r.Rating,
                CreatedAt = r.CreatedAt
            });
        }

        public async Task<ReviewDto?> GetReviewByIdAsync(int id)
        {
            var review = await _unitOfWork.Review.GetByIdAsync(id);
            if (review == null) return null;

            return new ReviewDto
            {
                Content = review.Content,
                Rating = review.Rating,
                CreatedAt = review.CreatedAt
            };
        }

        public async Task AddReviewAsync(ReviewDto reviewDto)
        {
            var review = new Review
            {
                Content = reviewDto.Content,
                Rating = reviewDto.Rating,
                CreatedAt = reviewDto.CreatedAt
            };

            await _unitOfWork.Review.AddAsync(review);
            _unitOfWork.Save();
        }

        public async Task UpdateReviewAsync(int id, ReviewDto reviewDto)
        {
            var review = await _unitOfWork.Review.GetByIdAsync(id);
            if (review == null) return;

            review.Content = reviewDto.Content;
            review.Rating = reviewDto.Rating;
            _unitOfWork.Review.Update(review);
            _unitOfWork.Save();
        }

        public async Task DeleteReviewAsync(int id)
        {
            var review = await _unitOfWork.Review.GetByIdAsync(id);
            if (review == null) return;

            _unitOfWork.Review.Delete(review);
            _unitOfWork.Save();
        }
    }
}
