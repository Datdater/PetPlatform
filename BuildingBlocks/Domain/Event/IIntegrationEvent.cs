using MassTransit;
using MassTransit.Topology;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Domain.Event
{
    [ExcludeFromTopology]
    public interface IIntegrationEvent : IEvent
    {
    }
}
