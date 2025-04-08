using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Data.Model;
using Ecommerce.Data.Repository.UnitOfWork;
using Ecommerce.Domain.Dtos;

namespace Ecommerce.Domain.Services.CategoryService
{
    public class CategoryService:ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync()
        {
            var categories = await _unitOfWork.Category.GetAllAsync();
            return categories.Select(c => new CategoryDto
            {
                CategoryName = c.CategoryName
            });
        }

        public async Task<CategoryDto?> GetCategoryByIdAsync(int id)
        {
            var category = await _unitOfWork.Category.GetByIdAsync(id);
            if (category == null) return null;

            return new CategoryDto
            {
                CategoryName = category.CategoryName
            };
        }

        public async Task AddCategoryAsync(CategoryDto categoryDto)
        {
            var category = new Category
            {
                CategoryName = categoryDto.CategoryName
            };

            await _unitOfWork.Category.AddAsync(category);
            _unitOfWork.Save();
        }

        public async Task UpdateCategoryAsync(int id, CategoryDto categoryDto)
        {
            var category = await _unitOfWork.Category.GetByIdAsync(id);
            if (category == null) return;

            category.CategoryName = categoryDto.CategoryName;
            _unitOfWork.Category.Update(category);
            _unitOfWork.Save();
        }

        public async Task DeleteCategoryAsync(int id)
        {
            var category = await _unitOfWork.Category.GetByIdAsync(id);
            if (category == null) return;

            _unitOfWork.Category.Delete(category);
            _unitOfWork.Save();
        }
    }
}
