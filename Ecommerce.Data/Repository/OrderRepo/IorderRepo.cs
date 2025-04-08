using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Data.Model;
using Ecommerce.Data.Repository.IRepo;

namespace Ecommerce.Data
{
    public interface IOrderRepo : IRepo<Order>
    {
        Task<IEnumerable<Order>> GetAllAsync();
        Task<Order?> GetByIdAsync(int id);
        Task AddAsync(Order order);
        void Update(Order order);
        void Delete(Order order);
    }

    public interface IRepo<T>
    {
    }
}
