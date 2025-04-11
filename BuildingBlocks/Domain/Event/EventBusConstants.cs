using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Domain.Event
{
    public class EventBusConstants
    {
        //This queue name will come in rabbit mq management portal
        public const string OrderQueue = "order-queue";
        public const string BasketCheckoutQueueV2 = "basketcheckout-queue-v2";
    }
}
