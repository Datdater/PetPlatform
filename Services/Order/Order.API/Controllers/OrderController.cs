using MediatR;
using Microsoft.AspNetCore.Mvc;
using Order.Application.Feature.Orders.Commands.CreateOrder;

namespace Order.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController(IMediator mediator) : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> Post(CreateOrderCommand createOrderCommand)
        {
            await mediator.Send(createOrderCommand);
            return Ok();
        }
    }
}
