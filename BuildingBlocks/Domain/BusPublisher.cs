using BuildingBlocks.Domain.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Domain
{
    public class BusPublisher : IBusPublisher
    {
        public async Task SendAsync(IIntegrationEvent integrationEvent,
        CancellationToken cancellationToken = default) => await SendAsync(new[] { integrationEvent }, cancellationToken);

        public async Task SendAsync(IReadOnlyList<IIntegrationEvent> integrationEvents, CancellationToken cancellationToken = default)
        {
            //if (integrationEvents is null) return;

            //_logger.LogTrace("Processing integration events start...");

            //foreach (var integrationEvent in integrationEvents)
            //{
            //    await _publishEndpoint.Publish((object)integrationEvent, context =>
            //    {
            //        context.CorrelationId = new Guid(_httpContextAccessor.HttpContext.GetCorrelationId());
            //        context.Headers.Set("UserId",
            //            _httpContextAccessor?.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier));
            //        context.Headers.Set("UserName",
            //            _httpContextAccessor?.HttpContext?.User?.FindFirstValue(ClaimTypes.Name));
            //    }, cancellationToken);

            //    _logger.LogTrace("Publish a message with ID: {Id}", integrationEvent?.EventId);
            //}

            //_logger.LogTrace("Processing integration events done...");
        }
    }
}
