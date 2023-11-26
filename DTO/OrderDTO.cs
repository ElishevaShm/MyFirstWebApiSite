using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class OrderDTO
    {

        public int OrderId { get; set; }

        public int? UserId { get; set; }

        public int? OrderSum { get; set; }

        public DateTime? OrderDate { get; set; }

        public virtual ICollection<OrderItemDTO>? OrderItems { get; set; } = new List<OrderItemDTO>();
    }
}
