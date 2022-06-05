using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eGertis.Dtos.Orders
{
    public class OrderDto
    {
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public string Title { get; set; }
        public DateTime CreationDate { get; set; }
        public bool IsRealized { get; set; } = false;

        public OrderDto(int id, int ownerId, string title, DateTime creationDate, bool isRealized)
        {
            Id = id;
            OwnerId = ownerId;
            if(title != null)
            {
                Title = title;
            }
            else
            {
                Title = "unnamed";
            }
            CreationDate = creationDate;
            IsRealized = isRealized;
        }
    }
}
