using FluentValidation;
using MediatR;
using StoreServices.Api.Book.Model;
using StoreServices.Api.Book.Persistence;

namespace StoreServices.Api.Book.Application
{
    public class New
    {
        public class Execute : IRequest
        {
            public string Tittle { get; set; }
            public DateTime? DatePublication { get; set; }
            public Guid? AuthorBook { get; set; }

        }

        public class ExecuteValidation : AbstractValidator<Execute>
        {
            public ExecuteValidation()
            {
                RuleFor(x => x.Tittle).NotEmpty();
                RuleFor(x => x.DatePublication).NotEmpty();
                RuleFor(x => x.AuthorBook).NotEmpty();
            }
        }

        public class Managment : IRequestHandler<Execute>
        {
            private readonly ContextLibrary _contextLibrary;

            public Managment(ContextLibrary contextLibrary)
            {
                _contextLibrary = contextLibrary;
            }
            public async Task<Unit> Handle(Execute request, CancellationToken cancellationToken)
            {
                var book = new LibraryMaterial
                {
                    Title = request.Tittle,
                    DatePublication = request.DatePublication,
                    AuthorBook = request.AuthorBook,
                };
                _contextLibrary.LibraryMaterial.Add(book);
                var value = await _contextLibrary.SaveChangesAsync();
                if (value>0)
                {
                    return Unit.Value;
                }
                throw new Exception("could not store Book");
            }
        }
    }
}
