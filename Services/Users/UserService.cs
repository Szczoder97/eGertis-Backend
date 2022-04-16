using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using eGertis.Dtos.Users;
using eGertis.Enums;
using eGertis.Models;
using eGertis.Repositories.Users;

namespace eGertis.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<List<GetUserDto>>> ChangeUserRole(ChangeRoleDto dto)
        {
            var serviceResponse = new ServiceResponse<List<GetUserDto>>();
            try
            {
                var users = await _userRepository.ChangeUserRole(dto.UserId, dto.Role);
                serviceResponse.Data = users.Select(u => _mapper.Map<GetUserDto>(u)).ToList();
            }
            catch(Exception e)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = e.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetUserDto>>> GetAllUsers()
        {
            var serviceResponse = new ServiceResponse<List<GetUserDto>>();
            try
            {
                var users = await _userRepository.GetAllUsers();
                serviceResponse.Data = users.Select(u => _mapper.Map<GetUserDto>(u)).ToList();
            }
            catch(Exception e)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = e.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetUserDto>> GetUserById(int id)
        {
            var serviceResponse = new ServiceResponse<GetUserDto>();
            try
            {
                var user = await _userRepository.GetUserById(id);
                serviceResponse.Data = _mapper.Map<GetUserDto>(user);
            }
            catch(Exception e)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = e.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetUserDto>>> RemoveUser(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetUserDto>>();
            try
            {
                var users = await _userRepository.RemoveUser(id);
                serviceResponse.Data = users.Select(u => _mapper.Map<GetUserDto>(u)).ToList();
            }
            catch(Exception e)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = e.Message;
            }
            return serviceResponse;
        }
    }
}