using HotelManagerAPI.Entities;
using HotelManagerAPI.Models;

namespace HotelManagerAPI.Repositories
{
    public interface IGuestRepository
    {
        Task<GuestDto> GetGuestAsync(Guid guestId);

        Task AddGuestAsync(Guest guest);

        Task SaveChangesAsync();
    }
}