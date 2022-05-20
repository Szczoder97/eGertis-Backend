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
        public ServiceResponse<List<GetUserDto>> ChangeRole(ChangeRoleDto dto)
        {
            var serviceResponse = new ServiceResponse<List<GetUserDto>>();
            try
            {
                _userRepository.ChangeRole(dto.UserId, dto.Role);
                serviceResponse.Message = "Role has been changed!";
        
            }
            catch(Exception e)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = e.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetUserDto>>> GetAll()
        {
            var serviceResponse = new ServiceResponse<List<GetUserDto>>();
            try
            {
                var users = await _userRepository.GetAll();
                serviceResponse.Data = users.Select(u => _mapper.Map<GetUserDto>(u)).ToList();
            }
            catch(Exception e)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = e.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetUserDto>> GetById(int id)
        {
            var serviceResponse = new ServiceResponse<GetUserDto>();
            try
            {
                var user = await _userRepository.GetById(id);
                serviceResponse.Data = _mapper.Map<GetUserDto>(user);
            }
            catch(Exception e)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = e.Message;
            }
            return serviceResponse;
        }

        public ServiceResponse<List<GetUserDto>> Delete(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetUserDto>>();
            try
            {
                _userRepository.Delete(id);
                
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