using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Data.Model;

namespace Ecommerce.Data.Repository.ReviewRepo
{
    public interface IReviewRepo:IRepo.IRepo<Review,Guid>
    {

        Task<IEnumerable<Review>> GetAllAsync();
        Task<Review?> GetByIdAsync(int id);
        Task AddAsync(Review review);
        void Update(Review review);
        void Delete(Review review);
    }
}
