using bookWebApi.Data;
using bookWebApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace bookWebApi.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext _context;

        public BookRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddBook(Book book)
        {
            await _context.Books.AddAsync(book);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteBook(Book book)
        {
            _context.Books.Remove(book);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Book>> GetAllBooks()
        {

            return await _context.Books
                .Include(book => book.Genre)
                .Include(book => book.Reviews)
                .ToListAsync();
        }

        public async Task<Book?> GetBook(Guid id)
        {
            return await _context.Books.FindAsync(id);
        }

        public async Task<bool> UpdateBook(Book book, Book oldBook)
        {
            oldBook.Title = book.Title;
            oldBook.Author = book.Author;
            oldBook.Description = book.Description;
            oldBook.Genre = book.Genre;
            oldBook.UpdatedDate = DateTime.Now;
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
