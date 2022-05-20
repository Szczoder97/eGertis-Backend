using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eGertis.Constants;
using eGertis.Dtos.Items;
using eGertis.Models;
using eGertis.Services.Items;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eGertis.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemController : ControllerBase
    {
        private readonly IItemService _itemService;   
        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }

        [Authorize(Roles = UserRole.Administrator)]
        [HttpPost]
        public async Task<ActionResult> CreateItem(AddItemDto itemDto)
        {
            return Ok(await _itemService.Create(itemDto));
        }

        [Authorize(Roles = UserRole.VerifiedUser)]
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<GetItemDto>>>> GetAllItems(){
            return Ok(await _itemService.GetAll());
        }

        [Authorize(Roles = UserRole.VerifiedUser)]
        [HttpGet("{id}")]
        public async Task<ActionResult> GetItemById(int id)
        {
            return Ok(await _itemService.GetById(id));
        }

        [Authorize(Roles = UserRole.Administrator)]
        [HttpPut]
        public async Task<ActionResult> UpdateItem(UpdateItemDto itemDto)
        {
            return Ok(await _itemService.Update(itemDto));
        }

        [Authorize(Roles = UserRole.Administrator)]
        [HttpDelete("{id}")]
        public async Task<ActionResult> RemoveItem(int id)
        {
            return Ok(await _itemService.Delete(id));
        }
    }
}