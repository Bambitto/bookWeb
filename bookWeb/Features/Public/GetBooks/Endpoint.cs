namespace Public.GetBooks
{
    internal sealed class Endpoint(Data data) : EndpointWithoutRequest<Response>
    {
        private readonly Data _data = data;

        public override void Configure()
        {
            Get("/public/get-books");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CancellationToken c)
        {
            var books = await _data.GetBooks();

            var response = new Response()
            { 
                Books = books.Select(x => new bookWebApi.Entities.Book
                {
                    Id = x.Id,
                    Author = x.Author,
                    Title = x.Title,
                    Description = x.Description,
                    Genre = x.Genre,
                    CreatedDate = x.CreatedDate,
                    UpdatedDate = x.UpdatedDate,
                })
            };

            await SendOkAsync(response, c);
        }
    }
}