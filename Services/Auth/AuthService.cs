using System.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eGertis.Dtos.User;
using eGertis.Models;
using eGertis.Repositories.Auth;

namespace eGertis.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepo;
        public AuthService(IAuthRepository authRepo)
        {
            _authRepo = authRepo;
        }
        public async Task<ServiceResponse<string>> Login(LoginUserDto userDto)
        {
            var servieResponse = new ServiceResponse<string>();
            var token = await _authRepo.Login(userDto.Email, userDto.Password);
            if(token.Equals(string.Empty))
            {
                servieResponse.Success = false;
                servieResponse.Message = "Email and password do not match!";
                return servieResponse;
            }
            servieResponse.Data = token;
            return servieResponse;
        }

        public async Task<ServiceResponse<int>> Register(RegisterUserDto userDto)
        {
            var serviceResponse = new ServiceResponse<int>();
            if(await _authRepo.UserExists(userDto.Email))
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "User with this email already exists!";
                return serviceResponse;
            }
            var user = new User();
            user.Email = userDto.Email;
            user.Name = userDto.Name;
            user.Surname = userDto.Surname;
            serviceResponse.Data = await _authRepo.Register(user, userDto.Password);
            serviceResponse.Message = $"Created new user with email: {userDto.Email}";
            return serviceResponse;
        }
    }
}