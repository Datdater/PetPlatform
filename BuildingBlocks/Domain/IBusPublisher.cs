using BuildingBlocks.Domain.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Domain
{
    public interface IBusPublisher
    {
        
        public Task SendAsync(IIntegrationEvent integrationEvent, CancellationToken cancellationToken = default);
        public Task SendAsync(IReadOnlyList<IIntegrationEvent> integrationEvents, CancellationToken cancellationToken = default);
    }
}
