using bookWebApi.Entities;
using bookWebApi.Repository;

namespace Admin.AddBook
{
    internal sealed class Endpoint : Endpoint<AddBookRequest>
    {

        private readonly IBookRepository _repo;

        public Endpoint(IBookRepository repo)
        {
            _repo = repo;
        }

        public override void Configure()
        {
            Post("/api/book/create");
            Roles("Admin");
        }

        public override async Task HandleAsync(AddBookRequest r, CancellationToken c)
        {

            if (await _repo.GetBookByTitle(r.Title) is not null)
                {
                ThrowError("Ta książka już istnieje");
                }


            var book = new Book
            {
                Id = Guid.NewGuid(),
                Title = r.Title,
                Author = r.Author,
                Description = r.Description,
                GenreId = r.GenreId,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
            };

            if(await _repo.AddBook(book))
            {
                await SendOkAsync(c);
                return;
            }

            ThrowError("Coś poszło nie tak");
        }
    }
}