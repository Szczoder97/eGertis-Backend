using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eGertis.Dtos.Item;
using eGertis.models;
using eGertis.Services.Items;
using Microsoft.AspNetCore.Mvc;

namespace eGertis.Controllers
{
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
        public async Task<ActionResult<ServiceResponse<List<GetItemDto>>>> AddItem(AddItemDto itemDto)
        {
            return Ok(await _itemServie.AddItem(itemDto));
        }
        
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<GetItemDto>>>> GetAllItems(){
            return Ok(await _itemServie.GetAllItems());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetItemDto>>> GetItemById(int id)
        {
            return Ok(await _itemServie.GetItem(id));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<GetItemDto>>>> UpdateItem(UpdateItemDto itemDto)
        {
            return Ok(await _itemServie.UpdateItem(itemDto));
        }
        
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetItemDto>>>> DeleteItem(int id)
        {
            return Ok(await _itemServie.DeleteItem(id));
        }
    }
}