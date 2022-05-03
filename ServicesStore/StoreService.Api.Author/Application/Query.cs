using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StoreService.Api.Author.Model;

namespace StoreService.Api.Author.Application
{
    public class Query
    {
        public class ListAuthor : IRequest<List<AuthorDto>> { }

        public class Managment : IRequestHandler<ListAuthor, List<AuthorDto>>
        {
            private readonly ContextAuthor _contextAuthor;
            private readonly IMapper _mapper;

            public Managment(ContextAuthor contextAuthor, IMapper mapper)
            {
                _contextAuthor = contextAuthor;
                _mapper = mapper;   
            }
            public async Task<List<AuthorDto>> Handle(ListAuthor request, CancellationToken cancellationToken)
            {
                var authors = await _contextAuthor.AuthorBook.ToListAsync();
                var authorDto = _mapper.Map<List<AuthorBook>, List<AuthorDto>>(authors);
                return authorDto;
            }
        }
    }
}
