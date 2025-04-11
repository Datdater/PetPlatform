using BuildingBlocks.Domain.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Contracts.EventBus.Message
{
    public class OrderCreated : BaseIntegrationEvent
    {
        public List<OrderDetailCreated> OrderDetails { get; set; }
    }

    public record OrderDetailCreated
    {
        public string? ProductVariationId { get; set; }
        public int Quantity { get; set; }
    }
}
