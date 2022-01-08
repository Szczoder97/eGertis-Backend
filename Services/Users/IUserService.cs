using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eGertis.Dtos.User;
using eGertis.Enums;
using eGertis.Models;

namespace eGertis.Services.Users
{
    public interface IUserService
    {
        Task<ServiceResponse<GetUserDto>> GetUserById(int id);
        Task<ServiceResponse<List<GetUserDto>>> GetAllUsers();
        Task<ServiceResponse<List<GetUserDto>>> GetFreeUsers();
        Task<ServiceResponse<List<GetUserDto>>> ChangeUserRole(ChangeRoleDto dto);
        Task<ServiceResponse<List<GetUserDto>>> RemoveUser(int id);
    }
}