using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Domain.Dtos;

namespace Ecommerce.Domain.Services.CategoryService
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync();
        Task<CategoryDto?> GetCategoryByIdAsync(int id);
        Task AddCategoryAsync(CategoryDto category);
        Task UpdateCategoryAsync(int id, CategoryDto category);
        Task DeleteCategoryAsync(int id);
    }
}
