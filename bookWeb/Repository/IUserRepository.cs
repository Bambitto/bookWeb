using bookWebApi.Entities;

namespace bookWebApi.Repository
{
    public interface IUserRepository
    {
        public Task<bool> AddUser(User user);
        public Task<User?> GetUserByEmail(string email);
    }
}
