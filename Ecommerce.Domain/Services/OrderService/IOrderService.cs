using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Domain.Dtos;

namespace Ecommerce.Domain.Services.OrderService
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderDto>> GetAllOrdersAsync();
        Task<OrderDto?> GetOrderByIdAsync(int id);
        Task AddOrderAsync(OrderDto order);
        Task UpdateOrderStatusAsync(int id, string status);
        Task DeleteOrderAsync(int id);
    }
}
