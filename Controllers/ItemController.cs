using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eGertis.Dtos.Items;
using eGertis.Models;
using eGertis.Services.Items;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eGertis.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ItemController : ControllerBase
    {
        private readonly IItemService _itemServie;   
        public ItemController(IItemService itemService)
        {
            _itemServie = itemService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateItem(AddItemDto itemDto)
        {
            return Ok(await _itemServie.Create(itemDto));
        }
        
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<GetItemDto>>>> GetAllItems(){
            return Ok(await _itemServie.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetItemById(int id)
        {
            return Ok(await _itemServie.GetById(id));
        }

        [HttpPut]
        public async Task<ActionResult> UpdateItem(UpdateItemDto itemDto)
        {
            return Ok(await _itemServie.Update(itemDto));
        }
        
        [HttpDelete("{id}")]
        public async Task<ActionResult> RemoveItem(int id)
        {
            return Ok(await _itemServie.Delete(id));
        }
    }
}