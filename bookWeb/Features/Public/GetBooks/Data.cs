using bookWebApi.Data;
using bookWebApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace Public.GetBooks
{
    internal class Data(AppDbContext context)
    {
        private readonly AppDbContext _context = context;

        public async Task<IEnumerable<Book>> GetBooks()
        {
            return await _context.Books.ToListAsync();
        }
    }
}
