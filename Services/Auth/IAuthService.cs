using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eGertis.Dtos.Users;
using eGertis.Models;

namespace eGertis.Services.Auth
{
    public interface IAuthService
    {
        Task<ServiceResponse<int>> Register(RegisterUserDto userDto);
        Task<ServiceResponse<string>> Login(LoginUserDto userDto);
        int GetUserId();
    }
}