using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreServices.Api.ShoppingCart.Application;

namespace StoreServices.Api.ShoppingCart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartBuysController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CartBuysController(IMediator mediator)
        {
            _mediator = mediator;   
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Create(New.Execute data)
        {
            return await _mediator.Send(data);
        }
    }
}
