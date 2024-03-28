using bookWebApi.Entities;

namespace bookWebApi.Repository
{
    public interface IBookRepository
    {
        public Task<Book?> GetBook(Guid id);
        public Task<IEnumerable<Book>> GetAllBooks();
        public Task<bool> AddBook(Book book);
        public Task<bool> DeleteBook(Book book);
        public Task<bool> UpdateBook(Book book, Book oldBook);
    }
}
