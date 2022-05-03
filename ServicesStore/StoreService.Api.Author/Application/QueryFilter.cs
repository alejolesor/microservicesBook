using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StoreService.Api.Author.Model;

namespace StoreService.Api.Author.Application
{
    public class QueryFilter
    {
        public class AuthorUnique : IRequest<AuthorDto>
        {
            public string authorGuid { get; set; }
        }

        public class Managment : IRequestHandler<AuthorUnique, AuthorDto>
        {
            private readonly ContextAuthor _contextAuthor;
            private readonly IMapper _mapper;

            public Managment(ContextAuthor contextAuthor, IMapper mapper)
            {
                _contextAuthor = contextAuthor;
                _mapper = mapper;
            }
            public async Task<AuthorDto> Handle(AuthorUnique request, CancellationToken cancellationToken)
            {
               var author= await _contextAuthor.AuthorBook.Where(x => x.AuthorBookGuid == request.authorGuid).FirstOrDefaultAsync();
                if (author == null) {
                    throw new Exception("Not found Author");
                }
                var authorDto = _mapper.Map<AuthorBook, AuthorDto>(author);    
                return authorDto;
               
            }
        }
    }
}
