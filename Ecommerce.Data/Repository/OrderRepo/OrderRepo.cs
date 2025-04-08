using System;
using Ecommerce.Data.Data;
using Ecommerce.Data.Model;
using Ecommerce.Data.Repository.IRepo;
using Microsoft.EntityFrameworkCore;  // Assuming Repo<T, TKey> is here

namespace Ecommerce.Data.Repository.OrderRepo
{
    public class OrderRepo : Repo<Order>, IOrderRepo
    {
        private readonly ApplicationDbContext _context;

        public OrderRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await _context.Orders.ToListAsync();
        }

        public async Task<Order?> GetByIdAsync(int id)
        {
            return await _context.Orders.FindAsync(id);
        }

        public async Task AddAsync(Order order)
        {
            await _context.Orders.AddAsync(order);
        }

        public void Update(Order order)
        {
            _context.Orders.Update(order);
        }

        public void Delete(Order order)
        {
            _context.Orders.Remove(order);
        }
    }

    public class Repo<T>
    {
    }
}
