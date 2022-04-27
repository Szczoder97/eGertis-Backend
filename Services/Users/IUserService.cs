using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eGertis.Dtos.Users;
using eGertis.Enums;
using eGertis.Models;

namespace eGertis.Services.Users
{
    public interface IUserService
    {
        Task<ServiceResponse<GetUserDto>> GetById(int id);
        Task<ServiceResponse<List<GetUserDto>>> GetAll();
        Task<ServiceResponse<List<GetUserDto>>> ChangeRole(ChangeRoleDto dto);
        Task<ServiceResponse<List<GetUserDto>>> Delete(int id);
    }
}