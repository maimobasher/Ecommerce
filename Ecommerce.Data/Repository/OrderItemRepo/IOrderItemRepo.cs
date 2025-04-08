using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Data.Model;
using Ecommerce.Data.Repository.IRepo;

namespace Ecommerce.Data.Repository.OrderItemRepo
{
    public interface IOrderItemRepo:IRepo<OrderItem>
    {
        Task<IEnumerable<OrderItem>> GetAllAsync();
        Task<OrderItem?> GetByIdAsync(int id);
        Task AddAsync(OrderItem orderItem);
        void Update(OrderItem orderItem);
        void Delete(OrderItem orderItem);
    }
}
