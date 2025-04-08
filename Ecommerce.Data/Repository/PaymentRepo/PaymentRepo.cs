using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Data.Data;
using Ecommerce.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Data.Repository.PaymentRepo
{
    public class PaymentRepo : Repo<Payment, Guid>, IPaymentRepo
    {
        private readonly ApplicationDbContext _context;

        public PaymentRepo(ApplicationDbContext context) : base(context)
        {
            _context = context; // ✅ تم التهيئة
        }

        public async Task<IEnumerable<Payment>> GetAllAsync()
        {
            return await _context.Payments.ToListAsync();
        }

        public async Task<Payment?> GetByIdAsync(int id)
        {
            return await _context.Payments.FindAsync(id);
        }

        public async Task AddAsync(Payment payment)
        {
            await _context.Payments.AddAsync(payment);
        }

        public void Update(Payment payment)
        {
            _context.Payments.Update(payment);
        }

        public void Delete(Payment payment)
        {
            _context.Payments.Remove(payment);
        }

        public Payment Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Payment> GetAsync(int id)
        {
            throw new NotImplementedException();
        }
    }

}