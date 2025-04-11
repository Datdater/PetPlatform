using BuildingBlocks.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Domain.Entities
{
    public class OrderDetail : BaseEntity
    {
        public Guid OrderId { get; set; }
        public string ProductVariationId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        // Navigation properties
        public virtual Order Order { get; set; }
    }
}
