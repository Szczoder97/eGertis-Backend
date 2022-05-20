using eGertis.Dtos.ItemWrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eGertis.Dtos.Orders
{
    public class UpdateOrderDto
    {
        public string Title { get; set; }
        public List<CreateItemWrapperDto> Products { get; set; }

    }
}