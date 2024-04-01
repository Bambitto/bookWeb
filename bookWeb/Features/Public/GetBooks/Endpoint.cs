using bookWebApi.Repository;

namespace Public.GetBooks
{
    internal sealed class Endpoint : EndpointWithoutRequest<Response>
    {
        private readonly IBookRepository _repo;

        public Endpoint(IBookRepository repo)
        {
            _repo = repo;
        }

        public override void Configure()
        {
            Get("/public/get-books");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CancellationToken c)
        {
            var books = await _repo.GetAllBooks();

            if (books is null || !books.Any())
            {
                await SendNoContentAsync(c);
            }

            else
            {
                var response = new Response()
                {
                    Books = books.Select(x => new ResponseEntity
                    {
                        Id = x.Id,
                        Author = x.Author,
                        Title = x.Title,
                        Description = x.Description,
                        GenreId = x.GenreId,
                        Genre = x.Genre.Name,
                        CreatedDate = x.CreatedDate,
                        UpdatedDate = x.UpdatedDate,
                        Reviews = x.Reviews
                    })
                };
                await SendOkAsync(response, c);
                return;
            }

            await SendStringAsync("something went wrong", 400, cancellation: c);
        }
    }
}