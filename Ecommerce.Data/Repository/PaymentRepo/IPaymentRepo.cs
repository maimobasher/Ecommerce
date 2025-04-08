using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Data.Model;
using Ecommerce.Data.Repository.IRepo;

namespace Ecommerce.Data.Repository.PaymentRepo
{
    public interface IPaymentRepo:IRepo<Payment,int>
    {
        Task<IEnumerable<Payment>> GetAllAsync();
        Task<Payment?> GetByIdAsync(int id);
        Task AddAsync(Payment payment);
        void Update(Payment payment);
        void Delete(Payment payment);
    }
}
