using BuildingBlocks.Contracts.EventBus.Message;
using BuildingBlocks.Contracts.Grpc;
using BuildingBlocks.Domain;
using Grpc.Net.Client;
using MagicOnion.Client;
using MassTransit;
using MassTransit.Transports;
using MediatR;
using Microsoft.Extensions.Options;
using Order.API.Configuration;
using Order.Domain.Entities;
using Order.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Application.Feature.Orders.Commands.CreateOrder
{
    public class CreateOrderHandler : IRequestHandler<CreateOrderCommand>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly IProductGrpcService _productGrpcService;
        private readonly IPublishEndpoint _publishEndpoint;

        public CreateOrderHandler(IOrderRepository orderRepository, IOptions<GrpcOptions> grpcOptions, IOrderDetailRepository orderDetailRepository, IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
            _orderRepository = orderRepository;
            _orderDetailRepository = orderDetailRepository;
            try
            {
                var channelProduct = GrpcChannel.ForAddress(grpcOptions.Value.ProductAddress);
                _productGrpcService = MagicOnionClient.Create<IProductGrpcService>(channelProduct);
            }
            catch (Exception ex)
            {
                throw new BuildingBlocks.Exception.BadRequestException($"Failed to create gRPC client: {ex.Message}");
            }
        }
        public async Task Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = new Domain.Entities.Order
            {
                UserId = request.CustomerId,
                OrderStatus = Domain.Enum.OrderStatus.Pending,

            };
            var orderDetails = new List<OrderDetail>();
            foreach (var orderDetail in request.OrderDetails)
            {
                var product = await _productGrpcService.GetProductByVariationIdAsync(orderDetail.ProductVariationId);
                
                orderDetails.Add(new OrderDetail
                {
                    ProductVariationId = orderDetail.ProductVariationId,
                    Quantity = orderDetail.Quantity,
                    Price = product.Price,
                });
                order.TotalPrice += product.Price * orderDetail.Quantity;
            }
            await _publishEndpoint.Publish(new OrderCreated()
            {
                OrderDetails = orderDetails.Select(x => new OrderDetailCreated
                {
                    ProductVariationId = x.ProductVariationId,
                    Quantity = x.Quantity
                }).ToList()
            });
            //await _orderDetailRepository.AddRangeAsync(orderDetails);
            //order.OrderDetails = orderDetails;
            //await _orderRepository.AddAsync(order);
        }


    }

}
