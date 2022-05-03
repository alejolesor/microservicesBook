using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreService.Api.Author.Application;
using StoreService.Api.Author.Model;

namespace StoreService.Api.Author.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Create([FromBody] New.Execute author)
        {
            return await _mediator.Send(author);
        }

        [HttpGet]
        public async Task<ActionResult<List<AuthorDto>>> Get()
        {
            return await _mediator.Send(new Query.ListAuthor());
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorDto>> Get(string id)
        {
            return await _mediator.Send(new QueryFilter.AuthorUnique { authorGuid = id});
        }
    }
}
