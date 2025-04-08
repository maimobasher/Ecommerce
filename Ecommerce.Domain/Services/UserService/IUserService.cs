using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Domain.Dtos;

namespace Ecommerce.Domain.Services.UserService
{
    public interface IUserService
    {

        Task<IEnumerable<UserDto>> GetAllUsersAsync();
        Task<UserDto?> GetUserByIdAsync(int id);
        Task AddUserAsync(UserDto user);
        Task UpdateUserAsync(int id, UserDto user);
        Task DeleteUserAsync(int id);
    }
}
