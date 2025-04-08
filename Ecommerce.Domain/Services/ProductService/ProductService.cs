using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Data.Model;
using Ecommerce.Data.Repository.UnitOfWork;
using Ecommerce.Domain.Dtos;

namespace Ecommerce.Domain.Services.ProductService
{
    public class ProductService:IProductService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
        {
            var products = await _unitOfWork.Product.GetAllAsync();
            return products.Select(p => new ProductDto
            {
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                Stock = p.Stock,
                ImageURL = p.ImageURL,
                CreatedAt = p.CreatedAt
            });
        }

        public async Task<ProductDto?> GetProductByIdAsync(int id)
        {
            var product = await _unitOfWork.Product.GetByIdAsync(id);
            if (product == null) return null;

            return new ProductDto
            {
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Stock = product.Stock,
                ImageURL = product.ImageURL,
                CreatedAt = product.CreatedAt
            };
        }

        public async Task AddProductAsync(ProductDto productDto)
        {
            var product = new Product
            {
                Name = productDto.Name,
                Description = productDto.Description,
                Price = productDto.Price,
                Stock = productDto.Stock,
                ImageURL = productDto.ImageURL,
                CreatedAt = productDto.CreatedAt
            };

            await _unitOfWork.Product.AddAsync(product);
            _unitOfWork.Save();
        }

        public async Task UpdateProductAsync(int id, ProductDto productDto)
        {
            var product = await _unitOfWork.Product.GetByIdAsync(id);
            if (product == null) return;

            product.Name = productDto.Name;
            product.Description = productDto.Description;
            product.Price = productDto.Price;
            product.Stock = productDto.Stock;
            product.ImageURL = productDto.ImageURL;

            _unitOfWork.Product.Update(product);
            _unitOfWork.Save();
        }

        public async Task DeleteProductAsync(int id)
        {
            var product = await _unitOfWork.Product.GetByIdAsync(id);
            if (product == null) return;

            _unitOfWork.Product.Delete(product);
            _unitOfWork.Save();
        }
    }
}

