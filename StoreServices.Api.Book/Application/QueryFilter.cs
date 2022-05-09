using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StoreServices.Api.Book.Model;
using StoreServices.Api.Book.Persistence;

namespace StoreServices.Api.Book.Application
{
    public class QueryFilter
    {
        public class BookUnic : IRequest<BookMaterialDto>
        {
            public Guid? BookId { get; set; }
        }
        public class Managment : IRequestHandler<BookUnic, BookMaterialDto>
        {
            private readonly ContextLibrary _contextLibrary;
            private readonly IMapper _mapper;
            public Managment(ContextLibrary contextLibrary, IMapper mapper)
            {
                _contextLibrary = contextLibrary;
                _mapper = mapper;
            }
            public async Task<BookMaterialDto> Handle(BookUnic request, CancellationToken cancellationToken)
            {
                var book = await _contextLibrary.LibraryMaterial.Where(x => x.LibraryMaterialId == request.BookId).FirstOrDefaultAsync();
                if (book == null) { throw new Exception("the book was not found"); }
                var bookDto = _mapper.Map<LibraryMaterial,BookMaterialDto>(book);
                return bookDto;
            }
        }
    }
}
