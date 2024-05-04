using bookWebApi.Data;
using bookWebApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace bookWebApi.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<bool> AddUser(User user)
        {
            await _context.Users.AddAsync(user);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<User?> GetUserByEmail(string email)
        {
            return await _context.Users.Include(x=> x.Role).FirstOrDefaultAsync(x => x.Email.ToLower() == email.ToLower());
        }
    }
}
