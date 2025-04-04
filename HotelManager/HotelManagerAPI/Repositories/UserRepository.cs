using HotelManagerAPI.DbContexts;
using HotelManagerAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelManagerAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly HotelManagerDbContext _context;

        public UserRepository(HotelManagerDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<User?> GetUserByUsernameAsync(string username)
        {
            return await _context.Users
                  .Where(u => u.UserName == username).FirstOrDefaultAsync();
        }

        public async Task<User?> GetUserByIdAsync(int userId)
        {
            return await _context.Users
                  .Where(u => u.Id == userId).FirstOrDefaultAsync();
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            return await _context.Users
                  .Where(u => u.Email == email).FirstOrDefaultAsync();
        }

        public void AddUser(User user)
        {
            _context.Users.Add(user);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}