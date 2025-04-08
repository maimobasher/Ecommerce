using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Data.Model;
using Ecommerce.Data.Repository.UnitOfWork;
using Ecommerce.Domain.Dtos;

namespace Ecommerce.Domain.Services.PaymentService
{
    public class PaymentService:IPaymentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PaymentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<PaymentDto>> GetAllPaymentsAsync()
        {
            var payments = await _unitOfWork.Payment.GetAllAsync();
            return payments.Select(p => new PaymentDto
            {
                Amount = p.Amount,
                PaymentMethod = p.PaymentMethod,
                PaymentStatus = p.PaymentStatus,
                CreatedAt = p.CreatedAt
            });
        }

        public async Task<PaymentDto?> GetPaymentByIdAsync(int id)
        {
            var payment = await _unitOfWork.Payment.GetByIdAsync(id);
            if (payment == null) return null;

            return new PaymentDto
            {
                Amount = payment.Amount,
                PaymentMethod = payment.PaymentMethod,
                PaymentStatus = payment.PaymentStatus,
                CreatedAt = payment.CreatedAt
            };
        }

        public async Task AddPaymentAsync(PaymentDto paymentDto)
        {
            var payment = new Payment
            {
                Amount = paymentDto.Amount,
                PaymentMethod = paymentDto.PaymentMethod,
                PaymentStatus = paymentDto.PaymentStatus,
                CreatedAt = paymentDto.CreatedAt
            };

            await _unitOfWork.Payment.AddAsync(payment);
            _unitOfWork.Save();
        }

        public async Task UpdatePaymentAsync(int id, PaymentDto paymentDto)
        {
            var payment = await _unitOfWork.Payment.GetByIdAsync(id);
            if (payment == null) return;

            payment.Amount = paymentDto.Amount;
            payment.PaymentMethod = paymentDto.PaymentMethod;
            payment.PaymentStatus = paymentDto.PaymentStatus;
            _unitOfWork.Payment.Update(payment);
            _unitOfWork.Save();
        }

        public async Task DeletePaymentAsync(int id)
        {
            var payment = await _unitOfWork.Payment.GetByIdAsync(id);
            if (payment == null) return;

            _unitOfWork.Payment.Delete(payment);
            _unitOfWork.Save();
        }

    }
}
