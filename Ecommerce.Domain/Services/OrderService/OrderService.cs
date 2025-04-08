using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Data.Model;
using Ecommerce.Data.Repository.UnitOfWork;
using Ecommerce.Domain.Dtos;

namespace Ecommerce.Domain.Services.OrderService
{
    public class OrderService:IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<OrderDto>> GetAllOrdersAsync()
        {
            var orders = await _unitOfWork.Order.GetAllAsync();
            return orders.Select(o => new OrderDto
            {
                TotalAmount = o.TotalAmount,
                Status = o.Status,
                CreatedAt = o.CreatedAt
            });
        }

        public async Task<OrderDto?> GetOrderByIdAsync(int id)
        {
            var order = await _unitOfWork.Order.GetByIdAsync(id);
            if (order == null) return null;

            return new OrderDto
            {
                TotalAmount = order.TotalAmount,
                Status = order.Status,
                CreatedAt = order.CreatedAt
            };
        }

        public async Task AddOrderAsync(OrderDto orderDto)
        {
            var order = new Order
            {
                TotalAmount = orderDto.TotalAmount,
                Status = orderDto.Status,
                CreatedAt = orderDto.CreatedAt
            };

            await _unitOfWork.Order.AddAsync(order);
            _unitOfWork.Save();
        }

        public async Task UpdateOrderStatusAsync(int id, string status)
        {
            var order = await _unitOfWork.Order.GetByIdAsync(id);
            if (order == null) return;

            order.Status = status;
            _unitOfWork.Order.Update(order);
            _unitOfWork.Save();
        }

        public async Task DeleteOrderAsync(int id)
        {
            var order = await _unitOfWork.Order.GetByIdAsync(id);
            if (order == null) return;

            _unitOfWork.Order.Delete(order);
            _unitOfWork.Save();
        }
    }
}