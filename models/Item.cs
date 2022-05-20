using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eGertis.Models
{
    public class Item
    {
        public int Id {get; set;}
        public string Name {get; set;}
    }
}