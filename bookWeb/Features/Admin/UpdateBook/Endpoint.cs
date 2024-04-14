using bookWebApi.Entities;
using bookWebApi.Repository;

namespace Admin.UpdateBook
{
    internal sealed class Endpoint : Endpoint<UpdateBookRequest>
    {
        private readonly IBookRepository _repo;

        public Endpoint(IBookRepository repo)
        {
            _repo = repo;
        }
            
        public override void Configure()
        {
            Post("api/book/update");
            AllowAnonymous();
        }

        public override async Task HandleAsync(UpdateBookRequest r, CancellationToken c)
        {
            var oldBook = await _repo.GetBook(r.Id);

            if(oldBook is null)
            {
                ThrowError("Coś poszło nie tak");
            }

            oldBook.Author = r.NewAuthor;
            oldBook.Title = r.NewTitle;
            oldBook.Description = r.NewDescription;
            oldBook.GenreId = r.NewGenreId;

            if (!await _repo.UpdateBook(oldBook))
            {
                ThrowError("Coś poszło nie tak");
            }

            await SendOkAsync(r);

            

        }
    }
}