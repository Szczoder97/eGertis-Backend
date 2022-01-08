using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eGertis.Dtos.SailCamp;
using eGertis.Models;
using eGertis.Services.SailCamps;
using Microsoft.AspNetCore.Mvc;

namespace eGertis.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SailCampController : ControllerBase
    {
        private readonly ISailCampService _sailCampService;
        public SailCampController(ISailCampService sailCampService)
        {
            _sailCampService = sailCampService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<GetSailCampDto>>>> GetAllSailCamps()
        {
            var response = await _sailCampService.GetAllSailCamps();
            if(!response.Succes)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetSailCampDto>>> GetSailCampById(int id)
        {
            var response = await _sailCampService.GetSailCapmById(id);
            if(!response.Succes)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetSailCampDto>>>> CreateSailCamp(CreateSailCampDto sailCampDto)
        {
            var response = await _sailCampService.CreateSailCamp(sailCampDto);
            if(!response.Succes)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<GetSailCampDto>>>> UpdateSailCamp(UpdateSailCampDto sailCampDto)
        {
            var response = await _sailCampService.UpdateSailCamp(sailCampDto);
            if(!response.Succes)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetSailCampDto>>>> RemoveSailCamp(int id)
        {
            var response = await _sailCampService.RemoveSailCamp(id);
            if(!response.Succes)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}