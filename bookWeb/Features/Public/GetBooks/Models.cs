using bookWebApi.Entities;

namespace Public.GetBooks
{

    internal sealed class Response
    {
        public required IEnumerable<Book> Books { get; set; }
    }
}
