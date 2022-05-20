using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eGertis.Constants;
using eGertis.Dtos.Users;
using eGertis.Services.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eGertis.Controllers
{
    [Authorize(Roles = UserRole.Administrator)]
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
        public async Task<ActionResult> GetAllUsers()
        {
            var response = await _userService.GetAll();
            if(!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetUserById(int id)
        {
            var response = await _userService.GetById(id);
            if(!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult> ChangeUserRole(ChangeRoleDto dto)
        {
            var response = await _userService.ChangeRole(dto);
            if(!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> RemoveUser(int id)
        {
            var response = await _userService.Delete(id);
            if(!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
              
    }
}