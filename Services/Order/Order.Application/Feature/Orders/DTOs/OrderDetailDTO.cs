using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Application.Feature.Orders.DTOs
{
    public class OrderDetailDTO
    {
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string ProductVariationId { get; set; }

    }
}
