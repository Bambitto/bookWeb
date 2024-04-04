using bookWebApi.Repository;

namespace Admin.DeleteBook
{
    internal sealed class Endpoint : Endpoint<DeleteBookRequest>
    {
        private readonly IBookRepository _repo;

        public Endpoint(IBookRepository repo)
        {
            _repo = repo;
        }

        public override void Configure()
        {
            Delete("/api/book/delete");
            AllowAnonymous();
        }

        public override async Task HandleAsync(DeleteBookRequest r, CancellationToken c)
        {
            var bookToDelete = await _repo.GetBook(r.Id);

            if(bookToDelete is null)
            {
                ThrowError("książka z tym id nie istnieje");
            }

            if(await _repo.DeleteBook(bookToDelete))
            {
                await SendOkAsync(cancellation: c);
            }
            else
            {
                ThrowError("coś poszło nie tak");
            }
        }
    }
}