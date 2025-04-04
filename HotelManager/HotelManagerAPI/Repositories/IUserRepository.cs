using HotelManagerAPI.Entities;

namespace HotelManagerAPI.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetUserByUsernameAsync(string username);

        Task<User?> GetUserByEmailAsync(string email);

        Task<User?> GetUserByIdAsync(int userId);

        void AddUser(User user);

        Task SaveChangesAsync();
    }
}