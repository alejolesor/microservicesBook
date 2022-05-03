using FluentValidation;
using MediatR;
using StoreService.Api.Author.Model;

namespace StoreService.Api.Author.Application
{
    public class New
    {
        public class Execute : IRequest
        {
            public string Name { get; set; }
            public string LastName { get; set; }
            public DateTime? DateOfBirth { get; set; }
        }

        public class ExecuteValidation : AbstractValidator<Execute>
        {
            public ExecuteValidation()
            {
                RuleFor(x => x.Name).NotEmpty();
                RuleFor(x => x.LastName).NotEmpty();

            }
        }

        public class Managment : IRequestHandler<Execute>
        {
            public readonly ContextAuthor _contextAuthor;
            public Managment(ContextAuthor contextAuthor)
            {
                _contextAuthor = contextAuthor;
            }
            public async Task<Unit> Handle(Execute request, CancellationToken cancellationToken)
            {
                var authorBook = new AuthorBook
                {
                    Name = request.Name,
                    LastName = request.LastName,
                    DateOfBirth = request.DateOfBirth,
                    AuthorBookGuid = Convert.ToString(Guid.NewGuid()),
                };

                _contextAuthor.AuthorBook.Add(authorBook);
                var value = await _contextAuthor.SaveChangesAsync();
                if (value > 0)
                {
                    return Unit.Value;
                }

                throw new Exception("isn't possible do the insert of the record ");

            }
        }
    }
}
