using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Data.Repository.CategoryRepo;
using Ecommerce.Data.Repository.OrderItemRepo;
using Ecommerce.Data.Repository.PaymentRepo;
using Ecommerce.Data.Repository.ProductRepo;
using Ecommerce.Data.Repository.ReviewRepo;
using Ecommerce.Data.Repository.UserRepo;


namespace Ecommerce.Data.Repository.UnitOfWork
{
    public interface IUnitOfWork:IDisposable
    {
        IProductRepo Product { get; }
        ICategoryRepo Category { get; }
        
        IReviewRepo Review { get; }
        IPaymentRepo Payment { get; }
        IOrderRepo Order { get; }
        IOrderItemRepo OrderItem { get; }
        IUserRepo User { get; } 

        
        int Save();
    }
}
