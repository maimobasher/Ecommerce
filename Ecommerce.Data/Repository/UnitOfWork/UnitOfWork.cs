using System;
using Ecommerce.Data.Data;
using Ecommerce.Data.Repository.OrderItemRepo;
using Ecommerce.Data.Repository.CategoryRepo;
using Ecommerce.Data.Repository.OrderRepo;
using Ecommerce.Data.Repository.PaymentRepo;
using Ecommerce.Data.Repository.ProductRepo;
using Ecommerce.Data.Repository.ReviewRepo;
using Microsoft.EntityFrameworkCore;
using Ecommerce.Data.Model;
using Ecommerce.Data.Repository.UserRepo;

namespace Ecommerce.Data.Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;

            Category = new CategoryRepo.CategoryRepo(_context);
            Product = new ProductRepo.ProductRepo(_context);
            OrderItem = new OrderItemRepo.OrderItemRepo(_context);
            Order = new OrderRepo.OrderRepo(_context);
            Review = new ReviewRepo.ReviewRepo(_context);
            Payment = new PaymentRepo.PaymentRepo(_context);
            User = new UserRepo.UserRepo(_context); // ✅ التهيئة المفقودة
        }

        public IProductRepo Product { get; private set; }
        public ICategoryRepo Category { get; private set; }
        public IReviewRepo Review { get; private set; }
        public IPaymentRepo Payment { get; private set; }
        public IOrderRepo Order { get; private set; }
        public IOrderItemRepo OrderItem { get; private set; }
        public IUserRepo User { get; private set; }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
