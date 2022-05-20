using System;
using System.Threading.Tasks;
using eGertis.Constants;
using eGertis.Dtos.Orders;
using eGertis.Services.Orders;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eGertis.Controllers
{
    [Authorize(Roles = UserRole.VerifiedUser)]
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<ActionResult> Create(string title)
        {
            return Ok(await _orderService.Create(title));
        }
        
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateOrderDto dto)
        {
            var response = await _orderService.Update(id, dto);
            if(response.Success == false)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [Authorize(Roles = UserRole.SupplyWorker)]
        [HttpGet("{id}/realize")]
        public async Task<ActionResult> Realize(int id)
        {
            var response = await _orderService.Realize(id);
            if (response.Success != true)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var response = await _orderService.GetAll();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GatById(int id)
        {
            var response = await _orderService.GetById(id);
            if(response.Success != true)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

    }
}