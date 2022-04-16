using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eGertis.Dtos.Users;
using eGertis.Models;
using eGertis.Services.Users;
using Microsoft.AspNetCore.Mvc;

namespace eGertis.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService) 
        {
            _userService = userService;
        }
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<GetUserDto>>>> GetAllUsers()
        {
            var response = await _userService.GetAllUsers();
            if(!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetUserDto>>> GetUserById(int id)
        {
            var response = await _userService.GetUserById(id);
            if(!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<GetUserDto>>>> ChangeUserRole(ChangeRoleDto dto)
        {
            var response = await _userService.ChangeUserRole(dto);
            if(!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetUserDto>>>> RemoveUser(int id)
        {
            var response = await _userService.RemoveUser(id);
            if(!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        
    }
}