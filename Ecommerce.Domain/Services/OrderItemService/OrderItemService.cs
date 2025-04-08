using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Data.Model;
using Ecommerce.Data.Repository.UnitOfWork;
using Ecommerce.Domain.Dtos;

namespace Ecommerce.Domain.Services.OrderItemService
{
    public class OrderItemService:IOrderItemService
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderItemService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<OrderItemDto>> GetAllOrderItemsAsync()
        {
            var orderItems = await _unitOfWork.OrderItem.GetAllAsync();
            return orderItems.Select(o => new OrderItemDto
            {
                Quantity = o.Quantity,
                Price = o.Price
            });
        }

        public async Task<OrderItemDto?> GetOrderItemByIdAsync(int id)
        {
            var orderItem = await _unitOfWork.OrderItem.GetByIdAsync(id);
            if (orderItem == null) return null;

            return new OrderItemDto
            {
                Quantity = orderItem.Quantity,
                Price = orderItem.Price
            };
        }

        public async Task AddOrderItemAsync(OrderItemDto orderItemDto)
        {
            var orderItem = new OrderItem
            {
                Quantity = orderItemDto.Quantity,
                Price = orderItemDto.Price
            };

            await _unitOfWork.OrderItem.AddAsync(orderItem);
            _unitOfWork.Save();
        }

        public async Task UpdateOrderItemAsync(int id, OrderItemDto orderItemDto)
        {
            var orderItem = await _unitOfWork.OrderItem.GetByIdAsync(id);
            if (orderItem == null) return;

            orderItem.Quantity = orderItemDto.Quantity;
            orderItem.Price = orderItemDto.Price;
            _unitOfWork.OrderItem.Update(orderItem);
            _unitOfWork.Save();
        }

        public async Task DeleteOrderItemAsync(int id)
        {
            var orderItem = await _unitOfWork.OrderItem.GetByIdAsync(id);
            if (orderItem == null) return;

            _unitOfWork.OrderItem.Delete(orderItem);
            _unitOfWork.Save();
        }
    }
}
