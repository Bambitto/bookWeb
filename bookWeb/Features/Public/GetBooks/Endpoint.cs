using bookWebApi.Repository;

namespace Public.GetBooks
{
    internal sealed class Endpoint : EndpointWithoutRequest<GetBooksResponse>
    {
        private readonly IBookRepository _repo;

        public Endpoint(IBookRepository repo)
        {
            _repo = repo;
        }

        public override void Configure()
        {
            Get("/api/books");
            ResponseCache(60);
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
                var response = new GetBooksResponse()
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
                        Reviews = x.Reviews,
                        Score = x.Reviews.Count != 0 ? x.Reviews.Average(x => x.Score) : 0
                    })
                };
                await SendOkAsync(response, c);
                return;
            }

            await SendStringAsync("something went wrong", 400, cancellation: c);
        }
    }
}