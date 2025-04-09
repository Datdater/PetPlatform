using MediatR;
using Microsoft.AspNetCore.Mvc;
using Product.Application.Feature.Products.Commands.CreateProduct;
using Product.Application.Feature.Products.Queries.GetAllProduct;
using Product.Application.Feature.Products.Queries.GetProductDetail;

namespace Product.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController(IMediator mediator) : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> Post(CreateProductCommand createProduct)
        {
            await mediator.Send(createProduct);
            return Ok();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<ActionResult> Get(string id)
        {
            var result = await mediator.Send(new GetProductSpecificQuery() {Id = id});
            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<ActionResult> GetAll([FromQuery] GetAllProductQuery getAllProduct)
        {
            var result = await mediator.Send(getAllProduct);
            return Ok(result);
        }
    }
}
