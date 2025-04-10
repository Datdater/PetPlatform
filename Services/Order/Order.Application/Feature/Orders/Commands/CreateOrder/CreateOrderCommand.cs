using MediatR;
using Order.Application.Feature.Orders.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Application.Feature.Orders.Commands.CreateOrder
{
    public class CreateOrderCommand : IRequest
    {
        public string CustomerId { get; set; }
        public string AddressId { get; set; }
        public string PromotionId { get; set; }
        public decimal DeliveryPrice { get; set; }
        public List<OrderDetailDTO> OrderDetails { get; set; } = new List<OrderDetailDTO>();
    }
}
