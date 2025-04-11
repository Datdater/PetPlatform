using BuildingBlocks.Contracts.EventBus.Message;
using MassTransit;
using Product.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Comsumers
{
    public class OrderConsumer : IConsumer<OrderCreated>
    {
        private readonly IVariantProductRepository _variantProductRepository;
        public OrderConsumer(IVariantProductRepository variantProductRepository)
        {
            _variantProductRepository = variantProductRepository;
        }
        public async Task Consume(ConsumeContext<OrderCreated> context)
        {
            // Handle the OrderCreated event here
            var orderDetails = context.Message.OrderDetails;
            foreach (var orderDetail in orderDetails)
            {
                // Process each order detail
                Console.WriteLine($"Product Variation ID: {orderDetail.ProductVariationId}, Quantity: {orderDetail.Quantity}");
                // Update the product variation quantity in the database
                var variantProduct = await _variantProductRepository.GetByIdAsync(orderDetail.ProductVariationId);
                if (variantProduct != null)
                {
                    variantProduct.Inventory -= orderDetail.Quantity;
                    await _variantProductRepository.UpdateAsync(variantProduct);
                }
                else
                {
                    // Handle the case where the product variation is not found
                    Console.WriteLine($"Product Variation ID {orderDetail.ProductVariationId} not found.");
                }
            }
        }
    }
    
}
