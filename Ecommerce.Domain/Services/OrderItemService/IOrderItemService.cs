using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Domain.Dtos;

namespace Ecommerce.Domain.Services.OrderItemService
{
    public interface IOrderItemService
    {
        Task<IEnumerable<OrderItemDto>> GetAllOrderItemsAsync();
        Task<OrderItemDto?> GetOrderItemByIdAsync(int id);
        Task AddOrderItemAsync(OrderItemDto orderItem);
        Task UpdateOrderItemAsync(int id, OrderItemDto orderItem);
        Task DeleteOrderItemAsync(int id);
    }
}
