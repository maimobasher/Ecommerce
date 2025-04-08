using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Data.Model;
using Ecommerce.Data.Repository.UnitOfWork;
using Ecommerce.Domain.Dtos;

namespace Ecommerce.Domain.Services.UserService
{
    public class UserService:IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            var users = await _unitOfWork.User.GetAllAsync();
            return users.Select(u => new UserDto
            {
                FullName = u.FullName,
                Email = u.Email,
                Phone = u.Phone,
                Address = u.Address,
                UserType = u.UserType,
                CreatedAt = u.CreatedAt
            });
        }

        public async Task<UserDto?> GetUserByIdAsync(int id)
        {
            var user = await _unitOfWork.User.GetByIdAsync(id);
            if (user == null) return null;

            return new UserDto
            {
                FullName = user.FullName,
                Email = user.Email,
                Phone = user.Phone,
                Address = user.Address,
                UserType = user.UserType,
                CreatedAt = user.CreatedAt
            };
        }

        public async Task AddUserAsync(UserDto userDto)
        {
            var user = new User
            {
                FullName = userDto.FullName,
                Email = userDto.Email,
                Password = userDto.Password, // Ensure password is hashed before saving
                Phone = userDto.Phone,
                Address = userDto.Address,
                UserType = userDto.UserType,
                CreatedAt = userDto.CreatedAt ?? DateTime.Now
            };

            await _unitOfWork.User.AddAsync(user);
            _unitOfWork.Save();
        }

        public async Task UpdateUserAsync(int id, UserDto userDto)
        {
            var user = await _unitOfWork.User.GetByIdAsync(id);
            if (user == null) return;

            user.FullName = userDto.FullName;
            user.Email = userDto.Email;
            user.Phone = userDto.Phone;
            user.Address = userDto.Address;
            user.UserType = userDto.UserType;

            _unitOfWork.User.Update(user);
            _unitOfWork.Save();
        }

        public async Task DeleteUserAsync(int id)
        {
            var user = await _unitOfWork.User.GetByIdAsync(id);
            if (user == null) return;

            _unitOfWork.User.Delete(user);
            _unitOfWork.Save();
        }
    }
}
