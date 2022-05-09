using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StoreServices.Api.Book.Model;
using StoreServices.Api.Book.Persistence;

namespace StoreServices.Api.Book.Application
{
    public class Query
    {
        public class Execute : IRequest<List<BookMaterialDto>>{ }
        public class Managment : IRequestHandler<Execute, List<BookMaterialDto>>
        {
            private readonly ContextLibrary _contextLibrary;
            private readonly IMapper _mapper;

            public Managment(ContextLibrary contextLibrary, IMapper mapper)
            {
                _contextLibrary = contextLibrary;
                _mapper = mapper;
            }
            public async Task<List<BookMaterialDto>> Handle(Execute request, CancellationToken cancellationToken)
            {
                var books = await _contextLibrary.LibraryMaterial.ToListAsync();            
                var bookDto = _mapper.Map<List<LibraryMaterial>, List<BookMaterialDto>>(books);    
                return bookDto;
            }
        }

    }
}
