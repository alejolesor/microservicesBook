using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreServices.Api.Book.Application;

namespace StoreServices.Api.Book.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookMaterialController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BookMaterialController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<ActionResult<Unit>> Create([FromBody] New.Execute data)
        {
            return await _mediator.Send(data);
        }

        [HttpGet]
        public async Task<ActionResult<List<BookMaterialDto>>> GetBooks()
        {
            return await _mediator.Send(new Query.Execute());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookMaterialDto>> GetBookUnic(Guid id)
        {
            return await _mediator.Send(new QueryFilter.BookUnic { BookId = id });
        }
    }
}
