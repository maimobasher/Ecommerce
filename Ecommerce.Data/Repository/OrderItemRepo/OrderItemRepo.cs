using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Data.Data;
using Ecommerce.Data.Model;
using Ecommerce.Data.Repository.IRepo;
using Ecommerce.Data.Repository.OrderItemRepo;
using Microsoft.EntityFrameworkCore;
namespace Ecommerce.Data.Repository.OrderItemRepo
{
    
        public class OrderItemRepo : Repo<OrderItem, Guid>, IOrderItemRepo
        {
            private readonly ApplicationDbContext _context;

            public OrderItemRepo(ApplicationDbContext context) : base(context)
            {
                _context = context; // هذا هو المهم
            }

            public async Task<IEnumerable<OrderItem>> GetAllAsync()
            {
                return await _context.OrderItems.ToListAsync();
            }

            public async Task<OrderItem?> GetByIdAsync(int id)
            {
                return await _context.OrderItems.FindAsync(id);
            }

            public async Task AddAsync(OrderItem orderItem)
            {
                await _context.OrderItems.AddAsync(orderItem);
            }

            public void Update(OrderItem orderItem)
            {
                _context.OrderItems.Update(orderItem);
            }

            public void Delete(OrderItem orderItem)
            {
                _context.OrderItems.Remove(orderItem);
            }
        }

    }
