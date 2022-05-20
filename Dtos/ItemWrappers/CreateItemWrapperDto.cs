using eGertis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eGertis.Dtos.ItemWrappers
{
    public class CreateItemWrapperDto
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
    }
}
